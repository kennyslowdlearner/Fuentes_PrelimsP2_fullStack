using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace Fuentes_PrelimsP2
{
    public partial class User_WeatherForecast : Form
    {
        private static User_WeatherForecast instance;
        private CartesianChart weatherLineChart;

        public User_WeatherForecast()
        {
            InitializeComponent();
            InitializeWeatherChart();
            // Defaulting to Cebu to maintain localized precision for Project Pananom
            _ = FetchRealTimeWeather("Cebu");
        }

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
            weatherLineChart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X,
                FindingStrategy = LiveChartsCore.Measure.FindingStrategy.CompareAllTakeClosest,
                // Customizing colors to match your high-protein, professional UI palette
                TooltipBackgroundPaint = new SolidColorPaint(new SKColor(35, 35, 35, 230)),
                TooltipTextPaint = new SolidColorPaint(SKColors.White)
            };

            // Set focus on mouse enter to enable immediate Ctrl+Scroll zooming on your Acer Swift 3
            weatherLineChart.MouseEnter += (s, e) => { weatherLineChart.Focus(); };

            Weather_Chart_Information.Controls.Add(weatherLineChart);
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

                    if (data?.list == null) return;

                    // Use Invoke to ensure UI updates happen safely on your Windows 10 Pro environment
                    this.Invoke((MethodInvoker)delegate
                    {
                        UpdateSummaryPanel(data);
                        UpdateDetailedChart(data);
                    });
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Weather Error: " + ex.Message);
            }
        }

        // Updated Summary Panel with a fix for the "Blank" issue
        private void UpdateSummaryPanel(WeatherResponse data)
        {
            // Force transparency to remove that white background
            Weather_Information.BackColor = Color.Transparent;
            Weather_Information.Controls.Clear();

            FlowLayoutPanel container = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                WrapContents = false,
                BackColor = Color.Transparent
            };

            var forecastGroups = data.list
                .GroupBy(x => DateTimeOffset.FromUnixTimeSeconds(x.dt).DateTime.ToLocalTime().Date)
                .ToList();

            // Sunday to Saturday Logic
            DateTime today = DateTime.Today;
            int diff = (7 + (today.DayOfWeek - DayOfWeek.Sunday)) % 7;
            DateTime startOfWeek = today.AddDays(-diff);

            for (int i = 0; i < 7; i++)
            {
                DateTime targetDay = startOfWeek.AddDays(i);
                var dayData = forecastGroups.FirstOrDefault(g => g.Key == targetDay)?.FirstOrDefault();

                // Dark box design from image_c6a6ac.jpg
                Panel dayCard = new Panel
                {
                    Size = new Size(180, 150),
                    Margin = new Padding(10),
                    BackColor = Color.FromArgb(40, 40, 40)
                };

                Label lblDay = new Label { Text = targetDay.ToString("dddd"), ForeColor = Color.White, Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 10, FontStyle.Bold), Height = 30 };
                Label lblDate = new Label { Text = targetDay.ToString("MMM dd"), ForeColor = Color.LightGray, Dock = DockStyle.Top, TextAlign = ContentAlignment.MiddleCenter, Height = 20 };

                string tempText = dayData != null ? $"{dayData.main.temp:N1}°C" : "N/A";
                Label lblTemp = new Label { Text = tempText, ForeColor = Color.Gold, Font = new Font("Segoe UI", 16, FontStyle.Bold), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter };

                string rainText = dayData != null ? $"Rain: {dayData.pop * 100:N0}%" : "";
                Label lblProb = new Label { Text = rainText, ForeColor = Color.SkyBlue, Dock = DockStyle.Bottom, TextAlign = ContentAlignment.MiddleCenter, Height = 30 };

                dayCard.Controls.Add(lblTemp);
                dayCard.Controls.Add(lblDate);
                dayCard.Controls.Add(lblDay);
                dayCard.Controls.Add(lblProb);
                container.Controls.Add(dayCard);
            }

            Weather_Information.Controls.Add(container);

            // Ensure the new weather data is visible on top of your background
            Weather_Information.BringToFront();
        }


        private void UpdateDetailedChart(WeatherResponse data)
        {
            // Capture temperatures and status strings for the tooltips
            var temps = data.list.Select(x => (double)x.main.temp).ToArray();
            var statuses = data.list.Select(x => x.weather[0].main).ToArray();
            var labels = data.list.Select(x => DateTimeOffset.FromUnixTimeSeconds(x.dt).DateTime.ToLocalTime().ToString("MMM dd, HH:mm")).ToArray();

            weatherLineChart.Series = new ISeries[]
            {
        new LineSeries<double>
        {
            Values = temps,
            Name = "Temperature",
            Fill = new SolidColorPaint(SKColors.Goldenrod.WithAlpha(40)),
            Stroke = new SolidColorPaint(SKColors.Goldenrod) { StrokeThickness = 3 },
            GeometrySize = 10,
            GeometryFill = new SolidColorPaint(SKColors.White),
            GeometryStroke = new SolidColorPaint(SKColors.DodgerBlue) { StrokeThickness = 2 },
            
            // TOOLTIP: Shows Date, Temp, and Status (Sunny/Rainy)
            YToolTipLabelFormatter = point => {
                var index = (int)point.Index;
                string dateStr = labels[index];
                string status = statuses[index];
                return $"{dateStr}\nTemp: {point.Coordinate.PrimaryValue:N1}°C\nStatus: {status}";
            }
        }
            };

            weatherLineChart.XAxes = new Axis[] {
        new Axis {
            Labels = labels,
            LabelsPaint = new SolidColorPaint(SKColors.DimGray),
            TextSize = 10,
            Labeler = (value) => labels.ElementAtOrDefault((int)value) ?? ""
        }
    };

            weatherLineChart.YAxes = new Axis[] {
        new Axis {
            Labeler = v => $"{v}°C",
            LabelsPaint = new SolidColorPaint(SKColors.DimGray),
            TextSize = 12
        }
    };
        }

        private async Task FetchCurrentWeather(string city)
        {
            string apiKey = "1012a9d5b4ece91b4a8564f3bf40c2b8";
            // Current weather endpoint is different from forecast
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = await client.GetStringAsync(url);
                    dynamic current = JsonConvert.DeserializeObject(json);

                    this.Invoke((MethodInvoker)delegate
                    {
                        // Update your "Current Weather" labels here
                        // For example, if you have a label named lbl_current_city:
                        // lbl_current_city.Text = $"{current.name}: {current.main.temp}°C, {current.weather[0].main}";

                        System.Diagnostics.Debug.WriteLine($"Search Result: {current.name} is {current.main.temp}°C");
                    });
                }
            }
            catch { /* Handle invalid city names silently or with a small indicator */ }
        }

        private void fill_search_wf_TextChanged(object sender, EventArgs e)
        {
            // Restarts the delay timer every time you type a character
            function_timer_wf.Stop();
            function_timer_wf.Start();
        }
        private void searchTimer_Tick(object sender, EventArgs e)
        {
            function_timer_wf.Stop(); // Ensure it doesn't repeat

            string city = fill_search_wf.Text.Trim();

            if (city.Length >= 3)
            {
                // For debugging on your Acer Swift 3, check the Output window
                System.Diagnostics.Debug.WriteLine("Fetching weather for: " + city);
                _ = FetchRealTimeWeather(city);
            }
        }

        private void backButton(object sender, EventArgs e)
        {
            RiceYieldEstimationandRegistry.Instance.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            User_SoilEvaluator.Instance.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            User_RiceYieldandEstimation.Instance.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User_ActivityLog.Instance.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }

    // --- JSON MODEL CLASSES ---
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
        public string description { get; set; }
    }
}