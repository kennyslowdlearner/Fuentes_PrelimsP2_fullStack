using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class User_DigitalReceiptVault : Form
    {
        private static User_DigitalReceiptVault instance;
        public User_DigitalReceiptVault()
        {
            InitializeComponent();
        }

        //(Global User Session) Component
        internal static User_DigitalReceiptVault Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new User_DigitalReceiptVault();

                return instance;
            }
        }
        private void printPreviewDialog2_Load(object sender, EventArgs e)
        {

        }
    }
}
