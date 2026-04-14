using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System.Windows.Media;

namespace Fuentes_PrelimsP2
{
    //need further polishing for this one.
    
    public partial class UserProductInventory_AnalyticsForm : Form
    {
        private CartesianChart inventoryChart;

        public UserProductInventory_AnalyticsForm()
        {
            InitializeComponent();
            InitializeLiveChart();
        }

        private void InitializeLiveChart()
        {
            inventoryChart = new CartesianChart();
            inventoryChart.Dock = DockStyle.Fill;

            display_panelchart_pi.Controls.Add(inventoryChart);
            inventoryChart.BackColor = Color.Transparent;

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void load_productInventoryAnalytics()
        {
            var values = new ChartValues<double>();
            var labels = new List<string>();

            string connString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";
            string query = "SELECT [Product Name], [Quantity in Kilograms] FROM [User PI Product Inventory]";

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                OleDbCommand cmd = new OleDbCommand(query, conn);
                try
                {
                    conn.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        labels.Add(reader["Product Name"].ToString());
                        values.Add(Convert.ToDouble(reader["Quantity in Kilograms"]));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Analytics Error: " + ex.Message);
                }
            }

            // 3. Create the Bar Series
            inventoryChart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Stock Level",
                    Values = values,
                    DataLabels = true,
                    Fill = Brushes.SeaGreen // Modern 2026 aesthetic
                }
            };

            // 4. Setup the X-Axis (Rice Names)
            inventoryChart.AxisX.Clear();
            inventoryChart.AxisX.Add(new Axis
            {
                Title = "Rice Varieties",
                Labels = labels,
                Separator = new Separator { Step = 1, IsEnabled = false }
            });

            // 5. Setup the Y-Axis (Quantity)
            inventoryChart.AxisY.Clear();
            inventoryChart.AxisY.Add(new Axis
            {
                Title = "Kilograms (kg)",
                LabelFormatter = value => value.ToString("N0") + " kg"
            });
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
