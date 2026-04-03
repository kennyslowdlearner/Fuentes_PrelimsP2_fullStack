using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class User_SoilEvaluator : Form
    {
        private static User_SoilEvaluator instance;
        public User_SoilEvaluator()
        {
            InitializeComponent();
        }

        //(Global User Session) Component
        internal static User_SoilEvaluator Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new User_SoilEvaluator();

                return instance;
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }
    }
}
