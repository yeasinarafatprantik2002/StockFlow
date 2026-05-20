using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using StockFlow.Data;
using StockFlow.Models;
using StockFlow.Utilities;
using StockFlow.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace StockFlow.Forms
{
    public partial class DashboardForm : Form
    {
        private User? _currentUser;
        private Form? _activeForm = null;

        // Fields are now in DashboardForm.Designer.cs

        public DashboardForm()
        {
            InitializeComponent();
            ConfigureDashboard();
            LoadDesignerPreview();
        }

        public DashboardForm(User user)
        {
            _currentUser = user;
            InitializeComponent();
            ConfigureDashboard();
            LoadDashboardStats();
        }

        private void DgvLowStock_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.CellStyle == null)
            {
                return;
            }

            if (dgvLowStock.Columns[e.ColumnIndex].Name == "Stock" && e.Value != null)
            {
                int stock = (int)e.Value;
                if (stock <= 5)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Orange;
                }
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
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = headerColor;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(44, 62, 80);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 245, 251);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(41, 128, 185);
            dgv.DefaultCellStyle.Padding = new Padding(15, 0, 0, 0);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 245, 251);
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(41, 128, 185);
            dgv.GridColor = Color.FromArgb(235, 235, 235);

            dgv.DataBindingComplete -= Grid_DataBindingComplete;
            dgv.DataBindingComplete += Grid_DataBindingComplete;
        }

        private static void Grid_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (sender is DataGridView grid)
            {
                grid.ClearSelection();
                grid.CurrentCell = null;
            }
        }

        public static Panel StyleTextBox(TextBox txt)
        {
            Panel pnl = new Panel
            {
                BackColor = Color.White,
                Padding = new Padding(10, 8, 10, 8),
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size(txt.Width, txt.Height + 16)
            };
            txt.BorderStyle = BorderStyle.None;
            txt.Dock = DockStyle.Fill;
            txt.Font = new Font("Segoe UI", 11);
            pnl.Controls.Add(txt);

            return pnl;
        }

        private void AddMenuItem(ToolStripMenuItem item, string text, EventHandler onClick)
        {
            item.Text = text;
            item.ForeColor = Color.White;
            item.Click += onClick;
            this.menuStrip.Items.Add(item);
        }

        private void ConfigureDashboard()
        {
            menuStrip.Items.Clear();
            pnlStats.Controls.Clear();

            bool isRuntime = _currentUser != null;
            bool isManagement = _currentUser?.Role == "SuperAdmin" || _currentUser?.Role == "Admin";
            bool showAllForDesigner = !isRuntime;

            AddMenuItem(productsMenu, "  📦 Products  ", isRuntime ? ProductsMenu_Click : EmptyMenu_Click);
            AddMenuItem(categoriesMenu, "  📂 Categories  ", isRuntime ? CategoriesMenu_Click : EmptyMenu_Click);

            if (isManagement || showAllForDesigner)
            {
                AddMenuItem(suppliersMenu, "  🚚 Suppliers  ", isRuntime ? SuppliersMenu_Click : EmptyMenu_Click);
            }

            if (_currentUser?.Role != "PartTimeStaff")
            {
                AddMenuItem(salesMenu, "  💰 Sales  ", isRuntime ? SalesMenu_Click : EmptyMenu_Click);
            }

            stockMenu.Text = "  📦 Inventory  ";
            stockMenu.ForeColor = Color.White;
            stockMenu.DropDownItems.Clear();

            var stockInItem = new ToolStripMenuItem("Stock Adjustment") { Visible = isManagement || showAllForDesigner };
            stockInItem.Click += isRuntime ? StockAdjustmentMenu_Click : EmptyMenu_Click;
            var ledgerItem = new ToolStripMenuItem("Movement History");
            ledgerItem.Click += isRuntime ? StockLedgerMenu_Click : EmptyMenu_Click;
            stockMenu.DropDownItems.AddRange(new ToolStripItem[] { stockInItem, ledgerItem });
            menuStrip.Items.Add(stockMenu);

            if (isManagement || showAllForDesigner)
            {
                AddMenuItem(reportsMenu, "  📊 Reports  ", isRuntime ? ReportsMenu_Click : EmptyMenu_Click);
                AddMenuItem(new ToolStripMenuItem(), "  👥 Users  ", isRuntime ? UsersMenu_Click : EmptyMenu_Click);
            }

            logoutMenu.Text = "  🔒 Logout  ";
            logoutMenu.Alignment = ToolStripItemAlignment.Right;
            logoutMenu.ForeColor = Color.FromArgb(231, 76, 60);
            logoutMenu.Click += LogoutMenu_Click;
            menuStrip.Items.Add(logoutMenu);

            if (_currentUser != null && _currentUser.Role == "SuperAdmin")
            {
                pnlHeader.BackColor = Color.FromArgb(44, 62, 80);
            }
            else if (_currentUser != null && _currentUser.Role == "Admin")
            {
                pnlHeader.BackColor = Color.FromArgb(22, 160, 133);
            }
            else
            {
                pnlHeader.BackColor = Color.FromArgb(52, 152, 219);
            }

            lblWelcome.Text = _currentUser != null ? $"Welcome, {_currentUser.Username}!" : "Welcome, User";
            string displayRole;
            if (_currentUser == null)
            {
                displayRole = "User";
            }
            else if (_currentUser.Role == "PartTimeStaff")
            {
                displayRole = "Part-Time Staff";
            }
            else if (_currentUser.Role == "PermanentStaff")
            {
                displayRole = "Permanent Staff";
            }
            else
            {
                displayRole = _currentUser.Role;
            }
            lblSubtitle.Text = $"{displayRole} Portal  •  {DateTime.Now:dddd, MMM dd, yyyy}";

            if (!isRuntime)
            {
                AddStatCard("📦 Products", "128", Color.FromArgb(52, 152, 219));
                AddStatCard("⚠️ Low Stock", "9", Color.FromArgb(231, 76, 60));
                AddStatCard("📂 Categories", "14", Color.FromArgb(155, 89, 182));
                AddStatCard("💰 Total Sales", "342", Color.FromArgb(46, 204, 113));
                AddStatCard("🚚 Suppliers", "18", Color.FromArgb(230, 126, 34));
            }
        }

        private void OpenChildForm(Form childForm)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
            }

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
            if (_activeForm != null)
            {
                _activeForm.Close();
                _activeForm = null;
            }
            pnlDashboardHome.Visible = true;
            btnBack.Visible = false;
            lblWelcome.Visible = true;
            lblSubtitle.Location = new Point(40, 95);
            lblSubtitle.Text = $"{_currentUser?.Role ?? "User"} Portal  •  {DateTime.Now:dddd, MMM dd, yyyy}";
            LoadDashboardStats();
        }

        private void ProductsMenu_Click(object? sender, EventArgs e)
        {
            if (_currentUser != null)
            {
                OpenChildForm(new ProductForm(_currentUser));
            }
        }

        private void CategoriesMenu_Click(object? sender, EventArgs e)
        {
            if (_currentUser != null)
            {
                OpenChildForm(new CategoryForm(_currentUser));
            }
        }

        private void SuppliersMenu_Click(object? sender, EventArgs e)
        {
            if (_currentUser != null)
            {
                OpenChildForm(new SupplierForm(_currentUser));
            }
        }

        private void SalesMenu_Click(object? sender, EventArgs e)
        {
            if (_currentUser != null)
            {
                OpenChildForm(new SalesForm(_currentUser));
            }
        }

        private void StockAdjustmentMenu_Click(object? sender, EventArgs e)
        {
            if (_currentUser != null)
            {
                OpenChildForm(new StockManagementForm(_currentUser));
            }
        }

        private void StockLedgerMenu_Click(object? sender, EventArgs e)
        {
            OpenChildForm(new StockLedgerForm());
        }

        private void ReportsMenu_Click(object? sender, EventArgs e)
        {
            if (_currentUser != null)
            {
                OpenChildForm(new ReportsForm(_currentUser));
            }
        }

        private void UsersMenu_Click(object? sender, EventArgs e)
        {
            if (_currentUser != null)
            {
                OpenChildForm(new UserForm(_currentUser));
            }
        }

        private void LogoutMenu_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnBack_Click(object? sender, EventArgs e)
        {
            CloseChildForm();
        }

        private void EmptyMenu_Click(object? sender, EventArgs e)
        {
        }

        private async void LoadDashboardStats()
        {
            try
            {
                using (AppDbContext context = new AppDbContext())
                {
                    int totalProducts = await context.Products.CountAsync();
                    List<Product> products = await context.Products
                        .Include("Category")
                        .Include("Supplier")
                        .ToListAsync();

                    int lowStockCount = 0;
                    List<object> lowStockItems = new List<object>();
                    foreach (Product product in products)
                    {
                        if (product.Quantity < 10)
                        {
                            lowStockCount++;

                            string categoryName = "";
                            if (product.Category != null)
                            {
                                categoryName = product.Category.Name;
                            }

                            string supplierName = "";
                            if (product.Supplier != null)
                            {
                                supplierName = product.Supplier.Name;
                            }

                            lowStockItems.Add(new
                            {
                                Product = product.Name,
                                Stock = product.Quantity,
                                Category = categoryName,
                                Supplier = supplierName
                            });
                        }
                    }

                    int totalCategories = await context.Categories.CountAsync();

                    pnlStats.Controls.Clear();
                    AddStatCard("📦 Products", totalProducts.ToString(), Color.FromArgb(52, 152, 219));
                    AddStatCard("⚠️ Low Stock", lowStockCount.ToString(), Color.FromArgb(231, 76, 60));
                    AddStatCard("📂 Categories", totalCategories.ToString(), Color.FromArgb(155, 89, 182));

                    if (_currentUser?.Role == "SuperAdmin" || _currentUser?.Role == "Admin")
                    {
                        int totalSales = await context.Sales.CountAsync();
                        int totalSuppliers = await context.Suppliers.CountAsync();
                        AddStatCard("💰 Total Sales", totalSales.ToString(), Color.FromArgb(46, 204, 113));
                        AddStatCard("🚚 Suppliers", totalSuppliers.ToString(), Color.FromArgb(230, 126, 34));
                        if (_currentUser?.Role == "SuperAdmin")
                        {
                            List<Sale> sales = await context.Sales.ToListAsync();
                            decimal revenue = 0;
                            foreach (Sale sale in sales)
                            {
                                revenue += sale.TotalAmount;
                            }
                            AddStatCard("💵 Total Revenue", $"${revenue:N0}", Color.FromArgb(241, 196, 15));
                        }
                    }

                    dgvLowStock.DataSource = lowStockItems;
                    DesignModeHelper.ClearGridSelection(dgvLowStock);
                }
            }
            catch { }
        }

        private void LoadDesignerPreview()
        {
            if (!DesignModeHelper.IsActive)
            {
                return;
            }

            dgvLowStock.DataSource = new[]
            {
                new { Product = "USB-C Cable", Stock = 8, Category = "Cables", Supplier = "Metro Traders" },
                new { Product = "Keyboard", Stock = 0, Category = "Accessories", Supplier = "Prime Wholesale" },
                new { Product = "Barcode Scanner", Stock = 4, Category = "Electronics", Supplier = "North Supply Co." }
            };
            DesignModeHelper.ClearGridSelection(dgvLowStock);
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

        private void pnlStats_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public class DashboardMenuRenderer : ToolStripProfessionalRenderer
    {
        public DashboardMenuRenderer() : base(new DashboardColorTable())
        {
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Enabled)
            {
                return;
            }

            if (!e.Item.Selected && !e.Item.Pressed)
            {
                return;
            }

            bool isTopMenuItem = false;
            if (e.Item.Owner is MenuStrip)
            {
                isTopMenuItem = true;
            }

            if (isTopMenuItem)
            {
                RenderTopMenuHover(e);
            }
            else
            {
                RenderDropDownMenuHover(e);
            }
        }

        private void RenderTopMenuHover(ToolStripItemRenderEventArgs e)
        {
            Rectangle itemRectangle = new Rectangle(Point.Empty, e.Item.Size);
            itemRectangle.Inflate(-8, -5);

            int accentTop = e.Item.Height - 5;
            Rectangle accentLine = new Rectangle(itemRectangle.Left, accentTop, itemRectangle.Width, 3);
            using (SolidBrush accentBrush = new SolidBrush(Color.FromArgb(52, 152, 219)))
            {
                e.Graphics.FillRectangle(accentBrush, accentLine);
            }
        }

        private void RenderDropDownMenuHover(ToolStripItemRenderEventArgs e)
        {
            Rectangle itemRectangle = new Rectangle(Point.Empty, e.Item.Size);
            itemRectangle.Inflate(-2, -1);

            using (SolidBrush brush = new SolidBrush(Color.FromArgb(245, 249, 252)))
            {
                e.Graphics.FillRectangle(brush, itemRectangle);
            }

            Rectangle accentLine = new Rectangle(itemRectangle.Left, itemRectangle.Top, 3, itemRectangle.Height);
            using (SolidBrush accentBrush = new SolidBrush(Color.FromArgb(52, 152, 219)))
            {
                e.Graphics.FillRectangle(accentBrush, accentLine);
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.Item.Owner is MenuStrip)
            {
                if (e.Item.Selected || e.Item.Pressed)
                {
                    e.TextColor = Color.FromArgb(230, 245, 255);
                }
                else
                {
                    e.TextColor = Color.White;
                }
            }
            else
            {
                e.TextColor = Color.FromArgb(44, 62, 80);
            }

            base.OnRenderItemText(e);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            if (e.Item != null && e.Item.Owner is MenuStrip)
            {
                e.ArrowColor = Color.White;
            }
            else
            {
                e.ArrowColor = Color.FromArgb(44, 62, 80);
            }
            base.OnRenderArrow(e);
        }

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(220, 225, 230)))
            {
                e.Graphics.DrawLine(pen, 10, 3, e.Item.Width - 10, 3);
            }
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
        }
    }

    public class DashboardColorTable : ProfessionalColorTable
    {
        public override Color MenuStripGradientBegin
        {
            get
            {
                return Color.FromArgb(44, 62, 80);
            }
        }

        public override Color MenuStripGradientEnd
        {
            get
            {
                return Color.FromArgb(44, 62, 80);
            }
        }

        public override Color MenuBorder
        {
            get
            {
                return Color.FromArgb(44, 62, 80);
            }
        }

        public override Color MenuItemBorder
        {
            get
            {
                return Color.Transparent;
            }
        }

        public override Color MenuItemSelected
        {
            get
            {
                return Color.FromArgb(52, 73, 94);
            }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return Color.FromArgb(52, 73, 94);
            }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return Color.FromArgb(52, 73, 94);
            }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get
            {
                return Color.FromArgb(44, 62, 80);
            }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get
            {
                return Color.FromArgb(44, 62, 80);
            }
        }

        public override Color ToolStripDropDownBackground
        {
            get
            {
                return Color.White;
            }
        }

        public override Color ImageMarginGradientBegin
        {
            get
            {
                return Color.White;
            }
        }

        public override Color ImageMarginGradientEnd
        {
            get
            {
                return Color.White;
            }
        }

        public override Color SeparatorDark
        {
            get
            {
                return Color.FromArgb(220, 225, 230);
            }
        }

        public override Color ToolStripBorder
        {
            get
            {
                return Color.FromArgb(220, 225, 230);
            }
        }
    }
}
