using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class User_TransactionSheet : Form
    {
        private static User_TransactionSheet instance;
        int originalQtyFromCell;
        public User_TransactionSheet()
        {
            InitializeComponent();
            choices_from_database();
            refreshreload();
        }

        //(Global User Session) Component
        internal static User_TransactionSheet Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new User_TransactionSheet();

                return instance;
            }
        }

        OleDbConnection? connection;
        OleDbDataAdapter? adapterOne, adapterTwo;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;

        string currentSelectedRollNumber;
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void shortcut_DigitalReceiptVault(object sender, EventArgs e)
        {
            try
            {
                User_DigitalReceiptVault.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Digital Receipt Vault page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void shortcut_CostOfProduction(object sender, EventArgs e)
        {
            try
            {
                User_CostofProduction.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Cost of Production page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void shortcut_MarketForecasting(object sender, EventArgs e)
        {
            try
            {
                User_MarketForecast.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Market Forecast page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backButton(object sender, EventArgs e)
        {
            try
            {
                UserTradesandTransactions.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void press_insertts(object sender, EventArgs e)
        {
            string ReferenceID = referenceID();
            string dbPath = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Pananom Database\Prooject Pananom Data.accdb";

            using (OleDbConnection connected = new OleDbConnection(dbPath))
            {
                try
                {
                    connected.Open();

                    // 1. VALIDATION: Check if the Product exists in [User PI Product Inventory] first
                    string checkQuery = "SELECT [Quantity in Kilograms] FROM [User PI Product Inventory] WHERE [Product ID] = ? AND [User ID] = ?";
                    int currentStock = 0;

                    using (OleDbCommand cmdCheck = new OleDbCommand(checkQuery, connected))
                    {
                        cmdCheck.Parameters.Add("?", OleDbType.VarWChar).Value = fill_productid_ts.Text.Trim();
                        cmdCheck.Parameters.Add("?", OleDbType.Integer).Value = UserSession.UserInstance.ID;

                        object result = cmdCheck.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("Error: Product ID '" + fill_productid_ts.Text + "' was not found in your Inventory. Please check the ID and try again.", "ID Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Stop the process
                        }
                        currentStock = Convert.ToInt32(result);
                    }

                    // 2. STOCK CHECK: Ensure they aren't buying more than what is available
                    int orderQty = Convert.ToInt32(fill_quantity_ts.Text);
                    if (orderQty > currentStock)
                    {
                        MessageBox.Show($"Insufficient Stock! Available: {currentStock}kg. You requested: {orderQty}kg.", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // 3. EXECUTE TRANSACTION INSERT (Table: [User T&T Transaction])
                    string insertQuery = "INSERT INTO [User T&T Transaction] ([Customer Name], [Rice Type], [Product ID], [Price per Kilogram], [Quantity in Kilogram], [Delivery Date], [Reference ID], [User ID], [Destination], [Region], [Date Made]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmdInsert = new OleDbCommand(insertQuery, connected))
                    {
                        cmdInsert.Parameters.Add("?", OleDbType.VarWChar).Value = fill_customername_ts.Text;
                        cmdInsert.Parameters.Add("?", OleDbType.VarWChar).Value = fill_ricetype_ts.Text;
                        cmdInsert.Parameters.Add("?", OleDbType.VarWChar).Value = fill_productid_ts.Text.Trim();
                        cmdInsert.Parameters.Add("?", OleDbType.Currency).Value = Convert.ToDecimal(fill_priceperkg_ts.Text);
                        cmdInsert.Parameters.Add("?", OleDbType.Integer).Value = orderQty;
                        cmdInsert.Parameters.Add("?", OleDbType.Date).Value = fill_date_ts.Value;
                        cmdInsert.Parameters.Add("?", OleDbType.VarWChar).Value = ReferenceID;
                        cmdInsert.Parameters.Add("?", OleDbType.Integer).Value = UserSession.UserInstance.ID;
                        cmdInsert.Parameters.Add("?", OleDbType.VarWChar).Value = fill_destination_tr.Text;
                        cmdInsert.Parameters.Add("?", OleDbType.VarWChar).Value = fill_region_tr.Text;
                        cmdInsert.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now;
                        cmdInsert.ExecuteNonQuery();
                    }

                    // 4. EXECUTE INVENTORY UPDATE (Table: [User PI Product Inventory])
                    string updateInvQuery = "UPDATE [User PI Product Inventory] SET [Quantity in Kilograms] = [Quantity in Kilograms] - ? WHERE [Product ID] = ? AND [User ID] = ?";

                    using (OleDbCommand cmdUpdateInv = new OleDbCommand(updateInvQuery, connected))
                    {
                        cmdUpdateInv.Parameters.Add("?", OleDbType.Integer).Value = orderQty;
                        cmdUpdateInv.Parameters.Add("?", OleDbType.VarWChar).Value = fill_productid_ts.Text.Trim();
                        cmdUpdateInv.Parameters.Add("?", OleDbType.Integer).Value = UserSession.UserInstance.ID;
                        cmdUpdateInv.ExecuteNonQuery();
                    }

                    // 5. AUTO-DELETE 0 STOCK
                    string cleanupQuery = "DELETE FROM [User PI Product Inventory] WHERE [Quantity in Kilograms] <= 0";
                    using (OleDbCommand cmdClean = new OleDbCommand(cleanupQuery, connected))
                    {
                        cmdClean.ExecuteNonQuery();
                    }

                    refreshreload();
                    choices_from_database();

                    // Success Handlers
                    MessageBox.Show("Transaction Completed! Inventory has been updated.", "Success");

                    // Notifications and Refresh
                    await GlobalEmailNotificationModule.send_Notification(UserSession.UserInstance.Email, "Transaction Confirmed!", $"Order for {orderQty}kg processed.");

                    
                    ClearTransactionInputs();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void ClearTransactionInputs()
        {
            fill_customername_ts.Clear();

            // Resets the ComboBox selection
            if (fill_ricetype_ts.DataSource != null)
            {
                fill_ricetype_ts.SelectedIndex = -1;
            }
            else
            {
                fill_ricetype_ts.Text = string.Empty;
            }

            fill_productid_ts.Clear();
            fill_quantity_ts.Clear();
            fill_priceperkg_ts.Clear();
            fill_destination_tr.Clear();
            fill_region_tr.SelectedIndex = -1;

            // Optional: Reset the date to today
            fill_date_ts.Value = DateTime.Now;
        }

        private void fill_ricetype_ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if an item is actually selected and not null
            if (fill_ricetype_ts.SelectedIndex != -1 && fill_ricetype_ts.SelectedValue != null)
            {
                try
                {
                    // Since ValueMember was set to "Product ID", SelectedValue gives us exactly that
                    fill_productid_ts.Text = fill_ricetype_ts.SelectedValue.ToString();
                }
                catch (Exception ex)
                {
                    // Optional: silent fail or log error if the value isn't a string
                    Console.WriteLine("Error mapping Product ID: " + ex.Message);
                }
            }
            else
            {
                // Clear the Product ID if the user clears the ComboBox
                fill_productid_ts.Clear();
            }
        }

        private void press_deletets(object sender, EventArgs e)
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
                string query = "DELETE FROM [User T&T Transaction] WHERE [Item Number] = @P1";

                command = new OleDbCommand(query, connection);
                command.Parameters.Add("@P1", OleDbType.Integer).Value = Convert.ToInt32(currentSelectedRollNumber);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Transaction item deleted successfully!");

                    refreshreload();

                    fill_customername_ts.Clear();
                    fill_ricetype_ts.SelectedIndex = -1;
                    fill_productid_ts.Clear();
                    fill_quantity_ts.Clear();
                    fill_priceperkg_ts.Clear();
                    fill_date_ts.Value = DateTime.Now;
                    display_referenceid_ts.Text = " ";
                    currentSelectedRollNumber = " ";
                    fill_destination_tr.Clear();
                    fill_region_tr.SelectedIndex = -1;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete item. Error: " + ex.Message);
                }
            }
        }

        private void press_updatets(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");

            // SQL ORDER: 1:Item Name, 2:Unit, 3:Quantity, 4:Price, 5:Total, 6:Date, 7:Status WHERE 8:ID
            string query = "UPDATE [User T&T Transaction] SET [Customer Name] = @P1, [Rice Type] = @P2, [Product ID] = @P3, [Price per Kilogram] = @P4, [Quantity in Kilogram] = @P5, [Delivery Date] = @P6, [Reference ID] = @P7, [Destination] = @P8, [Region] = @P9  WHERE [Item Number] = @P10";


            // Use UNIQUE parameter names and follow the SQL order exactly
            command.Parameters.Add("@P1", OleDbType.VarWChar).Value = fill_customername_ts.Text;
            command.Parameters.Add("@P2", OleDbType.VarWChar).Value = fill_ricetype_ts.Text;
            command.Parameters.Add("@P3", OleDbType.VarWChar).Value = fill_productid_ts.Text;
            command.Parameters.Add("@P4", OleDbType.Currency).Value = Convert.ToDecimal(fill_priceperkg_ts.Text);
            command.Parameters.Add("@P5", OleDbType.Integer).Value = Convert.ToInt32(fill_quantity_ts.Text);
            command.Parameters.Add("@P6", OleDbType.Date).Value = fill_date_ts.Value;
            command.Parameters.Add("@P7", OleDbType.Date).Value = referenceID();
            command.Parameters.Add("@P8", OleDbType.Date).Value = fill_destination_tr.Text;
            command.Parameters.Add("@P9", OleDbType.VarWChar).Value = fill_region_tr.Text;
            command.Parameters.Add("@P10", OleDbType.Date).Value = UserSession.UserInstance.ID;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Transaction made updated successfully!");
                refreshreload();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update transaction. Error: " + ex.Message);
            }
        }

        private void refreshreload()
        {
            string dbPath = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";
            connection = new OleDbConnection(dbPath);

            string inventoryQuery = "SELECT * FROM [User PI Product Inventory] WHERE [User ID] = @UserID";
            string transactionQuery = "SELECT * FROM [User T&T Transaction] WHERE [User ID] = @UserID";

            adapterOne = new OleDbDataAdapter(inventoryQuery, connection);
            adapterOne.SelectCommand.Parameters.AddWithValue("@UserID", UserSession.UserInstance.ID);

            adapterTwo = new OleDbDataAdapter(transactionQuery, connection);
            adapterTwo.SelectCommand.Parameters.AddWithValue("@UserID", UserSession.UserInstance.ID);

            try
            {
                connection.Open();
                dataSet = new DataSet();
                adapterOne.Fill(dataSet, "Inventory");
                adapterTwo.Fill(dataSet, "Transactions");
                connection.Close();

                DataTable dtInv = dataSet.Tables["Inventory"];
                DataTable dtTrans = dataSet.Tables["Transactions"];

                // --- 1. PROCESS INVENTORY GRID ---
                if (!dtInv.Columns.Contains("Estimated Sacks")) dtInv.Columns.Add("Estimated Sacks", typeof(string));
                foreach (DataRow row in dtInv.Rows)
                {
                    if (row["Quantity in Kilograms"] != DBNull.Value)
                    {
                        double kgs = Convert.ToDouble(row["Quantity in Kilograms"]);
                        row["Estimated Sacks"] = (kgs / 50.0).ToString("N2") + " sacks";
                    }
                }
                Product_Inventory_Grid.DataSource = dtInv;

                // --- 2. PROCESS TRANSACTION GRID & DASHBOARD TOTALS ---
                if (!dtTrans.Columns.Contains("Estimated Sacks")) dtTrans.Columns.Add("Estimated Sacks", typeof(string));

                double totalKgSum = 0;
                foreach (DataRow row in dtTrans.Rows)
                {
                    if (row["Quantity in Kilogram"] != DBNull.Value)
                    {
                        double kgs = Convert.ToDouble(row["Quantity in Kilogram"]);
                        totalKgSum += kgs; // Summing for dashboard
                        row["Estimated Sacks"] = (kgs / 50.0).ToString("N2") + " sacks";
                    }
                }
                Transaction_Sheet_Grid.DataSource = dtTrans;

                // --- 3. UPDATE DASHBOARD LABELS ---
                display_kg_gg.Text = totalKgSum.ToString("N2") + " kg";
                display_sack_gg.Text = (totalKgSum / 50.0).ToString("N2") + " sacks";

                // Apply Gold Bold Italic Styling
                var boldItalicFont = new Font(display_kg_gg.Font, FontStyle.Bold | FontStyle.Italic);
                display_kg_gg.Font = boldItalicFont;
                display_sack_gg.Font = boldItalicFont;
                display_sack_gg.ForeColor = Color.Gold;

                // --- 4. GRID FORMATTING AND COLUMN POSITIONING ---
                FormatGrid(Product_Inventory_Grid, "Quantity in Kilograms");
                FormatGrid(Transaction_Sheet_Grid, "Quantity in Kilogram");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }

        // Helper method to keep the code clean and handle positioning
        private void FormatGrid(DataGridView grid, string qtyColumnName)
        {
            grid.DefaultCellStyle.ForeColor = Color.Black;

            if (grid.Columns.Contains("User ID")) grid.Columns["User ID"].Visible = false;
            if (grid.Columns.Contains("Roll Number")) grid.Columns["Roll Number"].Visible = false;
            if (grid.Columns.Contains("Item Number")) grid.Columns["Item Number"].Visible = false;

            if (grid.Columns.Contains("Estimated Sacks"))
            {
                // Move Estimated Sacks beside the Kilogram column
                grid.Columns["Estimated Sacks"].DisplayIndex = grid.Columns[qtyColumnName].DisplayIndex + 1;
                grid.Columns["Estimated Sacks"].HeaderText = "Est. Sacks (50kg)";
                grid.Columns["Estimated Sacks"].DefaultCellStyle.ForeColor = Color.DarkBlue;
            }

            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private string referenceID()
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

            return "TRANSREF#-" + randomString;
        }

        private void tradsactionsheetCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Transaction_Sheet_Grid.Rows[e.RowIndex];
                currentSelectedRollNumber = row.Cells["Item Number"].Value?.ToString() ?? "";

                // Save this so we can calculate the inventory difference later
                if (row.Cells["Quantity in Kilogram"].Value != DBNull.Value)
                    originalQtyFromCell = Convert.ToInt32(row.Cells["Quantity in Kilogram"].Value);

                fill_customername_ts.Text = row.Cells["Customer Name"].Value?.ToString();
                fill_ricetype_ts.Text = row.Cells["Rice Type"].Value?.ToString();
                fill_productid_ts.Text = row.Cells["Product ID"].Value?.ToString();
                fill_priceperkg_ts.Text = row.Cells["Price per Kilogram"].Value?.ToString();
                fill_quantity_ts.Text = row.Cells["Quantity in Kilogram"].Value?.ToString();

                if (row.Cells["Delivery Date"].Value != DBNull.Value)
                    fill_date_ts.Value = Convert.ToDateTime(row.Cells["Delivery Date"].Value);
                else
                    fill_date_ts.Value = DateTime.Now;
            }
        }

        private void productinventoryCellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loadButton(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            adapterOne = new OleDbDataAdapter("SELECT * FROM [User PI Product Inventory]", connection);
            adapterTwo = new OleDbDataAdapter("SELECT * FROM [User T&T Transaction]", connection);

            try
            {
                connection.Open();

                dataSet = new DataSet();

                adapterOne.Fill(dataSet, "[User PI Product Inventory]");
                adapterTwo.Fill(dataSet, "[User T&T Transaction]");

                connection.Close();

                Product_Inventory_Grid.DataSource = dataSet.Tables["[User PI Product Inventory]"];
                Transaction_Sheet_Grid.DataSource = dataSet.Tables["[User T&T Transaction]"];

                if (Product_Inventory_Grid.Columns.Contains("Roll Number"))
                    Product_Inventory_Grid.Columns["Roll Number"].Visible = false;

                Product_Inventory_Grid.Columns["Roll Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Product_Inventory_Grid.Columns["Product Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Product_Inventory_Grid.Columns["Reference ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Product_Inventory_Grid.Columns["Product ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Product_Inventory_Grid.Columns["Quantity in Kilograms"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                if (Transaction_Sheet_Grid.Columns.Contains("Item Number"))
                    Transaction_Sheet_Grid.Columns["Item Number"].Visible = false;

                Transaction_Sheet_Grid.Columns["Item Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Transaction_Sheet_Grid.Columns["Customer Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Transaction_Sheet_Grid.Columns["Rice Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Transaction_Sheet_Grid.Columns["Product ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Transaction_Sheet_Grid.Columns["Price per Kilogram"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Transaction_Sheet_Grid.Columns["Quantity in Kilogram"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Transaction_Sheet_Grid.Columns["Delivery Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Transaction_Sheet_Grid.Columns["Reference ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }

        private void choices_from_database()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

            string query = "SELECT [Product ID], [Product Name] & ' ' & [Product ID] AS FullDisplay " +
                           "FROM [User PI Product Inventory] " +
                           "WHERE [User ID] = @UserID";

            using (OleDbConnection connected = new OleDbConnection(connectionString))
            {
                OleDbDataAdapter newAdapter = new OleDbDataAdapter(query, connected);

                newAdapter.SelectCommand.Parameters.AddWithValue("@UserID", UserSession.UserInstance.ID);

                DataTable newTable = new DataTable();

                try
                {
                    connected.Open();
                    newAdapter.Fill(newTable);

                    fill_ricetype_ts.DataSource = newTable;
                    fill_ricetype_ts.DisplayMember = "FullDisplay";
                    fill_ricetype_ts.ValueMember = "Product ID";

                    // Keeps the box empty until the user picks something
                    fill_ricetype_ts.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading filtered rice types: " + ex.Message);
                }
            }
        }

        private void GoToUserTransactionAnalytics(object sender, EventArgs e)
        {
            var analyticsForm = User_TransactionSheetAnalytics.Instance;
            analyticsForm.Show();
        }
    }
}
