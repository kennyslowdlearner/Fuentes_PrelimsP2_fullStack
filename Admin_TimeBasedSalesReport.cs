using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class Admin_TimeBasedSalesReport : Form
    {
        private static Admin_TimeBasedSalesReport instance;
        public Admin_TimeBasedSalesReport()
        {
            InitializeComponent();
        }

        internal static Admin_TimeBasedSalesReport Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Admin_TimeBasedSalesReport();
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
