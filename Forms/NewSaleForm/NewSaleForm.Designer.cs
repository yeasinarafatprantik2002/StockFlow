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
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlGridWrapper;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.Panel pnlBottom;

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
            lstProducts = new ListBox();
            dgvCart = new DataGridView();
            txtSearch = new TextBox();
            lblTotal = new Label();
            btnAdd = new Button();
            btnRemove = new Button();
            btnCheckout = new Button();
            lblMessage = new Label();
            btnClose = new Button();
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlLeft = new Panel();
            pnlSearch = new Panel();
            lblSearch = new Label();
            pnlRight = new Panel();
            pnlGridWrapper = new Panel();
            lblCart = new Label();
            pnlBottom = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            pnlHeader.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlGridWrapper.SuspendLayout();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // lstProducts
            // 
            lstProducts.Dock = DockStyle.Fill;
            lstProducts.Font = new Font("Segoe UI", 12F);
            lstProducts.ItemHeight = 21;
            lstProducts.Location = new Point(30, 110);
            lstProducts.Margin = new Padding(0, 20, 0, 20);
            lstProducts.Name = "lstProducts";
            lstProducts.Size = new Size(390, 440);
            lstProducts.TabIndex = 0;
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToResizeRows = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.BackgroundColor = Color.White;
            dgvCart.BorderStyle = BorderStyle.None;
            dgvCart.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCart.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCart.ColumnHeadersHeight = 55;
            dgvCart.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgvCart.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCart.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(44, 62, 80);
            dgvCart.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgvCart.DefaultCellStyle.BackColor = Color.White;
            dgvCart.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            dgvCart.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 245, 251);
            dgvCart.DefaultCellStyle.SelectionForeColor = Color.FromArgb(41, 128, 185);
            dgvCart.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            dgvCart.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 245, 251);
            dgvCart.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(41, 128, 185);
            dgvCart.Dock = DockStyle.Fill;
            dgvCart.EnableHeadersVisualStyles = false;
            dgvCart.GridColor = Color.FromArgb(235, 235, 235);
            dgvCart.Location = new Point(0, 20);
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersVisible = false;
            dgvCart.RowTemplate.Height = 50;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(780, 320);
            dgvCart.TabIndex = 0;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Font = new Font("Segoe UI", 11F);
            txtSearch.Location = new Point(10, 8);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search products...";
            txtSearch.Size = new Size(368, 20);
            txtSearch.TabIndex = 0;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            txtSearch.KeyDown += TxtSearch_KeyDown;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Dock = DockStyle.Left;
            lblTotal.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(44, 62, 80);
            lblTotal.Location = new Point(30, 30);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(253, 51);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "TOTAL: $0.00";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.Dock = DockStyle.Bottom;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(30, 550);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(390, 60);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "+ ADD TO CART";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(-10, -10);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(1, 1);
            btnRemove.TabIndex = 0;
            btnRemove.Visible = false;
            // 
            // btnCheckout
            // 
            btnCheckout.BackColor = Color.FromArgb(52, 152, 219);
            btnCheckout.Dock = DockStyle.Right;
            btnCheckout.FlatAppearance.BorderSize = 0;
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(450, 30);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(300, 90);
            btnCheckout.TabIndex = 1;
            btnCheckout.Text = "CONFIRM & PRINT RECEIPT";
            btnCheckout.UseVisualStyleBackColor = false;
            btnCheckout.Click += BtnCheckout_Click;
            // 
            // lblMessage
            // 
            lblMessage.Dock = DockStyle.Bottom;
            lblMessage.Location = new Point(30, 120);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(720, 30);
            lblMessage.TabIndex = 2;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.FromArgb(231, 76, 60);
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1130, 18);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 45);
            btnClose.TabIndex = 1;
            btnClose.Text = "✕ CLOSE";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += BtnClose_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(44, 62, 80);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1280, 80);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(30, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(287, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "POINT OF SALE TERMINAL";
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.White;
            pnlLeft.Controls.Add(lstProducts);
            pnlLeft.Controls.Add(btnAdd);
            pnlLeft.Controls.Add(pnlSearch);
            pnlLeft.Controls.Add(lblSearch);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 80);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Padding = new Padding(30);
            pnlLeft.Size = new Size(450, 640);
            pnlLeft.TabIndex = 1;
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.White;
            pnlSearch.BorderStyle = BorderStyle.FixedSingle;
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(30, 60);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Padding = new Padding(10, 8, 10, 8);
            pnlSearch.Size = new Size(390, 50);
            pnlSearch.TabIndex = 2;
            // 
            // lblSearch
            // 
            lblSearch.Dock = DockStyle.Top;
            lblSearch.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblSearch.ForeColor = Color.Gray;
            lblSearch.Location = new Point(30, 30);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(390, 30);
            lblSearch.TabIndex = 3;
            lblSearch.Text = "PRODUCT SEARCH";
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.FromArgb(240, 243, 244);
            pnlRight.Controls.Add(pnlGridWrapper);
            pnlRight.Controls.Add(lblCart);
            pnlRight.Controls.Add(pnlBottom);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(450, 80);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(25);
            pnlRight.Size = new Size(830, 640);
            pnlRight.TabIndex = 0;
            // 
            // pnlGridWrapper
            // 
            pnlGridWrapper.Controls.Add(dgvCart);
            pnlGridWrapper.Dock = DockStyle.Fill;
            pnlGridWrapper.Location = new Point(25, 75);
            pnlGridWrapper.Name = "pnlGridWrapper";
            pnlGridWrapper.Padding = new Padding(0, 20, 0, 20);
            pnlGridWrapper.Size = new Size(780, 360);
            pnlGridWrapper.TabIndex = 0;
            // 
            // lblCart
            // 
            lblCart.Dock = DockStyle.Top;
            lblCart.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCart.Location = new Point(25, 25);
            lblCart.Name = "lblCart";
            lblCart.Size = new Size(780, 50);
            lblCart.TabIndex = 1;
            lblCart.Text = "SHOPPING CART";
            lblCart.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.White;
            pnlBottom.Controls.Add(lblTotal);
            pnlBottom.Controls.Add(btnCheckout);
            pnlBottom.Controls.Add(lblMessage);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(25, 435);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(30);
            pnlBottom.Size = new Size(780, 180);
            pnlBottom.TabIndex = 2;
            // 
            // NewSaleForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(1280, 720);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "NewSaleForm";
            Text = "New Sale";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlLeft.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlGridWrapper.ResumeLayout(false);
            pnlBottom.ResumeLayout(false);
            pnlBottom.PerformLayout();
            ResumeLayout(false);
        }
    }
}
