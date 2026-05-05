using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class AdminTransportSchedule : Form
    {
        private static AdminTransportSchedule instance;
        public AdminTransportSchedule()
        {
            InitializeComponent();
            auto_reload();

            Admin_Transport_Schedule_Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        internal static AdminTransportSchedule Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new AdminTransportSchedule();
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
                AdminAccount.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void auto_reload()
        {
            try
            {
                // 1. Setup Connection - Pull all records
                connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
                string query = "SELECT * FROM [Admin - User Transport Schedule]"; // Simple query

                adapter = new OleDbDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                // 2. Process Status Updates
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Date Made"] != DBNull.Value && row["Trip Number"] != DBNull.Value)
                    {
                        int tripId = Convert.ToInt32(row["Trip Number"]);
                        DateTime dateMade = Convert.ToDateTime(row["Date Made"]);

                        // Use a safe check for the Status column
                        string currentStatus = row["Status"] != DBNull.Value ? row["Status"].ToString() : "";
                        string calculatedStatus = GetStatusByTime(dateMade);

                        // Update if it's not "Recognized" and not already the right status
                        if (currentStatus != "Recognized" && currentStatus != "Arrived at Consumer" && currentStatus != calculatedStatus)
                        {
                            UpdateStatusSilently(tripId, calculatedStatus);
                            row["Status"] = calculatedStatus;
                        }
                    }
                }

                // 3. Filter and Sort using DataView
                DataView dv = dt.DefaultView;

                // This filters out rows where you've set the status to "Recognized" manually
                dv.RowFilter = "Status <> 'Recognized' OR Status IS NULL";

                // Sort: We'll just sort by Date Made for now to keep it stable
                dv.Sort = "[Date Made] DESC";

                // 4. Bind the DataView (This fixes the Red X)
                Admin_Transport_Schedule_Grid.DataSource = null;
                Admin_Transport_Schedule_Grid.DataSource = dv;

                // UI Cleanup
                Admin_Transport_Schedule_Grid.RowHeadersVisible = false;
                Admin_Transport_Schedule_Grid.ClearSelection();

                // 4. Bind the DataView
                Admin_Transport_Schedule_Grid.DataSource = null;
                Admin_Transport_Schedule_Grid.DataSource = dv;

                // --- START OF COLUMN ADJUSTMENTS ---

                // 1. Set mode to None to allow manual pixel widths
                Admin_Transport_Schedule_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                // 2. Adjust individual widths (Adjust the numbers to fit your design)
                if (Admin_Transport_Schedule_Grid.Columns.Count > 0)
                {
                    // These names must match your Access Database field names exactly
                    Admin_Transport_Schedule_Grid.Columns["Trip Number"].Width = 60;
                    Admin_Transport_Schedule_Grid.Columns["Transport Name"].Width = 300;
                    Admin_Transport_Schedule_Grid.Columns["Driver"].Width = 250;
                    Admin_Transport_Schedule_Grid.Columns["License Number"].Width = 270;
                    Admin_Transport_Schedule_Grid.Columns["Delivery Code"].Width = 270;
                    Admin_Transport_Schedule_Grid.Columns["Place From"].Width = 400;
                    Admin_Transport_Schedule_Grid.Columns["Place To"].Width = 400;
                    Admin_Transport_Schedule_Grid.Columns["Estimated Time"].Width = 300;
                    Admin_Transport_Schedule_Grid.Columns["Status"].Width = 500;
                    Admin_Transport_Schedule_Grid.Columns["Date Made"].Width = 200;
                }

                // 3. Optional: Make them look cleaner
                Admin_Transport_Schedule_Grid.Columns["Date Made"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                Admin_Transport_Schedule_Grid.Columns["Estimated Time"].DefaultCellStyle.Format = "t"; // Shows just the time (e.g. 2:30 PM)

                // --- END OF COLUMN ADJUSTMENTS ---

                Admin_Transport_Schedule_Grid.RowHeadersVisible = false;
                Admin_Transport_Schedule_Grid.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Reload Error: " + ex.Message);
            }
        }

        private void UpdateStatusSilently(int tripId, string newStatus)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb"))
                {
                    conn.Open();
                    string sql = "UPDATE [Admin - User Transport Schedule] SET [Status] = @status WHERE [Trip Number] = @id";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@status", OleDbType.VarWChar).Value = newStatus;
                        cmd.Parameters.Add("@id", OleDbType.Integer).Value = tripId;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { /* Fail silently during background updates */ }
        }

        private void press_add(object sender, EventArgs e)
        {

            try
            {
                using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb"))
                {
                    conn.Open();

                    string query = "INSERT INTO [Admin - User Transport Schedule] ([Transport Name], [Driver], [License Number], [Delivery Code], [Place From], [Place To], [Estimated Time], [Status], [Date Made]) " +
                                   "VALUES (@P1, @P2, @P3, @P4, @P5, @P6, @P7, @P8, @P9)";

                    using (OleDbCommand command = new OleDbCommand(query, conn))
                    {
                        // Add parameters in the EXACT order they appear in the query
                        command.Parameters.Add("@P1", OleDbType.VarWChar).Value = fill_transportname_ats.Text;
                        command.Parameters.Add("@P2", OleDbType.VarWChar).Value = fill_driver_ats.Text;
                        command.Parameters.Add("@P3", OleDbType.VarWChar).Value = fill_licensenumber_ats.Text;
                        command.Parameters.Add("@P4", OleDbType.VarWChar).Value = fill_deliverycode_ats.Text;
                        command.Parameters.Add("@P5", OleDbType.VarWChar).Value = fill_placefrom_ats.Text;
                        command.Parameters.Add("@P6", OleDbType.VarWChar).Value = fill_placeto_ats.Text;


                        DateTime eta = DateTime.Now.AddHours(2);
                        command.Parameters.Add("@P7", OleDbType.Date).Value = eta;

                        // METHOD: Initial Status
                        command.Parameters.Add("@P8", OleDbType.VarWChar).Value = "Courier is preparing to pick up rice";

                        // SYNTAX CHECK: DateTime.Now is perfect here
                        command.Parameters.Add("@P9", OleDbType.Date).Value = DateTime.Now;


                        command.ExecuteNonQuery();
                        MessageBox.Show("Transportation saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Refresh your grids so the new data shows up in the rankings
                auto_reload();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }

        private void UpdateCourierStatus(int tripId, string newStatus)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb"))
                {
                    conn.Open();
                    string sql = "UPDATE [Admin - User Transport Schedule] SET [Status] = @status WHERE [Trip Number] = @id";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@status", OleDbType.VarWChar).Value = newStatus;
                        cmd.Parameters.Add("@id", OleDbType.Integer).Value = tripId;
                        cmd.ExecuteNonQuery();
                    }
                }
                auto_reload(); // Refresh to reflect changes (and hide 'Recognized' items)
            }
            catch (Exception ex) { MessageBox.Show("Update Error: " + ex.Message); }
        }

        private void press_recognized(object sender, EventArgs e)
        {
            if (Admin_Transport_Schedule_Grid.SelectedRows.Count > 0)
            {
                // Get the ID from the selected row
                int tripId = Convert.ToInt32(Admin_Transport_Schedule_Grid.SelectedRows[0].Cells["Trip Number"].Value);

                // Update the STATUS value to "Recognized"
                UpdateStatusSilently(tripId, "Recognized");

                // Reload to hide it
                auto_reload();
            }
        }

        private void dynamic_cellformatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 1. Safety checks to prevent the Red X
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (Admin_Transport_Schedule_Grid.Columns[e.ColumnIndex].Name != "Status") return;
            if (e.Value == null || e.Value == DBNull.Value) return;

            string status = e.Value.ToString();

            // 2. Apply Colors
            if (status == "Courier Arrived for Pickup")
            {
                e.CellStyle.BackColor = Color.Yellow;
                e.CellStyle.ForeColor = Color.Black;
            }
            else if (status == "Arrived at Consumer")
            {
                e.CellStyle.BackColor = Color.DeepSkyBlue;
                e.CellStyle.ForeColor = Color.White;
            }
        }

        // Optional: Logic to determine status based on elapsed time
        private string GetStatusByTime(DateTime dateMade)
        {
            TimeSpan elapsed = DateTime.Now - dateMade;
            if (elapsed.TotalMinutes > 60) return "Arrived at Consumer";
            if (elapsed.TotalMinutes > 30) return "In Transit - Courier is heading to destination.";
            if (elapsed.TotalMinutes > 15) return "Courier Arrived for Pickup"; // Turns Yellow
            return "Courier is preparing to pick up rice";
        }

        private void press_Delete(object sender, EventArgs e)
        {
            // Check if there is a current row selected via CellClick
            if (Admin_Transport_Schedule_Grid.CurrentRow != null)
            {
                int tripId = Convert.ToInt32(Admin_Transport_Schedule_Grid.CurrentRow.Cells["Trip Number"].Value);

                DialogResult confirm = MessageBox.Show("Delete this trip record permanently?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    ExecuteSql($"DELETE FROM [Admin - User Transport Schedule] WHERE [Trip Number] = {tripId}");

                    // Clear textboxes after deletion
                    fill_transportname_ats.Clear();
                    fill_driver_ats.Clear();

                    auto_reload();
                }
            }
            else
            {
                MessageBox.Show("Please click on a row first.");
            }
        }

        private void ExecuteSql(string sql)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb"))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
        }

        private void press_update(object sender, EventArgs e)
        {
            if (Admin_Transport_Schedule_Grid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please click a row in the table first.");
                return;
            }

            try
            {
                int tripId = Convert.ToInt32(Admin_Transport_Schedule_Grid.SelectedRows[0].Cells["Trip Number"].Value);

                using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb"))
                {
                    conn.Open();
                    string sql = "UPDATE [Admin - User Transport Schedule] SET " +
                                 "[Transport Name] = @name, [Driver] = @driver, [License Number] = @lic, " +
                                 "[Delivery Code] = @code, [Place From] = @from, [Place To] = @to " +
                                 "WHERE [Trip Number] = @id";

                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@name", OleDbType.VarWChar).Value = fill_transportname_ats.Text;
                        cmd.Parameters.Add("@driver", OleDbType.VarWChar).Value = fill_driver_ats.Text;
                        cmd.Parameters.Add("@lic", OleDbType.VarWChar).Value = fill_licensenumber_ats.Text;
                        cmd.Parameters.Add("@code", OleDbType.VarWChar).Value = fill_deliverycode_ats.Text;
                        cmd.Parameters.Add("@from", OleDbType.VarWChar).Value = fill_placefrom_ats.Text;
                        cmd.Parameters.Add("@to", OleDbType.VarWChar).Value = fill_placeto_ats.Text;
                        cmd.Parameters.Add("@id", OleDbType.Integer).Value = tripId;

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Trip updated successfully!", "Success");
                    }
                }
                auto_reload(); // Refresh the grid to show changes
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }
        }

        private void Admin_Transport_Schedule_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Admin_Transport_Schedule_Grid.Rows[e.RowIndex];

                // 1. Store the ID for Update/Delete operations
                // Trip Number is our Primary Key
                int tripId = Convert.ToInt32(row.Cells["Trip Number"].Value);

                // 2. Fill the TextBoxes
                fill_transportname_ats.Text = row.Cells["Transport Name"].Value?.ToString();
                fill_driver_ats.Text = row.Cells["Driver"].Value?.ToString();
                fill_licensenumber_ats.Text = row.Cells["License Number"].Value?.ToString();
                fill_deliverycode_ats.Text = row.Cells["Delivery Code"].Value?.ToString();
                fill_placefrom_ats.Text = row.Cells["Place From"].Value?.ToString();
                fill_placeto_ats.Text = row.Cells["Place To"].Value?.ToString();

                // Note: Status and Date are usually managed by the system, 
                // but you can add textboxes for them if needed.
            }
        }
    }
}
