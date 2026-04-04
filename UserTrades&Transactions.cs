using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class UserTradesandTransactions : Form
    {

        // This class needs UI design for main dashboard's buttons as well as for SET GOALS

        private static UserTradesandTransactions instance;
        public UserTradesandTransactions()
        {
            InitializeComponent();
        }

        //(Global User Session) Component
        private static UserTradesandTransactions Instance
        {
            get
            {
                if(instance == null || instance.IsDisposed)
                {
                    instance = new UserTradesandTransactions();
                }

                return instance;
            }
        }
    }
}
