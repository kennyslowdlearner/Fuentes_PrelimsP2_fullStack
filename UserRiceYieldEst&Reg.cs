using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class RiceYieldEstimationandRegistry : Form
    {

        private static RiceYieldEstimationandRegistry instance;
        public RiceYieldEstimationandRegistry()
        {
            InitializeComponent();
        }

        //(Global User Session) Component
        private static RiceYieldEstimationandRegistry Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new RiceYieldEstimationandRegistry();

                return instance;
            }
        }
    }
}
