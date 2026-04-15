using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class VisionMission : Form
    {
        public VisionMission()
        {
            InitializeComponent();
        }

        private void backButton2_Click_1(object sender, EventArgs e)
        {
            Homepageee homepage = new Homepageee();
            homepage.Show();
            this.Hide();
        }
    }
}
