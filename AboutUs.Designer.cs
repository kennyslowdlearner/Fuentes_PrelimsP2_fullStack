namespace Fuentes_PrelimsP2
{
    partial class AboutUs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutUs));
            panel1 = new Panel();
            richTextBox1 = new RichTextBox();
            backButton = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(richTextBox1);
            panel1.Controls.Add(backButton);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(61, 58);
            panel1.Name = "panel1";
            panel1.Size = new Size(895, 539);
            panel1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.White;
            richTextBox1.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            richTextBox1.Location = new Point(47, 122);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(786, 347);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // backButton
            // 
            backButton.BackColor = Color.LightGreen;
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            backButton.ForeColor = Color.DarkOliveGreen;
            backButton.Location = new Point(387, 489);
            backButton.Name = "backButton";
            backButton.Size = new Size(112, 34);
            backButton.TabIndex = 2;
            backButton.Text = "Back";
            backButton.UseVisualStyleBackColor = false;
            backButton.Click += backButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("League Spartan", 27.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkOliveGreen;
            label1.Location = new Point(316, 35);
            label1.Name = "label1";
            label1.Size = new Size(259, 84);
            label1.TabIndex = 0;
            label1.Text = "About Us";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(386, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(250, 76);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // AboutUs
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1040, 650);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Name = "AboutUs";
            Text = "Pananom : About Us";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Button backButton;
        private RichTextBox richTextBox1;
        private ContextMenuStrip contextMenuStrip1;
    }
}