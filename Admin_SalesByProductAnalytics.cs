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
    public partial class Admin_SalesByProductAnalytics : Form
    {
        private static Admin_SalesByProductAnalytics instance;
        private PieChart salesPieChart;

        public Admin_SalesByProductAnalytics()
        {
            InitializeComponent();

            // Still good to keep for standard control rendering
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializePieChart();
            FetchSalesData();
        }
        internal static Admin_SalesByProductAnalytics Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Admin_SalesByProductAnalytics();
                }
                return instance;
            }
        }

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;

        private void InitializePieChart()
        {
            // Set the specific Green color to match your Project Pananom theme
            // Adjust the (R, G, B) values if your background green is different
            Color pananomGreen = Color.FromArgb(118, 186, 27);

            salesPieChart = new PieChart
            {
                Dock = DockStyle.Fill,
                InitialRotation = 0,
                MaxAngle = 360,

                // Explicitly set the Chart background to Green
                BackColor = pananomGreen,

                LegendPosition = LiveChartsCore.Measure.LegendPosition.Hidden,
                TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Top
            };

            // Match the display panel background to the chart and theme
            display_piechart_sbpa.BackColor = pananomGreen;
            display_piechart_sbpa.Controls.Clear();
            display_piechart_sbpa.Controls.Add(salesPieChart);
        }

        private void FetchSalesData()
        {
            string dbPath = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Pananom Database\Prooject Pananom Data.accdb";
            List<ISeries> seriesList = new List<ISeries>();

            using (OleDbConnection conn = new OleDbConnection(dbPath))
            {
                // Sourced from [User T&T Transaction] table
                string query = "SELECT [Rice Type], SUM([Quantity in Kilogram]) as TotalQty FROM [User T&T Transaction] GROUP BY [Rice Type]";
                OleDbCommand cmd = new OleDbCommand(query, conn);

                try
                {
                    conn.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string riceName = reader["Rice Type"].ToString();
                        double qtyKg = Convert.ToDouble(reader["TotalQty"]);

                        // Maintains the 50kg per sack standard
                        double estSacks = qtyKg / 50.0;

                        seriesList.Add(new PieSeries<double>
                        {
                            Name = riceName,
                            Values = new double[] { qtyKg },
                            // Multiline tooltip showing Name, kg, Est. Sacks, and Percentage
                            ToolTipLabelFormatter = point =>
                                $"{point.Context.Series.Name}\n" +
                                $"Quantity: {point.Coordinate.PrimaryValue:N2} kg\n" +
                                $"Est. Sacks: {estSacks:N2} sacks\n" +
                                $"Share: {point.StackedValue.Share:P2}"
                        });
                    }

                    salesPieChart.Series = seriesList.ToArray();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Analytics Error: " + ex.Message);
                }
            }
        }
    }
}


