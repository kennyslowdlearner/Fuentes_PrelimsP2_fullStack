using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;
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
    public partial class User_TransactionSheetAnalytics : Form
    {
        private static User_TransactionSheetAnalytics instance;
        public User_TransactionSheetAnalytics()
        {
            InitializeComponent();

            this.Load += new EventHandler(User_TransactionSheetAnalytics_Load);
        }

        internal static User_TransactionSheetAnalytics Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new User_TransactionSheetAnalytics();
                }
                return instance;
            }
        }

        private void User_TransactionSheetAnalytics_Load(object sender, EventArgs e)
        {
            fetch_INVENTORY_data_from_database();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fetch_INVENTORY_data_from_database()
        {
            int currentUserID = UserSession.UserInstance.ID;
            string connection = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

            List<string> productName = new List<string>();
            List<double> quantities = new List<double>();
            double totalInventoryKg = 0;

            using (OleDbConnection reader = new OleDbConnection(connection))
            {
                // Added User ID check
                string query = "SELECT [Product Name], [Quantity in Kilograms] FROM [User PI Product Inventory] WHERE [User ID] = ?";
                OleDbCommand command = new OleDbCommand(query, reader);
                command.Parameters.AddWithValue("?", currentUserID);

                try
                {
                    reader.Open();
                    OleDbDataReader scanner = command.ExecuteReader();
                    while (scanner.Read())
                    {
                        productName.Add(scanner["Product Name"].ToString());
                        double qty = Convert.ToDouble(scanner["Quantity in Kilograms"]);
                        quantities.Add(qty);
                        totalInventoryKg += qty;
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

            fetch_TRANSACTION_data_from_database(productName, quantities, totalInventoryKg);
        }
        
        private void fetch_TRANSACTION_data_from_database(List<string> productName, List<double> quantities, double totalInventory)
        {
            int currentUserID = UserSession.UserInstance.ID;
            string connection = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

            List<string> riceType = new List<string>();
            List<double> quantitySold = new List<double>();
            List<DateTime> date_Transaction = new List<DateTime>();
            double totalSoldKg = 0;

            using (OleDbConnection reader = new OleDbConnection(connection))
            {
                string query = "SELECT [Rice Type], [Quantity in Kilogram], [Delivery Date] FROM [User T&T Transaction] WHERE [User ID] = ?";
                OleDbCommand command = new OleDbCommand(query, reader);
                command.Parameters.AddWithValue("?", currentUserID);

                try
                {
                    reader.Open();
                    OleDbDataReader scanner = command.ExecuteReader();
                    while (scanner.Read())
                    {
                        riceType.Add(scanner["Rice Type"].ToString());
                        double sold = Convert.ToDouble(scanner["Quantity in Kilogram"]);
                        quantitySold.Add(sold);
                        totalSoldKg += sold;
                        date_Transaction.Add(Convert.ToDateTime(scanner["Delivery Date"]));
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }

            // Calculate Rate: (Sold / (Sold + Current Inventory)) * 100
            double rate = (totalInventory + totalSoldKg) > 0 ? (totalSoldKg / (totalInventory + totalSoldKg)) * 100 : 0;

            _ = summaryAnimation(totalSoldKg, rate);
            if (quantitySold.Count > 0) initialize_AllCharts(productName, quantities, riceType, quantitySold, date_Transaction);
        }

        private void initialize_AllCharts(List<string> productName, List<double> quantity, List<string> riceType, List<double> quantitySold, List<DateTime> date_Transaction)
        {
            // Global Styling Constants
            var labelPaint = new SolidColorPaint(SKColors.Black);
            var separatorPaint = new SolidColorPaint(SKColors.LightGray.WithAlpha(80));
            var animationDuration = TimeSpan.FromMilliseconds(1200);
            var easing = LiveChartsCore.EasingFunctions.ExponentialOut;

            // 1. Inventory Pie Chart (Current Stock)
            var inventorySeries = new List<ISeries>();
            for (int a = 0; a < productName.Count; a++)
            {
                inventorySeries.Add(new PieSeries<double>
                {
                    Name = productName[a],
                    Values = new double[] { quantity[a] },
                    DataLabelsPaint = null, // Clean look: No permanent labels
                    ToolTipLabelFormatter = point => $"{point.Context.Series.Name}: {point.Coordinate.PrimaryValue} kg ({point.StackedValue.Share:P2})",
                    AnimationsSpeed = animationDuration,
                    EasingFunction = easing
                });
            }

            var pieChart_Inventory = new PieChart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(242, 242, 242),
                Series = inventorySeries.ToArray(),
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Hidden,
                TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Top,
                AnimationsSpeed = animationDuration,
                EasingFunction = easing
            };

            // 2. Transaction Pie Chart (Sales Distribution)
            var transactionSeries = new List<ISeries>();
            for (int b = 0; b < riceType.Count; b++)
            {
                transactionSeries.Add(new PieSeries<double>
                {
                    Name = riceType[b],
                    Values = new double[] { quantitySold[b] },
                    DataLabelsPaint = null,
                    ToolTipLabelFormatter = point => $"{point.Context.Series.Name}: {point.Coordinate.PrimaryValue} kg ({point.StackedValue.Share:P2})",
                    AnimationsSpeed = animationDuration,
                    EasingFunction = easing
                });
            }

            var pieChart_Transaction = new PieChart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(242, 242, 242),
                Series = transactionSeries.ToArray(),
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Hidden,
                TooltipPosition = LiveChartsCore.Measure.TooltipPosition.Top,
                AnimationsSpeed = animationDuration,
                EasingFunction = easing
            };

            // 3. Scatter Plot (Sales Over Time)
            var scatterPoints = new List<ObservablePoint>();
            for (int c = 0; c < date_Transaction.Count; c++)
            {
                // X = Day of Month, Y = Quantity Sold
                scatterPoints.Add(new ObservablePoint(date_Transaction[c].Day, quantitySold[c]));
            }

            var scatterChart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent,
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Hidden,

                // ZOOM & PAN (Standard for X-Y analysis)
                ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X,

                // OPENING ANIMATION
                AnimationsSpeed = animationDuration,
                EasingFunction = easing,

                Series = new ISeries[]
                {
            new ScatterSeries<ObservablePoint>
            {
                Name = "Transactions",
                Values = scatterPoints.ToArray(),
                GeometrySize = 12,
                Fill = new SolidColorPaint(SKColors.ForestGreen.WithAlpha(180)),
                
                // HOVER FORMATTER
                YToolTipLabelFormatter = point => $"Sold: {point.Coordinate.PrimaryValue} kg",
                XToolTipLabelFormatter = point => $"Day: {point.Coordinate.SecondaryValue}"
            }
                },

                // COORDINATE SYSTEM (X and Y Axes)
                XAxes = new Axis[]
                {
            new Axis
            {
                Name = "Day of Month",
                NamePaint = labelPaint,
                LabelsPaint = labelPaint,
                SeparatorsPaint = separatorPaint,
                MinLimit = 0,
                MaxLimit = 31 // Standard month view
            }
                },
                YAxes = new Axis[]
                {
            new Axis
            {
                Name = "Quantity (kg)",
                NamePaint = labelPaint,
                LabelsPaint = labelPaint,
                SeparatorsPaint = separatorPaint,
                Labeler = value => $"{value}kg",
                MinLimit = 0
            }
                }
            };

            // UI Panel Updates
            display_piechart_analyticsTandT.Controls.Clear();
            display_piechart_analyticsTandT.Controls.Add(pieChart_Inventory);

            display_piechartt_analyticsTandT.Controls.Clear();
            display_piechartt_analyticsTandT.Controls.Add(pieChart_Transaction);

            display_scatterplot_analyticsTandT.Controls.Clear();
            display_scatterplot_analyticsTandT.Controls.Add(scatterChart);
        }

        private async Task summaryAnimation(double total_Sales, double final_rate)
        {
            double current_Sales = 0;
            double current_rate = 0;
            int total_Frames = 30;

            double sales_Step = total_Sales / total_Frames;
            double rate_Step = final_rate / total_Frames;

            for (int a = 0; a < total_Frames; a++)
            {

                current_Sales += sales_Step;
                current_rate += rate_Step;
                await Task.Delay(33);
            }

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
