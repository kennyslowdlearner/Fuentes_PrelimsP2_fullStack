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
        
        private farmgateUSER mainGridForm;
        public UserAddFarmgate(farmgateUSER parent)
        {
            InitializeComponent();
            mainGridForm = parent;  
        }

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
            string Product = addproductnameFPG.Text;
            string ID = addproductidFGP.Text;
            float Price = 0f;
            if (float.TryParse(addfarmgatepriceFGP.Text, out float price))
            {
                if (mainGridForm != null)
                {
                    mainGridForm.AddEntry(Product, ID, price);
                }
                else
                {
                    MessageBox.Show("Cannot add entry: parent form not available.");
                }
            }
            else
                MessageBox.Show("Please enter a valid price.");

            this.Close();

        }

        private void searchbuttonFPG_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}