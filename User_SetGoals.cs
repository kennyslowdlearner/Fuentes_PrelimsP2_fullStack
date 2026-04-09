using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class User_SetGoals : Form
    {
        private static User_SetGoals instance;
        public User_SetGoals()
        {
            InitializeComponent();

            autosaveTimer.Interval = 5000;
            autosaveTimer.Tick += auto_saveTimer_tick;
        }


        System.Windows.Forms.Timer autosaveTimer = new System.Windows.Forms.Timer();


        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;

        bool isAlreadySaved = false;

        internal static User_SetGoals Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new User_SetGoals();
                }
                return instance;
            }
        }

        private void auto_saveTimer_tick(object sender, EventArgs e)
        {
            if (!isAlreadySaved)
            {
                autosaveTimer.Stop();
                isAlreadySaved = true; // "Lock" the save so it only happens once
                auto_SaveToDatabaseImmediately();
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void backButton(object sender, EventArgs e)
        {
            try
            {
                UserFinancialGoals.Instance.Show();
                this.Hide();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to open page:\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void auto_goal_data_send_database()
        {

            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            string query = "INSERT INTO [User FG Set Goals] ([Date Established], [Goal Description], [Targeted Sales (PhP)], [Targeted Savings (PhP)], [Targeted Income (PhP)], [Status]) VALUES (@P1, @P2, @P3, @P4, @P5, @P6)";


            command = new OleDbCommand(query, connection);
            command.Parameters.Add("@P1", OleDbType.Date).Value = fill_date_usg_fg.Text;
            command.Parameters.Add("@P2", OleDbType.VarWChar).Value = fill_goals_usg_fg.Text;
            command.Parameters.Add("@P3", OleDbType.Currency).Value = Convert.ToDecimal(fill_sales_usg_fg.Text);
            command.Parameters.Add("@P4", OleDbType.Currency).Value = Convert.ToDecimal(fill_savings_usg_fg.Text);
            command.Parameters.Add("@P5", OleDbType.Currency).Value = Convert.ToDecimal(fill_income_usg_fg.Text);
            command.Parameters.Add("@P6", OleDbType.VarWChar).Value = fill_status_usg_fg.Text;

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Item added successfully!");

                fill_date_usg_fg.Value = DateTime.Now;
                fill_goals_usg_fg.Clear();
                fill_sales_usg_fg.Clear();
                fill_savings_usg_fg.Clear();
                fill_income_usg_fg.Clear();
                fill_status_usg_fg.SelectedIndex = -1;

                auto_refreshreload();
                isAlreadySaved = true;
                MessageBox.Show("Saved successfully.");

            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to add you goal in the database. Error: " + ex.Message);
            }
        }

        private void auto_refreshreload()
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb");
            adapter = new OleDbDataAdapter("SELECT * FROM [User FG Set Goals]", connection);


            try
            {
                //connection.Open();

                dataSet = new DataSet();

                adapter.Fill(dataSet, "[User FG Set Goals]");
                MessageBox.Show("Your goal is successfully added!");

                //connection.Close();

                fill_date_usg_fg.Value = DateTime.Now;
                fill_goals_usg_fg.Clear();
                fill_savings_usg_fg.Clear();
                fill_income_usg_fg.Clear();
                fill_sales_usg_fg.Clear();
                fill_status_usg_fg.SelectedIndex = -1;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data. Error: " + ex.Message);
            }
        }

        private void auto_SaveToDatabaseImmediately()
        {
            using (OleDbConnection connected = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb"))
            {
                try
                {
                    connected.Open();
                    string inputquery = "INSERT INTO [User FG Set Goals] ([Date Established], [Goal Description], [Targeted Sales (PhP)], [Targeted Savings (PhP)], [Targeted Income (PhP)], [Status]) VALUES (?, ?, ?, ?, ?, ?)";


                    decimal sales = decimal.TryParse(fill_sales_usg_fg.Text, out decimal s) ? s : 0;
                    decimal savings = decimal.TryParse(fill_savings_usg_fg.Text, out decimal sv) ? sv : 0;
                    decimal income = decimal.TryParse(fill_income_usg_fg.Text, out decimal inc) ? inc : 0;


                    using (OleDbCommand cmdIn = new OleDbCommand(inputquery, connected))
                    {
                        cmdIn.Parameters.Add("?", OleDbType.Date).Value = fill_date_usg_fg.Value; // Use .Value for DateTimePicker
                        cmdIn.Parameters.Add("?", OleDbType.VarWChar).Value = fill_goals_usg_fg.Text;
                        cmdIn.Parameters.Add("?", OleDbType.Currency).Value = sales;
                        cmdIn.Parameters.Add("?", OleDbType.Currency).Value = savings;
                        cmdIn.Parameters.Add("?", OleDbType.Currency).Value = income;
                        cmdIn.Parameters.Add("?", OleDbType.VarWChar).Value = fill_status_usg_fg.Text;
                        cmdIn.ExecuteNonQuery();
                    }

                    isAlreadySaved = true;
                    auto_refreshreload();
                    
                    display_savingstatus_usg_fg.Text = "Goal Saved!";
                }
                catch (Exception ex) 
                { 
                    MessageBox.Show(ex.Message); 
                    isAlreadySaved = false; 
                }
            }
        }

        private void GoalInputChanged(object sender, EventArgs e)
        {
            // Check if all fields are filled
            bool ready = !string.IsNullOrEmpty(fill_goals_usg_fg.Text)
                         && !string.IsNullOrEmpty(fill_sales_usg_fg.Text)
                         && fill_status_usg_fg.SelectedIndex != -1;

            if (ready && !isAlreadySaved)
            {
                autosaveTimer.Stop();
                autosaveTimer.Start();
                display_savingstatus_usg_fg.Text = "Saving Goal in 5s...";
            }
        }

    }
}
