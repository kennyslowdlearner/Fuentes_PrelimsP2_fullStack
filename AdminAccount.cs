using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class AdminAccount : Form
    {
        public AdminAccount()
        {
            InitializeComponent();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();

            homepage.Show();

            this.Hide();
        }

        private void AdminAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void contactDeveloperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactUs contactDeveloper = new ContactUs();

            contactDeveloper.Show();

        }
    }
}
