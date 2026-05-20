using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using StockFlow.Data;
using StockFlow.Models;
using StockFlow.Utilities;
using StockFlow.Services;

namespace StockFlow.Forms
{
    public partial class UserForm : Form
    {
        // Fields are now in UserForm.Designer.cs
        private readonly User? _adminUser;

        public UserForm()
        {
            InitializeComponent();
            ApplyPermissions();
            LoadDesignerPreview();
        }

        public UserForm(User adminUser)
        {
            _adminUser = adminUser;
            InitializeComponent();
            ApplyPermissions();
            LoadUsers();
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

        private async void LoadUsers()
        {
            if (_adminUser == null)
            {
                return;
            }

            using (AppDbContext context = new AppDbContext())
            {
                UpdateGrid(await context.Users.ToListAsync());
            }
        }

        private void UpdateGrid(System.Collections.Generic.List<User> users)
        {
            List<object> rows = new List<object>();
            foreach (User user in users)
            {
                string displayRole = user.Role;
                if (user.Role == "Staff")
                {
                    displayRole = "PartTimeStaff";
                }

                rows.Add(new
                {
                    user.Id,
                    user.Username,
                    DisplayRole = displayRole,
                    ActualRole = user.Role,
                    JoinedDate = user.CreatedAt.ToLocalTime().ToString("yyyy-MM-dd")
                });
            }

            dgvUsers.DataSource = rows;

            if (dgvUsers.Columns.Contains("ActualRole"))
            {
                dgvUsers.Columns["ActualRole"].Visible = false;
            }
            DesignModeHelper.ClearGridSelection(dgvUsers);
        }

        private void LoadDesignerPreview()
        {
            if (!DesignModeHelper.IsActive)
            {
                return;
            }

            dgvUsers.DataSource = new[]
            {
                new { Id = 1, Username = "superadmin", DisplayRole = "SuperAdmin", ActualRole = "SuperAdmin", JoinedDate = "2026-05-01" },
                new { Id = 2, Username = "manager", DisplayRole = "Admin", ActualRole = "Admin", JoinedDate = "2026-05-05" },
                new { Id = 3, Username = "staff01", DisplayRole = "PermanentStaff", ActualRole = "PermanentStaff", JoinedDate = "2026-05-10" }
            };

            if (dgvUsers.Columns.Contains("ActualRole"))
            {
                dgvUsers.Columns["ActualRole"].Visible = false;
            }
            DesignModeHelper.ClearGridSelection(dgvUsers);
        }

        private void ApplyPermissions()
        {
            bool isSuper = false;
            bool isAdmin = false;

            if (_adminUser != null && _adminUser.Role == "SuperAdmin")
            {
                isSuper = true;
            }

            if (_adminUser != null && _adminUser.Role == "Admin")
            {
                isAdmin = true;
            }

            if (isSuper)
            {
                lblRoleWarning.Text = "Full Access (SuperAdmin)";
            }
            else if (isAdmin)
            {
                lblRoleWarning.Text = "Admin Access";
            }
            else
            {
                lblRoleWarning.Text = "View Only Access";
            }

            btnAdd.Enabled = btnPromote.Enabled = isSuper || isAdmin;
            btnDemote.Enabled = btnDelete.Enabled = isSuper;

            if (!isSuper)
            {
                btnDemote.BackColor = Color.FromArgb(224, 224, 224);
                btnDemote.ForeColor = Color.DarkGray;
            }
        }

        private async void BtnPromote_Click(object? s, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                int id = (int)dgvUsers.SelectedRows[0].Cells["Id"].Value;
                string currentRole = dgvUsers.SelectedRows[0].Cells["ActualRole"].Value.ToString() ?? "Staff";
                if (_adminUser == null)
                {
                    return;
                }

                if (id == _adminUser.Id)
                {
                    MessageBox.Show("You cannot change your own role!");
                    return;
                }

                if (_adminUser.Role == "Admin")
                {
                    if (currentRole != "Staff" && currentRole != "PartTimeStaff" && currentRole != "PermanentStaff")
                    {
                        MessageBox.Show("Admins can only promote Part-Time or Permanent Staff.", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                using (AppDbContext context = new AppDbContext())
                {
                    var user = await context.Users.FindAsync(id);
                    if (user != null)
                    {
                        if (user.Role == "Staff")
                        {
                            user.Role = "PermanentStaff";
                        }
                        else if (user.Role == "PartTimeStaff")
                        {
                            user.Role = "PermanentStaff";
                        }
                        else if (user.Role == "PermanentStaff")
                        {
                            user.Role = "Admin";
                        }
                        else if (user.Role == "Admin")
                        {
                            user.Role = "SuperAdmin";
                        }

                        await context.SaveChangesAsync();
                        LoadUsers();
                        MessageBox.Show($"{user.Username} promoted to {user.Role}!", "Success");
                    }
                }
            }
        }

        private async void BtnDemote_Click(object? s, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                int id = (int)dgvUsers.SelectedRows[0].Cells["Id"].Value;
                if (_adminUser == null)
                {
                    return;
                }

                if (id == _adminUser.Id)
                {
                    MessageBox.Show("You cannot change your own role!");
                    return;
                }

                using (AppDbContext context = new AppDbContext())
                {
                    var user = await context.Users.FindAsync(id);
                    if (user != null)
                    {
                        if (user.Role == "SuperAdmin")
                        {
                            user.Role = "Admin";
                        }
                        else if (user.Role == "Admin")
                        {
                            user.Role = "PermanentStaff";
                        }
                        else if (user.Role == "PermanentStaff")
                        {
                            user.Role = "PartTimeStaff";
                        }
                        else if (user.Role == "Staff")
                        {
                            user.Role = "PartTimeStaff";
                        }

                        await context.SaveChangesAsync();
                        LoadUsers();
                        MessageBox.Show($"{user.Username} demoted to {user.Role}!", "Success");
                    }
                }
            }
        }

        private async void BtnDelete_Click(object? s, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                int id = (int)dgvUsers.SelectedRows[0].Cells["Id"].Value;
                if (_adminUser == null)
                {
                    return;
                }

                if (id == _adminUser.Id)
                {
                    MessageBox.Show("You cannot delete yourself!");
                    return;
                }
                if (MessageBox.Show("Delete this user?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (AppDbContext context = new AppDbContext())
                    {
                        var user = await context.Users.FindAsync(id);
                        if (user != null)
                        {
                            context.Users.Remove(user);
                            await context.SaveChangesAsync();
                            LoadUsers();
                        }
                    }
                }
            }
        }

        private async void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            if (_adminUser == null)
            {
                return;
            }

            using (AppDbContext context = new AppDbContext())
            {
                string query = txtSearch.Text.ToLower();
                List<User> users = await context.Users.ToListAsync();
                List<User> result = new List<User>();
                foreach (User user in users)
                {
                    if (user.Username.ToLower().Contains(query))
                    {
                        result.Add(user);
                    }
                }
                UpdateGrid(result);
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (_adminUser != null && new UserEntryForm(_adminUser).ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void BtnRefresh_Click(object? sender, EventArgs e)
        {
            LoadUsers();
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
