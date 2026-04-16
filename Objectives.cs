using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class Objectives : Form
    {
        private static Objectives instance;

        public Objectives()
        {
            InitializeComponent();
        }
        internal static Objectives Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Objectives();
                }
                return instance;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Homepageee homepage = new Homepageee();

            homepage.Show();

            this.Hide();
        }
    }
}
