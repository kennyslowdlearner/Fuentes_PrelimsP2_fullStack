using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class UserFinancialGoals : Form
    {
        private static UserFinancialGoals instance;
        public UserFinancialGoals()
        {
            InitializeComponent();
            display_name_and_date();
        }

        //(Global User Session) Component
        internal static UserFinancialGoals Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new UserFinancialGoals();
                }

                return instance;
            }
        }

        private void display_name_and_date()
        {
            string name_in_session = UserSession.UserInstance.FirstName + " " + UserSession.UserInstance.MiddleName + " " + UserSession.UserInstance.LastName;
            display_name_fg.Text = name_in_session;
            systemTimer.Start();
        }
        private void sssssToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GoToSetGoals(object sender, EventArgs e)
        {
            User_SetGoals.Instance.Show();
            this.Hide();
        }

        private void GoToStatisticalProgress(object sender, EventArgs e)
        {
            User_StatisticalProgress.Instance.Show();
            this.Hide();
        }

        private void bbackButton(object sender, EventArgs e)
        {
            UserAccount.Instance.Show();
            this.Hide();
        }

        private void systemTimer_Tick(object sender, EventArgs e)
        {
            string name_in_session = UserSession.UserInstance.FirstName + " " +
                                     UserSession.UserInstance.MiddleName + " " +
                                     UserSession.UserInstance.LastName;
            display_name_fg.Text = name_in_session;

            display_datetime_fg.Text = DateTime.Now.ToString("MMMM dd, yyyy | hh:mm:ss tt");
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Homepageee.Instance.Show();
            this.Dispose();
        }

        private void learnMoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageUs.Instance.Show();
        }
    }
}
