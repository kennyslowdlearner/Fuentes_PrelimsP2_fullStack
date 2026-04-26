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
            auto_reload();
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
            adapter = new OleDbDataAdapter("SELECT * FROM [User Account Information]", connection);

            try
            {
                connection.Open();

                dataSet = new DataSet();

                adapter.Fill(dataSet, "[User Account Information]");

                connection.Close();

                Account_Control_Grid.DataSource = dataSet.Tables["[User Account Information]"];

                Account_Control_Grid.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["First Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Middle Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Last Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Birthdate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Age"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Category"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Gender"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Contact Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Email Account"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Hotline"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Active"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Attempts"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Locked"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                if (Account_Control_Grid.Columns.Contains("User ID"))
                    Account_Control_Grid.Columns["User ID"].Visible = false;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }

        private void save_changes_to_db()
        {
            try
            {
                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
                adapter.Update(dataSet, "[User Account Information]");
                MessageBox.Show("Account updated successfully!");
                auto_reload();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to database: " + ex.Message);
            }
        }

        internal void auto_reload()
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            adapter = new OleDbDataAdapter("SELECT * FROM [User Account Information]", connection);

            try
            {
                connection.Open();

                dataSet = new DataSet();

                adapter.Fill(dataSet, "User Account Information");

                connection.Close();

                Account_Control_Grid.DataSource = dataSet.Tables["User Account Information"];

                Account_Control_Grid.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["First Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Middle Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Last Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Birthdate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Age"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Category"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Gender"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Contact Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Email Account"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Hotline"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Active"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Attempts"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Account_Control_Grid.Columns["Locked"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                if (Account_Control_Grid.Columns.Contains("User ID"))
                    Account_Control_Grid.Columns["User ID"].Visible = false;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void press_enableDisable_aac(object sender, EventArgs e)
        {
            if (Account_Control_Grid.CurrentRow == null) return;

            // This gets the actual data row regardless of sorting or filtering
            DataRowView rowView = (DataRowView)Account_Control_Grid.CurrentRow.DataBoundItem;
            DataRow row = rowView.Row;

            bool currentStatus = Convert.ToBoolean(row["Active"]);
            row["Active"] = !currentStatus;

            save_changes_to_db();
        }

        private void press_unlock_aac(object sender, EventArgs e)
        {
            if (Account_Control_Grid.CurrentRow == null) return;

            DataRowView rowView = (DataRowView)Account_Control_Grid.CurrentRow.DataBoundItem;
            DataRow row = rowView.Row;

            row["Locked"] = false;
            row["Attempts"] = 0;

            save_changes_to_db();
        }
    }
}
