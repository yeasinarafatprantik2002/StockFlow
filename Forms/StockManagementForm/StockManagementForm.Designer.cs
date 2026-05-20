namespace StockFlow.Forms
{
    partial class StockManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbProducts;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.RadioButton rbStockIn;
        private System.Windows.Forms.RadioButton rbStockOut;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblCurrentStock;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Panel pnlQuantity;
        private System.Windows.Forms.Panel pnlNote;
        private System.Windows.Forms.Label lblInfoTitle;
        private System.Windows.Forms.Label lblInfoText;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblNote;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            cmbProducts = new ComboBox();
            txtQuantity = new TextBox();
            txtNote = new TextBox();
            rbStockIn = new RadioButton();
            rbStockOut = new RadioButton();
            btnSubmit = new Button();
            lblMessage = new Label();
            lblCurrentStock = new Label();
            pnlCard = new Panel();
            pnlForm = new Panel();
            lblTitle = new Label();
            lblProduct = new Label();
            lblQuantity = new Label();
            pnlQuantity = new Panel();
            lblType = new Label();
            lblNote = new Label();
            pnlNote = new Panel();
            pnlInfo = new Panel();
            lblInfoText = new Label();
            lblInfoTitle = new Label();
            pnlCard.SuspendLayout();
            pnlForm.SuspendLayout();
            pnlQuantity.SuspendLayout();
            pnlNote.SuspendLayout();
            pnlInfo.SuspendLayout();
            SuspendLayout();
            // 
            // cmbProducts
            // 
            cmbProducts.DisplayMember = "Name";
            cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducts.FlatStyle = FlatStyle.Flat;
            cmbProducts.Font = new Font("Segoe UI", 11F);
            cmbProducts.Location = new Point(30, 122);
            cmbProducts.Name = "cmbProducts";
            cmbProducts.Size = new Size(520, 28);
            cmbProducts.TabIndex = 2;
            cmbProducts.ValueMember = "Id";
            // 
            // txtQuantity
            // 
            txtQuantity.BorderStyle = BorderStyle.None;
            txtQuantity.Dock = DockStyle.Fill;
            txtQuantity.Font = new Font("Segoe UI", 11F);
            txtQuantity.Location = new Point(10, 8);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(498, 20);
            txtQuantity.TabIndex = 0;
            // 
            // txtNote
            // 
            txtNote.BorderStyle = BorderStyle.None;
            txtNote.Dock = DockStyle.Fill;
            txtNote.Font = new Font("Segoe UI", 11F);
            txtNote.Location = new Point(10, 8);
            txtNote.Name = "txtNote";
            txtNote.PlaceholderText = "e.g., Damaged item, Restock, Return...";
            txtNote.Size = new Size(498, 20);
            txtNote.TabIndex = 0;
            // 
            // rbStockIn
            // 
            rbStockIn.AutoSize = true;
            rbStockIn.Checked = true;
            rbStockIn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            rbStockIn.ForeColor = Color.FromArgb(46, 204, 113);
            rbStockIn.Location = new Point(40, 315);
            rbStockIn.Name = "rbStockIn";
            rbStockIn.Size = new Size(90, 23);
            rbStockIn.TabIndex = 7;
            rbStockIn.TabStop = true;
            rbStockIn.Text = "STOCK IN";
            // 
            // rbStockOut
            // 
            rbStockOut.AutoSize = true;
            rbStockOut.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            rbStockOut.ForeColor = Color.FromArgb(231, 76, 60);
            rbStockOut.Location = new Point(180, 315);
            rbStockOut.Name = "rbStockOut";
            rbStockOut.Size = new Size(104, 23);
            rbStockOut.TabIndex = 8;
            rbStockOut.Text = "STOCK OUT";
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.FromArgb(44, 62, 80);
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(30, 520);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(520, 60);
            btnSubmit.TabIndex = 11;
            btnSubmit.Text = "EXECUTE ADJUSTMENT";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += BtnSubmit_Click;
            // 
            // lblMessage
            // 
            lblMessage.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblMessage.Location = new Point(30, 590);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(520, 30);
            lblMessage.TabIndex = 12;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentStock
            // 
            lblCurrentStock.AutoSize = true;
            lblCurrentStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCurrentStock.ForeColor = Color.Gray;
            lblCurrentStock.Location = new Point(35, 175);
            lblCurrentStock.Name = "lblCurrentStock";
            lblCurrentStock.Size = new Size(176, 15);
            lblCurrentStock.TabIndex = 3;
            lblCurrentStock.Text = "Select a product to view stock";
            // 
            // pnlCard
            // 
            pnlCard.BackColor = Color.White;
            pnlCard.Controls.Add(pnlForm);
            pnlCard.Controls.Add(pnlInfo);
            pnlCard.Location = new Point(150, 55);
            pnlCard.Name = "pnlCard";
            pnlCard.Size = new Size(800, 650);
            pnlCard.TabIndex = 0;
            // 
            // pnlForm
            // 
            pnlForm.Controls.Add(lblTitle);
            pnlForm.Controls.Add(lblProduct);
            pnlForm.Controls.Add(cmbProducts);
            pnlForm.Controls.Add(lblCurrentStock);
            pnlForm.Controls.Add(lblQuantity);
            pnlForm.Controls.Add(pnlQuantity);
            pnlForm.Controls.Add(lblType);
            pnlForm.Controls.Add(rbStockIn);
            pnlForm.Controls.Add(rbStockOut);
            pnlForm.Controls.Add(lblNote);
            pnlForm.Controls.Add(pnlNote);
            pnlForm.Controls.Add(btnSubmit);
            pnlForm.Controls.Add(lblMessage);
            pnlForm.Dock = DockStyle.Fill;
            pnlForm.Location = new Point(220, 0);
            pnlForm.Name = "pnlForm";
            pnlForm.Padding = new Padding(30);
            pnlForm.Size = new Size(580, 650);
            pnlForm.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(30, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(355, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "INVENTORY ADJUSTMENT";
            // 
            // lblProduct
            // 
            lblProduct.Location = new Point(0, 0);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(100, 23);
            lblProduct.TabIndex = 1;
            // 
            // lblQuantity
            // 
            lblQuantity.Location = new Point(0, 0);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(100, 23);
            lblQuantity.TabIndex = 4;
            // 
            // pnlQuantity
            // 
            pnlQuantity.BackColor = Color.White;
            pnlQuantity.BorderStyle = BorderStyle.FixedSingle;
            pnlQuantity.Controls.Add(txtQuantity);
            pnlQuantity.Location = new Point(30, 217);
            pnlQuantity.Name = "pnlQuantity";
            pnlQuantity.Padding = new Padding(10, 8, 10, 8);
            pnlQuantity.Size = new Size(520, 40);
            pnlQuantity.TabIndex = 5;
            // 
            // lblType
            // 
            lblType.Location = new Point(0, 0);
            lblType.Name = "lblType";
            lblType.Size = new Size(100, 23);
            lblType.TabIndex = 6;
            // 
            // lblNote
            // 
            lblNote.Location = new Point(0, 0);
            lblNote.Name = "lblNote";
            lblNote.Size = new Size(100, 23);
            lblNote.TabIndex = 9;
            // 
            // pnlNote
            // 
            pnlNote.BackColor = Color.White;
            pnlNote.BorderStyle = BorderStyle.FixedSingle;
            pnlNote.Controls.Add(txtNote);
            pnlNote.Location = new Point(30, 447);
            pnlNote.Name = "pnlNote";
            pnlNote.Padding = new Padding(10, 8, 10, 8);
            pnlNote.Size = new Size(520, 40);
            pnlNote.TabIndex = 10;
            // 
            // pnlInfo
            // 
            pnlInfo.BackColor = Color.FromArgb(44, 62, 80);
            pnlInfo.Controls.Add(lblInfoText);
            pnlInfo.Controls.Add(lblInfoTitle);
            pnlInfo.Dock = DockStyle.Left;
            pnlInfo.Location = new Point(0, 0);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.Padding = new Padding(20);
            pnlInfo.Size = new Size(220, 650);
            pnlInfo.TabIndex = 1;
            // 
            // lblInfoText
            // 
            lblInfoText.Dock = DockStyle.Top;
            lblInfoText.Font = new Font("Segoe UI", 9F);
            lblInfoText.ForeColor = Color.LightGray;
            lblInfoText.Location = new Point(20, 60);
            lblInfoText.Name = "lblInfoText";
            lblInfoText.Padding = new Padding(0, 20, 0, 0);
            lblInfoText.Size = new Size(180, 300);
            lblInfoText.TabIndex = 0;
            lblInfoText.Text = "1. Select product\r\n\r\n2. View current stock\r\n\r\n3. Choose direction\r\n\r\n4. Enter quantity\r\n\r\n5. Add reason/note\r\n\r\n6. Confirm";
            // 
            // lblInfoTitle
            // 
            lblInfoTitle.Dock = DockStyle.Top;
            lblInfoTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblInfoTitle.ForeColor = Color.White;
            lblInfoTitle.Location = new Point(20, 20);
            lblInfoTitle.Name = "lblInfoTitle";
            lblInfoTitle.Size = new Size(180, 40);
            lblInfoTitle.TabIndex = 1;
            lblInfoTitle.Text = "GUIDE";
            // 
            // StockManagementForm
            // 
            BackColor = Color.FromArgb(244, 247, 249);
            ClientSize = new Size(1100, 760);
            Controls.Add(pnlCard);
            Name = "StockManagementForm";
            Padding = new Padding(40);
            Text = "Stock Adjustment";
            Resize += StockManagementForm_Resize;
            pnlCard.ResumeLayout(false);
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            pnlQuantity.ResumeLayout(false);
            pnlQuantity.PerformLayout();
            pnlNote.ResumeLayout(false);
            pnlNote.PerformLayout();
            pnlInfo.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void ConfigureSmallLabel(System.Windows.Forms.Label label, string text, int top)
        {
            label.AutoSize = true;
            label.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            label.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            label.Location = new System.Drawing.Point(30, top);
            label.Text = text;
        }
    }
}
