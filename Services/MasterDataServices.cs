using Microsoft.EntityFrameworkCore;
using StockFlow.Data;
using StockFlow.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockFlow.Services
{
    public class CategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.Include(c => c.Products).ToListAsync();
        }

        public async Task<List<Category>> SearchCategoriesAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return await GetAllCategoriesAsync();

            query = query.ToLower();
            return await _context.Categories
                .Include(c => c.Products)
                .Where(c => c.Name.ToLower().Contains(query))
                .ToListAsync();
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }

    public class SupplierService
    {
        private readonly AppDbContext _context;

        public SupplierService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Supplier?> GetSupplierByIdAsync(int id)
        {
            return await _context.Suppliers.Include(s => s.Products).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Supplier>> GetAllSuppliersAsync()
        {
            return await _context.Suppliers.Include(s => s.Products).ToListAsync();
        }

        public async Task<List<Supplier>> SearchSuppliersAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return await GetAllSuppliersAsync();

            query = query.ToLower();
            return await _context.Suppliers
                .Include(s => s.Products)
                .Where(s => s.Name.ToLower().Contains(query) || s.ContactInfo.ToLower().Contains(query))
                .ToListAsync();
        }

        public async Task AddSupplierAsync(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSupplierAsync(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
            }
        }
    }
}
