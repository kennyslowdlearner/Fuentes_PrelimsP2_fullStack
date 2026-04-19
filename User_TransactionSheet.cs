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
        public User_TransactionSheet()
        {
            InitializeComponent();
            choices_from_database();
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
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            string connect = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";
            string query = "INSERT INTO [User T&T Transaction] ([Customer Name], [Rice Type], [Product ID], [Price per Kilogram], [Quantity in Kilogram], [Delivery Date], [Reference ID], [User ID]) VALUES (@P1, @P2, @P3, @P4, @P5, @P6, @P7, @P8)";

            using (OleDbConnection connected = new OleDbConnection(connect))
            {
                using(OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.Add("@P1", OleDbType.VarWChar).Value = fill_customername_ts.Text;
                    command.Parameters.Add("@P2", OleDbType.VarWChar).Value = fill_ricetype_ts.Text;
                    command.Parameters.Add("@P3", OleDbType.VarWChar).Value = fill_productid_ts.Text;
                    command.Parameters.Add("@P4", OleDbType.Currency).Value = Convert.ToDecimal(fill_priceperkg_ts.Text);
                    command.Parameters.Add("@P5", OleDbType.Integer).Value = Convert.ToInt32(fill_quantity_ts.Text);
                    command.Parameters.Add("@P6", OleDbType.Date).Value = fill_date_ts.Text;
                    command.Parameters.Add("@P7", OleDbType.VarWChar).Value = ReferenceID;
                    command.Parameters.Add("@P5", OleDbType.Integer).Value = UserSession.UserInstance.ID;


                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();

                        //both lines are used for email notifications
                        string transaction_Details = "Transaction Successful! <br> Amount: " + Convert.ToDecimal(fill_priceperkg_ts.Text) + " was set to sold. Reference Number: " + ReferenceID;
                        await GlobalEmailNotificationModule.send_Notification(UserSession.UserInstance.Email, "Transacion Confirmed!", transaction_Details);

                        MessageBox.Show("Product added successfully! Ref ID: " + referenceID);

                        fill_customername_ts.Clear();
                        fill_ricetype_ts.SelectedIndex = -1;
                        fill_productid_ts.Clear();
                        fill_quantity_ts.Clear();
                        fill_priceperkg_ts.Clear();
                        fill_date_ts.Value = DateTime.Now;

                        refreshreload();


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to add product. Error: " + ex.Message);
                    }
                }
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
            string query = "UPDATE [User T&T Transaction] SET [Customer Name] = @P1, [Rice Type] = @P2, [Product ID] = @P3, [Price per Kilogram] = @P4, [Quantity in Kilogram] = @P5, [Delivery Date] = @P6, [Reference ID] = @P7 WHERE [Item Number] = @P8";


            // Use UNIQUE parameter names and follow the SQL order exactly
            command.Parameters.Add("@P1", OleDbType.VarWChar).Value = fill_customername_ts.Text;
            command.Parameters.Add("@P2", OleDbType.VarWChar).Value = fill_ricetype_ts.Text;
            command.Parameters.Add("@P3", OleDbType.VarWChar).Value = fill_productid_ts.Text;
            command.Parameters.Add("@P4", OleDbType.Currency).Value = Convert.ToDecimal(fill_priceperkg_ts.Text);
            command.Parameters.Add("@P5", OleDbType.Integer).Value = Convert.ToInt32(fill_quantity_ts.Text);
            command.Parameters.Add("@P6", OleDbType.Date).Value = fill_date_ts.Value;

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

                fill_customername_ts.Text = row.Cells["Customer Name"].Value?.ToString();
                fill_ricetype_ts.Text = row.Cells["Rice Type"].Value?.ToString();
                fill_productid_ts.Text = row.Cells["Product ID"].Value?.ToString();
                fill_priceperkg_ts.Text = row.Cells["Price per Kilogram"].Value?.ToString();
                fill_quantity_ts.Text = row.Cells["Quantity in Kilogram"].Value?.ToString();

                if (row.Cells["Delivery Date"].Value != DBNull.Value)
                    fill_date_ts.Value = Convert.ToDateTime(row.Cells["Delivery Date"].Value);

                else fill_date_ts.Value = DateTime.Now;
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
            string connection = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";
            string query = "SELECT [Product ID], [Product Name] & ' ' & [Product ID] AS FullDisplay FROM [User PI Product Inventory]";

            using (OleDbConnection connected = new OleDbConnection(connection))
            {
                OleDbDataAdapter newAdapter = new OleDbDataAdapter(query, connection);
                DataTable newTable = new DataTable();

                try
                {
                    connected.Open();
                    newAdapter.Fill(newTable);

                    fill_ricetype_ts.DataSource = newTable;
                    fill_ricetype_ts.DisplayMember = "FullDisplay";
                    fill_ricetype_ts.ValueMember = "Product ID";

                    fill_ricetype_ts.SelectedIndex = -1;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error occured: " + ex.Message);
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
