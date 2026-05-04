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
    public partial class Admin_TotalSalesReport : Form
    {
        private static Admin_TotalSalesReport instance;
        public Admin_TotalSalesReport()
        {
            InitializeComponent();
            auto_reload();
        }

        internal static Admin_TotalSalesReport Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Admin_TotalSalesReport();
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
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");

            try
            {
                connection.Open();

                adapter = new OleDbDataAdapter("SELECT * FROM [User T&T Transaction]", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // 1. Calculate the Estimated Sacks Column (50kg per sack)
                dt.Columns.Add("Estimated Sacks", typeof(string));
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Quantity in Kilogram"] != DBNull.Value)
                    {
                        double kgs = Convert.ToDouble(row["Quantity in Kilogram"]);
                        double sacks = kgs / 50.0;
                        // Updated suffix from "sck" to "sacks"
                        row["Estimated Sacks"] = sacks.ToString("N2") + " sacks";
                    }
                }

                // 2. Bind the data to your grid
                Total_Sales_Report_Grid.DataSource = dt;

                // 3. Update Dashboard Labels
                LoadDashboardStats(connection);

                connection.Close();

                // 4. Grid Formatting for the 14-inch display
                if (Total_Sales_Report_Grid.Columns.Contains("Item Number"))
                    Total_Sales_Report_Grid.Columns["Item Number"].Visible = false;

                if (Total_Sales_Report_Grid.Columns.Contains("Estimated Sacks"))
                {
                    Total_Sales_Report_Grid.Columns["Estimated Sacks"].DisplayIndex = Total_Sales_Report_Grid.Columns["Quantity in Kilogram"].DisplayIndex + 1;
                }

                string[] columnsToSize = { "Customer Name", "Rice Type", "Product ID", "Price per Kilogram",
                                   "Quantity in Kilogram", "Estimated Sacks", "Delivery Date",
                                   "Reference ID", "User ID", "Destination", "Region" };

                foreach (string col in columnsToSize)
                {
                    if (Total_Sales_Report_Grid.Columns.Contains(col))
                        Total_Sales_Report_Grid.Columns[col].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }

        private void press_search(object sender, EventArgs e)
        {
            string connect = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

            string query = "SELECT * FROM [User T&T Transaction] WHERE [Customer Name] LIKE @S1 OR [Reference ID] LIKE @S3 OR [Rice Type] LIKE @S4 OR [Product ID] LIKE @S5 OR [Destination] LIKE @S6 OR [Region] LIKE @S7";


            if (string.IsNullOrWhiteSpace(fill_search_tsr.Text))
            {
                auto_reload();
                return;
            }

            using (OleDbConnection connected = new OleDbConnection(connect))
            {
                OleDbDataAdapter searchAdapter = new OleDbDataAdapter(query, connected);

                string searchTerm = "%" + fill_search_tsr.Text + "%";
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S1", searchTerm);
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

                    Total_Sales_Report_Grid.DataSource = searchNow.Tables["User T&T Transaction"];
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Search failed. Error: " + ex.Message);
                }
            }
        }

        private void LoadDashboardStats(OleDbConnection conn)
        {
            // 1. Core Calculations
            string revQuery = "SELECT SUM([Price per Kilogram] * [Quantity in Kilogram]) FROM [User T&T Transaction]";
            OleDbCommand cmdRev = new OleDbCommand(revQuery, conn);
            double totalRevenue = Convert.ToDouble(cmdRev.ExecuteScalar() != DBNull.Value ? cmdRev.ExecuteScalar() : 0);

            string costQuery = "SELECT SUM([Total]) FROM [User T&T Cost of Production]";
            OleDbCommand cmdCost = new OleDbCommand(costQuery, conn);
            double totalCost = Convert.ToDouble(cmdCost.ExecuteScalar() != DBNull.Value ? cmdCost.ExecuteScalar() : 0);

            string sackQuery = "SELECT SUM([Quantity in Kilogram]) FROM [User T&T Transaction]";
            OleDbCommand cmdSack = new OleDbCommand(sackQuery, conn);
            double totalKgs = Convert.ToDouble(cmdSack.ExecuteScalar() != DBNull.Value ? cmdSack.ExecuteScalar() : 0);
            double totalSacks = totalKgs / 50.0;

            double netProfit = totalRevenue - totalCost;
            double growthPercent = CalculateSalesGrowth(conn);

            // 2. Styling Definitions
            var boldItalicFont = new Font(display_totalrevenue_tsr.Font, FontStyle.Bold | FontStyle.Italic);
            Color solidGold = Color.FromArgb(255, 215, 0);

            // 3. Force Enabled State (Prevents the "Gray Out" effect)
            display_totalcost_tsr.Enabled = true;
            display_salesgrowth_tsr.Enabled = true;
            display_es_gg.Enabled = true;

            // 4. Set Values
            display_totalrevenue_tsr.Text = "₱" + totalRevenue.ToString("N2");
            display_netprofit_tsr.Text = "₱" + netProfit.ToString("N2");
            display_atv_tsr.Text = "₱" + (totalRevenue / Math.Max(1, totalSacks)).ToString("N2");

            // Set Gold Values with "sacks" suffix
            display_totalcost_tsr.Text = "₱" + totalCost.ToString("N2");
            display_salesgrowth_tsr.Text = growthPercent.ToString("N2") + "%";
            display_es_gg.Text = totalSacks.ToString("N2") + " sacks"; // Updated to "sacks"

            // 5. Apply Color and Refresh
            Label[] goldLabels = { display_totalcost_tsr, display_salesgrowth_tsr, display_es_gg };
            Label[] standardLabels = { display_totalrevenue_tsr, display_netprofit_tsr, display_atv_tsr };

            foreach (var lbl in goldLabels)
            {
                lbl.Font = boldItalicFont;
                lbl.ForeColor = solidGold;
                lbl.BackColor = Color.Transparent;
                lbl.Refresh();
            }

            foreach (var lbl in standardLabels)
            {
                lbl.Font = boldItalicFont;
                lbl.Refresh();
            }

            try { LoadProductRankings(conn); } catch { }
        }

        private double CalculateSalesGrowth(OleDbConnection conn)
        {
            string currentQuery = "SELECT SUM([Price per Kilogram] * [Quantity in Kilogram]) FROM [User T&T Transaction] " +
                                  "WHERE [Delivery Date] > DateAdd('d', -30, Date())";

            string previousQuery = "SELECT SUM([Price per Kilogram] * [Quantity in Kilogram]) FROM [User T&T Transaction] " +
                                   "WHERE [Delivery Date] BETWEEN DateAdd('d', -60, Date()) AND DateAdd('d', -31, Date())";

            OleDbCommand cmdCurr = new OleDbCommand(currentQuery, conn);
            OleDbCommand cmdPrev = new OleDbCommand(previousQuery, conn);

            double currentSales = Convert.ToDouble(cmdCurr.ExecuteScalar() != DBNull.Value ? cmdCurr.ExecuteScalar() : 0);
            double previousSales = Convert.ToDouble(cmdPrev.ExecuteScalar() != DBNull.Value ? cmdPrev.ExecuteScalar() : 0);

            if (previousSales == 0) return currentSales > 0 ? 100 : 0;

            return ((currentSales - previousSales) / previousSales) * 100;
        }

        private void LoadProductRankings(OleDbConnection conn)
        {
            var boldItalicFont = new Font(display_tspOne_tsr.Font, FontStyle.Bold | FontStyle.Italic);

            Label[] rankingLabels = {
                                        display_tspOne_tsr, display_tspTwo_tsr, display_tspThree_tsr,
                                        display_lspOne_tsr, display_lspTwo_tsr, display_lspThree_tsr
                                    };

            foreach (var lbl in rankingLabels) lbl.Font = boldItalicFont;

            string topQuery = "SELECT TOP 3 [Rice Type] FROM [User T&T Transaction] GROUP BY [Rice Type] ORDER BY SUM([Quantity in Kilogram]) DESC";
            OleDbCommand cmdTop = new OleDbCommand(topQuery, conn);
            using (OleDbDataReader reader = cmdTop.ExecuteReader())
            {
                int rank = 1;
                if (!reader.HasRows)
                {
                    display_tspOne_tsr.Text = "N/A";
                    display_tspTwo_tsr.Text = "N/A";
                    display_tspThree_tsr.Text = "N/A";
                }
                while (reader.Read())
                {
                    if (rank == 1) display_tspOne_tsr.Text = reader[0].ToString();
                    if (rank == 2) display_tspTwo_tsr.Text = reader[0].ToString();
                    if (rank == 3) display_tspThree_tsr.Text = reader[0].ToString();
                    rank++;
                }
            }

            string lowQuery = "SELECT TOP 3 [Rice Type] FROM [User T&T Transaction] GROUP BY [Rice Type] ORDER BY SUM([Quantity in Kilogram]) ASC";
            OleDbCommand cmdLow = new OleDbCommand(lowQuery, conn);
            using (OleDbDataReader reader = cmdLow.ExecuteReader())
            {
                int rank = 1;
                if (!reader.HasRows)
                {
                    display_lspOne_tsr.Text = "N/A";
                    display_lspTwo_tsr.Text = "N/A";
                    display_lspThree_tsr.Text = "N/A";
                }
                while (reader.Read())
                {
                    if (rank == 1) display_lspOne_tsr.Text = reader[0].ToString();
                    if (rank == 2) display_lspTwo_tsr.Text = reader[0].ToString();
                    if (rank == 3) display_lspThree_tsr.Text = reader[0].ToString();
                    rank++;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Admin_TotalTransactionsAnalytics.Instance.Show();
        }
    }
}
