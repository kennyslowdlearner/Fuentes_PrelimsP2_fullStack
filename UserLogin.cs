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
        Homepage home;

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;

        public UserLogin()
        {
            InitializeComponent();


            //made changes here (4) [4/3/2026 | 11:11 AM]
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Y:\second year college\SECOND SEM Jan 20, 2026\CPE262 OOP2\Project Proposal\Project Pananom.accdb";
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

        private void loginUSER_Click(object sender, EventArgs e)
        {
            //Made changes here (3) on [4/1/2026 | 9:47 AM]
            //this is for logging in the user, it will check if the username and password matches the one in the session,
            //if not it will show a message box, if yes it will show the farmgate form and hide this form
            string loggingUSN = USERusn.Text;
            string loggingPASS = USERpass.Text;
            bool userFound = false;

            try
            {
                foreach (DataRow row in dataSet.Tables["User Account Information"].Rows)
                {
                    if (row["Username"].ToString() == loggingUSN && row["Password"].ToString() == loggingPASS)
                    {
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


                        userFound = true;
                        break;
                    }
                }

                if (userFound)
                {
                    UserAccount.Instance.Show();
                    this.Hide();
                }

                else MessageBox.Show("Invalid Username or Password. Please try again.");
                //SAMPLE: USN = kennymeow PASS = kennymeow123
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while logging in: " + ex.Message);
            }
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
            home = new Homepage();
            this.Hide();
            home.Show();
        }
    }
}
