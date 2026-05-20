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
    public partial class CategoryForm : Form
    {
        // Fields are now in CategoryForm.Designer.cs
        private CategoryService? _categoryService;
        private User? _currentUser;

        public CategoryForm()
        {
            InitializeComponent();
            LoadDesignerPreview();
        }

        public CategoryForm(User currentUser)
        {
            _currentUser = currentUser;
            var context = new AppDbContext();
            _categoryService = new CategoryService(context);
            InitializeComponent();
            ApplyPermissions();
            LoadCategories();
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

        private async void LoadCategories()
        {
            if (_categoryService == null)
            {
                return;
            }
            UpdateGrid(await _categoryService.GetAllCategoriesAsync());
        }

        private void UpdateGrid(System.Collections.Generic.List<Category> categories)
        {
            List<object> rows = new List<object>();
            foreach (Category category in categories)
            {
                int productsCount = 0;
                if (category.Products != null)
                {
                    productsCount = category.Products.Count;
                }

                rows.Add(new
                {
                    category.Id,
                    category.Name,
                    ProductsCount = productsCount
                });
            }

            dgvCategories.DataSource = rows;
            DesignModeHelper.ClearGridSelection(dgvCategories);
        }

        private void LoadDesignerPreview()
        {
            if (!DesignModeHelper.IsActive)
            {
                return;
            }

            dgvCategories.DataSource = new[]
            {
                new { Id = 1, Name = "Accessories", ProductsCount = 18 },
                new { Id = 2, Name = "Electronics", ProductsCount = 42 },
                new { Id = 3, Name = "Office Supplies", ProductsCount = 11 }
            };
            DesignModeHelper.ClearGridSelection(dgvCategories);
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

        private void BtnAdd_Click(object? s, EventArgs e)
        {
            if (new CategoryEntryForm().ShowDialog() == DialogResult.OK)
            {
                LoadCategories();
            }
        }

        private async void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            if (_categoryService == null)
            {
                return;
            }
            UpdateGrid(await _categoryService.SearchCategoriesAsync(txtSearch.Text));
        }

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            LoadCategories();
        }

        private async void BtnEdit_Click(object? s, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                int id = (int)dgvCategories.SelectedRows[0].Cells["Id"].Value;
                if (_categoryService == null)
                {
                    return;
                }
                var cat = await _categoryService.GetCategoryByIdAsync(id);
                if (cat != null && new CategoryEntryForm(cat).ShowDialog() == DialogResult.OK)
                {
                    LoadCategories();
                }
            }
        }

        private async void BtnDelete_Click(object? s, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                int id = (int)dgvCategories.SelectedRows[0].Cells["Id"].Value;
                if (_categoryService == null)
                {
                    return;
                }
                if (MessageBox.Show("Delete this category?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    await _categoryService.DeleteCategoryAsync(id);
                    LoadCategories();
                }
            }
        }
    }
}
