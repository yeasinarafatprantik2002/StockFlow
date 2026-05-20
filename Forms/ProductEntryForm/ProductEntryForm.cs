using System;
using System.Drawing;
using System.Windows.Forms;
using StockFlow.Models;
using StockFlow.Utilities;
using StockFlow.Services;
using StockFlow.Data;

namespace StockFlow.Forms
{
    public partial class ProductEntryForm : Form
    {
        // Fields are now in ProductEntryForm.Designer.cs
        private readonly ProductService? _productService;
        private readonly CategoryService? _categoryService;
        private readonly SupplierService? _supplierService;
        private Product? _product;

        public ProductEntryForm(Product? product = null)
        {
            _product = product;

            InitializeComponent();

            if (!DesignModeHelper.IsActive)
            {
                var context = new AppDbContext();
                _productService = new ProductService(context);
                _categoryService = new CategoryService(context);
                _supplierService = new SupplierService(context);
                LoadData();
            }
            else
            {
                LoadDesignerPreview();
            }

            Text = _product == null ? "Add Product" : "Edit Product";
        }

        private async void LoadData()
        {
            if (_categoryService == null || _supplierService == null)
            {
                return;
            }

            cmbCategory.DataSource = await _categoryService.GetAllCategoriesAsync();
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";

            cmbSupplier.DataSource = await _supplierService.GetAllSuppliersAsync();
            cmbSupplier.DisplayMember = "Name";
            cmbSupplier.ValueMember = "Id";

            if (_product != null)
            {
                txtName.Text = _product.Name;
                numPrice.Value = _product.Price;
                numQuantity.Value = _product.Quantity;
                cmbCategory.SelectedValue = _product.CategoryId;
                cmbSupplier.SelectedValue = _product.SupplierId;
            }
        }

        private void LoadDesignerPreview()
        {
            cmbCategory.Items.Add(new { Id = 1, Name = "Accessories" });
            cmbCategory.Items.Add(new { Id = 2, Name = "Electronics" });
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";
            cmbCategory.SelectedIndex = 0;

            cmbSupplier.Items.Add(new { Id = 1, Name = "Prime Wholesale" });
            cmbSupplier.Items.Add(new { Id = 2, Name = "Metro Traders" });
            cmbSupplier.DisplayMember = "Name";
            cmbSupplier.ValueMember = "Id";
            cmbSupplier.SelectedIndex = 0;

            txtName.Text = "Wireless Mouse";
            numPrice.Value = 18;
            numQuantity.Value = 24;
        }

        private async void BtnSave_Click(object? s, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                lblMessage.Text = "Product name is required!";
                return;
            }
            if (_product == null)
            {
                _product = new Product();
            }
            _product.Name = txtName.Text;
            _product.CategoryId = (int)(cmbCategory.SelectedValue ?? 0);
            _product.SupplierId = (int)(cmbSupplier.SelectedValue ?? 0);
            _product.Price = numPrice.Value;
            _product.Quantity = (int)numQuantity.Value;

            try
            {
                if (_productService == null)
                {
                    return;
                }

                if (_product.Id == 0)
                {
                    await _productService.AddProductAsync(_product);
                }
                else
                {
                    await _productService.UpdateProductAsync(_product);
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
