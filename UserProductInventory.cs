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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void InitializeTableAndBind()
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // no-op
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void searchBoxPI_TextChanged(object sender, EventArgs e)
        {
            // no-op
        }

        private void searchbuttonPI_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void usermenuPI_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // no-op
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updatePrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Implement update product flow here when needed
        }

        private void deleteRemoveProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Implement delete/remove product flow here when needed
        }
        // no-op


        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void activityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            // no-op
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void profileName_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void backoptionPI_click(object sender, EventArgs e)
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

        private void Close_Form_After_Run(object sender, FormClosingEventArgs e)
        {

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

                // 1. Add calculated column for the Grid
                if (!dt.Columns.Contains("Estimated Sacks"))
                {
                    dt.Columns.Add("Estimated Sacks", typeof(string));
                }

                // 2. Identify the correct Quantity column based on current view
                string qtyCol = showingSeedlings ? "Quantity(Kg)" : "Quantity in Kilograms";

                // Variables to store grand totals for the labels
                double totalKgSum = 0;

                // 3. Process Rows: Calculate Grid Values and Sum for Labels
                foreach (DataRow row in dt.Rows)
                {
                    if (row[qtyCol] != DBNull.Value)
                    {
                        double kgs = Convert.ToDouble(row[qtyCol]);
                        totalKgSum += kgs; // Accumulate total for dashboard

                        double sacks = kgs / 50.0;
                        row["Estimated Sacks"] = sacks.ToString("N2") + " sacks";
                    }
                }

                // 4. Update Dashboard Labels (display_kg_gg and display_sack_gg)
                double totalSacksSum = totalKgSum / 50.0;

                display_kg_gg.Text = totalKgSum.ToString("N2") + " kg";
                display_sack_gg.Text = totalSacksSum.ToString("N2") + " sacks";

                // Apply visual styling (consistent with your other forms)
                var boldItalicFont = new Font(display_kg_gg.Font, FontStyle.Bold | FontStyle.Italic);
                display_kg_gg.Font = boldItalicFont;
                display_sack_gg.Font = boldItalicFont;
                display_sack_gg.ForeColor = Color.Gold; // Using Gold for sack emphasis

                // 5. Grid Binding and Formatting
                Product_Inventory_Grid.DataSource = dt;

                Product_Inventory_Grid.DefaultCellStyle.ForeColor = Color.Black;
                Product_Inventory_Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

                if (Product_Inventory_Grid.Columns.Contains("Roll Number"))
                    Product_Inventory_Grid.Columns["Roll Number"].Visible = false;

                if (Product_Inventory_Grid.Columns.Contains("User ID"))
                    Product_Inventory_Grid.Columns["User ID"].Visible = false;

                // Position the new column next to the Quantity column in the grid
                if (Product_Inventory_Grid.Columns.Contains("Estimated Sacks"))
                {
                    Product_Inventory_Grid.Columns["Estimated Sacks"].DisplayIndex = Product_Inventory_Grid.Columns[qtyCol].DisplayIndex + 1;
                    Product_Inventory_Grid.Columns["Estimated Sacks"].HeaderText = "Est. Sacks (50kg)";
                }

                // AutoSize adjustments
                if (showingSeedlings)
                {
                    Product_Inventory_Grid.Columns["Variety Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Product_Inventory_Grid.Columns["Seed ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Product_Inventory_Grid.Columns["Quantity(Kg)"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Product_Inventory_Grid.Columns["Estimated Sacks"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                else
                {
                    Product_Inventory_Grid.Columns["Product Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Product_Inventory_Grid.Columns["Reference ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    Product_Inventory_Grid.Columns["Product ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Product_Inventory_Grid.Columns["Quantity in Kilograms"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Product_Inventory_Grid.Columns["Estimated Sacks"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }

        private void press_insertpi(object sender, EventArgs e)
        {
            //made changes here (14) [4/6/2026 | 12:46 PM]
            string tableName = showingSeedlings ? "[User PI Seedling Inventory]" : "[User PI Product Inventory]";
            string query;

            if (showingSeedlings)
            {
                query = $"INSERT INTO {tableName} ([Variety Name], [Seed ID], [Quantity(Kg)], [User ID]) VALUES (@P1, @P2, @P3, @P5)";
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

                if (!showingSeedlings) cmd.Parameters.AddWithValue("@P4", GenerateReferenceID());

                cmd.Parameters.AddWithValue("@P5", UserSession.UserInstance.ID);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inventory Updated!");
                press_loadpi(sender, e);
            }


        }

        private void datagrid_cellclick(object sender, DataGridViewCellEventArgs e)
        {
            //made changes here (15) [4/6/2026 | 12:46 PM]
            if (e.RowIndex < 0) return;
            indexRow = e.RowIndex;
            DataGridViewRow row = Product_Inventory_Grid.Rows[indexRow];

            if (showingSeedlings)
            {
                fill_productname_pi.Text = row.Cells["Variety Name"].Value.ToString();
                fill_productid_pi.Text = row.Cells["Seed ID"].Value.ToString();
                fill_quantity_pi.Text = row.Cells["Quantity(Kg)"].Value.ToString();
            }
            else
            {
                fill_productname_pi.Text = row.Cells["Product Name"].Value.ToString();
                fill_productid_pi.Text = row.Cells["Product ID"].Value.ToString();
                fill_quantity_pi.Text = row.Cells["Quantity in Kilograms"].Value.ToString();
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
            //made changes here (17) [4/6/2026 | 12:46 PM]
            string tableName = showingSeedlings ? "[User PI Seedling Inventory]" : "[User PI Product Inventory]";
            string query;

            if (showingSeedlings)
            {
                query = $"UPDATE {tableName} SET [Variety Name] = @P1, [Quantity(Kg)] = @P3 WHERE [Seed ID] = @P2";
            }
            else
            {
                query = $"UPDATE {tableName} SET [Product Name] = @P1, [Quantity in Kilograms] = @P3 WHERE [Product ID] = @P2";
            }

            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            command = new OleDbCommand(query, connection);

            command.Parameters.AddWithValue("@P1", fill_productname_pi.Text);
            command.Parameters.AddWithValue("@P3", Convert.ToInt32(fill_quantity_pi.Text));
            command.Parameters.AddWithValue("@P2", fill_productid_pi.Text); // ID for the WHERE clause

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Item updated successfully!");
                press_loadpi(sender, e); // Refresh grid
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update item. Error: " + ex.Message);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

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

            // Clear inputs to avoid mixing data from different tables
            fill_productname_pi.Clear();
            fill_productid_pi.Clear();
            fill_quantity_pi.Clear();
        }

        private void display_indicator_pi_Click(object sender, EventArgs e)
        {

        }
    }
}
