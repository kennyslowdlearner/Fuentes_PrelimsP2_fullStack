namespace Fuentes_PrelimsP2
{
    partial class User_VarietalRegistry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_VarietalRegistry));
            panel1 = new Panel();
            Varietal_Registry_Grid = new DataGridView();
            label1 = new Label();
            fill_mp_vr = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            button6 = new Button();
            button9 = new Button();
            button7 = new Button();
            button4 = new Button();
            button8 = new Button();
            label9 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            fill_search_vr = new TextBox();
            label8 = new Label();
            Refresh = new ContextMenuStrip(components);
            toolStripComboBox1 = new ToolStripComboBox();
            fill_ey_vr = new TextBox();
            label10 = new Label();
            label11 = new Label();
            fill_r_vr = new ComboBox();
            fill_gt_vr = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Varietal_Registry_Grid).BeginInit();
            Refresh.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(Varietal_Registry_Grid);
            panel1.Location = new Point(124, 207);
            panel1.Name = "panel1";
            panel1.Size = new Size(1297, 285);
            panel1.TabIndex = 0;
            // 
            // Varietal_Registry_Grid
            // 
            Varietal_Registry_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Varietal_Registry_Grid.Location = new Point(3, 3);
            Varietal_Registry_Grid.Name = "Varietal_Registry_Grid";
            Varietal_Registry_Grid.RowHeadersWidth = 62;
            Varietal_Registry_Grid.Size = new Size(1291, 279);
            Varietal_Registry_Grid.TabIndex = 0;
            Varietal_Registry_Grid.CellClick += datagridCellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LawnGreen;
            label1.Location = new Point(149, 521);
            label1.Name = "label1";
            label1.Size = new Size(171, 27);
            label1.TabIndex = 50;
            label1.Text = "Maturity Period";
            // 
            // fill_mp_vr
            // 
            fill_mp_vr.BackColor = Color.LightGreen;
            fill_mp_vr.BorderStyle = BorderStyle.None;
            fill_mp_vr.Location = new Point(336, 524);
            fill_mp_vr.Name = "fill_mp_vr";
            fill_mp_vr.Size = new Size(259, 24);
            fill_mp_vr.TabIndex = 49;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.LawnGreen;
            label2.Location = new Point(149, 560);
            label2.Name = "label2";
            label2.Size = new Size(114, 27);
            label2.TabIndex = 50;
            label2.Text = "Exp. Yield";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.LawnGreen;
            label3.Location = new Point(149, 597);
            label3.Name = "label3";
            label3.Size = new Size(124, 27);
            label3.TabIndex = 50;
            label3.Text = "Resistance";
            // 
            // button1
            // 
            button1.BackColor = Color.Yellow;
            button1.FlatAppearance.BorderColor = Color.Gold;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.DarkGreen;
            button1.Location = new Point(601, 522);
            button1.Name = "button1";
            button1.Size = new Size(154, 34);
            button1.TabIndex = 51;
            button1.Text = "Update";
            button1.UseVisualStyleBackColor = false;
            button1.Click += press_updatevr;
            // 
            // button2
            // 
            button2.BackColor = Color.Yellow;
            button2.FlatAppearance.BorderColor = Color.Gold;
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.DarkGreen;
            button2.Location = new Point(601, 562);
            button2.Name = "button2";
            button2.Size = new Size(154, 34);
            button2.TabIndex = 51;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = false;
            button2.Click += press_deletevr;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(419, 715);
            button6.Name = "button6";
            button6.Size = new Size(120, 41);
            button6.TabIndex = 52;
            button6.UseVisualStyleBackColor = false;
            button6.Click += backButton;
            // 
            // button9
            // 
            button9.BackColor = Color.Transparent;
            button9.BackgroundImage = (Image)resources.GetObject("button9.BackgroundImage");
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button9.Location = new Point(1119, 540);
            button9.Name = "button9";
            button9.Size = new Size(254, 99);
            button9.TabIndex = 56;
            button9.UseVisualStyleBackColor = false;
            button9.Click += shortcut_SoilEvaluator;
            // 
            // button7
            // 
            button7.BackColor = Color.Transparent;
            button7.BackgroundImage = (Image)resources.GetObject("button7.BackgroundImage");
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.Location = new Point(1119, 657);
            button7.Name = "button7";
            button7.Size = new Size(254, 99);
            button7.TabIndex = 57;
            button7.UseVisualStyleBackColor = false;
            button7.Click += shortcut_ActivityLog;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(849, 657);
            button4.Name = "button4";
            button4.Size = new Size(254, 99);
            button4.TabIndex = 58;
            button4.UseVisualStyleBackColor = false;
            button4.Click += shortcut_WeatherForecasting;
            // 
            // button8
            // 
            button8.BackColor = Color.Transparent;
            button8.BackgroundImage = (Image)resources.GetObject("button8.BackgroundImage");
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.Location = new Point(849, 540);
            button8.Name = "button8";
            button8.Size = new Size(254, 99);
            button8.TabIndex = 59;
            button8.UseVisualStyleBackColor = false;
            button8.Click += shortcut_RiceYieldandEstimation;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.GreenYellow;
            label9.Location = new Point(849, 510);
            label9.Name = "label9";
            label9.Size = new Size(164, 27);
            label9.TabIndex = 55;
            label9.Text = "Other Options:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.LawnGreen;
            label4.Location = new Point(311, 521);
            label4.Name = "label4";
            label4.Size = new Size(19, 27);
            label4.TabIndex = 50;
            label4.Text = ":";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.LawnGreen;
            label5.Location = new Point(311, 562);
            label5.Name = "label5";
            label5.Size = new Size(19, 27);
            label5.TabIndex = 50;
            label5.Text = ":";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.LawnGreen;
            label6.Location = new Point(311, 600);
            label6.Name = "label6";
            label6.Size = new Size(19, 27);
            label6.TabIndex = 50;
            label6.Text = ":";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.LawnGreen;
            label7.Location = new Point(130, 170);
            label7.Name = "label7";
            label7.Size = new Size(146, 27);
            label7.TabIndex = 113;
            label7.Text = "Product Name";
            // 
            // fill_search_vr
            // 
            fill_search_vr.BackColor = Color.Gainsboro;
            fill_search_vr.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Italic, GraphicsUnit.Point, 0);
            fill_search_vr.Location = new Point(298, 172);
            fill_search_vr.Name = "fill_search_vr";
            fill_search_vr.Size = new Size(252, 29);
            fill_search_vr.TabIndex = 112;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.LawnGreen;
            label8.Location = new Point(277, 173);
            label8.Name = "label8";
            label8.Size = new Size(15, 24);
            label8.TabIndex = 111;
            label8.Text = ":";
            // 
            // Refresh
            // 
            Refresh.ImageScalingSize = new Size(24, 24);
            Refresh.Items.AddRange(new ToolStripItem[] { toolStripComboBox1 });
            Refresh.Name = "Refresh";
            Refresh.Size = new Size(182, 43);
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 33);
            toolStripComboBox1.Click += refresh;
            // 
            // fill_ey_vr
            // 
            fill_ey_vr.BackColor = Color.LightGreen;
            fill_ey_vr.BorderStyle = BorderStyle.None;
            fill_ey_vr.Location = new Point(336, 562);
            fill_ey_vr.Name = "fill_ey_vr";
            fill_ey_vr.Size = new Size(259, 24);
            fill_ey_vr.TabIndex = 49;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.LawnGreen;
            label10.Location = new Point(149, 640);
            label10.Name = "label10";
            label10.Size = new Size(123, 27);
            label10.TabIndex = 50;
            label10.Text = "Grain Type";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.LawnGreen;
            label11.Location = new Point(311, 643);
            label11.Name = "label11";
            label11.Size = new Size(19, 27);
            label11.TabIndex = 50;
            label11.Text = ":";
            // 
            // fill_r_vr
            // 
            fill_r_vr.FormattingEnabled = true;
            fill_r_vr.Items.AddRange(new object[] { "Host Resistance", "Inbuilt Defense", "Pest Shielding" });
            fill_r_vr.Location = new Point(336, 598);
            fill_r_vr.Name = "fill_r_vr";
            fill_r_vr.Size = new Size(257, 33);
            fill_r_vr.TabIndex = 114;
            // 
            // fill_gt_vr
            // 
            fill_gt_vr.FormattingEnabled = true;
            fill_gt_vr.Items.AddRange(new object[] { "Long Grain", "Medium Grain", "Short Grain" });
            fill_gt_vr.Location = new Point(336, 641);
            fill_gt_vr.Name = "fill_gt_vr";
            fill_gt_vr.Size = new Size(257, 33);
            fill_gt_vr.TabIndex = 114;
            // 
            // User_VarietalRegistry
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1500, 775);
            Controls.Add(fill_gt_vr);
            Controls.Add(fill_r_vr);
            Controls.Add(label7);
            Controls.Add(fill_search_vr);
            Controls.Add(label8);
            Controls.Add(button9);
            Controls.Add(button7);
            Controls.Add(button4);
            Controls.Add(button8);
            Controls.Add(label9);
            Controls.Add(button6);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label11);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label10);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(fill_ey_vr);
            Controls.Add(fill_mp_vr);
            Controls.Add(panel1);
            ForeColor = Color.LawnGreen;
            Name = "User_VarietalRegistry";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Varietal Registry";
            FormClosed += endoperation;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Varietal_Registry_Grid).EndInit();
            Refresh.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox fill_mp_vr;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
        private Button button6;
        private Button button9;
        private Button button7;
        private Button button4;
        private Button button8;
        private Label label9;
        private DataGridView Varietal_Registry_Grid;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox fill_search_vr;
        private Label label8;
        private ContextMenuStrip Refresh;
        private ToolStripComboBox toolStripComboBox1;
        private TextBox fill_ey_vr;
        private Label label10;
        private Label label11;
        private ComboBox fill_r_vr;
        private ComboBox fill_gt_vr;
    }
}