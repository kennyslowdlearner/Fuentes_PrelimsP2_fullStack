using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class UserAddProductInventory : Form
    {
        private productInventory? parentInventory;

        public UserAddProductInventory()
        {
            InitializeComponent();
        }

        public UserAddProductInventory(productInventory parent)
        {
            InitializeComponent();
            parentInventory = parent;
        }

        private void confirmPI_Click(object sender, EventArgs e)
        {
            string productname = addproductnamePI.Text;
            string quantity = quantityPI.Text;
            string productid = addproductidPI.Text;
            bool addRow = true;

            if (string.IsNullOrEmpty(productname) || string.IsNullOrEmpty(productid))
            {
                MessageBox.Show("Complete the details on the corresponding textboxes.");
                return;
            }


            if (parentInventory != null)
            {
                parentInventory.AddProductRow(productname, productid, quantity);
                this.Close(); 
            }
            else
            {
                productInventory newInv = new productInventory(productname, productid, quantity, true);
                newInv.Show();
                this.Close();
            }
        }
    }
}
