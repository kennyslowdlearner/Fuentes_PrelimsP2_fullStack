namespace Fuentes_PrelimsP2
{
    partial class User_WeatherForecast
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_WeatherForecast));
            label6 = new Label();
            Weather_Information = new Panel();
            Weather_Chart_Information = new Panel();
            button8 = new Button();
            label9 = new Label();
            button6 = new Button();
            button1 = new Button();
            button2 = new Button();
            button4 = new Button();
            fill_search_wf = new TextBox();
            function_timer_wf = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.GreenYellow;
            label6.Location = new Point(42, 172);
            label6.Name = "label6";
            label6.Size = new Size(120, 27);
            label6.TabIndex = 33;
            label6.Text = "Place/City:";
            // 
            // Weather_Information
            // 
            Weather_Information.Location = new Point(43, 223);
            Weather_Information.Name = "Weather_Information";
            Weather_Information.Size = new Size(1413, 178);
            Weather_Information.TabIndex = 35;
            // 
            // Weather_Chart_Information
            // 
            Weather_Chart_Information.Location = new Point(43, 407);
            Weather_Chart_Information.Name = "Weather_Chart_Information";
            Weather_Chart_Information.Size = new Size(834, 276);
            Weather_Chart_Information.TabIndex = 35;
            // 
            // button8
            // 
            button8.BackColor = Color.Transparent;
            button8.BackgroundImage = (Image)resources.GetObject("button8.BackgroundImage");
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.CornflowerBlue;
            button8.Location = new Point(892, 462);
            button8.Name = "button8";
            button8.Size = new Size(254, 99);
            button8.TabIndex = 88;
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.GreenYellow;
            label9.Location = new Point(892, 432);
            label9.Name = "label9";
            label9.Size = new Size(164, 27);
            label9.TabIndex = 84;
            label9.Text = "Other Options:";
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(757, 718);
            button6.Name = "button6";
            button6.Size = new Size(120, 41);
            button6.TabIndex = 89;
            button6.UseVisualStyleBackColor = false;
            button6.Click += backButton;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.CornflowerBlue;
            button1.Location = new Point(892, 567);
            button1.Name = "button1";
            button1.Size = new Size(254, 99);
            button1.TabIndex = 88;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.CornflowerBlue;
            button2.Location = new Point(1152, 567);
            button2.Name = "button2";
            button2.Size = new Size(254, 99);
            button2.TabIndex = 88;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.CornflowerBlue;
            button4.Location = new Point(1152, 462);
            button4.Name = "button4";
            button4.Size = new Size(254, 99);
            button4.TabIndex = 88;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // fill_search_wf
            // 
            fill_search_wf.BackColor = Color.Gainsboro;
            fill_search_wf.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Italic, GraphicsUnit.Point, 0);
            fill_search_wf.Location = new Point(168, 173);
            fill_search_wf.Name = "fill_search_wf";
            fill_search_wf.Size = new Size(252, 29);
            fill_search_wf.TabIndex = 113;
            fill_search_wf.TextChanged += fill_search_wf_TextChanged;
            // 
            // function_timer_wf
            // 
            function_timer_wf.Interval = 500;
            function_timer_wf.Tick += searchTimer_Tick;
            // 
            // User_WeatherForecast
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1500, 785);
            Controls.Add(fill_search_wf);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button8);
            Controls.Add(label9);
            Controls.Add(Weather_Chart_Information);
            Controls.Add(Weather_Information);
            Controls.Add(label6);
            Name = "User_WeatherForecast";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Weather Forecast";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label6;
        private Panel Weather_Information;
        private Panel Weather_Chart_Information;
        private Button button8;
        private Label label9;
        private Button button6;
        private Button button1;
        private Button button2;
        private Button button4;
        private TextBox fill_search_wf;
        private System.Windows.Forms.Timer function_timer_wf;
    }
}