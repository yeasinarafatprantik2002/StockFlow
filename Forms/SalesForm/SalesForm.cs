using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using StockFlow.Data;
using StockFlow.Models;
using StockFlow.Utilities;
using StockFlow.Services;

namespace StockFlow.Forms
{
    public partial class SalesForm : Form
    {
        // Fields are now in SalesForm.Designer.cs
        private readonly SalesService? _salesService;
        private readonly User? _currentUser;

        public SalesForm()
        {
            InitializeComponent();
            LoadDesignerPreview();
        }

        public SalesForm(User currentUser)
        {
            _currentUser = currentUser;
            var context = new AppDbContext();
            _salesService = new SalesService(context);
            InitializeComponent();
            ApplyPermissions();
            LoadSales();
        }

        private void DgvSales_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.CellStyle == null)
            {
                return;
            }

            if (dgvSales.Columns[e.ColumnIndex].Name == "Total" && e.Value != null)
            {
                e.CellStyle.ForeColor = Color.FromArgb(46, 204, 113); // Emerald Green
                e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
        }

        private void StyleButton(Button btn, string text, Color color)
        {
            btn.Text = text;
            btn.Size = new Size(130, 45);
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Margin = new Padding(5);
        }

        private async void LoadSales()
        {
            if (_salesService == null)
            {
                return;
            }
            UpdateGrid(await _salesService.GetAllSalesAsync());
        }

        private void ApplyPermissions()
        {
            if (_currentUser != null && _currentUser.Role == "PartTimeStaff")
            {
                btnNewSale.Visible = false;
            }
            else
            {
                btnNewSale.Visible = true;
            }
        }

        private void UpdateGrid(System.Collections.Generic.List<Sale> sales)
        {
            List<object> rows = new List<object>();
            foreach (Sale sale in sales)
            {
                int itemsCount = 0;
                if (sale.SaleItems != null)
                {
                    itemsCount = sale.SaleItems.Count;
                }

                string staffName = "N/A";
                if (sale.User != null)
                {
                    staffName = sale.User.Username;
                }

                rows.Add(new
                {
                    ID = $"#INV-{sale.Id:D5}",
                    DateTime = sale.Date.ToLocalTime().ToString("MMM dd, HH:mm"),
                    ItemsCount = itemsCount,
                    Total = sale.TotalAmount.ToString("C2"),
                    Staff = staffName
                });
            }

            dgvSales.DataSource = rows;
            DesignModeHelper.ClearGridSelection(dgvSales);
        }

        private void LoadDesignerPreview()
        {
            if (!DesignModeHelper.IsActive)
            {
                return;
            }

            dgvSales.DataSource = new[]
            {
                new { ID = "#INV-00041", DateTime = "May 20, 10:30", ItemsCount = 3, Total = "$86.50", Staff = "admin" },
                new { ID = "#INV-00040", DateTime = "May 20, 09:15", ItemsCount = 1, Total = "$18.00", Staff = "staff01" },
                new { ID = "#INV-00039", DateTime = "May 19, 18:45", ItemsCount = 5, Total = "$142.25", Staff = "admin" }
            };
            DesignModeHelper.ClearGridSelection(dgvSales);
        }

        private async void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            if (_salesService == null)
            {
                return;
            }
            UpdateGrid(await _salesService.SearchSalesAsync(txtSearch.Text));
        }

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            LoadSales();
        }

        private void BtnNewSale_Click(object? sender, EventArgs e)
        {
            if (_currentUser != null && new NewSaleForm(_currentUser).ShowDialog() == DialogResult.OK)
            {
                LoadSales();
            }
        }
    }
}
