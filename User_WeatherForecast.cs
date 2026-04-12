using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
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

        Chart weatherChart;

        private void InitializeWeatherChart()
        {
            weatherChart = new Chart();
            weatherChart.Parent = Weather_Chart_Information;
            weatherChart.Dock = DockStyle.Fill;
            weatherChart.BackColor = Color.Transparent;

            ChartArea area = new ChartArea("MainArea");
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 100;
            area.AxisY.Interval = 25;

            // Descriptive Y-Axis
            area.AxisY.CustomLabels.Add(0, 20, "Rainy");
            area.AxisY.CustomLabels.Add(40, 60, "Cloudy");
            area.AxisY.CustomLabels.Add(80, 100, "Sunny");

            area.BackColor = Color.FromArgb(200, 240, 248, 240); // Slightly more opaque
            weatherChart.ChartAreas.Add(area);

            Series tempSeries = new Series("ConditionTrend");
            tempSeries.ChartType = SeriesChartType.Spline;

            // *** CRITICAL LINE: This spreads the days out ***
            tempSeries.XValueType = ChartValueType.String;

            tempSeries.BorderWidth = 3;
            tempSeries.Color = Color.OrangeRed;
            tempSeries.MarkerStyle = MarkerStyle.Circle;
            tempSeries.MarkerSize = 10;
            weatherChart.Series.Add(tempSeries);

            Random rng = new Random();
            for (int i = 0; i < 5; i++)
            {
                string dayLabel = DateTime.Now.AddDays(i).ToString("ddd (MMM dd)");
                int weatherValue = rng.Next(15, 90);

                var pointIndex = tempSeries.Points.AddXY(dayLabel, weatherValue);

                if (weatherValue >= 75)
                    tempSeries.Points[pointIndex].Color = Color.Gold;
                else if (weatherValue <= 25)
                    tempSeries.Points[pointIndex].Color = Color.DodgerBlue;
            }

            // Force labels to show up every time
            area.AxisX.Interval = 1;
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

                    weatherChart.Series[0].Points.Clear();

                    for (int a = 0; a < data.list.Count; a += 8)
                    {
                        var forecast = data.list[a];
                        DateTime date = DateTimeOffset.FromUnixTimeSeconds(forecast.dt).DateTime.ToLocalTime();

                        double weatherValue = (1 - forecast.pop) * 100;

                        string label = date.ToString("ddd (MM dd)");
                        int pIdx = weatherChart.Series[0].Points.AddXY(label, weatherValue);

                        if (weatherValue >= 70)
                            weatherChart.Series[0].Points[pIdx].Color = Color.Gold;
                        else if (weatherValue <= 30)
                            weatherChart.Series[0].Points[pIdx].Color = Color.DodgerBlue;
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
