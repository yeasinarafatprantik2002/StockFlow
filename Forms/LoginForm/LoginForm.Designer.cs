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
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Panel pnlPass;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;

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
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            lblMessage = new Label();
            pnlCard = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblUser = new Label();
            pnlUser = new Panel();
            lblPass = new Label();
            pnlPass = new Panel();
            pnlCard.SuspendLayout();
            pnlUser.SuspendLayout();
            pnlPass.SuspendLayout();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Dock = DockStyle.Fill;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(10, 8);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(278, 20);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(10, 8);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(278, 20);
            txtPassword.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(46, 204, 113);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(50, 340);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(300, 50);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "SIGN IN";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += BtnLogin_Click;
            // 
            // lblMessage
            // 
            lblMessage.Font = new Font("Segoe UI", 9F);
            lblMessage.Location = new Point(50, 410);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(300, 40);
            lblMessage.TabIndex = 7;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(lblTitle);
            pnlCard.Controls.Add(lblSubtitle);
            pnlCard.Controls.Add(lblUser);
            pnlCard.Controls.Add(pnlUser);
            pnlCard.Controls.Add(lblPass);
            pnlCard.Controls.Add(pnlPass);
            pnlCard.Controls.Add(btnLogin);
            pnlCard.Controls.Add(lblMessage);
            pnlCard.Location = new Point(0, 0);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(400, 500);
            pnlCard.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI Semibold", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(0, 50);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "STOCKFLOW";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSubtitle.ForeColor = Color.FromArgb(189, 195, 199);
            lblSubtitle.Location = new Point(0, 100);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(400, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "INVENTORY MANAGEMENT";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUser.ForeColor = Color.FromArgb(127, 140, 141);
            lblUser.Location = new Point(50, 160);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(71, 15);
            lblUser.TabIndex = 2;
            lblUser.Text = "USERNAME";
            // 
            // pnlUser
            // 
            pnlUser.BackColor = Color.White;
            pnlUser.BorderStyle = BorderStyle.FixedSingle;
            pnlUser.Controls.Add(txtUsername);
            pnlUser.Location = new Point(50, 185);
            pnlUser.Name = "pnlUser";
            pnlUser.Padding = new Padding(10, 8, 10, 8);
            pnlUser.Size = new Size(300, 38);
            pnlUser.TabIndex = 3;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPass.ForeColor = Color.FromArgb(127, 140, 141);
            lblPass.Location = new Point(50, 245);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(73, 15);
            lblPass.TabIndex = 4;
            lblPass.Text = "PASSWORD";
            // 
            // pnlPass
            // 
            pnlPass.BackColor = Color.White;
            pnlPass.BorderStyle = BorderStyle.FixedSingle;
            pnlPass.Controls.Add(txtPassword);
            pnlPass.Location = new Point(50, 270);
            pnlPass.Name = "pnlPass";
            pnlPass.Padding = new Padding(10, 8, 10, 8);
            pnlPass.Size = new Size(300, 38);
            pnlPass.TabIndex = 5;
            // 
            // LoginForm
            // 
            BackColor = Color.FromArgb(44, 62, 80);
            ClientSize = new Size(399, 497);
            Controls.Add(pnlCard);
            Name = "LoginForm";
            Text = "StockFlow Enterprise - Login";
            WindowState = FormWindowState.Maximized;
            Resize += LoginForm_Resize;
            pnlCard.ResumeLayout(false);
            pnlCard.PerformLayout();
            pnlUser.ResumeLayout(false);
            pnlUser.PerformLayout();
            pnlPass.ResumeLayout(false);
            pnlPass.PerformLayout();
            ResumeLayout(false);
        }
    }
}
