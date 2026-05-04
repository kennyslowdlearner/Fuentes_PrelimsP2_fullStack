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
    public partial class User_RiceYieldandEstimation : Form
    {
        private static User_RiceYieldandEstimation instance;
        public User_RiceYieldandEstimation()
        {
            InitializeComponent();
            refreshreload();
        }

        //(Global User Session) Component
        internal static User_RiceYieldandEstimation Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new User_RiceYieldandEstimation();

                return instance;
            }
        }

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void shortcut_ProductInventory(object sender, EventArgs e)
        {
            try
            {
                productInventory.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Product Inventory page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void shortcut_SoilEvaluator(object sender, EventArgs e)
        {
            try
            {
                User_SoilEvaluator.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Soil Evaluator page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void shortcut_WeatherForecasting(object sender, EventArgs e)
        {
            try
            {
                User_WeatherForecast.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Weather Forecast page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void shortcut_ActivityLog(object sender, EventArgs e)
        {
            try
            {
                User_ActivityLog.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Activity Log page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backButton(object sender, EventArgs e)
        {
            try
            {
                RiceYieldEstimationandRegistry.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void press_insertrye(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            string query = "INSERT INTO [User RYR Rice Yield & Estimation] ([Rice Type], [Product ID], [Date Planted], [Quantity (Kg)], [Yielding Days], [Time Left], [User ID]) VALUES (@P1, @P2, @P3, @P4, @P5, @P6, @P7)";


            command = new OleDbCommand(query, connection);
            command.Parameters.Add("@P1", OleDbType.VarWChar).Value = fill_ricetype_rye.Text;
            command.Parameters.Add("@P2", OleDbType.VarWChar).Value = fill_productid_rye.Text;
            command.Parameters.Add("@P3", OleDbType.Date).Value = fill_date_rye.Text;
            command.Parameters.Add("@P4", OleDbType.Integer).Value = Convert.ToInt32(fill_quantity_rye.Text);
            command.Parameters.Add("@P5", OleDbType.VarWChar).Value = yieldingDays();
            command.Parameters.Add("@P6", OleDbType.VarWChar).Value = timeLeft();

            command.Parameters.Add("@P7", OleDbType.Integer).Value = UserSession.UserInstance.ID;


            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Item added successfully!");

                fill_ricetype_rye.SelectedIndex = -1;
                fill_productid_rye.SelectedIndex = -1;
                fill_date_rye.Value = DateTime.Now;
                fill_quantity_rye.Clear();
                display_yieldingdays_rye.Text = " ";
                display_timeleft_rye.Text = " ";
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to add product. Error: " + ex.Message);
            }
        }

        internal void refreshreload()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Pananom Database\Prooject Pananom Data.accdb";

            try
            {
                using (OleDbConnection connected = new OleDbConnection(connectionString))
                {
                    adapter = new OleDbDataAdapter("SELECT * FROM [User RYR Rice Yield & Estimation]", connected);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // 1. Force the grid to reset
                    Rice_Yield_And_Estimation_Grid.DataSource = null;
                    Rice_Yield_And_Estimation_Grid.AutoGenerateColumns = true;
                    Rice_Yield_And_Estimation_Grid.DataSource = dataTable;

                    // 2. Allow the UI thread to process the new columns
                    Application.DoEvents();
                }

                // 3. Apply formatting only if data was actually loaded
                if (Rice_Yield_And_Estimation_Grid.Columns.Count > 0)
                {
                    // Set all to None first to allow manual overrides
                    foreach (DataGridViewColumn col in Rice_Yield_And_Estimation_Grid.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    }

                    // Fix for the "Item Name" invisibility:
                    if (Rice_Yield_And_Estimation_Grid.Columns.Contains("Item Name"))
                    {
                        Rice_Yield_And_Estimation_Grid.Columns["Item Name"].Visible = true;
                        Rice_Yield_And_Estimation_Grid.Columns["Item Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        Rice_Yield_And_Estimation_Grid.Columns["Item Name"].MinimumWidth = 300; // Ensure it stays visible
                    }

                    // Hide the database ID
                    if (Rice_Yield_And_Estimation_Grid.Columns.Contains("Item Number"))
                        Rice_Yield_And_Estimation_Grid.Columns["Item Number"].Visible = false;

                    // Batch update the rest of the cells
                    string[] autoFields = { "Unit", "Quantity", "Status", "Price per unit", "Total", "Date of purchase", "Serial Number" };
                    foreach (string field in autoFields)
                    {
                        if (Rice_Yield_And_Estimation_Grid.Columns.Contains(field))
                        {
                            Rice_Yield_And_Estimation_Grid.Columns[field].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }

        private void press_updaterye(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");

            // SQL ORDER: 1:Item Name, 2:Unit, 3:Quantity, 4:Price, 5:Total, 6:Date, 7:Status WHERE 8:ID
            string query = "UPDATE [User RYR Rice Yield & Estimation] SET [Rice Type] = @P1, [Product ID] = @P2, [Date Planted] = @P3, [Quantity (Kg)] = @P4, [Yielding Days] = @P5, [Time Left] = @P6 WHERE [User ID] = @P8";

            command = new OleDbCommand(query, connection);

            // Use UNIQUE parameter names and follow the SQL order exactly
            command.Parameters.Add("@P1", OleDbType.VarWChar).Value = fill_ricetype_rye.Text;
            command.Parameters.Add("@P2", OleDbType.VarWChar).Value = fill_productid_rye.Text;
            command.Parameters.Add("@P6", OleDbType.Date).Value = fill_date_rye.Value;
            command.Parameters.Add("@P3", OleDbType.Integer).Value = Convert.ToInt32(fill_quantity_rye.Text);
            command.Parameters.Add("@P2", OleDbType.VarWChar).Value = yieldingDays();
            command.Parameters.Add("@P2", OleDbType.VarWChar).Value = timeLeft();
            command.Parameters.Add("@P3", OleDbType.Integer).Value = UserSession.UserInstance.ID;

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

        private void press_deleterye(object sender, EventArgs e)
        {
            // Check if a row is actually selected in the Grid
            if (Rice_Yield_And_Estimation_Grid.CurrentRow != null)
            {
                // Get the Item Number from the selected row
                // Using "Item Number" because it's your unique ID in the database
                string itemID = Rice_Yield_And_Estimation_Grid.CurrentRow.Cells["Item Number"].Value.ToString();

                // Ask for confirmation before deleting
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this estimation record?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
                    string query = "DELETE FROM [User RYR Rice Yield & Estimation] WHERE [Item Number] = @P1";

                    command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@P1", itemID);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                        MessageBox.Show("Record deleted successfully!");

                        // Refresh the grid and stats
                        refreshreload();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to delete record. Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a record from the table first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string yieldingDays()
        {
            // Convert to lowercase to ensure the switch case matches regardless of user input casing
            string riceType = fill_ricetype_rye.Text.ToLower().Trim();

            // Standard days from planting to harvest for common Philippine rice varieties
            switch (riceType)
            {
                case "hybrid rice":
                case "sl-8h":
                    return "110";
                case "inbred rice":
                case "rc160":
                    return "120";
                case "sinandomeng":
                    return "115";
                case "dinorado":
                    return "125";
                case "jasmine rice":
                    return "130";
                case "angelica":
                    return "115";
                case "rc222": // Known as "Triple 2"
                    return "114";
                case "nsic rc216":
                    return "112";
                case "malagkit":
                    return "135";
                case "brown rice":
                    return "150";
                default:
                    return "120"; // Standard fallback for unspecified types
            }
        }

        private string timeLeft()
        {
            if (int.TryParse(yieldingDays(), out int totalDays))
            {
                DateTime datePlanted = fill_date_rye.Value;
                DateTime harvestDate = datePlanted.AddDays(totalDays);
                TimeSpan difference = harvestDate - DateTime.Now;

                int daysRemaining = (int)Math.Ceiling(difference.TotalDays);

                if (daysRemaining <= 0)
                    return "Ready for Harvest";

                return daysRemaining.ToString() + " Days";
            }
            return "Unknown";
        }
    }
}
