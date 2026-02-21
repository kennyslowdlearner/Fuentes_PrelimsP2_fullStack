using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class farmgateUSER : Form
    {
        public class FarmGateEntry
        {
            public string Product { get; set; }
            public string ID { get; set; }
            public float Price { get; set; }
            public int Number { get; set; }
        }

        private BindingList<FarmGateEntry> farmGateEntries = new BindingList<FarmGateEntry>();
        public farmgateUSER()
        {
            InitializeComponent();
            SetupDataGridView();
        }

        public farmgateUSER(string productname, string productid, float price)
        {
            InitializeComponent();
            SetupDataGridView();
            AddEntry(productname, productid, price);
        }


        private void SetupDataGridView()
        {
            displayFGPblock.AutoGenerateColumns = false;

            if (displayFGPblock.Columns.Contains("numberFGP"))
                displayFGPblock.Columns["numberFGP"].DataPropertyName = "Number";
            if (displayFGPblock.Columns.Contains("productnameFGP"))
                displayFGPblock.Columns["productnameFGP"].DataPropertyName = "Product";
            if (displayFGPblock.Columns.Contains("priceFGP"))
                displayFGPblock.Columns["priceFGP"].DataPropertyName = "Price";
            if (displayFGPblock.Columns.Contains("productidFGP"))
                displayFGPblock.Columns["productidFGP"].DataPropertyName = "ID";

            displayFGPblock.DataSource = farmGateEntries;

            if (displayFGPblock.Columns.Contains("dateFGP"))
                displayFGPblock.Columns.Remove("dateFGP");
        }

        public void AddEntry(string productname, string productid, float price)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() => AddEntry(productname, productid, price)));
                return;
            }

            displayFGPblock.DataSource = null;

            try
            {
                farmGateEntries.Add(new FarmGateEntry
                {
                    Number = farmGateEntries.Count + 1,
                    Product = productname,
                    ID = productid,
                    Price = price
                });

                displayFGPblock.DataSource = farmGateEntries;
                RebindColumns();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void RebindColumns()
        {
            if (displayFGPblock.Columns.Contains("numberFGP"))
                displayFGPblock.Columns["numberFGP"].DataPropertyName = "Number";
            if (displayFGPblock.Columns.Contains("productnameFGP"))
                displayFGPblock.Columns["productnameFGP"].DataPropertyName = "Product";
            if (displayFGPblock.Columns.Contains("priceFGP"))
                displayFGPblock.Columns["priceFGP"].DataPropertyName = "Price";
            if (displayFGPblock.Columns.Contains("productidFGP"))
                displayFGPblock.Columns["productidFGP"].DataPropertyName = "ID";

            if (displayFGPblock.Columns.Contains("numberFGP"))
                displayFGPblock.Columns["numberFGP"].Width = 50;
        }

        private void addproductFGP_Click(object sender, EventArgs e)
        {
            using (UserAddFarmgate addFarmgate = new UserAddFarmgate(this))
                addFarmgate.ShowDialog();
        }

        private void backoptionFPG_Click(object sender, EventArgs e)
        {
            UserAccount useraccount = new UserAccount("", "", "");
            useraccount.Show();
            this.Hide();
        }

        private void logoutoptionFPG_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
            this.Hide();

        }

        private void farmgateUSER_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dateViewFGP(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void backoptionFPG_Click_1(object sender, EventArgs e)
        {
            UserAccount useraccount = new UserAccount("", "", "");
            useraccount.Show();
            this.Hide();
        }

        private void logoutoptionFPG_Click_1(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();
            homepage.Show();
            this.Hide();
        }
    }
}