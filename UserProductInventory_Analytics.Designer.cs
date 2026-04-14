namespace Fuentes_PrelimsP2
{
    partial class UserProductInventory_Analytics
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
            display_summary_panel = new Panel();
            display_bargraph_panel = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            display_piechart_panel = new Panel();
            backButton = new Button();
            display_bargraph_panel.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // display_summary_panel
            // 
            display_summary_panel.Location = new Point(12, 12);
            display_summary_panel.Name = "display_summary_panel";
            display_summary_panel.Size = new Size(1045, 191);
            display_summary_panel.TabIndex = 0;
            // 
            // display_bargraph_panel
            // 
            display_bargraph_panel.Controls.Add(panel4);
            display_bargraph_panel.Controls.Add(panel3);
            display_bargraph_panel.Location = new Point(12, 209);
            display_bargraph_panel.Name = "display_bargraph_panel";
            display_bargraph_panel.Size = new Size(667, 286);
            display_bargraph_panel.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Location = new Point(673, -6);
            panel3.Name = "panel3";
            panel3.Size = new Size(372, 295);
            panel3.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(panel5);
            panel4.Location = new Point(676, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(369, 289);
            panel4.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Location = new Point(673, -6);
            panel5.Name = "panel5";
            panel5.Size = new Size(372, 295);
            panel5.TabIndex = 0;
            // 
            // display_piechart_panel
            // 
            display_piechart_panel.Location = new Point(686, 209);
            display_piechart_panel.Name = "display_piechart_panel";
            display_piechart_panel.Size = new Size(371, 286);
            display_piechart_panel.TabIndex = 1;
            // 
            // backButton
            // 
            backButton.Location = new Point(461, 535);
            backButton.Name = "backButton";
            backButton.Size = new Size(151, 41);
            backButton.TabIndex = 2;
            backButton.Text = "button1";
            backButton.UseVisualStyleBackColor = true;
            // 
            // UserProductInventory_AnalyticsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1069, 588);
            Controls.Add(backButton);
            Controls.Add(display_piechart_panel);
            Controls.Add(display_bargraph_panel);
            Controls.Add(display_summary_panel);
            Name = "UserProductInventory_AnalyticsForm";
            Text = "Form1";
            display_bargraph_panel.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel display_summary_panel;
        private Panel display_bargraph_panel;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel display_piechart_panel;
        private Button backButton;
    }
}