namespace Fuentes_PrelimsP2
{
    partial class UserAddProductInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAddProductInventory));
            panel1 = new Panel();
            confirmPI = new Button();
            pictureBox1 = new PictureBox();
            searchbuttonPI = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            addproductidPI = new TextBox();
            quantityPI = new TextBox();
            addproductnamePI = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(confirmPI);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(searchbuttonPI);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(addproductidPI);
            panel1.Controls.Add(quantityPI);
            panel1.Controls.Add(addproductnamePI);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(11, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(433, 371);
            panel1.TabIndex = 22;
            // 
            // confirmPI
            // 
            confirmPI.BackColor = Color.LightGreen;
            confirmPI.FlatStyle = FlatStyle.Flat;
            confirmPI.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            confirmPI.ForeColor = Color.DarkOliveGreen;
            confirmPI.Location = new Point(325, 315);
            confirmPI.Name = "confirmPI";
            confirmPI.Size = new Size(98, 34);
            confirmPI.TabIndex = 20;
            confirmPI.Text = "Confirm";
            confirmPI.UseVisualStyleBackColor = false;
            confirmPI.Click += confirmPI_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(257, 76);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // searchbuttonPI
            // 
            searchbuttonPI.BackColor = Color.LightGreen;
            searchbuttonPI.FlatStyle = FlatStyle.Flat;
            searchbuttonPI.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchbuttonPI.ForeColor = Color.DarkOliveGreen;
            searchbuttonPI.Location = new Point(211, 315);
            searchbuttonPI.Name = "searchbuttonPI";
            searchbuttonPI.Size = new Size(98, 34);
            searchbuttonPI.TabIndex = 20;
            searchbuttonPI.Text = "Cancel";
            searchbuttonPI.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Glacial Indifference", 10F);
            label4.ForeColor = Color.DarkOliveGreen;
            label4.Location = new Point(3, 231);
            label4.Name = "label4";
            label4.Size = new Size(113, 24);
            label4.TabIndex = 19;
            label4.Text = "Product ID : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Glacial Indifference", 10F);
            label3.ForeColor = Color.DarkOliveGreen;
            label3.Location = new Point(3, 191);
            label3.Name = "label3";
            label3.Size = new Size(132, 24);
            label3.TabIndex = 19;
            label3.Text = "Quantity (kg) :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Glacial Indifference", 10F);
            label2.ForeColor = Color.DarkOliveGreen;
            label2.Location = new Point(3, 148);
            label2.Name = "label2";
            label2.Size = new Size(145, 24);
            label2.TabIndex = 19;
            label2.Text = "Product Name : ";
            // 
            // addproductidPI
            // 
            addproductidPI.BackColor = Color.Gainsboro;
            addproductidPI.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addproductidPI.Location = new Point(171, 226);
            addproductidPI.Name = "addproductidPI";
            addproductidPI.Size = new Size(252, 34);
            addproductidPI.TabIndex = 18;
            // 
            // quantityPI
            // 
            quantityPI.BackColor = Color.Gainsboro;
            quantityPI.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            quantityPI.Location = new Point(171, 186);
            quantityPI.Name = "quantityPI";
            quantityPI.Size = new Size(252, 34);
            quantityPI.TabIndex = 18;
            // 
            // addproductnamePI
            // 
            addproductnamePI.BackColor = Color.Gainsboro;
            addproductnamePI.Font = new Font("Glacial Indifference", 10.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addproductnamePI.Location = new Point(171, 143);
            addproductnamePI.Name = "addproductnamePI";
            addproductnamePI.Size = new Size(252, 34);
            addproductnamePI.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("League Spartan", 15.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkOliveGreen;
            label1.Location = new Point(3, 78);
            label1.Name = "label1";
            label1.Size = new Size(340, 48);
            label1.TabIndex = 14;
            label1.Text = "Add Product Inventory";
            // 
            // UserAddProductInventory
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 395);
            Controls.Add(panel1);
            Name = "UserAddProductInventory";
            Text = "Pananom : Add Product Inventory";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button confirmPI;
        private PictureBox pictureBox1;
        private Button searchbuttonPI;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox addproductidPI;
        private TextBox quantityPI;
        private TextBox addproductnamePI;
        private Label label1;
    }
}