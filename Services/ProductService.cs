using Microsoft.EntityFrameworkCore;
using StockFlow.Data;
using StockFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockFlow.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            List<Product> products = await _context.Products
                .Include("Category")
                .Include("Supplier")
                .ToListAsync();

            foreach (Product product in products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            return null;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                .Include("Category")
                .Include("Supplier")
                .ToListAsync();
        }

        public async Task<List<Product>> SearchProductsAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return await GetAllProductsAsync();
            }

            query = query.ToLower();
            List<Product> products = await GetAllProductsAsync();
            List<Product> result = new List<Product>();
            foreach (Product product in products)
            {
                bool nameMatches = product.Name.ToLower().Contains(query);
                bool categoryMatches = product.Category != null && product.Category.Name.ToLower().Contains(query);
                if (nameMatches || categoryMatches)
                {
                    result.Add(product);
                }
            }
            return result;
        }

        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<StockTransaction>> GetStockLedgerAsync(int? productId = null)
        {
            List<StockTransaction> allTransactions = await _context.StockTransactions
                .Include("Product")
                .Include("User")
                .ToListAsync();

            List<StockTransaction> filteredTransactions = new List<StockTransaction>();
            foreach (StockTransaction transaction in allTransactions)
            {
                if (!productId.HasValue || transaction.ProductId == productId.Value)
                {
                    filteredTransactions.Add(transaction);
                }
            }

            filteredTransactions.Sort(CompareStockTransactionsByDateDescending);
            return filteredTransactions;
        }

        private static int CompareStockTransactionsByDateDescending(StockTransaction first, StockTransaction second)
        {
            return second.Date.CompareTo(first.Date);
        }

        public async Task<bool> AdjustStockAsync(int productId, int adjustment, string type, int userId)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    var product = await _context.Products.FindAsync(productId);
                    if (product == null)
                    {
                        return false;
                    }

                    product.Quantity += adjustment;
                    if (product.Quantity < 0)
                    {
                        return false;
                    }

                    var stockTx = new StockTransaction
                    {
                        ProductId = productId,
                        Quantity = adjustment,
                        TransactionType = type,
                        Date = DateTime.UtcNow,
                        UserId = userId
                    };

                    await _context.StockTransactions.AddAsync(stockTx);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return true;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
    }
}
