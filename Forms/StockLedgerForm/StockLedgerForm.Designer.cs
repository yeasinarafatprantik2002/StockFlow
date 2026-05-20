namespace StockFlow.Forms
{
    partial class StockLedgerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvLedger;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlGridWrapper;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvLedger = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlGridWrapper = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedger)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlGridWrapper.SuspendLayout();
            this.SuspendLayout();

            this.dgvLedger.AllowUserToAddRows = false;
            this.dgvLedger.AllowUserToResizeRows = false;
            this.dgvLedger.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLedger.BackgroundColor = System.Drawing.Color.White;
            this.dgvLedger.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLedger.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLedger.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLedger.ColumnHeadersHeight = 55;
            this.dgvLedger.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvLedger.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvLedger.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvLedger.ColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvLedger.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgvLedger.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.dgvLedger.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(235, 245, 251);
            this.dgvLedger.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.dgvLedger.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.dgvLedger.AlternatingRowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(235, 245, 251);
            this.dgvLedger.AlternatingRowsDefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.dgvLedger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLedger.EnableHeadersVisualStyles = false;
            this.dgvLedger.GridColor = System.Drawing.Color.FromArgb(235, 235, 235);
            this.dgvLedger.ReadOnly = true;
            this.dgvLedger.RowHeadersVisible = false;
            this.dgvLedger.RowTemplate.Height = 50;
            this.dgvLedger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLedger.CellFormatting += DgvLedger_CellFormatting;

            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(840, 28);
            this.btnRefresh.Size = new System.Drawing.Size(130, 45);
            this.btnRefresh.Text = "REFRESH";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += BtnRefresh_Click;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblTitle.Location = new System.Drawing.Point(30, 30);
            this.lblTitle.Text = "STOCK MOVEMENT HISTORY";

            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnRefresh);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlHeader.Size = new System.Drawing.Size(1000, 100);

            this.pnlGridWrapper.BackColor = System.Drawing.Color.FromArgb(244, 247, 249);
            this.pnlGridWrapper.Controls.Add(this.dgvLedger);
            this.pnlGridWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridWrapper.Padding = new System.Windows.Forms.Padding(15, 0, 15, 15);

            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 249);
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.pnlGridWrapper);
            this.Controls.Add(this.pnlHeader);
            this.Name = "StockLedgerForm";
            this.Text = "Stock Ledger";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLedger)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlGridWrapper.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}
