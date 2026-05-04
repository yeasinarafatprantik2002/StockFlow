using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockFlow.Data;
using StockFlow.Forms;
using StockFlow.Models;
using StockFlow.Repositories;
using StockFlow.Services;

namespace StockFlow
{
    internal static class Program
    {
        [STAThread]
        static async Task Main()
        {
            ApplicationConfiguration.Initialize();

            // Seed Super Admin if not exists
            using (var context = new AppDbContext())
            {
                // Ensure database is created/migrated
                context.Database.EnsureCreated();

                var userRepository = new Repository<User>(context);
                var authService = new AuthService(userRepository);

                var superAdmins = await userRepository.FindAsync(u => u.Role == "SuperAdmin");
                if (!superAdmins.Any())
                {
                    await authService.RegisterAsync("superadmin", "superadmin", "SuperAdmin");
                }

                // Seed initial data if the database is empty
                await DataSeeder.SeedAsync();
            }

            Application.Run(new LoginForm());
        }
    }
}