namespace Fuentes_PrelimsP2
{
    partial class UserTradesandTransactions
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserTradesandTransactions));
            display_name_TandT = new Label();
            display_datetime_TandT = new Label();
            label1 = new Label();
            addTransaction = new Button();
            viewTransaction = new Button();
            costOfProduction = new Button();
            marketForecasting = new Button();
            label4 = new Label();
            button6 = new Button();
            systemTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // display_name_TandT
            // 
            display_name_TandT.AutoSize = true;
            display_name_TandT.BackColor = Color.Transparent;
            display_name_TandT.Font = new Font("Glacial Indifference", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            display_name_TandT.ForeColor = Color.LawnGreen;
            display_name_TandT.Location = new Point(195, 149);
            display_name_TandT.Name = "display_name_TandT";
            display_name_TandT.Size = new Size(106, 34);
            display_name_TandT.TabIndex = 3;
            display_name_TandT.Text = "[USER]!";
            // 
            // display_datetime_TandT
            // 
            display_datetime_TandT.AutoSize = true;
            display_datetime_TandT.BackColor = Color.Transparent;
            display_datetime_TandT.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            display_datetime_TandT.ForeColor = Color.LawnGreen;
            display_datetime_TandT.Location = new Point(39, 186);
            display_datetime_TandT.Name = "display_datetime_TandT";
            display_datetime_TandT.Size = new Size(167, 27);
            display_datetime_TandT.TabIndex = 4;
            display_datetime_TandT.Text = "[Time and Date]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Glacial Indifference", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LawnGreen;
            label1.Location = new Point(39, 149);
            label1.Name = "label1";
            label1.Size = new Size(150, 34);
            label1.TabIndex = 5;
            label1.Text = "Hello there,";
            // 
            // addTransaction
            // 
            addTransaction.BackColor = Color.Transparent;
            addTransaction.BackgroundImage = (Image)resources.GetObject("addTransaction.BackgroundImage");
            addTransaction.FlatAppearance.BorderSize = 0;
            addTransaction.FlatStyle = FlatStyle.Flat;
            addTransaction.Location = new Point(171, 310);
            addTransaction.Name = "addTransaction";
            addTransaction.Size = new Size(165, 285);
            addTransaction.TabIndex = 6;
            addTransaction.UseVisualStyleBackColor = false;
            addTransaction.Click += GoToAddTransaction;
            // 
            // viewTransaction
            // 
            viewTransaction.BackColor = Color.Transparent;
            viewTransaction.BackgroundImage = (Image)resources.GetObject("viewTransaction.BackgroundImage");
            viewTransaction.FlatAppearance.BorderSize = 0;
            viewTransaction.FlatStyle = FlatStyle.Flat;
            viewTransaction.Location = new Point(362, 310);
            viewTransaction.Name = "viewTransaction";
            viewTransaction.Size = new Size(165, 285);
            viewTransaction.TabIndex = 6;
            viewTransaction.UseVisualStyleBackColor = false;
            viewTransaction.Click += GoToViewTransaction;
            // 
            // costOfProduction
            // 
            costOfProduction.BackColor = Color.Transparent;
            costOfProduction.BackgroundImage = (Image)resources.GetObject("costOfProduction.BackgroundImage");
            costOfProduction.FlatAppearance.BorderSize = 0;
            costOfProduction.FlatStyle = FlatStyle.Flat;
            costOfProduction.Location = new Point(550, 310);
            costOfProduction.Name = "costOfProduction";
            costOfProduction.Size = new Size(165, 285);
            costOfProduction.TabIndex = 6;
            costOfProduction.UseVisualStyleBackColor = false;
            costOfProduction.Click += GoToCostOfProduction;
            // 
            // marketForecasting
            // 
            marketForecasting.BackColor = Color.Transparent;
            marketForecasting.BackgroundImage = (Image)resources.GetObject("marketForecasting.BackgroundImage");
            marketForecasting.FlatAppearance.BorderSize = 0;
            marketForecasting.FlatStyle = FlatStyle.Flat;
            marketForecasting.Location = new Point(743, 310);
            marketForecasting.Name = "marketForecasting";
            marketForecasting.Size = new Size(165, 285);
            marketForecasting.TabIndex = 6;
            marketForecasting.UseVisualStyleBackColor = false;
            marketForecasting.Click += GoToMarketForecasting;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Gold;
            label4.Location = new Point(408, 248);
            label4.Name = "label4";
            label4.Size = new Size(237, 27);
            label4.TabIndex = 7;
            label4.Text = "Select your next step:";
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(446, 657);
            button6.Name = "button6";
            button6.Size = new Size(120, 41);
            button6.TabIndex = 124;
            button6.UseVisualStyleBackColor = false;
            button6.Click += back_Button;
            // 
            // systemTimer
            // 
            systemTimer.Enabled = true;
            systemTimer.Interval = 1000;
            systemTimer.Tick += systemTimer_Tick;
            // 
            // UserTradesandTransactions
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1064, 710);
            Controls.Add(button6);
            Controls.Add(label4);
            Controls.Add(marketForecasting);
            Controls.Add(costOfProduction);
            Controls.Add(viewTransaction);
            Controls.Add(addTransaction);
            Controls.Add(display_name_TandT);
            Controls.Add(display_datetime_TandT);
            Controls.Add(label1);
            Name = "UserTradesandTransactions";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trades and Transactions";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label display_name_TandT;
        private Label display_datetime_TandT;
        private Label label1;
        private Button addTransaction;
        private Button viewTransaction;
        private Button costOfProduction;
        private Button marketForecasting;
        private Label label4;
        private Button button6;
        private System.Windows.Forms.Timer systemTimer;
    }
}