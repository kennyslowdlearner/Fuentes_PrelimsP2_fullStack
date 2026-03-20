namespace Fuentes_PrelimsP2
{
    partial class LoginOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginOptions));
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Glacial Indifference", 10F);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(349, 344);
            button1.Name = "button1";
            button1.Size = new Size(160, 240);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Glacial Indifference", 10F);
            button2.ForeColor = Color.Transparent;
            button2.Location = new Point(534, 344);
            button2.Name = "button2";
            button2.Size = new Size(160, 240);
            button2.TabIndex = 0;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(316, 269);
            label2.Name = "label2";
            label2.Size = new Size(412, 72);
            label2.TabIndex = 1;
            label2.Text = "Choose an appropriate Login Account.";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginOptions
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1040, 650);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "LoginOptions";
            Text = "Pananom : Login Options";
            FormClosed += LoginOptions_FormClosed;
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Button button2;
        private Label label2;
    }
}