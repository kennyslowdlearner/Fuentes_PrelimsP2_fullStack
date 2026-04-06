namespace Fuentes_PrelimsP2
{
    partial class Admin_InventoryManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_InventoryManagement));
            menuStrip2 = new MenuStrip();
            sssssToolStripMenuItem = new ToolStripMenuItem();
            reloadToolStripMenuItem = new ToolStripMenuItem();
            learnMoreToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            viewAccountToolStripMenuItem1 = new ToolStripMenuItem();
            accountSettingsToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            button6 = new Button();
            button4 = new Button();
            button8 = new Button();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            label5 = new Label();
            searchBoxPI = new TextBox();
            searchbuttonPI = new Button();
            menuStrip2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip2
            // 
            menuStrip2.BackColor = Color.Transparent;
            menuStrip2.Dock = DockStyle.None;
            menuStrip2.ImageScalingSize = new Size(24, 24);
            menuStrip2.Items.AddRange(new ToolStripItem[] { sssssToolStripMenuItem, accountSettingsToolStripMenuItem });
            menuStrip2.Location = new Point(1134, 225);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(343, 32);
            menuStrip2.TabIndex = 126;
            menuStrip2.Text = "menuStrip2";
            // 
            // sssssToolStripMenuItem
            // 
            sssssToolStripMenuItem.BackColor = Color.Transparent;
            sssssToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reloadToolStripMenuItem, learnMoreToolStripMenuItem, toolStripMenuItem3, viewAccountToolStripMenuItem1 });
            sssssToolStripMenuItem.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sssssToolStripMenuItem.ForeColor = Color.Chartreuse;
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
            accountSettingsToolStripMenuItem.ForeColor = Color.Chartreuse;
            accountSettingsToolStripMenuItem.Name = "accountSettingsToolStripMenuItem";
            accountSettingsToolStripMenuItem.Size = new Size(184, 28);
            accountSettingsToolStripMenuItem.Text = "Account Settings";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(172, 34);
            toolStripMenuItem4.Text = "Logout";
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(676, 732);
            button6.Name = "button6";
            button6.Size = new Size(120, 41);
            button6.TabIndex = 122;
            button6.UseVisualStyleBackColor = false;
            button6.Click += backButton;
            // 
            // button4
            // 
            button4.BackColor = Color.Yellow;
            button4.FlatAppearance.BorderColor = Color.Gold;
            button4.FlatAppearance.BorderSize = 2;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.DarkGreen;
            button4.Location = new Point(1174, 676);
            button4.Name = "button4";
            button4.Size = new Size(143, 38);
            button4.TabIndex = 121;
            button4.Text = "Refresh";
            button4.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            button8.BackColor = Color.Yellow;
            button8.FlatAppearance.BorderColor = Color.Gold;
            button8.FlatAppearance.BorderSize = 2;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.DarkGreen;
            button8.Location = new Point(1323, 675);
            button8.Name = "button8";
            button8.Size = new Size(143, 38);
            button8.TabIndex = 120;
            button8.Text = "Connect";
            button8.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(32, 260);
            panel1.Name = "panel1";
            panel1.Size = new Size(1434, 409);
            panel1.TabIndex = 119;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1428, 501);
            dataGridView1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Glacial Indifference", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DarkOliveGreen;
            label5.Location = new Point(38, 220);
            label5.Name = "label5";
            label5.Size = new Size(157, 27);
            label5.TabIndex = 129;
            label5.Text = "Product Name";
            // 
            // searchBoxPI
            // 
            searchBoxPI.BackColor = Color.Gainsboro;
            searchBoxPI.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Italic, GraphicsUnit.Point, 0);
            searchBoxPI.ForeColor = Color.DarkOliveGreen;
            searchBoxPI.Location = new Point(206, 222);
            searchBoxPI.Name = "searchBoxPI";
            searchBoxPI.Size = new Size(252, 29);
            searchBoxPI.TabIndex = 128;
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
            searchbuttonPI.Location = new Point(464, 216);
            searchbuttonPI.Name = "searchbuttonPI";
            searchbuttonPI.Size = new Size(120, 41);
            searchbuttonPI.TabIndex = 127;
            searchbuttonPI.UseVisualStyleBackColor = false;
            // 
            // Admin_InventoryManagement
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1500, 785);
            Controls.Add(label5);
            Controls.Add(searchBoxPI);
            Controls.Add(searchbuttonPI);
            Controls.Add(menuStrip2);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button8);
            Controls.Add(panel1);
            Name = "Admin_InventoryManagement";
            Text = "Form1";
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip2;
        private ToolStripMenuItem sssssToolStripMenuItem;
        private ToolStripMenuItem reloadToolStripMenuItem;
        private ToolStripMenuItem learnMoreToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem viewAccountToolStripMenuItem1;
        private ToolStripMenuItem accountSettingsToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem4;
        private Button button6;
        private Button button4;
        private Button button8;
        private Panel panel1;
        private DataGridView dataGridView1;
        private Label label5;
        private TextBox searchBoxPI;
        private Button searchbuttonPI;
    }
}