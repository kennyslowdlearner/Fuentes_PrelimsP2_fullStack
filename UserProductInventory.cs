using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class productInventory : Form
    {
        DataTable ProductInventory = new DataTable();
        public productInventory()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductInventory.Columns.Add("numberPI", typeof(int));
            ProductInventory.Columns.Add("productnamePI", typeof(string));
            ProductInventory.Columns.Add("quantityPI", typeof(int));
            ProductInventory.Columns.Add("productidPI", typeof(string));
        }

        private void backoptionPI_click(object sender, EventArgs e)
        {
            UserAccount userAccount = new UserAccount("","","");
            userAccount.Show();
            this.Hide();
        }

        private void logoutoptionPI_click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
            this.Hide();
        }
    }
}
