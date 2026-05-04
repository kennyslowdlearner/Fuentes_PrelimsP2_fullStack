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
using System.Runtime.InteropServices.Marshalling;



namespace Fuentes_PrelimsP2
{
    //need further polishing for this one.

    public partial class UserProductInventory_Analytics : Form
    {
        private CartesianChart dataChart;
        private static UserProductInventory_Analytics instance;
        public UserProductInventory_Analytics()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            display_piechart_panel.BackColor = Color.Transparent;

            fetch_data_from_database();
        }

        internal static UserProductInventory_Analytics Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new UserProductInventory_Analytics();
                }
                else instance.fetch_data_from_database();
                return instance;
            }
        }


        private void fetch_data_from_database()
        {
            int currentUser = UserSession.UserInstance.ID;

            string connection = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

            List<string> productName = new List<string>();
            List<double> quantities = new List<double>();

            using (OleDbConnection reader = new OleDbConnection(connection))
            {

                string query = "SELECT [Product Name], [Quantity in Kilograms] FROM [User PI Product Inventory] WHERE [User ID] = ?";
                OleDbCommand command = new OleDbCommand(query, reader);

                command.Parameters.AddWithValue("?", currentUser);

                try
                {
                    reader.Open();
                    OleDbDataReader scanner = command.ExecuteReader();

                    while (scanner.Read())
                    {
                        productName.Add(scanner["Product Name"].ToString());
                        quantities.Add(Convert.ToDouble(scanner["Quantity in Kilograms"]));
                    }

                    double totalWeight = 0;
                    foreach (var q in quantities) totalWeight += q;

                    _ = summaryAnimation(totalWeight, productName.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching data: " + ex.Message);
                }
            }

            if (quantities.Count > 0) UpdateCharts(productName, quantities);
            else
            {
                display_bargraph_panel.Controls.Clear();
                display_piechart_panel.Controls.Clear();
                MessageBox.Show("No inventory data found on your content. Start adding products to see analytics.");
            }


        }

        private void UpdateCharts(List<string> productName, List<double> quantities)
        {
            double totalWeight = 0;
            foreach (var q in quantities) totalWeight += q;

            // --- BAR CHART (With Zoom & Animation) ---
            var barChart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Hidden,
                ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X,
                AnimationsSpeed = TimeSpan.FromMilliseconds(1000),
                EasingFunction = LiveChartsCore.EasingFunctions.ExponentialOut,

                Series = new ISeries[]
                {
            new ColumnSeries<double>
            {
                Name = "Stock Level",
                Values = quantities.ToArray(),
                Fill = new SolidColorPaint(SKColors.ForestGreen.WithAlpha(180)),
                // UPDATED TOOLTIP: Added Est. Sacks calculation (\n creates a new line)
                YToolTipLabelFormatter = point =>
                {
                    double val = point.Coordinate.PrimaryValue;
                    return $"{productName[(int)point.Index]}\n" +
                           $"Weight: {val:N2} kg\n" +
                           $"Est. Sacks: {(val / 50.0):N2} sacks\n" +
                           $"Share: {(val / totalWeight):P1}";
                }
            },
                },
                XAxes = new Axis[]
                {
            new Axis
            {
                Labels = productName.ToArray(),
                LabelsRotation = 15,
                TextSize = 10,
                MinLimit = 0,
                MaxLimit = productName.Count > 5 ? 4.5 : (double?)null
            }
                },
                YAxes = new Axis[]
                {
            new Axis
            {
                Labeler = value => $"{value}kg",
                TextSize = 10,
                MinLimit = 0
            }
                }
            };

            // --- PIE CHART (With Opening Animation) ---
            var pieSeries = new List<ISeries>();
            for (int a = 0; a < productName.Count; a++)
            {
                double currentVal = quantities[a];
                pieSeries.Add(new PieSeries<double>
                {
                    Name = productName[a],
                    Values = new double[] { currentVal },
                    // UPDATED TOOLTIP: Added Est. Sacks calculation
                    ToolTipLabelFormatter = point =>
                        $"{point.Context.Series.Name}\n" +
                        $"Weight: {point.Coordinate.PrimaryValue:N2} kg\n" +
                        $"Est. Sacks: {(currentVal / 50.0):N2} sacks\n" +
                        $"Share: {point.StackedValue.Share:P2}"
                });
            }

            var pieChart = new PieChart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(242, 242, 242),
                Series = pieSeries.ToArray(),
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Hidden,
                TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Top,
                AnimationsSpeed = TimeSpan.FromMilliseconds(1200),
                EasingFunction = LiveChartsCore.EasingFunctions.ExponentialOut
            };

            // UI Updates
            display_bargraph_panel.Controls.Clear();
            display_bargraph_panel.Controls.Add(barChart);

            display_piechart_panel.Controls.Clear();
            display_piechart_panel.Controls.Add(pieChart);
        }

        private async Task summaryAnimation(double total_Kilograms, int product_Count)
        {
            double current_Kilogram = 0;
            double current_count = 0;

            int total_Frames = 30;
            double kilogram_Step = total_Kilograms / total_Frames;
            double count_Step = (double)product_Count / total_Frames;

            for (int a = 0; a < total_Frames; a++)
            {
                
                current_Kilogram += kilogram_Step;
                current_count += count_Step;

                await Task.Delay(33);
            }
                       
        }

        

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
