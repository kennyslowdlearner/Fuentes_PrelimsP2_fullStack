using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
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
    public partial class Admin_TotalTransactionsAnalytics : Form
    {
        private static Admin_TotalTransactionsAnalytics instance;
        private PieChart productPieChart;
        private PieChart userProfilePieChart;
        private string dbPath = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Pananom Database\Prooject Pananom Data.accdb";

        public Admin_TotalTransactionsAnalytics()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeCharts();
            LoadAnalyticsData();
        }

        internal static Admin_TotalTransactionsAnalytics Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Admin_TotalTransactionsAnalytics();
                }
                return instance;
            }
        }

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;


        private void InitializeCharts()
        {
            // Adjust these RGB values to match your specific background image
            // Standard Forest Green is (34, 139, 34)
            Color pananomGreen = Color.FromArgb(34, 139, 34);

            // 1. Setup Product Chart Control
            productPieChart = new PieChart
            {
                Dock = DockStyle.Fill,
                // Match the chart background to your UI color
                BackColor = pananomGreen,
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Hidden,
                TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Top
            };

            // Ensure the panel behind the chart is the same color
            display_piechart1_tta.BackColor = pananomGreen;
            display_piechart1_tta.Controls.Clear();
            display_piechart1_tta.Controls.Add(productPieChart);

            // 2. Setup User Profile Chart Control
            userProfilePieChart = new PieChart
            {
                Dock = DockStyle.Fill,
                BackColor = pananomGreen,
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Hidden,
                TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Top
            };

            display_piechart2_tta.BackColor = pananomGreen;
            display_piechart2_tta.Controls.Clear();
            display_piechart2_tta.Controls.Add(userProfilePieChart);
        }

        private void LoadAnalyticsData()
        {
            using (OleDbConnection conn = new OleDbConnection(dbPath))
            {
                try
                {
                    conn.Open();
                    LoadProductSalesChart(conn);
                    LoadUserProfileSalesChart(conn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Analytics Error: " + ex.Message);
                }
            }
        }

        private void LoadProductSalesChart(OleDbConnection conn)
        {
            List<ISeries> seriesList = new List<ISeries>();
            string query = "SELECT [Rice Type], SUM([Quantity in Kilogram]) as TotalQty FROM [User T&T Transaction] GROUP BY [Rice Type]";
            OleDbCommand cmd = new OleDbCommand(query, conn);

            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string riceName = reader["Rice Type"].ToString();
                    double qtyKg = Convert.ToDouble(reader["TotalQty"]);
                    double estSacks = qtyKg / 50.0;

                    seriesList.Add(new PieSeries<double>
                    {
                        Name = riceName,
                        Values = new double[] { qtyKg },
                        ToolTipLabelFormatter = point =>
                            $"{point.Context.Series.Name}\n" +
                            $"Quantity: {point.Coordinate.PrimaryValue:N2} kg\n" +
                            $"Est. Sacks: {estSacks:N2} sacks\n" +
                            $"Share: {point.StackedValue.Share:P2}"
                    });
                }
            }
            productPieChart.Series = seriesList.ToArray();
        }

        private void LoadUserProfileSalesChart(OleDbConnection conn)
        {
            List<ISeries> seriesList = new List<ISeries>();

            // Query joining transactions with user accounts to get names and ranking
            string query = @"SELECT (U.[First Name] + ' ' + U.[Last Name]) as SellerName, 
                             SUM(T.[Quantity in Kilogram]) as TotalQty, 
                             SUM(T.[Price per Kilogram] * T.[Quantity in Kilogram]) as TotalIncome
                             FROM [User T&T Transaction] as T
                             INNER JOIN [User Account Information] as U ON T.[User ID] = U.[User ID]
                             GROUP BY U.[First Name], U.[Last Name]
                             ORDER BY SUM(T.[Price per Kilogram] * T.[Quantity in Kilogram]) DESC";

            DataTable dt = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
            adapter.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                string seller = row["SellerName"].ToString();
                double qty = Convert.ToDouble(row["TotalQty"]);
                double income = Convert.ToDouble(row["TotalIncome"]);
                int rank = i + 1; // Based on ORDER BY Income

                seriesList.Add(new PieSeries<double>
                {
                    Name = seller,
                    Values = new double[] { income }, // Chart based on PhP value
                    ToolTipLabelFormatter = point =>
                        $"Rank #{rank}: {point.Context.Series.Name}\n" +
                        $"Quantity Sold: {qty:N2} kg\n" +
                        $"Total Income: ₱{income:N2}\n" +
                        $"Market Share: {point.StackedValue.Share:P2}"
                });
            }
            userProfilePieChart.Series = seriesList.ToArray();
        }
    }
}
