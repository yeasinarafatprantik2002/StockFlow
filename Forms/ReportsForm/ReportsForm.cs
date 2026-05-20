using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using StockFlow.Data;
using StockFlow.Models;
using StockFlow.Utilities;

namespace StockFlow.Forms
{
    public partial class ReportsForm : Form
    {
        // Fields are now in ReportsForm.Designer.cs
        private readonly User? _user;

        public ReportsForm()
        {
            InitializeComponent();
            LoadDesignerPreview();
        }

        public ReportsForm(User user)
        {
            _user = user;
            InitializeComponent();
            ApplyPermissions();
            LoadReports();
        }



        private async void LoadReports()
        {
            if (_user == null)
            {
                return;
            }

            using (AppDbContext context = new AppDbContext())
            {
                if (_user.Role == "SuperAdmin")
                {
                    DateTime now = DateTime.UtcNow;
                    DateTime today = now.Date;
                    DateTime firstOfMonth = new DateTime(now.Year, now.Month, 1);

                    List<Sale> sales = await context.Sales.ToListAsync();
                    decimal allTime = 0;
                    decimal month = 0;
                    decimal todayVal = 0;
                    foreach (Sale sale in sales)
                    {
                        allTime += sale.TotalAmount;
                        if (sale.Date >= firstOfMonth)
                        {
                            month += sale.TotalAmount;
                        }
                        if (sale.Date >= today)
                        {
                            todayVal += sale.TotalAmount;
                        }
                    }

                    lblTotalRevenue.Text = allTime.ToString("C2");
                    lblMonthRevenue.Text = month.ToString("C2");
                    lblTodayRevenue.Text = todayVal.ToString("C2");
                }

                List<SaleItem> saleItems = await context.SaleItems.Include("Product").ToListAsync();
                Dictionary<string, ProductReportRow> productTotals = new Dictionary<string, ProductReportRow>();
                foreach (SaleItem saleItem in saleItems)
                {
                    string productName = "Unknown";
                    if (saleItem.Product != null)
                    {
                        productName = saleItem.Product.Name;
                    }

                    if (!productTotals.ContainsKey(productName))
                    {
                        productTotals[productName] = new ProductReportRow();
                        productTotals[productName].Product = productName;
                    }

                    productTotals[productName].UnitsSold += saleItem.Quantity;
                    productTotals[productName].Revenue += saleItem.Quantity * saleItem.UnitPrice;
                }

                List<ProductReportRow> reportRows = new List<ProductReportRow>();
                foreach (ProductReportRow row in productTotals.Values)
                {
                    reportRows.Add(row);
                }
                reportRows.Sort(CompareProductReportRows);

                List<object> topProducts = new List<object>();
                int maxRows = Math.Min(20, reportRows.Count);
                for (int i = 0; i < maxRows; i++)
                {
                    topProducts.Add(new
                    {
                        Product = reportRows[i].Product,
                        UnitsSold = reportRows[i].UnitsSold,
                        TotalRevenue = reportRows[i].Revenue.ToString("C2")
                    });
                }

                dgvTopProducts.DataSource = topProducts;
                DesignModeHelper.ClearGridSelection(dgvTopProducts);
            }
        }

        private static int CompareProductReportRows(ProductReportRow first, ProductReportRow second)
        {
            return second.UnitsSold.CompareTo(first.UnitsSold);
        }

        private class ProductReportRow
        {
            public string Product
            {
                get;
                set;
            } = "";

            public int UnitsSold
            {
                get;
                set;
            }

            public decimal Revenue
            {
                get;
                set;
            }
        }

        private void ApplyPermissions()
        {
            bool showRevenue = false;
            if (_user != null && _user.Role == "SuperAdmin")
            {
                showRevenue = true;
            }

            if (lblTodayRevenue.Parent != null && lblTodayRevenue.Parent.Parent != null)
            {
                lblTodayRevenue.Parent.Parent.Visible = showRevenue;
            }
        }

        private void LoadDesignerPreview()
        {
            if (!DesignModeHelper.IsActive)
            {
                return;
            }

            lblTodayRevenue.Text = "$1,245.00";
            lblMonthRevenue.Text = "$18,920.00";
            lblTotalRevenue.Text = "$86,410.00";
            dgvTopProducts.DataSource = new[]
            {
                new { Product = "Wireless Mouse", UnitsSold = 58, TotalRevenue = "$1,044.00" },
                new { Product = "USB-C Cable", UnitsSold = 44, TotalRevenue = "$330.00" },
                new { Product = "Keyboard", UnitsSold = 31, TotalRevenue = "$992.00" }
            };
            DesignModeHelper.ClearGridSelection(dgvTopProducts);
        }

        private void ReportCard_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Control control)
            {
                ControlPaint.DrawBorder(e.Graphics, control.ClientRectangle, Color.FromArgb(230, 230, 230), ButtonBorderStyle.Solid);
            }
        }
    }
}
