using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class Admin_SalesByProduct : Form
    {
        private static Admin_SalesByProduct instance;
        public Admin_SalesByProduct()
        {
            InitializeComponent();
            auto_reload();
        }

        internal static Admin_SalesByProduct Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Admin_SalesByProduct();
                }

                return instance;
            }
        }

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;

        private void backButton(object sender, EventArgs e)
        {
            try
            {
                AdminSalesReport.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void auto_reload()
        {
            string dbPath = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";
            connection = new OleDbConnection(dbPath);

            // Grid Query: Grouped by Rice Type and calculates sacks for each row
            string sql = @"SELECT [Rice Type], [Price per Kilogram], [Quantity in Kilogram], 
                          ([Quantity in Kilogram] / 50.0) AS [Estimated Sacks],
                          [Product ID], [Delivery Date], [Reference ID], 
                          [Destination], [Region], [Date Made], [User ID]
                   FROM [User T&T Transaction] 
                   ORDER BY [Rice Type] ASC, [Date Made] DESC";

            adapter = new OleDbDataAdapter(sql, connection);

            try
            {
                connection.Open();
                dataSet = new DataSet();
                adapter.Fill(dataSet, "SalesByProduct");

                // Load the analytics labels while the connection is open
                LoadAnalytics(connection);

                connection.Close();

                Sales_By_Product_Grid.DataSource = dataSet.Tables["SalesByProduct"];

                // Standard Grid Formatting
                Sales_By_Product_Grid.DefaultCellStyle.ForeColor = Color.Black;
                if (Sales_By_Product_Grid.Columns.Contains("Estimated Sacks"))
                {
                    Sales_By_Product_Grid.Columns["Estimated Sacks"].HeaderText = "Qty in Sacks (50kg)";
                    Sales_By_Product_Grid.Columns["Estimated Sacks"].DefaultCellStyle.Format = "N2";
                }

                foreach (DataGridViewColumn col in Sales_By_Product_Grid.Columns)
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load grouped sales data. Error: " + ex.Message);
            }
        }

        private void LoadAnalytics(OleDbConnection conn)
        {
            try
            {
                // 1. TOP SELLING PRODUCT (Highest Total Quantity Sold)
                string topQuery = "SELECT TOP 1 [Rice Type] FROM [User T&T Transaction] GROUP BY [Rice Type] ORDER BY SUM([Quantity in Kilogram]) DESC";
                OleDbCommand cmdTop = new OleDbCommand(topQuery, conn);
                display_tps_asp.Text = cmdTop.ExecuteScalar()?.ToString() ?? "N/A";

                // 2. LOWEST SELLING PRODUCT (Lowest Total Quantity Sold)
                string lowQuery = "SELECT TOP 1 [Rice Type] FROM [User T&T Transaction] GROUP BY [Rice Type] ORDER BY SUM([Quantity in Kilogram]) ASC";
                OleDbCommand cmdLow = new OleDbCommand(lowQuery, conn);
                display_lsp_asp.Text = cmdLow.ExecuteScalar()?.ToString() ?? "N/A";

                // 3. LEAD TERRITORY (Most repeated destination)
                string territoryQuery = "SELECT TOP 1 [Destination] FROM [User T&T Transaction] GROUP BY [Destination] ORDER BY COUNT([Destination]) DESC";
                OleDbCommand cmdTerritory = new OleDbCommand(territoryQuery, conn);
                display_lr_asp.Text = cmdTerritory.ExecuteScalar()?.ToString() ?? "N/A";

                // 4. TOTAL QUANTITY (Kilograms and Sacks)
                string totalQtyQuery = "SELECT SUM([Quantity in Kilogram]) FROM [User T&T Transaction]";
                OleDbCommand cmdTotal = new OleDbCommand(totalQtyQuery, conn);
                object totalResult = cmdTotal.ExecuteScalar();
                double totalKg = (totalResult != null && totalResult != DBNull.Value) ? Convert.ToDouble(totalResult) : 0;
                double totalSacks = totalKg / 50.0;

                // Display totals with formatting
                display_kg_gg.Text = totalKg.ToString("N2") + " kg";
                display_es_gg.Text = totalSacks.ToString("N2") + " sacks";

                // 5. IMPROVEMENT RATE (Economic Rating)
                // Calculated as: (Top Product Vol / Total Vol) * 100
                string topQtyQuery = "SELECT TOP 1 SUM([Quantity in Kilogram]) FROM [User T&T Transaction] GROUP BY [Rice Type] ORDER BY SUM([Quantity in Kilogram]) DESC";
                OleDbCommand cmdTopQty = new OleDbCommand(topQtyQuery, conn);
                double topQty = Convert.ToDouble(cmdTopQty.ExecuteScalar() ?? 0);

                double improvementRate = (totalKg > 0) ? (topQty / totalKg) * 100 : 0;
                display_ir_asp.Text = improvementRate.ToString("N2") + "%";

                // --- Apply Gold Bold Italic Styling ---
                ApplyDashboardStyle(new Label[] { display_tps_asp, display_lsp_asp, display_ir_asp, display_lr_asp, display_kg_gg, display_es_gg });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Analytics Error: " + ex.Message);
            }
        }

        private void ApplyDashboardStyle(Label[] labels)
        {
            var boldItalicFont = new Font(labels[0].Font, FontStyle.Bold | FontStyle.Italic);
            Color solidGold = Color.FromArgb(255, 215, 0);

            foreach (var lbl in labels)
            {
                lbl.Font = boldItalicFont;
                lbl.ForeColor = solidGold;
                lbl.Enabled = true;
                lbl.Refresh();
            }
        }

        private void press_search(object sender, EventArgs e)
        {
            string connect = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

            string query = "SELECT * FROM [User T&T Transaction] WHERE [Customer Name] LIKE @S1 OR [Rice Type] LIKE @S2 OR [Reference ID] LIKE @S3 OR [Rice Type] LIKE @S4 OR [Product ID] LIKE @S5 OR [Destination] LIKE @S6 OR [Region] LIKE @S7";


            if (string.IsNullOrWhiteSpace(fill_search_sbp.Text))
            {
                auto_reload();
                return;
            }

            using (OleDbConnection connected = new OleDbConnection(connect))
            {
                OleDbDataAdapter searchAdapter = new OleDbDataAdapter(query, connected);

                string searchTerm = "%" + fill_search_sbp.Text + "%";
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S1", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S2", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S3", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S4", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S5", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S6", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S7", searchTerm);

                DataSet searchNow = new DataSet();

                try
                {
                    connected.Open();
                    searchAdapter.Fill(searchNow, "User T&T Transaction");

                    Sales_By_Product_Grid.DataSource = searchNow.Tables["User T&T Transaction"];
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Search failed. Error: " + ex.Message);
                }
            }
        }

      
    }
}
