using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class User_MarketForecast : Form
    {
        private static User_MarketForecast instance;
        public User_MarketForecast()
        {
            InitializeComponent();
        }

        //(Global User Session) Component
        internal static User_MarketForecast Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new User_MarketForecast();

                return instance;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
