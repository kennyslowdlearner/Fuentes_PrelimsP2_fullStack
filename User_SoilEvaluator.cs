using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class User_SoilEvaluator : Form
    {
        private static User_SoilEvaluator instance;
        public User_SoilEvaluator()
        {
            InitializeComponent();
        }

        //(Global User Session) Component
        internal static User_SoilEvaluator Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new User_SoilEvaluator();

                return instance;
            }
        }

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;

        string currentSelectedRollNumber = " ";
        int nitrogen_levels, phosphorus_levels, potassium_levels, water_depth, water;
        double soil_pH, electrical_conductivity;
        string soil_consistency;
        bool isAlreadySaved = false;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

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

        private void shortcut_ProductInventory(object sender, EventArgs e)
        {
            try
            {
                productInventory.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open Product Inventory page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void shortcut_WeatherForecast(object sender, EventArgs e)
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

        private void shortcut_ActivityLog(object sender, EventArgs e)
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

        private void backButton(object sender, EventArgs e)
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


        private void numeric_data_send_database(object sender, EventArgs e)
        {
            // ensure latest values are read and results are computed
            inputChanged_handler(sender, e);

            // validate required data
            if (!(nitrogen_levels > 0 && phosphorus_levels > 0 && potassium_levels > 0
                  && soil_pH > 0 && electrical_conductivity > 0 && !string.IsNullOrEmpty(soil_consistency) && water > 0))
            {
                //MessageBox.Show("Please complete all required inputs before saving.", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //return; 
            }

            // insert inputs and outputs together (use your existing connection string & table names)
            using (var conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb"))
            {
                conn.Open();

                var inputSql = "INSERT INTO [User RYR Soil Evaluator Inputs] ([Nitrogen Levels], [Phosphorus Levels], [Potassium Levels], [Soil pH Levels], [Electrical Conductivity (EC)], [Soil Consistency], [Water Depth]) VALUES (?, ?, ?, ?, ?, ?, ?)";
                using (var cmdIn = new OleDbCommand(inputSql, conn))
                {
                    cmdIn.Parameters.AddWithValue("?", nitrogen_levels);
                    cmdIn.Parameters.AddWithValue("?", phosphorus_levels);
                    cmdIn.Parameters.AddWithValue("?", potassium_levels);
                    cmdIn.Parameters.AddWithValue("?", soil_pH);
                    cmdIn.Parameters.AddWithValue("?", electrical_conductivity);
                    cmdIn.Parameters.AddWithValue("?", soil_consistency);
                    cmdIn.Parameters.AddWithValue("?", water);
                    cmdIn.ExecuteNonQuery();
                }

                var outputSql = "INSERT INTO [User RYR Soil Evaluator Outputs] ([Nitrogen Levels Result], [Phosphorus Levels Result], [Potassium Levels Result], [Soil pH Levels Result], [Electrical Conductivity (EC) Result], [Soil Consistency Result], [Water Depth Result], [Overall Result]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
                using (var cmdOut = new OleDbCommand(outputSql, conn))
                {
                    cmdOut.Parameters.AddWithValue("?", display_nitrogenresult_se.Text);
                    cmdOut.Parameters.AddWithValue("?", display_phosphorusresult_se.Text);
                    cmdOut.Parameters.AddWithValue("?", display_potassiumresult_se.Text);
                    cmdOut.Parameters.AddWithValue("?", display_phresult_se.Text);
                    cmdOut.Parameters.AddWithValue("?", display_ecresult_se.Text);
                    cmdOut.Parameters.AddWithValue("?", display_soilconsistencyresult_se.Text);
                    cmdOut.Parameters.AddWithValue("?", display_waterdepthresult_se.Text);
                    cmdOut.Parameters.AddWithValue("?", display_overallresult_se.Text);
                    cmdOut.ExecuteNonQuery();
                }

                conn.Close();
            }

            isAlreadySaved = true; // optional flag
            refreshreload();
            MessageBox.Show("Saved successfully.");
        }

        private void refreshreload()
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            adapter = new OleDbDataAdapter("SELECT * FROM [User Soil Evaluator Query]", connection);


            try
            {
                dataSet = new DataSet();

                adapter.Fill(dataSet, "[User Soil Evaluator Query]");


                Soil_Evaluator_Grid.DataSource = dataSet.Tables["[User Soil Evaluator Query]"];
                Soil_Evaluator_Grid.AutoGenerateColumns = true;

                foreach (DataGridViewColumn col in Soil_Evaluator_Grid.Columns) { col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; }
                if (Soil_Evaluator_Grid.Columns.Contains("Roll Number")) Soil_Evaluator_Grid.Columns["Roll Number"].Visible = false;

                //set .Fill if .AllCells is not working for some columns
                Soil_Evaluator_Grid.Columns["Nitrogen Levels"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Soil_Evaluator_Grid.Columns["Nitrogen Levels Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Soil_Evaluator_Grid.Columns["Phosphorus Levels"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Soil_Evaluator_Grid.Columns["Phosphorus Levels Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Soil_Evaluator_Grid.Columns["Potassium Levels"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Soil_Evaluator_Grid.Columns["Potassium Levels Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Soil_Evaluator_Grid.Columns["Soil pH Levels"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Soil_Evaluator_Grid.Columns["Soil pH Levels Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Soil_Evaluator_Grid.Columns["Electrical Conductivity (EC)"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Soil_Evaluator_Grid.Columns["Electrical Conductivity (EC) Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Soil_Evaluator_Grid.Columns["Soil Consistency"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Soil_Evaluator_Grid.Columns["Soil Consistency Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Soil_Evaluator_Grid.Columns["Water Depth"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Soil_Evaluator_Grid.Columns["Water Depth Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                Soil_Evaluator_Grid.Columns["Overall Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                if (Soil_Evaluator_Grid.Columns.Contains("Roll Number")) Soil_Evaluator_Grid.Columns["Roll Number"].Visible = false;

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }

        private void results_and_calculation()
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            adapter = new OleDbDataAdapter("SELECT * FROM [User Soil Evaluator Query]", connection);


            if (nitrogen_levels == 0 || phosphorus_levels == 0 || potassium_levels == 0 ||
                soil_pH == 0 || electrical_conductivity == 0 || string.IsNullOrEmpty(soil_consistency))
            {
                // Hide the result area if incomplete
                display_nitrogenresult_se.Visible = false;
                display_phosphorusresult_se.Visible = false;
                display_potassiumresult_se.Visible = false;
                display_phresult_se.Visible = false;
                display_ecresult_se.Visible = false;
                display_soilconsistencyresult_se.Visible = false;
                display_waterdepthresult_se.Visible = false;

                isAlreadySaved = false;
                return;
            }

            else
            {
                display_nitrogenresult_se.Visible = true;
                display_phosphorusresult_se.Visible = true;
                display_potassiumresult_se.Visible = true;
                display_phresult_se.Visible = true;
                display_ecresult_se.Visible = true;
                display_soilconsistencyresult_se.Visible = true;
                display_waterdepthresult_se.Visible = true;
            }


            //NPK -> units: mg/kg

            if (nitrogen_levels < 20) display_nitrogenresult_se.Text = "Low/Deficient";
            else if (nitrogen_levels >= 20 && nitrogen_levels <= 50) display_nitrogenresult_se.Text = "Optimal/Good";
            else if (nitrogen_levels > 50) display_nitrogenresult_se.Text = "High/Excessive";

            if (phosphorus_levels < 10) display_phosphorusresult_se.Text = "Low/Deficient";
            else if (phosphorus_levels >= 10 && phosphorus_levels <= 25) display_phosphorusresult_se.Text = "Optimal/Good";
            else if (phosphorus_levels > 25) display_phosphorusresult_se.Text = "High/Excessive";

            if (potassium_levels < 20) display_potassiumresult_se.Text = "Low/Deficient";
            else if (potassium_levels >= 20 && potassium_levels <= 50) display_potassiumresult_se.Text = "Optimal/Good";
            else if (potassium_levels > 50) display_potassiumresult_se.Text = "High/Excessive";

            //pH and EC

            if (soil_pH < 5.5) display_phresult_se.Text = "Acidic";
            else if (soil_pH >= 5.5 && soil_pH <= 6.5) display_phresult_se.Text = "Optimal";
            else if (soil_pH > 6.5) display_phresult_se.Text = "Alkaline";

            if (electrical_conductivity < 0.8) display_ecresult_se.Text = "Low";
            else if (electrical_conductivity >= 0.8 && electrical_conductivity <= 2.0) display_ecresult_se.Text = "Optimal";
            else if (electrical_conductivity > 2.0) display_ecresult_se.Text = "Saline/Danger";

            //soil consistency and water depth
            if (soil_consistency == "Sticky/Plastic" || soil_consistency == "Soft") display_soilconsistencyresult_se.Text = "Excellent";
            else if (soil_consistency == "Firm" || soil_consistency == "Friable") display_soilconsistencyresult_se.Text = "Good";
            else if (soil_consistency == "Loose" || soil_consistency == "Extremely Firm") display_soilconsistencyresult_se.Text = "Poor";

            water = fill_waterdepth_se.Value;
            display_watermeasure_se.Text = fill_waterdepth_se.Value + " cm";

            if (water >= 3 && water <= 7) display_waterdepthresult_se.Text = "Optimal";
            else if (water < 3) display_waterdepthresult_se.Text = "Too shallow";
            else display_waterdepthresult_se.Text = "Too deep";

            //overall result
            if (display_phresult_se.Text == "Optimal" && display_ecresult_se.Text == "Optimal") display_overallresult_se.Text = "Excellent for RICE";
            else display_overallresult_se.Text = "Fair / Needs adjustment";

            // enable Save button only when ALL required inputs are provided (no auto-save)
            bool readyToSave = nitrogen_levels > 0
                               && phosphorus_levels > 0
                               && potassium_levels > 0
                               && soil_pH > 0
                               && electrical_conductivity > 0
                               && !string.IsNullOrEmpty(soil_consistency)
                               && water > 0;

            // button5 is the Save button in Designer; ensure it's disabled by default in InitializeComponent or form load
            if (button5 != null) button5.Enabled = readyToSave;
        }

        private void SaveToDatabaseImmediately()
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            string inputquery = "INSERT INTO [User RYR Soil Evaluator Inputs] ([Nitrogen Levels], [Phosphorus Levels], [Potassium Levels], [Soil pH Levels], [Electrical Conductivity (EC)], [Soil Consistency], [Water Depth]) VALUES (@P1, @P2, @P3, @P4, @P5, @P6, @P7)";
            string outputquery = "INSERT INTO [User RYR Soil Evaluator Outputs] ([Nitrogen Levels Result], [Phosphorus Levels Result], [Potassium Levels Result], [Soil pH Levels Result], [Electrical Conductivity (EC) Result], [Soil Consistency Result], [Water Depth Result], [Overall Result]) VALUES (@Q1, @Q2, @Q3, @Q4, @Q5, @Q6, @Q7, @Q8)";

            using (OleDbConnection connected = connection)
            {
                try
                {
                    connected.Open();

                    using (OleDbCommand commandInput = new OleDbCommand(inputquery, connected))
                    {
                        commandInput.Parameters.Add("@P1", OleDbType.Integer).Value = nitrogen_levels;
                        commandInput.Parameters.Add("@P2", OleDbType.Integer).Value = phosphorus_levels;
                        commandInput.Parameters.Add("@P3", OleDbType.Integer).Value = potassium_levels;
                        commandInput.Parameters.Add("@P4", OleDbType.Double).Value = soil_pH;
                        commandInput.Parameters.Add("@P5", OleDbType.Double).Value = electrical_conductivity;
                        commandInput.Parameters.Add("@P6", OleDbType.VarWChar).Value = soil_consistency;
                        commandInput.Parameters.Add("@P7", OleDbType.Integer).Value = water;
                        commandInput.ExecuteNonQuery();
                    }

                    using (OleDbCommand commandOutput = new OleDbCommand(outputquery, connected))
                    {
                        commandOutput.Parameters.Add("@Q1", OleDbType.VarWChar).Value = display_nitrogenresult_se.Text;
                        commandOutput.Parameters.Add("@Q2", OleDbType.VarWChar).Value = display_phosphorusresult_se.Text;
                        commandOutput.Parameters.Add("@Q3", OleDbType.VarWChar).Value = display_potassiumresult_se.Text;
                        commandOutput.Parameters.Add("@Q4", OleDbType.VarWChar).Value = display_phresult_se.Text;
                        commandOutput.Parameters.Add("@Q5", OleDbType.VarWChar).Value = display_ecresult_se.Text;
                        commandOutput.Parameters.Add("@Q6", OleDbType.VarWChar).Value = display_soilconsistencyresult_se.Text;
                        commandOutput.Parameters.Add("@Q7", OleDbType.VarWChar).Value = display_waterdepthresult_se.Text;
                        commandOutput.Parameters.Add("@Q8", OleDbType.VarWChar).Value = display_overallresult_se.Text;
                        commandOutput.ExecuteNonQuery();
                    }

                    refreshreload();
                    MessageBox.Show("Result records SAVED succesfully!");

                }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to save result records. Error: " + ex.Message);
                    }

                }
            }

        private void datagridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = Soil_Evaluator_Grid.Rows[e.RowIndex];

                fill_nitrogenlevels_se.Value = Convert.ToInt32(row.Cells["Nitrogen Levels"].Value);
                fill_phosphoruslevels_se.Value = Convert.ToInt32(row.Cells["Phosphorus Levels"].Value);
                fill_potassiumlevels_se.Value = Convert.ToInt32(row.Cells["Potassium Levels"].Value);
                fill_soilphlevels_se.Value = Convert.ToDecimal(row.Cells["Soil pH Levels"].Value);
                fill_ec_se.Value = Convert.ToDecimal(row.Cells["Electrical Conductivity (EC)"].Value);
                fill_soilconsistency_se.Text = (row.Cells["Soil Consistency"].Value).ToString();
                

                // 2. Update the Result Labels (The Output Table side)
                display_nitrogenresult_se.Text = row.Cells["Nitrogen Levels Result"].Value.ToString();
                display_phosphorusresult_se.Text = row.Cells["Phosphorus Levels Result"].Value.ToString();
                display_potassiumresult_se.Text = row.Cells["Potassium Levels Result"].Value.ToString();
                display_phresult_se.Text = row.Cells["Soil pH Levels Result"].Value.ToString();
                display_ecresult_se.Text = row.Cells["Electrical Conductivity (EC) Result"].Value.ToString();
                display_soilconsistencyresult_se.Text = row.Cells["Soil Consistency Result"].Value.ToString();
                display_waterdepthresult_se.Text = row.Cells["Water Depth Result"].Value.ToString();
                display_overallresult_se.Text = row.Cells["Overall Result"].Value.ToString();

                int waterValue = Convert.ToInt32(row.Cells["Water Depth"].Value);
                fill_waterdepth_se.Value = waterValue;
                display_waterdepthresult_se.Text = waterValue + " cm";

                display_nitrogenresult_se.Text = row.Cells["Nitrogen Levels Result"].Value.ToString();
                display_phosphorusresult_se.Text = row.Cells["Phosphorus Levels Result"].Value.ToString();
                display_potassiumresult_se.Text = row.Cells["Potassium Levels Result"].Value.ToString();
                display_phresult_se.Text = row.Cells["Soil pH Levels Result"].Value.ToString();
                display_ecresult_se.Text = row.Cells["Electrical Conductivity (EC) Result"].Value.ToString();
                display_soilconsistencyresult_se.Text = row.Cells["Soil Consistency Result"].Value.ToString();
                display_waterdepthresult_se.Text = row.Cells["Water Depth Result"].Value.ToString();
                display_overallresult_se.Text = row.Cells["Overall Result"].Value.ToString();

                MakeResultsVisible();
            }
        }

        private void MakeResultsVisible()
        {
            display_nitrogenresult_se.Visible = true;
            display_phosphorusresult_se.Visible = true;
            display_potassiumresult_se.Visible = true;
            display_phresult_se.Visible = true;
            display_ecresult_se.Visible = true;
            display_soilconsistencyresult_se.Visible = true;
            display_waterdepthresult_se.Visible = true;
            display_overallresult_se.Visible = true;
        }

        // Add this new handler to the form class
        private void inputChanged_handler(object? sender, EventArgs e)
        {
            // read current inputs into fields (safe parse)
            nitrogen_levels = Convert.ToInt32(fill_nitrogenlevels_se.Value);
            phosphorus_levels = Convert.ToInt32(fill_phosphoruslevels_se.Value);
            potassium_levels = Convert.ToInt32(fill_potassiumlevels_se.Value);
            soil_pH = Convert.ToDouble(fill_soilphlevels_se.Value);
            electrical_conductivity = Convert.ToDouble(fill_ec_se.Value);
            soil_consistency = fill_soilconsistency_se.Text ?? string.Empty;
            water = Convert.ToInt32(fill_waterdepth_se.Value);

            // recompute UI results but DO NOT save here
            results_and_calculation();
        }
    }
}
