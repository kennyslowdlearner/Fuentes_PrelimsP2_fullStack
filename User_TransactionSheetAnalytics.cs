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

            if (quantities.Count > 0) fetch_TRANSACTION_data_from_database(productName, quantities);
        }
        private void fetch_TRANSACTION_data_from_database(List<string> productName, List<double> quantities)
        {
            string connection = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

            List<string> riceType = new List<string>();
            List<double> quantitySold = new List<double>();
            List<DateTime> date_Transaction = new List<DateTime>();

            using (OleDbConnection reader = new OleDbConnection(connection))
            {

                string query = "SELECT [Rice Type], [Quantity in Kilogram], [Delivery Date] FROM [User T&T Transaction]";
                OleDbCommand command = new OleDbCommand(query, reader);

                try
                {
                    reader.Open();
                    OleDbDataReader scanner = command.ExecuteReader();

                    while (scanner.Read())
                    {
                        riceType.Add(scanner["Rice Type"].ToString());
                        quantitySold.Add(Convert.ToDouble(scanner["Quantity in Kilogram"]));
                        date_Transaction.Add(Convert.ToDateTime(scanner["Delivery Date"]));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching data: " + ex.Message);
                }
            }

            if (quantitySold.Count > 0) initialize_AllCharts(productName, quantities, riceType, quantitySold, date_Transaction);
        }

        private void initialize_AllCharts(List<string> productName, List<double> quantity, List<string> riceType, List<double> quantitySold, List<DateTime> date_Transaction)
        {
            var inventorySeries = new List<ISeries>();
            for (int a = 0; a < productName.Count(); a++)
            {
                inventorySeries.Add(new PieSeries<double>
                {
                    Name = productName[a],
                    Values = new double[] { quantity[a] },
                });
            }

            var pieChart_Inventory = new PieChart
            {
                Dock = DockStyle.Fill,
                Series = inventorySeries.ToArray(),
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Right
            };

            var transactionSeries = new List<ISeries>();
            for (int b = 0; b < riceType.Count; b++)
            {
                transactionSeries.Add(new PieSeries<double>
                {
                    Name = riceType[b],
                    Values = new double[] { quantitySold[b] },
                });
            }
            ;

            var pieChart_Transaction = new PieChart
            {
                Dock = DockStyle.Fill,
                Series = transactionSeries.ToArray(),
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Right

            };

            //scatterplot

            var scatterplot = new List<ObservablePoint>();
            for(int c = 0; c <date_Transaction.Count; c++)
            {
                scatterplot.Add(new ObservablePoint(date_Transaction[c].Day, quantitySold[c]));
            }

            var scatterChart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                Series = new ISeries[]
                {
                    new ScatterSeries<ObservablePoint>
                    {
                        Name = "Sales Transactions",
                        Values = scatterplot.ToArray(),
                        GeometrySize = 15,
                        Fill = new SolidColorPaint(SKColors.DarkGreen.WithAlpha(150)),
                    }
                },

                XAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Delivery Dates"
                    }
                },

                YAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Quantity Sold (Kg)"
                    }
                }
            };

            display_piechart_analyticsTandT.Controls.Clear();
            display_piechart_analyticsTandT.Controls.Add(pieChart_Inventory);

            display_piechartt_analyticsTandT.Controls.Clear();
            display_piechartt_analyticsTandT.Controls.Add(pieChart_Transaction);

            display_scatterplot_analyticsTandT.Controls.Clear();
            display_scatterplot_analyticsTandT.Controls.Add(scatterChart);

        }
    }
}
