using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using StockFlow.Data;
using StockFlow.Models;
using StockFlow.Services;

namespace StockFlow.Forms
{
    public partial class SalesForm : Form
    {
        // Fields are now in SalesForm.Designer.cs
        private readonly SalesService _salesService;
        private readonly User _currentUser;

        public SalesForm(User currentUser)
        {
            _currentUser = currentUser;
            var context = new AppDbContext();
            _salesService = new SalesService(context);
            InitializeComponent();
            LoadSales();
        }

        private void DgvSales_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSales.Columns[e.ColumnIndex].Name == "Total" && e.Value != null)
            {
                e.CellStyle.ForeColor = Color.FromArgb(46, 204, 113); // Emerald Green
                e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
        }

        private void StyleButton(Button btn, string text, Color color)
        {
            btn.Text = text; btn.Size = new Size(130, 45); btn.BackColor = color; btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0; btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Cursor = Cursors.Hand; btn.Margin = new Padding(5);
        }

        private async void LoadSales() => UpdateGrid(await _salesService.GetAllSalesAsync());

        private void UpdateGrid(System.Collections.Generic.List<Sale> sales)
        {
            dgvSales.DataSource = sales.Select(s => new { 
                ID = $"#INV-{s.Id:D5}",
                DateTime = s.Date.ToLocalTime().ToString("MMM dd, HH:mm"), 
                ItemsCount = s.SaleItems?.Count ?? 0, 
                Total = s.TotalAmount.ToString("C2"), 
                Staff = s.User?.Username ?? "N/A"
            }).ToList();
        }
    }
}
