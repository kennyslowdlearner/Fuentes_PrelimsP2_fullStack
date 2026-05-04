namespace Fuentes_PrelimsP2
{
    partial class farmgateUSER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(farmgateUSER));
            Farmgate_Prices_Grid = new DataGridView();
            label5 = new Label();
            label6 = new Label();
            button7 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label4 = new Label();
            label2 = new Label();
            label3 = new Label();
            label8 = new Label();
            label1 = new Label();
            fill_productname_fgp = new TextBox();
            label9 = new Label();
            button6 = new Button();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            fill_quantity_fgp = new TextBox();
            fill_search_fgp = new TextBox();
            panel1 = new Panel();
            fill_price_fgp = new TextBox();
            label7 = new Label();
            label10 = new Label();
            label17 = new Label();
            fill_productid_fgp = new ComboBox();
            display_kg_gg = new Label();
            display_sack_gg = new Label();
            label13 = new Label();
            label11 = new Label();
            label12 = new Label();
            label14 = new Label();
            ((System.ComponentModel.ISupportInitialize)Farmgate_Prices_Grid).BeginInit();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Farmgate_Prices_Grid
            // 
            Farmgate_Prices_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Farmgate_Prices_Grid.Location = new Point(3, 3);
            Farmgate_Prices_Grid.Name = "Farmgate_Prices_Grid";
            Farmgate_Prices_Grid.RowHeadersWidth = 62;
            Farmgate_Prices_Grid.Size = new Size(1368, 308);
            Farmgate_Prices_Grid.TabIndex = 0;
            Farmgate_Prices_Grid.CellClick += display_prices_fgp_CellContentClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.LawnGreen;
            label5.Location = new Point(64, 212);
            label5.Name = "label5";
            label5.Size = new Size(146, 27);
            label5.TabIndex = 107;
            label5.Text = "Product Name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.LawnGreen;
            label6.Location = new Point(211, 220);
            label6.Name = "label6";
            label6.Size = new Size(15, 24);
            label6.TabIndex = 106;
            label6.Text = ":";
            // 
            // button7
            // 
            button7.BackColor = Color.Yellow;
            button7.FlatAppearance.BorderColor = Color.Gold;
            button7.FlatAppearance.BorderSize = 2;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.DarkGreen;
            button7.Location = new Point(1302, 578);
            button7.Name = "button7";
            button7.Size = new Size(143, 38);
            button7.TabIndex = 103;
            button7.Text = "Load";
            button7.UseVisualStyleBackColor = false;
            button7.Click += press_loadfgp;
            // 
            // button4
            // 
            button4.BackColor = Color.Yellow;
            button4.FlatAppearance.BorderColor = Color.Gold;
            button4.FlatAppearance.BorderSize = 2;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.DarkGreen;
            button4.Location = new Point(1153, 578);
            button4.Name = "button4";
            button4.Size = new Size(143, 38);
            button4.TabIndex = 104;
            button4.Text = "Refresh";
            button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Yellow;
            button3.FlatAppearance.BorderColor = Color.Gold;
            button3.FlatAppearance.BorderSize = 2;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.DarkGreen;
            button3.Location = new Point(211, 722);
            button3.Name = "button3";
            button3.Size = new Size(143, 38);
            button3.TabIndex = 99;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = false;
            button3.Click += press_update;
            // 
            // button2
            // 
            button2.BackColor = Color.Yellow;
            button2.FlatAppearance.BorderColor = Color.Gold;
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.DarkGreen;
            button2.Location = new Point(360, 722);
            button2.Name = "button2";
            button2.Size = new Size(143, 38);
            button2.TabIndex = 100;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = false;
            button2.Click += press_delete;
            // 
            // button1
            // 
            button1.BackColor = Color.Yellow;
            button1.FlatAppearance.BorderColor = Color.Gold;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.DarkGreen;
            button1.Location = new Point(62, 722);
            button1.Name = "button1";
            button1.Size = new Size(143, 38);
            button1.TabIndex = 101;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = false;
            button1.Click += press_insert;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.LawnGreen;
            label4.Location = new Point(80, 654);
            label4.Name = "label4";
            label4.Size = new Size(135, 27);
            label4.TabIndex = 96;
            label4.Text = "Quantity (Kg)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LawnGreen;
            label2.Location = new Point(80, 613);
            label2.Name = "label2";
            label2.Size = new Size(110, 27);
            label2.TabIndex = 98;
            label2.Text = "Product ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.LawnGreen;
            label3.Location = new Point(262, 652);
            label3.Name = "label3";
            label3.Size = new Size(15, 24);
            label3.TabIndex = 92;
            label3.Text = ":";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.LawnGreen;
            label8.Location = new Point(80, 586);
            label8.Name = "label8";
            label8.Size = new Size(146, 27);
            label8.TabIndex = 97;
            label8.Text = "Product Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LawnGreen;
            label1.Location = new Point(262, 611);
            label1.Name = "label1";
            label1.Size = new Size(15, 24);
            label1.TabIndex = 91;
            label1.Text = ":";
            // 
            // fill_productname_fgp
            // 
            fill_productname_fgp.BackColor = Color.LightGreen;
            fill_productname_fgp.BorderStyle = BorderStyle.None;
            fill_productname_fgp.Location = new Point(283, 587);
            fill_productname_fgp.Name = "fill_productname_fgp";
            fill_productname_fgp.Size = new Size(207, 24);
            fill_productname_fgp.TabIndex = 94;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.LawnGreen;
            label9.Location = new Point(262, 584);
            label9.Name = "label9";
            label9.Size = new Size(15, 24);
            label9.TabIndex = 90;
            label9.Text = ":";
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(761, 732);
            button6.Name = "button6";
            button6.Size = new Size(120, 41);
            button6.TabIndex = 88;
            button6.UseVisualStyleBackColor = false;
            button6.Click += back;
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Size = new Size(142, 32);
            refreshToolStripMenuItem.Text = "Refresh";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { refreshToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(143, 36);
            // 
            // fill_quantity_fgp
            // 
            fill_quantity_fgp.BackColor = Color.LightGreen;
            fill_quantity_fgp.BorderStyle = BorderStyle.None;
            fill_quantity_fgp.Location = new Point(283, 655);
            fill_quantity_fgp.Name = "fill_quantity_fgp";
            fill_quantity_fgp.Size = new Size(207, 24);
            fill_quantity_fgp.TabIndex = 93;
            // 
            // fill_search_fgp
            // 
            fill_search_fgp.BackColor = Color.Gainsboro;
            fill_search_fgp.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Italic, GraphicsUnit.Point, 0);
            fill_search_fgp.Location = new Point(232, 214);
            fill_search_fgp.Name = "fill_search_fgp";
            fill_search_fgp.Size = new Size(252, 29);
            fill_search_fgp.TabIndex = 87;
            fill_search_fgp.TextChanged += press_Searchfgp;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(Farmgate_Prices_Grid);
            panel1.Font = new Font("Glacial Indifference", 10F);
            panel1.Location = new Point(71, 255);
            panel1.Name = "panel1";
            panel1.Size = new Size(1374, 314);
            panel1.TabIndex = 85;
            // 
            // fill_price_fgp
            // 
            fill_price_fgp.BackColor = Color.LightGreen;
            fill_price_fgp.BorderStyle = BorderStyle.None;
            fill_price_fgp.Location = new Point(308, 685);
            fill_price_fgp.Name = "fill_price_fgp";
            fill_price_fgp.Size = new Size(182, 24);
            fill_price_fgp.TabIndex = 93;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.LawnGreen;
            label7.Location = new Point(262, 682);
            label7.Name = "label7";
            label7.Size = new Size(15, 24);
            label7.TabIndex = 92;
            label7.Text = ":";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.LawnGreen;
            label10.Location = new Point(80, 684);
            label10.Name = "label10";
            label10.Size = new Size(126, 27);
            label10.TabIndex = 96;
            label10.Text = "Price per Kg";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.Transparent;
            label17.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.LawnGreen;
            label17.Location = new Point(283, 684);
            label17.Name = "label17";
            label17.Size = new Size(28, 27);
            label17.TabIndex = 108;
            label17.Text = "₱";
            // 
            // fill_productid_fgp
            // 
            fill_productid_fgp.FormattingEnabled = true;
            fill_productid_fgp.Location = new Point(283, 617);
            fill_productid_fgp.Name = "fill_productid_fgp";
            fill_productid_fgp.Size = new Size(207, 33);
            fill_productid_fgp.TabIndex = 109;
            fill_productid_fgp.SelectedIndexChanged += fill_productid_fgp_SelectedIndexChanged;
            // 
            // display_kg_gg
            // 
            display_kg_gg.AutoSize = true;
            display_kg_gg.BackColor = Color.Transparent;
            display_kg_gg.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold | FontStyle.Italic);
            display_kg_gg.ForeColor = Color.Gold;
            display_kg_gg.Location = new Point(788, 589);
            display_kg_gg.Name = "display_kg_gg";
            display_kg_gg.Size = new Size(122, 27);
            display_kg_gg.TabIndex = 112;
            display_kg_gg.Text = "Germ Rate";
            // 
            // display_sack_gg
            // 
            display_sack_gg.AutoSize = true;
            display_sack_gg.BackColor = Color.Transparent;
            display_sack_gg.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold | FontStyle.Italic);
            display_sack_gg.ForeColor = Color.Gold;
            display_sack_gg.Location = new Point(788, 623);
            display_sack_gg.Name = "display_sack_gg";
            display_sack_gg.Size = new Size(122, 27);
            display_sack_gg.TabIndex = 113;
            display_sack_gg.Text = "Germ Rate";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.LawnGreen;
            label13.Location = new Point(551, 589);
            label13.Name = "label13";
            label13.Size = new Size(186, 27);
            label13.TabIndex = 114;
            label13.Text = "Total Quantity (Kg)";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.LawnGreen;
            label11.Location = new Point(551, 623);
            label11.Name = "label11";
            label11.Size = new Size(209, 27);
            label11.TabIndex = 115;
            label11.Text = "Total Quantity (Sack)";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.LawnGreen;
            label12.Location = new Point(767, 588);
            label12.Name = "label12";
            label12.Size = new Size(15, 24);
            label12.TabIndex = 110;
            label12.Text = ":";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.LawnGreen;
            label14.Location = new Point(767, 622);
            label14.Name = "label14";
            label14.Size = new Size(15, 24);
            label14.TabIndex = 111;
            label14.Text = ":";
            // 
            // farmgateUSER
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
            Controls.Add(fill_productid_fgp);
            Controls.Add(label17);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(button7);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label10);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label7);
            Controls.Add(label3);
            Controls.Add(label8);
            Controls.Add(label1);
            Controls.Add(fill_productname_fgp);
            Controls.Add(label9);
            Controls.Add(button6);
            Controls.Add(fill_price_fgp);
            Controls.Add(fill_quantity_fgp);
            Controls.Add(fill_search_fgp);
            Controls.Add(panel1);
            Name = "farmgateUSER";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Farmgate Price";
            FormClosed += farmgateUSER_FormClosed;
            ((System.ComponentModel.ISupportInitialize)Farmgate_Prices_Grid).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Farmgate_Prices_Grid;
        private Label label5;
        private Label label6;
        private Button button7;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label4;
        private Label label2;
        private Label label3;
        private Label label8;
        private Label label1;
        private TextBox fill_productname_fgp;
        private Label label9;
        private Button button6;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox fill_quantity_fgp;
        private TextBox fill_search_fgp;
        private Panel panel1;
        private TextBox fill_price_fgp;
        private Label label7;
        private Label label10;
        private Label label17;
        private ComboBox fill_productid_fgp;
        private Label display_kg_gg;
        private Label display_sack_gg;
        private Label label13;
        private Label label11;
        private Label label12;
        private Label label14;
    }
}