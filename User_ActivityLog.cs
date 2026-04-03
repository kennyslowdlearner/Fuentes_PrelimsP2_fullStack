using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class User_ActivityLog : Form
    {
        private static User_ActivityLog instance;
        public User_ActivityLog()
        {
            InitializeComponent();
        }

        //(Global User Session) Component
        internal static User_ActivityLog Instance
        {
            get
            {
                if(instance  == null || instance.IsDisposed)
                    instance = new User_ActivityLog();

                return instance;
            }
        }
    }
}
