namespace StockFlow.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pnlCard;

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
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlCard = new System.Windows.Forms.Panel();
            
            // --- Center Card ---
            this.pnlCard.Size = new System.Drawing.Size(400, 500);
            this.pnlCard.BackColor = System.Drawing.Color.White;
            
            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label {
                Text = "STOCKFLOW",
                Font = new System.Drawing.Font("Segoe UI Semibold", 28, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(44, 62, 80),
                Location = new System.Drawing.Point(0, 50),
                Size = new System.Drawing.Size(400, 50),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            System.Windows.Forms.Label lblSubtitle = new System.Windows.Forms.Label {
                Text = "INVENTORY MANAGEMENT",
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(189, 195, 199),
                Location = new System.Drawing.Point(0, 100),
                Size = new System.Drawing.Size(400, 20),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            };

            System.Windows.Forms.Label lblUser = new System.Windows.Forms.Label { Text = "USERNAME", Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(127, 140, 141), Location = new System.Drawing.Point(50, 160), AutoSize = true };
            System.Windows.Forms.Panel pnlUser = DashboardForm.StyleTextBox(this.txtUsername);
            pnlUser.Location = new System.Drawing.Point(50, 185);
            pnlUser.Width = 300;

            System.Windows.Forms.Label lblPass = new System.Windows.Forms.Label { Text = "PASSWORD", Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(127, 140, 141), Location = new System.Drawing.Point(50, 245), AutoSize = true };
            System.Windows.Forms.Panel pnlPass = DashboardForm.StyleTextBox(this.txtPassword);
            pnlPass.Location = new System.Drawing.Point(50, 270);
            pnlPass.Width = 300;
            this.txtPassword.PasswordChar = '●';

            this.btnLogin.Text = "SIGN IN";
            this.btnLogin.Location = new System.Drawing.Point(50, 340);
            this.btnLogin.Size = new System.Drawing.Size(300, 50);
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Click += new System.EventHandler(BtnLogin_Click);

            this.lblMessage.Location = new System.Drawing.Point(50, 410);
            this.lblMessage.Size = new System.Drawing.Size(300, 40);
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 9);
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.pnlCard.Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, lblSubtitle, lblUser, pnlUser, lblPass, pnlPass, btnLogin, lblMessage });

            // Form config
            this.Text = "StockFlow Enterprise - Login";
            this.BackColor = System.Drawing.Color.FromArgb(44, 62, 80); // Professional Navy background
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.Add(pnlCard);
            
            this.Resize += (s, e) => {
                pnlCard.Left = (this.ClientSize.Width - pnlCard.Width) / 2;
                pnlCard.Top = (this.ClientSize.Height - pnlCard.Height) / 2;
            };
        }
    }
}
