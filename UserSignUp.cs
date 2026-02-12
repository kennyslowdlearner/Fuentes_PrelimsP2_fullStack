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


            FIRSTname = firstName.Text;
            MIDDLEname = middleName.Text;
            LASTname = lastName.Text;

            UserAccount userAccount = new UserAccount(FIRSTname, MIDDLEname, LASTname);

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
