namespace Fuentes_PrelimsP2
{
    partial class Admin_TotalTransactionsAnalytics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_TotalTransactionsAnalytics));
            label1 = new Label();
            display_piechart1_tta = new Panel();
            display_piechart2_tta = new Panel();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("League Spartan", 25.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkGreen;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(961, 78);
            label1.TabIndex = 5;
            label1.Text = "Total Transaction/Sales Report Analytics";
            // 
            // display_piechart1_tta
            // 
            display_piechart1_tta.BackColor = Color.Transparent;
            display_piechart1_tta.Location = new Point(35, 167);
            display_piechart1_tta.Name = "display_piechart1_tta";
            display_piechart1_tta.Size = new Size(607, 398);
            display_piechart1_tta.TabIndex = 6;
            // 
            // display_piechart2_tta
            // 
            display_piechart2_tta.BackColor = Color.Transparent;
            display_piechart2_tta.Location = new Point(673, 167);
            display_piechart2_tta.Name = "display_piechart2_tta";
            display_piechart2_tta.Size = new Size(607, 398);
            display_piechart2_tta.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("League Spartan", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkGreen;
            label2.Location = new Point(35, 104);
            label2.Name = "label2";
            label2.Size = new Size(405, 60);
            label2.TabIndex = 5;
            label2.Text = "Sales by User Product";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("League Spartan", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkGreen;
            label3.Location = new Point(673, 104);
            label3.Name = "label3";
            label3.Size = new Size(384, 60);
            label3.TabIndex = 5;
            label3.Text = "Sales by User Profile";
            // 
            // Admin_TotalTransactionsAnalytics
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1312, 586);
            Controls.Add(display_piechart2_tta);
            Controls.Add(display_piechart1_tta);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Admin_TotalTransactionsAnalytics";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Total Transaction Analytics";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel display_piechart1_tta;
        private Panel display_piechart2_tta;
        private Label label2;
        private Label label3;
    }
}