using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class User_VarietalRegistry : Form
    {
        private static User_VarietalRegistry instance;
        public User_VarietalRegistry()
        {
            InitializeComponent();
        }

        //(Global User Session) Component
        internal static User_VarietalRegistry Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new User_VarietalRegistry();

                return instance;
            }
        }
    }
}
