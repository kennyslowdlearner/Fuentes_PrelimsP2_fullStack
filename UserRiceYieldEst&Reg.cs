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
            display_name_and_date();
        }

        //(Global User Session) Component
        internal static RiceYieldEstimationandRegistry Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new RiceYieldEstimationandRegistry();

                return instance;
            }
        }

        private void display_name_and_date()
        {
            string name_in_session = UserSession.UserInstance.FirstName + " " + UserSession.UserInstance.MiddleName + " " + UserSession.UserInstance.LastName;
            display_name_ryer.Text = name_in_session;
            systemTimer.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UserAccount.Instance.Show();
            this.Hide();
        }

        private void GoToActivityLog(object sender, EventArgs e)
        {
            try
            {
                User_ActivityLog.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Activity Log page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToSoilEvaluator(object sender, EventArgs e)
        {
            try
            {
                User_SoilEvaluator.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Soil Evaluator page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToVarietalRegistry(object sender, EventArgs e)
        {
            try
            {
                User_VarietalRegistry.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Varietal Registry page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToWeatherForecasting(object sender, EventArgs e)
        {
            try
            {
                User_WeatherForecast.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Weather Forecast page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToViewRiceYieldandEstimation(object sender, EventArgs e)
        {
            try
            {
                User_RiceYieldandEstimation.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Rice Yield and Estimation page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoToAddRiceYieldandEstimation(object sender, EventArgs e)
        {
            try
            {
                User_RiceYieldandEstimation.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Rice Yield and Estimation Log page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void systemTimer_Tick(object sender, EventArgs e)
        {
            string name_in_session = UserSession.UserInstance.FirstName + " " +
                                     UserSession.UserInstance.MiddleName + " " +
                                     UserSession.UserInstance.LastName;
            display_name_ryer.Text = name_in_session;

            display_datetime_ryer.Text = DateTime.Now.ToString("MMMM dd, yyyy | hh:mm:ss tt");
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Homepageee.Instance.Show();
            this.Dispose();
        }

        private void SendMessageOrFeedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageUs.Instance.Show();
        }
    }
}
