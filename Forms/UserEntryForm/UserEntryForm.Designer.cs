namespace StockFlow.Forms
{
    partial class UserEntryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Panel pnlUsername;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.Panel pnlActions;

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
            cmbRole = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblMessage = new Label();
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlContent = new Panel();
            lblUsername = new Label();
            pnlUsername = new Panel();
            lblPassword = new Label();
            pnlPassword = new Panel();
            lblRole = new Label();
            pnlActions = new Panel();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlUsername.SuspendLayout();
            pnlPassword.SuspendLayout();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Dock = DockStyle.Fill;
            txtUsername.Font = new Font("Segoe UI", 11F);
            txtUsername.Location = new Point(10, 8);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(378, 20);
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
            txtPassword.Size = new Size(378, 20);
            txtPassword.TabIndex = 0;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FlatStyle = FlatStyle.Flat;
            cmbRole.Font = new Font("Segoe UI", 11F);
            cmbRole.Location = new Point(40, 227);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(400, 28);
            cmbRole.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(260, 15);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 45);
            btnSave.TabIndex = 0;
            btnSave.Text = "CREATE ACCOUNT";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += BtnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(189, 195, 199);
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(44, 62, 80);
            btnCancel.Location = new Point(140, 15);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(110, 45);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // lblMessage
            // 
            lblMessage.Dock = DockStyle.Bottom;
            lblMessage.Font = new Font("Segoe UI", 8F);
            lblMessage.ForeColor = Color.FromArgb(231, 76, 60);
            lblMessage.Location = new Point(0, 450);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(480, 30);
            lblMessage.TabIndex = 3;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(44, 62, 80);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(480, 60);
            pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(171, 20);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ONBOARD NEW STAFF";
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(lblUsername);
            pnlContent.Controls.Add(pnlUsername);
            pnlContent.Controls.Add(lblPassword);
            pnlContent.Controls.Add(pnlPassword);
            pnlContent.Controls.Add(lblRole);
            pnlContent.Controls.Add(cmbRole);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 60);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(35);
            pnlContent.Size = new Size(480, 310);
            pnlContent.TabIndex = 0;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(127, 140, 141);
            lblUsername.Location = new Point(40, 40);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(68, 13);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "USERNAME";
            // 
            // pnlUsername
            // 
            pnlUsername.BackColor = Color.White;
            pnlUsername.BorderStyle = BorderStyle.FixedSingle;
            pnlUsername.Controls.Add(txtUsername);
            pnlUsername.Location = new Point(40, 62);
            pnlUsername.Name = "pnlUsername";
            pnlUsername.Padding = new Padding(10, 8, 10, 8);
            pnlUsername.Size = new Size(400, 40);
            pnlUsername.TabIndex = 1;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(127, 140, 141);
            lblPassword.Location = new Point(40, 115);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(67, 13);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "PASSWORD";
            // 
            // pnlPassword
            // 
            pnlPassword.BackColor = Color.White;
            pnlPassword.BorderStyle = BorderStyle.FixedSingle;
            pnlPassword.Controls.Add(txtPassword);
            pnlPassword.Location = new Point(40, 137);
            pnlPassword.Name = "pnlPassword";
            pnlPassword.Padding = new Padding(10, 8, 10, 8);
            pnlPassword.Size = new Size(400, 40);
            pnlPassword.TabIndex = 3;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(127, 140, 141);
            lblRole.Location = new Point(40, 205);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(118, 13);
            lblRole.TabIndex = 4;
            lblRole.Text = "ASSIGN INITIAL ROLE";
            // 
            // pnlActions
            // 
            pnlActions.BackColor = Color.FromArgb(248, 249, 249);
            pnlActions.Controls.Add(btnSave);
            pnlActions.Controls.Add(btnCancel);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 370);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(480, 80);
            pnlActions.TabIndex = 2;
            // 
            // UserEntryForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(480, 480);
            Controls.Add(pnlContent);
            Controls.Add(pnlActions);
            Controls.Add(lblMessage);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "UserEntryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "User Account";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlContent.PerformLayout();
            pnlUsername.ResumeLayout(false);
            pnlUsername.PerformLayout();
            pnlPassword.ResumeLayout(false);
            pnlPassword.PerformLayout();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
