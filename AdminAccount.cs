using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data;

namespace Fuentes_PrelimsP2
{
    public partial class AdminAccount : Form
    {
        private string fontName = "Glacial Indifference";
        private static AdminAccount instance;
        public AdminAccount()
        {
            InitializeComponent();

            // ADD THIS LINE: It tells the grid to stop using Windows default theme colors
            Top_Selling_Product_Grid.EnableHeadersVisualStyles = false;
            Top_Seller_Grid.EnableHeadersVisualStyles = false;

            auto_reload();
            load_top_sellers();
        }

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;

        internal static AdminAccount Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new AdminAccount();
                }

                return instance;
            }


        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Homepageee homepage = new Homepageee();

            homepage.Show();

            this.Hide();
        }

        private void AdminAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void contactDeveloperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactUs contactDeveloper = new ContactUs();

            contactDeveloper.Show();

        }

        private void GoToTransportSchedule(object sender, EventArgs e)
        {
            try
            {
                AdminTransportSchedule.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Transport Schedule page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToAccountControl(object sender, EventArgs e)
        {
            try
            {
                AdminAccountControl.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Account Control page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void auto_reload()
        {
            try
            {
                connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");

                string query = "SELECT [Rice Type], SUM([Quantity in Kilogram]) AS TotalQuantity " +
                               "FROM [User T&T Transaction] " +
                               "GROUP BY [Rice Type] " +
                               "ORDER BY SUM([Quantity in Kilogram]) DESC";

                adapter = new OleDbDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                var rankedData = dt.AsEnumerable()
                    .Select((row, index) => new
                    {
                        Rank = index + 1,
                        Product = row.Field<string>("Rice Type"),
                        Quantity = Convert.ToDouble(row["TotalQuantity"])
                    }).ToList();

                Top_Selling_Product_Grid.DataSource = null;
                Top_Selling_Product_Grid.DataSource = rankedData;

                // --- GRID STYLING ---
                Top_Selling_Product_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                Top_Selling_Product_Grid.ScrollBars = ScrollBars.Both;
                Top_Selling_Product_Grid.RowHeadersVisible = false;
                Top_Selling_Product_Grid.AllowUserToAddRows = false;
                Top_Selling_Product_Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                Top_Selling_Product_Grid.CellBorderStyle = DataGridViewCellBorderStyle.None;

                if (Top_Selling_Product_Grid.Columns["Rank"] != null)
                {
                    Top_Selling_Product_Grid.Columns["Rank"].Width = 50;
                    Top_Selling_Product_Grid.Columns["Product"].Width = 180;
                    Top_Selling_Product_Grid.Columns["Quantity"].Width = 100;
                    Top_Selling_Product_Grid.Columns["Quantity"].HeaderText = "Qty (kg)";
                    Top_Selling_Product_Grid.Columns["Quantity"].DefaultCellStyle.Format = "N2";
                }

                Top_Selling_Product_Grid.ClearSelection();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            finally { connection?.Close(); }
        }

        // Helper method to keep your code clean
        private void ApplyRowStyle(DataGridViewRow row, Color color, FontStyle style, string fontName)
        {
            row.DefaultCellStyle.BackColor = color;
            row.DefaultCellStyle.ForeColor = Color.Black;
            // CRITICAL: This stops the blue highlight from hiding your color
            row.DefaultCellStyle.SelectionBackColor = color;
            row.DefaultCellStyle.SelectionForeColor = Color.Black;
            row.DefaultCellStyle.Font = new Font(fontName, 10, style);
        }

        internal void load_top_sellers()
        {
            try
            {
                connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");

                string query = @"SELECT U.[First Name], U.[Middle Name], U.[Last Name], 
                        SUM(T.[Quantity in Kilogram]) AS TotalSold, 
                        SUM(T.[Quantity in Kilogram] * T.[Price Per Kilogram]) AS TotalEarnings
                        FROM [User Account Information] AS U 
                        INNER JOIN [User T&T Transaction] AS T ON U.[User ID] = T.[User ID] 
                        GROUP BY U.[First Name], U.[Middle Name], U.[Last Name] 
                        ORDER BY SUM(T.[Quantity in Kilogram] * T.[Price Per Kilogram]) DESC";

                adapter = new OleDbDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                var rankedSellers = dt.AsEnumerable()
                    .Select((row, index) => new
                    {
                        Rank = index + 1,
                        Seller = $"{row.Field<string>("First Name")} {row.Field<string>("Middle Name")} {row.Field<string>("Last Name")}",
                        Quantity = Convert.ToDouble(row["TotalSold"]),
                        Earnings = Convert.ToDouble(row["TotalEarnings"])
                    }).ToList();

                Top_Seller_Grid.DataSource = null;
                Top_Seller_Grid.DataSource = rankedSellers;

                // --- GRID STYLING ---
                // CRITICAL: We use 'None' so we can set manual widths that trigger a scrollbar
                Top_Seller_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                Top_Seller_Grid.ScrollBars = ScrollBars.Both;
                Top_Seller_Grid.RowHeadersVisible = false;
                Top_Seller_Grid.CellBorderStyle = DataGridViewCellBorderStyle.None;
                Top_Seller_Grid.AllowUserToAddRows = false;
                Top_Seller_Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (Top_Seller_Grid.Columns["Rank"] != null)
                {
                    Top_Seller_Grid.Columns["Rank"].Width = 45;
                    Top_Seller_Grid.Columns["Seller"].Width = 180;
                    Top_Seller_Grid.Columns["Quantity"].Width = 90;
                    Top_Seller_Grid.Columns["Quantity"].HeaderText = "Qty (kg)";
                    Top_Seller_Grid.Columns["Quantity"].DefaultCellStyle.Format = "N2";
                    Top_Seller_Grid.Columns["Earnings"].Width = 110;
                    Top_Seller_Grid.Columns["Earnings"].HeaderText = "Earnings (PHP)";
                    Top_Seller_Grid.Columns["Earnings"].DefaultCellStyle.Format = "N2";
                }

                Top_Seller_Grid.ClearSelection();
            }
            catch (Exception ex) { MessageBox.Show("Error loading top sellers: " + ex.Message); }
            finally { connection?.Close(); }
        }

        private void Top_Selling_Product_Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ApplyPodiumFormatting(Top_Selling_Product_Grid, e);
        }

        private void Top_Seller_Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            ApplyPodiumFormatting(Top_Seller_Grid, e);
        }


        private void ApplyPodiumFormatting(DataGridView grid, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Standard for all rows: Black text
            e.CellStyle.ForeColor = Color.Black;
            e.CellStyle.SelectionForeColor = Color.Black;

            if (e.RowIndex == 0) // Gold
            {
                e.CellStyle.BackColor = Color.Gold;
                e.CellStyle.SelectionBackColor = Color.Gold; // Force highlight to be Gold too
                e.CellStyle.Font = new Font(fontName, 10, FontStyle.Bold);
            }
            else if (e.RowIndex == 1) // Silver
            {
                e.CellStyle.BackColor = Color.Silver;
                e.CellStyle.SelectionBackColor = Color.Silver;
                e.CellStyle.Font = new Font(fontName, 10, FontStyle.Bold);
            }
            else if (e.RowIndex == 2) // Bronze
            {
                e.CellStyle.BackColor = Color.SandyBrown;
                e.CellStyle.SelectionBackColor = Color.SandyBrown;
                e.CellStyle.Font = new Font(fontName, 10, FontStyle.Bold);
            }
            else
            {
                e.CellStyle.BackColor = Color.White;
                e.CellStyle.SelectionBackColor = Color.LightBlue; // Normal rows get blue highlight
            }
        }

        // When the mouse enters a cell
        private void Top_Selling_Product_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Increase row height (The "Zoom" feel)
                Top_Selling_Product_Grid.Rows[e.RowIndex].Height = 45;

                // Increase font size slightly
                Top_Selling_Product_Grid.Rows[e.RowIndex].DefaultCellStyle.Font =
                    new Font("Glacial Indifference", 12, FontStyle.Bold);
            }
        }

        // When the mouse leaves the cell, reset it
        private void Top_Selling_Product_Grid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Top_Selling_Product_Grid.Rows[e.RowIndex].Height = 22; // Default height

                // Reset to original font (Bold for Top 3, Regular for others)
                FontStyle style = (e.RowIndex <= 2) ? FontStyle.Bold : FontStyle.Regular;
                Top_Selling_Product_Grid.Rows[e.RowIndex].DefaultCellStyle.Font =
                    new Font("Glacial Indifference", 10, style);
            }
        }



        private void Top_Seller_Grid_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            HandleZoomEnter(Top_Seller_Grid, e);
        }

        private void Top_Seller_Grid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            HandleZoomLeave(Top_Seller_Grid, e);
        }

        // Use this for both grids (linked via Designer)
        private void HandleZoomEnter(DataGridView grid, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Smooth zoom effect
                grid.Rows[e.RowIndex].Height = 45;
                grid.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(fontName, 12, FontStyle.Bold);

                // Highlight the hovered row slightly differently to distinguish from the selection
                grid.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.LightCyan;
            }
        }

        private void HandleZoomLeave(DataGridView grid, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                grid.Rows[e.RowIndex].Height = 25; // Reset to your design-time height

                // Determine if this row should be Bold (Top 3) or Regular
                FontStyle style = (e.RowIndex <= 2) ? FontStyle.Bold : FontStyle.Regular;
                grid.Rows[e.RowIndex].DefaultCellStyle.Font = new Font(fontName, 10, style);

                // This is the "Secret Sauce": 
                // We trigger a refresh of the CellFormatting to make sure the Gold/Silver/Bronze colors 
                // don't disappear after the mouse leaves.
                grid.InvalidateRow(e.RowIndex);
            }
        }

        private void GoToSalesReport(object sender, EventArgs e)
        {
            try
            {
                AdminSalesReport.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Sales Report page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logoutAdmin(object sender, EventArgs e)
        {
            try
            {
                UserSession.reset();

                if (Admin_InventoryManagement.Instance != null) Admin_InventoryManagement.Instance.Dispose();
                if (Admin_SalesByProduct.Instance != null) Admin_SalesByProduct.Instance.Dispose();
                if (Admin_SalesbyUserProfile.Instance != null) Admin_SalesbyUserProfile.Instance.Dispose();
                if (Admin_TimeBasedSalesReport.Instance != null) Admin_TimeBasedSalesReport.Instance.Dispose();
                if (Admin_TotalSalesReport.Instance != null) Admin_TotalSalesReport.Instance.Dispose();
                if (Admin_TotalTransactions.Instance != null) Admin_TotalTransactions.Instance.Dispose();
                if (AdminAccount.Instance != null) AdminAccount.Instance.Dispose();
                if (AdminAccountControl.Instance != null) AdminAccountControl.Instance.Dispose();
                if (AdminSalesReport.Instance != null) AdminSalesReport.Instance.Dispose();
                if (AdminTransportSchedule.Instance != null) AdminTransportSchedule.Instance.Dispose();


                Homepageee.Instance.Show();
                this.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to logging out:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

         private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageUs.Instance.Show();
        }
    }
}
