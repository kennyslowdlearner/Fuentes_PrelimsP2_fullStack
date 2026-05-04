namespace Fuentes_PrelimsP2
{
    partial class User_MarketForecast
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_MarketForecast));
            label8 = new Label();
            label6 = new Label();
            label9 = new Label();
            Market_Forecast_Grid = new DataGridView();
            button6 = new Button();
            button1 = new Button();
            button2 = new Button();
            searchBoxPI = new TextBox();
            label1 = new Label();
            function_timer_mf = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)Market_Forecast_Grid).BeginInit();
            SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.GreenYellow;
            label8.Location = new Point(961, 368);
            label8.Name = "label8";
            label8.Size = new Size(164, 27);
            label8.TabIndex = 21;
            label8.Text = "Other Options:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.LawnGreen;
            label6.Location = new Point(961, 289);
            label6.Name = "label6";
            label6.Size = new Size(120, 27);
            label6.TabIndex = 22;
            label6.Text = "Place/City:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Glacial Indifference", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.GreenYellow;
            label9.Location = new Point(76, 182);
            label9.Name = "label9";
            label9.Size = new Size(182, 34);
            label9.TabIndex = 15;
            label9.Text = "Market Price";
            // 
            // Market_Forecast_Grid
            // 
            Market_Forecast_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Market_Forecast_Grid.Location = new Point(76, 219);
            Market_Forecast_Grid.Name = "Market_Forecast_Grid";
            Market_Forecast_Grid.RowHeadersWidth = 62;
            Market_Forecast_Grid.Size = new Size(834, 516);
            Market_Forecast_Grid.TabIndex = 7;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.Transparent;
            button6.Location = new Point(1132, 682);
            button6.Name = "button6";
            button6.Size = new Size(120, 41);
            button6.TabIndex = 32;
            button6.UseVisualStyleBackColor = false;
            button6.Click += backbutton;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(961, 428);
            button1.Name = "button1";
            button1.Size = new Size(418, 64);
            button1.TabIndex = 28;
            button1.UseVisualStyleBackColor = false;
            button1.Click += shortcut_CostOfProduction;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(961, 498);
            button2.Name = "button2";
            button2.Size = new Size(418, 64);
            button2.TabIndex = 28;
            button2.UseVisualStyleBackColor = false;
            button2.Click += shortcut_Transactions;
            // 
            // searchBoxPI
            // 
            searchBoxPI.BackColor = Color.Gainsboro;
            searchBoxPI.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Italic, GraphicsUnit.Point, 0);
            searchBoxPI.Location = new Point(1095, 290);
            searchBoxPI.Name = "searchBoxPI";
            searchBoxPI.Size = new Size(252, 29);
            searchBoxPI.TabIndex = 113;
            searchBoxPI.TextChanged += fillSearchBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LawnGreen;
            label1.Location = new Point(1074, 291);
            label1.Name = "label1";
            label1.Size = new Size(15, 24);
            label1.TabIndex = 111;
            label1.Text = ":";
            // 
            // User_MarketForecast
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1500, 785);
            Controls.Add(searchBoxPI);
            Controls.Add(label1);
            Controls.Add(button6);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label9);
            Controls.Add(Market_Forecast_Grid);
            Name = "User_MarketForecast";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Market Forecast";
            Load += User_MarketForecast_Load;
            ((System.ComponentModel.ISupportInitialize)Market_Forecast_Grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label8;
        private Label label6;
        private Label label9;
        private DataGridView Market_Forecast_Grid;
        private Button button6;
        private Button button1;
        private Button button2;
        private TextBox searchBoxPI;
        private Label label1;
        private System.Windows.Forms.Timer function_timer_mf;
    }
}