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
            label4 = new Label();
            display_rate_summary = new Label();
            label2 = new Label();
            display_transactions_summary = new Label();
            label1 = new Label();
            display_scatterplot_analyticsTandT = new Panel();
            display_piechartt_analyticsTandT = new Panel();
            display_summary_analyticsTandT.SuspendLayout();
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
            display_summary_analyticsTandT.BackColor = Color.Transparent;
            display_summary_analyticsTandT.Controls.Add(label4);
            display_summary_analyticsTandT.Controls.Add(display_rate_summary);
            display_summary_analyticsTandT.Controls.Add(label2);
            display_summary_analyticsTandT.Controls.Add(display_transactions_summary);
            display_summary_analyticsTandT.Controls.Add(label1);
            display_summary_analyticsTandT.Location = new Point(32, 12);
            display_summary_analyticsTandT.Name = "display_summary_analyticsTandT";
            display_summary_analyticsTandT.Size = new Size(732, 201);
            display_summary_analyticsTandT.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("League Spartan", 15.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DarkOliveGreen;
            label4.Location = new Point(183, 20);
            label4.Name = "label4";
            label4.Size = new Size(323, 48);
            label4.TabIndex = 6;
            label4.Text = "Transaction Analytics";
            // 
            // display_rate_summary
            // 
            display_rate_summary.AutoSize = true;
            display_rate_summary.Font = new Font("League Spartan", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            display_rate_summary.ForeColor = Color.DarkGreen;
            display_rate_summary.Location = new Point(426, 56);
            display_rate_summary.Name = "display_rate_summary";
            display_rate_summary.Size = new Size(237, 107);
            display_rate_summary.TabIndex = 5;
            display_rate_summary.Text = "label3";
            display_rate_summary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Glacial Indifference", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DarkGoldenrod;
            label2.Location = new Point(506, 163);
            label2.Name = "label2";
            label2.Size = new Size(63, 29);
            label2.TabIndex = 4;
            label2.Text = "Rate";
            label2.Click += label1_Click;
            // 
            // display_transactions_summary
            // 
            display_transactions_summary.AutoSize = true;
            display_transactions_summary.Font = new Font("League Spartan", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            display_transactions_summary.ForeColor = Color.DarkGreen;
            display_transactions_summary.Location = new Point(24, 56);
            display_transactions_summary.Name = "display_transactions_summary";
            display_transactions_summary.Size = new Size(237, 107);
            display_transactions_summary.TabIndex = 5;
            display_transactions_summary.Text = "label3";
            display_transactions_summary.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Glacial Indifference", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkGoldenrod;
            label1.Location = new Point(28, 163);
            label1.Name = "label1";
            label1.Size = new Size(226, 29);
            label1.TabIndex = 4;
            label1.Text = "Transactions Made";
            label1.Click += label1_Click;
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
            display_summary_analyticsTandT.ResumeLayout(false);
            display_summary_analyticsTandT.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel display_piechart_analyticsTandT;
        private Panel display_summary_analyticsTandT;
        private Panel display_scatterplot_analyticsTandT;
        private Panel display_piechartt_analyticsTandT;
        private Label display_transactions_summary;
        private Label label1;
        private Label display_rate_summary;
        private Label label2;
        private Label label4;
    }
}