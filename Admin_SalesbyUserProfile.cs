using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class Admin_SalesbyUserProfile : Form
    {
        private static Admin_SalesbyUserProfile instance;
        public Admin_SalesbyUserProfile()
        {
            InitializeComponent();
        }

        internal static Admin_SalesbyUserProfile Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Admin_SalesbyUserProfile();
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
