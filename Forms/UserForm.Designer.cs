namespace StockFlow.Forms
{
    partial class UserForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnRefresh, btnAdd, btnPromote, btnDemote, btnDelete;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblRoleWarning;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnPromote = new System.Windows.Forms.Button();
            this.btnDemote = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblRoleWarning = new System.Windows.Forms.Label();

            System.Windows.Forms.Panel pnlHeader = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Top, Height = 100, BackColor = System.Drawing.Color.White, Padding = new System.Windows.Forms.Padding(30, 20, 30, 20) };
            
            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label { Text = "STAFF MANAGEMENT", Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(44, 62, 80), Location = new System.Drawing.Point(30, 20), AutoSize = true };
            
            this.txtSearch.PlaceholderText = "Search staff by name...";
            System.Windows.Forms.Panel pnlSearch = DashboardForm.StyleTextBox(this.txtSearch);
            pnlSearch.Location = new System.Drawing.Point(30, 55);
            pnlSearch.Width = 300;
            this.txtSearch.TextChanged += async (s, e) => {
                using var context = new StockFlow.Data.AppDbContext();
                var query = txtSearch.Text.ToLower();
                var users = await Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync(
                    System.Linq.Queryable.Where(context.Users, u => u.Username.ToLower().Contains(query))
                );
                UpdateGrid(users);
            };

            if (_adminUser.Role == "SuperAdmin")
                this.lblRoleWarning.Text = "✨ Full Access (SuperAdmin)";
            else if (_adminUser.Role == "Admin")
                this.lblRoleWarning.Text = "🛡️ Admin Access";
            else
                this.lblRoleWarning.Text = "⚠️ View Only Access";

            this.lblRoleWarning.Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Italic);
            this.lblRoleWarning.ForeColor = System.Drawing.Color.DimGray;
            this.lblRoleWarning.Location = new System.Drawing.Point(335, 68);
            this.lblRoleWarning.AutoSize = true;

            System.Windows.Forms.FlowLayoutPanel pnlActions = new System.Windows.Forms.FlowLayoutPanel { Dock = System.Windows.Forms.DockStyle.Right, AutoSize = true, FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight, WrapContents = false, Padding = new System.Windows.Forms.Padding(0, 10, 0, 0) };

            StyleButton(btnAdd, "+ ADD STAFF", System.Drawing.Color.FromArgb(46, 204, 113));
            btnAdd.Click += (s, e) => { if (new UserEntryForm(_adminUser).ShowDialog() == System.Windows.Forms.DialogResult.OK) LoadUsers(); };

            StyleButton(btnPromote, "⭐ PROMOTE", System.Drawing.Color.FromArgb(155, 89, 182));
            btnPromote.Click += BtnPromote_Click;

            StyleButton(btnDemote, "🔽 DEMOTE", System.Drawing.Color.FromArgb(230, 126, 34));
            btnDemote.Click += BtnDemote_Click;
            
            StyleButton(btnDelete, "🗑 DELETE", System.Drawing.Color.FromArgb(231, 76, 60));
            btnDelete.Click += BtnDelete_Click;

            StyleButton(btnRefresh, "↻ REFRESH", System.Drawing.Color.FromArgb(52, 152, 219));
            btnRefresh.Click += (s, e) => LoadUsers();

            bool isSuper = _adminUser.Role == "SuperAdmin";
            bool isAdmin = _adminUser.Role == "Admin";

            btnAdd.Enabled = btnPromote.Enabled = isSuper || isAdmin;
            btnDemote.Enabled = btnDelete.Enabled = isSuper;

            if (!isSuper)
            {
                btnDemote.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
                btnDemote.ForeColor = System.Drawing.Color.DarkGray;
            }

            pnlActions.Controls.AddRange(new System.Windows.Forms.Control[] { btnAdd, btnPromote, btnDemote, btnDelete, btnRefresh });
            pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, pnlSearch, lblRoleWarning, pnlActions });

            DashboardForm.StyleGrid(this.dgvUsers, System.Drawing.Color.FromArgb(44, 62, 80));

            System.Windows.Forms.Panel pnlGridWrapper = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(15, 0, 15, 15) };
            pnlGridWrapper.Controls.Add(dgvUsers);

            this.Text = "Users";
            this.Controls.Add(pnlGridWrapper);
            this.Controls.Add(pnlHeader);
        }
    }
}
