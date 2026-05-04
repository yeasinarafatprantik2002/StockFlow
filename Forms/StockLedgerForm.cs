using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using StockFlow.Data;
using StockFlow.Services;

namespace StockFlow.Forms
{
    public partial class StockLedgerForm : Form
    {
        // Fields are now in StockLedgerForm.Designer.cs
        private readonly ProductService _productService;

        public StockLedgerForm()
        {
            var context = new AppDbContext();
            _productService = new ProductService(context);
            InitializeComponent();
            LoadLedger();
        }

        private void DgvLedger_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLedger.Columns[e.ColumnIndex].Name == "Change" && e.Value != null)
            {
                string val = e.Value.ToString() ?? "";
                if (val.StartsWith("+")) e.CellStyle.ForeColor = Color.Green;
                else if (val.StartsWith("-")) e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
        }

        private async void LoadLedger()
        {
            var transactions = await _productService.GetStockLedgerAsync();
            dgvLedger.DataSource = transactions.Select(t => new {
                Date = t.Date.ToLocalTime().ToString("MMM dd, HH:mm"),
                Product = t.Product?.Name ?? "Unknown",
                Change = t.Quantity > 0 ? $"+{t.Quantity}" : t.Quantity.ToString(),
                Type = t.TransactionType.ToUpper(),
                By = t.User?.Username ?? "System"
            }).ToList();
        }
    }
}
