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
            searchBoxPI = new TextBox();
            searchbuttonPI = new Button();
            button6 = new Button();
            button5 = new Button();
            label8 = new Label();
            textBox2 = new TextBox();
            label9 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            button8 = new Button();
            button7 = new Button();
            button4 = new Button();
            label5 = new Label();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(dataGridView1);
            panel1.Font = new Font("Glacial Indifference", 10F);
            panel1.Location = new Point(54, 235);
            panel1.Name = "panel1";
            panel1.Size = new Size(1374, 314);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // searchBoxPI
            // 
            searchBoxPI.BackColor = Color.Gainsboro;
            searchBoxPI.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Italic, GraphicsUnit.Point, 0);
            searchBoxPI.Location = new Point(215, 199);
            searchBoxPI.Name = "searchBoxPI";
            searchBoxPI.Size = new Size(252, 29);
            searchBoxPI.TabIndex = 5;
            searchBoxPI.Text = "Search product name or id";
            searchBoxPI.TextChanged += searchBoxPI_TextChanged;
            // 
            // searchbuttonPI
            // 
            searchbuttonPI.BackColor = Color.LightGreen;
            searchbuttonPI.FlatStyle = FlatStyle.Flat;
            searchbuttonPI.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchbuttonPI.ForeColor = Color.DarkOliveGreen;
            searchbuttonPI.Location = new Point(474, 196);
            searchbuttonPI.Name = "searchbuttonPI";
            searchbuttonPI.Size = new Size(98, 34);
            searchbuttonPI.TabIndex = 4;
            searchbuttonPI.Text = "Search";
            searchbuttonPI.UseVisualStyleBackColor = false;
            searchbuttonPI.Click += searchbuttonPI_Click;
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
            // textBox2
            // 
            textBox2.BackColor = Color.LightGreen;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Location = new Point(266, 567);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(207, 24);
            textBox2.TabIndex = 74;
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
            // textBox1
            // 
            textBox1.BackColor = Color.LightGreen;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(266, 594);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(207, 24);
            textBox1.TabIndex = 74;
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
            // textBox3
            // 
            textBox3.BackColor = Color.LightGreen;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Location = new Point(266, 621);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(207, 24);
            textBox3.TabIndex = 74;
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
            // button3
            // 
            button3.BackColor = Color.Yellow;
            button3.FlatAppearance.BorderColor = Color.Gold;
            button3.FlatAppearance.BorderSize = 2;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.DarkGreen;
            button3.Location = new Point(348, 669);
            button3.Name = "button3";
            button3.Size = new Size(143, 38);
            button3.TabIndex = 76;
            button3.Text = "Update";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Yellow;
            button2.FlatAppearance.BorderColor = Color.Gold;
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.DarkGreen;
            button2.Location = new Point(199, 669);
            button2.Name = "button2";
            button2.Size = new Size(143, 38);
            button2.TabIndex = 77;
            button2.Text = "Delete";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Yellow;
            button1.FlatAppearance.BorderColor = Color.Gold;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.DarkGreen;
            button1.Location = new Point(50, 669);
            button1.Name = "button1";
            button1.Size = new Size(143, 38);
            button1.TabIndex = 78;
            button1.Text = "Insert";
            button1.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            button8.BackColor = Color.Yellow;
            button8.FlatAppearance.BorderColor = Color.Gold;
            button8.FlatAppearance.BorderSize = 2;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.DarkGreen;
            button8.Location = new Point(1287, 558);
            button8.Name = "button8";
            button8.Size = new Size(143, 38);
            button8.TabIndex = 79;
            button8.Text = "Connect";
            button8.UseVisualStyleBackColor = false;
            // 
            // button7
            // 
            button7.BackColor = Color.Yellow;
            button7.FlatAppearance.BorderColor = Color.Gold;
            button7.FlatAppearance.BorderSize = 2;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button7.ForeColor = Color.DarkGreen;
            button7.Location = new Point(1138, 558);
            button7.Name = "button7";
            button7.Size = new Size(143, 38);
            button7.TabIndex = 80;
            button7.Text = "Load";
            button7.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Yellow;
            button4.FlatAppearance.BorderColor = Color.Gold;
            button4.FlatAppearance.BorderSize = 2;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.DarkGreen;
            button4.Location = new Point(989, 558);
            button4.Name = "button4";
            button4.Size = new Size(143, 38);
            button4.TabIndex = 81;
            button4.Text = "Refresh";
            button4.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.LawnGreen;
            label5.Location = new Point(47, 197);
            label5.Name = "label5";
            label5.Size = new Size(146, 27);
            label5.TabIndex = 84;
            label5.Text = "Product Name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.LawnGreen;
            label6.Location = new Point(194, 200);
            label6.Name = "label6";
            label6.Size = new Size(15, 24);
            label6.TabIndex = 83;
            label6.Text = ":";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1368, 308);
            dataGridView1.TabIndex = 0;
            // 
            // productInventory
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1500, 785);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label8);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(label9);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(searchBoxPI);
            Controls.Add(searchbuttonPI);
            Controls.Add(panel1);
            Name = "productInventory";
            Text = "Pananom : Product Inventory";
            FormClosed += productInventory_FormClosed;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox searchBoxPI;
        private Button searchbuttonPI;
        private Button button6;
        private Button button5;
        private Label label8;
        private TextBox textBox2;
        private Label label9;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private Button button3;
        private Button button2;
        private Button button1;
        private Button button8;
        private Button button7;
        private Button button4;
        private DataGridView dataGridView1;
        private Label label5;
        private Label label6;
    }
}