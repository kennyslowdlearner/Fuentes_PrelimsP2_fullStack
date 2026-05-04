namespace Fuentes_PrelimsP2
{
    partial class productInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(productInventory));
            panel1 = new Panel();
            Product_Inventory_Grid = new DataGridView();
            button6 = new Button();
            label8 = new Label();
            fill_productname_pi = new TextBox();
            label9 = new Label();
            label1 = new Label();
            fill_productid_pi = new TextBox();
            label2 = new Label();
            label3 = new Label();
            fill_quantity_pi = new TextBox();
            label4 = new Label();
            press_update_pi = new Button();
            press_delete_pi = new Button();
            press_insert_pi = new Button();
            press_connect_pi = new Button();
            press_switch_pi = new Button();
            press_refresh_pi = new Button();
            label6 = new Label();
            label5 = new Label();
            fill_search_pi = new TextBox();
            button1 = new Button();
            label_sc1_pi = new Label();
            fill_batchcode_pi = new TextBox();
            label_batchsource_pi = new Label();
            label_sc2_pi = new Label();
            label_datereceived_pi = new Label();
            label_sc3_pi = new Label();
            fill_germrate_pi = new TextBox();
            label_germrate_pi = new Label();
            fill_datereceived_pi = new DateTimePicker();
            display_indicator_pi = new Label();
            label7 = new Label();
            label10 = new Label();
            display_sack_gg = new Label();
            label12 = new Label();
            label13 = new Label();
            display_kg_gg = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Product_Inventory_Grid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(Product_Inventory_Grid);
            panel1.Font = new Font("Glacial Indifference", 10F);
            panel1.Location = new Point(54, 235);
            panel1.Name = "panel1";
            panel1.Size = new Size(1374, 314);
            panel1.TabIndex = 1;
            // 
            // Product_Inventory_Grid
            // 
            Product_Inventory_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Product_Inventory_Grid.Location = new Point(3, 3);
            Product_Inventory_Grid.Name = "Product_Inventory_Grid";
            Product_Inventory_Grid.RowHeadersWidth = 62;
            Product_Inventory_Grid.Size = new Size(1368, 308);
            Product_Inventory_Grid.TabIndex = 0;
            Product_Inventory_Grid.CellClick += datagrid_cellclick;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(724, 722);
            button6.Name = "button6";
            button6.Size = new Size(120, 41);
            button6.TabIndex = 54;
            button6.UseVisualStyleBackColor = false;
            button6.Click += backButton;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.LawnGreen;
            label8.Location = new Point(51, 561);
            label8.Name = "label8";
            label8.Size = new Size(146, 27);
            label8.TabIndex = 75;
            label8.Text = "Product Name";
            // 
            // fill_productname_pi
            // 
            fill_productname_pi.BackColor = Color.LightGreen;
            fill_productname_pi.BorderStyle = BorderStyle.None;
            fill_productname_pi.Location = new Point(224, 570);
            fill_productname_pi.Name = "fill_productname_pi";
            fill_productname_pi.Size = new Size(207, 24);
            fill_productname_pi.TabIndex = 74;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.LawnGreen;
            label9.Location = new Point(203, 567);
            label9.Name = "label9";
            label9.Size = new Size(15, 24);
            label9.TabIndex = 73;
            label9.Text = ":";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LawnGreen;
            label1.Location = new Point(203, 594);
            label1.Name = "label1";
            label1.Size = new Size(15, 24);
            label1.TabIndex = 73;
            label1.Text = ":";
            // 
            // fill_productid_pi
            // 
            fill_productid_pi.BackColor = Color.LightGreen;
            fill_productid_pi.BorderStyle = BorderStyle.None;
            fill_productid_pi.Location = new Point(224, 597);
            fill_productid_pi.Name = "fill_productid_pi";
            fill_productid_pi.Size = new Size(207, 24);
            fill_productid_pi.TabIndex = 74;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LawnGreen;
            label2.Location = new Point(51, 588);
            label2.Name = "label2";
            label2.Size = new Size(110, 27);
            label2.TabIndex = 75;
            label2.Text = "Product ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.LawnGreen;
            label3.Location = new Point(203, 621);
            label3.Name = "label3";
            label3.Size = new Size(15, 24);
            label3.TabIndex = 73;
            label3.Text = ":";
            // 
            // fill_quantity_pi
            // 
            fill_quantity_pi.BackColor = Color.LightGreen;
            fill_quantity_pi.BorderStyle = BorderStyle.None;
            fill_quantity_pi.Location = new Point(224, 624);
            fill_quantity_pi.Name = "fill_quantity_pi";
            fill_quantity_pi.Size = new Size(207, 24);
            fill_quantity_pi.TabIndex = 74;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.LawnGreen;
            label4.Location = new Point(51, 615);
            label4.Name = "label4";
            label4.Size = new Size(135, 27);
            label4.TabIndex = 75;
            label4.Text = "Quantity (Kg)";
            // 
            // press_update_pi
            // 
            press_update_pi.BackColor = Color.Yellow;
            press_update_pi.FlatAppearance.BorderColor = Color.Gold;
            press_update_pi.FlatAppearance.BorderSize = 2;
            press_update_pi.FlatStyle = FlatStyle.Flat;
            press_update_pi.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            press_update_pi.ForeColor = Color.DarkGreen;
            press_update_pi.Location = new Point(199, 669);
            press_update_pi.Name = "press_update_pi";
            press_update_pi.Size = new Size(143, 38);
            press_update_pi.TabIndex = 76;
            press_update_pi.Text = "Update";
            press_update_pi.UseVisualStyleBackColor = false;
            press_update_pi.Click += press_updatepi;
            // 
            // press_delete_pi
            // 
            press_delete_pi.BackColor = Color.Yellow;
            press_delete_pi.FlatAppearance.BorderColor = Color.Gold;
            press_delete_pi.FlatAppearance.BorderSize = 2;
            press_delete_pi.FlatStyle = FlatStyle.Flat;
            press_delete_pi.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            press_delete_pi.ForeColor = Color.DarkGreen;
            press_delete_pi.Location = new Point(348, 669);
            press_delete_pi.Name = "press_delete_pi";
            press_delete_pi.Size = new Size(143, 38);
            press_delete_pi.TabIndex = 77;
            press_delete_pi.Text = "Delete";
            press_delete_pi.UseVisualStyleBackColor = false;
            press_delete_pi.Click += press_deletepi;
            // 
            // press_insert_pi
            // 
            press_insert_pi.BackColor = Color.Yellow;
            press_insert_pi.FlatAppearance.BorderColor = Color.Gold;
            press_insert_pi.FlatAppearance.BorderSize = 2;
            press_insert_pi.FlatStyle = FlatStyle.Flat;
            press_insert_pi.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            press_insert_pi.ForeColor = Color.DarkGreen;
            press_insert_pi.Location = new Point(50, 669);
            press_insert_pi.Name = "press_insert_pi";
            press_insert_pi.Size = new Size(143, 38);
            press_insert_pi.TabIndex = 78;
            press_insert_pi.Text = "Add";
            press_insert_pi.UseVisualStyleBackColor = false;
            press_insert_pi.Click += press_insertpi;
            // 
            // press_connect_pi
            // 
            press_connect_pi.BackColor = Color.Yellow;
            press_connect_pi.FlatAppearance.BorderColor = Color.Gold;
            press_connect_pi.FlatAppearance.BorderSize = 2;
            press_connect_pi.FlatStyle = FlatStyle.Flat;
            press_connect_pi.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            press_connect_pi.ForeColor = Color.DarkGreen;
            press_connect_pi.Location = new Point(1287, 558);
            press_connect_pi.Name = "press_connect_pi";
            press_connect_pi.Size = new Size(143, 38);
            press_connect_pi.TabIndex = 79;
            press_connect_pi.Text = "Connect";
            press_connect_pi.UseVisualStyleBackColor = false;
            press_connect_pi.Click += press_connectpi;
            // 
            // press_switch_pi
            // 
            press_switch_pi.BackColor = Color.Yellow;
            press_switch_pi.FlatAppearance.BorderColor = Color.Gold;
            press_switch_pi.FlatAppearance.BorderSize = 2;
            press_switch_pi.FlatStyle = FlatStyle.Flat;
            press_switch_pi.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            press_switch_pi.ForeColor = Color.DarkGreen;
            press_switch_pi.Location = new Point(1138, 558);
            press_switch_pi.Name = "press_switch_pi";
            press_switch_pi.Size = new Size(143, 38);
            press_switch_pi.TabIndex = 80;
            press_switch_pi.Text = "Switch";
            press_switch_pi.UseVisualStyleBackColor = false;
            press_switch_pi.Click += press_switchpi;
            // 
            // press_refresh_pi
            // 
            press_refresh_pi.BackColor = Color.Yellow;
            press_refresh_pi.FlatAppearance.BorderColor = Color.Gold;
            press_refresh_pi.FlatAppearance.BorderSize = 2;
            press_refresh_pi.FlatStyle = FlatStyle.Flat;
            press_refresh_pi.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            press_refresh_pi.ForeColor = Color.DarkGreen;
            press_refresh_pi.Location = new Point(989, 558);
            press_refresh_pi.Name = "press_refresh_pi";
            press_refresh_pi.Size = new Size(143, 38);
            press_refresh_pi.TabIndex = 81;
            press_refresh_pi.Text = "Refresh";
            press_refresh_pi.UseVisualStyleBackColor = false;
            press_refresh_pi.Click += press_refreshpi;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.LawnGreen;
            label6.Location = new Point(201, 191);
            label6.Name = "label6";
            label6.Size = new Size(15, 24);
            label6.TabIndex = 83;
            label6.Text = ":";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.LawnGreen;
            label5.Location = new Point(54, 188);
            label5.Name = "label5";
            label5.Size = new Size(146, 27);
            label5.TabIndex = 110;
            label5.Text = "Product Name";
            // 
            // fill_search_pi
            // 
            fill_search_pi.BackColor = Color.Gainsboro;
            fill_search_pi.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Italic, GraphicsUnit.Point, 0);
            fill_search_pi.Location = new Point(222, 190);
            fill_search_pi.Name = "fill_search_pi";
            fill_search_pi.Size = new Size(252, 29);
            fill_search_pi.TabIndex = 109;
            fill_search_pi.TextChanged += fill_searchpi;
            // 
            // button1
            // 
            button1.BackColor = Color.Yellow;
            button1.FlatAppearance.BorderColor = Color.Gold;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.DarkGreen;
            button1.Location = new Point(840, 558);
            button1.Name = "button1";
            button1.Size = new Size(143, 38);
            button1.TabIndex = 81;
            button1.Text = "View Analytics";
            button1.UseVisualStyleBackColor = false;
            button1.Click += press_viewanalytics_pi;
            // 
            // label_sc1_pi
            // 
            label_sc1_pi.AutoSize = true;
            label_sc1_pi.BackColor = Color.Transparent;
            label_sc1_pi.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_sc1_pi.ForeColor = Color.LawnGreen;
            label_sc1_pi.Location = new Point(594, 571);
            label_sc1_pi.Name = "label_sc1_pi";
            label_sc1_pi.Size = new Size(15, 24);
            label_sc1_pi.TabIndex = 73;
            label_sc1_pi.Text = ":";
            // 
            // fill_batchcode_pi
            // 
            fill_batchcode_pi.BackColor = Color.LightGreen;
            fill_batchcode_pi.BorderStyle = BorderStyle.None;
            fill_batchcode_pi.Location = new Point(615, 572);
            fill_batchcode_pi.Name = "fill_batchcode_pi";
            fill_batchcode_pi.Size = new Size(207, 24);
            fill_batchcode_pi.TabIndex = 74;
            // 
            // label_batchsource_pi
            // 
            label_batchsource_pi.AutoSize = true;
            label_batchsource_pi.BackColor = Color.Transparent;
            label_batchsource_pi.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_batchsource_pi.ForeColor = Color.LawnGreen;
            label_batchsource_pi.Location = new Point(437, 570);
            label_batchsource_pi.Name = "label_batchsource_pi";
            label_batchsource_pi.Size = new Size(138, 27);
            label_batchsource_pi.TabIndex = 75;
            label_batchsource_pi.Text = "Batch Source";
            // 
            // label_sc2_pi
            // 
            label_sc2_pi.AutoSize = true;
            label_sc2_pi.BackColor = Color.Transparent;
            label_sc2_pi.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_sc2_pi.ForeColor = Color.LawnGreen;
            label_sc2_pi.Location = new Point(594, 609);
            label_sc2_pi.Name = "label_sc2_pi";
            label_sc2_pi.Size = new Size(15, 24);
            label_sc2_pi.TabIndex = 73;
            label_sc2_pi.Text = ":";
            // 
            // label_datereceived_pi
            // 
            label_datereceived_pi.AutoSize = true;
            label_datereceived_pi.BackColor = Color.Transparent;
            label_datereceived_pi.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_datereceived_pi.ForeColor = Color.LawnGreen;
            label_datereceived_pi.Location = new Point(437, 607);
            label_datereceived_pi.Name = "label_datereceived_pi";
            label_datereceived_pi.Size = new Size(150, 27);
            label_datereceived_pi.TabIndex = 75;
            label_datereceived_pi.Text = "Date Received";
            // 
            // label_sc3_pi
            // 
            label_sc3_pi.AutoSize = true;
            label_sc3_pi.BackColor = Color.Transparent;
            label_sc3_pi.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_sc3_pi.ForeColor = Color.LawnGreen;
            label_sc3_pi.Location = new Point(594, 640);
            label_sc3_pi.Name = "label_sc3_pi";
            label_sc3_pi.Size = new Size(15, 24);
            label_sc3_pi.TabIndex = 73;
            label_sc3_pi.Text = ":";
            // 
            // fill_germrate_pi
            // 
            fill_germrate_pi.BackColor = Color.LightGreen;
            fill_germrate_pi.BorderStyle = BorderStyle.None;
            fill_germrate_pi.Location = new Point(615, 639);
            fill_germrate_pi.Name = "fill_germrate_pi";
            fill_germrate_pi.Size = new Size(207, 24);
            fill_germrate_pi.TabIndex = 74;
            // 
            // label_germrate_pi
            // 
            label_germrate_pi.AutoSize = true;
            label_germrate_pi.BackColor = Color.Transparent;
            label_germrate_pi.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_germrate_pi.ForeColor = Color.LawnGreen;
            label_germrate_pi.Location = new Point(437, 638);
            label_germrate_pi.Name = "label_germrate_pi";
            label_germrate_pi.Size = new Size(115, 27);
            label_germrate_pi.TabIndex = 75;
            label_germrate_pi.Text = "Germ Rate";
            // 
            // fill_datereceived_pi
            // 
            fill_datereceived_pi.Location = new Point(615, 602);
            fill_datereceived_pi.Name = "fill_datereceived_pi";
            fill_datereceived_pi.Size = new Size(207, 31);
            fill_datereceived_pi.TabIndex = 111;
            // 
            // display_indicator_pi
            // 
            display_indicator_pi.AutoSize = true;
            display_indicator_pi.BackColor = Color.Transparent;
            display_indicator_pi.Font = new Font("Glacial Indifference", 15.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            display_indicator_pi.ForeColor = Color.LawnGreen;
            display_indicator_pi.Location = new Point(1090, 197);
            display_indicator_pi.Name = "display_indicator_pi";
            display_indicator_pi.Size = new Size(0, 38);
            display_indicator_pi.TabIndex = 75;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.LawnGreen;
            label7.Location = new Point(1056, 639);
            label7.Name = "label7";
            label7.Size = new Size(15, 24);
            label7.TabIndex = 73;
            label7.Text = ":";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.LawnGreen;
            label10.Location = new Point(840, 640);
            label10.Name = "label10";
            label10.Size = new Size(209, 27);
            label10.TabIndex = 75;
            label10.Text = "Total Quantity (Sack)";
            // 
            // display_sack_gg
            // 
            display_sack_gg.AutoSize = true;
            display_sack_gg.BackColor = Color.Transparent;
            display_sack_gg.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold | FontStyle.Italic);
            display_sack_gg.ForeColor = Color.Gold;
            display_sack_gg.Location = new Point(1077, 640);
            display_sack_gg.Name = "display_sack_gg";
            display_sack_gg.Size = new Size(33, 27);
            display_sack_gg.TabIndex = 75;
            display_sack_gg.Text = "---";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.LawnGreen;
            label12.Location = new Point(1056, 605);
            label12.Name = "label12";
            label12.Size = new Size(15, 24);
            label12.TabIndex = 73;
            label12.Text = ":";
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.LawnGreen;
            label13.Location = new Point(840, 606);
            label13.Name = "label13";
            label13.Size = new Size(186, 27);
            label13.TabIndex = 75;
            label13.Text = "Total Quantity (Kg)";
            // 
            // display_kg_gg
            // 
            display_kg_gg.AutoSize = true;
            display_kg_gg.BackColor = Color.Transparent;
            display_kg_gg.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold | FontStyle.Italic);
            display_kg_gg.ForeColor = Color.Gold;
            display_kg_gg.Location = new Point(1077, 606);
            display_kg_gg.Name = "display_kg_gg";
            display_kg_gg.Size = new Size(33, 27);
            display_kg_gg.TabIndex = 75;
            display_kg_gg.Text = "---";
            // 
            // productInventory
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1478, 775);
            Controls.Add(fill_datereceived_pi);
            Controls.Add(label5);
            Controls.Add(fill_search_pi);
            Controls.Add(label6);
            Controls.Add(press_connect_pi);
            Controls.Add(press_switch_pi);
            Controls.Add(button1);
            Controls.Add(press_refresh_pi);
            Controls.Add(press_update_pi);
            Controls.Add(press_delete_pi);
            Controls.Add(press_insert_pi);
            Controls.Add(label4);
            Controls.Add(fill_quantity_pi);
            Controls.Add(label2);
            Controls.Add(fill_productid_pi);
            Controls.Add(label3);
            Controls.Add(display_kg_gg);
            Controls.Add(display_sack_gg);
            Controls.Add(label13);
            Controls.Add(label10);
            Controls.Add(label_germrate_pi);
            Controls.Add(label_datereceived_pi);
            Controls.Add(display_indicator_pi);
            Controls.Add(label_batchsource_pi);
            Controls.Add(label12);
            Controls.Add(fill_germrate_pi);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(label_sc3_pi);
            Controls.Add(fill_batchcode_pi);
            Controls.Add(label_sc2_pi);
            Controls.Add(label1);
            Controls.Add(label_sc1_pi);
            Controls.Add(fill_productname_pi);
            Controls.Add(label9);
            Controls.Add(button6);
            Controls.Add(panel1);
            Name = "productInventory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Product Inventory";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Product_Inventory_Grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button6;
        private Label label8;
        private TextBox fill_productname_pi;
        private Label label9;
        private Label label1;
        private TextBox fill_productid_pi;
        private Label label2;
        private Label label3;
        private TextBox fill_quantity_pi;
        private Label label4;
        private Button press_update_pi;
        private Button press_delete_pi;
        private Button press_insert_pi;
        private Button press_connect_pi;
        private Button press_switch_pi;
        private Button press_refresh_pi;
        private DataGridView Product_Inventory_Grid;
        private Label label6;
        private Label label5;
        private TextBox fill_search_pi;
        private Button button1;
        private Label label_sc1_pi;
        private TextBox fill_batchcode_pi;
        private Label label_batchsource_pi;
        private Label label_sc2_pi;
        private Label label_datereceived_pi;
        private Label label_sc3_pi;
        private TextBox fill_germrate_pi;
        private Label label_germrate_pi;
        private DateTimePicker fill_datereceived_pi;
        private Label display_indicator_pi;
        private Label label7;
        private Label label10;
        private Label display_sack_gg;
        private Label label12;
        private Label label13;
        private Label display_kg_gg;
    }
}