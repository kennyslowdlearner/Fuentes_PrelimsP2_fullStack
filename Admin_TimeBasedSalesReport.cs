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

                // 4. TOTAL ESTIMATED SACKS (Updated Suffix to 'sacks')
                string totalQtyQuery = "SELECT SUM([Quantity in Kilogram]) FROM [User T&T Transaction]";
                OleDbCommand cmdSum = new OleDbCommand(totalQtyQuery, conn);
                object totalQtyObj = cmdSum.ExecuteScalar();
                double totalKgs = (totalQtyObj != null && totalQtyObj != DBNull.Value) ? Convert.ToDouble(totalQtyObj) : 0;
                double totalSacks = totalKgs / 50.0;

                // Apply the new 'sacks' suffix
                display_es_gg.Text = totalSacks.ToString("N2") + " sacks";

                // 5. ECONOMIC RATING (Performance Rate)
                CalculateEconomicRating(conn);

                // --- UI STYLING & COLOR CORRECTION ---

                // Defining the Pananom Gold Theme
                Color solidGold = Color.FromArgb(255, 215, 0);
                var boldItalicFont = new Font(display_tt_tbsr.Font, FontStyle.Bold | FontStyle.Italic);

                // List of labels that must stay Gold and Bold/Italic
                Label[] goldLabels = {
            display_es_gg,
            display_tps_tbsr,
            display_lps_tbsr,
            display_pr_tbsr
        };

                foreach (Label lbl in goldLabels)
                {
                    lbl.Enabled = true;           // Force enabled to prevent gray-out effect
                    lbl.ForeColor = solidGold;    // Apply perfect gold color
                    lbl.Font = boldItalicFont;    // Apply Bold Italic style
                    lbl.BackColor = Color.Transparent;
                    lbl.Refresh();                // Force immediate UI redraw
                }
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

            // PROJECT PANANOM: Add Calculated Column for Estimated Sacks
            dataset.Columns.Add("Estimated Sacks", typeof(string));
            foreach (DataRow row in dataset.Rows)
            {
                if (row["Quantity in Kilogram"] != DBNull.Value)
                {
                    double kgs = Convert.ToDouble(row["Quantity in Kilogram"]);
                    double sacks = kgs / 50.0;
                    row["Estimated Sacks"] = sacks.ToString("N2") + " sck";
                }
            }

            grid.DataSource = dataset;

            // Header Text Formatting
            if (grid.Columns.Contains("Customer Name")) grid.Columns["Customer Name"].HeaderText = "Customer";
            if (grid.Columns.Contains("Rice Type")) grid.Columns["Rice Type"].HeaderText = "Rice Variety";
            if (grid.Columns.Contains("Quantity in Kilogram")) grid.Columns["Quantity in Kilogram"].HeaderText = "Qty (Kg)";

            // Layout and Visibility
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            grid.ScrollBars = ScrollBars.Both;

            if (grid.Columns.Contains("Item Number")) grid.Columns["Item Number"].Visible = false;
            if (grid.Columns.Contains("User ID")) grid.Columns["User ID"].Visible = false;
            if (grid.Columns.Contains("Product ID")) grid.Columns["Product ID"].Visible = false;

            // Position "Estimated Sacks" next to "Quantity in Kilogram"
            if (grid.Columns.Contains("Estimated Sacks") && grid.Columns.Contains("Quantity in Kilogram"))
            {
                grid.Columns["Estimated Sacks"].DisplayIndex = grid.Columns["Quantity in Kilogram"].DisplayIndex + 1;
                grid.Columns["Estimated Sacks"].HeaderText = "Est. Sacks (50kg)";
            }

            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.Width = 150; // Adjusted for better fit on Acer Swift SF314-54 screen
            }

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

            // Professional color palette for the Pananom Dashboard
            var colors = new[] {
        SKColors.LimeGreen, SKColors.DodgerBlue, SKColors.OrangeRed,
        SKColors.MediumPurple, SKColors.Gold, SKColors.DeepPink, SKColors.Cyan
    };

            using (OleDbConnection conn = new OleDbConnection(dbPath))
            {
                try
                {
                    conn.Open();
                    DataTable dataDt = new DataTable();
                    using (OleDbDataAdapter da = new OleDbDataAdapter(sqlQuery, conn)) { da.Fill(dataDt); }

                    if (dataDt.Rows.Count == 0)
                    {
                        targetPanel.Controls.Clear();
                        targetPanel.Controls.Add(new Label
                        {
                            Text = "No data found for this period.",
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleCenter,
                            ForeColor = Color.White,
                            Font = new Font("Segoe UI", 12, FontStyle.Italic)
                        });
                        return;
                    }

                    double grandTotal = dataDt.AsEnumerable().Sum(r => Convert.ToDouble(r["TotalQty"]));
                    int colorIndex = 0;

                    foreach (DataRow row in dataDt.Rows)
                    {
                        string type = row["Rice Type"].ToString();
                        double totalQty = Convert.ToDouble(row["TotalQty"]);
                        double percentage = (totalQty / grandTotal);

                        // Project Pananom Logic: Calculate estimated sacks (50kg per sack)
                        double estimatedSacks = totalQty / 50.0;

                        allSeries.Add(new ColumnSeries<double>
                        {
                            Values = new double[] { totalQty },
                            Name = type,
                            Stroke = new SolidColorPaint(colors[colorIndex % colors.Length]) { StrokeThickness = 2 },
                            Fill = new SolidColorPaint(colors[colorIndex % colors.Length].WithAlpha(180)),
                            Padding = 25,

                            // CUSTOM TOOLTIP: Shows Name, Kg, Sacks, and Percentage
                            XToolTipLabelFormatter = point => $"{type}",
                            YToolTipLabelFormatter = point =>
                                $"Available: {totalQty:N2} kg\n" +
                                $"Est. Sacks: {estimatedSacks:N2} (50kg/ea)\n" +
                                $"Share: {percentage:P1}"
                        });
                        colorIndex++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Analytics Error: " + ex.Message);
                    return;
                }
            }

            // Initialize the Chart with Precision Zooming and Magnetic Tooltips
            var chart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart
            {
                Series = allSeries,

                // Axis Styling for White/Green Theme
                XAxes = new Axis[] {
            new Axis {
                Name = xAxisName,
                Labels = new string[] { "Rice Varieties" },
                LabelsPaint = new SolidColorPaint(SKColors.White),
                NamePaint = new SolidColorPaint(SKColors.White),
                MinLimit = 0
            }
        },
                YAxes = new Axis[] {
            new Axis {
                Name = "Total Quantity (kg)",
                Labeler = v => $"{v:N0} kg",
                LabelsPaint = new SolidColorPaint(SKColors.White),
                NamePaint = new SolidColorPaint(SKColors.White)
            }
        },

                // SMOOTH ZOOMING & NAVIGATION
                ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X,
                ZoomingSpeed = 0.1, // Controlled zoom for laptop touchpads/mice

                // MAGNETIC HOVER: Automatically snaps to the closest bar
                FindingStrategy = LiveChartsCore.Measure.FindingStrategy.CompareAllTakeClosest,

                // TOOLTIP STYLING
                TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Top,
                TooltipBackgroundPaint = new SolidColorPaint(new SKColor(35, 35, 35, 230)),
                TooltipTextPaint = new SolidColorPaint(SKColors.White),

                // Layout
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };

            // Ensure the chart receives focus for immediate mouse-wheel zooming
            chart.MouseEnter += (s, e) => { chart.Focus(); };

            targetPanel.Controls.Clear();
            targetPanel.Controls.Add(chart);
        }
    }
}

