using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class AdminAccount : Form
    {
        private static AdminAccount instance;
        public AdminAccount()
        {
            InitializeComponent();
        }

        internal static AdminAccount Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new AdminAccount();
                }

                return instance;
            }


        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Homepageee homepage = new Homepageee();

            homepage.Show();

            this.Hide();
        }

        private void AdminAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void contactDeveloperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactUs contactDeveloper = new ContactUs();

            contactDeveloper.Show();

        }

        private void GoToTransportSchedule(object sender, EventArgs e)
        {
            try
            {
                AdminTransportSchedule.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Transport Schedule page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToAccountControl(object sender, EventArgs e)
        {
            try
            {
                AdminAccountControl.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Account Control page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToSalesReport(object sender, EventArgs e)
        {
            try
            {
                AdminSalesReport.Instance.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Sales Report page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logoutAdmin (object sender, EventArgs e)
        {
            try
            {
                Homepageee.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to logging out:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
