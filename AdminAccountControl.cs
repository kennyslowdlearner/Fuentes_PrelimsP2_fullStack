using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class AdminAccountControl : Form
    {
        private static AdminAccountControl instance;
        public AdminAccountControl()
        {
            InitializeComponent();
        }

        internal static AdminAccountControl Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new AdminAccountControl();
                }

                return instance;
            }
        }
        private void button8_Click(object sender, EventArgs e)
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
