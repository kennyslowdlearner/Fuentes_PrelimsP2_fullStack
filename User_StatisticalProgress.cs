using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace Fuentes_PrelimsP2
{
    public partial class User_StatisticalProgress : Form
    {
        internal static User_StatisticalProgress instance;
        LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        public User_StatisticalProgress()
        {
            InitializeComponent();
            displayinfo();
            InitializeGraph();
        }

        private void InitializeGraph()
        {
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart
            {
                Dock = DockStyle.Fill,
                // Enables zooming with the mouse wheel and panning with right-click/drag
                ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X
            };

            // Add the chart to your panel
            display_graph_sp.Controls.Add(cartesianChart1);
        }

        //(Global User Session) Component
        internal static User_StatisticalProgress Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new User_StatisticalProgress();

                return instance;
            }
        }

        OleDbConnection? connection;
        OleDbDataAdapter? adapter;
        OleDbCommand? command;
        DataSet? dataSet;
        int indexRow;

        string connString = @"Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\Pananom Database\Prooject Pananom Data.accdb";
        private void displayinfo()
        {
            display_accountowner_sp.Text = UserSession.UserInstance.FirstName + " " + UserSession.UserInstance.MiddleName + " " + UserSession.UserInstance.LastName;
            display_accountnumber_sp.Text = Convert.ToString(UserSession.UserInstance.ID);
            display_accountstatus_sp.Text = "Active";
        }
        private void bbackButton(object sender, EventArgs e)
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

        private void User_StatisticalProgress_Load(object sender, EventArgs e)
        {
            LoadGoalData();
        }

        private void LoadGoalData()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connString))
                {
                    // Filtering by User ID to ensure privacy of financial goals
                    string query = "SELECT [Date Established], [Goal Description], [Targeted Sales], [Current Sales], " +
                                   "[Targeted Savings], [Current Savings], [Targeted Income], [Current Income], [Status], [User ID] " +
                                   "FROM [User FG Set Goals] WHERE [User ID] = @uid ORDER BY [Date Established] DESC";

                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    cmd.Parameters.AddWithValue("@uid", UserSession.UserInstance.ID);

                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Inside LoadGoalData, after filling the DataTable:
                    if (dt.Rows.Count > 0)
                    {
                        // Create a temp table with just the top row to initialize the graph
                        DataTable initialRow = dt.Clone();
                        initialRow.ImportRow(dt.Rows[0]);
                        UpdateGraph(initialRow);
                    }

                    display_currentdata_sp.DataSource = dt;
                    FormatGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sync Error: " + ex.Message);
            }
        }

        private void FormatGridView()
        {
            if (display_currentdata_sp.Columns.Count > 0)
            {
                // 1. Change from 'Fill' to 'None' or 'DisplayedCells' to allow scrolling
                // This prevents the columns from being squashed.
                display_currentdata_sp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                // 2. Enable both Horizontal and Vertical ScrollBars
                display_currentdata_sp.ScrollBars = ScrollBars.Both;

                // 3. Set specific widths so text like "Date Established" is readable
                display_currentdata_sp.Columns["Date Established"].Width = 120;
                display_currentdata_sp.Columns["Goal Description"].Width = 200;
                display_currentdata_sp.Columns["Targeted Sales"].Width = 130;
                display_currentdata_sp.Columns["Targeted Savings"].Width = 130;
                display_currentdata_sp.Columns["Targeted Income"].Width = 130;
                display_currentdata_sp.Columns["Current Sales"].Width = 130;
                display_currentdata_sp.Columns["Current Savings"].Width = 130;
                display_currentdata_sp.Columns["Current Income"].Width = 130;
                display_currentdata_sp.Columns["Status"].Width = 100;

                // 4. Formatting for Peso values
                display_currentdata_sp.Columns["Targeted Sales"].DefaultCellStyle.Format = "₱#,##0.00";
                display_currentdata_sp.Columns["Targeted Savings"].DefaultCellStyle.Format = "₱#,##0.00";
                display_currentdata_sp.Columns["Targeted Income"].DefaultCellStyle.Format = "₱#,##0.00";
                display_currentdata_sp.Columns["Current Sales"].DefaultCellStyle.Format = "₱#,##0.00";
                display_currentdata_sp.Columns["Current Savings"].DefaultCellStyle.Format = "₱#,##0.00";
                display_currentdata_sp.Columns["Current Income"].DefaultCellStyle.Format = "₱#,##0.00";

                // Hide User ID to save space
                if (display_currentdata_sp.Columns.Contains("User ID"))
                    display_currentdata_sp.Columns["User ID"].Visible = false;

                // 5. Optional: Header alignment for a cleaner look
                display_currentdata_sp.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void UpdateGraph(DataTable dt)
        {
            if (cartesianChart1 == null) InitializeGraph();

            if (dt.Rows.Count == 0) return;

            // Get the selected goal (the first row in the passed tempDt)
            DataRow row = dt.Rows[0];

            // Data extraction
            double tSales = Convert.ToDouble(row["Targeted Sales"]);
            double cSales = Convert.ToDouble(row["Current Sales"]);
            double tSavings = Convert.ToDouble(row["Targeted Savings"]);
            double cSavings = Convert.ToDouble(row["Current Savings"]);
            double tIncome = Convert.ToDouble(row["Targeted Income"]);
            double cIncome = Convert.ToDouble(row["Current Income"]);

            // Series collection with side-by-side pairing
            cartesianChart1.Series = new ISeries[]
            {
        new ColumnSeries<double>
        {
            Name = "Targeted Goal",
            Values = new double[] { tSales, tSavings, tIncome },
            Stroke = null,
            Fill = new SolidColorPaint(SKColors.DodgerBlue), // Blue for Targets
            Padding = 5, // Adds space between the pairs
            MaxBarWidth = 40
        },
        new ColumnSeries<double>
        {
            Name = "Current Progress",
            Values = new double[] { cSales, cSavings, cIncome },
            Stroke = null,
            Fill = new SolidColorPaint(SKColors.SeaGreen), // Green for Current
            Padding = 5,
            MaxBarWidth = 40
        }
            };

            cartesianChart1.XAxes = new[]
            {
        new Axis
        {
            Labels = new string[] { "Sales", "Savings", "Income" },
            Name = "Financial Categories",
            NamePaint = new SolidColorPaint(SKColors.DimGray)
        }
    };

            cartesianChart1.YAxes = new[]
            {
        new Axis
        {
            Labeler = value => "₱" + value.ToString("N0"),
            Name = "Amount (PhP)",
            NamePaint = new SolidColorPaint(SKColors.DimGray)
        }
    };
        }
        private void press_add(object sender, EventArgs e)
        {
            //try
            //{
            //    using (OleDbConnection conn = new OleDbConnection(connString))
            //    {
            //        string query = "INSERT INTO [User FG Set Goals] ([Date Established], [Goal Description], " +
            //                       "[Targeted Sales], [Current Sales], [Targeted Savings], [Current Savings], [Targeted Income], [Current Income], [Status], [User ID]) " +
            //                       "VALUES (@A1, @A2, @A3, @A4, @A5, @A6, @A7, @A8, @A9, @A10)";



            //        OleDbCommand cmd = new OleDbCommand(query, conn);
            //        cmd.Parameters.AddWithValue("@A1", DateTime.Now.ToString("MM/dd/yyyy"));
            //        cmd.Parameters.AddWithValue("@A4", Convert.ToDouble(fill_sales_sp.Text));
            //        cmd.Parameters.AddWithValue("@A6", Convert.ToDouble(fill_savings_sp.Text));
            //        cmd.Parameters.AddWithValue("@A8", Convert.ToDouble(fill_income_sp.Text));
            //        cmd.Parameters.AddWithValue("@A9", "Ongoing");
            //        cmd.Parameters.AddWithValue("@a10", UserSession.UserInstance.ID);

            //        conn.Open();
            //        cmd.ExecuteNonQuery();
            //        MessageBox.Show("Financial Goal Logged!");
            //        LoadGoalData();
            //    }
            //}
            //catch (Exception ex) { MessageBox.Show("Insert Error: " + ex.Message); }

            User_SetGoals.Instance.Show();
            this.Hide();
        }

        private void press_update(object sender, EventArgs e)
        {
            if (display_currentdata_sp.CurrentRow != null)
            {
                try
                {
                    DataRow row = ((DataRowView)display_currentdata_sp.CurrentRow.DataBoundItem).Row;

                    // 1. Calculate New Totals (Current + Input)
                    double newSales = Convert.ToDouble(row["Current Sales"]) + Convert.ToDouble(fill_sales_sp.Text);
                    double newSavings = Convert.ToDouble(row["Current Savings"]) + Convert.ToDouble(fill_savings_sp.Text);
                    double newIncome = Convert.ToDouble(row["Current Income"]) + Convert.ToDouble(fill_income_sp.Text);

                    // 2. Determine Status (Must exceed or equal ALL targets)
                    string newStatus = "Ongoing";
                    if (newSales >= Convert.ToDouble(row["Targeted Sales"]) &&
                        newSavings >= Convert.ToDouble(row["Targeted Savings"]) &&
                        newIncome >= Convert.ToDouble(row["Targeted Income"]))
                    {
                        newStatus = "Achieved";
                    }

                    using (OleDbConnection conn = new OleDbConnection(connString))
                    {
                        string query = "UPDATE [User FG Set Goals] SET [Current Sales] = @s, [Current Savings] = @sv, " +
                                       "[Current Income] = @i, [Status] = @stat WHERE [User ID] = @uid AND [Goal Description] = @desc";

                        OleDbCommand cmd = new OleDbCommand(query, conn);
                        cmd.Parameters.AddWithValue("@s", newSales);
                        cmd.Parameters.AddWithValue("@sv", newSavings);
                        cmd.Parameters.AddWithValue("@i", newIncome);
                        cmd.Parameters.AddWithValue("@stat", newStatus);
                        cmd.Parameters.AddWithValue("@uid", UserSession.UserInstance.ID);
                        cmd.Parameters.AddWithValue("@desc", row["Goal Description"].ToString());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show($"Progress Updated! Status: {newStatus}");
                        LoadGoalData(); // Refresh grid and colors
                    }
                }
                catch (Exception ex) { MessageBox.Show("Update Calculation Error: " + ex.Message); }
            }
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            LoadGoalData();
        }
        private void press_delete(object sender, EventArgs e)
        {
            if (display_currentdata_sp.CurrentRow != null)
            {
                string goalDesc = display_currentdata_sp.CurrentRow.Cells["Goal Description"].Value.ToString();
                DialogResult result = MessageBox.Show($"Delete goal: '{goalDesc}'?", "Project Pananom", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (OleDbConnection conn = new OleDbConnection(connString))
                        {
                            string query = "DELETE FROM [User FG Set Goals] WHERE [User ID] = @uid AND [Goal Description] = @desc";
                            OleDbCommand cmd = new OleDbCommand(query, conn);
                            cmd.Parameters.AddWithValue("@uid", UserSession.UserInstance.ID);
                            cmd.Parameters.AddWithValue("@desc", goalDesc);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            LoadGoalData();
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Delete Error: " + ex.Message); }
                }
            }
        }

        private void LoadGoalDataEvent(object sender, EventArgs e)
        {
            LoadGoalData();
        }

        private void press_select(object sender, EventArgs e)
        {
            if (display_currentdata_sp.CurrentRow != null && display_currentdata_sp.CurrentRow.DataBoundItem != null)
            {
                // 1. Get the DataRow from the selected DataGridView row
                DataRow selectedRow = ((DataRowView)display_currentdata_sp.CurrentRow.DataBoundItem).Row;

                // 2. Populate your textboxes for the "deposit" system
                fill_sales_sp.Text = "0";
                fill_savings_sp.Text = "0";
                fill_income_sp.Text = "0";
                display_status_sp.Text = selectedRow["Status"].ToString();

                // 3. Create a temporary DataTable for the graph
                DataTable tempDt = selectedRow.Table.Clone(); // Clones the structure (columns)
                tempDt.ImportRow(selectedRow); // Copies only the selected row into the new table

                // 4. Update the graph with this single-row table
                UpdateGraph(tempDt);
            }
        }

        private void ApplyRowHighlighting()
        {
            foreach (DataGridViewRow row in display_currentdata_sp.Rows)
            {
                // Check if the 'Status' cell matches 'Achieved'
                if (row.Cells["Status"].Value != null &&
                    row.Cells["Status"].Value.ToString().Equals("Achieved", StringComparison.OrdinalIgnoreCase))
                {
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    // Reset for 'Ongoing' or other statuses
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void row_highlight(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ApplyRowHighlighting();
        }
    }
}
