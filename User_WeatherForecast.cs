using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class User_WeatherForecast : Form
    {
        private static User_WeatherForecast instance;
        public User_WeatherForecast()
        {
            InitializeComponent();
        }

        //(Global User Session) Component
        internal static User_WeatherForecast Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new User_WeatherForecast();

                return instance;
            }
        }
    }
}
