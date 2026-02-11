namespace Fuentes_PrelimsP2
{
    partial class UserLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLogin));
            panel1 = new Panel();
            USERpass = new TextBox();
            USERusn = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label5 = new Label();
            label1 = new Label();
            loginUSER = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(USERpass);
            panel1.Controls.Add(USERusn);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(loginUSER);
            panel1.Font = new Font("Glacial Indifference", 10F);
            panel1.Location = new Point(88, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(855, 589);
            panel1.TabIndex = 0;
            // 
            // USERpass
            // 
            USERpass.Location = new Point(354, 351);
            USERpass.Name = "USERpass";
            USERpass.Size = new Size(364, 31);
            USERpass.TabIndex = 4;
            // 
            // USERusn
            // 
            USERusn.Location = new Point(354, 300);
            USERusn.Name = "USERusn";
            USERusn.Size = new Size(364, 31);
            USERusn.TabIndex = 4;
            USERusn.TextChanged += USERusn_TextChanged;
            // 
            // label3
            // 
            label3.Font = new Font("Glacial Indifference", 10.999999F);
            label3.Location = new Point(29, 343);
            label3.Name = "label3";
            label3.Size = new Size(310, 44);
            label3.TabIndex = 2;
            label3.Text = "Password :";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(206, 228);
            label4.Name = "label4";
            label4.Size = new Size(516, 44);
            label4.TabIndex = 2;
            label4.Text = "Make sure to enter a valid credentials!";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Glacial Indifference", 10.999999F);
            label2.Location = new Point(38, 292);
            label2.Name = "label2";
            label2.Size = new Size(310, 44);
            label2.TabIndex = 2;
            label2.Text = "Username : ";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("League Spartan", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(304, 35);
            label5.Name = "label5";
            label5.Size = new Size(340, 107);
            label5.TabIndex = 3;
            label5.Text = "Pananom";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Glacial Indifference", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(354, 180);
            label1.Name = "label1";
            label1.Size = new Size(215, 48);
            label1.TabIndex = 3;
            label1.Text = "User Login";
            // 
            // loginUSER
            // 
            loginUSER.BackColor = Color.LightGreen;
            loginUSER.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 0);
            loginUSER.FlatStyle = FlatStyle.Flat;
            loginUSER.Font = new Font("Glacial Indifference", 10F);
            loginUSER.ForeColor = Color.DarkOliveGreen;
            loginUSER.Location = new Point(337, 504);
            loginUSER.Name = "loginUSER";
            loginUSER.Size = new Size(187, 39);
            loginUSER.TabIndex = 0;
            loginUSER.Text = "Login";
            loginUSER.UseVisualStyleBackColor = false;
            // 
            // UserLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1040, 650);
            Controls.Add(panel1);
            Name = "UserLogin";
            Text = "Pananom : User Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button loginUSER;
        private TextBox USERpass;
        private TextBox USERusn;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label5;
    }
}