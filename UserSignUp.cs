using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
// using System.Data.OleDb; (duplicate removed)
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Fuentes_PrelimsP2
{
    public partial class UserSignUp : Form
    {
        private static UserSignUp instance;

        internal static UserSignUp Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new UserSignUp();
                }
                return instance;
            }
        }

        private string initialPassword, confirmPassword;

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;

        public UserSignUp()
        {
            //made changes here (6) [4/3/2026 | 1:41 PM]
            InitializeComponent();

            connectionDB();

            if (connection == null)
            {
                MessageBox.Show("Database connection was not established. Sign-up functionality will be disabled.");
                return;
            }

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


        private void connectionDB()
        {
            // Attempt to find a provider that can open the database and report diagnostics.
            string dbPath = @"C:\Pananom Database\Prooject Pananom Data.accdb";
            string[] providersToTry = new[] { "Microsoft.ACE.OLEDB.16.0", "Microsoft.ACE.OLEDB.12.0" };

            MessageBox.Show($"Attempting DB path: {dbPath}\nIs64BitProcess: {Environment.Is64BitProcess}");

            Exception lastEx = null;

            foreach (var provider in providersToTry)
            {
                try
                {
                    string connectionString = $"Provider={provider};Data Source={dbPath};Persist Security Info=False;";
                    using (var testConn = new OleDbConnection(connectionString))
                    {
                        testConn.Open();
                        testConn.Close();
                    }

                    // success - store connection to use later
                    connection = new OleDbConnection($"Provider={provider};Data Source={dbPath};Persist Security Info=False;");
                    return;
                }
                catch (Exception ex)
                {
                    lastEx = ex;
                    // try next provider
                }
            }

            // If we reach here no provider worked
            if (lastEx != null)
            {
                MessageBox.Show("Failed to open Access database.\n" + lastEx.ToString(), "Database connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void signIn(object sender, EventArgs e)
        {
            //made changes here (1) [4/1/2026 | 10:29 PM]

            initialPassword = passwordSIGN.Text;
            confirmPassword = cpasswordSIGN.Text;

            if (!TCbutton.Checked)
            {
                MessageBox.Show("Tick the Terms and Conditions before signing up");
                return;
            }

            if (initialPassword != confirmPassword)
            {
                MessageBox.Show("Make sure your password matched!");
                return;
            }

            if (string.IsNullOrWhiteSpace(age.Text))
            {
                MessageBox.Show("Please enter your age.");
                return;
            }

            if (string.IsNullOrWhiteSpace(contactNumber.Text))
            {
                MessageBox.Show("Please enter your valid contact number.");
                return;
            }

            UserSession.UserInstance.FirstName = firstName.Text;
            UserSession.UserInstance.MiddleName = middleName.Text;
            UserSession.UserInstance.LastName = lastName.Text;
            UserSession.UserInstance.Birthdate = birthDate.Value;
            UserSession.UserInstance.Address = address.Text;
            UserSession.UserInstance.Age = Convert.ToInt32(age.Text);
            UserSession.UserInstance.Category = categoryDropdown.Text;
            UserSession.UserInstance.Gender = genderDropdown.Text;
            UserSession.UserInstance.Username = usernameSIGN.Text;
            UserSession.UserInstance.Password = cpasswordSIGN.Text;

            UserSession.UserInstance.ContactNumber = Convert.ToInt64(contactNumber.Text);
            UserSession.UserInstance.Email = emailAccount.Text;
            UserSession.UserInstance.Hotline = hotlineNumber.Text;

            try
            {
                DataRow newRow = dataSet.Tables["User Account Information"].NewRow();


                newRow["Username"] = UserSession.UserInstance.Username;
                newRow["Password"] = UserSession.UserInstance.Password;
                newRow["First Name"] = UserSession.UserInstance.FirstName;
                newRow["Middle Name"] = UserSession.UserInstance.MiddleName;
                newRow["Last Name"] = UserSession.UserInstance.LastName;
                newRow["Birthdate"] = UserSession.UserInstance.Birthdate;
                newRow["Address"] = UserSession.UserInstance.Address;
                newRow["Age"] = UserSession.UserInstance.Age;
                newRow["Category"] = UserSession.UserInstance.Category;
                newRow["Gender"] = UserSession.UserInstance.Gender;
                newRow["Contact Number"] = UserSession.UserInstance.ContactNumber;
                newRow["Email Account"] = UserSession.UserInstance.Email;
                newRow["Hotline"] = UserSession.UserInstance.Hotline;

                dataSet.Tables["User Account Information"].Rows.Add(newRow);

                //made changes here (7) [4/3/2026 | 1:54 PM]
                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);

                builder.QuotePrefix = "[";
                builder.QuoteSuffix = "]";

                adapter.Update(dataSet, "User Account Information");

                //----------------------------------------------------------------

                MessageBox.Show("DB Path: " + connection.ConnectionString);

                UserAccount.Instance.Show();

                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while signing up: " + ex.Message);
            }
        }

        private void TCbutton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cpasswordSIGN_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserSignUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
