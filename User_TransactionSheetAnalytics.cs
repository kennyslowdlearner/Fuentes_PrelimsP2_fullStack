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
        public User_TransactionSheetAnalytics()
        {
            InitializeComponent();
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

            //if (quantities.Count > 0) UpdateCharts(productName, quantities);
        }
        private void fetch_TRANSACTION_data_from_database()
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

            //if (quantities.Count > 0) UpdateCharts(productName, quantities);
        }

        private void initialize_AllCharts()
        {
            var inventory_piechart = new PieChart
            {
                Dock = DockStyle.Fill,
                Series = new ISeries[]
                {

                }
            };

        }
    }
}
