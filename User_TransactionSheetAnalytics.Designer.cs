namespace Fuentes_PrelimsP2
{
    partial class User_TransactionSheetAnalytics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_TransactionSheetAnalytics));
            display_piechart_analyticsTandT = new Panel();
            display_summary_analyticsTandT = new Panel();
            display_scatterplot_analyticsTandT = new Panel();
            display_piechartt_analyticsTandT = new Panel();
            SuspendLayout();
            // 
            // display_piechart_analyticsTandT
            // 
            display_piechart_analyticsTandT.BackColor = Color.Transparent;
            display_piechart_analyticsTandT.Location = new Point(32, 246);
            display_piechart_analyticsTandT.Name = "display_piechart_analyticsTandT";
            display_piechart_analyticsTandT.Size = new Size(320, 288);
            display_piechart_analyticsTandT.TabIndex = 0;
            display_piechart_analyticsTandT.Paint += panel1_Paint;
            // 
            // display_summary_analyticsTandT
            // 
            display_summary_analyticsTandT.Location = new Point(32, 39);
            display_summary_analyticsTandT.Name = "display_summary_analyticsTandT";
            display_summary_analyticsTandT.Size = new Size(885, 174);
            display_summary_analyticsTandT.TabIndex = 0;
            // 
            // display_scatterplot_analyticsTandT
            // 
            display_scatterplot_analyticsTandT.BackColor = Color.Transparent;
            display_scatterplot_analyticsTandT.Location = new Point(701, 246);
            display_scatterplot_analyticsTandT.Name = "display_scatterplot_analyticsTandT";
            display_scatterplot_analyticsTandT.Size = new Size(567, 288);
            display_scatterplot_analyticsTandT.TabIndex = 1;
            display_scatterplot_analyticsTandT.Paint += panel4_Paint;
            // 
            // display_piechartt_analyticsTandT
            // 
            display_piechartt_analyticsTandT.BackColor = Color.Transparent;
            display_piechartt_analyticsTandT.Location = new Point(358, 246);
            display_piechartt_analyticsTandT.Name = "display_piechartt_analyticsTandT";
            display_piechartt_analyticsTandT.Size = new Size(337, 288);
            display_piechartt_analyticsTandT.TabIndex = 0;
            display_piechartt_analyticsTandT.Paint += panel1_Paint;
            // 
            // User_TransactionSheetAnalytics
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1298, 558);
            Controls.Add(display_piechartt_analyticsTandT);
            Controls.Add(display_scatterplot_analyticsTandT);
            Controls.Add(display_summary_analyticsTandT);
            Controls.Add(display_piechart_analyticsTandT);
            Name = "User_TransactionSheetAnalytics";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Transaction: Analytics";
            Load += User_TransactionSheetAnalytics_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel display_piechart_analyticsTandT;
        private Panel display_summary_analyticsTandT;
        private Panel display_scatterplot_analyticsTandT;
        private Panel display_piechartt_analyticsTandT;
    }
}