using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class UserSignUp : Form
    {

        public static string FIRSTname, MIDDLEname, LASTname;
        public UserSignUp()
        {
            InitializeComponent();
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
            UserSession.UserInstance.FirstName = firstName.Text;
            UserSession.UserInstance.MiddleName = middleName.Text;
            UserSession.UserInstance.LastName = lastName.Text;
            UserSession.UserInstance.Birthdate = birthDate.Text;
            UserSession.UserInstance.Address = address.Text;
            UserSession.UserInstance.Age = Convert.ToInt32(age.Text);
            UserSession.UserInstance.Category = categoryDropdown.Text;
            UserSession.UserInstance.Gender = genderDropdown.Text;

            UserSession.UserInstance.Username = usernameSIGN.Text;
            UserSession.UserInstance.Password = cpasswordSIGN.Text;

            UserSession.UserInstance.ContactNumber = Convert.ToInt64(contactNumber.Text);
            UserSession.UserInstance.Email = emailAccount.Text;
            UserSession.UserInstance.Hotline = hotlineNumber.Text;

            if (passwordSIGN != cpasswordSIGN)
            {
                MessageBox.Show("Make sure your password matched!");
                return;
            }

            if (!TCbutton.Checked)
            {
                MessageBox.Show("Tick the Terms and Conditions before signing up");
                return;
            }

            UserAccount userAccount = new UserAccount();

            userAccount.Show();
            this.Hide();
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
