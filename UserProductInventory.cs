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
            // Initialize the DataTable and bind it to the grid when the form is created
            InitializeTableAndBind();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Intentionally left blank. Do not initialize or add columns/rows here;
            // this event fires when the user clicks a cell. Table is initialized on form creation.
        }

        // Initialize DataTable schema, add sample data and bind to the DataGridView
        private void InitializeTableAndBind()
        {
            // Prevent adding columns multiple times
            if (!ProductInventory.Columns.Contains("numberPI"))
            {
                ProductInventory.Columns.Add("numberPI", typeof(int));
                ProductInventory.Columns.Add("productnamePI", typeof(string));
                ProductInventory.Columns.Add("quantityPI", typeof(float));
                ProductInventory.Columns.Add("productidPI", typeof(string));
            }

            // Add a sample row
            var row1 = ProductInventory.NewRow();
            row1["numberPI"] = ProductInventory.Rows.Count + 1;
            row1["productnamePI"] = "Ganador";
            row1["quantityPI"] = 378; // must match column type (float)
            row1["productidPI"] = "100-2026";
            ProductInventory.Rows.Add(row1);

            var row2 = ProductInventory.NewRow();
            row2["numberPI"] = ProductInventory.Rows.Count + 1;
            row2["productnamePI"] = "Ivory";
            row2["quantityPI"] = 326; // must match column type (float)
            row2["productidPI"] = "101-2026";
            ProductInventory.Rows.Add(row2);

            // Bind the DataTable to the grid so rows appear in the UI
            // Make sure the grid uses the designer columns (keep header texts/widths)
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersVisible = true;

            // Lock the "No." column so it doesn't stretch or shrink weirdly
            dataGridView1.Columns["Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Alternatively, set a fixed width if you want it exactly like your designer
            dataGridView1.Columns["Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["Number"].Width = 86;


            // Ensure the grid fills the panel and columns use available space without shrinking
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Make sure designer columns map to the table's column names
            if (dataGridView1.Columns.Contains("Number"))
                dataGridView1.Columns["Number"].DataPropertyName = "numberPI";
            if (dataGridView1.Columns.Contains("productName"))
                dataGridView1.Columns["productName"].DataPropertyName = "productnamePI";
            if (dataGridView1.Columns.Contains("quantityProduct"))
                dataGridView1.Columns["quantityProduct"].DataPropertyName = "quantityPI";
            if (dataGridView1.Columns.Contains("idProduct"))
                dataGridView1.Columns["idProduct"].DataPropertyName = "productidPI";

            dataGridView1.DataSource = ProductInventory;

            // Ensure headers are shown and the grid layout is refreshed
            dataGridView1.ColumnHeadersVisible = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.Refresh();
        }

        // Designer event handlers (stubs) ---------------------------------
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
            // Implement add product flow here when needed
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
