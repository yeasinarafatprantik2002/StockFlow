using System;
using System.Drawing;
using System.Windows.Forms;
using StockFlow.Models;
using StockFlow.Data;
using StockFlow.Services;
using StockFlow.Repositories;

namespace StockFlow.Forms
{
    public partial class UserEntryForm : Form
    {
        // Fields are now in UserEntryForm.Designer.cs
        private readonly AuthService? _authService;
        private readonly User? _currentUser;

        public UserEntryForm()
        {
            InitializeComponent();
            SetupRoleSelection();
        }

        public UserEntryForm(User currentUser)
        {
            _currentUser = currentUser;
            var context = new AppDbContext();
            var repo = new Repository<User>(context);
            _authService = new AuthService(repo);
            InitializeComponent();
            SetupRoleSelection();
        }

        private void SetupRoleSelection()
        {
            cmbRole.Items.Clear();

            if (_currentUser != null && _currentUser.Role == "Admin")
            {
                cmbRole.Items.Add("PartTimeStaff");
                cmbRole.SelectedIndex = 0;
                cmbRole.Enabled = false;
            }
            else
            {
                cmbRole.Items.AddRange(new string[] { "PartTimeStaff", "PermanentStaff", "Admin", "SuperAdmin" });
                cmbRole.SelectedIndex = 0;
            }
        }



        private async void BtnSave_Click(object? s, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblMessage.Text = "Username and password are required!";
                return;
            }

            try
            {
                if (_authService == null)
                {
                    return;
                }

                if (await _authService.RegisterAsync(txtUsername.Text, txtPassword.Text, cmbRole.SelectedItem?.ToString() ?? "PartTimeStaff"))
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    lblMessage.Text = "This username already exists!";
                }
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
