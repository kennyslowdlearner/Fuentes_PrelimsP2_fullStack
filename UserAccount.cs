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
            display_name_and_date();
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
            //string name_in_session = UserSession.UserInstance.FirstName + " " + UserSession.UserInstance.MiddleName + " " + UserSession.UserInstance.LastName;
            //profileName.Text = name_in_session;
        }

        private void display_name_and_date()
        {
            string name_in_session = UserSession.UserInstance.FirstName + " " + UserSession.UserInstance.MiddleName + " " + UserSession.UserInstance.LastName;
            profileName.Text = name_in_session;
            systemTimer.Start();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Homepageee homepage = new Homepageee();

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
                UserSession.reset();

                if (User_ActivityLog.Instance != null) User_ActivityLog.Instance.Dispose();
                if (User_CostofProduction.Instance != null) User_CostofProduction.Instance.Dispose();
                if (User_DigitalReceiptVault.Instance != null) User_DigitalReceiptVault.Instance.Dispose();
                if (User_MarketForecast.Instance != null) User_MarketForecast.Instance.Dispose();
                if (User_RiceYieldandEstimation.Instance != null) User_RiceYieldandEstimation.Instance.Dispose();
                if (User_SetGoals.Instance != null) User_SetGoals.Instance.Dispose();
                if (User_SoilEvaluator.Instance != null) User_SoilEvaluator.Instance.Dispose();
                if (User_StatisticalProgress.Instance != null) User_StatisticalProgress.Instance.Dispose();
                if (User_TransactionSheet.Instance != null) User_TransactionSheet.Instance.Dispose();
                if (User_TransactionSheetAnalytics.Instance != null) User_TransactionSheetAnalytics.Instance.Dispose();
                if (User_VarietalRegistry.Instance != null) User_VarietalRegistry.Instance.Dispose();
                if (User_WeatherForecast.Instance != null) User_WeatherForecast.Instance.Dispose();

                if (farmgateUSER.Instance != null) farmgateUSER.Instance.Dispose();
                if (UserFinancialGoals.Instance != null) UserFinancialGoals.Instance.Dispose();
                if (UserLogin.Instance != null) UserLogin.Instance.Dispose();
                if (productInventory.Instance != null) productInventory.Instance.Dispose();
                if (UserProductInventory_Analytics.Instance != null) UserProductInventory_Analytics.Instance.Dispose();
                if (UserSignUp.Instance != null) UserSignUp.Instance.Dispose();
                if (UserTradesandTransactions.Instance != null) UserTradesandTransactions.Instance.Dispose();
                if (UserTransportSchedule.Instance != null) UserTransportSchedule.Instance.Dispose();

                if (LoginOptions.Instance != null) LoginOptions.Instance.Dispose();
                if (MessageUs.Instance != null) MessageUs.Instance.Dispose();
                if (Objectives.Instance != null) Objectives.Instance.Dispose();
                if (SupportUs.Instance != null) SupportUs.Instance.Dispose();
                if (VisionMission.Instance != null) VisionMission.Instance.Dispose();


                Homepageee.Instance.Show();
                this.Dispose();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to logging out:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string name_in_session = UserSession.UserInstance.FirstName + " " +
                                     UserSession.UserInstance.MiddleName + " " +
                                     UserSession.UserInstance.LastName;
            profileName.Text = name_in_session;

            display_datetime_Udashboard.Text = DateTime.Now.ToString("MMMM dd, yyyy | hh:mm:ss tt");
        }

        private void sendMessageOrFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageUs.Instance.Show();
        }

        private void chatWithAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalUserChatModule.Instance.Show();
        }
    }
}
