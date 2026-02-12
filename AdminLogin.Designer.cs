namespace Fuentes_PrelimsP2
{
    partial class AdminLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminLogin));
            panel1 = new Panel();
            ADMINpass = new TextBox();
            ADMINusn = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label5 = new Label();
            label1 = new Label();
            loginADMIN = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(ADMINpass);
            panel1.Controls.Add(ADMINusn);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(loginADMIN);
            panel1.Font = new Font("Glacial Indifference", 10F);
            panel1.Location = new Point(93, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(855, 589);
            panel1.TabIndex = 1;
            // 
            // ADMINpass
            // 
            ADMINpass.Location = new Point(354, 351);
            ADMINpass.Name = "ADMINpass";
            ADMINpass.Size = new Size(364, 31);
            ADMINpass.TabIndex = 4;
            // 
            // ADMINusn
            // 
            ADMINusn.Location = new Point(354, 300);
            ADMINusn.Name = "ADMINusn";
            ADMINusn.Size = new Size(364, 31);
            ADMINusn.TabIndex = 4;
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
            label1.Location = new Point(337, 180);
            label1.Name = "label1";
            label1.Size = new Size(251, 48);
            label1.TabIndex = 3;
            label1.Text = "Admin Login";
            // 
            // loginADMIN
            // 
            loginADMIN.BackColor = Color.LightGreen;
            loginADMIN.FlatAppearance.BorderColor = Color.Green;
            loginADMIN.FlatStyle = FlatStyle.Flat;
            loginADMIN.Font = new Font("Glacial Indifference", 10F);
            loginADMIN.ForeColor = Color.DarkOliveGreen;
            loginADMIN.Location = new Point(337, 504);
            loginADMIN.Name = "loginADMIN";
            loginADMIN.Size = new Size(187, 39);
            loginADMIN.TabIndex = 0;
            loginADMIN.Text = "Login";
            loginADMIN.UseVisualStyleBackColor = false;
            loginADMIN.Click += loginADMIN_Click;
            // 
            // AdminLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1040, 650);
            Controls.Add(panel1);
            Name = "AdminLogin";
            Text = "Pananom : Admin Login";
            FormClosed += AdminLogin_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox ADMINpass;
        private TextBox ADMINusn;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label5;
        private Label label1;
        private Button loginADMIN;
    }
}