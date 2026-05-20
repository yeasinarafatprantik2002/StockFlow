using Microsoft.EntityFrameworkCore;
using StockFlow.Data;
using StockFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockFlow.Services
{
    public class SalesService
    {
        private readonly AppDbContext _context;

        public SalesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sale>> GetAllSalesAsync()
        {
            List<Sale> sales = await _context.Sales
                .Include("User")
                .Include("SaleItems.Product")
                .ToListAsync();
            sales.Sort(CompareSalesByDateDescending);
            return sales;
        }

        public async Task<List<Sale>> SearchSalesAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return await GetAllSalesAsync();
            }

            query = query.ToLower();
            List<Sale> allSales = await GetAllSalesAsync();
            List<Sale> result = new List<Sale>();
            foreach (Sale sale in allSales)
            {
                bool userMatches = sale.User != null && sale.User.Username.ToLower().Contains(query);
                bool idMatches = sale.Id.ToString() == query;
                if (userMatches || idMatches)
                {
                    result.Add(sale);
                }
            }
            result.Sort(CompareSalesByDateDescending);
            return result;
        }

        private static int CompareSalesByDateDescending(Sale first, Sale second)
        {
            return second.Date.CompareTo(first.Date);
        }

        public async Task<bool> CreateSaleAsync(int userId, List<SaleItem> items)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    decimal totalAmount = 0;
                    var sale = new Sale
                    {
                        UserId = userId,
                        Date = DateTime.UtcNow
                    };

                    await _context.Sales.AddAsync(sale);
                    await _context.SaveChangesAsync();

                    foreach (var item in items)
                    {
                        var product = await _context.Products.FindAsync(item.ProductId);
                        if (product == null || product.Quantity < item.Quantity)
                        {
                            await transaction.RollbackAsync();
                            return false;
                        }

                        product.Quantity -= item.Quantity;

                        item.SaleId = sale.Id;
                        await _context.SaleItems.AddAsync(item);

                        var stockTx = new StockTransaction
                        {
                            ProductId = item.ProductId,
                            Quantity = -item.Quantity,
                            TransactionType = "Sale",
                            Date = DateTime.UtcNow,
                            UserId = userId
                        };
                        await _context.StockTransactions.AddAsync(stockTx);

                        totalAmount += item.Quantity * item.UnitPrice;
                    }

                    sale.TotalAmount = totalAmount;
                    _context.Sales.Update(sale);

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
    }
}
