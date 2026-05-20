namespace StockFlow.Forms
{
    partial class ProductEntryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Panel pnlName;
        private System.Windows.Forms.Panel pnlActions;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtName = new TextBox();
            cmbCategory = new ComboBox();
            cmbSupplier = new ComboBox();
            numPrice = new NumericUpDown();
            numQuantity = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            lblMessage = new Label();
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlContent = new Panel();
            lblName = new Label();
            pnlName = new Panel();
            lblCategory = new Label();
            lblSupplier = new Label();
            lblPrice = new Label();
            lblQuantity = new Label();
            pnlActions = new Panel();
            ((System.ComponentModel.ISupportInitialize)numPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            pnlHeader.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlName.SuspendLayout();
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
            txtName.Size = new Size(398, 20);
            txtName.TabIndex = 0;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.FlatStyle = FlatStyle.Flat;
            cmbCategory.Font = new Font("Segoe UI", 11F);
            cmbCategory.Location = new Point(40, 137);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(420, 28);
            cmbCategory.TabIndex = 3;
            // 
            // cmbSupplier
            // 
            cmbSupplier.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSupplier.FlatStyle = FlatStyle.Flat;
            cmbSupplier.Font = new Font("Segoe UI", 11F);
            cmbSupplier.Location = new Point(40, 212);
            cmbSupplier.Name = "cmbSupplier";
            cmbSupplier.Size = new Size(420, 28);
            cmbSupplier.TabIndex = 5;
            // 
            // numPrice
            // 
            numPrice.DecimalPlaces = 2;
            numPrice.Font = new Font("Segoe UI", 11F);
            numPrice.Location = new Point(40, 287);
            numPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numPrice.Name = "numPrice";
            numPrice.Size = new Size(420, 27);
            numPrice.TabIndex = 7;
            // 
            // numQuantity
            // 
            numQuantity.Font = new Font("Segoe UI", 11F);
            numQuantity.Location = new Point(40, 362);
            numQuantity.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(420, 27);
            numQuantity.TabIndex = 9;
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
            btnSave.Size = new Size(120, 45);
            btnSave.TabIndex = 0;
            btnSave.Text = "SAVE CHANGES";
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
            btnCancel.Location = new Point(130, 15);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 45);
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
            lblMessage.Location = new Point(0, 570);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(500, 30);
            lblMessage.TabIndex = 2;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(44, 62, 80);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(500, 70);
            pnlHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(25, 23);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(151, 21);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "PRODUCT DETAILS";
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(lblName);
            pnlContent.Controls.Add(pnlName);
            pnlContent.Controls.Add(lblCategory);
            pnlContent.Controls.Add(cmbCategory);
            pnlContent.Controls.Add(lblSupplier);
            pnlContent.Controls.Add(cmbSupplier);
            pnlContent.Controls.Add(lblPrice);
            pnlContent.Controls.Add(numPrice);
            pnlContent.Controls.Add(lblQuantity);
            pnlContent.Controls.Add(numQuantity);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 70);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(40);
            pnlContent.Size = new Size(500, 420);
            pnlContent.TabIndex = 0;
            // 
            // lblName
            // 
            lblName.Location = new Point(0, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 0;
            // 
            // pnlName
            // 
            pnlName.BackColor = Color.White;
            pnlName.BorderStyle = BorderStyle.FixedSingle;
            pnlName.Controls.Add(txtName);
            pnlName.Location = new Point(40, 62);
            pnlName.Name = "pnlName";
            pnlName.Padding = new Padding(10, 8, 10, 8);
            pnlName.Size = new Size(420, 40);
            pnlName.TabIndex = 1;
            // 
            // lblCategory
            // 
            lblCategory.Location = new Point(0, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(100, 23);
            lblCategory.TabIndex = 2;
            // 
            // lblSupplier
            // 
            lblSupplier.Location = new Point(0, 0);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(100, 23);
            lblSupplier.TabIndex = 4;
            // 
            // lblPrice
            // 
            lblPrice.Location = new Point(0, 0);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(100, 23);
            lblPrice.TabIndex = 6;
            // 
            // lblQuantity
            // 
            lblQuantity.Location = new Point(0, 0);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(100, 23);
            lblQuantity.TabIndex = 8;
            // 
            // pnlActions
            // 
            pnlActions.BackColor = Color.FromArgb(248, 249, 249);
            pnlActions.Controls.Add(btnSave);
            pnlActions.Controls.Add(btnCancel);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 490);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(500, 80);
            pnlActions.TabIndex = 1;
            // 
            // ProductEntryForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(500, 600);
            Controls.Add(pnlContent);
            Controls.Add(pnlActions);
            Controls.Add(lblMessage);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ProductEntryForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Product";
            ((System.ComponentModel.ISupportInitialize)numPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlContent.ResumeLayout(false);
            pnlName.ResumeLayout(false);
            pnlName.PerformLayout();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void ConfigureLabel(System.Windows.Forms.Label label, string text, int top)
        {
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            label.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            label.Location = new System.Drawing.Point(40, top);
            label.Text = text;
        }
    }
}
