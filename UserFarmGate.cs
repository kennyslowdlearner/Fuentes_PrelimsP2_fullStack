using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class farmgateUSER : Form
    {

        private static farmgateUSER instance;

        public farmgateUSER()
        {
            InitializeComponent();
            this.Load += (s, e) => { if (this.Visible) refreshreload(); };
            LoadProductIDs();
        }

        internal static farmgateUSER Instance
        {
            get
            {
                // Add a check to see if the instance is actually null or was closed
                if (instance == null || instance.IsDisposed)
                {
                    instance = new farmgateUSER();
                }
                return instance;
            }
        }

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;

        internal string currentSelectedRollNumber = " ";

        private void farmgateUser_Load(object sender, EventArgs e)
        {
            string name_in_session = UserSession.UserInstance.FirstName + " " + UserSession.UserInstance.MiddleName + " " + UserSession.UserInstance.LastName;

        }
        private void backoptionFPG_Click(object sender, EventArgs e)
        {
            UserAccount.Instance.Show();
            this.Hide();
        }

        private void logoutoptionFPG_Click(object sender, EventArgs e)
        {
            Homepageee homepage = new Homepageee();
            homepage.Show();
            this.Hide();

        }

        private void farmgateUSER_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void backoptionFPG_Click_1(object sender, EventArgs e)
        {
            UserAccount useraccount = new UserAccount();
            useraccount.Show();
            this.Hide();
        }

        private void logoutoptionFPG_Click_1(object sender, EventArgs e)
        {
            Homepageee homepage = new Homepageee();
            homepage.Show();
            this.Hide();
        }

        private void display_prices_fgp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Farmgate_Prices_Grid.Rows[e.RowIndex];

                // This links the Grid back to your 'currentSelectedRollNumber' variable
                currentSelectedRollNumber = row.Cells["Roll Number"].Value?.ToString() ?? "";

                fill_productid_fgp.Text = row.Cells["Product ID"].Value?.ToString();
                fill_productname_fgp.Text = row.Cells["Product Name"].Value?.ToString();
                fill_quantity_fgp.Text = row.Cells["Quantity (Kg)"].Value?.ToString();
                fill_price_fgp.Text = row.Cells["Price per Kilogram"].Value?.ToString();
            }
        }

        private void refreshreload()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Pananom Database\Prooject Pananom Data.accdb";

            try
            {
                using (OleDbConnection connected = new OleDbConnection(connectionString))
                {
                    string query = "SELECT * FROM [User Farmgate Price] WHERE [User ID] = @UID";
                    adapter = new OleDbDataAdapter(query, connected);
                    adapter.SelectCommand.Parameters.AddWithValue("@UID", UserSession.UserInstance.ID);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // 1. Add Calculated Column for Sacks in the Grid
                    if (!dataTable.Columns.Contains("Estimated Sacks"))
                    {
                        dataTable.Columns.Add("Estimated Sacks", typeof(string));
                    }

                    // Variables for Dashboard Totals
                    double totalKgSum = 0;

                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Quantity (Kg)"] != DBNull.Value)
                        {
                            double kgs = Convert.ToDouble(row["Quantity (Kg)"]);
                            totalKgSum += kgs; // Accumulate for total KG

                            double sacks = kgs / 50.0;
                            row["Estimated Sacks"] = sacks.ToString("N2") + " sacks";
                        }
                    }

                    // 2. Update Dashboard Summary Labels
                    double totalSacksSum = totalKgSum / 50.0;

                    display_kg_gg.Text = totalKgSum.ToString("N2") + " kg";
                    display_sack_gg.Text = totalSacksSum.ToString("N2") + " sacks";

                    // Apply consistent Bold Italic Gold styling
                    var boldItalicFont = new Font(display_kg_gg.Font, FontStyle.Bold | FontStyle.Italic);
                    display_kg_gg.Font = boldItalicFont;
                    display_sack_gg.Font = boldItalicFont;
                    display_sack_gg.ForeColor = Color.Gold;

                    // 3. Reset and Bind Grid
                    Farmgate_Prices_Grid.DataSource = null;
                    Farmgate_Prices_Grid.DataSource = dataTable;
                    Application.DoEvents();
                }

                // 4. Formatting the DataGrid Columns
                if (Farmgate_Prices_Grid.Columns.Count > 0)
                {
                    foreach (DataGridViewColumn col in Farmgate_Prices_Grid.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    }

                    // Position Estimated Sacks beside Quantity
                    if (Farmgate_Prices_Grid.Columns.Contains("Estimated Sacks"))
                    {
                        Farmgate_Prices_Grid.Columns["Estimated Sacks"].DisplayIndex = Farmgate_Prices_Grid.Columns["Quantity (Kg)"].DisplayIndex + 1;
                        Farmgate_Prices_Grid.Columns["Estimated Sacks"].HeaderText = "Est. Sacks (50kg)";
                        Farmgate_Prices_Grid.Columns["Estimated Sacks"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        Farmgate_Prices_Grid.Columns["Estimated Sacks"].DefaultCellStyle.ForeColor = Color.DarkBlue;
                    }

                    if (Farmgate_Prices_Grid.Columns.Contains("Product Name"))
                    {
                        Farmgate_Prices_Grid.Columns["Product Name"].Visible = true;
                        Farmgate_Prices_Grid.Columns["Product Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        Farmgate_Prices_Grid.Columns["Product Name"].MinimumWidth = 300;
                    }

                    if (Farmgate_Prices_Grid.Columns.Contains("Roll Number"))
                        Farmgate_Prices_Grid.Columns["Roll Number"].Visible = false;

                    if (Farmgate_Prices_Grid.Columns.Contains("User ID"))
                        Farmgate_Prices_Grid.Columns["User ID"].Visible = false;

                    // Apply formatting to currency and numeric fields
                    if (Farmgate_Prices_Grid.Columns.Contains("Price per Kilogram"))
                        Farmgate_Prices_Grid.Columns["Price per Kilogram"].DefaultCellStyle.Format = "₱#,##0.00";

                    string[] autoFields = { "Product ID", "Quantity (Kg)", "Price per Kilogram", "Reference ID" };
                    foreach (string field in autoFields)
                    {
                        if (Farmgate_Prices_Grid.Columns.Contains(field))
                            Farmgate_Prices_Grid.Columns[field].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }


        private void press_loadfgp(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            adapter = new OleDbDataAdapter("SELECT * FROM [User Farmgate Price] WHERE [User ID] = @A1", connection);

            adapter.SelectCommand.Parameters.AddWithValue("A1", UserSession.UserInstance.ID);

            try
            {
                connection.Open();

                dataSet = new DataSet();

                adapter.Fill(dataSet, "[User Farmgate Price]");

                connection.Close();

                Farmgate_Prices_Grid.DataSource = dataSet.Tables["[User Farmgate Price]"];

                if (Farmgate_Prices_Grid.Columns.Contains("Roll Number"))
                    Farmgate_Prices_Grid.Columns["Roll Number"].Visible = false;

                Farmgate_Prices_Grid.Columns["Product ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Farmgate_Prices_Grid.Columns["Product Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Farmgate_Prices_Grid.Columns["Price per Kilogram"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Farmgate_Prices_Grid.Columns["Reference ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                if (Farmgate_Prices_Grid.Columns.Contains("User ID"))
                    Farmgate_Prices_Grid.Columns["User ID"].Visible = false;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }

        private void press_Searchfgp(object sender, EventArgs e)
        {
            string connect = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

            string query = "SELECT * FROM [User Farmgate Price] WHERE [Product Name] LIKE @S1 OR [Product ID] LIKE @S2 OR [Reference ID] LIKE @S3";

            using (OleDbConnection connected = new OleDbConnection(connect))
            {
                OleDbDataAdapter searchAdapter = new OleDbDataAdapter(query, connected);

                string searchTerm = "%" + fill_search_fgp.Text + "%";
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S1", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S2", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S3", searchTerm);

                DataSet searchNow = new DataSet();

                try
                {
                    connected.Open();
                    searchAdapter.Fill(searchNow, "[User Farmgate Price]");

                    Farmgate_Prices_Grid.DataSource = searchNow.Tables["[User Farmgate Price]"];
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Search failed. Error: " + ex.Message);
                }
            }
        }

        private void press_insert(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            string query = "INSERT INTO [User Farmgate Price] ([Product ID], [Product Name], [Quantity (Kg)], [Price per Kilogram], [Reference ID], [User ID]) VALUES (@P1, @P2, @P3, @P4, @P5, @P6)";

            command = new OleDbCommand(query, connection);
            command.Parameters.Add("@P1", OleDbType.VarWChar).Value = fill_productid_fgp.Text;
            command.Parameters.Add("@P2", OleDbType.VarWChar).Value = fill_productname_fgp.Text;
            command.Parameters.Add("@P3", OleDbType.Integer).Value = Convert.ToInt32(fill_quantity_fgp.Text);

            // This is correct as Currency because it's a price
            command.Parameters.Add("@P4", OleDbType.Currency).Value = Convert.ToDecimal(fill_price_fgp.Text);

            // CHANGE THIS LINE: Reference ID is a String (FRMGT-XXXX), not Currency
            command.Parameters.Add("@P5", OleDbType.VarWChar).Value = serialIDgenerator();

            command.Parameters.Add("@P6", OleDbType.Integer).Value = UserSession.UserInstance.ID;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Item added successfully!");

                // Clear fields
                fill_productname_fgp.Clear();
                fill_quantity_fgp.Clear();
                fill_price_fgp.Clear();
                fill_productid_fgp.SelectedIndex = -1;

                refreshreload();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add product. Error: " + ex.Message);
            }
        }

        private void press_update(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");

            // SQL ORDER: 1:Item Name, 2:Unit, 3:Quantity, 4:Price, 5:Total, 6:Date, 7:Status WHERE 8:ID
            string query = "UPDATE [User Farmgate Price] SET [Product ID] = @P1, [Product Name] = @P2, [Quantity (Kg)] = @P3, [Price per Kilogram] = @P4 WHERE [Roll Number] = @P5";

            command = new OleDbCommand(query, connection);

            // Use UNIQUE parameter names and follow the SQL order exactly
            command.Parameters.Add("@P1", OleDbType.VarWChar).Value = fill_productid_fgp.Text;
            command.Parameters.Add("@P2", OleDbType.VarWChar).Value = fill_productname_fgp.Text;
            command.Parameters.Add("@P3", OleDbType.Integer).Value = Convert.ToInt32(fill_quantity_fgp.Text);
            command.Parameters.Add("@P4", OleDbType.Currency).Value = Convert.ToDecimal(fill_price_fgp.Text);

            // The WHERE clause parameter must be last
            command.Parameters.Add("@P5", OleDbType.Integer).Value = Convert.ToInt32(currentSelectedRollNumber);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Item updated successfully!");
                refreshreload();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update item. Error: " + ex.Message);
            }
        }

        private string serialIDgenerator()
        {
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

            return "FRMGT-" + randomString;
        }

        private void press_delete(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentSelectedRollNumber))
            {
                MessageBox.Show("Please select an item to delete.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
                string query = "DELETE FROM [User Farmgate Price] WHERE [Roll Number] = @P1";

                command = new OleDbCommand(query, connection);
                command.Parameters.Add("@P1", OleDbType.Integer).Value = Convert.ToInt32(currentSelectedRollNumber);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Item deleted successfully!");

                    refreshreload();

                    fill_productname_fgp.Clear();
                    fill_productid_fgp.SelectedIndex = -1;
                    fill_quantity_fgp.Clear();
                    fill_price_fgp.Clear();

                    currentSelectedRollNumber = " ";
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete item. Error: " + ex.Message);
                }
            }
        }

        private void LoadProductIDs()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Pananom Database\Prooject Pananom Data.accdb";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                // We pull from the Inventory table, filtered by the current user
                string query = "SELECT [Product ID] FROM [User PI Product Inventory] WHERE [User ID] = @UID";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@UID", UserSession.UserInstance.ID);

                try
                {
                    conn.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    fill_productid_fgp.Items.Clear(); // Clear old items

                    while (reader.Read())
                    {
                        fill_productid_fgp.Items.Add(reader["Product ID"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading Product IDs: " + ex.Message);
                }
            }
        }

        private void back(object sender, EventArgs e)
        {
            try
            {
                UserAccount.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fill_productid_fgp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fill_productid_fgp.SelectedIndex == -1) return;

            string selectedID = fill_productid_fgp.SelectedItem.ToString();
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Pananom Database\Prooject Pananom Data.accdb";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                // Find the Name that matches the ID for this specific user
                string query = "SELECT [Product Name] FROM [User PI Product Inventory] WHERE [Product ID] = @PID AND [User ID] = @UID";
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@PID", selectedID);
                cmd.Parameters.AddWithValue("@UID", UserSession.UserInstance.ID);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar(); // ExecuteScalar is perfect for getting one single value

                    if (result != null)
                    {
                        fill_productname_fgp.Text = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error auto-filling product name: " + ex.Message);
                }
            }
        }
    }
}