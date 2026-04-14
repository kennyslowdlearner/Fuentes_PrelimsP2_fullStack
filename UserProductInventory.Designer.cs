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
            button5 = new Button();
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
            press_load_pi = new Button();
            press_refresh_pi = new Button();
            label6 = new Label();
            label5 = new Label();
            fill_search_pi = new TextBox();
            button1 = new Button();
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
            panel1.Paint += panel1_Paint;
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
            button6.Location = new Point(605, 712);
            button6.Name = "button6";
            button6.Size = new Size(120, 41);
            button6.TabIndex = 54;
            button6.UseVisualStyleBackColor = false;
            button6.Click += backButton;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(737, 712);
            button5.Name = "button5";
            button5.Size = new Size(120, 41);
            button5.TabIndex = 55;
            button5.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.LawnGreen;
            label8.Location = new Point(63, 566);
            label8.Name = "label8";
            label8.Size = new Size(146, 27);
            label8.TabIndex = 75;
            label8.Text = "Product Name";
            label8.Click += label8_Click;
            // 
            // fill_productname_pi
            // 
            fill_productname_pi.BackColor = Color.LightGreen;
            fill_productname_pi.BorderStyle = BorderStyle.None;
            fill_productname_pi.Location = new Point(266, 567);
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
            label9.Location = new Point(245, 564);
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
            label1.Location = new Point(245, 591);
            label1.Name = "label1";
            label1.Size = new Size(15, 24);
            label1.TabIndex = 73;
            label1.Text = ":";
            // 
            // fill_productid_pi
            // 
            fill_productid_pi.BackColor = Color.LightGreen;
            fill_productid_pi.BorderStyle = BorderStyle.None;
            fill_productid_pi.Location = new Point(266, 594);
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
            label2.Location = new Point(63, 593);
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
            label3.Location = new Point(245, 618);
            label3.Name = "label3";
            label3.Size = new Size(15, 24);
            label3.TabIndex = 73;
            label3.Text = ":";
            // 
            // fill_quantity_pi
            // 
            fill_quantity_pi.BackColor = Color.LightGreen;
            fill_quantity_pi.BorderStyle = BorderStyle.None;
            fill_quantity_pi.Location = new Point(266, 621);
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
            label4.Location = new Point(63, 620);
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
            press_update_pi.Location = new Point(348, 669);
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
            press_delete_pi.Location = new Point(199, 669);
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
            press_insert_pi.Text = "Insert";
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
            // press_load_pi
            // 
            press_load_pi.BackColor = Color.Yellow;
            press_load_pi.FlatAppearance.BorderColor = Color.Gold;
            press_load_pi.FlatAppearance.BorderSize = 2;
            press_load_pi.FlatStyle = FlatStyle.Flat;
            press_load_pi.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            press_load_pi.ForeColor = Color.DarkGreen;
            press_load_pi.Location = new Point(1138, 558);
            press_load_pi.Name = "press_load_pi";
            press_load_pi.Size = new Size(143, 38);
            press_load_pi.TabIndex = 80;
            press_load_pi.Text = "Load";
            press_load_pi.UseVisualStyleBackColor = false;
            press_load_pi.Click += press_loadpi;
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
            fill_search_pi.Text = "Search product name or id";
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
            // productInventory
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1478, 729);
            Controls.Add(label5);
            Controls.Add(fill_search_pi);
            Controls.Add(label6);
            Controls.Add(press_connect_pi);
            Controls.Add(press_load_pi);
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
            Controls.Add(label8);
            Controls.Add(label1);
            Controls.Add(fill_productname_pi);
            Controls.Add(label9);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(panel1);
            Name = "productInventory";
            Text = "Pananom : Product Inventory";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Product_Inventory_Grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button6;
        private Button button5;
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
        private Button press_load_pi;
        private Button press_refresh_pi;
        private DataGridView Product_Inventory_Grid;
        private Label label6;
        private Label label5;
        private TextBox fill_search_pi;
        private Button button1;
    }
}