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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserTradesandTransactions));
            menuStrip1 = new MenuStrip();
            sssssToolStripMenuItem = new ToolStripMenuItem();
            reloadToolStripMenuItem = new ToolStripMenuItem();
            learnMoreToolStripMenuItem = new ToolStripMenuItem();
            contactDeveloperToolStripMenuItem = new ToolStripMenuItem();
            accountSettingsToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            label3 = new Label();
            label1 = new Label();
            addTransaction = new Button();
            viewTransaction = new Button();
            digitalVaultReceipt = new Button();
            costOfProduction = new Button();
            marketForecasting = new Button();
            label4 = new Label();
            button6 = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { sssssToolStripMenuItem, accountSettingsToolStripMenuItem });
            menuStrip1.Location = new Point(703, 185);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(343, 32);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // sssssToolStripMenuItem
            // 
            sssssToolStripMenuItem.BackColor = Color.Transparent;
            sssssToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reloadToolStripMenuItem, learnMoreToolStripMenuItem, contactDeveloperToolStripMenuItem });
            sssssToolStripMenuItem.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sssssToolStripMenuItem.ForeColor = Color.LawnGreen;
            sssssToolStripMenuItem.Name = "sssssToolStripMenuItem";
            sssssToolStripMenuItem.Size = new Size(151, 28);
            sssssToolStripMenuItem.Text = "More Options";
            // 
            // reloadToolStripMenuItem
            // 
            reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            reloadToolStripMenuItem.Size = new Size(281, 34);
            reloadToolStripMenuItem.Text = "Reload";
            // 
            // learnMoreToolStripMenuItem
            // 
            learnMoreToolStripMenuItem.Name = "learnMoreToolStripMenuItem";
            learnMoreToolStripMenuItem.Size = new Size(281, 34);
            learnMoreToolStripMenuItem.Text = "Learn More";
            // 
            // contactDeveloperToolStripMenuItem
            // 
            contactDeveloperToolStripMenuItem.Name = "contactDeveloperToolStripMenuItem";
            contactDeveloperToolStripMenuItem.Size = new Size(281, 34);
            contactDeveloperToolStripMenuItem.Text = "Contact Developer";
            // 
            // accountSettingsToolStripMenuItem
            // 
            accountSettingsToolStripMenuItem.BackColor = Color.Transparent;
            accountSettingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { logoutToolStripMenuItem });
            accountSettingsToolStripMenuItem.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            accountSettingsToolStripMenuItem.ForeColor = Color.LawnGreen;
            accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            accountSettingsToolStripMenuItem.Size = new Size(184, 28);
            accountSettingsToolStripMenuItem.Text = "Account Settings";
            // 
            // logoutToolStripMenuItem
            // 
            logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            logoutToolStripMenuItem.Size = new Size(172, 34);
            logoutToolStripMenuItem.Text = "Logout";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Glacial Indifference", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LawnGreen;
            label2.Location = new Point(195, 149);
            label2.Name = "label2";
            label2.Size = new Size(106, 34);
            label2.TabIndex = 3;
            label2.Text = "[USER]!";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.LawnGreen;
            label3.Location = new Point(39, 186);
            label3.Name = "label3";
            label3.Size = new Size(167, 27);
            label3.TabIndex = 4;
            label3.Text = "[Time and Date]";
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
            addTransaction.Location = new Point(78, 310);
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
            viewTransaction.Location = new Point(262, 310);
            viewTransaction.Name = "viewTransaction";
            viewTransaction.Size = new Size(165, 285);
            viewTransaction.TabIndex = 6;
            viewTransaction.UseVisualStyleBackColor = false;
            viewTransaction.Click += GoToViewTransaction;
            // 
            // digitalVaultReceipt
            // 
            digitalVaultReceipt.BackColor = Color.Transparent;
            digitalVaultReceipt.BackgroundImage = (Image)resources.GetObject("digitalVaultReceipt.BackgroundImage");
            digitalVaultReceipt.FlatAppearance.BorderSize = 0;
            digitalVaultReceipt.FlatStyle = FlatStyle.Flat;
            digitalVaultReceipt.Location = new Point(446, 310);
            digitalVaultReceipt.Name = "digitalVaultReceipt";
            digitalVaultReceipt.Size = new Size(165, 285);
            digitalVaultReceipt.TabIndex = 6;
            digitalVaultReceipt.UseVisualStyleBackColor = false;
            digitalVaultReceipt.Click += GoToDigitalVaultReceipt;
            // 
            // costOfProduction
            // 
            costOfProduction.BackColor = Color.Transparent;
            costOfProduction.BackgroundImage = (Image)resources.GetObject("costOfProduction.BackgroundImage");
            costOfProduction.FlatAppearance.BorderSize = 0;
            costOfProduction.FlatStyle = FlatStyle.Flat;
            costOfProduction.Location = new Point(630, 310);
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
            marketForecasting.Location = new Point(815, 310);
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
            Controls.Add(digitalVaultReceipt);
            Controls.Add(addTransaction);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Name = "UserTradesandTransactions";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form2";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem sssssToolStripMenuItem;
        private ToolStripMenuItem reloadToolStripMenuItem;
        private ToolStripMenuItem learnMoreToolStripMenuItem;
        private ToolStripMenuItem contactDeveloperToolStripMenuItem;
        private ToolStripMenuItem accountSettingsToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private Label label2;
        private Label label3;
        private Label label1;
        private Button addTransaction;
        private Button viewTransaction;
        private Button digitalVaultReceipt;
        private Button costOfProduction;
        private Button marketForecasting;
        private Label label4;
        private Button button6;
    }
}