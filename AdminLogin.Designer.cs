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
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            label5 = new Label();
            loginADMIN = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(ADMINpass);
            panel1.Controls.Add(ADMINusn);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(loginADMIN);
            panel1.Font = new Font("Glacial Indifference", 10F);
            panel1.Location = new Point(93, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(873, 589);
            panel1.TabIndex = 1;
            // 
            // ADMINpass
            // 
            ADMINpass.BackColor = Color.LightGreen;
            ADMINpass.BorderStyle = BorderStyle.FixedSingle;
            ADMINpass.Location = new Point(493, 377);
            ADMINpass.Name = "ADMINpass";
            ADMINpass.Size = new Size(280, 31);
            ADMINpass.TabIndex = 4;
            // 
            // ADMINusn
            // 
            ADMINusn.BackColor = Color.LightGreen;
            ADMINusn.BorderStyle = BorderStyle.FixedSingle;
            ADMINusn.ForeColor = Color.Black;
            ADMINusn.Location = new Point(493, 333);
            ADMINusn.Name = "ADMINusn";
            ADMINusn.Size = new Size(280, 31);
            ADMINusn.TabIndex = 4;
            // 
            // label4
            // 
            label4.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(282, 251);
            label4.Name = "label4";
            label4.Size = new Size(516, 44);
            label4.TabIndex = 2;
            label4.Text = "Make sure to enter a valid credentials!";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("League Spartan SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.ForestGreen;
            label1.Location = new Point(342, 364);
            label1.Name = "label1";
            label1.Size = new Size(145, 44);
            label1.TabIndex = 2;
            label1.Text = "Password : ";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Font = new Font("League Spartan SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.ForestGreen;
            label2.Location = new Point(342, 322);
            label2.Name = "label2";
            label2.Size = new Size(145, 44);
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
            label5.Size = new Size(0, 107);
            label5.TabIndex = 3;
            // 
            // loginADMIN
            // 
            loginADMIN.BackColor = Color.SeaGreen;
            loginADMIN.FlatAppearance.BorderColor = Color.Green;
            loginADMIN.FlatStyle = FlatStyle.Flat;
            loginADMIN.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginADMIN.ForeColor = Color.Gold;
            loginADMIN.Location = new Point(621, 486);
            loginADMIN.Name = "loginADMIN";
            loginADMIN.Size = new Size(152, 39);
            loginADMIN.TabIndex = 0;
            loginADMIN.Text = "Login";
            loginADMIN.UseVisualStyleBackColor = false;
            loginADMIN.Click += loginADMIN_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.SeaGreen;
            button1.FlatAppearance.BorderColor = Color.Green;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Gold;
            button1.Location = new Point(463, 486);
            button1.Name = "button1";
            button1.Size = new Size(152, 39);
            button1.TabIndex = 0;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += BackHomepage_Click;
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
        private Label label4;
        private Label label2;
        private Label label5;
        private Button loginADMIN;
        private Label label1;
        private Button button1;
    }
}