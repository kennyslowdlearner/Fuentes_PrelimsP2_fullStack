namespace Fuentes_PrelimsP2
{
    partial class SupportUs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupportUs));
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            label2 = new Label();
            supportBack = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(supportBack);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(30, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(806, 556);
            panel1.TabIndex = 3;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.Location = new Point(274, 237);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(271, 248);
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Glacial Indifference", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(118, 190);
            label2.Name = "label2";
            label2.Size = new Size(613, 29);
            label2.TabIndex = 5;
            label2.Text = "Support us by sending extra funds for the development! ^^";
            // 
            // supportBack
            // 
            supportBack.BackColor = Color.LightGreen;
            supportBack.FlatStyle = FlatStyle.Flat;
            supportBack.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            supportBack.ForeColor = Color.DarkOliveGreen;
            supportBack.Location = new Point(351, 504);
            supportBack.Name = "supportBack";
            supportBack.Size = new Size(112, 34);
            supportBack.TabIndex = 2;
            supportBack.Text = "Back";
            supportBack.UseVisualStyleBackColor = false;
            supportBack.Click += this.supportBack_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(286, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 76);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("League Spartan", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkOliveGreen;
            label1.Location = new Point(221, 83);
            label1.Name = "label1";
            label1.Size = new Size(395, 107);
            label1.TabIndex = 0;
            label1.Text = "Support Us";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // SupportUs
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(869, 619);
            Controls.Add(panel1);
            Name = "SupportUs";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button supportBack;
        private PictureBox pictureBox1;
        private Label label1;
        private ContextMenuStrip contextMenuStrip1;
        private Label label2;
        private PictureBox pictureBox3;
    }
}