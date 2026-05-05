using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Fuentes_PrelimsP2
{
    public partial class User_VarietalRegistry : Form
    {
        private static User_VarietalRegistry instance;
        public User_VarietalRegistry()
        {
            InitializeComponent();
            refreshreload();
        }

        // Global User Session Component
        internal static User_VarietalRegistry Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new User_VarietalRegistry();

                return instance;
            }
        }

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;

        // Tracks the Roll Number of the selected record for updates
        string currentSelectedRollNumber = "";

        #region Navigation Shortcuts
        private void shortcut_RiceYieldandEstimation(object sender, EventArgs e)
        {
            try
            {
                User_RiceYieldandEstimation.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Rice Yield/Estimation page:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Failed to open Weather Forecast page:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Failed to open Activity Log page:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Failed to open Soil Evaluator page:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Failed to open page:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        // UPDATE Logic: Targets the specific Roll Number
        private void press_updatevr(object sender, EventArgs e)
        {
            // Check if the ID is valid (it must be a number, not "we")
            if (string.IsNullOrEmpty(currentSelectedRollNumber) || !int.TryParse(currentSelectedRollNumber, out int rollId))
            {
                MessageBox.Show("Please select a valid record from the table. The current ID is invalid.");
                return;
            }

            string dbPath = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Pananom Database\Prooject Pananom Data.accdb";
            string query = @"UPDATE [User RYR Varietal Registry] 
                     SET [Maturity Period] = @mp, [Expected Yield] = @ey, [Resistance] = @res, [Grain Type] = @gt 
                     WHERE [Roll Number] = @roll AND [User ID] = @uid";

            try
            {
                using (OleDbConnection conn = new OleDbConnection(dbPath))
                {
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        int mpValue, eyValue;
                        int.TryParse(fill_mp_vr.Text, out mpValue);
                        int.TryParse(fill_ey_vr.Text, out eyValue);

                        cmd.Parameters.AddWithValue("@mp", mpValue);
                        cmd.Parameters.AddWithValue("@ey", eyValue);
                        cmd.Parameters.AddWithValue("@res", fill_r_vr.Text);
                        cmd.Parameters.AddWithValue("@gt", fill_gt_vr.Text);
                        cmd.Parameters.AddWithValue("@roll", rollId); // Uses the safely parsed ID
                        cmd.Parameters.AddWithValue("@uid", UserSession.UserInstance.ID);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Record updated successfully!");
                        refreshreload();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Failed: " + ex.Message);
            }
        }

        private void press_deletevr(object sender, EventArgs e)
        {
            // Use the safely parsed ID from your previous code
            if (string.IsNullOrEmpty(currentSelectedRollNumber) || !int.TryParse(currentSelectedRollNumber, out int rollId))
            {
                MessageBox.Show("Please click the row in the table first so the system knows which record to delete!");
                return;
            }

            DialogResult confirm = MessageBox.Show($"Are you sure you want to PERMANENTLY delete record #{rollId}?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                string dbPath = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Pananom Database\Prooject Pananom Data.accdb";
                string query = "DELETE FROM [User RYR Varietal Registry] WHERE [Roll Number] = @roll";

                try
                {
                    using (OleDbConnection conn = new OleDbConnection(dbPath))
                    {
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@roll", rollId);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();

                            MessageBox.Show("Record deleted successfully.");

                            // Reset the ID so you don't accidentally delete the next row
                            currentSelectedRollNumber = "";
                            refreshreload();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete Error: " + ex.Message);
                }
            }
        }

        private void datagridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Varietal_Registry_Grid.Rows[e.RowIndex];

                // 1. Try to find the exact column name
                if (Varietal_Registry_Grid.Columns.Contains("Roll Number"))
                {
                    currentSelectedRollNumber = row.Cells["Roll Number"].Value?.ToString() ?? "";
                }
                else
                {
                    // 2. EMERGENCY FALLBACK: If name fails, grab the first column (Index 0)
                    // Make sure Roll Number is the very FIRST column in your Access Query!
                    currentSelectedRollNumber = row.Cells[0].Value?.ToString() ?? "";

                    // If the value is "PNMIC" or "wew", you'll know Index 0 is the wrong column.
                    if (!int.TryParse(currentSelectedRollNumber, out _))
                    {
                        MessageBox.Show("Selection Error: Grabbed '" + currentSelectedRollNumber +
                                        "' instead of a Number. Move Roll Number to the first column in Access!");
                    }
                }

                fill_mp_vr.Text = GetCellValue(row, "Maturity Period");
                fill_ey_vr.Text = GetCellValue(row, "Expected Yield");
                fill_r_vr.Text = GetCellValue(row, "Resistance");
                fill_gt_vr.Text = GetCellValue(row, "Grain Type");
            }
        }

        // KEEP ONLY THIS ONE VERSION OF GetCellValue
        private string GetCellValue(DataGridViewRow row, string columnName)
        {
            if (Varietal_Registry_Grid.Columns.Contains(columnName))
            {
                return row.Cells[columnName].Value?.ToString() ?? "";
            }
            return "";
        }

        internal void refreshreload()
        {
            string dbPath = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Pananom Database\Prooject Pananom Data.accdb";
            string query = "SELECT * FROM [Varietal Registry Query] WHERE [User ID] = @uid";

            try
            {
                using (OleDbConnection connected = new OleDbConnection(dbPath))
                {
                    adapter = new OleDbDataAdapter(query, connected);
                    adapter.SelectCommand.Parameters.Clear();
                    adapter.SelectCommand.Parameters.AddWithValue("@uid", UserSession.UserInstance.ID);

                    DataTable dt = new DataTable();
                    connected.Open();
                    adapter.Fill(dt);
                    connected.Close();

                    Varietal_Registry_Grid.DataSource = dt;

                    // STYLING: Make text black so it's readable
                    Varietal_Registry_Grid.DefaultCellStyle.ForeColor = Color.Black;
                    Varietal_Registry_Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

                    if (Varietal_Registry_Grid.Columns.Contains("Roll Number"))
                        Varietal_Registry_Grid.Columns["Roll Number"].Visible = false;

                    Varietal_Registry_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex) { MessageBox.Show("Load Error: " + ex.Message); }
        }

        private void refresh(object sender, EventArgs e)
        {
            refreshreload();
        }

        private void endoperation(object sender, FormClosedEventArgs e)
        {
            // Clean up if necessary
        }
    }
}