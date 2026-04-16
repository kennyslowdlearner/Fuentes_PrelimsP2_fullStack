namespace Fuentes_PrelimsP2
{
    partial class UserFinancialGoals
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserFinancialGoals));
            button1 = new Button();
            button2 = new Button();
            button6 = new Button();
            label4 = new Label();
            display_name_fg = new Label();
            display_datetime_fg = new Label();
            label1 = new Label();
            systemTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(284, 351);
            button1.Name = "button1";
            button1.Size = new Size(202, 259);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = false;
            button1.Click += GoToSetGoals;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(556, 351);
            button2.Name = "button2";
            button2.Size = new Size(202, 259);
            button2.TabIndex = 0;
            button2.UseVisualStyleBackColor = false;
            button2.Click += GoToStatisticalProgress;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(447, 657);
            button6.Name = "button6";
            button6.Size = new Size(120, 41);
            button6.TabIndex = 124;
            button6.UseVisualStyleBackColor = false;
            button6.Click += bbackButton;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Gold;
            label4.Location = new Point(423, 294);
            label4.Name = "label4";
            label4.Size = new Size(237, 27);
            label4.TabIndex = 125;
            label4.Text = "Select your next step:";
            // 
            // display_name_fg
            // 
            display_name_fg.AutoSize = true;
            display_name_fg.BackColor = Color.Transparent;
            display_name_fg.Font = new Font("Glacial Indifference", 15.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            display_name_fg.ForeColor = Color.LawnGreen;
            display_name_fg.Location = new Point(202, 160);
            display_name_fg.Name = "display_name_fg";
            display_name_fg.Size = new Size(123, 38);
            display_name_fg.TabIndex = 2;
            display_name_fg.Text = "[USER]!";
            display_name_fg.Click += label1_Click;
            // 
            // display_datetime_fg
            // 
            display_datetime_fg.AutoSize = true;
            display_datetime_fg.BackColor = Color.Transparent;
            display_datetime_fg.Font = new Font("Glacial Indifference", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            display_datetime_fg.ForeColor = Color.LawnGreen;
            display_datetime_fg.Location = new Point(38, 197);
            display_datetime_fg.Name = "display_datetime_fg";
            display_datetime_fg.Size = new Size(179, 29);
            display_datetime_fg.TabIndex = 2;
            display_datetime_fg.Text = "[Time and Date]";
            display_datetime_fg.Click += label1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Glacial Indifference", 15.9999981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LawnGreen;
            label1.Location = new Point(38, 160);
            label1.Name = "label1";
            label1.Size = new Size(172, 38);
            label1.TabIndex = 2;
            label1.Text = "Hello there,";
            label1.Click += label1_Click;
            // 
            // systemTimer
            // 
            systemTimer.Enabled = true;
            systemTimer.Interval = 1000;
            systemTimer.Tick += systemTimer_Tick;
            // 
            // UserFinancialGoals
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1063, 710);
            Controls.Add(label4);
            Controls.Add(button6);
            Controls.Add(display_name_fg);
            Controls.Add(display_datetime_fg);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "UserFinancialGoals";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Financial Goals";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button6;
        private Label label4;
        private Label display_name_fg;
        private Label display_datetime_fg;
        private Label label1;
        private System.Windows.Forms.Timer systemTimer;
    }
}