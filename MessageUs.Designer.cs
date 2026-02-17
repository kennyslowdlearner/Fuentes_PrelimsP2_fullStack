namespace Fuentes_PrelimsP2
{
    partial class MessageUs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageUs));
            pictureBox2 = new PictureBox();
            label3 = new Label();
            panel1 = new Panel();
            richTextBox1 = new RichTextBox();
            label4 = new Label();
            label2 = new Label();
            messageBack = new Button();
            messageSend = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.Location = new Point(287, 285);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(46, 49);
            pictureBox2.TabIndex = 8;
            pictureBox2.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Glacial Indifference", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(348, 300);
            label3.Name = "label3";
            label3.Size = new Size(234, 34);
            label3.TabIndex = 7;
            label3.Text = "kennyslowdlearner";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(richTextBox1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(messageBack);
            panel1.Controls.Add(messageSend);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(31, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(806, 556);
            panel1.TabIndex = 10;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(174, 287);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(425, 156);
            richTextBox1.TabIndex = 6;
            richTextBox1.Text = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Glacial Indifference", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(281, 246);
            label4.Name = "label4";
            label4.Size = new Size(233, 29);
            label4.TabIndex = 5;
            label4.Text = "Enter message here : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Glacial Indifference", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(174, 190);
            label2.Name = "label2";
            label2.Size = new Size(444, 29);
            label2.TabIndex = 5;
            label2.Text = "Send us a message for inquiry or to report.";
            // 
            // messageBack
            // 
            messageBack.BackColor = Color.LightGreen;
            messageBack.FlatStyle = FlatStyle.Flat;
            messageBack.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            messageBack.ForeColor = Color.DarkOliveGreen;
            messageBack.Location = new Point(281, 475);
            messageBack.Name = "messageBack";
            messageBack.Size = new Size(112, 34);
            messageBack.TabIndex = 2;
            messageBack.Text = "Back";
            messageBack.UseVisualStyleBackColor = false;
            messageBack.Click += messageBack_Click;
            // 
            // messageSend
            // 
            messageSend.BackColor = Color.LightGreen;
            messageSend.FlatStyle = FlatStyle.Flat;
            messageSend.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            messageSend.ForeColor = Color.DarkOliveGreen;
            messageSend.Location = new Point(415, 475);
            messageSend.Name = "messageSend";
            messageSend.Size = new Size(112, 34);
            messageSend.TabIndex = 2;
            messageSend.Text = "Send";
            messageSend.UseVisualStyleBackColor = false;
            messageSend.Click += messageSend_Click;
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
            label1.Location = new Point(202, 83);
            label1.Name = "label1";
            label1.Size = new Size(416, 107);
            label1.TabIndex = 0;
            label1.Text = "Message Us";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // MessageUs
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(869, 619);
            Controls.Add(panel1);
            Controls.Add(pictureBox2);
            Controls.Add(label3);
            Name = "MessageUs";
            Text = "Pananom : Message Us";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private Label label3;
        private Panel panel1;
        private Label label2;
        private Button messageSend;
        private PictureBox pictureBox1;
        private Label label1;
        private ContextMenuStrip contextMenuStrip1;
        private RichTextBox richTextBox1;
        private Label label4;
        private Button messageBack;
    }
}