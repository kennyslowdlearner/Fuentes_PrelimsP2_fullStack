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

        string Product, ID, Quantity;
        bool AddRow;
        public productInventory(string productname, string productid, string quantity, bool addRow)
        {
            InitializeComponent();

            this.Product = productname;
            this.ID = productid;
            this.Quantity = quantity;
            this.AddRow = addRow;

            InitializeTableAndBind();

            if(addRow)
            {
                AddProductRow(productname, productid, quantity);
            }
        }

        public void AddProductRow(string productname, string productid, string quantity)
        {
            if (ProductInventory == null)
                ProductInventory = new DataTable();

            if (!ProductInventory.Columns.Contains("numberPI"))
            {
                ProductInventory.Columns.Add("numberPI", typeof(int));
                ProductInventory.Columns.Add("productnamePI", typeof(string));
                ProductInventory.Columns.Add("quantityPI", typeof(float));
                ProductInventory.Columns.Add("productidPI", typeof(string));
            }

            var newRow = ProductInventory.NewRow();
            newRow["numberPI"] = ProductInventory.Rows.Count + 1;
            newRow["productnamePI"] = productname ?? string.Empty;

            float quantityValue = 0f;
            if (!string.IsNullOrWhiteSpace(quantity))
                float.TryParse(quantity, out quantityValue);

            newRow["quantityPI"] = quantityValue;
            newRow["productidPI"] = productid ?? string.Empty;
            ProductInventory.Rows.Add(newRow);

            if (dataGridView1 != null)
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ProductInventory;
                dataGridView1.Refresh();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void InitializeTableAndBind()
        {
            if (!ProductInventory.Columns.Contains("numberPI"))
            {
                ProductInventory.Columns.Add("numberPI", typeof(int));
                ProductInventory.Columns.Add("productnamePI", typeof(string));
                ProductInventory.Columns.Add("quantityPI", typeof(float));
                ProductInventory.Columns.Add("productidPI", typeof(string));
            }

            dataGridView1.AutoGenerateColumns = false;

            if (dataGridView1.Columns.Contains("Number"))
                dataGridView1.Columns["Number"].DataPropertyName = "numberPI";
            if (dataGridView1.Columns.Contains("productName"))
                dataGridView1.Columns["productName"].DataPropertyName = "productnamePI";
            if (dataGridView1.Columns.Contains("quantityProduct"))
                dataGridView1.Columns["quantityProduct"].DataPropertyName = "quantityPI";
            if (dataGridView1.Columns.Contains("idProduct"))
                dataGridView1.Columns["idProduct"].DataPropertyName = "productidPI";

            dataGridView1.DataSource = ProductInventory;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // no-op
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void searchBoxPI_TextChanged(object sender, EventArgs e)
        {
            // no-op
        }

        private void searchbuttonPI_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void usermenuPI_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // no-op
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserAddProductInventory addproductinventory = new UserAddProductInventory(this);
            addproductinventory.Show();
        }

        private void updatePrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Implement update product flow here when needed
        }

        private void deleteRemoveProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Implement delete/remove product flow here when needed
        }

        private void activityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            // no-op
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void profileName_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void label3_Click(object sender, EventArgs e)
        {
            // no-op
        }

        private void backoptionPI_click(object sender, EventArgs e)
        {
            UserAccount userAccount = new UserAccount("", "", "");
            userAccount.Show();
            this.Hide();
        }

        private void logoutoptionPI_click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
            this.Hide();
        }

        private void productInventory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
