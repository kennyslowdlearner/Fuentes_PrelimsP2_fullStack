using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class AdminSalesReport : Form
    {
        private static AdminSalesReport instance;
        public AdminSalesReport()
        {
            InitializeComponent();
        }

        internal static AdminSalesReport Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new AdminSalesReport();
                }

                return instance;
            }
        }

        private void GoToAdminSalesReport(object sender, EventArgs e)
        {
            try
            {
                Admin_TotalSalesReport.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Total Sales Report page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToSalesByProduct(object sender, EventArgs e)
        {
            try
            {
                Admin_SalesByProduct.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Sales by Product page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToSaleByUserProfile(object sender, EventArgs e)
        {
            try
            {
                Admin_SalesbyUserProfile.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Sales by User Profile page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToTimeBasedSalesReport(object sender, EventArgs e)
        {
            try
            {
                Admin_TimeBasedSalesReport.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Time-based Sales Report page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToTotalTransactions(object sender, EventArgs e)
        {
            try
            {
                Admin_TotalTransactions.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Total Transactions page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToInventoryManagement(object sender, EventArgs e)
        {
            try
            {
                Admin_InventoryManagement.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Inventory Management page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backButton(object sender, EventArgs e)
        {
            try
            {
                AdminAccount.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
