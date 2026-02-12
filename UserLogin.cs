using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void USERusn_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginUSER_Click(object sender, EventArgs e)
        {
            string sampleUser, samplePass;

            sampleUser = USERusn.Text;
            samplePass = USERpass.Text;

            if (sampleUser == "user123" && samplePass == "user123")
            {
                UserAccount userAccount = new UserAccount(UserSignUp.FIRSTname, UserSignUp.MIDDLEname, UserSignUp.LASTname);

                MessageBox.Show("Login Successful!");

                userAccount.Show();

                this.Hide();

            }
        }

        private void UserLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
