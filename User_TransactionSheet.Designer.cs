namespace Fuentes_PrelimsP2
{
    partial class User_TransactionSheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_TransactionSheet));
            Transaction_Sheet_Grid = new DataGridView();
            Product_Inventory_Grid = new DataGridView();
            menuStrip1 = new MenuStrip();
            sssssToolStripMenuItem = new ToolStripMenuItem();
            reloadToolStripMenuItem = new ToolStripMenuItem();
            learnMoreToolStripMenuItem = new ToolStripMenuItem();
            contactDeveloperToolStripMenuItem = new ToolStripMenuItem();
            accountSettingsToolStripMenuItem = new ToolStripMenuItem();
            logoutToolStripMenuItem = new ToolStripMenuItem();
            fill_productid_ts = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            fill_quantity_ts = new TextBox();
            fill_priceperkg_ts = new TextBox();
            display_referenceid_ts = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            label8 = new Label();
            button9 = new Button();
            button10 = new Button();
            fill_date_ts = new DateTimePicker();
            fill_customername_ts = new TextBox();
            label7 = new Label();
            fill_ricetype_ts = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)Transaction_Sheet_Grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Product_Inventory_Grid).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // Transaction_Sheet_Grid
            // 
            Transaction_Sheet_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Transaction_Sheet_Grid.Location = new Point(649, 197);
            Transaction_Sheet_Grid.Name = "Transaction_Sheet_Grid";
            Transaction_Sheet_Grid.RowHeadersWidth = 62;
            Transaction_Sheet_Grid.Size = new Size(798, 251);
            Transaction_Sheet_Grid.TabIndex = 0;
            Transaction_Sheet_Grid.CellClick += tradsactionsheetCellClick;
            // 
            // Product_Inventory_Grid
            // 
            Product_Inventory_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Product_Inventory_Grid.Location = new Point(98, 481);
            Product_Inventory_Grid.Name = "Product_Inventory_Grid";
            Product_Inventory_Grid.RowHeadersWidth = 62;
            Product_Inventory_Grid.Size = new Size(800, 236);
            Product_Inventory_Grid.TabIndex = 0;
            Product_Inventory_Grid.CellClick += productinventoryCellClick;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Transparent;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { sssssToolStripMenuItem, accountSettingsToolStripMenuItem });
            menuStrip1.Location = new Point(1111, 162);
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
            // fill_productid_ts
            // 
            fill_productid_ts.BackColor = Color.LightGreen;
            fill_productid_ts.BorderStyle = BorderStyle.None;
            fill_productid_ts.Location = new Point(320, 234);
            fill_productid_ts.Name = "fill_productid_ts";
            fill_productid_ts.Size = new Size(259, 24);
            fill_productid_ts.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LawnGreen;
            label1.Location = new Point(138, 196);
            label1.Name = "label1";
            label1.Size = new Size(100, 27);
            label1.TabIndex = 4;
            label1.Text = "Rice Type";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LawnGreen;
            label2.Location = new Point(138, 233);
            label2.Name = "label2";
            label2.Size = new Size(110, 27);
            label2.TabIndex = 4;
            label2.Text = "Product ID";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.LawnGreen;
            label3.Location = new Point(138, 272);
            label3.Name = "label3";
            label3.Size = new Size(126, 27);
            label3.TabIndex = 4;
            label3.Text = "Price per Kg";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.LawnGreen;
            label4.Location = new Point(138, 311);
            label4.Name = "label4";
            label4.Size = new Size(159, 27);
            label4.TabIndex = 4;
            label4.Text = "Quantity per Kg";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.LawnGreen;
            label5.Location = new Point(138, 348);
            label5.Name = "label5";
            label5.Size = new Size(137, 27);
            label5.TabIndex = 4;
            label5.Text = "Delivery Date";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.LawnGreen;
            label6.Location = new Point(138, 381);
            label6.Name = "label6";
            label6.Size = new Size(134, 27);
            label6.TabIndex = 4;
            label6.Text = "Reference ID";
            // 
            // fill_quantity_ts
            // 
            fill_quantity_ts.BackColor = Color.LightGreen;
            fill_quantity_ts.BorderStyle = BorderStyle.None;
            fill_quantity_ts.Location = new Point(320, 307);
            fill_quantity_ts.Name = "fill_quantity_ts";
            fill_quantity_ts.Size = new Size(259, 24);
            fill_quantity_ts.TabIndex = 3;
            // 
            // fill_priceperkg_ts
            // 
            fill_priceperkg_ts.BackColor = Color.LightGreen;
            fill_priceperkg_ts.BorderStyle = BorderStyle.None;
            fill_priceperkg_ts.Location = new Point(320, 270);
            fill_priceperkg_ts.Name = "fill_priceperkg_ts";
            fill_priceperkg_ts.Size = new Size(259, 24);
            fill_priceperkg_ts.TabIndex = 3;
            // 
            // display_referenceid_ts
            // 
            display_referenceid_ts.AutoSize = true;
            display_referenceid_ts.BackColor = Color.Transparent;
            display_referenceid_ts.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Italic, GraphicsUnit.Point, 0);
            display_referenceid_ts.ForeColor = Color.Gold;
            display_referenceid_ts.Location = new Point(320, 381);
            display_referenceid_ts.Name = "display_referenceid_ts";
            display_referenceid_ts.Size = new Size(140, 27);
            display_referenceid_ts.TabIndex = 4;
            display_referenceid_ts.Text = "Reference ID:";
            // 
            // button1
            // 
            button1.BackColor = Color.Yellow;
            button1.FlatAppearance.BorderColor = Color.Gold;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.DarkGreen;
            button1.Location = new Point(138, 423);
            button1.Name = "button1";
            button1.Size = new Size(143, 38);
            button1.TabIndex = 5;
            button1.Text = "Insert";
            button1.UseVisualStyleBackColor = false;
            button1.Click += press_insertts;
            // 
            // button2
            // 
            button2.BackColor = Color.Yellow;
            button2.FlatAppearance.BorderColor = Color.Gold;
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.DarkGreen;
            button2.Location = new Point(287, 423);
            button2.Name = "button2";
            button2.Size = new Size(143, 38);
            button2.TabIndex = 5;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = false;
            button2.Click += press_deletets;
            // 
            // button3
            // 
            button3.BackColor = Color.Yellow;
            button3.FlatAppearance.BorderColor = Color.Gold;
            button3.FlatAppearance.BorderSize = 2;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.DarkGreen;
            button3.Location = new Point(436, 423);
            button3.Name = "button3";
            button3.Size = new Size(143, 38);
            button3.TabIndex = 5;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = false;
            button3.Click += press_updatets;
            // 
            // button4
            // 
            button4.BackColor = Color.Yellow;
            button4.FlatAppearance.BorderColor = Color.Gold;
            button4.FlatAppearance.BorderSize = 2;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.DarkGreen;
            button4.Location = new Point(98, 732);
            button4.Name = "button4";
            button4.Size = new Size(120, 41);
            button4.TabIndex = 5;
            button4.Text = "Load";
            button4.UseVisualStyleBackColor = false;
            button4.Click += loadButton;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.FlatAppearance.BorderColor = Color.Gold;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.DarkGreen;
            button5.Location = new Point(778, 732);
            button5.Name = "button5";
            button5.Size = new Size(120, 41);
            button5.TabIndex = 5;
            button5.UseVisualStyleBackColor = false;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.FlatAppearance.BorderColor = Color.Gold;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.ForeColor = Color.DarkGreen;
            button6.Location = new Point(649, 732);
            button6.Name = "button6";
            button6.Size = new Size(120, 41);
            button6.TabIndex = 5;
            button6.UseVisualStyleBackColor = false;
            button6.Click += backButton;
            // 
            // button7
            // 
            button7.BackColor = Color.Yellow;
            button7.FlatAppearance.BorderColor = Color.Gold;
            button7.FlatAppearance.BorderSize = 2;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.DarkGreen;
            button7.Location = new Point(224, 732);
            button7.Name = "button7";
            button7.Size = new Size(151, 41);
            button7.TabIndex = 5;
            button7.Text = "Print Receipt";
            button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            button8.BackColor = Color.Transparent;
            button8.BackgroundImage = (Image)resources.GetObject("button8.BackgroundImage");
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.Location = new Point(983, 495);
            button8.Name = "button8";
            button8.Size = new Size(418, 64);
            button8.TabIndex = 5;
            button8.UseVisualStyleBackColor = false;
            button8.Click += shortcut_DigitalReceiptVault;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.GreenYellow;
            label8.Location = new Point(983, 465);
            label8.Name = "label8";
            label8.Size = new Size(164, 27);
            label8.TabIndex = 4;
            label8.Text = "Other Options:";
            // 
            // button9
            // 
            button9.BackColor = Color.Transparent;
            button9.BackgroundImage = (Image)resources.GetObject("button9.BackgroundImage");
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button9.Location = new Point(983, 565);
            button9.Name = "button9";
            button9.Size = new Size(418, 64);
            button9.TabIndex = 5;
            button9.UseVisualStyleBackColor = false;
            button9.Click += shortcut_CostOfProduction;
            // 
            // button10
            // 
            button10.BackColor = Color.Transparent;
            button10.BackgroundImage = (Image)resources.GetObject("button10.BackgroundImage");
            button10.FlatAppearance.BorderSize = 0;
            button10.FlatStyle = FlatStyle.Flat;
            button10.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button10.Location = new Point(983, 635);
            button10.Name = "button10";
            button10.Size = new Size(418, 64);
            button10.TabIndex = 5;
            button10.UseVisualStyleBackColor = false;
            button10.Click += shortcut_MarketForecasting;
            // 
            // fill_date_ts
            // 
            fill_date_ts.Location = new Point(320, 344);
            fill_date_ts.Name = "fill_date_ts";
            fill_date_ts.Size = new Size(259, 31);
            fill_date_ts.TabIndex = 6;
            // 
            // fill_customername_ts
            // 
            fill_customername_ts.BackColor = Color.LightGreen;
            fill_customername_ts.BorderStyle = BorderStyle.None;
            fill_customername_ts.Location = new Point(320, 162);
            fill_customername_ts.Name = "fill_customername_ts";
            fill_customername_ts.Size = new Size(259, 24);
            fill_customername_ts.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.LawnGreen;
            label7.Location = new Point(133, 162);
            label7.Name = "label7";
            label7.Size = new Size(170, 27);
            label7.TabIndex = 4;
            label7.Text = " Customer Name";
            // 
            // fill_ricetype_ts
            // 
            fill_ricetype_ts.FormattingEnabled = true;
            fill_ricetype_ts.Location = new Point(320, 192);
            fill_ricetype_ts.Name = "fill_ricetype_ts";
            fill_ricetype_ts.Size = new Size(259, 33);
            fill_ricetype_ts.TabIndex = 7;
            fill_ricetype_ts.SelectedIndex = -1;
            // 
            // User_TransactionSheet
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1500, 785);
            Controls.Add(fill_ricetype_ts);
            Controls.Add(fill_date_ts);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(display_referenceid_ts);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label7);
            Controls.Add(label1);
            Controls.Add(fill_customername_ts);
            Controls.Add(fill_priceperkg_ts);
            Controls.Add(fill_quantity_ts);
            Controls.Add(fill_productid_ts);
            Controls.Add(menuStrip1);
            Controls.Add(Product_Inventory_Grid);
            Controls.Add(Transaction_Sheet_Grid);
            ForeColor = Color.LawnGreen;
            Name = "User_TransactionSheet";
            Text = "User Transactions";
            ((System.ComponentModel.ISupportInitialize)Transaction_Sheet_Grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)Product_Inventory_Grid).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Transaction_Sheet_Grid;
        private DataGridView Product_Inventory_Grid;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem sssssToolStripMenuItem;
        private ToolStripMenuItem reloadToolStripMenuItem;
        private ToolStripMenuItem learnMoreToolStripMenuItem;
        private ToolStripMenuItem contactDeveloperToolStripMenuItem;
        private ToolStripMenuItem accountSettingsToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private TextBox fill_productid_ts;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox fill_quantity_ts;
        private TextBox fill_priceperkg_ts;
        private Label display_referenceid_ts;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Label label8;
        private Button button9;
        private Button button10;
        private DateTimePicker fill_date_ts;
        private TextBox fill_customername_ts;
        private Label label7;
        private ComboBox fill_ricetype_ts;
    }
}