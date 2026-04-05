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
    }
}
