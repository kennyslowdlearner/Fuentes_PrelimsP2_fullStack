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
        private static SupportUs instance;
        public SupportUs()
        {
            InitializeComponent();
        }

        internal static SupportUs Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new SupportUs();
                }
                return instance;
            }
        }
        // Back button closes the form (wired in designer)
        private void supportBack_Click(object sender, EventArgs e)
        {
            Homepageee homepage = new Homepageee();

            homepage.Show();
            this.Close();
        }
    }
}
