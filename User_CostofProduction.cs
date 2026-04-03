using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class User_CostofProduction : Form
    {
        private static User_CostofProduction instance;
        public User_CostofProduction()
        {
            InitializeComponent();
        }

        //(Global User Session) Component
        internal static User_CostofProduction Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new User_CostofProduction();

                return instance;
            }
        }
    }
}
