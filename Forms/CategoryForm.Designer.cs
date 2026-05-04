namespace StockFlow.Forms
{
    partial class CategoryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Button btnRefresh, btnAdd, btnEdit, btnDelete;
        private System.Windows.Forms.TextBox txtSearch;

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
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();

            System.Windows.Forms.Panel pnlHeader = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Top, Height = 100, BackColor = System.Drawing.Color.White, Padding = new System.Windows.Forms.Padding(30, 20, 30, 20) };
            System.Windows.Forms.Label lblSearchIcon = new System.Windows.Forms.Label { Text = "🔍", Font = new System.Drawing.Font("Segoe UI", 12), Location = new System.Drawing.Point(35, 42), AutoSize = true };
            this.txtSearch.PlaceholderText = "Search categories...";
            System.Windows.Forms.Panel pnlSearch = DashboardForm.StyleTextBox(this.txtSearch);
            pnlSearch.Location = new System.Drawing.Point(80, 35);
            pnlSearch.Width = 350;
            this.txtSearch.TextChanged += async (s, e) => UpdateGrid(await _categoryService.SearchCategoriesAsync(txtSearch.Text));

            System.Windows.Forms.FlowLayoutPanel pnlActions = new System.Windows.Forms.FlowLayoutPanel { Dock = System.Windows.Forms.DockStyle.Right, AutoSize = true, Padding = new System.Windows.Forms.Padding(0, 10, 0, 0) };
            StyleButton(btnRefresh, "↻ REFRESH", System.Drawing.Color.FromArgb(52, 152, 219));
            btnRefresh.Click += (s, e) => LoadCategories();

            if (_currentUser.Role == "SuperAdmin" || _currentUser.Role == "Admin")
            {
                StyleButton(btnAdd, "+ ADD NEW", System.Drawing.Color.FromArgb(46, 204, 113));
                btnAdd.Click += BtnAdd_Click;
                StyleButton(btnEdit, "✎ EDIT", System.Drawing.Color.FromArgb(241, 196, 15));
                btnEdit.Click += BtnEdit_Click;
                StyleButton(btnDelete, "🗑 DELETE", System.Drawing.Color.FromArgb(231, 76, 60));
                btnDelete.Click += BtnDelete_Click;
                pnlActions.Controls.AddRange(new System.Windows.Forms.Control[] { btnAdd, btnEdit, btnDelete });
            }
            pnlActions.Controls.Add(btnRefresh);
            pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[] { lblSearchIcon, pnlSearch, pnlActions });

            DashboardForm.StyleGrid(this.dgvCategories, System.Drawing.Color.FromArgb(44, 62, 80));

            System.Windows.Forms.Panel pnlGridWrapper = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(15, 0, 15, 15) };
            pnlGridWrapper.Controls.Add(dgvCategories);

            this.Text = "Categories";
            this.Controls.Add(pnlGridWrapper);
            this.Controls.Add(pnlHeader);
        }
    }
}
