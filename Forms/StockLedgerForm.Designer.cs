namespace StockFlow.Forms
{
    partial class StockLedgerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvLedger;
        private System.Windows.Forms.Button btnRefresh;

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
            this.dgvLedger = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();

            System.Windows.Forms.Panel pnlHeader = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Top, Height = 100, BackColor = System.Drawing.Color.White, Padding = new System.Windows.Forms.Padding(30, 20, 30, 20) };
            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label { Text = "STOCK MOVEMENT HISTORY", Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(44, 62, 80), Location = new System.Drawing.Point(30, 30), AutoSize = true };
            
            this.btnRefresh.Text = "↻ REFRESH";
            this.btnRefresh.Size = new System.Drawing.Size(130, 45);
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Location = new System.Drawing.Point(pnlHeader.Width - 160, 28);
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnRefresh.Click += (s, e) => LoadLedger();

            pnlHeader.Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, btnRefresh });

            DashboardForm.StyleGrid(this.dgvLedger, System.Drawing.Color.FromArgb(44, 62, 80));
            this.dgvLedger.CellFormatting += DgvLedger_CellFormatting;

            System.Windows.Forms.Panel pnlGridWrapper = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(15, 0, 15, 15) };
            pnlGridWrapper.Controls.Add(dgvLedger);

            this.Text = "Stock Ledger";
            this.Controls.Add(pnlGridWrapper);
            this.Controls.Add(pnlHeader);
        }
    }
}
