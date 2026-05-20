namespace StockFlow.Forms
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblTodayRevenue;
        private System.Windows.Forms.Label lblMonthRevenue;
        private System.Windows.Forms.DataGridView dgvTopProducts;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.Panel pnlTodayCard;
        private System.Windows.Forms.Panel pnlMonthCard;
        private System.Windows.Forms.Panel pnlTotalCard;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblTop;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.lblTodayRevenue = new System.Windows.Forms.Label();
            this.lblMonthRevenue = new System.Windows.Forms.Label();
            this.dgvTopProducts = new System.Windows.Forms.DataGridView();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.pnlTodayCard = new System.Windows.Forms.Panel();
            this.pnlMonthCard = new System.Windows.Forms.Panel();
            this.pnlTotalCard = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblTop = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.pnlTodayCard.SuspendLayout();
            this.pnlMonthCard.SuspendLayout();
            this.pnlTotalCard.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();

            this.dgvTopProducts.AllowUserToAddRows = false;
            this.dgvTopProducts.AllowUserToResizeRows = false;
            this.dgvTopProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTopProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTopProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvTopProducts.ColumnHeadersHeight = 55;
            this.dgvTopProducts.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvTopProducts.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvTopProducts.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvTopProducts.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvTopProducts.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvTopProducts.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvTopProducts.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(235, 245, 251);
            this.dgvTopProducts.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.dgvTopProducts.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.dgvTopProducts.AlternatingRowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(235, 245, 251);
            this.dgvTopProducts.AlternatingRowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.dgvTopProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopProducts.EnableHeadersVisualStyles = false;
            this.dgvTopProducts.GridColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.dgvTopProducts.ReadOnly = true;
            this.dgvTopProducts.RowHeadersVisible = false;
            this.dgvTopProducts.RowTemplate.Height = 50;
            this.dgvTopProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblTitle.Location = new System.Drawing.Point(35, 25);
            this.lblTitle.Text = "ANALYTICS & PERFORMANCE";

            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(35, 20, 35, 20);
            this.pnlHeader.Size = new System.Drawing.Size(1100, 90);

            this.pnlCards.BackColor = System.Drawing.Color.FromArgb(244, 247, 249);
            this.pnlCards.Controls.Add(this.pnlTodayCard);
            this.pnlCards.Controls.Add(this.pnlMonthCard);
            this.pnlCards.Controls.Add(this.pnlTotalCard);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Padding = new System.Windows.Forms.Padding(35, 20, 35, 10);
            this.pnlCards.Size = new System.Drawing.Size(1100, 190);

            ConfigureCard(this.pnlTodayCard, this.lblTodayRevenue, "TODAY'S REVENUE", System.Drawing.Color.FromArgb(46, 204, 113), 35);
            ConfigureCard(this.pnlMonthCard, this.lblMonthRevenue, "THIS MONTH", System.Drawing.Color.FromArgb(52, 152, 219), 400);
            ConfigureCard(this.pnlTotalCard, this.lblTotalRevenue, "ALL-TIME REVENUE", System.Drawing.Color.FromArgb(241, 196, 15), 765);

            this.lblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTop.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblTop.Height = 70;
            this.lblTop.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.lblTop.Text = "TOP SELLING PRODUCTS";
            this.lblTop.TextAlign = System.Drawing.ContentAlignment.BottomLeft;

            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(244, 247, 249);
            this.pnlBottom.Controls.Add(this.dgvTopProducts);
            this.pnlBottom.Controls.Add(this.lblTop);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(35, 10, 35, 60);

            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 249);
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlHeader);
            this.Name = "ReportsForm";
            this.Text = "Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopProducts)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCards.ResumeLayout(false);
            this.pnlTodayCard.ResumeLayout(false);
            this.pnlTodayCard.PerformLayout();
            this.pnlMonthCard.ResumeLayout(false);
            this.pnlMonthCard.PerformLayout();
            this.pnlTotalCard.ResumeLayout(false);
            this.pnlTotalCard.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void ConfigureCard(System.Windows.Forms.Panel panel, System.Windows.Forms.Label valueLabel, string title, System.Drawing.Color accent, int left)
        {
            System.Windows.Forms.Panel accentPanel = new System.Windows.Forms.Panel();
            System.Windows.Forms.Label titleLabel = new System.Windows.Forms.Label();

            panel.BackColor = System.Drawing.Color.White;
            panel.Controls.Add(valueLabel);
            panel.Controls.Add(titleLabel);
            panel.Controls.Add(accentPanel);
            panel.Location = new System.Drawing.Point(left, 20);
            panel.Size = new System.Drawing.Size(340, 140);
            panel.Paint += ReportCard_Paint;

            accentPanel.BackColor = accent;
            accentPanel.Dock = System.Windows.Forms.DockStyle.Left;
            accentPanel.Width = 6;

            titleLabel.AutoSize = true;
            titleLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            titleLabel.ForeColor = System.Drawing.Color.Gray;
            titleLabel.Location = new System.Drawing.Point(25, 25);
            titleLabel.Text = title;

            valueLabel.AutoSize = true;
            valueLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            valueLabel.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            valueLabel.Location = new System.Drawing.Point(22, 60);
            valueLabel.Text = "$0.00";
        }
    }
}
