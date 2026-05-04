namespace StockFlow.Forms
{
    partial class ProductEntryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cmbCategory, cmbSupplier;
        private System.Windows.Forms.NumericUpDown numPrice, numQuantity;
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
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();

            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(500, 600);

            // --- Header ---
            System.Windows.Forms.Panel pnlHeader = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Top, Height = 70, BackColor = System.Drawing.Color.FromArgb(44, 62, 80) };
            System.Windows.Forms.Label lblTitle = new System.Windows.Forms.Label { 
                Text = _product == null ? "ADD NEW PRODUCT" : "EDIT PRODUCT", 
                Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold), 
                ForeColor = System.Drawing.Color.White, 
                Location = new System.Drawing.Point(25, 23), 
                AutoSize = true 
            };
            pnlHeader.Controls.Add(lblTitle);

            // --- Content ---
            System.Windows.Forms.Panel pnlContent = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Fill, Padding = new System.Windows.Forms.Padding(40) };
            
            AddInput(pnlContent, "PRODUCT NAME", txtName, 0);
            AddInput(pnlContent, "CATEGORY", cmbCategory, 1);
            AddInput(pnlContent, "SUPPLIER", cmbSupplier, 2);
            AddInput(pnlContent, "UNIT PRICE", numPrice, 3);
            AddInput(pnlContent, "INITIAL STOCK", numQuantity, 4);

            this.numPrice.Maximum = 1000000; this.numPrice.DecimalPlaces = 2;
            this.numQuantity.Maximum = 1000000;
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            // --- Actions ---
            System.Windows.Forms.Panel pnlActions = new System.Windows.Forms.Panel { Dock = System.Windows.Forms.DockStyle.Bottom, Height = 80, BackColor = System.Drawing.Color.FromArgb(248, 249, 249) };
            
            StyleButton(btnSave, "SAVE CHANGES", System.Drawing.Color.FromArgb(46, 204, 113), true);
            btnSave.Location = new System.Drawing.Point(260, 15);
            btnSave.Click += BtnSave_Click;

            StyleButton(btnCancel, "CANCEL", System.Drawing.Color.FromArgb(189, 195, 199), false);
            btnCancel.Location = new System.Drawing.Point(130, 15);
            btnCancel.Click += (s, e) => this.Close();

            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMessage.Height = 30;
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 8);

            pnlActions.Controls.AddRange(new System.Windows.Forms.Control[] { btnSave, btnCancel });
            this.Controls.AddRange(new System.Windows.Forms.Control[] { pnlContent, pnlHeader, pnlActions, lblMessage });
        }

        private void StyleButton(System.Windows.Forms.Button btn, string text, System.Drawing.Color color, bool primary)
        {
            btn.Text = text; btn.Size = new System.Drawing.Size(120, 45); 
            btn.BackColor = color; btn.ForeColor = primary ? System.Drawing.Color.White : System.Drawing.Color.FromArgb(44, 62, 80);
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0; 
            btn.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold); btn.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void AddInput(System.Windows.Forms.Panel p, string label, System.Windows.Forms.Control ctrl, int index)
        {
            System.Windows.Forms.Label l = new System.Windows.Forms.Label { Text = label, Font = new System.Drawing.Font("Segoe UI", 8, System.Drawing.FontStyle.Bold), ForeColor = System.Drawing.Color.FromArgb(127, 140, 141), Location = new System.Drawing.Point(40, 40 + (index * 75)), AutoSize = true };
            
            if (ctrl is System.Windows.Forms.TextBox txt)
            {
                System.Windows.Forms.Panel pnl = DashboardForm.StyleTextBox(txt);
                pnl.Location = new System.Drawing.Point(40, 62 + (index * 75));
                pnl.Width = 420;
                p.Controls.Add(pnl);
            }
            else
            {
                ctrl.Location = new System.Drawing.Point(40, 62 + (index * 75));
                ctrl.Width = 420;
                ctrl.Font = new System.Drawing.Font("Segoe UI", 11);
                if (ctrl is System.Windows.Forms.ComboBox c) { c.FlatStyle = System.Windows.Forms.FlatStyle.Flat; }
                p.Controls.Add(ctrl);
            }
            p.Controls.Add(l);
        }
    }
}
