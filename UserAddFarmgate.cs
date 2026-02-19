using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class UserAddFarmgate : Form
    {
        public UserAddFarmgate()
        {
            InitializeComponent();
        }

        private void UserAddFarmgate_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void confirmFGP_Click(object sender, EventArgs e)
        {
            string productname = addproductnameFPG.Text.Trim();
            string productid = addproductidFGP.Text.Trim();

            if (string.IsNullOrEmpty(productname) || string.IsNullOrEmpty(productid))
            {
                MessageBox.Show("Please enter product name and product ID.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!float.TryParse(addfarmgatepriceFGP.Text, out float price))
            {
                MessageBox.Show("Please enter a valid numeric price.", "Invalid Price", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Instantiate target form and show it. If the parameterized constructor doesn't exist,
            // fall back to the parameterless constructor.
            try
            {
                var mainFPG = new farmgateUSER(productname, productid, price);
                mainFPG.Show();
                this.Close();
            }
            catch (MissingMethodException)
            {
                var mainFPG = new farmgateUSER();
                mainFPG.Show();
                this.Close();
            }

        }
            
    }
}
