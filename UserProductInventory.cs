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
        private static productInventory instance;
        public productInventory()
        {
            InitializeComponent();
        }

        internal static productInventory Instance
        {
            //made changes here (5) [4/3/2026 | 12:24 PM]
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new productInventory();
                }

                return instance;
            }
        }

        public void AddProductRow(string productname, string productid, string quantity)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void InitializeTableAndBind()
        {

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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void backButton(object sender, EventArgs e)
        {
            UserAccount.Instance.Show();
            this.Hide();
        }

        private void Close_Form_After_Run(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}
