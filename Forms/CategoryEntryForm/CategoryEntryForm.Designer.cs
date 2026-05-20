namespace StockFlow.Forms
{
    partial class CategoryEntryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Panel pnlActions;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtName = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblMessage = new Label();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblName = new Label();
            pnlInput = new Panel();
            pnlActions = new Panel();
            pnlHeader.SuspendLayout();
            pnlInput.SuspendLayout();
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
            txtName.Size = new Size(308, 20);
            txtName.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.Cursor = Cursors.Hand;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(230, 10);
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
            btnCancel.Location = new Point(120, 10);
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
            lblMessage.Font = new Font("Segoe UI", 9F);
            lblMessage.ForeColor = Color.FromArgb(231, 76, 60);
            lblMessage.Location = new Point(0, 310);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(450, 40);
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
            pnlHeader.Size = new Size(450, 90);
            pnlHeader.TabIndex = 4;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(450, 90);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CATEGORY DETAILS";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(127, 140, 141);
            lblName.Location = new Point(60, 130);
            lblName.Name = "lblName";
            lblName.Size = new Size(104, 15);
            lblName.TabIndex = 1;
            lblName.Text = "CATEGORY NAME";
            // 
            // pnlInput
            // 
            pnlInput.BackColor = Color.White;
            pnlInput.BorderStyle = BorderStyle.FixedSingle;
            pnlInput.Controls.Add(txtName);
            pnlInput.Location = new Point(60, 158);
            pnlInput.Name = "pnlInput";
            pnlInput.Padding = new Padding(10, 8, 10, 8);
            pnlInput.Size = new Size(330, 40);
            pnlInput.TabIndex = 0;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(btnSave);
            pnlActions.Controls.Add(btnCancel);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 220);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(450, 90);
            pnlActions.TabIndex = 2;
            // 
            // CategoryEntryForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(450, 350);
            Controls.Add(pnlInput);
            Controls.Add(lblName);
            Controls.Add(pnlActions);
            Controls.Add(lblMessage);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "CategoryEntryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Category";
            pnlHeader.ResumeLayout(false);
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
