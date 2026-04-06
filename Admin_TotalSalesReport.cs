using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class Admin_TotalSalesReport : Form
    {
        private static Admin_TotalSalesReport instance;
        public Admin_TotalSalesReport()
        {
            InitializeComponent();
        }

        internal static Admin_TotalSalesReport Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Admin_TotalSalesReport();
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
