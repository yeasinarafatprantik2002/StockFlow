using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using StockFlow.Data;
using StockFlow.Models;
using StockFlow.Services;

namespace StockFlow.Forms
{
    public partial class CategoryForm : Form
    {
        // Fields are now in CategoryForm.Designer.cs
        private readonly CategoryService _categoryService;
        private readonly User _currentUser;

        public CategoryForm(User currentUser)
        {
            _currentUser = currentUser;
            var context = new AppDbContext();
            _categoryService = new CategoryService(context);
            InitializeComponent();
            LoadCategories();
        }

        private void StyleButton(Button btn, string text, Color color)
        {
            btn.Text = text; btn.Size = new Size(125, 45); btn.BackColor = color; btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0; btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Cursor = Cursors.Hand; btn.Margin = new Padding(5);
        }

        private async void LoadCategories() => UpdateGrid(await _categoryService.GetAllCategoriesAsync());

        private void UpdateGrid(System.Collections.Generic.List<Category> categories)
        {
            dgvCategories.DataSource = categories.Select(c => new { c.Id, c.Name, ProductsCount = c.Products?.Count ?? 0 }).ToList();
        }

        private void BtnAdd_Click(object? s, EventArgs e) { if (new CategoryEntryForm().ShowDialog() == DialogResult.OK) LoadCategories(); }
        
        private async void BtnEdit_Click(object? s, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                int id = (int)dgvCategories.SelectedRows[0].Cells["Id"].Value;
                var cat = await _categoryService.GetCategoryByIdAsync(id);
                if (cat != null && new CategoryEntryForm(cat).ShowDialog() == DialogResult.OK) LoadCategories();
            }
        }

        private async void BtnDelete_Click(object? s, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                int id = (int)dgvCategories.SelectedRows[0].Cells["Id"].Value;
                if (MessageBox.Show("Delete this category?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes) { await _categoryService.DeleteCategoryAsync(id); LoadCategories(); }
            }
        }
    }
}
