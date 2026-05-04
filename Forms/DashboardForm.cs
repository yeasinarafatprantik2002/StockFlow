using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using StockFlow.Data;
using StockFlow.Models;
using StockFlow.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace StockFlow.Forms
{
    public partial class DashboardForm : Form
    {
        private User _currentUser;
        private Form? _activeForm = null;

        // Fields are now in DashboardForm.Designer.cs

        public DashboardForm(User user)
        {
            _currentUser = user;
            InitializeComponent();
            LoadDashboardStats();
        }

        private void DgvLowStock_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLowStock.Columns[e.ColumnIndex].Name == "Stock" && e.Value != null)
            {
                int stock = (int)e.Value;
                if (stock <= 5) e.CellStyle.ForeColor = Color.Red;
                else e.CellStyle.ForeColor = Color.Orange;
                e.CellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            }
        }

        public static void StyleGrid(DataGridView dgv, Color headerColor)
        {
            dgv.Dock = DockStyle.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.EnableHeadersVisualStyles = false;
            dgv.RowTemplate.Height = 50;
            dgv.ReadOnly = true;

            dgv.ColumnHeadersHeight = 55;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 245, 251);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(41, 128, 185);
            dgv.DefaultCellStyle.Padding = new Padding(15, 0, 0, 0);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            dgv.GridColor = Color.FromArgb(235, 235, 235);
        }

        public static Panel StyleTextBox(TextBox txt)
        {
            Panel pnl = new Panel { 
                BackColor = Color.White, 
                Padding = new Padding(10, 8, 10, 8), 
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(txt.Width, txt.Height + 16)
            };
            txt.BorderStyle = BorderStyle.None;
            txt.Dock = DockStyle.Fill;
            txt.Font = new Font("Segoe UI", 11);
            pnl.Controls.Add(txt);
            
            txt.GotFocus += (s, e) => pnl.BorderStyle = BorderStyle.FixedSingle; // Can set color here
            return pnl;
        }

        private void AddMenuItem(ToolStripMenuItem item, string text, EventHandler onClick)
        {
            item.Text = text; item.ForeColor = Color.White; item.Click += onClick;
            this.menuStrip.Items.Add(item);
        }

        private void OpenChildForm(Form childForm)
        {
            if (_activeForm != null) _activeForm.Close();
            
            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            
            pnlViewPort.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
            
            pnlDashboardHome.Visible = false;
            btnBack.Visible = true;
            lblWelcome.Visible = false;
            lblSubtitle.Location = new Point(40, 65);
            lblSubtitle.Text = $"SYSTEM / {childForm.Text.ToUpper().Replace("STOCKFLOW ENTERPRISE - ", "")}";
        }

        private void CloseChildForm()
        {
            if (_activeForm != null) { _activeForm.Close(); _activeForm = null; }
            pnlDashboardHome.Visible = true;
            btnBack.Visible = false;
            lblWelcome.Visible = true;
            lblSubtitle.Location = new Point(40, 95);
            lblSubtitle.Text = $"{_currentUser.Role} Portal  •  {DateTime.Now:dddd, MMM dd, yyyy}";
            LoadDashboardStats();
        }

        private async void LoadDashboardStats()
        {
            try {
                using var context = new AppDbContext();
                int totalProducts = await context.Products.CountAsync();
                int lowStockCount = await context.Products.CountAsync(p => p.Quantity < 10);
                int totalCategories = await context.Categories.CountAsync();

                pnlStats.Controls.Clear();
                AddStatCard("📦 Products", totalProducts.ToString(), Color.FromArgb(52, 152, 219));
                AddStatCard("⚠️ Low Stock", lowStockCount.ToString(), Color.FromArgb(231, 76, 60));
                AddStatCard("📂 Categories", totalCategories.ToString(), Color.FromArgb(155, 89, 182));

                if (_currentUser.Role == "SuperAdmin" || _currentUser.Role == "Admin") {
                    int totalSales = await context.Sales.CountAsync();
                    int totalSuppliers = await context.Suppliers.CountAsync();
                    AddStatCard("💰 Total Sales", totalSales.ToString(), Color.FromArgb(46, 204, 113));
                    AddStatCard("🚚 Suppliers", totalSuppliers.ToString(), Color.FromArgb(230, 126, 34));
                    if (_currentUser.Role == "SuperAdmin") {
                        decimal revenue = await context.Sales.SumAsync(s => (decimal?)s.TotalAmount) ?? 0;
                        AddStatCard("💵 Total Revenue", $"${revenue:N0}", Color.FromArgb(241, 196, 15));
                    }
                }

                var lowStockItems = await context.Products.Include(p => p.Category).Include(p => p.Supplier).Where(p => p.Quantity < 10).Select(p => new { Product = p.Name, Stock = p.Quantity, Category = p.Category.Name, Supplier = p.Supplier.Name }).ToListAsync();
                dgvLowStock.DataSource = lowStockItems;
            } catch { }
        }

        private void AddStatCard(string title, string value, Color color)
        {
            Panel card = new Panel { Size = new Size(260, 140), BackColor = Color.White, Margin = new Padding(0, 0, 30, 0) };
            Panel accent = new Panel { Dock = DockStyle.Left, Width = 8, BackColor = color };
            Label lblT = new Label { Text = title, Font = new Font("Segoe UI", 11), ForeColor = Color.Gray, Location = new Point(25, 25), AutoSize = true };
            Label lblV = new Label { Text = value, Font = new Font("Segoe UI", 30, FontStyle.Bold), ForeColor = Color.FromArgb(44, 62, 80), Location = new Point(22, 55), AutoSize = true };
            card.Controls.AddRange(new Control[] { accent, lblT, lblV });
            pnlStats.Controls.Add(card);
        }
    }

    public class DashboardMenuRenderer : ToolStripProfessionalRenderer
    {
        public DashboardMenuRenderer() : base(new DashboardColorTable()) { }
        
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e) {
            if (e.Item.Enabled) {
                if (e.Item.Selected || e.Item.Pressed) {
                    Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(52, 73, 94))) e.Graphics.FillRectangle(brush, rc);
                }
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e) {
            e.TextColor = Color.White;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e) {
            using (Pen pen = new Pen(Color.FromArgb(64, 82, 100))) e.Graphics.DrawLine(pen, 10, 3, e.Item.Width - 10, 3);
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) { }
    }

    public class DashboardColorTable : ProfessionalColorTable
    {
        public override Color MenuStripGradientBegin => Color.FromArgb(44, 62, 80);
        public override Color MenuStripGradientEnd => Color.FromArgb(44, 62, 80);
        public override Color MenuBorder => Color.FromArgb(44, 62, 80); // Match background
        public override Color MenuItemBorder => Color.Transparent;
        public override Color MenuItemSelected => Color.FromArgb(52, 73, 94);
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(52, 73, 94);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(52, 73, 94);
        public override Color MenuItemPressedGradientBegin => Color.FromArgb(44, 62, 80);
        public override Color MenuItemPressedGradientEnd => Color.FromArgb(44, 62, 80);
        public override Color ToolStripDropDownBackground => Color.FromArgb(44, 62, 80);
        public override Color ImageMarginGradientBegin => Color.FromArgb(44, 62, 80);
        public override Color ImageMarginGradientEnd => Color.FromArgb(44, 62, 80);
        public override Color SeparatorDark => Color.FromArgb(64, 82, 100);
        public override Color ToolStripBorder => Color.FromArgb(64, 82, 100);
    }
}
