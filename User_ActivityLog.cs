using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class User_ActivityLog : Form
    {
        private static User_ActivityLog instance;
        public User_ActivityLog()
        {
            InitializeComponent();
            press_refreshreloadal(null, null);
        }

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;

        string currentSelectedRollNumber = " ";

        //(Global User Session) Component
        internal static User_ActivityLog Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new User_ActivityLog();

                return instance;
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
                MessageBox.Show("Failed to open Rice Yield Estimation and Registry page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void shortcut_RiceYieldandEstimation(object sender, EventArgs e)
        {
            try
            {
                User_RiceYieldandEstimation.Instance.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Rice Yield Estimation and Registry page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void press_refreshreloadal(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            adapter = new OleDbDataAdapter("SELECT * FROM [User RYR Activity Log]", connection);


            try
            {
                connection.Open();

                dataSet = new DataSet();

                adapter.Fill(dataSet, "[User RYR Activity Log]");

                connection.Close();

                Activity_Log_Grid.DataSource = dataSet.Tables["[User RYR Activity Log]"];

                Activity_Log_Grid.Columns["Roll Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Activity_Log_Grid.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Activity_Log_Grid.Columns["Activity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Activity_Log_Grid.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Activity_Log_Grid.Columns["Time"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Activity_Log_Grid.Columns["Duration"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }

        private void press_insertal(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            string query = "INSERT INTO [User RYR Activity Log] ([Date], [Time], [Activity], [Duration], [Status]) VALUES (@P1, @P2, @P3, @P4, @P5)";

            command = new OleDbCommand(query, connection);
            command.Parameters.Add("@P1", OleDbType.Date).Value = fill_date_al.Value;

            command.Parameters.Add("@P2", OleDbType.VarWChar).Value = fill_time_al.Text;
            command.Parameters.Add("@P2", OleDbType.VarWChar).Value = fill_activity_al.Text;
            command.Parameters.Add("@P2", OleDbType.VarWChar).Value = fill_duration_al.Text;
            command.Parameters.Add("@P2", OleDbType.VarWChar).Value = fill_status_al.Text;


            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Activity added successfully!");

                fill_date_al.Value = DateTime.Now;
                fill_time_al.Clear();
                fill_activity_al.Clear();
                fill_duration_al.Clear();
                fill_status_al.SelectedIndex = -1;

                press_refreshreloadal(null, null);


            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to add new activity. Error: " + ex.Message);
            }
        }

        private void dataGridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                indexRow = e.RowIndex;

                DataGridViewRow row = Activity_Log_Grid.Rows[indexRow];

                currentSelectedRollNumber = row.Cells[0].Value.ToString();

                fill_date_al.Text = row.Cells[1].Value.ToString();
                fill_time_al.Text = row.Cells[2].Value.ToString();
                fill_activity_al.Text = row.Cells[3].Value.ToString();
                fill_duration_al.Text = row.Cells[4].Value.ToString();
                fill_status_al.Text = row.Cells[5].Value.ToString();
            }
        }

        private void press_updateal(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            string query = "UPDATE [User RYR Activity Log] SET [Date] = @P1, [Time] = @P2, Activity = @P3, Duration =@P4, Status = @P5 WHERE [Roll Number] = @P6";

            command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@P1", fill_date_al.Text);
            command.Parameters.AddWithValue("@P2", fill_time_al.Text);
            command.Parameters.AddWithValue("@P3", fill_activity_al.Text);
            command.Parameters.AddWithValue("@P4", fill_duration_al.Text);
            command.Parameters.AddWithValue("@P5", fill_status_al.Text);

            command.Parameters.AddWithValue("@P6", currentSelectedRollNumber);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Item updated successfully!");

                press_refreshreloadal(null, null);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to update item. Error: " + ex.Message);
            }
        }

        private void press_deleteal(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
                string query = "DELETE FROM [User RYR Activity Log] WHERE [Roll Number] = @P6";

                command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@P6", Activity_Log_Grid.CurrentRow.Cells[0].Value);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Item deleted successfully!");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete item. Error: " + ex.Message);
                }
            }
        }

        private void endOperation(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
