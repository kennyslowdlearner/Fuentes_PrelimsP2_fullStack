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
        // Correct path as seen in your recent database configuration
        string connString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Pananom Database\Prooject Pananom Data.accdb";
        System.Windows.Forms.Timer autosaveTimer = new System.Windows.Forms.Timer();
        bool isAlreadySaved = false;

        public User_SetGoals()
        {
            InitializeComponent();
            autosaveTimer.Interval = 5000;
            autosaveTimer.Tick += auto_saveTimer_tick;
        }

        internal static User_SetGoals Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new User_SetGoals();
                return instance;
            }
        }

        private void auto_saveTimer_tick(object sender, EventArgs e)
        {
            if (!isAlreadySaved)
            {
                autosaveTimer.Stop();
                auto_SaveToDatabaseImmediately();
            }
        }

        // Updated to include [User ID] and initialize [Current] values to 0
        private void auto_SaveToDatabaseImmediately()
        {
            using (OleDbConnection connected = new OleDbConnection(connString))
            {
                try
                {
                    connected.Open();
                    // Matching your updated table structure from User_StatisticalProgress
                    string inputquery = "INSERT INTO [User FG Set Goals] " +
                        "([Date Established], [Goal Description], [Targeted Sales], [Current Sales], " +
                        "[Targeted Savings], [Current Savings], [Targeted Income], [Current Income], " +
                        "[Status], [User ID]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

                    decimal sales = decimal.TryParse(fill_sales_usg_fg.Text, out decimal s) ? s : 0;
                    decimal savings = decimal.TryParse(fill_savings_usg_fg.Text, out decimal sv) ? sv : 0;
                    decimal income = decimal.TryParse(fill_income_usg_fg.Text, out decimal inc) ? inc : 0;

                    using (OleDbCommand cmdIn = new OleDbCommand(inputquery, connected))
                    {
                        cmdIn.Parameters.Add("?", OleDbType.Date).Value = fill_date_usg_fg.Value;
                        cmdIn.Parameters.Add("?", OleDbType.VarWChar).Value = fill_goals_usg_fg.Text;
                        cmdIn.Parameters.Add("?", OleDbType.Currency).Value = sales;
                        cmdIn.Parameters.Add("?", OleDbType.Currency).Value = 0; // Initial Current Sales
                        cmdIn.Parameters.Add("?", OleDbType.Currency).Value = savings;
                        cmdIn.Parameters.Add("?", OleDbType.Currency).Value = 0; // Initial Current Savings
                        cmdIn.Parameters.Add("?", OleDbType.Currency).Value = income;
                        cmdIn.Parameters.Add("?", OleDbType.Currency).Value = 0; // Initial Current Income
                        cmdIn.Parameters.Add("?", OleDbType.VarWChar).Value = fill_status_usg_fg.Text;
                        cmdIn.Parameters.Add("?", OleDbType.Integer).Value = UserSession.UserInstance.ID; // localized ID

                        cmdIn.ExecuteNonQuery();
                    }

                    isAlreadySaved = true;
                    display_savingstatus_usg_fg.Text = "Goal Saved!";
                    MessageBox.Show("New Financial Goal successfully added to Project Pananom!");
                    ClearInputs();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Save Error: " + ex.Message);
                    isAlreadySaved = false;
                }
            }
        }

        private void ClearInputs()
        {
            fill_date_usg_fg.Value = DateTime.Now;
            fill_goals_usg_fg.Clear();
            fill_sales_usg_fg.Clear();
            fill_savings_usg_fg.Clear();
            fill_income_usg_fg.Clear();
            fill_status_usg_fg.SelectedIndex = -1;
        }

        private void GoalInputChanged(object sender, EventArgs e)
        {
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

        private void backButton(object sender, EventArgs e)
        {
            this.Hide();
            UserFinancialGoals.Instance.Show();
        }
    }
}