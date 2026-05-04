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
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToListAsync();
        }

        public async Task<List<Product>> SearchProductsAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return await GetAllProductsAsync();

            query = query.ToLower();
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Where(p => p.Name.ToLower().Contains(query) || p.Category.Name.ToLower().Contains(query))
                .ToListAsync();
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
            var query = _context.StockTransactions
                .Include(t => t.Product)
                .Include(t => t.User)
                .AsQueryable();

            if (productId.HasValue)
                query = query.Where(t => t.ProductId == productId.Value);

            return await query.OrderByDescending(t => t.Date).ToListAsync();
        }

        public async Task<bool> AdjustStockAsync(int productId, int adjustment, string type, int userId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var product = await _context.Products.FindAsync(productId);
                if (product == null) return false;

                product.Quantity += adjustment;
                if (product.Quantity < 0) return false;

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
