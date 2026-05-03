using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        //(Global User Session) Component
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
        int indexRow;

        string currentSelectedRollNumber;

        private void shortcut_RiceYieldandEstimation(object sender, EventArgs e)
        {
            try
            {
                User_RiceYieldandEstimation.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Rice Yield/Estimation page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void press_insertvr(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            string query = "INSERT INTO [User RYR Varietal Registry] ([Rice Type], [Date Stored], [Quantity in Kilograms], [Serial Number]) VALUES (@P1, @P2, @P3, @P4)";

            command = new OleDbCommand(query, connection);
            command.Parameters.Add("@P1", OleDbType.VarWChar).Value = fill_ricetype_vr.Text;
            command.Parameters.Add("@P2", OleDbType.Date).Value = fill_date_vr.Text;
            command.Parameters.Add("@P3", OleDbType.Integer).Value = Convert.ToInt32(fill_quantity_vr.Text);
            command.Parameters.Add("@P4", OleDbType.VarWChar).Value = serialIDgenerator();


            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Item added successfully!");

                fill_ricetype_vr.Clear();
                fill_date_vr.Value = DateTime.Now;
                fill_quantity_vr.Clear();

                refreshreload();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to add product. Error: " + ex.Message);
            }
        }

        private void press_updatevr(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");

            // SQL ORDER: 1:Item Name, 2:Unit, 3:Quantity, 4:Price, 5:Total, 6:Date, 7:Status WHERE 8:ID
            string query = "UPDATE [User RYR Varietal Registry] SET [Rice Type] = @P1, [Date Stored] = @P2, [Quantity in Kilograms] = @P3 WHERE [Roll Number] = @P4";

            command = new OleDbCommand(query, connection);

            // Use UNIQUE parameter names and follow the SQL order exactly
            command.Parameters.Add("@P1", OleDbType.VarWChar).Value = fill_ricetype_vr.Text;
            command.Parameters.Add("@P2", OleDbType.Date).Value = fill_date_vr.Value;
            command.Parameters.Add("@P3", OleDbType.Integer).Value = Convert.ToInt32(fill_quantity_vr.Text);


            // The WHERE clause parameter must be last
            command.Parameters.Add("@P4", OleDbType.Integer).Value = Convert.ToInt32(currentSelectedRollNumber);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Local Registry updated successfully!");
                refreshreload();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update item. Error: " + ex.Message);
            }
        }

        private void press_deletevr(object sender, EventArgs e)
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
                string query = "DELETE FROM [User RYR Varietal Registry] WHERE [Roll Number] = @P1";

                command = new OleDbCommand(query, connection);
                command.Parameters.Add("@P1", OleDbType.Integer).Value = Convert.ToInt32(currentSelectedRollNumber);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Item deleted successfully!");

                    refreshreload();

                    fill_ricetype_vr.Clear();
                    fill_quantity_vr.Clear();
                    fill_date_vr.Value = DateTime.Now;
                    currentSelectedRollNumber = " ";
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete item. Error: " + ex.Message);
                }
            }
        }

        private void searchvr(object sender, EventArgs e)
        {
            string connect = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

            string query = "SELECT * FROM [User RYR Varietal Registry] WHERE [Rice Type] LIKE @S1 OR [Date Stored] LIKE @S2 OR [Serial Number] LIKE @S3";

            using (OleDbConnection connected = new OleDbConnection(connect))
            {
                OleDbDataAdapter searchAdapter = new OleDbDataAdapter(query, connected);

                string searchTerm = "%" + fill_search_vr.Text + "%";
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S1", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S2", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S3", searchTerm);

                DataSet searchNow = new DataSet();

                try
                {
                    connected.Open();
                    searchAdapter.Fill(searchNow, "[User RYR Varietal Registry]");

                    Varietal_Registry_Grid.DataSource = searchNow.Tables["[User RYR Varietal Registry]"];
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Search failed. Error: " + ex.Message);
                }
            }
        }

        private void datagridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Varietal_Registry_Grid.Rows[e.RowIndex];

                currentSelectedRollNumber = row.Cells["Roll Number"].Value?.ToString() ?? "";

                fill_ricetype_vr.Text = row.Cells["Rice Type"].Value?.ToString();
                fill_quantity_vr.Text = row.Cells["Quantity"].Value?.ToString();

                if (row.Cells["Date Stored"].Value != DBNull.Value)
                    fill_date_vr.Value = Convert.ToDateTime(row.Cells["Date Stored"].Value);

                else fill_date_vr.Value = DateTime.Now;
            }
        }

        private void refreshreload()
        {
            string dbPath = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Pananom Database\Prooject Pananom Data.accdb";

            // Using a simple query for now to ensure data displays
            string query = "SELECT * FROM [User RYR Varietal Registry]";

            try
            {
                using (OleDbConnection connected = new OleDbConnection(dbPath))
                {
                    adapter = new OleDbDataAdapter(query, connected);
                    dataSet = new DataSet();

                    connected.Open();
                    adapter.Fill(dataSet, "VarietalRegistry");
                    connected.Close();

                    Varietal_Registry_Grid.DataSource = dataSet.Tables["VarietalRegistry"];

                    Varietal_Registry_Grid.DefaultCellStyle.ForeColor = Color.Black;
                    Varietal_Registry_Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

                    if (Varietal_Registry_Grid.Columns.Contains("Roll Number"))
                        Varietal_Registry_Grid.Columns["Roll Number"].Visible = false;

                    foreach (DataGridViewColumn col in Varietal_Registry_Grid.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    }

                    if (Varietal_Registry_Grid.Columns.Contains("Rice Type"))
                    {
                        Varietal_Registry_Grid.Columns["Rice Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Display Error: " + ex.Message);
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

            return "VRSN-" + randomString;
        }

        private void Refresh_Opening(object sender, CancelEventArgs e)
        {
            refreshreload();
        }

        private void refresh(object sender, EventArgs e)
        {
            refreshreload();
        }

        private void endoperation(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
