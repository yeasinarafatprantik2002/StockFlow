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
            List<Category> categories = await _context.Categories.Include("Products").ToListAsync();
            foreach (Category category in categories)
            {
                if (category.Id == id)
                {
                    return category;
                }
            }
            return null;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.Include("Products").ToListAsync();
        }

        public async Task<List<Category>> SearchCategoriesAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return await GetAllCategoriesAsync();
            }

            query = query.ToLower();
            List<Category> allCategories = await GetAllCategoriesAsync();
            List<Category> result = new List<Category>();
            foreach (Category category in allCategories)
            {
                if (category.Name.ToLower().Contains(query))
                {
                    result.Add(category);
                }
            }
            return result;
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
            List<Supplier> suppliers = await _context.Suppliers.Include("Products").ToListAsync();
            foreach (Supplier supplier in suppliers)
            {
                if (supplier.Id == id)
                {
                    return supplier;
                }
            }
            return null;
        }

        public async Task<List<Supplier>> GetAllSuppliersAsync()
        {
            return await _context.Suppliers.Include("Products").ToListAsync();
        }

        public async Task<List<Supplier>> SearchSuppliersAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return await GetAllSuppliersAsync();
            }

            query = query.ToLower();
            List<Supplier> allSuppliers = await GetAllSuppliersAsync();
            List<Supplier> result = new List<Supplier>();
            foreach (Supplier supplier in allSuppliers)
            {
                bool nameMatches = supplier.Name.ToLower().Contains(query);
                bool contactMatches = supplier.ContactInfo != null && supplier.ContactInfo.ToLower().Contains(query);
                if (nameMatches || contactMatches)
                {
                    result.Add(supplier);
                }
            }
            return result;
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
