using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.Defaults; 
using SkiaSharp;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class Admin_TimeBasedSalesReport : Form
    {
        private static Admin_TimeBasedSalesReport instance;
        public Admin_TimeBasedSalesReport()
        {
            InitializeComponent();
            LoadTables();
        }

        internal static Admin_TimeBasedSalesReport Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Admin_TimeBasedSalesReport();
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

        private void press_switchview(object sender, EventArgs e)
        {
            // Toggle the state
            bool showAnalytics = Per_Week_Grid.Visible;

            // Swap Visibility
            Per_Week_Grid.Visible = !showAnalytics;
            Per_Month_Grid.Visible = !showAnalytics;
            Per_Year_Grid.Visible = !showAnalytics;

            display_perweek_analytics.Visible = showAnalytics;
            display_permonth_analytics.Visible = showAnalytics;
            display_peryear_analytics.Visible = showAnalytics;

            if (showAnalytics)
            {
                LoadLiveCharts();
            }
        }

        
        private void LoadTables()
        {
            string connString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                try
                {
                    conn.Open();

                    // 1. Weekly Table (Last 7 Days)
                    string weekQuery = "SELECT * FROM [User T&T Transaction] WHERE [Date Made] >= Date() - 7 ORDER BY [Date Made] DESC";
                    FillGrid(Per_Week_Grid, weekQuery, conn);

                    // 2. Monthly Table (Current Calendar Month)
                    string monthQuery = "SELECT * FROM [User T&T Transaction] WHERE MONTH([Date Made]) = MONTH(Date()) AND YEAR([Date Made]) = YEAR(Date()) ORDER BY [Date Made] DESC";
                    FillGrid(Per_Month_Grid, monthQuery, conn);

                    // 3. Yearly Table (Current Calendar Year)
                    string yearQuery = "SELECT * FROM [User T&T Transaction] WHERE YEAR([Date Made]) = YEAR(Date()) ORDER BY [Date Made] DESC";
                    FillGrid(Per_Year_Grid, yearQuery, conn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading tables: " + ex.Message);
                }
            }

            // Call the labels method (we need to add this back to this form)
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                LoadSellerPerformance(conn);
            }

            // Add this at the very end of your LoadTables() method
            Per_Week_Grid.Visible = true;
            Per_Month_Grid.Visible = true;
            Per_Year_Grid.Visible = true;

            // Force them to the top layer
            Per_Week_Grid.BringToFront();
            Per_Month_Grid.BringToFront();
            Per_Year_Grid.BringToFront();

            display_perweek_analytics.Visible = false;
            display_permonth_analytics.Visible = false;
            display_peryear_analytics.Visible = false;
        }

        private void LoadSellerPerformance(OleDbConnection conn)
        {
            try
            {
                // 1. TOP SOLD RICE (Based on Quantity)
                string topRiceQuery = @"SELECT TOP 1 [Rice Type] 
                                FROM [User T&T Transaction] 
                                GROUP BY [Rice Type] 
                                ORDER BY SUM([Quantity in Kilogram]) DESC";
                OleDbCommand cmdTop = new OleDbCommand(topRiceQuery, conn);
                object topRice = cmdTop.ExecuteScalar();
                display_tps_tbsr.Text = topRice != null ? topRice.ToString() : "None";

                // 2. LEAST SOLD RICE
                string lowRiceQuery = @"SELECT TOP 1 [Rice Type] 
                               FROM [User T&T Transaction] 
                               GROUP BY [Rice Type] 
                               ORDER BY SUM([Quantity in Kilogram]) ASC";
                OleDbCommand cmdLow = new OleDbCommand(lowRiceQuery, conn);
                object lowRice = cmdLow.ExecuteScalar();
                display_lps_tbsr.Text = lowRice != null ? lowRice.ToString() : "None";

                // 3. OVERALL TRANSACTIONS
                string totalTransQuery = "SELECT COUNT(*) FROM [User T&T Transaction]";
                OleDbCommand cmdCount = new OleDbCommand(totalTransQuery, conn);
                display_tt_tbsr.Text = cmdCount.ExecuteScalar().ToString();

                // 4. ECONOMIC RATING (Performance Rate)
                CalculateEconomicRating(conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stats Error: " + ex.Message);
            }
        }

        private void CalculateEconomicRating(OleDbConnection conn)
        {
            // Logic: How much the Top Rice type contributes to the total volume sold
            string sumAllQty = "SELECT SUM([Quantity in Kilogram]) FROM [User T&T Transaction]";
            string sumTopQty = @"SELECT TOP 1 SUM([Quantity in Kilogram]) 
                         FROM [User T&T Transaction] 
                         GROUP BY [Rice Type] 
                         ORDER BY SUM([Quantity in Kilogram]) DESC";

            OleDbCommand cmdAll = new OleDbCommand(sumAllQty, conn);
            OleDbCommand cmdTop = new OleDbCommand(sumTopQty, conn);

            double totalQty = Convert.ToDouble(cmdAll.ExecuteScalar() ?? 0);
            double topQty = Convert.ToDouble(cmdTop.ExecuteScalar() ?? 0);

            if (totalQty > 0)
            {
                double rating = (topQty / totalQty) * 100;
                display_pr_tbsr.Text = rating.ToString("N2") + "%";
            }
            else
            {
                display_pr_tbsr.Text = "0.00%";
            }
        }


        private void FillGrid(DataGridView grid, string query, OleDbConnection conn)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            DataTable dataset = new DataTable();
            adapter.Fill(dataset);
            grid.DataSource = dataset;

            // Add this inside FillGrid after setting the DataSource
            if (grid.Columns.Contains("Customer Name")) grid.Columns["Customer Name"].HeaderText = "Customer";
            if (grid.Columns.Contains("Rice Type")) grid.Columns["Rice Type"].HeaderText = "Rice Variety";
            if (grid.Columns.Contains("Quantity in Kilogram")) grid.Columns["Quantity in Kilogram"].HeaderText = "Qty (Kg)";

            // 1. Enable Horizontal Scrollbars by allowing columns to be wider than the grid
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            grid.ScrollBars = ScrollBars.Both;

            // 2. Hide the Item Number column (Assuming the column name is "Item Number")
            if (grid.Columns.Contains("Item Number"))
            {
                grid.Columns["Item Number"].Visible = false;
            }

            // 3. Optional: Hide other technical columns to keep it clean
            if (grid.Columns.Contains("User ID")) grid.Columns["User ID"].Visible = false;
            if (grid.Columns.Contains("Product ID")) grid.Columns["Product ID"].Visible = false;

            // 4. Set a manual width for the important columns so they "spread out"
            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.Width = 300; // Adjust this number until it feels right
            }

            // 5. Formatting for currency
            if (grid.Columns.Contains("Price per Kilogram"))
                grid.Columns["Price per Kilogram"].DefaultCellStyle.Format = "₱#,##0.00";
        }

        private void FilterAllGrids(string searchText)
        {
            // Clean the search text to prevent errors with special characters
            string filterValue = searchText.Replace("'", "''");

            // Define the filter string for Customer Name OR Rice Type
            // The '%' acts as a wildcard (e.g., "Rice" will find "White Rice", "Brown Rice", etc.)
            string filterExpression = string.Format("[Customer Name] LIKE '%{0}%' OR [Rice Type] LIKE '%{0}%' OR [Reference ID] LIKE '%{0}%' OR [Destination] LIKE '%{0}%'", filterValue);

            try
            {
                // 1. Filter Weekly Grid
                if (Per_Week_Grid.DataSource is DataTable dtWeek)
                {
                    dtWeek.DefaultView.RowFilter = filterExpression;
                }

                // 2. Filter Monthly Grid
                if (Per_Month_Grid.DataSource is DataTable dtMonth)
                {
                    dtMonth.DefaultView.RowFilter = filterExpression;
                }

                // 3. Filter Yearly Grid
                if (Per_Year_Grid.DataSource is DataTable dtYear)
                {
                    dtYear.DefaultView.RowFilter = filterExpression;
                }
            }
            catch (Exception ex)
            {
                // If a column name is misspelled, this will catch it
                Console.WriteLine("Filter Error: " + ex.Message);
            }
        }

        private void press_search(object sender, EventArgs e)
        {
            FilterAllGrids(fill_search_tbsr.Text);
      
            // 1. First, run the filter method you created
            FilterAllGrids(fill_search_tbsr.Text);

            // 2. Then, provide the visual feedback
            // We check the Week grid as the indicator, but you could check all three
            if (Per_Week_Grid.Rows.Count == 0 && !string.IsNullOrEmpty(fill_search_tbsr.Text))
            {
                // Turns light red if no results match the search
                fill_search_tbsr.BackColor = Color.MistyRose;
            }
            else
            {
                // Stays white if there are results or if the search bar is empty
                fill_search_tbsr.BackColor = Color.White;
            }
        }

        private void LoadLiveCharts()
        {
            // Total per Rice Type for the Last 7 Days
            string weekQuery = "SELECT [Rice Type], SUM([Quantity in Kilogram]) as TotalQty FROM [User T&T Transaction] WHERE [Date Made] >= Date()-7 GROUP BY [Rice Type]";

            // Total per Rice Type for the Current Month
            string monthQuery = "SELECT [Rice Type], SUM([Quantity in Kilogram]) as TotalQty FROM [User T&T Transaction] WHERE MONTH([Date Made]) = MONTH(Date()) AND YEAR([Date Made]) = YEAR(Date()) GROUP BY [Rice Type]";

            // Total per Rice Type from the Very Beginning (Overall Progress)
            string yearQuery = "SELECT [Rice Type], SUM([Quantity in Kilogram]) as TotalQty FROM [User T&T Transaction] GROUP BY [Rice Type]";

            CreateRiceTypeBarGraph(display_perweek_analytics, weekQuery, "Weekly Performance");
            CreateRiceTypeBarGraph(display_permonth_analytics, monthQuery, "Monthly Performance");
            CreateRiceTypeBarGraph(display_peryear_analytics, yearQuery, "Overall Progress");
        }

        private void CreateRiceTypeBarGraph(Panel targetPanel, string sqlQuery, string xAxisName)
        {
            string dbPath = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

            var allSeries = new List<ISeries>();
            var riceNames = new List<string>();

            // Professional color palette
            var colors = new[] { SKColors.LimeGreen, SKColors.DodgerBlue, SKColors.OrangeRed, SKColors.MediumPurple, SKColors.Gold, SKColors.DeepPink, SKColors.Cyan };

            using (OleDbConnection conn = new OleDbConnection(dbPath))
            {
                try
                {
                    conn.Open();

                    // 1. Load the aggregated data (Total Qty per Rice Type)
                    DataTable dataDt = new DataTable();
                    using (OleDbDataAdapter da = new OleDbDataAdapter(sqlQuery, conn))
                    {
                        da.Fill(dataDt);
                    }

                    int colorIndex = 0;
                    foreach (DataRow row in dataDt.Rows)
                    {
                        string type = row["Rice Type"].ToString();
                        double totalQty = Convert.ToDouble(row["TotalQty"]);

                        // We calculate percentage relative to the total of ALL rice in this view
                        double grandTotal = dataDt.AsEnumerable().Sum(r => Convert.ToDouble(r["TotalQty"]));
                        double percentage = (totalQty / grandTotal);

                        // Add each Rice Type as its own Series to get different colors
                        allSeries.Add(new ColumnSeries<double>
                        {
                            Values = new double[] { totalQty },
                            Name = type,
                            Stroke = new SolidColorPaint(colors[colorIndex % colors.Length]) { StrokeThickness = 2 },
                            Fill = new SolidColorPaint(colors[colorIndex % colors.Length].WithAlpha(200)),
                            Padding = 20,

                            // THE FIX: Modern LiveCharts2 Formatter Syntax
                            // This shows the Rice Type name
                            XToolTipLabelFormatter = point => $"{type}",

                            // This shows the Qty and the calculated Percentage Share
                            YToolTipLabelFormatter = point => $"Qty: {totalQty}kg ({percentage:P1})"
                        });

                        riceNames.Add(type);
                        colorIndex++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bar Graph Error: " + ex.Message);
                    return;
                }
            }

            // 2. Handle Empty State
            if (allSeries.Count == 0)
            {
                targetPanel.Controls.Clear();
                Label lbl = new Label { Text = "No data found.", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter };
                targetPanel.Controls.Add(lbl);
                return;
            }

            // 3. Render the Chart
            var chart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart
            {
                Series = allSeries,
                // The X-Axis shows the Varieties
                XAxes = new Axis[] {
            new Axis {
                Name = xAxisName,
                Labels = new string[] { "Varieties" }, // Grouped under one category or empty
                TextSize = 14
            }
        },
                YAxes = new Axis[] {
            new Axis {
                Name = "Total Sold (kg)",
                Labeler = v => $"{v}kg",
                TextSize = 14
            }
        },
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Hidden,
                TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Top,

                // Sizing for Scrollbars (150px per Rice Type bar)
                Width = Math.Max(targetPanel.Width - 10, allSeries.Count * 150),
                Height = Math.Max(100, targetPanel.Height - 30),
                Left = 0,
                Top = 0
            };

            targetPanel.AutoScroll = true;
            targetPanel.Controls.Clear();
            targetPanel.Controls.Add(chart);
        }
    }
}

