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
    public partial class NewSaleForm : Form
    {
        private List<Product> _products = new List<Product>();
        private List<SaleItem> _cart = new List<SaleItem>();
        private decimal _total = 0;

        // Fields are now in NewSaleForm.Designer.cs

        private ProductService? _productService;
        private SalesService? _salesService;
        private User? _currentUser;

        public NewSaleForm()
        {
            InitializeComponent();
        }

        public NewSaleForm(User currentUser) : this()
        {
            _currentUser = currentUser;
            var context = new AppDbContext();
            _productService = new ProductService(context);
            _salesService = new SalesService(context);

            LoadProducts();
        }

        private async void LoadProducts()
        {
            if (_productService == null)
            {
                return;
            }

            _products = await _productService.GetAllProductsAsync();
            lstProducts.DataSource = _products;
            lstProducts.DisplayMember = "Name";
        }

        private void TxtSearch_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                lstProducts.Focus();
                if (lstProducts.Items.Count > 0)
                {
                    lstProducts.SelectedIndex = 0;
                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                BtnAdd_Click(sender, e);
            }
        }

        private async void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            if (_productService == null)
            {
                return;
            }

            _products = await _productService.SearchProductsAsync(txtSearch.Text);
            lstProducts.DataSource = null;
            lstProducts.DataSource = _products;
            lstProducts.DisplayMember = "Name";
        }

        private void BtnAdd_Click(object? s, EventArgs e)
        {
            if (lstProducts.SelectedItem is Product p)
            {
                SaleItem? existing = null;
                foreach (SaleItem item in _cart)
                {
                    if (item.ProductId == p.Id)
                    {
                        existing = item;
                        break;
                    }
                }

                if (existing != null)
                {
                    existing.Quantity++;
                }
                else
                {
                    _cart.Add(new SaleItem { ProductId = p.Id, Product = p, Quantity = 1, UnitPrice = p.Price });
                }
                UpdateCart();
            }
        }

        private void UpdateCart()
        {
            dgvCart.DataSource = null;
            List<object> rows = new List<object>();
            foreach (SaleItem cartItem in _cart)
            {
                string productName = "";
                if (cartItem.Product != null)
                {
                    productName = cartItem.Product.Name;
                }

                rows.Add(new
                {
                    Item = productName,
                    cartItem.Quantity,
                    Price = cartItem.UnitPrice.ToString("C2"),
                    Subtotal = (cartItem.Quantity * cartItem.UnitPrice).ToString("C2")
                });
            }

            dgvCart.DataSource = rows;
            DesignModeHelper.ClearGridSelection(dgvCart);
            _total = 0;
            foreach (SaleItem item in _cart)
            {
                _total += item.Quantity * item.UnitPrice;
            }
            lblTotal.Text = $"TOTAL: {_total:C2}";
        }

        private async void BtnCheckout_Click(object? s, EventArgs e)
        {
            if (_salesService == null || _currentUser == null)
            {
                return;
            }

            if (_cart.Count == 0)
            {
                return;
            }
            btnCheckout.Enabled = false;
            if (await _salesService.CreateSaleAsync(_currentUser.Id, _cart))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblMessage.Text = "Checkout failed. Check stock levels.";
                lblMessage.ForeColor = Color.Red;
                btnCheckout.Enabled = true;
            }
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
