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
    public partial class SupplierForm : Form
    {
        // Fields are now in SupplierForm.Designer.cs
        private readonly SupplierService? _supplierService;
        private readonly User? _currentUser;

        public SupplierForm()
        {
            InitializeComponent();
            LoadDesignerPreview();
        }

        public SupplierForm(User currentUser)
        {
            _currentUser = currentUser;
            var context = new AppDbContext();
            _supplierService = new SupplierService(context);
            InitializeComponent();
            ApplyPermissions();
            LoadSuppliers();
        }

        private void StyleButton(Button btn, string text, Color color)
        {
            btn.Text = text;
            btn.Size = new Size(125, 45);
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Margin = new Padding(5);
        }

        private async void LoadSuppliers()
        {
            if (_supplierService == null)
            {
                return;
            }
            UpdateGrid(await _supplierService.GetAllSuppliersAsync());
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

        private void UpdateGrid(System.Collections.Generic.List<Supplier> suppliers)
        {
            List<object> rows = new List<object>();
            foreach (Supplier supplier in suppliers)
            {
                rows.Add(new
                {
                    supplier.Id,
                    supplier.Name,
                    supplier.ContactInfo
                });
            }

            dgvSuppliers.DataSource = rows;
            DesignModeHelper.ClearGridSelection(dgvSuppliers);
        }

        private void LoadDesignerPreview()
        {
            if (!DesignModeHelper.IsActive)
            {
                return;
            }

            dgvSuppliers.DataSource = new[]
            {
                new { Id = 1, Name = "Prime Wholesale", ContactInfo = "prime@example.com" },
                new { Id = 2, Name = "Metro Traders", ContactInfo = "+880 1711-000000" },
                new { Id = 3, Name = "North Supply Co.", ContactInfo = "north@example.com" }
            };
            DesignModeHelper.ClearGridSelection(dgvSuppliers);
        }

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            LoadSuppliers();
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (new SupplierEntryForm().ShowDialog() == DialogResult.OK)
            {
                LoadSuppliers();
            }
        }

        private async void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count > 0)
            {
                int id = (int)dgvSuppliers.SelectedRows[0].Cells["Id"].Value;
                if (_supplierService == null)
                {
                    return;
                }
                var supplier = await _supplierService.GetSupplierByIdAsync(id);
                if (supplier != null && new SupplierEntryForm(supplier).ShowDialog() == DialogResult.OK)
                {
                    LoadSuppliers();
                }
            }
        }

        private async void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Delete this supplier?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int id = (int)dgvSuppliers.SelectedRows[0].Cells["Id"].Value;
                    if (_supplierService == null)
                    {
                        return;
                    }
                    await _supplierService.DeleteSupplierAsync(id);
                    LoadSuppliers();
                }
            }
        }

        private async void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            if (_supplierService == null)
            {
                return;
            }
            UpdateGrid(await _supplierService.SearchSuppliersAsync(txtSearch.Text));
        }
    }
}
