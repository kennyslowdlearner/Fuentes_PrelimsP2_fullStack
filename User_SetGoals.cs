using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class User_SetGoals : Form
    {
        private static User_SetGoals instance;
        public User_SetGoals()
        {
            InitializeComponent();
        }

        internal static User_SetGoals Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new User_SetGoals();
                }
                return instance;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void backButton(object sender, EventArgs e)
        {
            try
            {
                UserFinancialGoals.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
