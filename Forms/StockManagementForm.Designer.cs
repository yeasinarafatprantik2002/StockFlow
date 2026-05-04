namespace StockFlow.Forms
{
    partial class StockManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbProducts;
        private System.Windows.Forms.TextBox txtQuantity, txtNote;
        private System.Windows.Forms.RadioButton rbStockIn, rbStockOut;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblMessage, lblCurrentStock;

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
            this.cmbProducts = new System.Windows.Forms.ComboBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.rbStockIn = new System.Windows.Forms.RadioButton();
            this.rbStockOut = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblCurrentStock = new System.Windows.Forms.Label();

            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 249);
            this.Padding = new System.Windows.Forms.Padding(40);

            System.Windows.Forms.Panel pnlCard = new System.Windows.Forms.Panel { Size = new System.Drawing.Size(800, 650), BackColor = System.Drawing.Color.White };
            
            // Left Panel (Instructions/Status)
            System.Windows.Forms.Panel pnlInfo = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Left, Width = 220, BackColor = System.Drawing.Color.FromArgb(44, 62, 80), Padding = new System.Windows.Forms.Padding(20) };
            System.Windows.Forms.Label lblInfoTitle = new System.Windows.Forms.Label { Text = "GUIDE", Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.White, Dock = System.Windows.Forms.DockStyle.Top, Height = 40 };
            System.Windows.Forms.Label lblInfoText = new System.Windows.Forms.Label { 
                Text = "1. Select product\n\n2. View current stock\n\n3. Choose direction\n\n4. Enter quantity\n\n5. Add reason/note\n\n6. Confirm", 
                Font = new System.Drawing.Font("Segoe UI", 9), ForeColor = System.Drawing.Color.LightGray, Dock = System.Windows.Forms.DockStyle.Top, Height = 300, Padding = new System.Windows.Forms.Padding(0, 20, 0, 0) 
            };
            pnlInfo.Controls.AddRange(new System.Windows.Forms.Control[] { lblInfoText, lblInfoTitle });

            // Right Panel (Form)
            System.Windows.Forms.Panel pnlForm = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(30) };
            
            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label { Text = "INVENTORY ADJUSTMENT", Font = new System.Drawing.Font("Segoe UI", 20, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(44, 62, 80), Location = new System.Drawing.Point(30, 30), AutoSize = true };
            
            AddInput(pnlForm, "PRODUCT TO ADJUST", cmbProducts, 0);
            cmbProducts.DisplayMember = "Name";
            cmbProducts.ValueMember = "Id";
            cmbProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;

            this.lblCurrentStock.Text = "Select a product to view stock";
            this.lblCurrentStock.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            this.lblCurrentStock.ForeColor = System.Drawing.Color.Gray;
            this.lblCurrentStock.Location = new System.Drawing.Point(35, 175);
            this.lblCurrentStock.AutoSize = true;

            AddInput(pnlForm, "MOVEMENT QUANTITY", txtQuantity, 1);
            
            System.Windows.Forms.Label lblType = new System.Windows.Forms.Label { Text = "ADJUSTMENT DIRECTION", Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.Gray, Location = new System.Drawing.Point(35, 290), AutoSize = true };
            rbStockIn.Text = "📥 STOCK IN"; rbStockIn.Location = new System.Drawing.Point(40, 315); rbStockIn.Checked = true; rbStockIn.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold); rbStockIn.ForeColor = System.Drawing.Color.FromArgb(46, 204, 113); rbStockIn.AutoSize = true;
            rbStockOut.Text = "📤 STOCK OUT"; rbStockOut.Location = new System.Drawing.Point(180, 315); rbStockOut.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold); rbStockOut.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60); rbStockOut.AutoSize = true;

            AddInput(pnlForm, "TRANSACTION NOTE / REASON", txtNote, 3);
            txtNote.PlaceholderText = "e.g., Damaged item, Restock, Return...";

            this.btnSubmit.Text = "EXECUTE ADJUSTMENT";
            this.btnSubmit.Location = new System.Drawing.Point(30, 520);
            this.btnSubmit.Size = new System.Drawing.Size(520, 60);
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            this.btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmit.Click += BtnSubmit_Click;

            this.lblMessage.Location = new System.Drawing.Point(30, 590);
            this.lblMessage.Size = new System.Drawing.Size(520, 30);
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Italic);

            pnlForm.Controls.AddRange(new System.Windows.Forms.Control[] { lblTitle, lblCurrentStock, lblType, rbStockIn, rbStockOut, btnSubmit, lblMessage });
            pnlCard.Controls.Add(pnlForm);
            pnlCard.Controls.Add(pnlInfo);
            this.Controls.Add(pnlCard);

            this.Resize += (s, e) => {
                pnlCard.Location = new System.Drawing.Point((this.ClientSize.Width - pnlCard.Width) / 2, (this.ClientSize.Height - pnlCard.Height) / 2);
            };
        }

        private void AddInput(System.Windows.Forms.Panel p, string label, System.Windows.Forms.Control ctrl, int index)
        {
            int baseTop = 100;
            int spacing = 95;
            if (index >= 3) baseTop += 40;

            System.Windows.Forms.Label l = new System.Windows.Forms.Label { Text = label, Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(127, 140, 141), Location = new System.Drawing.Point(30, baseTop + (index * spacing)), AutoSize = true };
            if (ctrl is System.Windows.Forms.TextBox txt) {
                System.Windows.Forms.Panel pnl = DashboardForm.StyleTextBox(txt);
                pnl.Location = new System.Drawing.Point(30, baseTop + 22 + (index * spacing));
                pnl.Width = 520;
                p.Controls.Add(pnl);
            } else {
                ctrl.Location = new System.Drawing.Point(30, baseTop + 22 + (index * spacing));
                ctrl.Width = 520;
                ctrl.Font = new System.Drawing.Font("Segoe UI", 11);
                p.Controls.Add(ctrl);
            }
            p.Controls.Add(l);
        }
    }
}
