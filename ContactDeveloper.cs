using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class ContactDeveloper : Form
    {
        public ContactDeveloper()
        {
            InitializeComponent();
        }

        // Event handler for clickable labels (wired in the designer). No action required.
        private void label4_Click(object sender, EventArgs e)
        {
            // Intentionally left blank.
        }

        // Back button closes the form
        private void button2_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage(); 

            homepage.Show(); 
            this.Close();
        }
    }
}
