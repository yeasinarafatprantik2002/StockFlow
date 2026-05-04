using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using StockFlow.Data;
using StockFlow.Models;

namespace StockFlow.Forms
{
    public partial class ReportsForm : Form
    {
        // Fields are now in ReportsForm.Designer.cs
        private readonly User _user;

        public ReportsForm(User user)
        {
            _user = user;
            InitializeComponent();
            LoadReports();
        }



        private async void LoadReports()
        {
            using var context = new AppDbContext();
            
            if (_user.Role == "SuperAdmin")
            {
                var now = DateTime.UtcNow;
                var today = now.Date;
                var firstOfMonth = new DateTime(now.Year, now.Month, 1);

                decimal allTime = await context.Sales.SumAsync(s => (decimal?)s.TotalAmount) ?? 0;
                decimal month = await context.Sales.Where(s => s.Date >= firstOfMonth).SumAsync(s => (decimal?)s.TotalAmount) ?? 0;
                decimal todayVal = await context.Sales.Where(s => s.Date >= today).SumAsync(s => (decimal?)s.TotalAmount) ?? 0;

                lblTotalRevenue.Text = allTime.ToString("C2");
                lblMonthRevenue.Text = month.ToString("C2");
                lblTodayRevenue.Text = todayVal.ToString("C2");
            }

            var topProducts = await context.SaleItems
                .GroupBy(si => si.Product.Name)
                .Select(g => new { 
                    Product = g.Key, 
                    UnitsSold = g.Sum(si => si.Quantity), 
                    TotalRevenue = g.Sum(si => si.Quantity * si.UnitPrice).ToString("C2") 
                })
                .OrderByDescending(x => x.UnitsSold).Take(20).ToListAsync();
            dgvTopProducts.DataSource = topProducts;
        }
    }
}
