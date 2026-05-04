namespace StockFlow.Forms
{
    partial class UserEntryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUsername, txtPassword;
        private System.Windows.Forms.ComboBox cmbRole;
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
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();

            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 480);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            System.Windows.Forms.Panel pnlHeader = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Top, Height = 60, BackColor = System.Drawing.Color.FromArgb(44, 62, 80) };
            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label { Text = "ONBOARD NEW STAFF", Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.White, Location = new System.Drawing.Point(20, 18), AutoSize = true };
            pnlHeader.Controls.Add(lblTitle);

            System.Windows.Forms.Panel pnlContent = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(35) };
            
            AddInput(pnlContent, "USERNAME", txtUsername, 0);
            AddInput(pnlContent, "PASSWORD", txtPassword, 1);
            this.txtPassword.PasswordChar = '●';

            System.Windows.Forms.Label lblRole = new System.Windows.Forms.Label { Text = "ASSIGN INITIAL ROLE", Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(127, 140, 141), Location = new System.Drawing.Point(40, 205), AutoSize = true };
            this.cmbRole.Location = new System.Drawing.Point(40, 227);
            this.cmbRole.Width = 400;
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 11);
            this.cmbRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            System.Windows.Forms.Panel pnlActions = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Bottom, Height = 80, BackColor = System.Drawing.Color.FromArgb(248, 249, 249) };
            StyleBtn(btnSave, "CREATE ACCOUNT", System.Drawing.Color.FromArgb(46, 204, 113), true);
            btnSave.Location = new System.Drawing.Point(260, 15);
            btnSave.Width = 180;
            btnSave.Click += BtnSave_Click;

            StyleBtn(btnCancel, "CANCEL", System.Drawing.Color.FromArgb(189, 195, 199), false);
            btnCancel.Location = new System.Drawing.Point(140, 15);
            btnCancel.Click += (s, e) => this.Close();

            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMessage.Height = 30;
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 8);

            pnlActions.Controls.AddRange(new System.Windows.Forms.Control[] { btnSave, btnCancel });
            pnlContent.Controls.AddRange(new System.Windows.Forms.Control[] { lblRole, cmbRole });
            
            this.Controls.AddRange(new System.Windows.Forms.Control[] { pnlContent, pnlHeader, pnlActions, lblMessage });
        }

        private void AddInput(System.Windows.Forms.Panel p, string label, System.Windows.Forms.TextBox ctrl, int index)
        {
            System.Windows.Forms.Label l = new System.Windows.Forms.Label { Text = label, Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(127, 140, 141), Location = new System.Drawing.Point(40, 40 + (index * 75)), AutoSize = true };
            System.Windows.Forms.Panel pnl = DashboardForm.StyleTextBox(ctrl);
            pnl.Location = new System.Drawing.Point(40, 62 + (index * 75));
            pnl.Width = 400;
            p.Controls.Add(l);
            p.Controls.Add(pnl);
        }

        private void StyleBtn(System.Windows.Forms.Button btn, string text, System.Drawing.Color color, bool primary)
        {
            btn.Text = text; btn.Size = new System.Drawing.Size(110, 45); btn.BackColor = color; 
            btn.ForeColor = primary ? System.Drawing.Color.White : System.Drawing.Color.FromArgb(44, 62, 80);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0; 
            btn.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold); btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }
    }
}
