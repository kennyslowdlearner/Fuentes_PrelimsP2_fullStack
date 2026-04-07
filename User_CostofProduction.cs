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
        double quantity, price, product = 0;
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
            string query = "INSERT INTO [User T&T Cost of Production] ([Item Name], [Unit], [Quantity], [Price per unit], [Total], [Date of purchase], [Status], [Serial Number]) VALUES (@P1, @P2, @P3, @P4, @P5, @P6, @P7, @P8)";


            price = Convert.ToDouble(fill_priceperunit_cop.Text);
            quantity = Convert.ToDouble(fill_quantity_cop.Text);

            product = price * quantity;

            command = new OleDbCommand(query, connection);
            command.Parameters.Add("@P1", OleDbType.VarWChar).Value = fill_itemname_cop.Text;
            command.Parameters.Add("@P2", OleDbType.VarWChar).Value = fill_unit_cop.Text;
            command.Parameters.Add("@P3", OleDbType.Integer).Value = Convert.ToInt32(fill_quantity_cop.Text);
            command.Parameters.Add("@P4", OleDbType.Currency).Value = Convert.ToDecimal(fill_priceperunit_cop.Text);

            command.Parameters.Add("@P5", OleDbType.Currency).Value = Convert.ToDecimal(product);

            command.Parameters.Add("@P6", OleDbType.Date).Value = fill_date_cop.Text;
            command.Parameters.Add("@P7", OleDbType.VarWChar).Value = fill_status_cop.Text;
            command.Parameters.Add("@P8", OleDbType.VarWChar).Value = serialIDgenerator();


            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Item added successfully!");

                fill_itemname_cop.Clear();
                fill_unit_cop.SelectedIndex = -1;
                fill_quantity_cop.Clear();
                fill_priceperunit_cop.Clear();
                fill_date_cop.Value = DateTime.Now;
                fill_status_cop.SelectedIndex = -1;

                refreshreload();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to add product. Error: " + ex.Message);
            }
        }

        private void press_updatecop(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");

            // SQL ORDER: 1:Item Name, 2:Unit, 3:Quantity, 4:Price, 5:Total, 6:Date, 7:Status WHERE 8:ID
            string query = "UPDATE [User T&T Cost of Production] SET [Item Name] = @P1, [Unit] = @P2, [Quantity] = @P3, [Price per unit] = @P4, [Total] = @P5, [Date of purchase] = @P6, [Status] = @P7 WHERE [Item Number] = @P8";

            // Recalculate to ensure the Total is fresh for the update
            double upQty = Convert.ToDouble(fill_quantity_cop.Text);
            double upPrice = Convert.ToDouble(fill_priceperunit_cop.Text);
            double upTotal = upQty * upPrice;

            command = new OleDbCommand(query, connection);

            // Use UNIQUE parameter names and follow the SQL order exactly
            command.Parameters.Add("@P1", OleDbType.VarWChar).Value = fill_itemname_cop.Text;
            command.Parameters.Add("@P2", OleDbType.VarWChar).Value = fill_unit_cop.Text;
            command.Parameters.Add("@P3", OleDbType.Integer).Value = Convert.ToInt32(fill_quantity_cop.Text);
            command.Parameters.Add("@P4", OleDbType.Currency).Value = Convert.ToDecimal(fill_priceperunit_cop.Text);
            command.Parameters.Add("@P5", OleDbType.Currency).Value = Convert.ToDecimal(upTotal); // The fixed Total
            command.Parameters.Add("@P6", OleDbType.Date).Value = fill_date_cop.Value;
            command.Parameters.Add("@P7", OleDbType.VarWChar).Value = fill_status_cop.Text;

            // The WHERE clause parameter must be last
            command.Parameters.Add("@P8", OleDbType.Integer).Value = Convert.ToInt32(currentSelectedRollNumber);

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
                Cost_Of_Production_Grid.AutoGenerateColumns = true;

                foreach(DataGridViewColumn col in Cost_Of_Production_Grid.Columns) { col.AutoSizeMode = DataGridViewAutoSizeColumnMode.None; }
                if (Cost_Of_Production_Grid.Columns.Contains("Item Number")) Cost_Of_Production_Grid.Columns["Item number"].Visible = false;
                Cost_Of_Production_Grid.Columns["Item Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                Cost_Of_Production_Grid.Columns["Unit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Cost_Of_Production_Grid.Columns["Quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Cost_Of_Production_Grid.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Cost_Of_Production_Grid.Columns["Price per unit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Cost_Of_Production_Grid.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Cost_Of_Production_Grid.Columns["Date of purchase"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Cost_Of_Production_Grid.Columns["Serial Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }

        private void press_deletecop(object sender, EventArgs e)
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
                    fill_unit_cop.SelectedIndex = -1;
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

        private void searchcop(object sender, EventArgs e)
        {
            string connect = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

            string query = "SELECT * FROM [User T&T Cost of Production] WHERE [Item Name] LIKE @S1 OR [Date of purchase] LIKE @S2 OR [Serial Number] LIKE @S3";

            using (OleDbConnection connected = new OleDbConnection(connect))
            {
                OleDbDataAdapter searchAdapter = new OleDbDataAdapter(query, connected);

                string searchTerm = "%" + fill_search_cop.Text + "%";
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S1", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S2", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S3", searchTerm);

                DataSet searchNow = new DataSet();

                try
                {
                    connected.Open();
                    searchAdapter.Fill(searchNow, "[User T&T Cost of Production]");

                    Cost_Of_Production_Grid.DataSource = searchNow.Tables["[User T&T Cost of Production]"];
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Search failed. Error: " + ex.Message);
                }
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

            return "PPSN-" + randomString;
        }

        //issues with data grid displauy
    }
}
