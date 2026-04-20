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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserProductInventory_Analytics));
            display_summary_panel = new Panel();
            display_capacity_summary = new Label();
            label4 = new Label();
            display_totalKilograms_summary = new Label();
            label3 = new Label();
            display_productquantities_summary = new Label();
            label1 = new Label();
            label2 = new Label();
            display_bargraph_panel = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel3 = new Panel();
            display_piechart_panel = new Panel();
            display_summary_panel.SuspendLayout();
            display_bargraph_panel.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // display_summary_panel
            // 
            display_summary_panel.BackColor = Color.Transparent;
            display_summary_panel.Controls.Add(display_capacity_summary);
            display_summary_panel.Controls.Add(label4);
            display_summary_panel.Controls.Add(display_totalKilograms_summary);
            display_summary_panel.Controls.Add(label3);
            display_summary_panel.Controls.Add(display_productquantities_summary);
            display_summary_panel.Controls.Add(label1);
            display_summary_panel.Controls.Add(label2);
            display_summary_panel.Location = new Point(23, 28);
            display_summary_panel.Name = "display_summary_panel";
            display_summary_panel.Size = new Size(1045, 213);
            display_summary_panel.TabIndex = 0;
            // 
            // display_capacity_summary
            // 
            display_capacity_summary.AutoSize = true;
            display_capacity_summary.Font = new Font("League Spartan", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            display_capacity_summary.Location = new Point(731, 48);
            display_capacity_summary.Name = "display_capacity_summary";
            display_capacity_summary.Size = new Size(237, 107);
            display_capacity_summary.TabIndex = 3;
            display_capacity_summary.Text = "label3";
            display_capacity_summary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Glacial Indifference", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DarkGoldenrod;
            label4.Location = new Point(794, 155);
            label4.Name = "label4";
            label4.Size = new Size(116, 29);
            label4.TabIndex = 2;
            label4.Text = "Capacity";
            label4.Click += label4_Click;
            // 
            // display_totalKilograms_summary
            // 
            display_totalKilograms_summary.AutoSize = true;
            display_totalKilograms_summary.Font = new Font("League Spartan", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            display_totalKilograms_summary.ForeColor = Color.DarkGreen;
            display_totalKilograms_summary.Location = new Point(384, 48);
            display_totalKilograms_summary.Name = "display_totalKilograms_summary";
            display_totalKilograms_summary.Size = new Size(237, 107);
            display_totalKilograms_summary.TabIndex = 3;
            display_totalKilograms_summary.Text = "label3";
            display_totalKilograms_summary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Glacial Indifference", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkGoldenrod;
            label3.Location = new Point(449, 155);
            label3.Name = "label3";
            label3.Size = new Size(185, 29);
            label3.TabIndex = 2;
            label3.Text = "Total Kilograms";
            // 
            // display_productquantities_summary
            // 
            display_productquantities_summary.AutoSize = true;
            display_productquantities_summary.Font = new Font("League Spartan", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            display_productquantities_summary.ForeColor = Color.DarkGreen;
            display_productquantities_summary.Location = new Point(47, 48);
            display_productquantities_summary.Name = "display_productquantities_summary";
            display_productquantities_summary.Size = new Size(237, 107);
            display_productquantities_summary.TabIndex = 3;
            display_productquantities_summary.Text = "label3";
            display_productquantities_summary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Glacial Indifference", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkGoldenrod;
            label1.Location = new Point(47, 155);
            label1.Name = "label1";
            label1.Size = new Size(220, 29);
            label1.TabIndex = 2;
            label1.Text = "Product Quantities";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("League Spartan", 15.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkOliveGreen;
            label2.Location = new Point(290, 0);
            label2.Name = "label2";
            label2.Size = new Size(412, 48);
            label2.TabIndex = 0;
            label2.Text = "Product Inventory Analytics";
            // 
            // display_bargraph_panel
            // 
            display_bargraph_panel.BackColor = Color.Transparent;
            display_bargraph_panel.Controls.Add(panel4);
            display_bargraph_panel.Controls.Add(panel3);
            display_bargraph_panel.Location = new Point(32, 268);
            display_bargraph_panel.Name = "display_bargraph_panel";
            display_bargraph_panel.Size = new Size(562, 275);
            display_bargraph_panel.TabIndex = 0;
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
            // panel3
            // 
            panel3.Location = new Point(673, -6);
            panel3.Name = "panel3";
            panel3.Size = new Size(372, 295);
            panel3.TabIndex = 0;
            // 
            // display_piechart_panel
            // 
            display_piechart_panel.BackColor = Color.Transparent;
            display_piechart_panel.Location = new Point(600, 268);
            display_piechart_panel.Name = "display_piechart_panel";
            display_piechart_panel.Size = new Size(457, 275);
            display_piechart_panel.TabIndex = 1;
            // 
            // UserProductInventory_Analytics
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1092, 566);
            Controls.Add(display_piechart_panel);
            Controls.Add(display_bargraph_panel);
            Controls.Add(display_summary_panel);
            Name = "UserProductInventory_Analytics";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Product Inventory: Analytics";
            display_summary_panel.ResumeLayout(false);
            display_summary_panel.PerformLayout();
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
        private Label label1;
        private Label label2;
        private Label display_totalKilograms_summary;
        private Label label3;
        private Label display_productquantities_summary;
        private Label display_capacity_summary;
        private Label label4;
    }
}