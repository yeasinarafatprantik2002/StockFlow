using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockFlow.Data;
using StockFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace StockFlow.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync()
        {
            using var context = new AppDbContext();
            
            // Check if products already exist to avoid duplication
            if (await context.Products.AnyAsync()) return;

            // 1. Seed 10 Categories
            var categories = new List<Category>();
            string[] catNames = { "Electronics", "Clothing", "Home & Garden", "Beauty", "Sports", "Toys", "Books", "Automotive", "Grocery", "Tools" };
            foreach (var name in catNames)
            {
                categories.Add(new Category { Name = name });
            }
            await context.Categories.AddRangeAsync(categories);

            // 2. Seed 5 Suppliers
            var suppliers = new List<Supplier>();
            string[] supNames = { "Global Tech Distribution", "StyleHub Fashion", "HomePro Logistics", "NatureCare Supplies", "AutoPart Direct" };
            foreach (var name in supNames)
            {
                suppliers.Add(new Supplier { Name = name, ContactInfo = $"contact@{name.Replace(" ", "").ToLower()}.com" });
            }
            await context.Suppliers.AddRangeAsync(suppliers);
            
            await context.SaveChangesAsync();

            // 3. Seed 100 Products
            var random = new Random();
            var products = new List<Product>();
            
            for (int i = 1; i <= 100; i++)
            {
                var category = categories[random.Next(categories.Count)];
                var supplier = suppliers[random.Next(suppliers.Count)];
                
                products.Add(new Product
                {
                    Name = $"Product {i} - {category.Name}",
                    Price = (decimal)(random.NextDouble() * 950 + 50), // Range $50 - $1000
                    Quantity = random.Next(5, 200),
                    CategoryId = category.Id,
                    SupplierId = supplier.Id
                });
            }

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();
        }
    }
}
