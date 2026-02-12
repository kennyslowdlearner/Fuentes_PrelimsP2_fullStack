using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class SupportUs : Form
    {
        public SupportUs()
        {
            InitializeComponent();
        }

        // Back button closes the form (wired in designer)
        private void supportBack_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage();

            homepage.Show();
            this.Close();
        }
    }
}
