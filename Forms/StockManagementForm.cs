using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using StockFlow.Data;
using StockFlow.Models;
using StockFlow.Services;

namespace StockFlow.Forms
{
    public partial class StockManagementForm : Form
    {
        // Fields are now in StockManagementForm.Designer.cs
        private readonly ProductService _productService;
        private readonly User _currentUser;

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
            cmbProducts.DataSource = await _productService.GetAllProductsAsync();
            cmbProducts.SelectedIndexChanged += (s, e) => {
                if (cmbProducts.SelectedItem is Product p) {
                    lblCurrentStock.Text = $"Current Inventory: {p.Quantity} units";
                    lblCurrentStock.ForeColor = p.Quantity < 10 ? Color.FromArgb(231, 76, 60) : Color.FromArgb(46, 204, 113);
                }
            };
        }

        private async void BtnSubmit_Click(object? sender, EventArgs e)
        {
            if (cmbProducts.SelectedItem == null || !int.TryParse(txtQuantity.Text, out int qty) || qty == 0) return;
            var product = (Product)cmbProducts.SelectedItem;
            btnSubmit.Enabled = false;
            try {
                string type = rbStockIn.Checked ? "StockIn" : "StockOut";
                if (rbStockOut.Checked) qty = -Math.Abs(qty);

                if (await _productService.AdjustStockAsync(product.Id, qty, type, _currentUser.Id))
                {
                    lblMessage.Text = "Stock adjusted successfully!";
                    lblMessage.ForeColor = Color.Green;
                    txtQuantity.Text = "0";
                    txtNote.Clear();
                }
                else { lblMessage.Text = "Insufficient stock for this operation!"; lblMessage.ForeColor = Color.Red; }
            } catch (Exception ex) { lblMessage.Text = ex.Message; }
            btnSubmit.Enabled = true;
        }
    }
}
