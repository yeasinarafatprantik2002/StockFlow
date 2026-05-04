using Microsoft.EntityFrameworkCore;
using StockFlow.Models;

namespace StockFlow.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<StockTransaction> StockTransactions { get; set; } = null!;
        public DbSet<Sale> Sales { get; set; } = null!;
        public DbSet<SaleItem> SaleItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost\\MSSQLSERVER01;Initial Catalog=stockFlow;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;Command Timeout=0");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed an initial Admin user if desired, but we can do that later or in AuthService.
            // Setup constraints (e.g. unique username)
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }
    }
}
