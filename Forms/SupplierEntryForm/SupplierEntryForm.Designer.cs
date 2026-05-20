namespace StockFlow.Forms
{
    partial class SupplierEntryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtContactInfo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Panel pnlName;
        private System.Windows.Forms.Panel pnlContact;
        private System.Windows.Forms.Panel pnlActions;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtName = new TextBox();
            txtContactInfo = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblMessage = new Label();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblName = new Label();
            lblContact = new Label();
            pnlName = new Panel();
            pnlContact = new Panel();
            pnlActions = new Panel();
            pnlHeader.SuspendLayout();
            pnlName.SuspendLayout();
            pnlContact.SuspendLayout();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.None;
            txtName.Dock = DockStyle.Fill;
            txtName.Font = new Font("Segoe UI", 11F);
            txtName.Location = new Point(10, 8);
            txtName.Name = "txtName";
            txtName.Size = new Size(378, 20);
            txtName.TabIndex = 0;
            // 
            // txtContactInfo
            // 
            txtContactInfo.BorderStyle = BorderStyle.None;
            txtContactInfo.Dock = DockStyle.Fill;
            txtContactInfo.Font = new Font("Segoe UI", 11F);
            txtContactInfo.Location = new Point(10, 8);
            txtContactInfo.Multiline = true;
            txtContactInfo.Name = "txtContactInfo";
            txtContactInfo.Size = new Size(378, 82);
            txtContactInfo.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(260, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 45);
            btnSave.TabIndex = 0;
            btnSave.Text = "SAVE";
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
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(150, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 45);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // lblMessage
            // 
            lblMessage.Dock = DockStyle.Bottom;
            lblMessage.Location = new Point(0, 420);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(480, 30);
            lblMessage.TabIndex = 6;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(44, 62, 80);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(480, 70);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(25, 22);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(125, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SUPPLIER INFO";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(127, 140, 141);
            lblName.Location = new Point(40, 85);
            lblName.Name = "lblName";
            lblName.Size = new Size(94, 13);
            lblName.TabIndex = 1;
            lblName.Text = "SUPPLIER NAME";
            // 
            // lblContact
            // 
            lblContact.AutoSize = true;
            lblContact.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblContact.ForeColor = Color.FromArgb(127, 140, 141);
            lblContact.Location = new Point(40, 160);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(162, 13);
            lblContact.TabIndex = 3;
            lblContact.Text = "CONTACT DETAILS / ADDRESS";
            // 
            // pnlName
            // 
            pnlName.BackColor = Color.White;
            pnlName.BorderStyle = BorderStyle.FixedSingle;
            pnlName.Controls.Add(txtName);
            pnlName.Location = new Point(40, 107);
            pnlName.Name = "pnlName";
            pnlName.Padding = new Padding(10, 8, 10, 8);
            pnlName.Size = new Size(400, 40);
            pnlName.TabIndex = 2;
            // 
            // pnlContact
            // 
            pnlContact.BackColor = Color.White;
            pnlContact.BorderStyle = BorderStyle.FixedSingle;
            pnlContact.Controls.Add(txtContactInfo);
            pnlContact.Location = new Point(40, 182);
            pnlContact.Name = "pnlContact";
            pnlContact.Padding = new Padding(10, 8, 10, 8);
            pnlContact.Size = new Size(400, 100);
            pnlContact.TabIndex = 4;
            // 
            // pnlActions
            // 
            pnlActions.BackColor = Color.FromArgb(248, 249, 249);
            pnlActions.Controls.Add(btnSave);
            pnlActions.Controls.Add(btnCancel);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 350);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(480, 70);
            pnlActions.TabIndex = 5;
            // 
            // SupplierEntryForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(480, 450);
            Controls.Add(pnlHeader);
            Controls.Add(lblName);
            Controls.Add(pnlName);
            Controls.Add(lblContact);
            Controls.Add(pnlContact);
            Controls.Add(pnlActions);
            Controls.Add(lblMessage);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "SupplierEntryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Supplier";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlName.ResumeLayout(false);
            pnlName.PerformLayout();
            pnlContact.ResumeLayout(false);
            pnlContact.PerformLayout();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
