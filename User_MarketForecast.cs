using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net.Http;

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
            string url = "http://www.bantaypresyo.da.gov.ph/";

            try
            {
                HtmlWeb web = new HtmlWeb();
                var infos = await web.LoadFromWebAsync(url);

                var rows = infos.DocumentNode.SelectNodes("//table[@id='rice-prices-table']//tr");

                if (rows != null)
                {
                    foreach (var row in rows.Skip(1))
                    {
                        var cells = row.SelectNodes("td");

                        if (cells != null && cells.Count >= 6)
                        {
                            riceList.Add(new RiceFarmgateData
                            {
                                Region = cells[0].InnerText.Trim(),
                                CityMarket = cells[1].InnerText.Trim(),
                                RiceType = cells[2].InnerText.Trim(),

                                CurrentPrice = CleanAndParsePrice(cells[3].InnerText),
                                ForecastedPrice = CleanAndParsePrice(cells[4].InnerText),

                                Trend = cells[5].InnerText.Trim(),
                                LastUpdated = DateTime.Now
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Project Pananom Error occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return riceList;
        }
        private void FormatGrid()
        {
            if (Market_Forecast_Grid.Columns["CurrentPrice"] != null)
                Market_Forecast_Grid.Columns["CurrentPrice"].DefaultCellStyle.Format = "₱0.00";

            if (Market_Forecast_Grid.Columns["ForecastedPrice"] != null)
                Market_Forecast_Grid.Columns["ForecastedPrice"].DefaultCellStyle.Format = "₱0.00";

            foreach (DataGridViewRow row in Market_Forecast_Grid.Rows)
            {
                var trendCell = row.Cells["Trend"];
                if (trendCell.Value != null)
                {
                    string trend = trendCell.Value.ToString();
                    if (trend.Contains("Rising")) trendCell.Style.ForeColor = Color.Red;
                    else if (trend.Contains("Falling")) trendCell.Style.ForeColor = Color.Green;
                    else trendCell.Style.ForeColor = Color.Black;
                }
            }
        }

        private async void displayFarmgate(object sender, EventArgs e)
        {
            try
            {
                allRiceData = await LiveScrapingWeb();
                Market_Forecast_Grid.DataSource = null;
                Market_Forecast_Grid.DataSource = allRiceData;

                if (Market_Forecast_Grid.Columns["CurrentPrice"] != null)
                    Market_Forecast_Grid.Columns["CurrentPrice"].DefaultCellStyle.Format = "C2";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve current 2026 market data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

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
            string searchTerm = searchBoxPI.Text.ToLower();

            var filterData = allRiceData.Where(x => x.Region.ToLower().Contains(searchTerm) || x.CityMarket.ToLower().Contains(searchTerm)).ToList();
            Market_Forecast_Grid.DataSource = filterData;
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
