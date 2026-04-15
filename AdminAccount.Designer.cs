namespace Fuentes_PrelimsP2
{
    partial class AdminAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminAccount));
            panel1 = new Panel();
            button2 = new Button();
            groupBox1 = new GroupBox();
            button3 = new Button();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            richTextBox2 = new RichTextBox();
            label7 = new Label();
            label8 = new Label();
            sssssToolStripMenuItem = new ToolStripMenuItem();
            reloadToolStripMenuItem = new ToolStripMenuItem();
            learnMoreToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            viewAccountToolStripMenuItem1 = new ToolStripMenuItem();
            accountSettingsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            menuStrip2 = new MenuStrip();
            groupBox1.SuspendLayout();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Font = new Font("Glacial Indifference", 10F);
            panel1.Location = new Point(31, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(972, 135);
            panel1.TabIndex = 6;
            // 
            // button2
            // 
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 0);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Glacial Indifference", 10F);
            button2.Location = new Point(19, 40);
            button2.Name = "button2";
            button2.Size = new Size(288, 113);
            button2.TabIndex = 0;
            button2.UseVisualStyleBackColor = true;
            button2.Click += GoToTransportSchedule;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button2);
            groupBox1.Font = new Font("Glacial Indifference", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 217);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(322, 404);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Choose your next step:";
            // 
            // button3
            // 
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 0);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button3.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Glacial Indifference", 10F);
            button3.Location = new Point(19, 278);
            button3.Name = "button3";
            button3.Size = new Size(288, 113);
            button3.TabIndex = 0;
            button3.UseVisualStyleBackColor = true;
            button3.Click += GoToSalesReport;
            // 
            // button1
            // 
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 192, 0);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Glacial Indifference", 10F);
            button1.Location = new Point(19, 159);
            button1.Name = "button1";
            button1.Size = new Size(288, 113);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            button1.Click += GoToAccountControl;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.Silver;
            richTextBox1.Font = new Font("Glacial Indifference", 10F);
            richTextBox1.Location = new Point(350, 285);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(312, 353);
            richTextBox1.TabIndex = 10;
            richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            richTextBox2.BackColor = Color.Silver;
            richTextBox2.Font = new Font("Glacial Indifference", 10F);
            richTextBox2.Location = new Point(691, 285);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(312, 353);
            richTextBox2.TabIndex = 10;
            richTextBox2.Text = "";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Glacial Indifference", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(350, 235);
            label7.Name = "label7";
            label7.Size = new Size(265, 34);
            label7.TabIndex = 11;
            label7.Text = "Top Selling Product";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Glacial Indifference", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(691, 235);
            label8.Name = "label8";
            label8.Size = new Size(144, 34);
            label8.TabIndex = 11;
            label8.Text = "Top Seller";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // sssssToolStripMenuItem
            // 
            sssssToolStripMenuItem.BackColor = Color.Transparent;
            sssssToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reloadToolStripMenuItem, learnMoreToolStripMenuItem, toolStripMenuItem3, viewAccountToolStripMenuItem1 });
            sssssToolStripMenuItem.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sssssToolStripMenuItem.ForeColor = Color.DarkOliveGreen;
            sssssToolStripMenuItem.Name = "sssssToolStripMenuItem";
            sssssToolStripMenuItem.Size = new Size(151, 28);
            sssssToolStripMenuItem.Text = "More Options";
            // 
            // reloadToolStripMenuItem
            // 
            reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            reloadToolStripMenuItem.Size = new Size(281, 34);
            reloadToolStripMenuItem.Text = "Reload";
            // 
            // learnMoreToolStripMenuItem
            // 
            learnMoreToolStripMenuItem.Name = "learnMoreToolStripMenuItem";
            learnMoreToolStripMenuItem.Size = new Size(281, 34);
            learnMoreToolStripMenuItem.Text = "Learn More";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(281, 34);
            toolStripMenuItem3.Text = "Contact Developer";
            // 
            // viewAccountToolStripMenuItem1
            // 
            viewAccountToolStripMenuItem1.Name = "viewAccountToolStripMenuItem1";
            viewAccountToolStripMenuItem1.Size = new Size(281, 34);
            viewAccountToolStripMenuItem1.Text = "View Account";
            // 
            // accountSettingsToolStripMenuItem
            // 
            accountSettingsToolStripMenuItem.BackColor = Color.Transparent;
            accountSettingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem4 });
            accountSettingsToolStripMenuItem.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            accountSettingsToolStripMenuItem.ForeColor = Color.DarkOliveGreen;
            accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            accountSettingsToolStripMenuItem.Size = new Size(184, 28);
            accountSettingsToolStripMenuItem.Text = "Account Settings";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(172, 34);
            toolStripMenuItem4.Text = "Logout";
            toolStripMenuItem4.Click += logoutAdmin;
            // 
            // menuStrip2
            // 
            menuStrip2.BackColor = Color.Transparent;
            menuStrip2.Dock = DockStyle.None;
            menuStrip2.ImageScalingSize = new Size(24, 24);
            menuStrip2.Items.AddRange(new ToolStripItem[] { sssssToolStripMenuItem, accountSettingsToolStripMenuItem });
            menuStrip2.Location = new Point(669, 172);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(343, 32);
            menuStrip2.TabIndex = 106;
            menuStrip2.Text = "menuStrip2";
            // 
            // AdminAccount
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1040, 650);
            Controls.Add(menuStrip2);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(richTextBox2);
            Controls.Add(richTextBox1);
            Controls.Add(panel1);
            Controls.Add(groupBox1);
            Name = "AdminAccount";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Pananom : Admin Dashboard";
            FormClosed += AdminAccount_FormClosed;
            groupBox1.ResumeLayout(false);
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button2;
        private GroupBox groupBox1;
        private Button button3;
        private Button button1;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private Label label7;
        private Label label8;
        private ToolStripMenuItem sssssToolStripMenuItem;
        private ToolStripMenuItem reloadToolStripMenuItem;
        private ToolStripMenuItem learnMoreToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem viewAccountToolStripMenuItem1;
        private ToolStripMenuItem accountSettingsToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem4;
        private MenuStrip menuStrip2;
    }
}