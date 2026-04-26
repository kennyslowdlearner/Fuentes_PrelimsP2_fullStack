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
    public partial class Admin_InventoryManagement : Form
    {
        private static Admin_InventoryManagement instance;
        public Admin_InventoryManagement()
        {
            InitializeComponent();
            auto_reload();
        }

        internal static Admin_InventoryManagement Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Admin_InventoryManagement();
                }

                return instance;
            }
        }

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;

        internal bool showingSeedlings = true;
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
            string tableName = showingSeedlings ? "[User PI Seedling Inventory]" : "[User PI Product Inventory]";

            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");

            string query = $"SELECT * FROM {tableName}";
            adapter = new OleDbDataAdapter(query, connection);

            try
            {
                connection.Open();
                dataSet = new DataSet();
                adapter.Fill(dataSet, tableName);
                connection.Close();

                Inventory_Management_Grid.DataSource = dataSet.Tables[tableName];

                if (showingSeedlings)
                {
                    if (Inventory_Management_Grid.Columns.Contains("Roll Number"))
                        Inventory_Management_Grid.Columns["Roll Number"].Visible = false;

                    Inventory_Management_Grid.Columns["Variety Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Inventory_Management_Grid.Columns["Seed ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Inventory_Management_Grid.Columns["Quantity(Kg)"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Inventory_Management_Grid.Columns["Batch Source"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Inventory_Management_Grid.Columns["Date Received"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Inventory_Management_Grid.Columns["Germ Rate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    if (Inventory_Management_Grid.Columns.Contains("User ID"))
                    {
                        Inventory_Management_Grid.Columns["User ID"].Visible = true;
                        Inventory_Management_Grid.Columns["User ID"].DisplayIndex = 0;
                    }
                }
                else
                {

                    if (Inventory_Management_Grid.Columns.Contains("Roll Number"))
                        Inventory_Management_Grid.Columns["Roll Number"].Visible = false;

                    Inventory_Management_Grid.Columns["Product Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Inventory_Management_Grid.Columns["Reference ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Inventory_Management_Grid.Columns["Product ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Inventory_Management_Grid.Columns["Quantity in Kilograms"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    if (Inventory_Management_Grid.Columns.Contains("User ID"))
                    {
                        Inventory_Management_Grid.Columns["User ID"].Visible = true;
                        Inventory_Management_Grid.Columns["User ID"].DisplayIndex = 0;
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }

        private void press_switch(object sender, EventArgs e)
        {
            showingSeedlings = !showingSeedlings;

            // Fix: Display the name of the table the user is MOVING TO
            display_namestatus.Text = showingSeedlings ? "Seedling Inventory" : "Rice Inventory";

            auto_reload();

        }

        private void press_search(object sender, EventArgs e)
        {
            string connect = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";
            string query = "";
            string tableName = "";

            // 1. Switch Query based on active inventory
            if (showingSeedlings)
            {
                tableName = "User PI Seedling Inventory";
                // Search by Variety Name or Seed ID
                query = $"SELECT * FROM [{tableName}] WHERE ([Variety Name] LIKE @S1 OR [Seed ID] LIKE @S2)";
            }
            else
            {
                tableName = "User PI Product Inventory";
                // Search by Product Name, Product ID, or Reference ID
                query = $"SELECT * FROM [{tableName}] WHERE ([Product Name] LIKE @S1 OR [Product ID] LIKE @S2 OR [Reference ID] LIKE @S3)";
            }

            using (OleDbConnection connected = new OleDbConnection(connect))
            {
                OleDbDataAdapter searchAdapter = new OleDbDataAdapter(query, connected);
                string searchTerm = "%" + fill_search_im.Text + "%";

                // 2. Add Parameters
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S1", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S2", searchTerm);

                if (!showingSeedlings)
                {
                    searchAdapter.SelectCommand.Parameters.AddWithValue("@S3", searchTerm);
                }

                DataSet searchNow = new DataSet();

                try
                {
                    connected.Open();
                    searchAdapter.Fill(searchNow, tableName);
                    Inventory_Management_Grid.DataSource = searchNow.Tables[tableName];

                    // 3. Re-apply your column formatting so the grid stays clean
                    if (Inventory_Management_Grid.Columns.Contains("User ID"))
                    {
                        Inventory_Management_Grid.Columns["User ID"].Visible = true;
                        Inventory_Management_Grid.Columns["User ID"].HeaderText = "Owner ID";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search failed. Error: " + ex.Message);
                }
            }
        }

        private void auto_Reload(object sender, EventArgs e)
        {
            string tableName = showingSeedlings ? "[User PI Seedling Inventory]" : "[User PI Product Inventory]";

            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");

            string query = $"SELECT * FROM {tableName}";
            adapter = new OleDbDataAdapter(query, connection);

            try
            {
                connection.Open();
                dataSet = new DataSet();
                adapter.Fill(dataSet, tableName);
                connection.Close();

                Inventory_Management_Grid.DataSource = dataSet.Tables[tableName];

                if (showingSeedlings)
                {
                    if (Inventory_Management_Grid.Columns.Contains("Roll Number"))
                        Inventory_Management_Grid.Columns["Roll Number"].Visible = false;

                    Inventory_Management_Grid.Columns["Variety Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Inventory_Management_Grid.Columns["Seed ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Inventory_Management_Grid.Columns["Quantity(Kg)"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Inventory_Management_Grid.Columns["Batch Source"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Inventory_Management_Grid.Columns["Date Received"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Inventory_Management_Grid.Columns["Germ Rate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    if (Inventory_Management_Grid.Columns.Contains("User ID"))
                    {
                        Inventory_Management_Grid.Columns["User ID"].Visible = true;
                        Inventory_Management_Grid.Columns["User ID"].DisplayIndex = 0;
                    }
                }
                else
                {

                    if (Inventory_Management_Grid.Columns.Contains("Roll Number"))
                        Inventory_Management_Grid.Columns["Roll Number"].Visible = false;

                    Inventory_Management_Grid.Columns["Product Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Inventory_Management_Grid.Columns["Reference ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Inventory_Management_Grid.Columns["Product ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Inventory_Management_Grid.Columns["Quantity in Kilograms"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    if (Inventory_Management_Grid.Columns.Contains("User ID"))
                    {
                        Inventory_Management_Grid.Columns["User ID"].Visible = true;
                        Inventory_Management_Grid.Columns["User ID"].DisplayIndex = 0;
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }
    }
}
