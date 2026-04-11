using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class UserAccount : Form
    {
        private static UserAccount instance;

        public UserAccount()
        {
            InitializeComponent();
        }

        internal static UserAccount Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new UserAccount();
                return instance;
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void viewAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void profileName_Click(object sender, EventArgs e)
        {
            //made changes here (2) [4/1/2026 | 10:41 PM]
            string name_in_session = UserSession.UserInstance.FirstName + " " + UserSession.UserInstance.MiddleName + " " + UserSession.UserInstance.LastName;
            profileName.Text = name_in_session;
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
            try
            {
                productInventory.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Product Inventory:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //farmgateUSER userFarmGate = new farmgateUSER();
                //userFarmGate.Show();
                //this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Farmgate page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToProductInventoryPage(object sender, EventArgs e)
        {
            try
            {
                productInventory.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Product Inventory:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToFarmgatePricePage(object sender, EventArgs e)
        {
            try
            {
                farmgateUSER.Instance.Show();
                //this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Farmgate page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToFinancialGoalsPage(object sender, EventArgs e)
        {
            try
            {
                UserFinancialGoals.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Financial Goals page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToTradesandTransactionsPage(object sender, EventArgs e)
        {
            try
            {
                UserTradesandTransactions.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Trades & Transactions page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToTransportSchedulePage(object sender, EventArgs e)
        {
            try
            {
                UserTransportSchedule.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Transport Schedule page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToRiceYieldEstimationandRegistryPage(object sender, EventArgs e)
        {
            try
            {
                RiceYieldEstimationandRegistry.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Rice Yield Estimation & Registry page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logoutUser(object sender, EventArgs e)
        {
            try
            {
                Homepage.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to logging out:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
