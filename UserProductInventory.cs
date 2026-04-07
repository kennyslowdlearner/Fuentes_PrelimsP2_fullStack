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
    public partial class productInventory : Form
    {
        private static productInventory instance;
        public productInventory()
        {
            InitializeComponent();
        }

        //made changes here (8) [4/6/2026 | 12:46 PM]
        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;

        internal static productInventory Instance
        {
            //made changes here (5) [4/3/2026 | 12:24 PM]
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new productInventory();
                }

                return instance;
            }
        }

        public void AddProductRow(string productname, string productid, string quantity)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void InitializeTableAndBind()
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // no-op
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void searchBoxPI_TextChanged(object sender, EventArgs e)
        {
            // no-op
        }

        private void searchbuttonPI_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void usermenuPI_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // no-op
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updatePrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Implement update product flow here when needed
        }

        private void deleteRemoveProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Implement delete/remove product flow here when needed
        }

        private void activityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            // no-op
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void profileName_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void backoptionPI_click(object sender, EventArgs e)
        {

        }

        private void logoutoptionPI_click(object sender, EventArgs e)
        {
            //made changes here (9) [4/6/2026 | 12:46 PM]
            Homepage.Instance.Show();
            this.Hide();
        }

        private void productInventory_FormClosed(object sender, FormClosedEventArgs e)
        {
            //made changes here (10) [4/6/2026 | 12:46 PM]
            //Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void backButton(object sender, EventArgs e)
        {
            //made changes here (11) [4/6/2026 | 12:46 PM]
            UserAccount.Instance.Show();
            this.Hide();
        }

        private void Close_Form_After_Run(object sender, FormClosingEventArgs e)
        {

        }

        private void press_connectpi(object sender, EventArgs e)
        {
            //made changes here (12) [4/6/2026 | 12:46 PM]
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            dataSet = new DataSet();

            try
            {
                connection.Open();
                System.Windows.Forms.MessageBox.Show("Connected Succesfully!");
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed. Error: " + ex.Message);
            }
        }

        private void press_loadpi(object sender, EventArgs e)
        {
            //made changes here (13) [4/6/2026 | 12:46 PM]
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            adapter = new OleDbDataAdapter("SELECT * FROM [User PI Product Inventory]", connection);


            try
            {
                connection.Open();

                dataSet = new DataSet();

                adapter.Fill(dataSet, "[User PI Product Inventory]");

                connection.Close();

                Product_Inventory_Grid.DataSource = dataSet.Tables["[User PI Product Inventory]"];

                Product_Inventory_Grid.Columns["Roll Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Product_Inventory_Grid.Columns["Product Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Product_Inventory_Grid.Columns["Reference ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Product_Inventory_Grid.Columns["Product ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Product_Inventory_Grid.Columns["Quantity in Kilograms"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }

        private void press_insertpi(object sender, EventArgs e)
        {
            //made changes here (14) [4/6/2026 | 12:46 PM]
            string referenceID = GenerateReferenceID();
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            string query = "INSERT INTO [User PI Product Inventory] ([Product Name], [Product ID], [Quantity in Kilograms], [Reference ID]) VALUES (@P1, @P2, @P3, @P4)";

            command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@P1", fill_productname_pi.Text);
            command.Parameters.AddWithValue("@P2", fill_productid_pi.Text);
            command.Parameters.AddWithValue("@P3", Convert.ToInt32(fill_quantity_pi.Text));
            command.Parameters.AddWithValue("@P4", referenceID);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Product added successfully! Ref ID: " + referenceID);

                fill_productname_pi.Clear();
                fill_productid_pi.Clear();
                fill_quantity_pi.Clear();

                press_loadpi(sender, e);


            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to add product. Error: " + ex.Message);
            }
        }

        private void datagrid_cellclick(object sender, DataGridViewCellEventArgs e)
        {
            //made changes here (15) [4/6/2026 | 12:46 PM]
            indexRow = e.RowIndex;

            DataGridViewRow row = Product_Inventory_Grid.Rows[indexRow];

            fill_productname_pi.Text = row.Cells[0].Value.ToString();
            fill_productid_pi.Text = row.Cells[1].Value.ToString();
            fill_quantity_pi.Text = row.Cells[2].Value.ToString();
        }

        private void press_deletepi(object sender, EventArgs e)
        {
            //made changes here (16) [4/6/2026 | 12:46 PM]
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            string query = "DELETE FROM [User PI Product Inventory] WHERE [Product ID] = @P2";

            command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("@P2", Product_Inventory_Grid.CurrentRow.Cells[0].Value);

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

        private void press_updatepi(object sender, EventArgs e)
        {
            //made changes here (17) [4/6/2026 | 12:46 PM]
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            string query = "UPDATE [Product PI Product Inventory] SET [Product Name] = @P1, [Quantity in Kilograms] = @P3 WHERE [Product ID] = @P2";

            command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("[P1]", fill_productname_pi.Text);
            command.Parameters.AddWithValue("[P3]", Convert.ToInt32(fill_quantity_pi.Text));

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Item updated successfully!");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to update item. Error: " + ex.Message);
            }
        }

        private string GenerateReferenceID()
        {
            //made changes here (18) [4/6/2026 | 12:46 PM]
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

            return "PPREF-" + randomString;
        }

        private void press_refreshpi(object sender, EventArgs e)
        {
            //made changes here (19) [4/6/2026 | 12:46 PM]
            press_loadpi(null, null);

            fill_productname_pi.Clear();
            fill_productid_pi.Clear();
            fill_quantity_pi.Clear();
        }

        private void fill_searchpi(object sender, EventArgs e)
        {
            //made changes here (20) [4/6/2026 | 12:46 PM]
            string connect = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

            string query = "SELECT * FROM [User PI Product Inventory] WHERE [Product Name] LIKE @S1 OR [Product ID] LIKE @S2 OR [Reference ID] LIKE @S3";

            using (OleDbConnection connected = new OleDbConnection(connect))
            {
                OleDbDataAdapter searchAdapter = new OleDbDataAdapter(query, connected);

                string searchTerm = "%" + fill_search_pi.Text + "%";
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S1", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S2", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S3", searchTerm);

                DataSet searchNow = new DataSet();

                try
                {
                    connected.Open();
                    searchAdapter.Fill(searchNow, "[User PI Product Inventory]");

                    Product_Inventory_Grid.DataSource = searchNow.Tables["[User PI Product Inventory]"];
                }

                catch(Exception ex)
                {
                    MessageBox.Show("Search failed. Error: " + ex.Message);
                }
            }
        }
    }
}
