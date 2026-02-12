using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void loginADMIN_Click(object sender, EventArgs e)
        {
            string sampleAdminUserName, sampleAdminPassword;

            sampleAdminUserName = ADMINusn.Text;
            sampleAdminPassword = ADMINpass.Text;

            if (sampleAdminUserName == "admin123" && sampleAdminPassword == "admin123")
            {
                AdminAccount adminAccount = new AdminAccount();

                MessageBox.Show("Login Successful!");

                adminAccount.Show();

                this.Hide();
            }
        }

        private void AdminLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
