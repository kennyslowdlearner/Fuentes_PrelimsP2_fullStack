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
    public partial class productInventory : Form
    {
        private static productInventory instance;
        public productInventory()
        {
            InitializeComponent();
            press_connectpi(null, null);
        }

        //made changes here (8) [4/6/2026 | 12:46 PM]
        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;

        bool showingSeedlings = false;
        internal static productInventory Instance
        {
            //made changes here (5) [4/3/2026 | 12:24 PM]
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new productInventory();
                }

                return instance;
            }
        }


        public void AddProductRow(string productname, string productid, string quantity)
        {

        }



        private void logoutoptionPI_click(object sender, EventArgs e)
        {
            //made changes here (9) [4/6/2026 | 12:46 PM]
            Homepageee.Instance.Show();
            this.Hide();
        }

        private void productInventory_FormClosed(object sender, FormClosedEventArgs e)
        {
            //made changes here (10) [4/6/2026 | 12:46 PM]
            //Application.Exit();
        }


        private void backButton(object sender, EventArgs e)
        {
            //made changes here (11) [4/6/2026 | 12:46 PM]
            UserAccount.Instance.Show();
            this.Hide();
        }



        private void press_connectpi(object sender, EventArgs e)
        {
            //made changes here (12) [4/6/2026 | 12:46 PM]
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            dataSet = new DataSet();

            try
            {
                connection.Open();
                System.Windows.Forms.MessageBox.Show("Connected Succesfully!");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed. Error: " + ex.Message);
            }
        }

        private void press_loadpi(object sender, EventArgs e)
        {
            string tableName = showingSeedlings ? "[User PI Seedling Inventory]" : "[User PI Product Inventory]";
            string dbPath = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

            connection = new OleDbConnection(dbPath);
            string query = $"SELECT * FROM {tableName} WHERE [User ID] = @A1";
            adapter = new OleDbDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("A1", UserSession.UserInstance.ID);

            try
            {
                connection.Open();
                dataSet = new DataSet();
                adapter.Fill(dataSet, tableName);
                connection.Close();

                DataTable dt = dataSet.Tables[tableName];

                // 1. Reset the Grid to prevent column memory leaks
                Product_Inventory_Grid.DataSource = null;
                Product_Inventory_Grid.Columns.Clear();
                Product_Inventory_Grid.AutoGenerateColumns = true;

                // 2. Add calculated column
                if (!dt.Columns.Contains("Estimated Sacks"))
                {
                    dt.Columns.Add("Estimated Sacks", typeof(string));
                }

                // 3. Identification and Calculation Logic
                string qtyCol = showingSeedlings ? "Quantity(Kg)" : "Quantity in Kilograms";
                double totalKgSum = 0;

                foreach (DataRow row in dt.Rows)
                {
                    if (row[qtyCol] != DBNull.Value && double.TryParse(row[qtyCol].ToString(), out double kgs))
                    {
                        totalKgSum += kgs;
                        double sacks = kgs / 50.0;
                        row["Estimated Sacks"] = sacks.ToString("N2") + " sacks";
                    }
                    else
                    {
                        row["Estimated Sacks"] = "0.00 sacks";
                    }
                }

                // 4. Update Dashboard Labels
                double totalSacksSum = totalKgSum / 50.0;
                display_kg_gg.Text = totalKgSum.ToString("N2") + " kg";
                display_sack_gg.Text = totalSacksSum.ToString("N2") + " sacks";

                // 5. Bind Data and Format Visuals
                Product_Inventory_Grid.DataSource = dt;
                Product_Inventory_Grid.DefaultCellStyle.ForeColor = Color.Black;
                Product_Inventory_Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

                // Hide Technical Columns
                if (Product_Inventory_Grid.Columns.Contains("Roll Number"))
                    Product_Inventory_Grid.Columns["Roll Number"].Visible = false;
                if (Product_Inventory_Grid.Columns.Contains("User ID"))
                    Product_Inventory_Grid.Columns["User ID"].Visible = false;

                // Position "Estimated Sacks" next to Quantity
                if (Product_Inventory_Grid.Columns.Contains(qtyCol) && Product_Inventory_Grid.Columns.Contains("Estimated Sacks"))
                {
                    Product_Inventory_Grid.Columns["Estimated Sacks"].DisplayIndex = Product_Inventory_Grid.Columns[qtyCol].DisplayIndex + 1;
                    Product_Inventory_Grid.Columns["Estimated Sacks"].HeaderText = "Est. Sacks (50kg)";
                }

                Product_Inventory_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }

        private void press_insertpi(object sender, EventArgs e)
        {
            string tableName = showingSeedlings ? "[User PI Seedling Inventory]" : "[User PI Product Inventory]";
            string query;

            if (showingSeedlings)
            {
                // Added the three specific seedling columns to the query
                query = $"INSERT INTO {tableName} ([Variety Name], [Seed ID], [Quantity(Kg)], [Batch Source], [Date Received], [Germ Rate], [User ID]) VALUES (@P1, @P2, @P3, @BS, @DR, @GR, @P5)";
            }
            else
            {
                query = $"INSERT INTO {tableName} ([Product Name], [Product ID], [Quantity in Kilograms], [Reference ID], [User ID]) VALUES (@P1, @P2, @P3, @P4, @P5)";
            }

            using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb"))
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@P1", fill_productname_pi.Text);
                cmd.Parameters.AddWithValue("@P2", fill_productid_pi.Text);
                cmd.Parameters.AddWithValue("@P3", Convert.ToInt32(fill_quantity_pi.Text));

                if (showingSeedlings)
                {
                    // NEW: Mapping the seedling-specific textboxes to the database
                    cmd.Parameters.AddWithValue("@BS", fill_batchcode_pi.Text);
                    cmd.Parameters.AddWithValue("@DR", fill_datereceived_pi.Value.ToShortDateString());
                    cmd.Parameters.AddWithValue("@GR", fill_germrate_pi.Text);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@P4", GenerateReferenceID());
                }

                cmd.Parameters.AddWithValue("@P5", UserSession.UserInstance.ID);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inventory Updated!");
                press_loadpi(sender, e);
            }
        }



        private void press_deletepi(object sender, EventArgs e)
        {
            //made changes here (16) [4/6/2026 | 12:46 PM]
            // Fix: Dynamic table name and column identification
            string tableName = showingSeedlings ? "[User PI Seedling Inventory]" : "[User PI Product Inventory]";
            string idColumn = showingSeedlings ? "Seed ID" : "Product ID";

            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");

            // We use the column name directly from the grid to be safe
            string query = $"DELETE FROM {tableName} WHERE [{idColumn}] = @P2";

            command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@P2", Product_Inventory_Grid.CurrentRow.Cells[idColumn].Value);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Item deleted successfully!");
                press_loadpi(sender, e); // Refresh grid
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete item. Error: " + ex.Message);
            }
        }

        private void press_updatepi(object sender, EventArgs e)
        {
            string tableName = showingSeedlings ? "[User PI Seedling Inventory]" : "[User PI Product Inventory]";
            string query;

            // Use ONE if/else block to set the query correctly
            if (showingSeedlings)
            {
                query = $"UPDATE {tableName} SET [Variety Name] = @P1, [Quantity(Kg)] = @P3, [Batch Source] = @BS, [Germ Rate] = @GR, [Date Received] = @DR WHERE [Seed ID] = @P2";
            }
            else
            {
                query = $"UPDATE {tableName} SET [Product Name] = @P1, [Quantity in Kilograms] = @P3 WHERE [Product ID] = @P2";
            }

            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            command = new OleDbCommand(query, connection);

            // PARAMETERS MUST BE IN THE EXACT ORDER THEY APPEAR IN THE SQL STRING
            command.Parameters.AddWithValue("@P1", fill_productname_pi.Text);
            command.Parameters.AddWithValue("@P3", Convert.ToInt32(fill_quantity_pi.Text));

            if (showingSeedlings)
            {
                command.Parameters.AddWithValue("@BS", fill_batchcode_pi.Text);
                command.Parameters.AddWithValue("@GR", fill_germrate_pi.Text);
                command.Parameters.AddWithValue("@DR", fill_datereceived_pi.Value.ToShortDateString());
            }

            // The WHERE clause ID always comes last in this specific SQL structure
            command.Parameters.AddWithValue("@P2", fill_productid_pi.Text);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Inventory updated successfully!");
                press_loadpi(sender, e); // Refresh the grid on your Acer Swift
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed. Error: " + ex.Message);
            }
        }

        private string GenerateReferenceID()
        {
            //made changes here (18) [4/6/2026 | 12:46 PM]
            Random reference = new Random();

            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int size = 8;
            string randomString = "";

            for (int a = 0; a < size; a++)
            {
                int index = reference.Next(characters.Length);
                randomString += characters[index];

                if (a == 3)
                {
                    randomString += "-";
                }

            }

            return "PPREF-" + randomString;
        }

        private void press_refreshpi(object sender, EventArgs e)
        {
            //made changes here (19) [4/6/2026 | 12:46 PM]
            press_loadpi(null, null);

            fill_productname_pi.Clear();
            fill_productid_pi.Clear();
            fill_quantity_pi.Clear();
        }

        private void fill_searchpi(object sender, EventArgs e)
        {
            string connect = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";
            string query = "";
            string tableName = "";

            // 1. Switch Query based on active inventory
            if (showingSeedlings)
            {
                tableName = "User PI Seedling Inventory";
                // Search by Variety Name or Seed ID
                query = $"SELECT * FROM [{tableName}] WHERE ([Variety Name] LIKE @S1 OR [Seed ID] LIKE @S2) AND [User ID] = @User";
            }
            else
            {
                tableName = "User PI Product Inventory";
                // Search by Product Name, Product ID, or Reference ID
                query = $"SELECT * FROM [{tableName}] WHERE ([Product Name] LIKE @S1 OR [Product ID] LIKE @S2 OR [Reference ID] LIKE @S3) AND [User ID] = @User";
            }

            using (OleDbConnection connected = new OleDbConnection(connect))
            {
                OleDbDataAdapter searchAdapter = new OleDbDataAdapter(query, connected);
                string searchTerm = "%" + fill_search_pi.Text + "%";

                // 2. Add Parameters
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S1", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S2", searchTerm);

                if (!showingSeedlings)
                {
                    searchAdapter.SelectCommand.Parameters.AddWithValue("@S3", searchTerm);
                }

                searchAdapter.SelectCommand.Parameters.AddWithValue("@User", UserSession.UserInstance.ID);

                DataSet searchNow = new DataSet();

                try
                {
                    connected.Open();
                    searchAdapter.Fill(searchNow, tableName);
                    Product_Inventory_Grid.DataSource = searchNow.Tables[tableName];

                    if (Product_Inventory_Grid.Columns.Contains("User ID"))
                        Product_Inventory_Grid.Columns["User ID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search failed. Error: " + ex.Message);
                }
            }
        }

        private void press_viewanalytics_pi(object sender, EventArgs e)
        {
            var analytics = UserProductInventory_Analytics.Instance;
            analytics.Show();
            //this.Hide();

        }


        private void press_switchpi(object sender, EventArgs e)
        {
            showingSeedlings = !showingSeedlings;

            label_batchsource_pi.Visible = showingSeedlings;
            label_datereceived_pi.Visible = showingSeedlings;
            label_germrate_pi.Visible = showingSeedlings;
            label_sc1_pi.Visible = showingSeedlings;
            label_sc2_pi.Visible = showingSeedlings;
            label_sc3_pi.Visible = showingSeedlings;
            fill_batchcode_pi.Visible = showingSeedlings;
            fill_datereceived_pi.Visible = showingSeedlings;
            fill_germrate_pi.Visible = showingSeedlings;

            // Fix: Display the name of the table the user is MOVING TO
            display_indicator_pi.Text = showingSeedlings ? "Seedling Inventory" : "Rice Inventory";

            press_loadpi(sender, e);


            fill_productname_pi.Clear();
            fill_productid_pi.Clear();
            fill_quantity_pi.Clear();
        }

        private void Product_Inventory_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            indexRow = e.RowIndex;
            DataGridViewRow row = Product_Inventory_Grid.Rows[indexRow];

            if (showingSeedlings)
            {
                fill_productname_pi.Text = row.Cells["Variety Name"].Value?.ToString();
                fill_productid_pi.Text = row.Cells["Seed ID"].Value?.ToString();
                fill_quantity_pi.Text = row.Cells["Quantity(Kg)"].Value?.ToString();

                // Load the seedling-specific data back into textboxes
                fill_batchcode_pi.Text = row.Cells["Batch Source"].Value?.ToString();
                fill_germrate_pi.Text = row.Cells["Germ Rate"].Value?.ToString();

                if (row.Cells["Date Received"].Value != DBNull.Value)
                    fill_datereceived_pi.Value = Convert.ToDateTime(row.Cells["Date Received"].Value);
            }
            else
            {
                fill_productname_pi.Text = row.Cells["Product Name"].Value?.ToString();
                fill_productid_pi.Text = row.Cells["Product ID"].Value?.ToString();
                fill_quantity_pi.Text = row.Cells["Quantity in Kilograms"].Value?.ToString();
            }
        }
    }
}
