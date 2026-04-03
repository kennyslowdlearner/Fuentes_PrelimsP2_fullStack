using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class User_TransactionSheet : Form
    {
        private static User_TransactionSheet instance;
        public User_TransactionSheet()
        {
            InitializeComponent();
        }

        //(Global User Session) Component
        internal static User_TransactionSheet Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new User_TransactionSheet();

                return instance;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
    }
}
