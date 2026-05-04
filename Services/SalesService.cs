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
            return await _context.Sales
                .Include(s => s.User)
                .Include(s => s.SaleItems)
                    .ThenInclude(si => si.Product)
                .OrderByDescending(s => s.Date)
                .ToListAsync();
        }

        public async Task<List<Sale>> SearchSalesAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return await GetAllSalesAsync();

            query = query.ToLower();
            return await _context.Sales
                .Include(s => s.User)
                .Include(s => s.SaleItems)
                .Where(s => s.User.Username.ToLower().Contains(query) || s.Id.ToString() == query)
                .OrderByDescending(s => s.Date)
                .ToListAsync();
        }

        public async Task<bool> CreateSaleAsync(int userId, List<SaleItem> items)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                decimal totalAmount = 0;
                var sale = new Sale
                {
                    UserId = userId,
                    Date = DateTime.UtcNow
                };

                await _context.Sales.AddAsync(sale);
                await _context.SaveChangesAsync(); // To get the SaleId

                foreach (var item in items)
                {
                    var product = await _context.Products.FindAsync(item.ProductId);
                    if (product == null || product.Quantity < item.Quantity)
                    {
                        // Insufficient stock
                        await transaction.RollbackAsync();
                        return false;
                    }

                    product.Quantity -= item.Quantity; // Reduce stock

                    item.SaleId = sale.Id;
                    await _context.SaleItems.AddAsync(item);

                    // Record stock transaction
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
