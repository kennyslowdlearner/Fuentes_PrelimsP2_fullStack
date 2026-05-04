using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
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

            // Subscribe to formatting event for the "Low/High" visual indicators
            Inventory_Management_Grid.CellFormatting += Inventory_Management_Grid_CellFormatting;

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
        DataSet? dataSet;
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

        // --- DYNAMIC COLOR CODING LOGIC ---
        private void Inventory_Management_Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Identify the Quantity column based on the active view
            string qtyColumn = showingSeedlings ? "Quantity(Kg)" : "Quantity in Kilograms";

            if (Inventory_Management_Grid.Columns[e.ColumnIndex].Name == qtyColumn && e.Value != null)
            {
                if (double.TryParse(e.Value.ToString(), out double qty))
                {
                    // Threshold: Low < 50kg (Red), Stable >= 50kg (Green)
                    if (qty < 50)
                    {
                        Inventory_Management_Grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.MistyRose;
                        Inventory_Management_Grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Maroon;
                    }
                    else
                    {
                        Inventory_Management_Grid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Honeydew;
                        Inventory_Management_Grid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.DarkGreen;
                    }
                }
            }
        }

        private void auto_reload()
        {
            string tableName = showingSeedlings ? "[User PI Seedling Inventory]" : "[User PI Product Inventory]";
            string qtyField = showingSeedlings ? "[Quantity(Kg)]" : "[Quantity in Kilograms]";

            // MS Access SQL logic to create a dynamic 'Stock Status' column
            string query = $"SELECT *, IIF({qtyField} < 50, 'LOW STOCK', 'STABLE') AS [Stock Status] FROM {tableName}";

            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");

            try
            {
                connection.Open();
                dataSet = new DataSet();
                adapter = new OleDbDataAdapter(query, connection);
                adapter.Fill(dataSet, tableName);
                connection.Close();

                Inventory_Management_Grid.DataSource = dataSet.Tables[tableName];

                // --- SHARED GRID FORMATTING ---
                if (Inventory_Management_Grid.Columns.Contains("Roll Number"))
                    Inventory_Management_Grid.Columns["Roll Number"].Visible = false;

                if (Inventory_Management_Grid.Columns.Contains("User ID"))
                {
                    Inventory_Management_Grid.Columns["User ID"].DisplayIndex = 0;
                    Inventory_Management_Grid.Columns["User ID"].HeaderText = "Owner ID";
                }

                if (Inventory_Management_Grid.Columns.Contains("Stock Status"))
                {
                    Inventory_Management_Grid.Columns["Stock Status"].DefaultCellStyle.Font = new Font(Inventory_Management_Grid.Font, FontStyle.Bold);
                    Inventory_Management_Grid.Columns["Stock Status"].Width = 120;
                }

                // --- VIEW-SPECIFIC FORMATTING ---
                if (showingSeedlings)
                {
                    Inventory_Management_Grid.Columns["Variety Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Inventory_Management_Grid.Columns["Quantity(Kg)"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                else
                {
                    Inventory_Management_Grid.Columns["Product Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Inventory_Management_Grid.Columns["Quantity in Kilograms"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load inventory: " + ex.Message);
            }
        }

        private void press_switch(object sender, EventArgs e)
        {
            showingSeedlings = !showingSeedlings;
            display_namestatus.Text = showingSeedlings ? "Seedling Inventory" : "Rice Inventory";
            auto_reload();
        }

        private void press_search(object sender, EventArgs e)
        {
            string tableName = showingSeedlings ? "User PI Seedling Inventory" : "User PI Product Inventory";
            string qtyField = showingSeedlings ? "[Quantity(Kg)]" : "[Quantity in Kilograms]";

            string query = showingSeedlings
                ? $"SELECT *, IIF({qtyField} < 50, 'LOW STOCK', 'STABLE') AS [Stock Status] FROM [{tableName}] WHERE ([Variety Name] LIKE @S1 OR [Seed ID] LIKE @S2)"
                : $"SELECT *, IIF({qtyField} < 50, 'LOW STOCK', 'STABLE') AS [Stock Status] FROM [{tableName}] WHERE ([Product Name] LIKE @S1 OR [Product ID] LIKE @S2 OR [Reference ID] LIKE @S3)";

            using (OleDbConnection connected = new OleDbConnection(connection.ConnectionString))
            {
                try
                {
                    OleDbDataAdapter searchAdapter = new OleDbDataAdapter(query, connected);
                    string searchTerm = "%" + fill_search_im.Text + "%";
                    searchAdapter.SelectCommand.Parameters.AddWithValue("@S1", searchTerm);
                    searchAdapter.SelectCommand.Parameters.AddWithValue("@S2", searchTerm);

                    if (!showingSeedlings)
                        searchAdapter.SelectCommand.Parameters.AddWithValue("@S3", searchTerm);

                    DataTable searchDt = new DataTable();
                    connected.Open();
                    searchAdapter.Fill(searchDt);
                    Inventory_Management_Grid.DataSource = searchDt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search Error: " + ex.Message);
                }
            }
        }
    }
}