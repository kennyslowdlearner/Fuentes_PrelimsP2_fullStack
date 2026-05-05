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
            LoadInventoryToComboBoxes();
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

        // Near your other declarations
        string currentSelectedItemNumber = "";
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
            if (fill_productid_rye.Focused && fill_productid_rye.SelectedIndex != -1)
            {
                // SelectedValue contains the "Product Name" because of our ValueMember setting
                fill_ricetype_rye.Text = fill_productid_rye.SelectedValue.ToString();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void press_insertrye(object sender, EventArgs e)
        {
            // Check if fields are empty before proceeding
            if (fill_ricetype_rye.SelectedIndex == -1 || string.IsNullOrEmpty(fill_quantity_rye.Text))
            {
                MessageBox.Show("Please select a rice variety and enter quantity.");
                return;
            }

            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            string query = "INSERT INTO [User RYR Rice Yield & Estimation] ([Rice Type], [Product ID], [Date Planted], [Quantity (Kg)], [Yielding Days], [Time Left], [User ID]) VALUES (@P1, @P2, @P3, @P4, @P5, @P6, @P7)";

            command = new OleDbCommand(query, connection);

            // Fetch values from the auto-filled ComboBoxes
            command.Parameters.Add("@P1", OleDbType.VarWChar).Value = fill_ricetype_rye.Text;
            command.Parameters.Add("@P2", OleDbType.VarWChar).Value = fill_productid_rye.Text;
            command.Parameters.Add("@P3", OleDbType.Date).Value = fill_date_rye.Value;
            command.Parameters.Add("@P4", OleDbType.Integer).Value = Convert.ToInt32(fill_quantity_rye.Text);
            command.Parameters.Add("@P5", OleDbType.VarWChar).Value = yieldingDays();
            command.Parameters.Add("@P6", OleDbType.VarWChar).Value = timeLeft();
            command.Parameters.Add("@P7", OleDbType.Integer).Value = UserSession.UserInstance.ID;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Plant logged successfully!");

                // Clear input fields for next entry
                fill_ricetype_rye.SelectedIndex = -1;
                fill_productid_rye.SelectedIndex = -1;
                fill_date_rye.Value = DateTime.Now;
                fill_quantity_rye.Clear();


                // CRITICAL: Refresh the grid to show the new record
                refreshreload();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to log plant. Error: " + ex.Message);
            }
        }


        internal void refreshreload()
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Pananom Database\Prooject Pananom Data.accdb";

            try
            {
                int currentUserID = UserSession.UserInstance.ID;

                using (OleDbConnection connected = new OleDbConnection(connectionString))
                {
                    // SYNCED: Using [Roll Number] instead of [Item Number]
                    string query = "SELECT [Roll Number], [Rice Type], [Product ID], [Date Planted], [Quantity (Kg)], [Yielding Days], [Time Left], [User ID] " +
                                   "FROM [User RYR Rice Yield & Estimation] WHERE [User ID] = @uid";

                    adapter = new OleDbDataAdapter(query, connected);
                    adapter.SelectCommand.Parameters.Clear();
                    adapter.SelectCommand.Parameters.AddWithValue("@uid", currentUserID);

                    DataTable dataTable = new DataTable();
                    connected.Open();
                    adapter.Fill(dataTable);
                    connected.Close();

                    Rice_Yield_And_Estimation_Grid.DataSource = null;
                    Rice_Yield_And_Estimation_Grid.DataSource = dataTable;
                }

                if (Rice_Yield_And_Estimation_Grid.Columns.Count > 0)
                {
                    Rice_Yield_And_Estimation_Grid.DefaultCellStyle.ForeColor = Color.Black;
                    Rice_Yield_And_Estimation_Grid.DefaultCellStyle.BackColor = Color.White;
                    Rice_Yield_And_Estimation_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Hiding primary keys from the UI
                    if (Rice_Yield_And_Estimation_Grid.Columns.Contains("Roll Number"))
                        Rice_Yield_And_Estimation_Grid.Columns["Roll Number"].Visible = false;

                    if (Rice_Yield_And_Estimation_Grid.Columns.Contains("User ID"))
                        Rice_Yield_And_Estimation_Grid.Columns["User ID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Display Error: " + ex.Message);
            }
        }

        private void LoadInventoryToComboBoxes()
        {
            // 1. Ensure the path to your Access database is correct
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Pananom Database\Prooject Pananom Data.accdb";

            // 2. Your SQL defines the available columns
            string query = "SELECT [Variety Name], [Seed ID] FROM [User PI Seedling Inventory] WHERE [User ID] = ?";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("?", UserSession.UserInstance.ID); // Filters by current user

                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // 3. Bind fill_productid_rye
                    // Display: What the user sees (Seed ID)
                    // Value: What the code uses to update the other box (Variety Name)
                    fill_productid_rye.DataSource = dt.Copy();
                    fill_productid_rye.DisplayMember = "Seed ID";     // MUST match SQL
                    fill_productid_rye.ValueMember = "Variety Name";  // MUST match SQL

                    // 4. Bind fill_ricetype_rye
                    // Display: What the user sees (Variety Name)
                    // Value: What the code uses to update the other box (Seed ID)
                    fill_ricetype_rye.DataSource = dt.Copy();
                    fill_ricetype_rye.DisplayMember = "Variety Name"; // MUST match SQL
                    fill_ricetype_rye.ValueMember = "Seed ID";        // MUST match SQL

                    // Reset selections to avoid accidental triggers
                    fill_productid_rye.SelectedIndex = -1;
                    fill_ricetype_rye.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading inventory: " + ex.Message);
                }
            }
        }
        private void press_updaterye(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentSelectedItemNumber))
            {
                MessageBox.Show("Please select a record from the table first.");
                return;
            }

            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");

            // SYNCED: Targeting [Roll Number]
            string query = "UPDATE [User RYR Rice Yield & Estimation] SET " +
                           "[Rice Type] = @p1, [Product ID] = @p2, [Date Planted] = @p3, " +
                           "[Quantity (Kg)] = @p4, [Yielding Days] = @p5, [Time Left] = @p6 " +
                           "WHERE [Roll Number] = @p7 AND [User ID] = @p8";

            command = new OleDbCommand(query, connection);

            // OLEDB parameters order: @p1 to @p8
            command.Parameters.Add("@p1", OleDbType.VarWChar).Value = fill_ricetype_rye.Text;
            command.Parameters.Add("@p2", OleDbType.VarWChar).Value = fill_productid_rye.Text;
            command.Parameters.Add("@p3", OleDbType.Date).Value = fill_date_rye.Value;
            command.Parameters.Add("@p4", OleDbType.Integer).Value = Convert.ToInt32(fill_quantity_rye.Text);
            command.Parameters.Add("@p5", OleDbType.VarWChar).Value = yieldingDays();
            command.Parameters.Add("@p6", OleDbType.VarWChar).Value = timeLeft();
            command.Parameters.Add("@p7", OleDbType.Integer).Value = Convert.ToInt32(currentSelectedItemNumber);
            command.Parameters.Add("@p8", OleDbType.Integer).Value = UserSession.UserInstance.ID;

            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                connection.Close();

                if (result > 0)
                {
                    MessageBox.Show("Record updated successfully!");
                    refreshreload();
                    currentSelectedItemNumber = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Failed: " + ex.Message);
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fill_ricetype_rye.Focused && fill_ricetype_rye.SelectedIndex != -1)
            {
                // SelectedValue contains the "Product ID" because of our ValueMember setting
                fill_productid_rye.Text = fill_ricetype_rye.SelectedValue.ToString();
            }
        }

        private void Rice_Yield_And_Estimation_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Rice_Yield_And_Estimation_Grid.Rows[e.RowIndex];

                // SYNCED: Using "Roll Number"
                currentSelectedItemNumber = row.Cells["Roll Number"].Value?.ToString() ?? "";

                // Filling the input controls
                fill_ricetype_rye.Text = row.Cells["Rice Type"].Value?.ToString();
                fill_productid_rye.Text = row.Cells["Product ID"].Value?.ToString();
                fill_quantity_rye.Text = row.Cells["Quantity (Kg)"].Value?.ToString();

                if (DateTime.TryParse(row.Cells["Date Planted"].Value?.ToString(), out DateTime plantedDate))
                {
                    fill_date_rye.Value = plantedDate;
                }
            }
        }
    }
}
