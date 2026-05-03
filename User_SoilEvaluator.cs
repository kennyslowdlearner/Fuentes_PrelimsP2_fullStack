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

            autosaveTimer.Interval = 5000;
            autosaveTimer.Tick += autosaveTimer_tick;

            auto_refreshreload();
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

        System.Windows.Forms.Timer autosaveTimer = new System.Windows.Forms.Timer();

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

        private void autosaveTimer_tick(object sender, EventArgs e)
        {
            if (!isAlreadySaved)
            {
                autosaveTimer.Stop();
                isAlreadySaved = true; // "Lock" the save so it only happens once
                auto_SaveToDatabaseImmediately();
            }
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
                RiceYieldEstimationandRegistry.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void auto_numeric_data_send_database(object sender, EventArgs e)
        {
            // ensure latest values are read and results are computed
            try
            {
                auto_inputChanged_handler(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading inputs before save: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // validate required data
            if (!(nitrogen_levels > 0 && phosphorus_levels > 0 && potassium_levels > 0
                  && soil_pH > 0 && electrical_conductivity > 0 && !string.IsNullOrEmpty(soil_consistency) && water > 0))
            {
                //MessageBox.Show("Please complete all required inputs before saving.", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // insert inputs and outputs together (use your existing connection string & table names)
            using (var conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb"))
            {
                conn.Open();

                var inputSql = "INSERT INTO [User RYR Soil Evaluator Inputs] ([Nitrogen Levels], [Phosphorus Levels], [Potassium Levels], [Soil pH Levels], [Electrical Conductivity (EC)], [Soil Consistency], [Water Depth]) VALUES (?, ?, ?, ?, ?, ?, ?)";

                try
                {
                    int insertedId = -1;
                    using (var cmdIn = new OleDbCommand(inputSql, conn))
                    {
                        cmdIn.Parameters.AddWithValue("?", nitrogen_levels);
                        cmdIn.Parameters.AddWithValue("?", phosphorus_levels);
                        cmdIn.Parameters.AddWithValue("?", potassium_levels);
                        cmdIn.Parameters.AddWithValue("?", soil_pH);
                        cmdIn.Parameters.AddWithValue("?", electrical_conductivity);
                        cmdIn.Parameters.AddWithValue("?", soil_consistency ?? string.Empty);
                        cmdIn.Parameters.AddWithValue("?", water);
                        cmdIn.ExecuteNonQuery();
                    }

                    // Retrieve the autonumber / identity value for the just-inserted input record
                    using (var idCmd = new OleDbCommand("SELECT @@IDENTITY", conn))
                    {
                        var idObj = idCmd.ExecuteScalar();
                        if (idObj != null && int.TryParse(idObj.ToString(), out int tmp))
                            insertedId = tmp;
                    }

                    // Ensure we include the foreign key to the input record when inserting outputs
                    var outputSql = "INSERT INTO [User RYR Soil Evaluator Outputs] ([Roll Number], [Nitrogen Levels Result], [Phosphorus Levels Result], [Potassium Levels Result], [Soil pH Levels Result], [Electrical Conductivity (EC) Result], [Soil Consistency Result], [Water Depth Result], [Overall Result]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
                    using (var cmdOut = new OleDbCommand(outputSql, conn))
                    {
                        // first parameter is the FK to inputs table
                        cmdOut.Parameters.AddWithValue("?", insertedId);
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to save data. Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conn.Close();
            }

            isAlreadySaved = true; // optional flag
            auto_refreshreload();
            MessageBox.Show("Saved successfully.");
        }

        // Handler for input changes: update local fields and recompute results without saving
        private void auto_inputChanged_handler(object? sender, EventArgs e)
        {
            try
            {
                nitrogen_levels = Convert.ToInt32(fill_nitrogenlevels_se.Value);
                phosphorus_levels = Convert.ToInt32(fill_phosphoruslevels_se.Value);
                potassium_levels = Convert.ToInt32(fill_potassiumlevels_se.Value);
                soil_pH = Convert.ToDouble(fill_soilphlevels_se.Value);
                electrical_conductivity = Convert.ToDouble(fill_ec_se.Value);
                soil_consistency = fill_soilconsistency_se.Text ?? string.Empty;
                water = Convert.ToInt32(fill_waterdepth_se.Value);
            }
            catch
            {
                // ignore parse errors; results_and_calculation will validate
            }

            auto_results_and_calculation();
        }

        private void auto_refreshreload()
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            adapter = new OleDbDataAdapter("SELECT * FROM [User Soil Evaluator Query]", connection);


            try
            {
                dataSet = new DataSet();

                adapter.Fill(dataSet, "[User Soil Evaluator Query]");


                Soil_Evaluator_Grid.DataSource = dataSet.Tables["[User Soil Evaluator Query]"];
                Soil_Evaluator_Grid.AutoGenerateColumns = true;

                Soil_Evaluator_Grid.DefaultCellStyle.ForeColor = Color.Black;

                foreach (DataGridViewColumn col in Soil_Evaluator_Grid.Columns) { col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; }
                if (Soil_Evaluator_Grid.Columns.Contains("Roll Number")) Soil_Evaluator_Grid.Columns["Roll Number"].Visible = false;

                //set .Fill if .AllCells is not working for some columns
                if (Soil_Evaluator_Grid.Columns.Contains("Date and Time"))
                {
                    Soil_Evaluator_Grid.Columns["Date and Time"].DefaultCellStyle.Format = "MMM dd, yyyy hh:mm tt";
                    Soil_Evaluator_Grid.Columns["Date and Time"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    Soil_Evaluator_Grid.Columns["Date and Time"].DisplayIndex = 0; // Move it to the first column so it's easy to see
                }

                Soil_Evaluator_Grid.Columns["Overall Result"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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
                

                if (Soil_Evaluator_Grid.Columns.Contains("Roll Number")) Soil_Evaluator_Grid.Columns["Roll Number"].Visible = false;

                fill_nitrogenlevels_se.Value = 0;
                fill_phosphoruslevels_se.Value = 0;
                fill_potassiumlevels_se.Value = 0;
                fill_soilphlevels_se.Value = 0;
                fill_ec_se.Value = 0;
                fill_soilconsistency_se.SelectedIndex = -1;
                fill_waterdepth_se.Value = 0;

                isAlreadySaved = false; // reset save flag on reload
                display_watermeasure_se.Text = "0 cm";

                display_nitrogenresult_se.Visible = false;
                display_phosphorusresult_se.Visible = false;
                display_potassiumresult_se.Visible = false;
                display_phresult_se.Visible = false;
                display_ecresult_se.Visible = false;
                display_soilconsistencyresult_se.Visible = false;
                display_waterdepthresult_se.Visible = false;
                display_overallresult_se.Text = "Results will appear here";
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }

        private void auto_results_and_calculation()
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

            if (soil_pH < 6) display_phresult_se.Text = "Acidic";
            else if (soil_pH >= 6 && soil_pH <= 7) display_phresult_se.Text = "Optimal";
            else if (soil_pH > 7) display_phresult_se.Text = "Alkaline";

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
            //if (button5 != null) button5.Enabled = readyToSave;

            if (readyToSave && !isAlreadySaved)
            {
                // If the user changes something, STOP the old timer and START a fresh 5s countdown
                autosaveTimer.Stop();
                autosaveTimer.Start();

                display_savingstatus_se.Text = "Data Complete! Saving in 5s...";
            }
            else if (!readyToSave)
            {
                // If they change a value to 0 or empty, kill the timer entirely
                autosaveTimer.Stop();
                isAlreadySaved = false;
            }
        }

        private void auto_SaveToDatabaseImmediately()
        {
            using (OleDbConnection connected = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb"))
            {
                try
                {
                    connected.Open();
                    int insertedId = -1;

                    // 1. INPUTS: Double check these 7 columns match your 'Inputs' table exactly
                    string inputquery = "INSERT INTO [User RYR Soil Evaluator Inputs] " +
                                        "([Nitrogen Levels], [Phosphorus Levels], [Potassium Levels], [Soil pH Levels], [Electrical Conductivity (EC)], [Soil Consistency], [Water Depth]) " +
                                        "VALUES (?, ?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmdIn = new OleDbCommand(inputquery, connected))
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

                    // 2. GET THE IDENTITY
                    using (OleDbCommand idCmd = new OleDbCommand("SELECT @@IDENTITY", connected))
                    {
                        insertedId = (int)idCmd.ExecuteScalar();
                    }

                    // 3. OUTPUTS: This is where the 10 parameters must be in perfect order
                    // I've added brackets to every column to prevent Access from getting confused
                    string outputquery = "INSERT INTO [User RYR Soil Evaluator Outputs] " +
                                        "([Roll Number], [Nitrogen Levels Result], [Phosphorus Levels Result], [Potassium Levels Result], [Soil pH Levels Result], [Electrical Conductivity (EC) Result], [Soil Consistency Result], [Water Depth Result], [Overall Result], [Date and Time]) " +
                                        "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                    using (OleDbCommand cmdOut = new OleDbCommand(outputquery, connected))
                    {
                        // Order is: Roll, N_Res, P_Res, K_Res, pH_Res, EC_Res, Cons_Res, Water_Res, Overall, Date
                        cmdOut.Parameters.AddWithValue("?", insertedId);
                        cmdOut.Parameters.AddWithValue("?", display_nitrogenresult_se.Text);
                        cmdOut.Parameters.AddWithValue("?", display_phosphorusresult_se.Text);
                        cmdOut.Parameters.AddWithValue("?", display_potassiumresult_se.Text);
                        cmdOut.Parameters.AddWithValue("?", display_phresult_se.Text);
                        cmdOut.Parameters.AddWithValue("?", display_ecresult_se.Text);
                        cmdOut.Parameters.AddWithValue("?", display_soilconsistencyresult_se.Text);
                        cmdOut.Parameters.AddWithValue("?", display_waterdepthresult_se.Text);
                        cmdOut.Parameters.AddWithValue("?", display_overallresult_se.Text);

                        // Force specify this as a Date to avoid mismatch
                        cmdOut.Parameters.Add("?", OleDbType.Date).Value = DateTime.Now;

                        cmdOut.ExecuteNonQuery();
                    }

                    auto_refreshreload();
                    MessageBox.Show("Evaluation Saved to Pananom History!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Final troubleshooting error: " + ex.Message);
                    isAlreadySaved = false;
                }
            }
        }

        private void auto_datagridCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
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

                auto_MakeResultsVisible();
            }
        }

        private void auto_MakeResultsVisible()
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

        private void auto_fill_waterdepth_se_Scroll(object sender, EventArgs e)
        {
            display_watermeasure_se.Text = fill_waterdepth_se.Value + " cm";
            auto_inputChanged_handler(sender, e);
        }

        // Add this new handler to the form class
        //private void inputChanged_handler(object? sender, EventArgs e)
        //{
        //    // read current inputs into fields (safe parse)
        //    nitrogen_levels = Convert.ToInt32(fill_nitrogenlevels_se.Value);
        //    phosphorus_levels = Convert.ToInt32(fill_phosphoruslevels_se.Value);
        //    potassium_levels = Convert.ToInt32(fill_potassiumlevels_se.Value);
        //    soil_pH = Convert.ToDouble(fill_soilphlevels_se.Value);
        //    electrical_conductivity = Convert.ToDouble(fill_ec_se.Value);
        //    soil_consistency = fill_soilconsistency_se.Text ?? string.Empty;
        //    water = Convert.ToInt32(fill_waterdepth_se.Value);

        //    // recompute UI results but DO NOT save here
        //    results_and_calculation();
        //}
    }
}
