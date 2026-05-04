using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class User_MarketForecast : Form
    {
        private static User_MarketForecast instance;
        private List<RiceFarmgateData> allRiceData = new List<RiceFarmgateData>();
        public User_MarketForecast()
        {
            InitializeComponent();
            this.Load += new EventHandler(displayFarmgate);
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

        private double CleanAndParsePrice(string INPUT)
        {
            if (string.IsNullOrWhiteSpace(INPUT)) return 0.0;

            string cleaned = INPUT.Replace("₱", "").Replace(",", "").Trim();

            if (cleaned.Contains("-")) cleaned = cleaned.Split('-')[0].Trim();

            return double.TryParse(cleaned, out double result) ? result : 0.0;
        }

        internal async Task<List<RiceFarmgateData>> LiveScrapingWeb()
        {
            var riceList = new List<RiceFarmgateData>();
            string url = "http://www.bantaypresyo.da.gov.ph/tbl_rice.php";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
                    string html = await client.GetStringAsync(url);
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    // Get all header columns to identify market names
                    var headers = doc.DocumentNode.SelectNodes("//table//th");
                    if (headers == null) return riceList;

                    // Get all data rows
                    var rows = doc.DocumentNode.SelectNodes("//table//tr");
                    if (rows == null) return riceList;

                    foreach (var row in rows)
                    {
                        var cells = row.SelectNodes("td");
                        // Skip rows that don't have enough data
                        if (cells == null || cells.Count < 3) continue;

                        string commodity = cells[0].InnerText.Trim();
                        string spec = cells[1].InnerText.Trim();

                        // Skip the "NFA" or unit rows
                        if (commodity.Equals("COMMODITY") || spec.Equals("KG")) continue;

                        // Loop through market columns (starting from index 2 based on your image)
                        for (int i = 2; i < cells.Count; i++)
                        {
                            string priceRaw = cells[i].InnerText.Trim();

                            // Only add if there is a valid price (skip "N/A")
                            if (!priceRaw.Equals("N/A") && !string.IsNullOrEmpty(priceRaw))
                            {
                                double price = CleanAndParsePrice(priceRaw);

                                riceList.Add(new RiceFarmgateData
                                {
                                    Region = "Region VII",
                                    CityMarket = headers[i].InnerText.Trim().Replace("\n", " "),
                                    RiceType = commodity.Contains("Imported") ? $"Imported {spec}" : $"Local {spec}",
                                    CurrentPrice = price,
                                    ForecastedPrice = price * 1.05, // 5% Forecast as Digital Safeguard
                                    Trend = "Stable",
                                    LastUpdated = DateTime.Now
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Scrape Error: " + ex.Message);
            }
            return riceList;
        }

        private async Task<List<RiceFarmgateData>> GetBestAvailableData()
        {
            string folderPath = @"C:\Pananom Database";
            string backupPath = System.IO.Path.Combine(folderPath, "market_backup.json");

            // Ensure the Digital Safeguard directory exists
            if (!System.IO.Directory.Exists(folderPath))
                System.IO.Directory.CreateDirectory(folderPath);

            // 1. Try Live Scrape
            List<RiceFarmgateData> data = await LiveScrapingWeb();

            if (data != null && data.Count > 0)
            {
                allRiceData = data;
                // Save to local backup for offline persistence
                System.IO.File.WriteAllText(backupPath, JsonConvert.SerializeObject(allRiceData));
                return allRiceData;
            }

            // 2. Try Backup
            if (System.IO.File.Exists(backupPath))
            {
                allRiceData = JsonConvert.DeserializeObject<List<RiceFarmgateData>>(System.IO.File.ReadAllText(backupPath));
                return allRiceData;
            }

            // 3. Final Fallback to National Defaults
            allRiceData = GetDefaultMarketData();
            return allRiceData;
        }

        private List<RiceFarmgateData> GetDefaultMarketData()
        {
            return new List<RiceFarmgateData>
    {
        // Luzon
        new RiceFarmgateData { Region = "NCR", CityMarket = "Malabon", RiceType = "Well-Milled Rice", CurrentPrice = 52.00, ForecastedPrice = 54.00, Trend = "Rising", LastUpdated = DateTime.Now },
        new RiceFarmgateData { Region = "CAR", CityMarket = "Baguio City", RiceType = "Premium Rice", CurrentPrice = 60.00, ForecastedPrice = 60.00, Trend = "Stable", LastUpdated = DateTime.Now },
        new RiceFarmgateData { Region = "Region I", CityMarket = "Laoag City", RiceType = "Regular Milled", CurrentPrice = 46.00, ForecastedPrice = 45.00, Trend = "Falling", LastUpdated = DateTime.Now },
        new RiceFarmgateData { Region = "Region II", CityMarket = "Tuguegarao City", RiceType = "Well-Milled Rice", CurrentPrice = 48.50, ForecastedPrice = 49.00, Trend = "Rising", LastUpdated = DateTime.Now },
        new RiceFarmgateData { Region = "Region III", CityMarket = "Cabanatuan City", RiceType = "Premium Rice", CurrentPrice = 55.00, ForecastedPrice = 55.00, Trend = "Stable", LastUpdated = DateTime.Now },
        new RiceFarmgateData { Region = "Region IV-A", CityMarket = "Antipolo City", RiceType = "Well-Milled Rice", CurrentPrice = 53.00, ForecastedPrice = 55.00, Trend = "Rising", LastUpdated = DateTime.Now },
        new RiceFarmgateData { Region = "Region IV-B", CityMarket = "Calapan City", RiceType = "Regular Milled", CurrentPrice = 44.00, ForecastedPrice = 44.00, Trend = "Stable", LastUpdated = DateTime.Now },
        new RiceFarmgateData { Region = "Region V", CityMarket = "Albay (Legazpi)", RiceType = "Regular Milled", CurrentPrice = 48.00, ForecastedPrice = 46.00, Trend = "Falling", LastUpdated = DateTime.Now },

        // Visayas
        new RiceFarmgateData { Region = "Region VI", CityMarket = "Iloilo City", RiceType = "Well-Milled Rice", CurrentPrice = 49.00, ForecastedPrice = 48.50, Trend = "Falling", LastUpdated = DateTime.Now },
        new RiceFarmgateData { Region = "Region VII", CityMarket = "Cebu City", RiceType = "Ganador", CurrentPrice = 58.00, ForecastedPrice = 58.00, Trend = "Stable", LastUpdated = DateTime.Now },
        new RiceFarmgateData { Region = "Region VII", CityMarket = "Bohol (Tagbilaran)", RiceType = "Well-Milled Rice", CurrentPrice = 55.00, ForecastedPrice = 54.00, Trend = "Falling", LastUpdated = DateTime.Now },
        new RiceFarmgateData { Region = "Region VIII", CityMarket = "Samar (Catbalogan)", RiceType = "Regular Milled", CurrentPrice = 50.00, ForecastedPrice = 52.00, Trend = "Rising", LastUpdated = DateTime.Now },

        // Mindanao
        new RiceFarmgateData { Region = "Region IX", CityMarket = "Zamboanga City", RiceType = "Well-Milled Rice", CurrentPrice = 54.00, ForecastedPrice = 55.00, Trend = "Rising", LastUpdated = DateTime.Now },
        new RiceFarmgateData { Region = "Region X", CityMarket = "Cagayan de Oro", RiceType = "Premium Rice", CurrentPrice = 57.00, ForecastedPrice = 57.00, Trend = "Stable", LastUpdated = DateTime.Now },
        new RiceFarmgateData { Region = "Region XI", CityMarket = "Davao City", RiceType = "Well-Milled Rice", CurrentPrice = 52.50, ForecastedPrice = 51.00, Trend = "Falling", LastUpdated = DateTime.Now },
        new RiceFarmgateData { Region = "Region XII", CityMarket = "General Santos", RiceType = "Regular Milled", CurrentPrice = 47.00, ForecastedPrice = 48.00, Trend = "Rising", LastUpdated = DateTime.Now },
        new RiceFarmgateData { Region = "Region XIII", CityMarket = "Butuan City", RiceType = "Well-Milled Rice", CurrentPrice = 51.00, ForecastedPrice = 51.00, Trend = "Stable", LastUpdated = DateTime.Now },
        new RiceFarmgateData { Region = "BARMM", CityMarket = "Cotabato City", RiceType = "Regular Milled", CurrentPrice = 45.00, ForecastedPrice = 45.00, Trend = "Stable", LastUpdated = DateTime.Now }
    };
        }

        private void FormatGrid()
        {
            if (Market_Forecast_Grid.Columns.Count == 0) return;

            Market_Forecast_Grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            Market_Forecast_Grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Set specific widths for your Acer Swift 3 screen
            Market_Forecast_Grid.Columns["CityMarket"].Width = 200;
            Market_Forecast_Grid.Columns["RiceType"].Width = 200;

            // Standardize price columns
            Market_Forecast_Grid.Columns["CurrentPrice"].DefaultCellStyle.Format = "₱0.00";
            Market_Forecast_Grid.Columns["ForecastedPrice"].DefaultCellStyle.Format = "₱0.00";
        }

        private void FormatCebuStyleGrid()
        {
            // Match the blue header style from image_c47e65.png
            Market_Forecast_Grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 122, 183); // DA Blue
            Market_Forecast_Grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Market_Forecast_Grid.EnableHeadersVisualStyles = false;

            // UI Layout for your 14-inch screen
            Market_Forecast_Grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 245, 255);
            Market_Forecast_Grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            Market_Forecast_Grid.RowHeadersVisible = false;

            // Auto-size for readability
            Market_Forecast_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Bold the first column (Rice Types) to match the site's layout
            Market_Forecast_Grid.Columns[0].DefaultCellStyle.Font = new Font(Market_Forecast_Grid.Font, FontStyle.Bold);
        }
        private void SetupCebuMarketGrid(List<RiceFarmgateData> data)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Commodity / Rice Type");

            // 1. Identify all unique Cebu markets from your scraped data
            var markets = data.Select(x => x.CityMarket).Distinct().ToList();
            foreach (var market in markets)
            {
                dt.Columns.Add(market);
            }

            // 2. Identify all rice types (Well-Milled, Regular, etc.)
            var riceTypes = data.Select(x => x.RiceType).Distinct().ToList();

            // 3. Fill the table row by row
            foreach (var type in riceTypes)
            {
                DataRow row = dt.NewRow();
                row["Commodity / Rice Type"] = type;

                foreach (var market in markets)
                {
                    var priceEntry = data.FirstOrDefault(x => x.RiceType == type && x.CityMarket == market);
                    row[market] = priceEntry != null ? $"₱{priceEntry.CurrentPrice:F2}" : "N/A";
                }
                dt.Rows.Add(row);
            }

            Market_Forecast_Grid.DataSource = dt;
            FormatCebuStyleGrid();
        }

        private void shortcut_DigitalReceiptVault(object sender, EventArgs e)
        {
            try
            {
                User_DigitalReceiptVault.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Digitall Receipt Vault page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void shortcut_CostOfProduction(object sender, EventArgs e)
        {
            try
            {
                User_CostofProduction.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open cost of Production page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void shortcut_Transactions(object sender, EventArgs e)
        {
            try
            {
                User_TransactionSheet.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Transaction page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backbutton(object sender, EventArgs e)
        {
            try
            {
                UserTradesandTransactions.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillSearchBox_TextChanged(object sender, EventArgs e)
        {
            // Restarts your specific function timer (ensure interval is ~300-500ms)
            function_timer_mf.Stop();
            function_timer_mf.Start();
        }

        private void marketSearchTimer_Tick(object sender, EventArgs e)
        {
            function_timer_mf.Stop();

            string searchTerm = searchBoxPI.Text.ToLower().Trim();

            if (allRiceData == null || allRiceData.Count == 0) return;

            // Logic: If search is empty, default to Cebu City. Otherwise, filter by search term.
            var filteredData = string.IsNullOrEmpty(searchTerm)
                ? allRiceData.Where(x => x.CityMarket.Contains("Cebu City")).ToList()
                : allRiceData.Where(x =>
                    x.Region.ToLower().Contains(searchTerm) ||
                    x.CityMarket.ToLower().Contains(searchTerm) ||
                    x.RiceType.ToLower().Contains(searchTerm)).ToList();

            Market_Forecast_Grid.DataSource = null;
            Market_Forecast_Grid.DataSource = filteredData;

            FormatGrid();
        }

        private async void displayFarmgate(object sender, EventArgs e)
        {
            // Stage 1 & 2: Fetch data (Scrape or Backup)
            List<RiceFarmgateData> allData = await GetBestAvailableData();

            // Stage 3: Filter specifically for Cebu City / Region 7
            var cebuData = allData.Where(x =>
                x.Region.Contains("VII") ||
                x.CityMarket.ToLower().Contains("cebu") ||
                x.CityMarket.ToLower().Contains("tabunok") ||
                x.CityMarket.ToLower().Contains("mandaue")
            ).ToList();

            if (cebuData.Count > 0)
            {
                SetupCebuMarketGrid(cebuData);
            }
            else
            {
                // If no localized data found, show national list as a safeguard
                Market_Forecast_Grid.DataSource = allData.Take(10).ToList();
                FormatGrid();
            }
        }

        private async void User_MarketForecast_Load(object sender, EventArgs e)
        {
            displayFarmgate(sender, e);
        }
    }

    public class RiceFarmgateData
    {
        public string Region { get; set; }
        public string CityMarket { get; set; }
        public string RiceType { get; set; }
        public double CurrentPrice { get; set; }
        public double ForecastedPrice { get; set; }
        public string Trend { get; set; }
        public DateTime LastUpdated { get; set; }

    }

    
}
