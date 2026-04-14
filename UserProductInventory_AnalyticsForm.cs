using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using LiveChartsCore;
using LiveChartsCore.VisualStates;

using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;



namespace Fuentes_PrelimsP2
{
    //need further polishing for this one.

    public partial class UserProductInventory_AnalyticsForm : Form
    {
        private CartesianChart dataChart;
        private static UserProductInventory_AnalyticsForm instance;
        public UserProductInventory_AnalyticsForm()
        {
            InitializeComponent();
            fetch_data_from_database();
        }

        internal static UserProductInventory_AnalyticsForm Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new UserProductInventory_AnalyticsForm();
                }
                return instance;
            }
        }


        private void fetch_data_from_database()
        {
            string connection = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

            List<string> productName = new List<string>();
            List<double> quantities = new List<double>();

            using (OleDbConnection reader = new OleDbConnection(connection))
            {

                string query = "SELECT [Product Name], [Quantity in Kilograms] FROM [User PI Product Inventory]";
                OleDbCommand command = new OleDbCommand(query, reader);

                try
                {
                    reader.Open();
                    OleDbDataReader scanner = command.ExecuteReader();

                    while (scanner.Read())
                    {
                        productName.Add(scanner["Product Name"].ToString());
                        quantities.Add(Convert.ToDouble(scanner["Quantity in Kilograms"]));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching data: " + ex.Message);
                }
            }

            if (quantities.Count > 0) UpdateCharts(productName, quantities);
        }

        private void UpdateCharts(List<string> productName, List<double> quantities)
        {
            var barChart = new CartesianChart
            {
                Dock = DockStyle.Fill,

                Series = new ISeries[]
                {
                    new ColumnSeries<double>
                    {
                        Name = "Current Stock Level (Kg)",
                        Values = quantities.ToArray(),
                        Fill = new SolidColorPaint(SKColors.ForestGreen.WithAlpha(150))
                    },

                },

                XAxes = new Axis[]
                    {
                        new Axis
                        {
                            Labels = productName.ToArray(),
                            LabelsRotation = 30

                        }
                    }
            };

            var pieSeries = new List<ISeries>();
            for(int a = 0; a < productName.Count; a++)
            {
                pieSeries.Add(new PieSeries<double>
                {
                    Name = productName[a],
                    Values = new double[] { quantities[a] },
                });
            }

            var pieChart = new PieChart
            {
                Dock = DockStyle.Fill,
                Series = pieSeries.ToArray(),
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Right
            };


            display_bargraph_panel.Controls.Clear();
            display_bargraph_panel.Controls.Add(barChart);

            display_piechart_panel.Controls.Clear();
            display_piechart_panel.Controls.Add(pieChart);
        }
    }
}
