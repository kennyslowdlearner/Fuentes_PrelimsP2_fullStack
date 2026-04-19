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

        private async void loginUSER_Click(object sender, EventArgs e)
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


                        userFound = true;
                        break;
                    }
                }

                if (userFound)
                {
                    //first 2 lines are used for email notification
                    string login_Info = $@"
                                        <h3>Security Alert: New Login Detected</h3>
                                        <p>Hello <b>{UserSession.UserInstance.FirstName}</b>,</p>
                                        <p>A new login was detected on your <b>Pananom</b> account. Contact the developer if it wasn't you. Thank you and have a nice day ahead!</p>
                                        <p><b>Time:</b> {DateTime.Now.ToString("f")}<br>
                                        <b>Location:</b> Cebu City, Philippines (Estimated)</p>
                                        <p>If this was not you, please contact support immediately via the Hotline: 331-567.</p>
                                        <hr>
                                        <p style='color:gray; font-size:10px;'>
                                            This is an automated message from the Project Pananom System. <br>
                                            Cebu Institute of Technology – University | BS Computer Engineering
                                        </p>";


                    //apply decoupling here
                    _ = GlobalEmailNotificationModule.send_Notification(UserSession.UserInstance.Email, "Security Alert: New Login", login_Info);
                    
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
    }
}
