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
                dataSet = new DataSet();
                adapter.Fill(dataSet, "User T&T Transaction");
                Total_Sales_Report_Grid.DataSource = dataSet.Tables["User T&T Transaction"];

                LoadDashboardStats(connection);

                connection.Close();

                Total_Sales_Report_Grid.DataSource = dataSet.Tables["User T&T Transaction"];

                if (Total_Sales_Report_Grid.Columns.Contains("Item Number"))
                    Total_Sales_Report_Grid.Columns["Item Number"].Visible = false;

                Total_Sales_Report_Grid.Columns["Customer Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Total_Sales_Report_Grid.Columns["Rice Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Total_Sales_Report_Grid.Columns["Product ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Total_Sales_Report_Grid.Columns["Price per Kilogram"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Total_Sales_Report_Grid.Columns["Quantity in Kilogram"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Total_Sales_Report_Grid.Columns["Delivery Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Total_Sales_Report_Grid.Columns["Reference ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Total_Sales_Report_Grid.Columns["User ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Total_Sales_Report_Grid.Columns["Destination"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Total_Sales_Report_Grid.Columns["Region"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

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
            // --- TOTAL REVENUE ---
            // Access uses brackets for spaces. Formula: Price * Quantity
            string revQuery = "SELECT SUM([Price per Kilogram] * [Quantity in Kilogram]) FROM [User T&T Transaction]";
            OleDbCommand cmdRev = new OleDbCommand(revQuery, conn);
            object revObj = cmdRev.ExecuteScalar();
            double totalRevenue = (revObj != null && revObj != DBNull.Value) ? Convert.ToDouble(revObj) : 0;

            // --- TOTAL COST ---
            // Pulling from your separate Cost of Production table
            string costQuery = "SELECT SUM([Amount]) FROM [User T&T Cost of Production]";
            OleDbCommand cmdCost = new OleDbCommand(costQuery, conn);
            object costObj = cmdCost.ExecuteScalar();
            double totalCost = (costObj != null && costObj != DBNull.Value) ? Convert.ToDouble(costObj) : 0;

            // --- CALCULATIONS ---
            double netProfit = totalRevenue - totalCost;

            string avgQuery = "SELECT AVG([Price per Kilogram] * [Quantity in Kilogram]) FROM [User T&T Transaction]";
            OleDbCommand cmdAvg = new OleDbCommand(avgQuery, conn);
            object avgObj = cmdAvg.ExecuteScalar();
            double avgValue = (avgObj != null && avgObj != DBNull.Value) ? Convert.ToDouble(avgObj) : 0;

            // --- UPDATE LABELS ---
            // Replace these names with your actual Label control names
            display_totalrevenue_tsr.Text = "₱" + totalRevenue.ToString("N2");
            display_totalcost_tsr.Text = "₱" + totalCost.ToString("N2");
            display_netprofit_tsr.Text = "₱" + netProfit.ToString("N2");
            display_atv_tsr.Text = "₱" + avgValue.ToString("N2");

            // --- TOP SELLING PRODUCTS ---
            try
            {
                LoadProductRankings(conn);
            }
            catch
            {
                // Ensure dashboard still shows revenue/cost even if rankings fail
                display_tspOne_tsr.Text = "N/A";
                display_tspTwo_tsr.Text = "N/A";
                display_tspThree_tsr.Text = "N/A";
                display_lspOne_tsr.Text = "N/A";
                display_lspTwo_tsr.Text = "N/A";
                display_lspThree_tsr.Text = "N/A";
            }
        }

        private void LoadProductRankings(OleDbConnection conn)
        {
            // Top 3 Products
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
                    if (rank == 1) display_tspOne_tsr.Text = "1. " + reader[0].ToString();
                    if (rank == 2) display_tspTwo_tsr.Text = "2. " + reader[0].ToString();
                    if (rank == 3) display_tspThree_tsr.Text = "3. " + reader[0].ToString();
                    rank++;
                }
            }

            // Low Selling (Switch DESC to ASC)
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
                    if (rank == 1) display_lspOne_tsr.Text = "1. " + reader[0].ToString();
                    if (rank == 2) display_lspTwo_tsr.Text = "2. " + reader[0].ToString();
                    if (rank == 3) display_lspThree_tsr.Text = "3. " + reader[0].ToString();
                    rank++;
                }
            }
        }
    }
}
