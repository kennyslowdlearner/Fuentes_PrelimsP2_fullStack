using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class User_StatisticalProgress : Form
    {
        internal static User_StatisticalProgress instance;
        public User_StatisticalProgress()
        {
            InitializeComponent();
        }

        //(Global User Session) Component
        internal static User_StatisticalProgress Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new User_StatisticalProgress();

                return instance;
            }
        }

        private void bbackButton(object sender, EventArgs e)
        {
            try
            {
                UserFinancialGoals.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void User_StatisticalProgress_Load(object sender, EventArgs e)
        {

        }
    }
}
