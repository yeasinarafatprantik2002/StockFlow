using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using StockFlow.Data;
using StockFlow.Models;
using StockFlow.Utilities;
using StockFlow.Services;

namespace StockFlow.Forms
{
    public partial class StockManagementForm : Form
    {
        // Fields are now in StockManagementForm.Designer.cs
        private readonly ProductService? _productService;
        private readonly User? _currentUser;

        public StockManagementForm()
        {
            InitializeComponent();
            LoadDesignerPreview();
        }

        public StockManagementForm(User currentUser)
        {
            _currentUser = currentUser;
            var context = new AppDbContext();
            _productService = new ProductService(context);
            InitializeComponent();
            LoadProducts();
        }



        private async void LoadProducts()
        {
            if (_productService == null)
            {
                return;
            }

            cmbProducts.DataSource = await _productService.GetAllProductsAsync();
            cmbProducts.SelectedIndexChanged += CmbProducts_SelectedIndexChanged;
            UpdateCurrentStockLabel();
        }

        private void CmbProducts_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateCurrentStockLabel();
        }

        private void UpdateCurrentStockLabel()
        {
            Product? product = cmbProducts.SelectedItem as Product;
            if (product == null)
            {
                return;
            }

            lblCurrentStock.Text = $"Current Inventory: {product.Quantity} units";
            if (product.Quantity < 10)
            {
                lblCurrentStock.ForeColor = Color.FromArgb(231, 76, 60);
            }
            else
            {
                lblCurrentStock.ForeColor = Color.FromArgb(46, 204, 113);
            }
        }

        private void LoadDesignerPreview()
        {
            if (!DesignModeHelper.IsActive)
            {
                return;
            }

            cmbProducts.Items.Add(new { Id = 1, Name = "Wireless Mouse" });
            cmbProducts.Items.Add(new { Id = 2, Name = "USB-C Cable" });
            cmbProducts.Items.Add(new { Id = 3, Name = "Keyboard" });
            cmbProducts.SelectedIndex = 0;
            lblCurrentStock.Text = "Current Inventory: 24 units";
            lblCurrentStock.ForeColor = Color.FromArgb(46, 204, 113);
            txtQuantity.Text = "10";
            txtNote.Text = "Opening stock correction";
            lblMessage.Text = "Ready for stock adjustment";
            StockManagementForm_Resize(this, EventArgs.Empty);
        }

        private async void BtnSubmit_Click(object? sender, EventArgs e)
        {
            if (_productService == null || _currentUser == null)
            {
                return;
            }

            if (cmbProducts.SelectedItem == null || !int.TryParse(txtQuantity.Text, out int qty) || qty == 0)
            {
                return;
            }
            var product = (Product)cmbProducts.SelectedItem;
            btnSubmit.Enabled = false;
            try
            {
                string type = rbStockIn.Checked ? "StockIn" : "StockOut";
                if (rbStockOut.Checked)
                {
                    qty = -Math.Abs(qty);
                }

                if (await _productService.AdjustStockAsync(product.Id, qty, type, _currentUser.Id))
                {
                    lblMessage.Text = "Stock adjusted successfully!";
                    lblMessage.ForeColor = Color.Green;
                    txtQuantity.Text = "0";
                    txtNote.Clear();
                }
                else
                {
                    lblMessage.Text = "Insufficient stock for this operation!";
                    lblMessage.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
            btnSubmit.Enabled = true;
        }

        private void StockManagementForm_Resize(object? sender, EventArgs e)
        {
            if (Controls.Count == 0)
            {
                return;
            }

            var pnlCard = Controls[0];
            pnlCard.Location = new Point((ClientSize.Width - pnlCard.Width) / 2, (ClientSize.Height - pnlCard.Height) / 2);
        }
    }
}
