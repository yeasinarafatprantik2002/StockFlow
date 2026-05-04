using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using StockFlow.Data;
using StockFlow.Models;
using StockFlow.Services;

namespace StockFlow.Forms
{
    public partial class ProductForm : Form
    {
        // Fields are now in ProductForm.Designer.cs
        private readonly ProductService _productService;
        private readonly User _currentUser;

        public ProductForm(User currentUser)
        {
            _currentUser = currentUser;
            var context = new AppDbContext();
            _productService = new ProductService(context);

            InitializeComponent();
            LoadProducts();
        }

        private void DgvProducts_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvProducts.Columns[e.ColumnIndex].Name == "Stock" && e.Value != null)
            {
                int stock = (int)e.Value;
                if (stock == 0) e.CellStyle.ForeColor = Color.Red;
                else if (stock < 10) e.CellStyle.ForeColor = Color.Orange;
            }
            if (dgvProducts.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString() ?? "";
                if (status == "OUT OF STOCK") e.CellStyle.ForeColor = Color.Red;
                else if (status == "LOW STOCK") e.CellStyle.ForeColor = Color.Orange;
                else e.CellStyle.ForeColor = Color.Green;
                e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }
        }

        private void StyleButton(Button btn, string text, Color color)
        {
            btn.Text = text; btn.Size = new Size(130, 45); btn.BackColor = color; btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0; btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Cursor = Cursors.Hand; btn.Margin = new Padding(5);
        }

        private async void LoadProducts() => UpdateGrid(await _productService.GetAllProductsAsync());

        private void UpdateGrid(System.Collections.Generic.List<Product> products)
        {
            dgvProducts.DataSource = products.Select(p => new { 
                p.Id, 
                p.Name, 
                Category = p.Category?.Name, 
                Price = p.Price.ToString("C2"), 
                Stock = p.Quantity,
                Status = p.Quantity == 0 ? "OUT OF STOCK" : (p.Quantity < 10 ? "LOW STOCK" : "IN STOCK"),
                TotalValue = (p.Price * p.Quantity).ToString("C2")
            }).ToList();
        }

        private async void TxtSearch_TextChanged(object? sender, EventArgs e) => UpdateGrid(await _productService.SearchProductsAsync(txtSearch.Text));
        private void BtnRefresh_Click(object? sender, EventArgs e) => LoadProducts();
        private void BtnAdd_Click(object? sender, EventArgs e) { if (new ProductEntryForm().ShowDialog() == DialogResult.OK) LoadProducts(); }

        private async void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int id = (int)dgvProducts.SelectedRows[0].Cells["Id"].Value;
                var product = await _productService.GetProductByIdAsync(id);
                if (product != null && new ProductEntryForm(product).ShowDialog() == DialogResult.OK) LoadProducts();
            }
        }

        private async void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Delete this product?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int id = (int)dgvProducts.SelectedRows[0].Cells["Id"].Value;
                    await _productService.DeleteProductAsync(id);
                    LoadProducts();
                }
            }
        }
    }
}
