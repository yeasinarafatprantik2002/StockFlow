namespace StockFlow.Forms
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem productsMenu;
        private System.Windows.Forms.ToolStripMenuItem categoriesMenu;
        private System.Windows.Forms.ToolStripMenuItem suppliersMenu;
        private System.Windows.Forms.ToolStripMenuItem salesMenu;
        private System.Windows.Forms.ToolStripMenuItem stockMenu;
        private System.Windows.Forms.ToolStripMenuItem reportsMenu;
        private System.Windows.Forms.ToolStripMenuItem logoutMenu;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlViewPort;
        private System.Windows.Forms.Panel pnlDashboardHome;
        private System.Windows.Forms.FlowLayoutPanel pnlStats;
        private System.Windows.Forms.DataGridView dgvLowStock;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Panel pnlGridContainer;
        private System.Windows.Forms.Label lblLowStock;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            menuStrip = new MenuStrip();
            productsMenu = new ToolStripMenuItem();
            categoriesMenu = new ToolStripMenuItem();
            suppliersMenu = new ToolStripMenuItem();
            salesMenu = new ToolStripMenuItem();
            stockMenu = new ToolStripMenuItem();
            reportsMenu = new ToolStripMenuItem();
            logoutMenu = new ToolStripMenuItem();
            lblWelcome = new Label();
            lblSubtitle = new Label();
            pnlHeader = new Panel();
            btnBack = new Button();
            pnlViewPort = new Panel();
            pnlDashboardHome = new Panel();
            pnlGridContainer = new Panel();
            dgvLowStock = new DataGridView();
            lblLowStock = new Label();
            pnlStats = new FlowLayoutPanel();
            pnlHeader.SuspendLayout();
            pnlViewPort.SuspendLayout();
            pnlDashboardHome.SuspendLayout();
            pnlGridContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLowStock).BeginInit();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.AutoSize = false;
            menuStrip.BackColor = Color.FromArgb(44, 62, 80);
            menuStrip.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            menuStrip.ForeColor = Color.White;
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(22, 8, 22, 8);
            menuStrip.Size = new Size(1280, 52);
            menuStrip.TabIndex = 2;
            // 
            // productsMenu
            // 
            productsMenu.Name = "productsMenu";
            productsMenu.Size = new Size(32, 19);
            // 
            // categoriesMenu
            // 
            categoriesMenu.Name = "categoriesMenu";
            categoriesMenu.Size = new Size(32, 19);
            // 
            // suppliersMenu
            // 
            suppliersMenu.Name = "suppliersMenu";
            suppliersMenu.Size = new Size(32, 19);
            // 
            // salesMenu
            // 
            salesMenu.Name = "salesMenu";
            salesMenu.Size = new Size(32, 19);
            // 
            // stockMenu
            // 
            stockMenu.Name = "stockMenu";
            stockMenu.Size = new Size(32, 19);
            // 
            // reportsMenu
            // 
            reportsMenu.Name = "reportsMenu";
            reportsMenu.Size = new Size(32, 19);
            // 
            // logoutMenu
            // 
            logoutMenu.Name = "logoutMenu";
            logoutMenu.Size = new Size(32, 19);
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblWelcome.ForeColor = Color.White;
            lblWelcome.Location = new Point(35, 45);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(288, 51);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome, User";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 12F);
            lblSubtitle.ForeColor = Color.FromArgb(200, 255, 255, 255);
            lblSubtitle.Location = new Point(40, 95);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(86, 21);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "User Portal";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(52, 152, 219);
            pnlHeader.Controls.Add(btnBack);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 24);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(40, 20, 40, 20);
            pnlHeader.Size = new Size(1280, 140);
            pnlHeader.TabIndex = 1;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(80, 0, 0, 0);
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(40, 25);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 35);
            btnBack.TabIndex = 0;
            btnBack.Text = "← BACK";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Visible = false;
            btnBack.Click += BtnBack_Click;
            // 
            // pnlViewPort
            // 
            pnlViewPort.BackColor = Color.FromArgb(240, 243, 244);
            pnlViewPort.Controls.Add(pnlDashboardHome);
            pnlViewPort.Dock = DockStyle.Fill;
            pnlViewPort.Location = new Point(0, 164);
            pnlViewPort.Name = "pnlViewPort";
            pnlViewPort.Size = new Size(1280, 556);
            pnlViewPort.TabIndex = 0;
            // 
            // pnlDashboardHome
            // 
            pnlDashboardHome.Controls.Add(pnlGridContainer);
            pnlDashboardHome.Controls.Add(pnlStats);
            pnlDashboardHome.Dock = DockStyle.Fill;
            pnlDashboardHome.Location = new Point(0, 0);
            pnlDashboardHome.Name = "pnlDashboardHome";
            pnlDashboardHome.Padding = new Padding(40, 30, 40, 40);
            pnlDashboardHome.Size = new Size(1280, 556);
            pnlDashboardHome.TabIndex = 0;
            // 
            // pnlGridContainer
            // 
            pnlGridContainer.Controls.Add(dgvLowStock);
            pnlGridContainer.Controls.Add(lblLowStock);
            pnlGridContainer.Dock = DockStyle.Fill;
            pnlGridContainer.Location = new Point(40, 210);
            pnlGridContainer.Name = "pnlGridContainer";
            pnlGridContainer.Padding = new Padding(0, 15, 0, 0);
            pnlGridContainer.Size = new Size(1200, 306);
            pnlGridContainer.TabIndex = 0;
            // 
            // dgvLowStock
            // 
            dgvLowStock.AllowUserToAddRows = false;
            dgvLowStock.AllowUserToResizeRows = false;
            dgvLowStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLowStock.BackgroundColor = Color.White;
            dgvLowStock.BorderStyle = BorderStyle.None;
            dgvLowStock.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLowStock.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(231, 76, 60);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(231, 76, 60);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvLowStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvLowStock.ColumnHeadersHeight = 55;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(44, 62, 80);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(235, 245, 251);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvLowStock.DefaultCellStyle = dataGridViewCellStyle2;
            dgvLowStock.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            dgvLowStock.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 245, 251);
            dgvLowStock.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(41, 128, 185);
            dgvLowStock.Dock = DockStyle.Fill;
            dgvLowStock.EnableHeadersVisualStyles = false;
            dgvLowStock.GridColor = Color.FromArgb(235, 235, 235);
            dgvLowStock.Location = new Point(0, 65);
            dgvLowStock.Name = "dgvLowStock";
            dgvLowStock.ReadOnly = true;
            dgvLowStock.RowHeadersVisible = false;
            dgvLowStock.RowTemplate.Height = 50;
            dgvLowStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLowStock.Size = new Size(1200, 241);
            dgvLowStock.TabIndex = 0;
            dgvLowStock.CellFormatting += DgvLowStock_CellFormatting;
            // 
            // lblLowStock
            // 
            lblLowStock.Dock = DockStyle.Top;
            lblLowStock.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblLowStock.ForeColor = Color.FromArgb(231, 76, 60);
            lblLowStock.Location = new Point(0, 15);
            lblLowStock.Name = "lblLowStock";
            lblLowStock.Size = new Size(1200, 50);
            lblLowStock.TabIndex = 1;
            lblLowStock.Text = "CRITICAL STOCK ALERTS";
            lblLowStock.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlStats
            // 
            pnlStats.AutoScroll = true;
            pnlStats.Dock = DockStyle.Top;
            pnlStats.Location = new Point(40, 30);
            pnlStats.Name = "pnlStats";
            pnlStats.Size = new Size(1200, 180);
            pnlStats.TabIndex = 1;
            pnlStats.Paint += pnlStats_Paint;
            // 
            // DashboardForm
            // 
            ClientSize = new Size(1280, 720);
            Controls.Add(pnlViewPort);
            Controls.Add(pnlHeader);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Name = "DashboardForm";
            Text = "StockFlow Enterprise";
            WindowState = FormWindowState.Maximized;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlViewPort.ResumeLayout(false);
            pnlDashboardHome.ResumeLayout(false);
            pnlGridContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLowStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
