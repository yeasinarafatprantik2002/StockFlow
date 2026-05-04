namespace StockFlow.Forms
{
    partial class SalesForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.Button btnRefresh, btnNewSale;
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
            this.dgvSales = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnNewSale = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();

            System.Windows.Forms.Panel pnlHeader = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Top, Height = 100, BackColor = System.Drawing.Color.White, Padding = new System.Windows.Forms.Padding(30, 20, 30, 20) };
            
            System.Windows.Forms.Label lblSearchIcon = new System.Windows.Forms.Label { Text = "🔍", Font = new System.Drawing.Font("Segoe UI", 12), Location = new System.Drawing.Point(35, 42), AutoSize = true };
            this.txtSearch.PlaceholderText = "Search by ID or staff...";
            System.Windows.Forms.Panel pnlSearch = DashboardForm.StyleTextBox(this.txtSearch);
            pnlSearch.Location = new System.Drawing.Point(80, 35);
            pnlSearch.Width = 350;
            this.txtSearch.TextChanged += async (s, e) => UpdateGrid(await _salesService.SearchSalesAsync(txtSearch.Text));

            System.Windows.Forms.FlowLayoutPanel pnlActions = new System.Windows.Forms.FlowLayoutPanel { Dock = System.Windows.Forms.DockStyle.Right, AutoSize = true, Padding = new System.Windows.Forms.Padding(0, 10, 0, 0) };
            
            StyleButton(btnRefresh, "↻ REFRESH", System.Drawing.Color.FromArgb(52, 152, 219));
            btnRefresh.Click += (s, e) => LoadSales();

            if (_currentUser.Role != "PartTimeStaff")
            {
                StyleButton(btnNewSale, "+ NEW SALE", System.Drawing.Color.FromArgb(46, 204, 113));
                btnNewSale.Click += (s, e) => { if (new NewSaleForm(_currentUser).ShowDialog() == System.Windows.Forms.DialogResult.OK) LoadSales(); };
                pnlActions.Controls.Add(btnNewSale);
            }
            pnlActions.Controls.Add(btnRefresh);
            pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[] { lblSearchIcon, pnlSearch, pnlActions });

            DashboardForm.StyleGrid(this.dgvSales, System.Drawing.Color.FromArgb(44, 62, 80));
            this.dgvSales.CellFormatting += DgvSales_CellFormatting;

            System.Windows.Forms.Panel pnlGridWrapper = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(15, 0, 15, 15) };
            pnlGridWrapper.Controls.Add(dgvSales);

            this.Text = "Sales History";
            this.Controls.Add(pnlGridWrapper);
            this.Controls.Add(pnlHeader);
        }
    }
}
