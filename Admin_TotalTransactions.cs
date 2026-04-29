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
    public partial class Admin_TotalTransactions : Form
    {
        private static Admin_TotalTransactions instance;
        public Admin_TotalTransactions()
        {
            InitializeComponent();
            auto_reload();
            LoadGlobalPerformanceStats();
        }

        internal static Admin_TotalTransactions Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Admin_TotalTransactions();
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
            string connString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

            // This query pulls Customer Name first, and the Farmer (Seller) Name last.
            // It joins your Transaction table with your Account Information table.
            string query = @"SELECT T.[Customer Name], T.[Rice Type], T.[Price per Kilogram], 
                            T.[Quantity in Kilogram], T.[Date Made], T.[Reference ID], 
                            T.Destination, (U.[First Name] + ' ' + U.[Last Name]) as [Seller Name]
                     FROM [User T&T Transaction] as T
                     INNER JOIN [User Account Information] as U ON T.[User ID] = U.[User ID]
                     ORDER BY T.[Date Made] DESC";

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                try
                {
                    conn.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    Total_Transactions_Grid.DataSource = dt;

                    // --- GRID FORMATTING ---

                    // 1. Enable Scrolling
                    Total_Transactions_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    Total_Transactions_Grid.ScrollBars = ScrollBars.Both;

                    // 2. Set Row Height for readability
                    Total_Transactions_Grid.RowTemplate.Height = 40;

                    // 3. Set Base Column Width
                    foreach (DataGridViewColumn col in Total_Transactions_Grid.Columns)
                    {
                        col.Width = 180;
                    }

                    // 4. Specific Column Adjustments
                    if (Total_Transactions_Grid.Columns.Contains("Reference ID"))
                    {
                        Total_Transactions_Grid.Columns["Reference ID"].Width = 350;
                    }
                    if (Total_Transactions_Grid.Columns.Contains("Destination"))
                    {
                        Total_Transactions_Grid.Columns["Destination"].Width = 450;
                    }
                    if (Total_Transactions_Grid.Columns.Contains("Customer Name"))
                    {
                        Total_Transactions_Grid.Columns["Customer Name"].Width = 220;
                    }

                    // 5. Currency Formatting
                    if (Total_Transactions_Grid.Columns.Contains("Price per Kilogram"))
                        Total_Transactions_Grid.Columns["Price per Kilogram"].DefaultCellStyle.Format = "₱#,##0.00";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading transactions: " + ex.Message);
                }
            }
        }

        private void LoadGlobalPerformanceStats()
        {
            string connString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                try
                {
                    conn.Open();

                    // 1. TOP PERFORMING SELLER
                    string topSellerQuery = @"SELECT TOP 1 A.[First Name] & ' ' & A.[Last Name] 
                                      FROM [User Account Information] AS A
                                      INNER JOIN [User T&T Transaction] AS T ON A.[User ID] = T.[User ID]
                                      GROUP BY A.[First Name], A.[Last Name] 
                                      ORDER BY SUM(T.[Price per Kilogram] * T.[Quantity in Kilogram]) DESC";

                    OleDbCommand cmdTop = new OleDbCommand(topSellerQuery, conn);
                    object topResult = cmdTop.ExecuteScalar();
                    display_tps_tt.Text = topResult != null ? topResult.ToString() : "N/A";

                    // 2. LOW PERFORMING SELLER
                    string lowSellerQuery = @"SELECT TOP 1 A.[First Name] & ' ' & A.[Last Name] 
                                      FROM [User Account Information] AS A
                                      INNER JOIN [User T&T Transaction] AS T ON A.[User ID] = T.[User ID]
                                      GROUP BY A.[First Name], A.[Last Name] 
                                      ORDER BY SUM(T.[Price per Kilogram] * T.[Quantity in Kilogram]) ASC";

                    OleDbCommand cmdLow = new OleDbCommand(lowSellerQuery, conn);
                    object lowResult = cmdLow.ExecuteScalar();
                    display_lps_tt.Text = lowResult != null ? lowResult.ToString() : "N/A";

                    // 3. TOTAL TRANSACTIONS
                    string countQuery = "SELECT COUNT(*) FROM [User T&T Transaction]";
                    OleDbCommand cmdCount = new OleDbCommand(countQuery, conn);
                    display_tt_tt.Text = cmdCount.ExecuteScalar().ToString();

                    // 4. PERFORMANCE RATE (%)
                    // Access fix: Using a subquery because COUNT(DISTINCT) is not supported
                    string totalUsersQuery = "SELECT COUNT(*) FROM [User Account Information]";
                    string activeSellersQuery = "SELECT COUNT(*) FROM (SELECT DISTINCT [User ID] FROM [User T&T Transaction])";

                    OleDbCommand cmdTotalU = new OleDbCommand(totalUsersQuery, conn);
                    OleDbCommand cmdActiveU = new OleDbCommand(activeSellersQuery, conn);

                    double totalUsers = Convert.ToDouble(cmdTotalU.ExecuteScalar() ?? 0);
                    double activeSellers = Convert.ToDouble(cmdActiveU.ExecuteScalar() ?? 0);

                    if (totalUsers > 0)
                    {
                        double rate = (activeSellers / totalUsers) * 100;
                        display_pr_tt.Text = rate.ToString("N2") + "%";
                    }
                    else
                    {
                        display_pr_tt.Text = "0.00%";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading performance stats: " + ex.Message);
                }
            } // conn is closed and disposed here automatically
        }

        private void press_search(object sender, EventArgs e)
        {
            FilterAllGlobalTransactions(fill_search_tt.Text);
        }

        private void FilterAllGlobalTransactions(string searchText)
        {
            // Clean the search text to prevent SQL injection/errors with apostrophes
            string filterValue = searchText.Replace("'", "''");

            // This expression searches through the Seller Name, Rice Type, Reference ID, and Destination
            string filterExpression = string.Format(
                "([Customer Name] LIKE '%{0}%') OR " +
                "([Rice Type] LIKE '%{0}%') OR " +
                "([Reference ID] LIKE '%{0}%') OR " +
                "([Destination] LIKE '%{0}%') OR " +
                "([Seller Name] LIKE '%{0}%')",
                filterValue);

            try
            {
                if (Total_Transactions_Grid.DataSource is DataTable dt)
                {
                    dt.DefaultView.RowFilter = filterExpression;

                    // Visual Feedback: Turn search bar MistyRose if no results are found
                    if (dt.DefaultView.Count == 0 && !string.IsNullOrEmpty(searchText))
                    {
                        fill_search_tt.BackColor = Color.MistyRose;
                    }
                    else
                    {
                        fill_search_tt.BackColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                // Helpful for debugging if a column name is misspelled
                Console.WriteLine("Filter Error: " + ex.Message);
            }
        }
    }
}
