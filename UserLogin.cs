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
    public partial class UserLogin : Form
    {
        private static UserLogin instance;

        internal static UserLogin Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new UserLogin();
                }
                return instance;
            }
        }


        Homepageee home;

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;

        public UserLogin()
        {
            InitializeComponent();
            USERpass.UseSystemPasswordChar = true;

            //made changes here (4) [4/3/2026 | 11:11 AM]
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Pananom Database\Prooject Pananom Data.accdb";
            connection = new OleDbConnection(connectionString);

            adapter = new OleDbDataAdapter("SELECT * FROM [User Account Information]", connection);

            dataSet = new DataSet();

            try
            {
                adapter.Fill(dataSet, "User Account Information");

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while connecting to the database: " + ex.Message);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void USERusn_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateDatabase()
        {
            try
            {
                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);

                // This automatically adds [ ] around your column names in the SQL query
                builder.QuotePrefix = "[";
                builder.QuoteSuffix = "]";

                adapter.Update(dataSet, "User Account Information");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving status to database: " + ex.Message);
            }
        }

        private async void loginUSER_Click(object sender, EventArgs e)
        {
            string loggingUSN = USERusn.Text;
            string loggingPASS = USERpass.Text;

            DataRow[] foundRows = dataSet.Tables["User Account Information"].Select($"Username = '{loggingUSN}'");

            if (foundRows.Length > 0)
            {
                DataRow row = foundRows[0]; // We found the user

                if (Convert.ToBoolean(row["Locked"]) == true || Convert.ToBoolean(row["Active"]) == false)
                {
                    MessageBox.Show("Your account is locked or disabled.");
                    return;
                }

                if (row["Password"].ToString() == loggingPASS)
                {
                    row["Attempts"] = 0;
                    UpdateDatabase();

                    MapUserSession(row);

                    string login_Info = $@"<h3>Security Alert: New Login Detected</h3>..."; // your email string
                    _ = GlobalEmailNotificationModule.send_Notification(UserSession.UserInstance.Email, "Security Alert: New Login", login_Info);

                    UserAccount.Instance.Show();
                    this.Hide();
                }
                else
                {
                    int attempts = Convert.ToInt32(row["Attempts"]) + 1;
                    row["Attempts"] = attempts;
                    int remaining = 10 - attempts;

                    if (attempts >= 10)
                    {
                        row["Locked"] = true;
                        MessageBox.Show("Account LOCKED due to too many failed attempts.");
                    }
                    else
                    {
                        MessageBox.Show($"Incorrect password! {remaining} attempts remaining.");
                    }
                    UpdateDatabase();
                }
            }
            else
            {
                MessageBox.Show("Invalid Username. Please try again.");
            }
        }

        private void MapUserSession (DataRow row)
        {
            UserSession.UserInstance.ID = Convert.ToInt32(row["User ID"]);
            UserSession.UserInstance.Username = row["Username"].ToString();
            UserSession.UserInstance.Password = row["Password"].ToString();
            UserSession.UserInstance.FirstName = row["First Name"].ToString();
            UserSession.UserInstance.MiddleName = row["Middle Name"].ToString();
            UserSession.UserInstance.LastName = row["Last Name"].ToString();
            UserSession.UserInstance.Birthdate = Convert.ToDateTime(row["Birthdate"]);
            UserSession.UserInstance.Address = row["Address"].ToString();
            UserSession.UserInstance.Age = Convert.ToInt32(row["Age"]);
            UserSession.UserInstance.Category = row["Category"].ToString();
            UserSession.UserInstance.Gender = row["Gender"].ToString();
            UserSession.UserInstance.ContactNumber = Convert.ToInt64(row["Contact Number"]);
            UserSession.UserInstance.Email = row["Email Account"].ToString();
            UserSession.UserInstance.Hotline = row["Hotline"].ToString();
            UserSession.UserInstance.Active = Convert.ToBoolean(row["Active"]);
            UserSession.UserInstance.Locked = Convert.ToBoolean(row["Locked"]);

            UserSession.UserInstance.Attempt = Convert.ToInt32(row["Attempts"]);
            UserSession.UserInstance.Locked = false;
        }
        private void UserLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void USERpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void backHomepage_Click(object sender, EventArgs e)
        {
            home = new Homepageee();
            this.Hide();
            home.Show();
        }

        private void Close_Form_After_Run(object sender, FormClosingEventArgs e)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }

            // Force the entire environment to shut down
            Environment.Exit(0);
        }

        private void press_showpassword(object sender, EventArgs e)
        {
            if (press_check.Checked)
            {
                USERpass.UseSystemPasswordChar = false;
            }
            else
            {
                USERpass.UseSystemPasswordChar = true;
            }
        }
    }
}
