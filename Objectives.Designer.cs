namespace Fuentes_PrelimsP2
{
    partial class Objectives
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Objectives));
            panel1 = new Panel();
            label2 = new Label();
            label7 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(73, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(895, 579);
            panel1.TabIndex = 2;
            // 
            // label2
            // 
            label2.Font = new Font("Glacial Indifference", 10F);
            label2.Location = new Point(34, 417);
            label2.Name = "label2";
            label2.Size = new Size(831, 81);
            label2.TabIndex = 5;
            label2.Text = resources.GetString("label2.Text");
            // 
            // label7
            // 
            label7.Font = new Font("Glacial Indifference", 10F);
            label7.Location = new Point(34, 327);
            label7.Name = "label7";
            label7.Size = new Size(831, 81);
            label7.TabIndex = 5;
            label7.Text = resources.GetString("label7.Text");
            // 
            // label5
            // 
            label5.Font = new Font("Glacial Indifference", 10F);
            label5.Location = new Point(34, 201);
            label5.Name = "label5";
            label5.Size = new Size(831, 81);
            label5.TabIndex = 5;
            label5.Text = resources.GetString("label5.Text");
            // 
            // label4
            // 
            label4.Font = new Font("Glacial Indifference", 10F);
            label4.Location = new Point(34, 292);
            label4.Name = "label4";
            label4.Size = new Size(831, 35);
            label4.TabIndex = 5;
            label4.Text = "b.   Provide the use of user friendly console application and an easy-to-use application for users; ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Glacial Indifference", 10F);
            label3.Location = new Point(23, 162);
            label3.Name = "label3";
            label3.Size = new Size(569, 24);
            label3.TabIndex = 5;
            label3.Text = "The primary objectives of Pananom project includes the following:";
            // 
            // button1
            // 
            button1.BackColor = Color.LightGreen;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.DarkOliveGreen;
            button1.Location = new Point(387, 523);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 2;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(316, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 76);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("League Spartan", 27.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkOliveGreen;
            label1.Location = new Point(295, 69);
            label1.Name = "label1";
            label1.Size = new Size(293, 84);
            label1.TabIndex = 0;
            label1.Text = "Objectives";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // Objectives
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1040, 650);
            Controls.Add(panel1);
            Name = "Objectives";
            Text = "Pananom : Objectives";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Label label1;
        private PictureBox pictureBox1;
        private ContextMenuStrip contextMenuStrip1;
        private Label label7;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
    }
}