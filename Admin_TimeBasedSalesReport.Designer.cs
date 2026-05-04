namespace Fuentes_PrelimsP2
{
    partial class Admin_TimeBasedSalesReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_TimeBasedSalesReport));
            display_permonth_analytics = new Panel();
            Per_Month_Grid = new DataGridView();
            display_perweek_analytics = new Panel();
            Per_Week_Grid = new DataGridView();
            display_peryear_analytics = new Panel();
            Per_Year_Grid = new DataGridView();
            button4 = new Button();
            button8 = new Button();
            button6 = new Button();
            display_tps_tbsr = new Label();
            label3 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            display_lps_tbsr = new Label();
            display_tt_tbsr = new Label();
            display_pr_tbsr = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label7 = new Label();
            fill_search_tbsr = new TextBox();
            label8 = new Label();
            label1 = new Label();
            display_es_gg = new Label();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)Per_Month_Grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Per_Week_Grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Per_Year_Grid).BeginInit();
            SuspendLayout();
            // 
            // display_permonth_analytics
            // 
            display_permonth_analytics.Location = new Point(48, 242);
            display_permonth_analytics.Name = "display_permonth_analytics";
            display_permonth_analytics.Size = new Size(671, 211);
            display_permonth_analytics.TabIndex = 0;
            display_permonth_analytics.Visible = false;
            // 
            // Per_Month_Grid
            // 
            Per_Month_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Per_Month_Grid.Location = new Point(48, 242);
            Per_Month_Grid.Name = "Per_Month_Grid";
            Per_Month_Grid.RowHeadersWidth = 62;
            Per_Month_Grid.Size = new Size(671, 211);
            Per_Month_Grid.TabIndex = 0;
            // 
            // display_perweek_analytics
            // 
            display_perweek_analytics.Location = new Point(48, 483);
            display_perweek_analytics.Name = "display_perweek_analytics";
            display_perweek_analytics.Size = new Size(671, 179);
            display_perweek_analytics.TabIndex = 0;
            display_perweek_analytics.Visible = false;
            // 
            // Per_Week_Grid
            // 
            Per_Week_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Per_Week_Grid.Location = new Point(49, 483);
            Per_Week_Grid.Name = "Per_Week_Grid";
            Per_Week_Grid.RowHeadersWidth = 62;
            Per_Week_Grid.Size = new Size(670, 180);
            Per_Week_Grid.TabIndex = 0;
            // 
            // display_peryear_analytics
            // 
            display_peryear_analytics.Location = new Point(742, 245);
            display_peryear_analytics.Name = "display_peryear_analytics";
            display_peryear_analytics.Size = new Size(711, 208);
            display_peryear_analytics.TabIndex = 0;
            display_peryear_analytics.Visible = false;
            // 
            // Per_Year_Grid
            // 
            Per_Year_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Per_Year_Grid.Location = new Point(742, 242);
            Per_Year_Grid.Name = "Per_Year_Grid";
            Per_Year_Grid.RowHeadersWidth = 62;
            Per_Year_Grid.Size = new Size(711, 211);
            Per_Year_Grid.TabIndex = 0;
            // 
            // button4
            // 
            button4.BackColor = Color.Yellow;
            button4.FlatAppearance.BorderColor = Color.Gold;
            button4.FlatAppearance.BorderSize = 2;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.DarkGreen;
            button4.Location = new Point(49, 669);
            button4.Name = "button4";
            button4.Size = new Size(143, 38);
            button4.TabIndex = 120;
            button4.Text = "Refresh";
            button4.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            button8.BackColor = Color.Yellow;
            button8.FlatAppearance.BorderColor = Color.Gold;
            button8.FlatAppearance.BorderSize = 2;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.DarkGreen;
            button8.Location = new Point(198, 668);
            button8.Name = "button8";
            button8.Size = new Size(143, 38);
            button8.TabIndex = 119;
            button8.Text = "Switch View";
            button8.UseVisualStyleBackColor = false;
            button8.Click += press_switchview;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(674, 732);
            button6.Name = "button6";
            button6.Size = new Size(120, 41);
            button6.TabIndex = 122;
            button6.UseVisualStyleBackColor = false;
            button6.Click += backButton;
            // 
            // display_tps_tbsr
            // 
            display_tps_tbsr.AutoSize = true;
            display_tps_tbsr.BackColor = Color.Transparent;
            display_tps_tbsr.Font = new Font("Glacial Indifference", 11F, FontStyle.Italic);
            display_tps_tbsr.ForeColor = Color.Gold;
            display_tps_tbsr.Location = new Point(1060, 501);
            display_tps_tbsr.Name = "display_tps_tbsr";
            display_tps_tbsr.Size = new Size(126, 27);
            display_tps_tbsr.TabIndex = 125;
            display_tps_tbsr.Text = "(Label Only)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.PaleGreen;
            label3.Location = new Point(1035, 501);
            label3.Name = "label3";
            label3.Size = new Size(19, 27);
            label3.TabIndex = 123;
            label3.Text = ":";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold);
            label6.ForeColor = Color.PaleGreen;
            label6.Location = new Point(742, 593);
            label6.Name = "label6";
            label6.Size = new Size(210, 27);
            label6.TabIndex = 126;
            label6.Text = "Economic Rating(%)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold);
            label5.ForeColor = Color.PaleGreen;
            label5.Location = new Point(742, 561);
            label5.Name = "label5";
            label5.Size = new Size(223, 27);
            label5.TabIndex = 127;
            label5.Text = "Overall Transactions";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold);
            label4.ForeColor = Color.PaleGreen;
            label4.Location = new Point(742, 531);
            label4.Name = "label4";
            label4.Size = new Size(171, 27);
            label4.TabIndex = 128;
            label4.Text = "Least Sold Rice";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold);
            label2.ForeColor = Color.PaleGreen;
            label2.Location = new Point(742, 499);
            label2.Name = "label2";
            label2.Size = new Size(151, 27);
            label2.TabIndex = 129;
            label2.Text = "Top Sold Rice";
            // 
            // display_lps_tbsr
            // 
            display_lps_tbsr.AutoSize = true;
            display_lps_tbsr.BackColor = Color.Transparent;
            display_lps_tbsr.Font = new Font("Glacial Indifference", 11F, FontStyle.Italic);
            display_lps_tbsr.ForeColor = Color.Gold;
            display_lps_tbsr.Location = new Point(1060, 531);
            display_lps_tbsr.Name = "display_lps_tbsr";
            display_lps_tbsr.Size = new Size(126, 27);
            display_lps_tbsr.TabIndex = 125;
            display_lps_tbsr.Text = "(Label Only)";
            // 
            // display_tt_tbsr
            // 
            display_tt_tbsr.AutoSize = true;
            display_tt_tbsr.BackColor = Color.Transparent;
            display_tt_tbsr.Font = new Font("Glacial Indifference", 11F, FontStyle.Italic);
            display_tt_tbsr.ForeColor = Color.Gold;
            display_tt_tbsr.Location = new Point(1060, 561);
            display_tt_tbsr.Name = "display_tt_tbsr";
            display_tt_tbsr.Size = new Size(126, 27);
            display_tt_tbsr.TabIndex = 125;
            display_tt_tbsr.Text = "(Label Only)";
            // 
            // display_pr_tbsr
            // 
            display_pr_tbsr.AutoSize = true;
            display_pr_tbsr.BackColor = Color.Transparent;
            display_pr_tbsr.Font = new Font("Glacial Indifference", 11F, FontStyle.Italic);
            display_pr_tbsr.ForeColor = Color.Gold;
            display_pr_tbsr.Location = new Point(1060, 593);
            display_pr_tbsr.Name = "display_pr_tbsr";
            display_pr_tbsr.Size = new Size(126, 27);
            display_pr_tbsr.TabIndex = 125;
            display_pr_tbsr.Text = "(Label Only)";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Glacial Indifference", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.DarkGreen;
            label12.Location = new Point(48, 215);
            label12.Name = "label12";
            label12.Size = new Size(125, 29);
            label12.TabIndex = 130;
            label12.Text = "Per Month";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Glacial Indifference", 12F, FontStyle.Bold);
            label13.ForeColor = Color.DarkGreen;
            label13.Location = new Point(761, 215);
            label13.Name = "label13";
            label13.Size = new Size(105, 29);
            label13.TabIndex = 130;
            label13.Text = "Per Year";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Glacial Indifference", 12F, FontStyle.Bold);
            label14.ForeColor = Color.DarkGreen;
            label14.Location = new Point(49, 456);
            label14.Name = "label14";
            label14.Size = new Size(118, 29);
            label14.TabIndex = 130;
            label14.Text = "Per Week";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.PaleGreen;
            label15.Location = new Point(1035, 531);
            label15.Name = "label15";
            label15.Size = new Size(19, 27);
            label15.TabIndex = 123;
            label15.Text = ":";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.PaleGreen;
            label16.Location = new Point(1035, 563);
            label16.Name = "label16";
            label16.Size = new Size(19, 27);
            label16.TabIndex = 123;
            label16.Text = ":";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.Transparent;
            label17.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.PaleGreen;
            label17.Location = new Point(1035, 593);
            label17.Name = "label17";
            label17.Size = new Size(19, 27);
            label17.TabIndex = 123;
            label17.Text = ":";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold);
            label7.ForeColor = Color.DarkOliveGreen;
            label7.Location = new Point(922, 209);
            label7.Name = "label7";
            label7.Size = new Size(254, 24);
            label7.TabIndex = 133;
            label7.Text = "Customer Name/Rice Type";
            // 
            // fill_search_tbsr
            // 
            fill_search_tbsr.BackColor = Color.Gainsboro;
            fill_search_tbsr.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Italic, GraphicsUnit.Point, 0);
            fill_search_tbsr.Location = new Point(1203, 204);
            fill_search_tbsr.Name = "fill_search_tbsr";
            fill_search_tbsr.Size = new Size(252, 29);
            fill_search_tbsr.TabIndex = 132;
            fill_search_tbsr.TextChanged += press_search;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold);
            label8.ForeColor = Color.DarkOliveGreen;
            label8.Location = new Point(1182, 205);
            label8.Name = "label8";
            label8.Size = new Size(16, 24);
            label8.TabIndex = 131;
            label8.Text = ":";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.PaleGreen;
            label1.Location = new Point(1035, 635);
            label1.Name = "label1";
            label1.Size = new Size(19, 27);
            label1.TabIndex = 123;
            label1.Text = ":";
            // 
            // display_es_gg
            // 
            display_es_gg.AutoSize = true;
            display_es_gg.BackColor = Color.Transparent;
            display_es_gg.Font = new Font("Glacial Indifference", 11F, FontStyle.Italic);
            display_es_gg.ForeColor = Color.Gold;
            display_es_gg.Location = new Point(1060, 635);
            display_es_gg.Name = "display_es_gg";
            display_es_gg.Size = new Size(126, 27);
            display_es_gg.TabIndex = 125;
            display_es_gg.Text = "(Label Only)";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold);
            label10.ForeColor = Color.PaleGreen;
            label10.Location = new Point(742, 635);
            label10.Name = "label10";
            label10.Size = new Size(178, 27);
            label10.TabIndex = 126;
            label10.Text = "Est. Sack(50 Kg)";
            // 
            // Admin_TimeBasedSalesReport
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1500, 785);
            Controls.Add(label7);
            Controls.Add(fill_search_tbsr);
            Controls.Add(label8);
            Controls.Add(Per_Week_Grid);
            Controls.Add(Per_Year_Grid);
            Controls.Add(Per_Month_Grid);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label10);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(display_es_gg);
            Controls.Add(label2);
            Controls.Add(display_pr_tbsr);
            Controls.Add(display_tt_tbsr);
            Controls.Add(display_lps_tbsr);
            Controls.Add(label1);
            Controls.Add(display_tps_tbsr);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label3);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(display_peryear_analytics);
            Controls.Add(button8);
            Controls.Add(display_perweek_analytics);
            Controls.Add(display_permonth_analytics);
            Name = "Admin_TimeBasedSalesReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)Per_Month_Grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)Per_Week_Grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)Per_Year_Grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel display_permonth_analytics;
        private Panel display_perweek_analytics;
        private Panel display_peryear_analytics;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem sssssToolStripMenuItem;
        private ToolStripMenuItem reloadToolStripMenuItem;
        private ToolStripMenuItem learnMoreToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem viewAccountToolStripMenuItem1;
        private ToolStripMenuItem accountSettingsToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem4;
        private Button button4;
        private Button button8;
        private Button button6;
        private Label display_tps_tbsr;
        private Label label3;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label display_lps_tbsr;
        private Label display_tt_tbsr;
        private Label display_pr_tbsr;
        private Label label12;
        private Label label13;
        private Label label14;
        private DataGridView Per_Month_Grid;
        private Label label15;
        private Label label16;
        private Label label17;
        private DataGridView Per_Week_Grid;
        private DataGridView Per_Year_Grid;
        private Label label7;
        private TextBox fill_search_tbsr;
        private Label label8;
        private Label label1;
        private Label display_es_gg;
        private Label label10;
    }
}