using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class farmgateUSER : Form
    {

        private static farmgateUSER instance;

        public farmgateUSER()
        {
            InitializeComponent();
        }

        internal static farmgateUSER Instance
        {
            get
            {
                // Add a check to see if the instance is actually null or was closed
                if (instance == null || instance.IsDisposed)
                {
                    instance = new farmgateUSER();
                }
                return instance;
            }
        }

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;

        private void farmgateUser_Load(object sender, EventArgs e)
        {
            string name_in_session = UserSession.UserInstance.FirstName + " " + UserSession.UserInstance.MiddleName + " " + UserSession.UserInstance.LastName;

        }
        private void backoptionFPG_Click(object sender, EventArgs e)
        {
            UserAccount.Instance.Show();
            this.Hide();
        }

        private void logoutoptionFPG_Click(object sender, EventArgs e)
        {
            Homepageee homepage = new Homepageee();
            homepage.Show();
            this.Hide();

        }

        private void farmgateUSER_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void backoptionFPG_Click_1(object sender, EventArgs e)
        {
            UserAccount useraccount = new UserAccount();
            useraccount.Show();
            this.Hide();
        }

        private void logoutoptionFPG_Click_1(object sender, EventArgs e)
        {
            Homepageee homepage = new Homepageee();
            homepage.Show();
            this.Hide();
        }

        private void display_prices_fgp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;

            DataGridViewRow row = Farmgate_Prices_Grid.Rows[indexRow];

            fill_productname_pi.Text = row.Cells[0].Value.ToString();
            fill_productid_pi.Text = row.Cells[1].Value.ToString();
            fill_quantity_pi.Text = row.Cells[2].Value.ToString();
        }


        private void press_loadfgp(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            adapter = new OleDbDataAdapter("SELECT * FROM [User Farmgate Price] WHERE [User ID] = !A1", connection);

            adapter.SelectCommand.Parameters.AddWithValue("A1", UserSession.UserInstance.ID);

            try
            {
                connection.Open();

                dataSet = new DataSet();

                adapter.Fill(dataSet, "[User Farmgate Price]");

                connection.Close();

                Farmgate_Prices_Grid.DataSource = dataSet.Tables["[User Farmgate Price]"];

                Farmgate_Prices_Grid.Columns["Roll Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Farmgate_Prices_Grid.Columns["Product ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Farmgate_Prices_Grid.Columns["Product Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Farmgate_Prices_Grid.Columns["Price per Kilogram"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Farmgate_Prices_Grid.Columns["User ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                if (Farmgate_Prices_Grid.Columns.Contains("User ID"))
                    Farmgate_Prices_Grid.Columns["User ID"].Visible = false;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }

        private void press_Searchfgp(object sender, EventArgs e)
        {
            string connect = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

            string query = "SELECT * FROM [User Farmgate Price Query] WHERE [Product Name] LIKE @S1 OR [Product ID] LIKE @S2 OR [Reference ID] LIKE @S3";

            using (OleDbConnection connected = new OleDbConnection(connect))
            {
                OleDbDataAdapter searchAdapter = new OleDbDataAdapter(query, connected);

                string searchTerm = "%" + fill_search_fgp.Text + "%";
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S1", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S2", searchTerm);
                searchAdapter.SelectCommand.Parameters.AddWithValue("@S3", searchTerm);

                DataSet searchNow = new DataSet();

                try
                {
                    connected.Open();
                    searchAdapter.Fill(searchNow, "[User PI Product Inventory]");

                    Farmgate_Prices_Grid.DataSource = searchNow.Tables["[User PI Product Inventory]"];
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Search failed. Error: " + ex.Message);
                }
            }
        }
    }
}