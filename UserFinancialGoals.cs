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
        }

        //(Global User Session) Component
        private static UserFinancialGoals Instance
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

        private void sssssToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GoToSetGoals(object sender, EventArgs e)
        {

        }

        private void GoToStatisticalProgress(object sender, EventArgs e)
        {
            User_StatisticalProgress.Instance.Show();
            this.Hide();
        }
    }
}
