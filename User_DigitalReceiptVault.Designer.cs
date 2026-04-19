namespace Fuentes_PrelimsP2
{
    partial class User_DigitalReceiptVault
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_DigitalReceiptVault));
            panel1 = new Panel();
            printPreviewControl1 = new PrintPreviewControl();
            dataGridView1 = new DataGridView();
            button8 = new Button();
            label8 = new Label();
            button6 = new Button();
            button5 = new Button();
            label1 = new Label();
            button1 = new Button();
            button4 = new Button();
            label5 = new Label();
            searchBoxPI = new TextBox();
            searchbuttonPI = new Button();
            label6 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(printPreviewControl1);
            panel1.Location = new Point(77, 192);
            panel1.Name = "panel1";
            panel1.Size = new Size(780, 566);
            panel1.TabIndex = 0;
            // 
            // printPreviewControl1
            // 
            printPreviewControl1.Location = new Point(3, 3);
            printPreviewControl1.Name = "printPreviewControl1";
            printPreviewControl1.Size = new Size(774, 584);
            printPreviewControl1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(874, 168);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(550, 253);
            dataGridView1.TabIndex = 1;
            // 
            // button8
            // 
            button8.BackColor = Color.Transparent;
            button8.BackgroundImage = (Image)resources.GetObject("button8.BackgroundImage");
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.Location = new Point(1006, 490);
            button8.Name = "button8";
            button8.Size = new Size(418, 64);
            button8.TabIndex = 37;
            button8.UseVisualStyleBackColor = false;
            button8.Click += shortcut_Transactions;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.GreenYellow;
            label8.Location = new Point(1272, 460);
            label8.Name = "label8";
            label8.Size = new Size(164, 27);
            label8.TabIndex = 36;
            label8.Text = "Other Options:";
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(1164, 732);
            button6.Name = "button6";
            button6.Size = new Size(120, 41);
            button6.TabIndex = 40;
            button6.UseVisualStyleBackColor = false;
            button6.Click += backbutton;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(1301, 732);
            button5.Name = "button5";
            button5.Size = new Size(120, 41);
            button5.TabIndex = 41;
            button5.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Glacial Indifference", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.GreenYellow;
            label1.Location = new Point(874, 138);
            label1.Name = "label1";
            label1.Size = new Size(189, 29);
            label1.TabIndex = 36;
            label1.Text = "Existing Receipt";
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(1006, 560);
            button1.Name = "button1";
            button1.Size = new Size(418, 64);
            button1.TabIndex = 37;
            button1.UseVisualStyleBackColor = false;
            button1.Click += shortcut_CostOfProduction;
            // 
            // button4
            // 
            button4.BackColor = Color.Transparent;
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.Location = new Point(1006, 630);
            button4.Name = "button4";
            button4.Size = new Size(418, 64);
            button4.TabIndex = 37;
            button4.UseVisualStyleBackColor = false;
            button4.Click += shortcut_MarketForecasting;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.LawnGreen;
            label5.Location = new Point(74, 139);
            label5.Name = "label5";
            label5.Size = new Size(157, 27);
            label5.TabIndex = 114;
            label5.Text = "Product Name";
            // 
            // searchBoxPI
            // 
            searchBoxPI.BackColor = Color.Gainsboro;
            searchBoxPI.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Italic, GraphicsUnit.Point, 0);
            searchBoxPI.Location = new Point(242, 141);
            searchBoxPI.Name = "searchBoxPI";
            searchBoxPI.Size = new Size(252, 29);
            searchBoxPI.TabIndex = 113;
            searchBoxPI.Text = "Search product name or id";
            // 
            // searchbuttonPI
            // 
            searchbuttonPI.BackColor = Color.Transparent;
            searchbuttonPI.BackgroundImage = (Image)resources.GetObject("searchbuttonPI.BackgroundImage");
            searchbuttonPI.FlatAppearance.BorderSize = 0;
            searchbuttonPI.FlatStyle = FlatStyle.Flat;
            searchbuttonPI.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchbuttonPI.ForeColor = Color.DarkOliveGreen;
            searchbuttonPI.Location = new Point(500, 135);
            searchbuttonPI.Name = "searchbuttonPI";
            searchbuttonPI.Size = new Size(120, 41);
            searchbuttonPI.TabIndex = 112;
            searchbuttonPI.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.LawnGreen;
            label6.Location = new Point(221, 142);
            label6.Name = "label6";
            label6.Size = new Size(15, 24);
            label6.TabIndex = 111;
            label6.Text = ":";
            // 
            // User_DigitalReceiptVault
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1500, 785);
            Controls.Add(label5);
            Controls.Add(searchBoxPI);
            Controls.Add(searchbuttonPI);
            Controls.Add(label6);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button1);
            Controls.Add(button8);
            Controls.Add(label1);
            Controls.Add(label8);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "User_DigitalReceiptVault";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Digital Vault Receipt";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private PrintPreviewControl printPreviewControl1;
        private DataGridView dataGridView1;
        private Button button8;
        private Label label8;
        private Button button6;
        private Button button5;
        private Label label1;
        private Button button1;
        private Button button4;
        private Label label5;
        private TextBox searchBoxPI;
        private Button searchbuttonPI;
        private Label label6;
    }
}