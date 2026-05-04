namespace StockFlow.Forms
{
    partial class NewSaleForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstProducts;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblTotal, lblMessage;
        private System.Windows.Forms.Button btnAdd, btnRemove, btnCheckout, btnClose;

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
            this.lstProducts = new System.Windows.Forms.ListBox();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();

            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            // --- Header ---
            System.Windows.Forms.Panel pnlHeader = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Top, Height = 80, BackColor = System.Drawing.Color.FromArgb(44, 62, 80) };
            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label { Text = "POINT OF SALE TERMINAL", Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(30, 22), AutoSize = true };
            
            this.btnClose.Text = "✕ CLOSE";
            this.btnClose.Size = new System.Drawing.Size(120, 45);
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            this.btnClose.Location = new System.Drawing.Point(this.Width - 150, 18);
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnClose.Click += (s, e) => this.Close();
            
            pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, btnClose });

            // --- Main Layout ---
            System.Windows.Forms.Panel pnlLeft = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Left, Width = 450, BackColor = System.Drawing.Color.White, Padding = new System.Windows.Forms.Padding(30) };
            System.Windows.Forms.Panel pnlRight = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Fill, BackColor = System.Drawing.Color.FromArgb(240, 243, 244), Padding = new System.Windows.Forms.Padding(25) };
            
            // Left Panel Content
            System.Windows.Forms.Label lblSearch = new System.Windows.Forms.Label { Text = "PRODUCT SEARCH", Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.Gray, Dock = System.Windows.Forms.DockStyle.Top, Height = 30 };
            
            this.txtSearch.PlaceholderText = "Search products...";
            System.Windows.Forms.Panel pnlSearch = DashboardForm.StyleTextBox(this.txtSearch);
            pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            pnlSearch.Height = 50;
            
            this.txtSearch.TextChanged += async (s, e) => {
                _products = await _productService.SearchProductsAsync(txtSearch.Text);
                lstProducts.DataSource = null;
                lstProducts.DataSource = _products;
                lstProducts.DisplayMember = "Name";
            };
            this.txtSearch.KeyDown += TxtSearch_KeyDown;

            this.lstProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstProducts.Font = new System.Drawing.Font("Segoe UI", 12);
            this.lstProducts.ItemHeight = 35;
            this.lstProducts.Margin = new System.Windows.Forms.Padding(0, 20, 0, 20);

            this.btnAdd.Text = "+ ADD TO CART";
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAdd.Height = 60;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            this.btnAdd.Click += BtnAdd_Click;

            pnlLeft.Controls.AddRange(new System.Windows.Forms.Control[] { lstProducts, btnAdd, pnlSearch, lblSearch });

            // Right Panel Content (Cart)
            System.Windows.Forms.Label lblCart = new System.Windows.Forms.Label { Text = "SHOPPING CART", Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold), Dock = System.Windows.Forms.DockStyle.Top, Height = 50, TextAlign = System.Drawing.ContentAlignment.BottomLeft };
            
            DashboardForm.StyleGrid(this.dgvCart, System.Drawing.Color.FromArgb(44, 62, 80));

            System.Windows.Forms.Panel pnlBottom = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Bottom, Height = 180, BackColor = System.Drawing.Color.White, Padding = new System.Windows.Forms.Padding(30) };
            this.lblTotal.Text = "TOTAL: $0.00";
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 28, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblTotal.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTotal.AutoSize = true;

            this.btnCheckout.Text = "CONFIRM & PRINT RECEIPT";
            this.btnCheckout.Size = new System.Drawing.Size(300, 70);
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            this.btnCheckout.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCheckout.Click += BtnCheckout_Click;

            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMessage.Height = 30;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            pnlBottom.Controls.AddRange(new System.Windows.Forms.Control[] { lblTotal, btnCheckout, lblMessage });
            
            System.Windows.Forms.Panel pnlGridWrapper = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(0, 20, 0, 20) };
            pnlGridWrapper.Controls.Add(dgvCart);

            pnlRight.Controls.AddRange(new System.Windows.Forms.Control[] { pnlGridWrapper, lblCart, pnlBottom });

            this.Controls.AddRange(new System.Windows.Forms.Control[] { pnlRight, pnlLeft, pnlHeader });
        }
    }
}
