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
    public partial class User_CostofProduction : Form
    {
        private static User_CostofProduction instance;
        public User_CostofProduction()
        {
            InitializeComponent();
        }

        //(Global User Session) Component
        internal static User_CostofProduction Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new User_CostofProduction();

                return instance;
            }
        }

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;

        string currentSelectedRollNumber = " ";
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

        private void shortcut_Transactions(object sender, EventArgs e)
        {
            try
            {
                User_TransactionSheet.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Transactions page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void press_insertcop(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            string query = "INSERT INTO [User T&T Cost of Production] ([Item Name], [Unit], [Quantity], [Price per unit], [Date of purchase], [Status]) VALUES (@P1, @P2, @P3, @P4, @P5, @P6)";

            command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@P1", fill_itemname_cop.Text);
            command.Parameters.AddWithValue("@P2", fill_unit_cop.Text);
            command.Parameters.AddWithValue("@P3", Convert.ToInt32(fill_quantity_cop.Text));
            command.Parameters.AddWithValue("@P4", Convert.ToDecimal(fill_priceperunit_cop.Text));
            command.Parameters.AddWithValue("@P5", fill_date_cop.Value);
            command.Parameters.AddWithValue("@P6", fill_status_cop.Text);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Item added successfully!");

                fill_itemname_cop.Clear();
                fill_unit_cop.Clear();
                fill_quantity_cop.Clear();
                fill_priceperunit_cop.Clear();
                fill_date_cop.Value = DateTime.Now;
                fill_status_cop.SelectedIndex = -1;

                press_insertcop(sender, e);

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to add product. Error: " + ex.Message);
            }
        }

        private void press_updatecop(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            string query = "UPDATE [User T&T Cost of Production] SET [Item Name] = @P1, [Unit] = @P2, [Quantity] = @P3, [Price per unit] = @P4, [Date of purchase] = @P5, [Status] = @P6 WHERE [Item Number] = @P7";

            command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@P1", fill_itemname_cop.Text);
            command.Parameters.AddWithValue("@P2", fill_unit_cop.Text);
            command.Parameters.AddWithValue("@P3", Convert.ToInt32(fill_quantity_cop.Text));
            command.Parameters.AddWithValue("@P4", Convert.ToDecimal(fill_priceperunit_cop.Text));
            command.Parameters.AddWithValue("@P5", fill_date_cop.Value);
            command.Parameters.AddWithValue("@P6", fill_status_cop.Text);

            command.Parameters.AddWithValue("@P7", currentSelectedRollNumber);


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

        private void dataGridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Cost_Of_Production_Grid.Rows[e.RowIndex];

                currentSelectedRollNumber = row.Cells["Item Number"].Value?.ToString() ?? "";

                fill_itemname_cop.Text = row.Cells["Item Name"].Value?.ToString();
                fill_unit_cop.Text = row.Cells["Unit"].Value?.ToString();
                fill_quantity_cop.Text = row.Cells["Quantity"].Value?.ToString();
                fill_priceperunit_cop.Text = row.Cells["Price per unit"].Value?.ToString();
                fill_status_cop.Text = row.Cells["Status"].Value?.ToString();

                if (row.Cells["Date of purchase"].Value != DBNull.Value)
                    fill_date_cop.Value = Convert.ToDateTime(row.Cells["Date of purchase"].Value);

                else fill_date_cop.Value = DateTime.Now;
            }
        }

        private void refreshreload()
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            adapter = new OleDbDataAdapter("SELECT * FROM [User T&T Cost of Production]", connection);


            try
            {
                //connection.Open();

                dataSet = new DataSet();

                adapter.Fill(dataSet, "[User T&T Cost of Production]");

                //connection.Close();

                Cost_Of_Production_Grid.DataSource = dataSet.Tables["[User T&T Cost of Production]"];

                Cost_Of_Production_Grid.Columns["Item Number"].Visible = false;
                Cost_Of_Production_Grid.Columns["Unit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Cost_Of_Production_Grid.Columns["Item Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Cost_Of_Production_Grid.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Cost_Of_Production_Grid.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Cost_Of_Production_Grid.Columns["Price per unit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Cost_Of_Production_Grid.Columns["Date of purchase"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }

        private void press_deletecop(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(currentSelectedRollNumber))
            {
                MessageBox.Show("Please select an item to delete.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
                string query = "DELETE FROM [User T&T Cost of Production] WHERE [Item Number] = @P1";

                command = new OleDbCommand(query, connection);
                command.Parameters.Add("@P1", OleDbType.Integer).Value = Convert.ToInt32(currentSelectedRollNumber);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Item deleted successfully!");

                    refreshreload();

                    fill_itemname_cop.Clear();
                    fill_unit_cop.Clear();
                    fill_quantity_cop.Clear();
                    fill_priceperunit_cop.Clear();
                    fill_date_cop.Value = DateTime.Now;
                    fill_status_cop.SelectedIndex = -1;
                    currentSelectedRollNumber = " ";
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete item. Error: " + ex.Message);
                }
            }
        }

        //NEED TO ADD SEARCH FUNCTIONALITY IN THIS PART
    }
}
