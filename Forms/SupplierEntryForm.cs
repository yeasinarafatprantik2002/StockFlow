using System;
using System.Drawing;
using System.Windows.Forms;
using StockFlow.Models;
using StockFlow.Services;
using StockFlow.Data;

namespace StockFlow.Forms
{
    public partial class SupplierEntryForm : Form
    {
        // Fields are now in SupplierEntryForm.Designer.cs
        private readonly SupplierService _supplierService;
        private Supplier? _supplier;

        public SupplierEntryForm(Supplier? supplier = null)
        {
            _supplier = supplier;
            var context = new AppDbContext();
            _supplierService = new SupplierService(context);
            InitializeComponent();
            if (_supplier != null) { txtName.Text = _supplier.Name; txtContactInfo.Text = _supplier.ContactInfo; }
        }

        private async void BtnSave_Click(object? s, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) return;
            if (_supplier == null) _supplier = new Supplier();
            _supplier.Name = txtName.Text;
            _supplier.ContactInfo = txtContactInfo.Text;
            try {
                if (_supplier.Id == 0) await _supplierService.AddSupplierAsync(_supplier);
                else await _supplierService.UpdateSupplierAsync(_supplier);
                this.DialogResult = DialogResult.OK;
            } catch (Exception ex) { lblMessage.Text = ex.Message; }
        }
    }
}
