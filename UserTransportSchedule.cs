using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class UserTransportSchedule : Form
    {
        private static UserTransportSchedule instance;
        public UserTransportSchedule()
        {
            InitializeComponent();
        }

        //(Global User Session) Component
        private static UserTransportSchedule Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new UserTransportSchedule();

                return instance;
            }
        }
    }
}
