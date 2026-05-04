namespace Fuentes_PrelimsP2
{
    partial class Admin_SalesByProductAnalytics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_SalesByProductAnalytics));
            label1 = new Label();
            display_piechart_sbpa = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("League Spartan", 25.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkGreen;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(634, 78);
            label1.TabIndex = 4;
            label1.Text = "Sales by Product Analytics";
            // 
            // display_piechart_sbpa
            // 
            display_piechart_sbpa.BackColor = Color.Transparent;
            display_piechart_sbpa.Location = new Point(35, 113);
            display_piechart_sbpa.Name = "display_piechart_sbpa";
            display_piechart_sbpa.Size = new Size(728, 398);
            display_piechart_sbpa.TabIndex = 5;
            // 
            // Admin_SalesByProductAnalytics
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 523);
            Controls.Add(display_piechart_sbpa);
            Controls.Add(label1);
            Name = "Admin_SalesByProductAnalytics";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sales by Product Analytics";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel display_piechart_sbpa;
    }
}