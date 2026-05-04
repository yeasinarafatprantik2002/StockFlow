using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using StockFlow.Data;
using StockFlow.Models;
using StockFlow.Services;

namespace StockFlow.Forms
{
    public partial class SupplierForm : Form
    {
        // Fields are now in SupplierForm.Designer.cs
        private readonly SupplierService _supplierService;
        private readonly User _currentUser;

        public SupplierForm(User currentUser)
        {
            _currentUser = currentUser;
            var context = new AppDbContext();
            _supplierService = new SupplierService(context);
            InitializeComponent();
            LoadSuppliers();
        }

        private void StyleButton(Button btn, string text, Color color)
        {
            btn.Text = text; btn.Size = new Size(125, 45); btn.BackColor = color; btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0; btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Cursor = Cursors.Hand; btn.Margin = new Padding(5);
        }

        private async void LoadSuppliers() => UpdateGrid(await _supplierService.GetAllSuppliersAsync());

        private void UpdateGrid(System.Collections.Generic.List<Supplier> suppliers)
        {
            dgvSuppliers.DataSource = suppliers.Select(s => new { s.Id, s.Name, s.ContactInfo }).ToList();
        }

        private async void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count > 0)
            {
                int id = (int)dgvSuppliers.SelectedRows[0].Cells["Id"].Value;
                var supplier = await _supplierService.GetSupplierByIdAsync(id);
                if (supplier != null && new SupplierEntryForm(supplier).ShowDialog() == DialogResult.OK) LoadSuppliers();
            }
        }

        private async void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvSuppliers.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Delete this supplier?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int id = (int)dgvSuppliers.SelectedRows[0].Cells["Id"].Value;
                    await _supplierService.DeleteSupplierAsync(id);
                    LoadSuppliers();
                }
            }
        }
    }
}
