using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class UserTradesandTransactions : Form
    {

        // This class needs UI design for main dashboard's buttons as well as for SET GOALS

        private static UserTradesandTransactions instance;
        public UserTradesandTransactions()
        {
            InitializeComponent();
            display_name_and_date();
        }

        //(Global User Session) Component
        internal static UserTradesandTransactions Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new UserTradesandTransactions();
                }

                return instance;
            }
        }

        private void display_name_and_date()
        {
            string name_in_session = UserSession.UserInstance.FirstName + " " + UserSession.UserInstance.MiddleName + " " + UserSession.UserInstance.LastName;
            display_name_TandT.Text = name_in_session;
            systemTimer.Start();
        }

        private void back_Button(object sender, EventArgs e)
        {
            UserAccount.Instance.Show();
            this.Hide();
        }

        private void GoToAddTransaction(object sender, EventArgs e)
        {
            try
            {
                User_TransactionSheet.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Add Transaction page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToViewTransaction(object sender, EventArgs e)
        {
            try
            {
                User_TransactionSheet.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Farmgate page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToDigitalVaultReceipt(object sender, EventArgs e)
        {
            try
            {
                User_DigitalReceiptVault.Instance.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Digital Vault Receipt page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToCostOfProduction(object sender, EventArgs e)
        {
            try
            {
                User_CostofProduction.Instance.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Cost of Production page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToMarketForecasting(object sender, EventArgs e)
        {
            try
            {
                User_MarketForecast.Instance.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Market Forecasting page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void systemTimer_Tick(object sender, EventArgs e)
        {
            string name_in_session = UserSession.UserInstance.FirstName + " " +
                                     UserSession.UserInstance.MiddleName + " " +
                                     UserSession.UserInstance.LastName;
            display_name_TandT.Text = name_in_session;

            display_datetime_TandT.Text = DateTime.Now.ToString("MMMM dd, yyyy | hh:mm:ss tt");
        }

        private void learnMoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageUs.Instance.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Homepageee.Instance.Show();
            this.Dispose();
        }
    }
}
