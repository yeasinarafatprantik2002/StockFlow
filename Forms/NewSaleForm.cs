using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using StockFlow.Data;
using StockFlow.Models;
using StockFlow.Services;

namespace StockFlow.Forms
{
    public partial class NewSaleForm : Form
    {
        private List<Product> _products = new();
        private List<SaleItem> _cart = new();
        private decimal _total = 0;

        // Fields are now in NewSaleForm.Designer.cs

        private readonly ProductService _productService;
        private readonly SalesService _salesService;
        private readonly User _currentUser;

        public NewSaleForm(User currentUser)
        {
            _currentUser = currentUser;
            var context = new AppDbContext();
            _productService = new ProductService(context);
            _salesService = new SalesService(context);

            InitializeComponent();
            LoadProducts();
        }

        private async void LoadProducts()
        {
            _products = await _productService.GetAllProductsAsync();
            lstProducts.DataSource = _products;
            lstProducts.DisplayMember = "Name";
        }

        private void TxtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down) { e.Handled = true; lstProducts.Focus(); if (lstProducts.Items.Count > 0) lstProducts.SelectedIndex = 0; }
            if (e.KeyCode == Keys.Enter) { e.Handled = true; BtnAdd_Click(sender, e); }
        }

        private void BtnAdd_Click(object? s, EventArgs e)
        {
            if (lstProducts.SelectedItem is Product p)
            {
                var existing = _cart.FirstOrDefault(i => i.ProductId == p.Id);
                if (existing != null) existing.Quantity++;
                else _cart.Add(new SaleItem { ProductId = p.Id, Product = p, Quantity = 1, UnitPrice = p.Price });
                UpdateCart();
            }
        }

        private void UpdateCart()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart.Select(i => new { Item = i.Product?.Name, i.Quantity, Price = i.UnitPrice.ToString("C2"), Subtotal = (i.Quantity * i.UnitPrice).ToString("C2") }).ToList();
            _total = _cart.Sum(i => i.Quantity * i.UnitPrice);
            lblTotal.Text = $"TOTAL: {_total:C2}";
        }

        private async void BtnCheckout_Click(object? s, EventArgs e)
        {
            if (!_cart.Any()) return;
            btnCheckout.Enabled = false;
            if (await _salesService.CreateSaleAsync(_currentUser.Id, _cart)) { this.DialogResult = DialogResult.OK; this.Close(); }
            else { lblMessage.Text = "Checkout failed. Check stock levels."; lblMessage.ForeColor = Color.Red; btnCheckout.Enabled = true; }
        }
    }
}
