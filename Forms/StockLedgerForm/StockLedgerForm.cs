using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using StockFlow.Data;
using StockFlow.Models;
using StockFlow.Services;
using StockFlow.Utilities;

namespace StockFlow.Forms
{
    public partial class StockLedgerForm : Form
    {
        // Fields are now in StockLedgerForm.Designer.cs
        private readonly ProductService? _productService;

        public StockLedgerForm()
        {
            InitializeComponent();

            if (!DesignModeHelper.IsActive)
            {
                var context = new AppDbContext();
                _productService = new ProductService(context);
                LoadLedger();
            }
            else
            {
                LoadDesignerPreview();
            }
        }

        private void DgvLedger_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.CellStyle == null)
            {
                return;
            }

            if (dgvLedger.Columns[e.ColumnIndex].Name == "Change" && e.Value != null)
            {
                string val = e.Value.ToString() ?? "";
                if (val.StartsWith("+"))
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                else if (val.StartsWith("-"))
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
        }

        private async void LoadLedger()
        {
            if (_productService == null)
            {
                return;
            }

            var transactions = await _productService.GetStockLedgerAsync();
            List<object> rows = new List<object>();
            foreach (StockTransaction transaction in transactions)
            {
                string productName = "Unknown";
                if (transaction.Product != null)
                {
                    productName = transaction.Product.Name;
                }

                string username = "System";
                if (transaction.User != null)
                {
                    username = transaction.User.Username;
                }

                string change = transaction.Quantity.ToString();
                if (transaction.Quantity > 0)
                {
                    change = $"+{transaction.Quantity}";
                }

                rows.Add(new
                {
                    Date = transaction.Date.ToLocalTime().ToString("MMM dd, HH:mm"),
                    Product = productName,
                    Change = change,
                    Type = transaction.TransactionType.ToUpper(),
                    By = username
                });
            }

            dgvLedger.DataSource = rows;
            DesignModeHelper.ClearGridSelection(dgvLedger);
        }

        private void LoadDesignerPreview()
        {
            dgvLedger.DataSource = new[]
            {
                new { Date = "May 20, 10:20", Product = "Wireless Mouse", Change = "+25", Type = "STOCKIN", By = "admin" },
                new { Date = "May 20, 11:05", Product = "USB-C Cable", Change = "-4", Type = "STOCKOUT", By = "staff01" },
                new { Date = "May 19, 16:30", Product = "Keyboard", Change = "+12", Type = "STOCKIN", By = "admin" }
            };
            DesignModeHelper.ClearGridSelection(dgvLedger);
        }

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            LoadLedger();
        }
    }
}
