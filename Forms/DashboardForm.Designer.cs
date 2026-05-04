namespace StockFlow.Forms
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem productsMenu, categoriesMenu, suppliersMenu, salesMenu, stockMenu, reportsMenu, logoutMenu;
        private System.Windows.Forms.Label lblWelcome, lblSubtitle;
        private System.Windows.Forms.Panel pnlHeader, pnlViewPort, pnlDashboardHome;
        private System.Windows.Forms.FlowLayoutPanel pnlStats;
        private System.Windows.Forms.DataGridView dgvLowStock;
        private System.Windows.Forms.Button btnBack;

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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.productsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.suppliersMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.salesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.stockMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlViewPort = new System.Windows.Forms.Panel();
            this.pnlDashboardHome = new System.Windows.Forms.Panel();
            this.pnlStats = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvLowStock = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();

            // --- Menu Strip Styling ---
            this.menuStrip.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.menuStrip.ForeColor = System.Drawing.Color.White;
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            this.menuStrip.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.menuStrip.Renderer = new DashboardMenuRenderer();

            // Menu Items
            AddMenuItem(productsMenu, "  📦 Products  ", (s, e) => OpenChildForm(new ProductForm(_currentUser)));
            AddMenuItem(categoriesMenu, "  📂 Categories  ", (s, e) => OpenChildForm(new CategoryForm(_currentUser)));
            
            bool isManagement = _currentUser.Role == "SuperAdmin" || _currentUser.Role == "Admin";
            if (isManagement) AddMenuItem(suppliersMenu, "  🚚 Suppliers  ", (s, e) => OpenChildForm(new SupplierForm(_currentUser)));

            if (_currentUser.Role != "PartTimeStaff") AddMenuItem(salesMenu, "  💰 Sales  ", (s, e) => OpenChildForm(new SalesForm(_currentUser)));

            this.stockMenu.Text = "  📦 Inventory  ";
            this.stockMenu.ForeColor = System.Drawing.Color.White;
            if (this.stockMenu.DropDown is System.Windows.Forms.ToolStripDropDownMenu menu) {
                menu.ShowImageMargin = false;
                menu.ShowCheckMargin = false;
            }
            var stockInItem = new System.Windows.Forms.ToolStripMenuItem("Stock Adjustment") { Visible = isManagement };
            stockInItem.Click += (s, e) => OpenChildForm(new StockManagementForm(_currentUser));
            var ledgerItem = new System.Windows.Forms.ToolStripMenuItem("Movement History");
            ledgerItem.Click += (s, e) => OpenChildForm(new StockLedgerForm());
            this.stockMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { stockInItem, ledgerItem });
            this.menuStrip.Items.Add(stockMenu);

            if (isManagement) AddMenuItem(reportsMenu, "  📊 Reports  ", (s, e) => OpenChildForm(new ReportsForm(_currentUser)));
            if (isManagement) AddMenuItem(new System.Windows.Forms.ToolStripMenuItem(), "  👥 Users  ", (s, e) => OpenChildForm(new UserForm(_currentUser)));

            this.logoutMenu.Text = "  🔒 Logout  ";
            this.logoutMenu.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.logoutMenu.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.logoutMenu.Click += (s, e) => { this.DialogResult = System.Windows.Forms.DialogResult.OK; this.Close(); };
            this.menuStrip.Items.Add(logoutMenu);

            System.Drawing.Color themeColor = _currentUser.Role switch { "SuperAdmin" => System.Drawing.Color.FromArgb(44, 62, 80), "Admin" => System.Drawing.Color.FromArgb(22, 160, 133), _ => System.Drawing.Color.FromArgb(52, 152, 219) };

            // --- Header ---
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Height = 140;
            this.pnlHeader.BackColor = themeColor;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(40, 20, 40, 20);

            this.btnBack.Text = "← BACK";
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(50, 0, 0, 0);
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.Location = new System.Drawing.Point(40, 25);
            this.btnBack.Size = new System.Drawing.Size(100, 35);
            this.btnBack.Visible = false;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Click += (s, e) => CloseChildForm();

            this.lblWelcome.Text = $"Welcome, {_currentUser.Username}!";
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 28, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(35, 45);
            this.lblWelcome.AutoSize = true;

            string displayRole = _currentUser.Role switch { "PartTimeStaff" => "Part-Time Staff", "PermanentStaff" => "Permanent Staff", _ => _currentUser.Role };
            this.lblSubtitle.Text = $"{displayRole} Portal  •  {System.DateTime.Now:dddd, MMM dd, yyyy}";
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 12);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(200, 255, 255, 255);
            this.lblSubtitle.Location = new System.Drawing.Point(40, 95);
            this.lblSubtitle.AutoSize = true;

            this.pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[] { btnBack, lblWelcome, lblSubtitle });

            // --- ViewPort & Dashboard Home ---
            this.pnlViewPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViewPort.BackColor = System.Drawing.Color.FromArgb(240, 243, 244);
            
            this.pnlDashboardHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDashboardHome.Padding = new System.Windows.Forms.Padding(40, 30, 40, 40);
            
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Height = 180;
            this.pnlStats.AutoScroll = true;

            System.Windows.Forms.Label lblLowStock = new System.Windows.Forms.Label { Text = "🚨 CRITICAL STOCK ALERTS", Font = new System.Drawing.Font("Segoe UI", 13, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(231, 76, 60), Dock = System.Windows.Forms.DockStyle.Top, Height = 50, TextAlign = System.Drawing.ContentAlignment.BottomLeft };
            
            StyleGrid(this.dgvLowStock, System.Drawing.Color.FromArgb(231, 76, 60));
            this.dgvLowStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLowStock.CellFormatting += DgvLowStock_CellFormatting;

            System.Windows.Forms.Panel pnlGridContainer = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(0, 15, 0, 0) };
            pnlGridContainer.Controls.Add(dgvLowStock);
            pnlGridContainer.Controls.Add(lblLowStock);

            this.pnlDashboardHome.Controls.Add(pnlGridContainer);
            this.pnlDashboardHome.Controls.Add(pnlStats);
            this.pnlViewPort.Controls.Add(pnlDashboardHome);

            this.Text = "StockFlow Enterprise";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MainMenuStrip = this.menuStrip;
            this.Controls.Add(this.pnlViewPort);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.menuStrip);
        }
    }
}
