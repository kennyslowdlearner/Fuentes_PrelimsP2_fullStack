namespace Fuentes_PrelimsP2
{
    partial class farmgateUSER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(farmgateUSER));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            label3 = new Label();
            label2 = new Label();
            refreshToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            logoutoptionFPG = new ToolStripMenuItem();
            backoptionFPG = new ToolStripMenuItem();
            activityToolStripMenuItem = new ToolStripMenuItem();
            deleteproductFGP = new ToolStripMenuItem();
            updateproductFGP = new ToolStripMenuItem();
            addproductFGP = new ToolStripMenuItem();
            profileName = new Label();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            searchBoxPI = new TextBox();
            searchbuttonFPG = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            displayFGPblock = new DataGridView();
            numberFGP = new DataGridViewTextBoxColumn();
            productnameFGP = new DataGridViewTextBoxColumn();
            priceFGP = new DataGridViewTextBoxColumn();
            productidFGP = new DataGridViewTextBoxColumn();
            dateFGP = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            usermenuPI = new MenuStrip();
            contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)displayFGPblock).BeginInit();
            panel1.SuspendLayout();
            usermenuPI.SuspendLayout();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkOliveGreen;
            label3.Location = new Point(45, 99);
            label3.Name = "label3";
            label3.Size = new Size(290, 24);
            label3.TabIndex = 19;
            label3.Text = "Welcome to your farmgate price,";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Glacial Indifference", 10F);
            label2.ForeColor = Color.DarkOliveGreen;
            label2.Location = new Point(45, 123);
            label2.Name = "label2";
            label2.Size = new Size(148, 24);
            label2.TabIndex = 17;
            label2.Text = "[Time and Date]";
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Size = new Size(142, 32);
            refreshToolStripMenuItem.Text = "Refresh";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { refreshToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(143, 36);
            // 
            // logoutoptionFPG
            // 
            logoutoptionFPG.Name = "logoutoptionFPG";
            logoutoptionFPG.Size = new Size(270, 34);
            logoutoptionFPG.Text = "Logout";
            logoutoptionFPG.Click += logoutoptionFPG_Click_1;
            // 
            // backoptionFPG
            // 
            backoptionFPG.Name = "backoptionFPG";
            backoptionFPG.Size = new Size(270, 34);
            backoptionFPG.Text = "Back";
            backoptionFPG.Click += backoptionFPG_Click_1;
            // 
            // activityToolStripMenuItem
            // 
            activityToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { backoptionFPG, logoutoptionFPG });
            activityToolStripMenuItem.ForeColor = Color.DarkGreen;
            activityToolStripMenuItem.Name = "activityToolStripMenuItem";
            activityToolStripMenuItem.Size = new Size(133, 28);
            activityToolStripMenuItem.Text = "User Activity";
            // 
            // deleteproductFGP
            // 
            deleteproductFGP.Name = "deleteproductFGP";
            deleteproductFGP.Size = new Size(382, 34);
            deleteproductFGP.Text = "Delete/Remove Farmgate Price";
            // 
            // updateproductFGP
            // 
            updateproductFGP.Name = "updateproductFGP";
            updateproductFGP.Size = new Size(382, 34);
            updateproductFGP.Text = "Update Farmgate Price";
            // 
            // addproductFGP
            // 
            addproductFGP.Name = "addproductFGP";
            addproductFGP.Size = new Size(382, 34);
            addproductFGP.Text = "Add Farmgate Price";
            addproductFGP.Click += addproductFGP_Click;
            // 
            // profileName
            // 
            profileName.AutoSize = true;
            profileName.BackColor = Color.Transparent;
            profileName.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            profileName.ForeColor = Color.DarkOliveGreen;
            profileName.Location = new Point(331, 99);
            profileName.Name = "profileName";
            profileName.Size = new Size(58, 24);
            profileName.TabIndex = 18;
            profileName.Text = "User!";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.BackColor = Color.Transparent;
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addproductFGP, updateproductFGP, deleteproductFGP });
            optionsToolStripMenuItem.ForeColor = Color.DarkGreen;
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(137, 28);
            optionsToolStripMenuItem.Text = "User Options";
            // 
            // searchBoxPI
            // 
            searchBoxPI.BackColor = Color.Gainsboro;
            searchBoxPI.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Italic, GraphicsUnit.Point, 0);
            searchBoxPI.Location = new Point(149, 162);
            searchBoxPI.Name = "searchBoxPI";
            searchBoxPI.Size = new Size(252, 29);
            searchBoxPI.TabIndex = 15;
            searchBoxPI.Text = "Search product name or id";
            // 
            // searchbuttonFPG
            // 
            searchbuttonFPG.BackColor = Color.LightGreen;
            searchbuttonFPG.FlatStyle = FlatStyle.Flat;
            searchbuttonFPG.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchbuttonFPG.ForeColor = Color.DarkOliveGreen;
            searchbuttonFPG.Location = new Point(45, 157);
            searchbuttonFPG.Name = "searchbuttonFPG";
            searchbuttonFPG.Size = new Size(98, 34);
            searchbuttonFPG.TabIndex = 14;
            searchbuttonFPG.Text = "Search";
            searchbuttonFPG.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("League Spartan", 15.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkOliveGreen;
            label1.Location = new Point(45, 51);
            label1.Name = "label1";
            label1.Size = new Size(231, 48);
            label1.TabIndex = 13;
            label1.Text = "Farmgate Price";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(413, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(257, 76);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // displayFGPblock
            // 
            displayFGPblock.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            displayFGPblock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            displayFGPblock.ColumnHeadersHeight = 40;
            displayFGPblock.Columns.AddRange(new DataGridViewColumn[] { numberFGP, productnameFGP, priceFGP, productidFGP, dateFGP });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Verdana", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            displayFGPblock.DefaultCellStyle = dataGridViewCellStyle1;
            displayFGPblock.GridColor = SystemColors.MenuText;
            displayFGPblock.Location = new Point(0, 0);
            displayFGPblock.Name = "displayFGPblock";
            displayFGPblock.RowHeadersWidth = 62;
            displayFGPblock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            displayFGPblock.Size = new Size(950, 416);
            displayFGPblock.TabIndex = 0;
            displayFGPblock.CellContentClick += dateViewFGP;
            // 
            // numberFGP
            // 
            numberFGP.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            numberFGP.DataPropertyName = "numberFGP";
            numberFGP.FillWeight = 227.272751F;
            numberFGP.HeaderText = "No.";
            numberFGP.MinimumWidth = 8;
            numberFGP.Name = "numberFGP";
            numberFGP.ReadOnly = true;
            // 
            // productnameFGP
            // 
            productnameFGP.DataPropertyName = "productnameFGP";
            productnameFGP.FillWeight = 172.956528F;
            productnameFGP.HeaderText = "Product Name";
            productnameFGP.MinimumWidth = 8;
            productnameFGP.Name = "productnameFGP";
            // 
            // priceFGP
            // 
            priceFGP.DataPropertyName = "priceFGP";
            priceFGP.FillWeight = 29.5617085F;
            priceFGP.HeaderText = "Farmgate Price (PHP)";
            priceFGP.MinimumWidth = 8;
            priceFGP.Name = "priceFGP";
            priceFGP.ReadOnly = true;
            // 
            // productidFGP
            // 
            productidFGP.DataPropertyName = "productidFGP";
            productidFGP.FillWeight = 29.5617085F;
            productidFGP.HeaderText = "Product ID";
            productidFGP.MinimumWidth = 8;
            productidFGP.Name = "productidFGP";
            productidFGP.ReadOnly = true;
            // 
            // dateFGP
            // 
            dateFGP.DataPropertyName = "dateFGP";
            dateFGP.FillWeight = 40.6473465F;
            dateFGP.HeaderText = "Date Published";
            dateFGP.MinimumWidth = 8;
            dateFGP.Name = "dateFGP";
            dateFGP.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(displayFGPblock);
            panel1.Font = new Font("Glacial Indifference", 10F);
            panel1.Location = new Point(45, 212);
            panel1.Name = "panel1";
            panel1.Size = new Size(950, 416);
            panel1.TabIndex = 11;
            // 
            // usermenuPI
            // 
            usermenuPI.BackColor = Color.Transparent;
            usermenuPI.Dock = DockStyle.None;
            usermenuPI.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usermenuPI.ImageScalingSize = new Size(24, 24);
            usermenuPI.Items.AddRange(new ToolStripItem[] { optionsToolStripMenuItem, activityToolStripMenuItem });
            usermenuPI.Location = new Point(413, 159);
            usermenuPI.Name = "usermenuPI";
            usermenuPI.Size = new Size(458, 32);
            usermenuPI.TabIndex = 16;
            usermenuPI.Text = "menuStrip1";
            // 
            // farmgateUSER
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1040, 650);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(profileName);
            Controls.Add(searchBoxPI);
            Controls.Add(searchbuttonFPG);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(usermenuPI);
            Name = "farmgateUSER";
            Text = "Pananom : Farmgate Price";
            FormClosed += farmgateUSER_FormClosed;
            contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)displayFGPblock).EndInit();
            panel1.ResumeLayout(false);
            usermenuPI.ResumeLayout(false);
            usermenuPI.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem logoutoptionFPG;
        private ToolStripMenuItem backoptionFPG;
        private ToolStripMenuItem activityToolStripMenuItem;
        private ToolStripMenuItem deleteproductFGP;
        private ToolStripMenuItem updateproductFGP;
        private ToolStripMenuItem addproductFGP;
        private Label profileName;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private TextBox searchBoxPI;
        private Button searchbuttonFPG;
        private Label label1;
        private PictureBox pictureBox1;
        private DataGridView displayFGPblock;
        private Panel panel1;
        private MenuStrip usermenuPI;
        private DataGridViewTextBoxColumn numberFGP;
        private DataGridViewTextBoxColumn productnameFGP;
        private DataGridViewTextBoxColumn priceFGP;
        private DataGridViewTextBoxColumn productidFGP;
        private DataGridViewTextBoxColumn dateFGP;
    }
}