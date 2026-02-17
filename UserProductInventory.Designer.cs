namespace Fuentes_PrelimsP2
{
    partial class productInventory
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(productInventory));
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            Number = new DataGridViewTextBoxColumn();
            productName = new DataGridViewTextBoxColumn();
            quantityProduct = new DataGridViewTextBoxColumn();
            idProduct = new DataGridViewTextBoxColumn();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            searchBoxPI = new TextBox();
            searchbuttonPI = new Button();
            usermenuPI = new MenuStrip();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            addProductToolStripMenuItem = new ToolStripMenuItem();
            updatePrToolStripMenuItem = new ToolStripMenuItem();
            deleteRemoveProductToolStripMenuItem = new ToolStripMenuItem();
            activityToolStripMenuItem = new ToolStripMenuItem();
            backoptionPI = new ToolStripMenuItem();
            logoutoptionPI = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            refreshToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            profileName = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            usermenuPI.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(dataGridView1);
            panel1.Font = new Font("Glacial Indifference", 10F);
            panel1.Location = new Point(41, 201);
            panel1.Name = "panel1";
            panel1.Size = new Size(950, 416);
            panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Verdana", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Number, productName, quantityProduct, idProduct });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = SystemColors.MenuText;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(950, 416);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Number
            // 
            Number.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Number.DataPropertyName = "numberPI";
            Number.FillWeight = 181.818176F;
            Number.HeaderText = "No.";
            Number.MinimumWidth = 8;
            Number.Name = "Number";
            Number.ReadOnly = true;
            // 
            // productName
            // 
            productName.DataPropertyName = "productnamePI";
            productName.FillWeight = 72.72727F;
            productName.HeaderText = "Product Name";
            productName.MinimumWidth = 8;
            productName.Name = "productName";
            productName.ReadOnly = true;
            productName.Width = 350;
            // 
            // quantityProduct
            // 
            quantityProduct.DataPropertyName = "quantityPI";
            quantityProduct.FillWeight = 72.72727F;
            quantityProduct.HeaderText = "Quantity";
            quantityProduct.MinimumWidth = 8;
            quantityProduct.Name = "quantityProduct";
            quantityProduct.ReadOnly = true;
            quantityProduct.Width = 200;
            // 
            // idProduct
            // 
            idProduct.DataPropertyName = "productidPI";
            idProduct.FillWeight = 72.72727F;
            idProduct.HeaderText = "Product ID";
            idProduct.MinimumWidth = 8;
            idProduct.Name = "idProduct";
            idProduct.ReadOnly = true;
            idProduct.Width = 250;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Location = new Point(409, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(257, 76);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("League Spartan", 15.999999F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkOliveGreen;
            label1.Location = new Point(41, 40);
            label1.Name = "label1";
            label1.Size = new Size(274, 48);
            label1.TabIndex = 3;
            label1.Text = "Product Inventory";
            // 
            // searchBoxPI
            // 
            searchBoxPI.BackColor = Color.Gainsboro;
            searchBoxPI.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Italic, GraphicsUnit.Point, 0);
            searchBoxPI.Location = new Point(145, 151);
            searchBoxPI.Name = "searchBoxPI";
            searchBoxPI.Size = new Size(252, 29);
            searchBoxPI.TabIndex = 5;
            searchBoxPI.Text = "Search product name or id";
            // 
            // searchbuttonPI
            // 
            searchbuttonPI.BackColor = Color.LightGreen;
            searchbuttonPI.FlatStyle = FlatStyle.Flat;
            searchbuttonPI.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchbuttonPI.ForeColor = Color.DarkOliveGreen;
            searchbuttonPI.Location = new Point(41, 146);
            searchbuttonPI.Name = "searchbuttonPI";
            searchbuttonPI.Size = new Size(98, 34);
            searchbuttonPI.TabIndex = 4;
            searchbuttonPI.Text = "Search";
            searchbuttonPI.UseVisualStyleBackColor = false;
            // 
            // usermenuPI
            // 
            usermenuPI.BackColor = Color.Transparent;
            usermenuPI.Dock = DockStyle.None;
            usermenuPI.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usermenuPI.ImageScalingSize = new Size(24, 24);
            usermenuPI.Items.AddRange(new ToolStripItem[] { optionsToolStripMenuItem, activityToolStripMenuItem });
            usermenuPI.Location = new Point(409, 148);
            usermenuPI.Name = "usermenuPI";
            usermenuPI.Size = new Size(458, 32);
            usermenuPI.TabIndex = 6;
            usermenuPI.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.BackColor = Color.Transparent;
            optionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addProductToolStripMenuItem, updatePrToolStripMenuItem, deleteRemoveProductToolStripMenuItem });
            optionsToolStripMenuItem.ForeColor = Color.DarkGreen;
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(137, 28);
            optionsToolStripMenuItem.Text = "User Options";
            // 
            // addProductToolStripMenuItem
            // 
            addProductToolStripMenuItem.Name = "addProductToolStripMenuItem";
            addProductToolStripMenuItem.Size = new Size(317, 34);
            addProductToolStripMenuItem.Text = "Add Product";
            // 
            // updatePrToolStripMenuItem
            // 
            updatePrToolStripMenuItem.Name = "updatePrToolStripMenuItem";
            updatePrToolStripMenuItem.Size = new Size(317, 34);
            updatePrToolStripMenuItem.Text = "Update Product";
            // 
            // deleteRemoveProductToolStripMenuItem
            // 
            deleteRemoveProductToolStripMenuItem.Name = "deleteRemoveProductToolStripMenuItem";
            deleteRemoveProductToolStripMenuItem.Size = new Size(317, 34);
            deleteRemoveProductToolStripMenuItem.Text = "Delete/Remove Product";
            // 
            // activityToolStripMenuItem
            // 
            activityToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { backoptionPI, logoutoptionPI });
            activityToolStripMenuItem.ForeColor = Color.DarkGreen;
            activityToolStripMenuItem.Name = "activityToolStripMenuItem";
            activityToolStripMenuItem.Size = new Size(133, 28);
            activityToolStripMenuItem.Text = "User Activity";
            // 
            // backoptionPI
            // 
            backoptionPI.Name = "backoptionPI";
            backoptionPI.Size = new Size(270, 34);
            backoptionPI.Text = "Back";
            backoptionPI.Click += this.backoptionPI_click;
            // 
            // logoutoptionPI
            // 
            logoutoptionPI.Name = "logoutoptionPI";
            logoutoptionPI.Size = new Size(270, 34);
            logoutoptionPI.Text = "Logout";
            logoutoptionPI.Click += this.logoutoptionPI_click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { refreshToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(143, 36);
            // 
            // refreshToolStripMenuItem
            // 
            refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            refreshToolStripMenuItem.Size = new Size(142, 32);
            refreshToolStripMenuItem.Text = "Refresh";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Glacial Indifference", 10F);
            label2.ForeColor = Color.DarkOliveGreen;
            label2.Location = new Point(41, 112);
            label2.Name = "label2";
            label2.Size = new Size(148, 24);
            label2.TabIndex = 8;
            label2.Text = "[Time and Date]";
            // 
            // profileName
            // 
            profileName.AutoSize = true;
            profileName.BackColor = Color.Transparent;
            profileName.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            profileName.ForeColor = Color.DarkOliveGreen;
            profileName.Location = new Point(345, 88);
            profileName.Name = "profileName";
            profileName.Size = new Size(58, 24);
            profileName.TabIndex = 9;
            profileName.Text = "User!";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Glacial Indifference", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.DarkOliveGreen;
            label3.Location = new Point(41, 88);
            label3.Name = "label3";
            label3.Size = new Size(310, 24);
            label3.TabIndex = 10;
            label3.Text = "Welcome to your Product Inventory,";
            // 
            // productInventory
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1040, 650);
            Controls.Add(profileName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(searchBoxPI);
            Controls.Add(searchbuttonPI);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(usermenuPI);
            MainMenuStrip = usermenuPI;
            Name = "productInventory";
            Text = "Pananom : Product Inventory";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            usermenuPI.ResumeLayout(false);
            usermenuPI.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private PictureBox pictureBox1;
        private Label label1;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn productName;
        private DataGridViewTextBoxColumn quantityProduct;
        private DataGridViewTextBoxColumn idProduct;
        private TextBox searchBoxPI;
        private Button searchbuttonPI;
        private MenuStrip usermenuPI;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem addProductToolStripMenuItem;
        private ToolStripMenuItem updatePrToolStripMenuItem;
        private ToolStripMenuItem deleteRemoveProductToolStripMenuItem;
        private ToolStripMenuItem activityToolStripMenuItem;
        private ToolStripMenuItem backoptionPI;
        private ToolStripMenuItem logoutoptionPI;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem refreshToolStripMenuItem;
        private Label label2;
        private Label profileName;
        private Label label3;
    }
}