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
    public partial class AdminTransportSchedule : Form
    {
        private static AdminTransportSchedule instance;
        public AdminTransportSchedule()
        {
            InitializeComponent();
        }

        internal static AdminTransportSchedule Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new AdminTransportSchedule();
                }

                return instance;
            }
        }

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;


        private void label26_Click(object sender, EventArgs e)
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

        private void press_refresh_ts(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            adapter = new OleDbDataAdapter("SELECT * FROM [Admin - User Transport Schedule] WHERE [User ID] = !A1", connection);

            adapter.SelectCommand.Parameters.AddWithValue("A1", UserSession.UserInstance.ID);

            try
            {
                connection.Open();

                dataSet = new DataSet();

                adapter.Fill(dataSet, "[Admin - User Transport Schedule]");

                connection.Close();

                Admin_Transport_Schedule_Grid.DataSource = dataSet.Tables["[Admin - User Transport Schedule]"];

                Admin_Transport_Schedule_Grid.Columns["Trip Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Admin_Transport_Schedule_Grid.Columns["From"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Admin_Transport_Schedule_Grid.Columns["To"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Admin_Transport_Schedule_Grid.Columns["Estimated Time"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                Admin_Transport_Schedule_Grid.Columns["Time Left"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Admin_Transport_Schedule_Grid.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //if (Admin_Transport_Schedule_Grid.Columns.Contains("User ID"))
                //    Admin_Transport_Schedule_Grid.Columns["User ID"].Visible = false;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }
    }
}
