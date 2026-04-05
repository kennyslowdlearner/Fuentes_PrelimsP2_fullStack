using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class farmgateUSER : Form
    {

        private static farmgateUSER instance;

        internal static farmgateUSER Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new farmgateUSER();

                return instance;
            }
        }
        private void farmgateUser_Load(object sender, EventArgs e)
        {
            string name_in_session = UserSession.UserInstance.FirstName + " " + UserSession.UserInstance.MiddleName + " " + UserSession.UserInstance.LastName;

        }
        private void backoptionFPG_Click(object sender, EventArgs e)
        {
            UserAccount.Instance.Show();
            this.Hide();
        }

        private void logoutoptionFPG_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
            this.Hide();

        }

        private void farmgateUSER_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void backoptionFPG_Click_1(object sender, EventArgs e)
        {
            UserAccount useraccount = new UserAccount();
            useraccount.Show();
            this.Hide();
        }

        private void logoutoptionFPG_Click_1(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
            this.Hide();
        }
    }
}