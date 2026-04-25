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
    public partial class AdminAccountControl : Form
    {
        private static AdminAccountControl instance;
        public AdminAccountControl()
        {
            InitializeComponent();
        }

        internal static AdminAccountControl Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new AdminAccountControl();
                }

                return instance;
            }
        }

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;
        private void button8_Click(object sender, EventArgs e)
        {

        }

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

        private void press_refresh_aa(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            //adapter = new OleDbDataAdapter("SELECT * FROM [User Account Information] WHERE [User ID] = !A1", connection);
            adapter = new OleDbDataAdapter("SELECT * FROM [User Account Information] WHERE [User ID] = !A1", connection);

            adapter.SelectCommand.Parameters.AddWithValue("A1", UserSession.UserInstance.ID);

            try
            {
                connection.Open();

                dataSet = new DataSet();

                adapter.Fill(dataSet, "[User Account Information]");

                connection.Close();

                Account_Control_Grid.DataSource = dataSet.Tables["[User Account Information]"];

                Account_Control_Grid.Columns["User ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Account_Control_Grid.Columns["Reference ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Account_Control_Grid.Columns["First Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Middle Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Last Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Account_Control_Grid.Columns["Birthdate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Account_Control_Grid.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Account_Control_Grid.Columns["Age"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Account_Control_Grid.Columns["Category"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Account_Control_Grid.Columns["Gender"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Account_Control_Grid.Columns["Contact Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Account_Control_Grid.Columns["Email Account"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Account_Control_Grid.Columns["Hotline"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                if (Account_Control_Grid.Columns.Contains("User ID"))
                    Account_Control_Grid.Columns["User ID"].Visible = false;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }
    }
}
