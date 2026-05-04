using System;
using System.Drawing;
using System.Windows.Forms;
using StockFlow.Data;
using StockFlow.Repositories;
using StockFlow.Services;
using StockFlow.Models;

namespace StockFlow.Forms
{
    public partial class LoginForm : Form
    {
        // Fields are now in LoginForm.Designer.cs

        private readonly AuthService _authService;

        public LoginForm()
        {
            InitializeComponent();
            
            var context = new AppDbContext();
            var userRepository = new Repository<User>(context);
            _authService = new AuthService(userRepository);
        }

        private async void BtnLogin_Click(object? sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            lblMessage.Text = "Authenticating...";
            lblMessage.ForeColor = Color.Gray;

            var user = await _authService.LoginAsync(txtUsername.Text, txtPassword.Text);
            
            if (user != null)
            {
                var dashboard = new DashboardForm(user);
                this.Hide();
                if (dashboard.ShowDialog() == DialogResult.OK)
                {
                    this.txtUsername.Clear();
                    this.txtPassword.Clear();
                    this.lblMessage.Text = "Session ended.";
                    this.lblMessage.ForeColor = Color.FromArgb(46, 204, 113);
                    this.btnLogin.Enabled = true;
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                lblMessage.Text = "Invalid credentials. Try again.";
                lblMessage.ForeColor = Color.FromArgb(231, 76, 60);
                btnLogin.Enabled = true;
            }
        }
    }
}
