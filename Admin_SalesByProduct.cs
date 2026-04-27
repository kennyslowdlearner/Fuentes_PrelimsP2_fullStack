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
    public partial class Admin_SalesByProduct : Form
    {
        private static Admin_SalesByProduct instance;
        public Admin_SalesByProduct()
        {
            InitializeComponent();
            auto_reload();
        }

        internal static Admin_SalesByProduct Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Admin_SalesByProduct();
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

        private void auto_reload()
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            adapter = new OleDbDataAdapter("SELECT * FROM [User T&T Transaction]", connection);

            adapter.SelectCommand.Parameters.AddWithValue("?", UserSession.UserInstance.ID);

            try
            {
                connection.Open();

                dataSet = new DataSet();

                adapter.Fill(dataSet, "User T&T Transaction");

                connection.Close();

                Sales_By_Product_Grid.DataSource = dataSet.Tables["User T&T Transaction"];

                if (Sales_By_Product_Grid.Columns.Contains("Item Number"))
                    Sales_By_Product_Grid.Columns["Item Number"].Visible = false;

                Sales_By_Product_Grid.Columns["Customer Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Sales_By_Product_Grid.Columns["Rice Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Sales_By_Product_Grid.Columns["Product ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Sales_By_Product_Grid.Columns["Price per Kilogram"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Sales_By_Product_Grid.Columns["Quantity in Kilogram"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Sales_By_Product_Grid.Columns["Delivery Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Sales_By_Product_Grid.Columns["Reference ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Sales_By_Product_Grid.Columns["User ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }

        private void press_search(object sender, EventArgs e)
        {
            string connect = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

            string query = "SELECT * FROM [User T&T Transaction] WHERE [Customer Name] LIKE @S1 OR [Product Name] LIKE @S2 OR [Reference ID] LIKE @S3 OR [Rice Type] LIKE @S4 OR [Product ID] LIKE @S5 OR [Destination] LIKE @S6 OR [Region] LIKE @S7";


            if (string.IsNullOrWhiteSpace(fill_search_sbp.Text))
            {
                auto_reload();
                return;
            }

            using (OleDbConnection connected = new OleDbConnection(connect))
            {
                OleDbDataAdapter searchAdapter = new OleDbDataAdapter(query, connected);

                string searchTerm = "%" + fill_search_sbp.Text + "%";
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S1", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S2", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S3", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S4", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S5", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S6", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S7", searchTerm);

                DataSet searchNow = new DataSet();

                try
                {
                    connected.Open();
                    searchAdapter.Fill(searchNow, "User T&T Transaction");

                    Sales_By_Product_Grid.DataSource = searchNow.Tables["User T&T Transaction"];
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Search failed. Error: " + ex.Message);
                }
            }
        }

        private void Sales_By_Product_Grid_VisibleChanged(object sender, EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                auto_reload();
            }
        }
    }
}
