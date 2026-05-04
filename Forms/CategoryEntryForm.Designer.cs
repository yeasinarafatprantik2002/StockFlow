namespace StockFlow.Forms
{
    partial class CategoryEntryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave, btnCancel;
        private System.Windows.Forms.Label lblMessage;

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
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();

            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(450, 350);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            System.Windows.Forms.Panel pnlHeader = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Top, Height = 70, BackColor = System.Drawing.Color.FromArgb(44, 62, 80) };
            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label { Text = "CATEGORY INFO", Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(25, 22), AutoSize = true };
            pnlHeader.Controls.Add(lblTitle);

            System.Windows.Forms.Label lblName = new System.Windows.Forms.Label { Text = "CATEGORY NAME", Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(127, 140, 141), Location = new System.Drawing.Point(35, 85), AutoSize = true };
            System.Windows.Forms.Panel pnlName = DashboardForm.StyleTextBox(this.txtName);
            pnlName.Location = new System.Drawing.Point(35, 107);
            pnlName.Width = 380;

            System.Windows.Forms.Panel pnlActions = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Bottom, Height = 70, BackColor = System.Drawing.Color.FromArgb(248, 249, 249) };
            StyleBtn(btnSave, "SAVE", System.Drawing.Color.FromArgb(46, 204, 113), true);
            StyleBtn(btnCancel, "CANCEL", System.Drawing.Color.FromArgb(189, 195, 199), false);
            btnSave.Location = new System.Drawing.Point(230, 10);
            btnCancel.Location = new System.Drawing.Point(120, 10);
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.Close();

            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMessage.Height = 30;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            pnlActions.Controls.AddRange(new System.Windows.Forms.Control[] { btnSave, btnCancel });
            this.Controls.AddRange(new System.Windows.Forms.Control[] { pnlHeader, pnlName, lblName, pnlActions, lblMessage });
        }

        private void StyleBtn(System.Windows.Forms.Button btn, string text, System.Drawing.Color color, bool primary)
        {
            btn.Text = text; btn.Size = new System.Drawing.Size(100, 45); btn.BackColor = color; btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0; btn.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }
    }
}
