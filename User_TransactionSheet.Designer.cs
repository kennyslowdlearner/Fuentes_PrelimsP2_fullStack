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
            button6 = new Button();
            label8 = new Label();
            button9 = new Button();
            button10 = new Button();
            fill_date_ts = new DateTimePicker();
            fill_customername_ts = new TextBox();
            label7 = new Label();
            fill_ricetype_ts = new ComboBox();
            button11 = new Button();
            fill_destination_tr = new TextBox();
            label9 = new Label();
            label10 = new Label();
            fill_region_tr = new ComboBox();
            display_kg_gg = new Label();
            display_sack_gg = new Label();
            label13 = new Label();
            label11 = new Label();
            label12 = new Label();
            label14 = new Label();
            ((System.ComponentModel.ISupportInitialize)Transaction_Sheet_Grid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Product_Inventory_Grid).BeginInit();
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
            Product_Inventory_Grid.Location = new Point(93, 526);
            Product_Inventory_Grid.Name = "Product_Inventory_Grid";
            Product_Inventory_Grid.RowHeadersWidth = 62;
            Product_Inventory_Grid.Size = new Size(800, 236);
            Product_Inventory_Grid.TabIndex = 0;
            Product_Inventory_Grid.CellClick += productinventoryCellClick;
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
            button1.Location = new Point(143, 482);
            button1.Name = "button1";
            button1.Size = new Size(143, 38);
            button1.TabIndex = 5;
            button1.Text = "Add";
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
            button2.Location = new Point(441, 482);
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
            button3.Location = new Point(292, 482);
            button3.Name = "button3";
            button3.Size = new Size(143, 38);
            button3.TabIndex = 5;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = false;
            button3.Click += press_updatets;
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
            button6.Location = new Point(1138, 721);
            button6.Name = "button6";
            button6.Size = new Size(120, 41);
            button6.TabIndex = 5;
            button6.UseVisualStyleBackColor = false;
            button6.Click += backButton;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.GreenYellow;
            label8.Location = new Point(983, 526);
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
            fill_ricetype_ts.SelectedIndexChanged += fill_ricetype_ts_SelectedIndexChanged;
            // 
            // button11
            // 
            button11.BackColor = Color.Yellow;
            button11.FlatAppearance.BorderColor = Color.Gold;
            button11.FlatAppearance.BorderSize = 2;
            button11.FlatStyle = FlatStyle.Flat;
            button11.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button11.ForeColor = Color.DarkGreen;
            button11.Location = new Point(1296, 454);
            button11.Name = "button11";
            button11.Size = new Size(151, 41);
            button11.TabIndex = 5;
            button11.Text = "View Analytics";
            button11.UseVisualStyleBackColor = false;
            button11.Click += GoToUserTransactionAnalytics;
            // 
            // fill_destination_tr
            // 
            fill_destination_tr.BackColor = Color.LightGreen;
            fill_destination_tr.BorderStyle = BorderStyle.None;
            fill_destination_tr.Location = new Point(320, 409);
            fill_destination_tr.Name = "fill_destination_tr";
            fill_destination_tr.Size = new Size(259, 24);
            fill_destination_tr.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.LawnGreen;
            label9.Location = new Point(138, 408);
            label9.Name = "label9";
            label9.Size = new Size(118, 27);
            label9.TabIndex = 4;
            label9.Text = "Destination";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.LawnGreen;
            label10.Location = new Point(138, 435);
            label10.Name = "label10";
            label10.Size = new Size(77, 27);
            label10.TabIndex = 4;
            label10.Text = "Region";
            // 
            // fill_region_tr
            // 
            fill_region_tr.BackColor = Color.LightGreen;
            fill_region_tr.FormattingEnabled = true;
            fill_region_tr.Items.AddRange(new object[] { "NCR (National Capital Region)", "CAR (Cordillera Administrative Region)", "REGION I (Ilocos Region)", "REGION II (Cagayan Valley)", "REGION III (Central Luzon)", "REGION IV-A (CALABARZON) ", "MIMAROPA (Southwestern Tagalog Region)", "REGION V (Bicol Region)", "REGION VI (Western Visayas)", "REGION VII (Central Visayas)", "REGION VIII (Eastern Visayas)", "NIR (Negros Island Region)", "REGION IX (Zamboanga Peninsula)", "REGION X (Northern Mindanao)", "REGION XI (Davao Region)", "REGION XII (SOCCSKSARGEN)", "REGION XIII (Caraga)", "BARMM (Bangsamoro Autonomous Region in Muslim Mindanao)" });
            fill_region_tr.Location = new Point(321, 443);
            fill_region_tr.Name = "fill_region_tr";
            fill_region_tr.Size = new Size(256, 33);
            fill_region_tr.TabIndex = 8;
            // 
            // display_kg_gg
            // 
            display_kg_gg.AutoSize = true;
            display_kg_gg.BackColor = Color.Transparent;
            display_kg_gg.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold | FontStyle.Italic);
            display_kg_gg.ForeColor = Color.Gold;
            display_kg_gg.Location = new Point(839, 462);
            display_kg_gg.Name = "display_kg_gg";
            display_kg_gg.Size = new Size(33, 27);
            display_kg_gg.TabIndex = 78;
            display_kg_gg.Text = "---";
            // 
            // display_sack_gg
            // 
            display_sack_gg.AutoSize = true;
            display_sack_gg.BackColor = Color.Transparent;
            display_sack_gg.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold | FontStyle.Italic);
            display_sack_gg.ForeColor = Color.Gold;
            display_sack_gg.Location = new Point(859, 489);
            display_sack_gg.Name = "display_sack_gg";
            display_sack_gg.Size = new Size(33, 27);
            display_sack_gg.TabIndex = 79;
            display_sack_gg.Text = "---";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.LawnGreen;
            label13.Location = new Point(633, 462);
            label13.Name = "label13";
            label13.Size = new Size(186, 27);
            label13.TabIndex = 80;
            label13.Text = "Total Quantity (Kg)";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.LawnGreen;
            label11.Location = new Point(633, 489);
            label11.Name = "label11";
            label11.Size = new Size(209, 27);
            label11.TabIndex = 81;
            label11.Text = "Total Quantity (Sack)";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.LawnGreen;
            label12.Location = new Point(818, 461);
            label12.Name = "label12";
            label12.Size = new Size(15, 24);
            label12.TabIndex = 76;
            label12.Text = ":";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.LawnGreen;
            label14.Location = new Point(839, 492);
            label14.Name = "label14";
            label14.Size = new Size(15, 24);
            label14.TabIndex = 77;
            label14.Text = ":";
            // 
            // User_TransactionSheet
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1500, 785);
            Controls.Add(display_kg_gg);
            Controls.Add(display_sack_gg);
            Controls.Add(label13);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(label14);
            Controls.Add(fill_region_tr);
            Controls.Add(fill_ricetype_ts);
            Controls.Add(fill_date_ts);
            Controls.Add(button11);
            Controls.Add(button6);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(display_referenceid_ts);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label7);
            Controls.Add(label1);
            Controls.Add(fill_customername_ts);
            Controls.Add(fill_destination_tr);
            Controls.Add(fill_priceperkg_ts);
            Controls.Add(fill_quantity_ts);
            Controls.Add(fill_productid_ts);
            Controls.Add(Product_Inventory_Grid);
            Controls.Add(Transaction_Sheet_Grid);
            ForeColor = Color.LawnGreen;
            Name = "User_TransactionSheet";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Transactions";
            ((System.ComponentModel.ISupportInitialize)Transaction_Sheet_Grid).EndInit();
            ((System.ComponentModel.ISupportInitialize)Product_Inventory_Grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Transaction_Sheet_Grid;
        private DataGridView Product_Inventory_Grid;
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
        private Button button6;
        private Label label8;
        private Button button9;
        private Button button10;
        private DateTimePicker fill_date_ts;
        private TextBox fill_customername_ts;
        private Label label7;
        private ComboBox fill_ricetype_ts;
        private Button button11;
        private TextBox fill_destination_tr;
        private Label label9;
        private Label label10;
        private ComboBox fill_region_tr;
        private Label display_kg_gg;
        private Label display_sack_gg;
        private Label label13;
        private Label label11;
        private Label label12;
        private Label label14;
    }
}