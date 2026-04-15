namespace Fuentes_PrelimsP2
{
    partial class User_SetGoals
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_SetGoals));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            fill_date_usg_fg = new DateTimePicker();
            fill_sales_usg_fg = new TextBox();
            fill_goals_usg_fg = new RichTextBox();
            fill_savings_usg_fg = new TextBox();
            fill_income_usg_fg = new TextBox();
            fill_status_usg_fg = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            button6 = new Button();
            button5 = new Button();
            panel1 = new Panel();
            display_savingstatus_usg_fg = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Yellow;
            label1.Location = new Point(123, 28);
            label1.Name = "label1";
            label1.Size = new Size(421, 27);
            label1.TabIndex = 0;
            label1.Text = "Kindly fill out the necessary data below";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold);
            label2.ForeColor = Color.PaleGreen;
            label2.Location = new Point(35, 87);
            label2.Name = "label2";
            label2.Size = new Size(214, 24);
            label2.TabIndex = 0;
            label2.Text = "Enter date for the goal";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold);
            label3.ForeColor = Color.PaleGreen;
            label3.Location = new Point(34, 174);
            label3.Name = "label3";
            label3.Size = new Size(212, 24);
            label3.TabIndex = 0;
            label3.Text = "Enter goal description";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold);
            label4.ForeColor = Color.PaleGreen;
            label4.Location = new Point(34, 288);
            label4.Name = "label4";
            label4.Size = new Size(195, 24);
            label4.TabIndex = 0;
            label4.Text = "Enter targeted sales";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold);
            label5.ForeColor = Color.PaleGreen;
            label5.Location = new Point(34, 325);
            label5.Name = "label5";
            label5.Size = new Size(218, 24);
            label5.TabIndex = 0;
            label5.Text = "Enter targeted savings";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold);
            label6.ForeColor = Color.PaleGreen;
            label6.Location = new Point(34, 359);
            label6.Name = "label6";
            label6.Size = new Size(232, 24);
            label6.TabIndex = 0;
            label6.Text = "Entetr targetend income";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold);
            label7.ForeColor = Color.PaleGreen;
            label7.Location = new Point(34, 396);
            label7.Name = "label7";
            label7.Size = new Size(229, 24);
            label7.TabIndex = 0;
            label7.Text = "Enter status for the goal";
            // 
            // fill_date_usg_fg
            // 
            fill_date_usg_fg.Location = new Point(335, 80);
            fill_date_usg_fg.Name = "fill_date_usg_fg";
            fill_date_usg_fg.Size = new Size(291, 31);
            fill_date_usg_fg.TabIndex = 1;
            // 
            // fill_sales_usg_fg
            // 
            fill_sales_usg_fg.BackColor = Color.PaleGreen;
            fill_sales_usg_fg.Location = new Point(335, 281);
            fill_sales_usg_fg.Name = "fill_sales_usg_fg";
            fill_sales_usg_fg.Size = new Size(291, 31);
            fill_sales_usg_fg.TabIndex = 2;
            fill_sales_usg_fg.TextChanged += GoalInputChanged;
            // 
            // fill_goals_usg_fg
            // 
            fill_goals_usg_fg.BackColor = Color.PaleGreen;
            fill_goals_usg_fg.BorderStyle = BorderStyle.FixedSingle;
            fill_goals_usg_fg.Location = new Point(335, 117);
            fill_goals_usg_fg.Name = "fill_goals_usg_fg";
            fill_goals_usg_fg.Size = new Size(291, 158);
            fill_goals_usg_fg.TabIndex = 3;
            fill_goals_usg_fg.Text = "";
            fill_goals_usg_fg.TextChanged += GoalInputChanged;
            // 
            // fill_savings_usg_fg
            // 
            fill_savings_usg_fg.BackColor = Color.PaleGreen;
            fill_savings_usg_fg.Location = new Point(335, 318);
            fill_savings_usg_fg.Name = "fill_savings_usg_fg";
            fill_savings_usg_fg.Size = new Size(291, 31);
            fill_savings_usg_fg.TabIndex = 2;
            fill_savings_usg_fg.TextChanged += GoalInputChanged;
            // 
            // fill_income_usg_fg
            // 
            fill_income_usg_fg.BackColor = Color.PaleGreen;
            fill_income_usg_fg.Location = new Point(335, 355);
            fill_income_usg_fg.Name = "fill_income_usg_fg";
            fill_income_usg_fg.Size = new Size(291, 31);
            fill_income_usg_fg.TabIndex = 2;
            fill_income_usg_fg.TextChanged += GoalInputChanged;
            // 
            // fill_status_usg_fg
            // 
            fill_status_usg_fg.BackColor = Color.PaleGreen;
            fill_status_usg_fg.FormattingEnabled = true;
            fill_status_usg_fg.Items.AddRange(new object[] { "Ongoing goal", "Goal achieved", "Cancelled goal" });
            fill_status_usg_fg.Location = new Point(335, 392);
            fill_status_usg_fg.Name = "fill_status_usg_fg";
            fill_status_usg_fg.Size = new Size(291, 33);
            fill_status_usg_fg.TabIndex = 4;
            fill_status_usg_fg.SelectedIndexChanged += GoalInputChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold);
            label9.ForeColor = Color.PaleGreen;
            label9.Location = new Point(301, 86);
            label9.Name = "label9";
            label9.Size = new Size(16, 24);
            label9.TabIndex = 0;
            label9.Text = ":";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold);
            label8.ForeColor = Color.PaleGreen;
            label8.Location = new Point(301, 174);
            label8.Name = "label8";
            label8.Size = new Size(16, 24);
            label8.TabIndex = 0;
            label8.Text = ":";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold);
            label10.ForeColor = Color.PaleGreen;
            label10.Location = new Point(301, 285);
            label10.Name = "label10";
            label10.Size = new Size(16, 24);
            label10.TabIndex = 0;
            label10.Text = ":";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold);
            label11.ForeColor = Color.PaleGreen;
            label11.Location = new Point(301, 325);
            label11.Name = "label11";
            label11.Size = new Size(16, 24);
            label11.TabIndex = 0;
            label11.Text = ":";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold);
            label12.ForeColor = Color.PaleGreen;
            label12.Location = new Point(301, 359);
            label12.Name = "label12";
            label12.Size = new Size(16, 24);
            label12.TabIndex = 0;
            label12.Text = ":";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold);
            label13.ForeColor = Color.PaleGreen;
            label13.Location = new Point(301, 396);
            label13.Name = "label13";
            label13.Size = new Size(16, 24);
            label13.TabIndex = 0;
            label13.Text = ":";
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(254, 726);
            button6.Name = "button6";
            button6.Size = new Size(120, 41);
            button6.TabIndex = 75;
            button6.UseVisualStyleBackColor = false;
            button6.Click += backButton;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(379, 724);
            button5.Name = "button5";
            button5.Size = new Size(120, 41);
            button5.TabIndex = 76;
            button5.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(fill_status_usg_fg);
            panel1.Controls.Add(fill_goals_usg_fg);
            panel1.Controls.Add(fill_income_usg_fg);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(fill_savings_usg_fg);
            panel1.Controls.Add(fill_sales_usg_fg);
            panel1.Controls.Add(fill_date_usg_fg);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(57, 189);
            panel1.Name = "panel1";
            panel1.Size = new Size(655, 454);
            panel1.TabIndex = 77;
            // 
            // display_savingstatus_usg_fg
            // 
            display_savingstatus_usg_fg.BackColor = Color.Transparent;
            display_savingstatus_usg_fg.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            display_savingstatus_usg_fg.ForeColor = Color.Yellow;
            display_savingstatus_usg_fg.Location = new Point(169, 681);
            display_savingstatus_usg_fg.Name = "display_savingstatus_usg_fg";
            display_savingstatus_usg_fg.Size = new Size(421, 27);
            display_savingstatus_usg_fg.TabIndex = 0;
            display_savingstatus_usg_fg.Text = "-----";
            display_savingstatus_usg_fg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // User_SetGoals
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(753, 787);
            Controls.Add(panel1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(display_savingstatus_usg_fg);
            Name = "User_SetGoals";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private DateTimePicker fill_date_usg_fg;
        private TextBox fill_sales_usg_fg;
        private RichTextBox fill_goals_usg_fg;
        private TextBox fill_savings_usg_fg;
        private TextBox fill_income_usg_fg;
        private ComboBox fill_status_usg_fg;
        private Label label9;
        private Label label8;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Button button6;
        private Button button5;
        private Panel panel1;
        private Label display_savingstatus_usg_fg;
    }
}