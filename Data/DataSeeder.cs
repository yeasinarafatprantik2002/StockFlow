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
            using (AppDbContext context = new AppDbContext())
            {
                if (await context.Products.AnyAsync())
                {
                    return;
                }

                List<Category> categories = new List<Category>();
                string[] catNames = { "Electronics", "Clothing", "Home & Garden", "Beauty", "Sports", "Toys", "Books", "Automotive", "Grocery", "Tools" };
                foreach (string name in catNames)
                {
                    categories.Add(new Category { Name = name });
                }
                await context.Categories.AddRangeAsync(categories);

                List<Supplier> suppliers = new List<Supplier>();
                string[] supNames = { "Global Tech Distribution", "StyleHub Fashion", "HomePro Logistics", "NatureCare Supplies", "AutoPart Direct" };
                foreach (string name in supNames)
                {
                    suppliers.Add(new Supplier { Name = name, ContactInfo = $"contact@{name.Replace(" ", "").ToLower()}.com" });
                }
                await context.Suppliers.AddRangeAsync(suppliers);
                
                await context.SaveChangesAsync();

                Random random = new Random();
                List<Product> products = new List<Product>();
                
                for (int i = 1; i <= 100; i++)
                {
                    Category category = categories[random.Next(categories.Count)];
                    Supplier supplier = suppliers[random.Next(suppliers.Count)];
                    
                    products.Add(new Product
                    {
                        Name = $"Product {i} - {category.Name}",
                        Price = (decimal)(random.NextDouble() * 950 + 50),
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
}
