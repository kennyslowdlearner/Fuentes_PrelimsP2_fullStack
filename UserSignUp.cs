using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Fuentes_PrelimsP2
{
    public partial class UserSignUp : Form
    {

        private string initialPassword, confirmPassword;
        public UserSignUp()
        {
            InitializeComponent();
        }

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;

        private void connectionDB()
        { 
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Y:\second year college\SECOND SEM Jan 20, 2026\CPE262 OOP2\Project Proposal\Project Pananom.accdb";
            connection = new OleDbConnection(connectionString);
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

                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
                adapter.Update(dataSet, "User Account Information");


                UserAccount.Instance.Show();

                this.Hide();
            }
            catch(Exception ex)
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
    }
}
