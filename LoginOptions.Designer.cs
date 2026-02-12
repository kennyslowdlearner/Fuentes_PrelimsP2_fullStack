namespace Fuentes_PrelimsP2
{
    partial class LoginOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginOptions));
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            button2 = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Font = new Font("Glacial Indifference", 10F);
            panel1.Location = new Point(304, 160);
            panel1.Name = "panel1";
            panel1.Size = new Size(392, 258);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(38, 89);
            label2.Name = "label2";
            label2.Size = new Size(310, 72);
            label2.TabIndex = 1;
            label2.Text = "Choose an appropriate Login Account.";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Glacial Indifference", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(38, 31);
            label1.Name = "label1";
            label1.Size = new Size(334, 58);
            label1.TabIndex = 1;
            label1.Text = "Login Options";
            // 
            // button2
            // 
            button2.BackColor = Color.LightGreen;
            button2.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 0);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Glacial Indifference", 10F);
            button2.ForeColor = Color.DarkOliveGreen;
            button2.Location = new Point(216, 184);
            button2.Name = "button2";
            button2.Size = new Size(129, 43);
            button2.TabIndex = 0;
            button2.Text = "User Login";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGreen;
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 0);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Glacial Indifference", 10F);
            button1.ForeColor = Color.DarkOliveGreen;
            button1.Location = new Point(48, 184);
            button1.Name = "button1";
            button1.Size = new Size(129, 43);
            button1.TabIndex = 0;
            button1.Text = "Admin Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // LoginOptions
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1040, 650);
            Controls.Add(panel1);
            Name = "LoginOptions";
            Text = "Pananom : Login Options";
            FormClosed += LoginOptions_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button2;
        private Button button1;
        private Label label2;
        private Label label1;
    }
}