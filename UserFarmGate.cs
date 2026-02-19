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
        // Strongly-typed entry for the farmgate list
        private class FarmgateEntry
        {
            public int numberFGP { get; set; }
            public string productnameFGP { get; set; }
            public float priceFGP { get; set; }
            public string productidFGP { get; set; }
            public DateTime dateFGP { get; set; }
        }

        string Product, ID;
        float Price;

        // Replace DataTable with a binding list for strongly-typed rows
        private BindingList<FarmgateEntry> FGPentries;

        public farmgateUSER(string productname, string productid, float price)
        {
            InitializeComponent();

            Product = productname;
            ID = productid;
            Price = price;

            // Initialize and populate the grid immediately so the newly added farmgate
            // entry is visible as soon as this form is shown.
            InitializeListAndBind();
        }

        // Parameterless constructor fallback
        public farmgateUSER()
        {
            InitializeComponent();
            InitializeListAndBind();
        }

        private void InitializeListAndBind()
        {
            // Create the binding list if needed
            if (FGPentries == null)
                FGPentries = new BindingList<FarmgateEntry>();

            // If constructor provided values, add them as the first row
            //ROW 1
            if (!string.IsNullOrEmpty(Product) && !string.IsNullOrEmpty(ID) && Price != 0f)
            {
                FGPentries.Add(new FarmgateEntry
                {
                    numberFGP = FGPentries.Count + 1,
                    productnameFGP = Product,
                    priceFGP = Price,
                    productidFGP = ID,
                    dateFGP = DateTime.Now
                });
            }
           
            //ROW2
            // Provide a sample first row so the grid isn't empty
            FGPentries.Add(new FarmgateEntry
            {
                numberFGP = 1,
                productnameFGP = "Ganador",
                priceFGP = 37.89f,
                productidFGP = "100-2026",
                dateFGP = DateTime.Now
            });

            //ROW3
            FGPentries.Add(new FarmgateEntry
            {
                numberFGP = 2,
                productnameFGP = "Ivory",
                priceFGP = 34.26f,
                productidFGP = "101-2026",
                dateFGP = DateTime.Now
            });




            // Ensure the grid uses generated columns from the list's properties
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = true;
            // Make the grid fill the panel and have columns stretch to use available space
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = FGPentries;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // no-op: grid is bound to a list and rows should be added via code (Add dialog) or edit UI
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

        private void addproductFGP_Click(object sender, EventArgs e)
        {
            UserAddFarmgate addFarmgate = new UserAddFarmgate();

            addFarmgate.Show();
        }

        private void farmgateUSER_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
