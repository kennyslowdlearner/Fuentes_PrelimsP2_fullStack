using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Fuentes_PrelimsP2
{
    public partial class UserTransportSchedule : Form
    {
        private static UserTransportSchedule instance;
        public UserTransportSchedule()
        {
            InitializeComponent();
            peakGrid_autoreload();
        }

        //(Global User Session) Component
        internal static UserTransportSchedule Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new UserTransportSchedule();

                return instance;
            }
        }

        private void backButton(object sender, EventArgs e)
        {
            UserAccount.Instance.Show();
            this.Hide();
        }

        internal void peakGrid_autoreload()
        {
            try
            {
                // 1. Setup Connection
                string connectionString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Pananom Database\\Prooject Pananom Data.accdb";

                // 2. Query - We only show active trips (Not 'Recognized')
                string query = "SELECT [Transport Name], [Driver], [Place From], [Place To], [Estimated Time], [Status], [Date Made] " +
                               "FROM [Admin - User Transport Schedule] " +
                               "WHERE [Status] <> 'Recognized' OR [Status] IS NULL";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // 3. Add a "Time Left" column for the User's convenience
                    if (!dt.Columns.Contains("Time Left"))
                        dt.Columns.Add("Time Left", typeof(string));

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["Estimated Time"] != DBNull.Value)
                        {
                            DateTime eta = Convert.ToDateTime(row["Estimated Time"]);
                            TimeSpan diff = eta - DateTime.Now;

                            if (diff.TotalMinutes > 0)
                                row["Time Left"] = $"{(int)diff.TotalMinutes} mins";
                            else
                                row["Time Left"] = "Arrived";
                        }
                    }

                    // 4. Bind to the Grid (Assuming your grid is named User_Transport_Grid)
                    Transport_Schedule_Grid.DataSource = null;
                    Transport_Schedule_Grid.DataSource = dt;

                    // 5. UI Adjustments for the User
                    ConfigureUserGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading schedule: " + ex.Message);
            }
        }

        private void ConfigureUserGrid()
        {
            // Make it read-only so users can't change the schedule
            Transport_Schedule_Grid.ReadOnly = true;
            Transport_Schedule_Grid.AllowUserToAddRows = false;
            Transport_Schedule_Grid.RowHeadersVisible = false;
            Transport_Schedule_Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Set Manual Widths
            Transport_Schedule_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            Transport_Schedule_Grid.ScrollBars = ScrollBars.Both;

            if (Transport_Schedule_Grid.Columns.Count > 0)
            {
                Transport_Schedule_Grid.Columns["Transport Name"].Width = 270;
                Transport_Schedule_Grid.Columns["Driver"].Width = 400;
                Transport_Schedule_Grid.Columns["Place From"].Width = 450;
                Transport_Schedule_Grid.Columns["Place To"].Width = 450;
                Transport_Schedule_Grid.Columns["Estimated Time"].Width = 250;
                Transport_Schedule_Grid.Columns["Estimated Time"].DefaultCellStyle.Format = "t"; // 2:30 PM
                Transport_Schedule_Grid.Columns["Time Left"].Width = 250;
                Transport_Schedule_Grid.Columns["Status"].Width = 500;

                // Hide Date Made from the user to keep it clean
                if (Transport_Schedule_Grid.Columns.Contains("Date Made"))
                    Transport_Schedule_Grid.Columns["Date Made"].Visible = false;
            }

            Transport_Schedule_Grid.RowHeadersVisible = false;
            Transport_Schedule_Grid.ClearSelection();
            Transport_Schedule_Grid.CurrentCell = null;
        }
    }
}
