using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class User_DigitalReceiptVault : Form
    {
        private static User_DigitalReceiptVault instance;
        public User_DigitalReceiptVault()
        {
            InitializeComponent();
        }

        //(Global User Session) Component
        internal static User_DigitalReceiptVault Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new User_DigitalReceiptVault();

                return instance;
            }
        }
        private void printPreviewDialog2_Load(object sender, EventArgs e)
        {

        }

        private void shortcut_Transactions(object sender, EventArgs e)
        {
            try
            {
                User_TransactionSheet.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Transaction Sheet page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void shortcut_CostOfProduction(object sender, EventArgs e)
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

        private void shortcut_MarketForecasting(object sender, EventArgs e)
        {
            try
            {
                User_MarketForecast.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Market Forecast page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backbutton(object sender, EventArgs e)
        {
            try
            {
                UserTradesandTransactions.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
