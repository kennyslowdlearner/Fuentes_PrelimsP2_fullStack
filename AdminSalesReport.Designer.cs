namespace Fuentes_PrelimsP2
{
    partial class AdminSalesReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminSalesReport));
            button1 = new Button();
            button7 = new Button();
            panel1 = new Panel();
            button6 = new Button();
            button3 = new Button();
            button5 = new Button();
            button4 = new Button();
            button2 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(89, 72);
            button1.Name = "button1";
            button1.Size = new Size(268, 111);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            button1.Click += GoToAdminSalesReport;
            // 
            // button7
            // 
            button7.BackColor = Color.Transparent;
            button7.BackgroundImage = (Image)resources.GetObject("button7.BackgroundImage");
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.Location = new Point(482, 683);
            button7.Name = "button7";
            button7.Size = new Size(120, 41);
            button7.TabIndex = 96;
            button7.UseVisualStyleBackColor = false;
            button7.Click += backButton;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(button6);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(178, 222);
            panel1.Name = "panel1";
            panel1.Size = new Size(736, 455);
            panel1.TabIndex = 97;
            // 
            // button6
            // 
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(363, 306);
            button6.Name = "button6";
            button6.Size = new Size(268, 111);
            button6.TabIndex = 0;
            button6.UseVisualStyleBackColor = true;
            button6.Click += GoToInventoryManagement;
            // 
            // button3
            // 
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(89, 306);
            button3.Name = "button3";
            button3.Size = new Size(268, 111);
            button3.TabIndex = 0;
            button3.UseVisualStyleBackColor = true;
            button3.Click += GoToTotalTransactions;
            // 
            // button5
            // 
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(363, 189);
            button5.Name = "button5";
            button5.Size = new Size(268, 111);
            button5.TabIndex = 0;
            button5.UseVisualStyleBackColor = true;
            button5.Click += GoToTimeBasedSalesReport;
            // 
            // button4
            // 
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(363, 72);
            button4.Name = "button4";
            button4.Size = new Size(268, 111);
            button4.TabIndex = 0;
            button4.UseVisualStyleBackColor = true;
            button4.Click += GoToSalesByProduct;
            // 
            // button2
            // 
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(89, 189);
            button2.Name = "button2";
            button2.Size = new Size(268, 111);
            button2.TabIndex = 0;
            button2.UseVisualStyleBackColor = true;
            button2.Click += GoToSaleByUserProfile;
            // 
            // AdminSalesReport
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1063, 753);
            Controls.Add(panel1);
            Controls.Add(button7);
            Name = "AdminSalesReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button7;
        private Panel panel1;
        private Button button6;
        private Button button3;
        private Button button5;
        private Button button4;
        private Button button2;
    }
}