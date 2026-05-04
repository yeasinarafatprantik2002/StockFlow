using System;
using System.Drawing;
using System.Windows.Forms;
using StockFlow.Models;
using StockFlow.Services;
using StockFlow.Data;

namespace StockFlow.Forms
{
    public partial class CategoryEntryForm : Form
    {
        // Fields are now in CategoryEntryForm.Designer.cs
        private readonly CategoryService _categoryService;
        private Category? _category;

        public CategoryEntryForm(Category? category = null)
        {
            _category = category;
            var context = new AppDbContext();
            _categoryService = new CategoryService(context);
            InitializeComponent();
            if (_category != null) txtName.Text = _category.Name;
        }

        private async void BtnSave_Click(object? s, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) return;
            if (_category == null) _category = new Category();
            _category.Name = txtName.Text;
            try {
                if (_category.Id == 0) await _categoryService.AddCategoryAsync(_category);
                else await _categoryService.UpdateCategoryAsync(_category);
                this.DialogResult = DialogResult.OK;
            } catch (Exception ex) { lblMessage.Text = ex.Message; }
        }
    }
}
