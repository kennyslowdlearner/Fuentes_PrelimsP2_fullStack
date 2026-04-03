using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class User_RiceYieldandEstimation : Form
    {
        private static User_RiceYieldandEstimation instance;
        public User_RiceYieldandEstimation()
        {
            InitializeComponent();
        }

        //(Global User Session) Component
        internal static User_RiceYieldandEstimation Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new User_RiceYieldandEstimation();

                return instance;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
