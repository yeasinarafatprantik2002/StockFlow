using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using StockFlow.Data;
using StockFlow.Models;
using StockFlow.Services;

namespace StockFlow.Forms
{
    public partial class UserForm : Form
    {
        // Fields are now in UserForm.Designer.cs
        private readonly User _adminUser;

        public UserForm(User adminUser)
        {
            _adminUser = adminUser;
            InitializeComponent();
            LoadUsers();
        }

        private void StyleButton(Button btn, string text, Color color)
        {
            btn.Text = text; btn.Size = new Size(125, 45); btn.BackColor = color; btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0; btn.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btn.Cursor = Cursors.Hand; btn.Margin = new Padding(5);
        }

        private async void LoadUsers()
        {
            using var context = new AppDbContext();
            UpdateGrid(await context.Users.ToListAsync());
        }

        private void UpdateGrid(System.Collections.Generic.List<User> users)
        {
            dgvUsers.DataSource = users.Select(u => new { 
                u.Id, 
                u.Username, 
                DisplayRole = u.Role == "Staff" ? "PartTimeStaff" : u.Role,
                ActualRole = u.Role,
                JoinedDate = u.CreatedAt.ToLocalTime().ToString("yyyy-MM-dd") 
            }).ToList();
            
            if (dgvUsers.Columns.Contains("ActualRole")) dgvUsers.Columns["ActualRole"].Visible = false;
        }

        private async void BtnPromote_Click(object? s, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                int id = (int)dgvUsers.SelectedRows[0].Cells["Id"].Value;
                string currentRole = dgvUsers.SelectedRows[0].Cells["ActualRole"].Value.ToString() ?? "Staff";
                if (id == _adminUser.Id) { MessageBox.Show("You cannot change your own role!"); return; }

                if (_adminUser.Role == "Admin")
                {
                    if (currentRole != "Staff" && currentRole != "PartTimeStaff" && currentRole != "PermanentStaff")
                    {
                        MessageBox.Show("Admins can only promote Part-Time or Permanent Staff.", "Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                using var context = new AppDbContext();
                var user = await context.Users.FindAsync(id);
                if (user != null)
                {
                    user.Role = user.Role switch {
                        "Staff" => "PermanentStaff",
                        "PartTimeStaff" => "PermanentStaff",
                        "PermanentStaff" => "Admin",
                        "Admin" => "SuperAdmin",
                        _ => user.Role
                    };
                    await context.SaveChangesAsync();
                    LoadUsers();
                    MessageBox.Show($"{user.Username} promoted to {user.Role}!", "Success");
                }
            }
        }

        private async void BtnDemote_Click(object? s, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                int id = (int)dgvUsers.SelectedRows[0].Cells["Id"].Value;
                if (id == _adminUser.Id) { MessageBox.Show("You cannot change your own role!"); return; }
                
                using var context = new AppDbContext();
                var user = await context.Users.FindAsync(id);
                if (user != null)
                {
                    user.Role = user.Role switch {
                        "SuperAdmin" => "Admin",
                        "Admin" => "PermanentStaff",
                        "PermanentStaff" => "PartTimeStaff",
                        "Staff" => "PartTimeStaff",
                        _ => user.Role
                    };
                    await context.SaveChangesAsync();
                    LoadUsers();
                    MessageBox.Show($"{user.Username} demoted to {user.Role}!", "Success");
                }
            }
        }

        private async void BtnDelete_Click(object? s, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                int id = (int)dgvUsers.SelectedRows[0].Cells["Id"].Value;
                if (id == _adminUser.Id) { MessageBox.Show("You cannot delete yourself!"); return; }
                if (MessageBox.Show("Delete this user?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using var context = new AppDbContext();
                    var user = await context.Users.FindAsync(id);
                    if (user != null) { context.Users.Remove(user); await context.SaveChangesAsync(); LoadUsers(); }
                }
            }
        }
    }
}
