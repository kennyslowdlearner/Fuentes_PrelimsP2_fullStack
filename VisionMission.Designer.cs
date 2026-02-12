namespace Fuentes_PrelimsP2
{
    partial class VisionMission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisionMission));
            panel1 = new Panel();
            backButton = new Label();
            label2 = new Label();
            backButton2 = new Button();
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
            panel1.Controls.Add(backButton);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(backButton2);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(73, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(895, 579);
            panel1.TabIndex = 3;
            // 
            // backButton
            // 
            backButton.Font = new Font("Glacial Indifference", 10F);
            backButton.Location = new Point(82, 317);
            backButton.Name = "backButton";
            backButton.Size = new Size(810, 128);
            backButton.TabIndex = 4;
            backButton.Text = resources.GetString("backButton.Text");
            // 
            // label2
            // 
            label2.Font = new Font("Glacial Indifference", 10F);
            label2.Location = new Point(71, 189);
            label2.Name = "label2";
            label2.Size = new Size(810, 128);
            label2.TabIndex = 4;
            label2.Text = "Vision : To become a leading bridge between technical engineering and creative innovation, where complex logic is transformed into intuitive, beautiful, and accessible digital experiences.";
            // 
            // backButton2
            // 
            backButton2.BackColor = Color.LightGreen;
            backButton2.FlatStyle = FlatStyle.Flat;
            backButton2.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            backButton2.ForeColor = Color.DarkOliveGreen;
            backButton2.Location = new Point(387, 523);
            backButton2.Name = "backButton2";
            backButton2.Size = new Size(112, 34);
            backButton2.TabIndex = 2;
            backButton2.Text = "Back";
            backButton2.UseVisualStyleBackColor = false;
            backButton2.Click += this.backButton2_Click_1;
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
            label1.Location = new Point(199, 69);
            label1.Name = "label1";
            label1.Size = new Size(495, 84);
            label1.TabIndex = 0;
            label1.Text = "Vision and Mission";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // VisionMission
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1040, 650);
            Controls.Add(panel1);
            Name = "VisionMission";
            Text = "Form2";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button backButton2;
        private PictureBox pictureBox1;
        private Label label1;
        private ContextMenuStrip contextMenuStrip1;
        private Label backButton;
        private Label label2;
    }
}