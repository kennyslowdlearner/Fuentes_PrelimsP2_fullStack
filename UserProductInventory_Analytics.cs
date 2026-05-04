using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Threading.Tasks;

namespace Fuentes_PrelimsP2
{
    public partial class UserProductInventory_Analytics : Form
    {
        private static UserProductInventory_Analytics instance;

        // FIX: Define the color here at the class level so all methods can see it
        private readonly Color pananomGreen = Color.FromArgb(118, 186, 27);

        public UserProductInventory_Analytics()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            // Apply the green background to the panels immediately
            display_bargraph_panel.BackColor = pananomGreen;
            display_piechart_panel.BackColor = pananomGreen;

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
            }
        }

        private void UpdateCharts(List<string> productName, List<double> quantities)
        {
            double totalWeight = 0;
            foreach (var q in quantities) totalWeight += q;

            // --- BAR CHART ---
            var barChart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = pananomGreen, // Now accessible here
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
                        YToolTipLabelFormatter = point =>
                        {
                            double val = point.Coordinate.PrimaryValue;
                            return $"{productName[(int)point.Index]}\n" +
                                   $"Weight: {val:N2} kg\n" +
                                   $"Est. Sacks: {(val / 50.0):N2} sacks\n" +
                                   $"Share: {(val / totalWeight):P1}";
                        }
                    }
                },
                XAxes = new Axis[] { new Axis { Labels = productName.ToArray(), LabelsRotation = 15 } },
                YAxes = new Axis[] { new Axis { Labeler = value => $"{value}kg" } }
            };

            // --- PIE CHART ---
            var pieSeries = new List<ISeries>();
            for (int a = 0; a < productName.Count; a++)
            {
                double currentVal = quantities[a];
                pieSeries.Add(new PieSeries<double>
                {
                    Name = productName[a],
                    Values = new double[] { currentVal },
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
                BackColor = pananomGreen, // Now accessible here
                Series = pieSeries.ToArray(),
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Hidden,
                TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Top,
                AnimationsSpeed = TimeSpan.FromMilliseconds(1200),
                EasingFunction = LiveChartsCore.EasingFunctions.ExponentialOut
            };

            display_bargraph_panel.Controls.Clear();
            display_bargraph_panel.Controls.Add(barChart);

            display_piechart_panel.Controls.Clear();
            display_piechart_panel.Controls.Add(pieChart);
        }

        private async Task summaryAnimation(double total_Kilograms, int product_Count)
        {
            // Animation logic for UI labels
            await Task.Delay(1);
        }
    }
}