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
            button6 = new Button();
            button4 = new Button();
            button8 = new Button();
            panel1 = new Panel();
            Inventory_Management_Grid = new DataGridView();
            label5 = new Label();
            fill_search_im = new TextBox();
            display_namestatus = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Inventory_Management_Grid).BeginInit();
            SuspendLayout();
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
            button8.Text = "Switch";
            button8.UseVisualStyleBackColor = false;
            button8.Click += press_switch;
            // 
            // panel1
            // 
            panel1.Controls.Add(Inventory_Management_Grid);
            panel1.Location = new Point(32, 260);
            panel1.Name = "panel1";
            panel1.Size = new Size(1434, 409);
            panel1.TabIndex = 119;
            // 
            // Inventory_Management_Grid
            // 
            Inventory_Management_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Inventory_Management_Grid.Location = new Point(3, 3);
            Inventory_Management_Grid.Name = "Inventory_Management_Grid";
            Inventory_Management_Grid.RowHeadersWidth = 62;
            Inventory_Management_Grid.Size = new Size(1428, 501);
            Inventory_Management_Grid.TabIndex = 0;
            Inventory_Management_Grid.CellFormatting += Inventory_Management_Grid_CellFormatting;
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
            // fill_search_im
            // 
            fill_search_im.BackColor = Color.Gainsboro;
            fill_search_im.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Italic, GraphicsUnit.Point, 0);
            fill_search_im.ForeColor = Color.DarkOliveGreen;
            fill_search_im.Location = new Point(206, 222);
            fill_search_im.Name = "fill_search_im";
            fill_search_im.Size = new Size(252, 29);
            fill_search_im.TabIndex = 128;
            fill_search_im.TextChanged += press_search;
            // 
            // display_namestatus
            // 
            display_namestatus.AutoSize = true;
            display_namestatus.BackColor = Color.Transparent;
            display_namestatus.Font = new Font("Glacial Indifference", 15.9999981F, FontStyle.Bold, GraphicsUnit.Point, 0);
            display_namestatus.ForeColor = Color.Chartreuse;
            display_namestatus.Location = new Point(1233, 209);
            display_namestatus.Name = "display_namestatus";
            display_namestatus.Size = new Size(50, 38);
            display_namestatus.TabIndex = 129;
            display_namestatus.Text = "---";
            // 
            // Admin_InventoryManagement
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1500, 785);
            Controls.Add(display_namestatus);
            Controls.Add(label5);
            Controls.Add(fill_search_im);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button8);
            Controls.Add(panel1);
            Name = "Admin_InventoryManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Inventory_Management_Grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button6;
        private Button button4;
        private Button button8;
        private Panel panel1;
        private DataGridView Inventory_Management_Grid;
        private Label label5;
        private TextBox fill_search_im;
        private Label display_namestatus;
    }
}