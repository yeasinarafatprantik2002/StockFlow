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
    public partial class ProductForm : Form
    {
        // Fields are now in ProductForm.Designer.cs
        private readonly ProductService? _productService;
        private readonly User? _currentUser;

        public ProductForm()
        {
            InitializeComponent();
            LoadDesignerPreview();
        }

        public ProductForm(User currentUser)
        {
            _currentUser = currentUser;
            var context = new AppDbContext();
            _productService = new ProductService(context);

            InitializeComponent();
            ApplyPermissions();
            LoadProducts();
        }

        private void DgvProducts_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.CellStyle == null)
            {
                return;
            }

            if (dgvProducts.Columns[e.ColumnIndex].Name == "Stock" && e.Value != null)
            {
                int stock = (int)e.Value;
                if (stock == 0)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else if (stock < 10)
                {
                    e.CellStyle.ForeColor = Color.Orange;
                }
            }
            if (dgvProducts.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString() ?? "";
                if (status == "OUT OF STOCK")
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else if (status == "LOW STOCK")
                {
                    e.CellStyle.ForeColor = Color.Orange;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Green;
                }
                e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
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

        private async void LoadProducts()
        {
            if (_productService == null)
            {
                return;
            }
            UpdateGrid(await _productService.GetAllProductsAsync());
        }

        private void ApplyPermissions()
        {
            bool canManage = false;
            if (_currentUser != null)
            {
                if (_currentUser.Role == "SuperAdmin" || _currentUser.Role == "Admin")
                {
                    canManage = true;
                }
            }
            btnAdd.Visible = canManage;
            btnEdit.Visible = canManage;
            btnDelete.Visible = canManage;
        }

        private void UpdateGrid(System.Collections.Generic.List<Product> products)
        {
            List<object> rows = new List<object>();
            foreach (Product product in products)
            {
                string categoryName = "";
                if (product.Category != null)
                {
                    categoryName = product.Category.Name;
                }

                string status = "IN STOCK";
                if (product.Quantity == 0)
                {
                    status = "OUT OF STOCK";
                }
                else if (product.Quantity < 10)
                {
                    status = "LOW STOCK";
                }

                rows.Add(new
                {
                    product.Id,
                    product.Name,
                    Category = categoryName,
                    Price = product.Price.ToString("C2"),
                    Stock = product.Quantity,
                    Status = status,
                    TotalValue = (product.Price * product.Quantity).ToString("C2")
                });
            }

            dgvProducts.DataSource = rows;
            DesignModeHelper.ClearGridSelection(dgvProducts);
        }

        private async void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            if (_productService == null)
            {
                return;
            }
            UpdateGrid(await _productService.SearchProductsAsync(txtSearch.Text));
        }

        private void LoadDesignerPreview()
        {
            if (!DesignModeHelper.IsActive)
            {
                return;
            }

            dgvProducts.DataSource = new[]
            {
                new { Id = 1, Name = "Wireless Mouse", Category = "Accessories", Price = "$18.00", Stock = 24, Status = "IN STOCK", TotalValue = "$432.00" },
                new { Id = 2, Name = "USB-C Cable", Category = "Cables", Price = "$7.50", Stock = 8, Status = "LOW STOCK", TotalValue = "$60.00" },
                new { Id = 3, Name = "Keyboard", Category = "Accessories", Price = "$32.00", Stock = 0, Status = "OUT OF STOCK", TotalValue = "$0.00" }
            };
            DesignModeHelper.ClearGridSelection(dgvProducts);
        }

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            LoadProducts();
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (new ProductEntryForm().ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
            }
        }

        private async void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                int id = (int)dgvProducts.SelectedRows[0].Cells["Id"].Value;
                if (_productService == null)
                {
                    return;
                }
                var product = await _productService.GetProductByIdAsync(id);
                if (product != null && new ProductEntryForm(product).ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                }
            }
        }

        private async void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Delete this product?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int id = (int)dgvProducts.SelectedRows[0].Cells["Id"].Value;
                    if (_productService == null)
                    {
                        return;
                    }
                    await _productService.DeleteProductAsync(id);
                    LoadProducts();
                }
            }
        }
    }
}
