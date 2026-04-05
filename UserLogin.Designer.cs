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
            label1 = new Label();
            label2 = new Label();
            USERpass = new TextBox();
            USERusn = new TextBox();
            label4 = new Label();
            button1 = new Button();
            loginUSER = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(USERpass);
            panel1.Controls.Add(USERusn);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(loginUSER);
            panel1.Font = new Font("Glacial Indifference", 10F);
            panel1.Location = new Point(88, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(855, 589);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Font = new Font("League Spartan SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.ForestGreen;
            label1.Location = new Point(355, 355);
            label1.Name = "label1";
            label1.Size = new Size(145, 44);
            label1.TabIndex = 5;
            label1.Text = "Password : ";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Font = new Font("League Spartan SemiBold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.ForestGreen;
            label2.Location = new Point(355, 313);
            label2.Name = "label2";
            label2.Size = new Size(145, 44);
            label2.TabIndex = 6;
            label2.Text = "Username : ";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // USERpass
            // 
            USERpass.BackColor = Color.LightGreen;
            USERpass.BorderStyle = BorderStyle.FixedSingle;
            USERpass.Location = new Point(506, 365);
            USERpass.Name = "USERpass";
            USERpass.Size = new Size(239, 31);
            USERpass.TabIndex = 4;
            USERpass.TextChanged += USERpass_TextChanged;
            // 
            // USERusn
            // 
            USERusn.BackColor = Color.LightGreen;
            USERusn.BorderStyle = BorderStyle.FixedSingle;
            USERusn.Location = new Point(506, 326);
            USERusn.Name = "USERusn";
            USERusn.Size = new Size(239, 31);
            USERusn.TabIndex = 4;
            USERusn.TextChanged += USERusn_TextChanged;
            // 
            // label4
            // 
            label4.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(274, 245);
            label4.Name = "label4";
            label4.Size = new Size(516, 44);
            label4.TabIndex = 2;
            label4.Text = "Make sure to enter a valid credentials!";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.SeaGreen;
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 0);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Gold;
            button1.Location = new Point(435, 469);
            button1.Name = "button1";
            button1.Size = new Size(152, 39);
            button1.TabIndex = 0;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += backHomepage_Click;
            // 
            // loginUSER
            // 
            loginUSER.BackColor = Color.SeaGreen;
            loginUSER.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 0);
            loginUSER.FlatStyle = FlatStyle.Flat;
            loginUSER.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            loginUSER.ForeColor = Color.Gold;
            loginUSER.Location = new Point(593, 469);
            loginUSER.Name = "loginUSER";
            loginUSER.Size = new Size(152, 39);
            loginUSER.TabIndex = 0;
            loginUSER.Text = "Login";
            loginUSER.UseVisualStyleBackColor = false;
            loginUSER.Click += loginUSER_Click;
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
            FormClosing += Close_Form_After_Run;
            FormClosed += UserLogin_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button loginUSER;
        private TextBox USERpass;
        private TextBox USERusn;
        private Label label4;
        private Label label1;
        private Label label2;
        private Button button1;
    }
}