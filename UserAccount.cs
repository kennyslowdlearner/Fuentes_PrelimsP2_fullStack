using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class UserAccount : Form
    {
        string FIRSTname, MIDDLEname, LASTname;
        public UserAccount(string FIRSTname, string MIDDLEname, string LASTname)
        {
            InitializeComponent();

            this.FIRSTname = FIRSTname;
            this.MIDDLEname = MIDDLEname;
            this.LASTname = LASTname;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void viewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void profileName_Click(object sender, EventArgs e)
        {
            string fullName;

            fullName = FIRSTname + " " + MIDDLEname + " " + LASTname;

            profileName.Text = fullName;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();

            homepage.Show();

            this.Hide();
        }

        private void UserAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void contactDeveloperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountContactUs Acontactus = new AccountContactUs();

            Acontactus.Show();
        }

        private void supportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountSupportUs AsupportUS = new AccountSupportUs();

            AsupportUS.Show();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            productInventory productInventory = new productInventory("", "", "", true);

            productInventory.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            farmgateUSER userFarmGate = new farmgateUSER();

            userFarmGate.Show();
            this.Hide();
        }
    }
}
