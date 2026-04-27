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
    public partial class AdminLogin : Form
    {
        Homepageee home;
        private static AdminLogin instance;

        internal static AdminLogin Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new AdminLogin();
                }

                return instance;
            }
        }
        public AdminLogin()
        {
            InitializeComponent();
        }

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;

        private void loginADMIN_Click(object sender, EventArgs e)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";
            string query = "SELECT COUNT(*) FROM [Admin Account Information] WHERE [username] = @H1 AND [password] = @H2";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(query, conn);

                    // Using parameters prevents SQL Injection (a big plus for your grade!)
                    cmd.Parameters.AddWithValue("@H1", ADMINusn.Text);
                    cmd.Parameters.AddWithValue("@H2", ADMINpass.Text);

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Login Successful!");
                        AdminAccount.Instance.Show(); // Using your Singleton
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password. Please try again.");
                        ADMINpass.Clear();
                        ADMINusn.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }

        private void AdminLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BackHomepage_Click(object sender, EventArgs e)
        {
            home = new Homepageee();
            this.Hide();
            home.Show();
        }

    }
}
