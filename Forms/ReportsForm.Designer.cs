namespace StockFlow.Forms
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTotalRevenue, lblTodayRevenue, lblMonthRevenue;
        private System.Windows.Forms.DataGridView dgvTopProducts;

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
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.lblTodayRevenue = new System.Windows.Forms.Label();
            this.lblMonthRevenue = new System.Windows.Forms.Label();
            this.dgvTopProducts = new System.Windows.Forms.DataGridView();

            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 249);

            System.Windows.Forms.Panel pnlHeader = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Top, Height = 90, BackColor = System.Drawing.Color.White, Padding = new System.Windows.Forms.Padding(35, 20, 35, 20) };
            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label { Text = "ANALYTICS & PERFORMANCE", Font = new System.Drawing.Font("Segoe UI", 18, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(44, 62, 80), Location = new System.Drawing.Point(35, 25), AutoSize = true };
            pnlHeader.Controls.Add(lblTitle);

            System.Windows.Forms.FlowLayoutPanel pnlCards = new System.Windows.Forms.FlowLayoutPanel { Dock = System.Windows.Forms.DockStyle.Top, Height = 190, Padding = new System.Windows.Forms.Padding(35, 20, 35, 10), BackColor = System.Drawing.Color.FromArgb(244, 247, 249), AutoScroll = true };
            
            if (_user.Role == "SuperAdmin")
            {
                AddReportCard(pnlCards, "TODAY'S REVENUE", lblTodayRevenue, System.Drawing.Color.FromArgb(46, 204, 113), "💰");
                AddReportCard(pnlCards, "THIS MONTH", lblMonthRevenue, System.Drawing.Color.FromArgb(52, 152, 219), "📅");
                AddReportCard(pnlCards, "ALL-TIME REVENUE", lblTotalRevenue, System.Drawing.Color.FromArgb(241, 196, 15), "📈");
            }
            else
            {
                pnlCards.Height = 0;
                pnlCards.Visible = false;
            }

            System.Windows.Forms.Panel pnlBottom = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(35, 10, 35, 60), BackColor = System.Drawing.Color.FromArgb(244, 247, 249) };
            System.Windows.Forms.Label lblTop = new System.Windows.Forms.Label { Text = "📊 TOP SELLING PRODUCTS", Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(127, 140, 141), Dock = System.Windows.Forms.DockStyle.Top, Height = 70, Padding = new System.Windows.Forms.Padding(0, 0, 0, 20), TextAlign = System.Drawing.ContentAlignment.BottomLeft };
            
            DashboardForm.StyleGrid(this.dgvTopProducts, System.Drawing.Color.FromArgb(44, 62, 80));

            pnlBottom.Controls.Add(dgvTopProducts);
            pnlBottom.Controls.Add(lblTop);

            this.Text = "Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.Add(pnlBottom);
            this.Controls.Add(pnlCards);
            this.Controls.Add(pnlHeader);
        }

        private void AddReportCard(System.Windows.Forms.FlowLayoutPanel parent, string title, System.Windows.Forms.Label valLabel, System.Drawing.Color accent, string icon)
        {
            System.Windows.Forms.Panel p = new System.Windows.Forms.Panel { Size = new System.Drawing.Size(340, 140), BackColor = System.Drawing.Color.White, Margin = new System.Windows.Forms.Padding(0, 0, 25, 0) };
            
            // Subtle Shadow/Border
            p.Paint += (s, e) => {
                System.Windows.Forms.ControlPaint.DrawBorder(e.Graphics, p.ClientRectangle, System.Drawing.Color.FromArgb(230, 230, 230), System.Windows.Forms.ButtonBorderStyle.Solid);
            };

            System.Windows.Forms.Panel acc = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Left, Width = 6, BackColor = accent };
            
            System.Windows.Forms.Label i = new System.Windows.Forms.Label { Text = icon, Location = new System.Drawing.Point(280, 20), Font = new System.Drawing.Font("Segoe UI", 20), AutoSize = true };
            System.Windows.Forms.Label t = new System.Windows.Forms.Label { Text = title, Location = new System.Drawing.Point(25, 25), AutoSize = true, Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.Gray };
            
            valLabel.Text = "$0.00";
            valLabel.Location = new System.Drawing.Point(22, 60);
            valLabel.AutoSize = true;
            valLabel.Font = new System.Drawing.Font("Segoe UI", 24, System.Drawing.FontStyle.Bold);
            valLabel.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            
            p.Controls.AddRange(new System.Windows.Forms.Control[] { acc, i, t, valLabel });
            parent.Controls.Add(p);
        }
    }
}
