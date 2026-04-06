using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class AdminTransportSchedule : Form
    {
        private static AdminTransportSchedule instance;
        public AdminTransportSchedule()
        {
            InitializeComponent();
        }

        internal static AdminTransportSchedule Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new AdminTransportSchedule();
                }

                return instance;
            }
        }

        private void label26_Click(object sender, EventArgs e)
        {

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
