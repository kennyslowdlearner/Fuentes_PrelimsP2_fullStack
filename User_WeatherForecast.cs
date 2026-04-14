using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace Fuentes_PrelimsP2
{
    public partial class User_WeatherForecast : Form
    {
        private static User_WeatherForecast instance;
        public User_WeatherForecast()
        {
            InitializeComponent();
            InitializeWeatherChart();
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


        private void InitializeWeatherChart()
        {
            
        }

        private async Task FetchRealTimeWeather(string city)
        {
            string apiKey = "1012a9d5b4ece91b4a8564f3bf40c2b8";
            string url = $"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid={apiKey}&units=metric";


            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync(url);
                    var data = JsonConvert.DeserializeObject<WeatherResponse>(json);


                    for (int a = 0; a < data.list.Count; a += 8)
                    {
                        var forecast = data.list[a];
                        DateTime date = DateTimeOffset.FromUnixTimeSeconds(forecast.dt).DateTime.ToLocalTime();

                        double weatherValue = (1 - forecast.pop) * 100;

                        string label = date.ToString("ddd (MM dd)");

                        
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Weather Update Failed: " + ex.Message);
            }
        }

        private void shortcut_SoilEvaluator(object sender, EventArgs e)
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

        private void shortcut_ActivityLog(object sender, EventArgs e)
        {
            try
            {
                User_ActivityLog.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to opeActivity Log page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void shortcut_RiceYieldandEstimation(object sender, EventArgs e)
        {
            try
            {
                User_RiceYieldandEstimation.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Rice Yield/Estimation page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void shortcut_WeatherForecasting(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        User_WeatherForecast.Instance.Show();
        //        this.Hide();
        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Failed to open Weather Forecast page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //} find another function okay

        private void backButton(object sender, EventArgs e)
        {
            try
            {
                RiceYieldEstimationandRegistry.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fill_search_wf_TextChanged(object sender, EventArgs e)
        {
            function_timer_wf.Stop();
            function_timer_wf.Start();
        }
            
        private void searchTimer_Tick(object sender, EventArgs e)
        {
            function_timer_wf.Stop();

            string city = fill_search_wf.Text.Trim();

            if (city.Length >= 3) _ = FetchRealTimeWeather(city);
        }
    }

    public class WeatherResponse
    {
        public List<ForecastItem> list { get; set; }
    }

    public class ForecastItem
    {
        public long dt { get; set; }
        public MainData main { get; set; }
        public List<WeatherDescription> weather { get; set; }
        public double pop { get; set; }
    }

    public class MainData
    {
        public double temp { get; set; }
    }

    public class WeatherDescription
    {
        public string main { get; set; }
    }
}
