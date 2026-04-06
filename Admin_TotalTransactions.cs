using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class Admin_TotalTransactions : Form
    {
        private static Admin_TotalTransactions instance;
        public Admin_TotalTransactions()
        {
            InitializeComponent();
        }

        internal static Admin_TotalTransactions Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Admin_TotalTransactions();
                }
                return instance;
            }
        }

        private void backButton(object sender, EventArgs e)
        {
            try
            {
                AdminSalesReport.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
