namespace Fuentes_PrelimsP2
{
    partial class AdminAccountControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminAccountControl));
            panel1 = new Panel();
            Account_Control_Grid = new DataGridView();
            button2 = new Button();
            button1 = new Button();
            button8 = new Button();
            button4 = new Button();
            label26 = new Label();
            display_users_aac = new Label();
            label2 = new Label();
            display_actives_aac = new Label();
            display_inactives_aac = new Label();
            label5 = new Label();
            button6 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Account_Control_Grid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(Account_Control_Grid);
            panel1.Location = new Point(63, 230);
            panel1.Name = "panel1";
            panel1.Size = new Size(1344, 399);
            panel1.TabIndex = 0;
            // 
            // Account_Control_Grid
            // 
            Account_Control_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Account_Control_Grid.Location = new Point(3, 3);
            Account_Control_Grid.Name = "Account_Control_Grid";
            Account_Control_Grid.RowHeadersWidth = 62;
            Account_Control_Grid.Size = new Size(1338, 393);
            Account_Control_Grid.TabIndex = 0;
            Account_Control_Grid.CellFormatting += enabledisable_changcolor;
            // 
            // button2
            // 
            button2.BackColor = Color.Yellow;
            button2.FlatAppearance.BorderColor = Color.Gold;
            button2.FlatAppearance.BorderSize = 2;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.DarkGreen;
            button2.Location = new Point(215, 638);
            button2.Name = "button2";
            button2.Size = new Size(143, 38);
            button2.TabIndex = 90;
            button2.Text = "Unlock";
            button2.UseVisualStyleBackColor = false;
            button2.Click += press_unlock_aac;
            // 
            // button1
            // 
            button1.BackColor = Color.Yellow;
            button1.FlatAppearance.BorderColor = Color.Gold;
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.DarkGreen;
            button1.Location = new Point(66, 638);
            button1.Name = "button1";
            button1.Size = new Size(143, 38);
            button1.TabIndex = 91;
            button1.Text = "Enable/Disable";
            button1.UseVisualStyleBackColor = false;
            button1.Click += press_enableDisable_aac;
            // 
            // button8
            // 
            button8.BackColor = Color.Yellow;
            button8.FlatAppearance.BorderColor = Color.Gold;
            button8.FlatAppearance.BorderSize = 2;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.DarkGreen;
            button8.Location = new Point(1264, 635);
            button8.Name = "button8";
            button8.Size = new Size(143, 38);
            button8.TabIndex = 87;
            button8.Text = "Delete Account";
            button8.UseVisualStyleBackColor = false;
            button8.Click += delete_Account;
            // 
            // button4
            // 
            button4.BackColor = Color.Yellow;
            button4.FlatAppearance.BorderColor = Color.Gold;
            button4.FlatAppearance.BorderSize = 2;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.DarkGreen;
            button4.Location = new Point(1115, 636);
            button4.Name = "button4";
            button4.Size = new Size(143, 38);
            button4.TabIndex = 88;
            button4.Text = "Refresh";
            button4.UseVisualStyleBackColor = false;
            button4.Click += press_refresh_aa;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.BackColor = Color.Transparent;
            label26.Font = new Font("Glacial Indifference", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label26.ForeColor = Color.LawnGreen;
            label26.Location = new Point(382, 644);
            label26.Name = "label26";
            label26.Size = new Size(142, 29);
            label26.TabIndex = 93;
            label26.Text = "Total Users:";
            // 
            // display_users_aac
            // 
            display_users_aac.AutoSize = true;
            display_users_aac.BackColor = Color.Transparent;
            display_users_aac.Font = new Font("Glacial Indifference", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            display_users_aac.ForeColor = Color.Gold;
            display_users_aac.Location = new Point(521, 644);
            display_users_aac.Name = "display_users_aac";
            display_users_aac.Size = new Size(57, 29);
            display_users_aac.TabIndex = 94;
            display_users_aac.Text = "Num";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Glacial Indifference", 12F, FontStyle.Bold);
            label2.ForeColor = Color.LawnGreen;
            label2.Location = new Point(612, 647);
            label2.Name = "label2";
            label2.Size = new Size(91, 29);
            label2.TabIndex = 93;
            label2.Text = "Active:";
            // 
            // display_actives_aac
            // 
            display_actives_aac.AutoSize = true;
            display_actives_aac.BackColor = Color.Transparent;
            display_actives_aac.Font = new Font("Glacial Indifference", 12F);
            display_actives_aac.ForeColor = Color.Gold;
            display_actives_aac.Location = new Point(700, 647);
            display_actives_aac.Name = "display_actives_aac";
            display_actives_aac.Size = new Size(57, 29);
            display_actives_aac.TabIndex = 94;
            display_actives_aac.Text = "Num";
            // 
            // display_inactives_aac
            // 
            display_inactives_aac.AutoSize = true;
            display_inactives_aac.BackColor = Color.Transparent;
            display_inactives_aac.Font = new Font("Glacial Indifference", 12F);
            display_inactives_aac.ForeColor = Color.Gold;
            display_inactives_aac.Location = new Point(911, 649);
            display_inactives_aac.Name = "display_inactives_aac";
            display_inactives_aac.Size = new Size(57, 29);
            display_inactives_aac.TabIndex = 94;
            display_inactives_aac.Text = "Num";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Glacial Indifference", 12F, FontStyle.Bold);
            label5.ForeColor = Color.LawnGreen;
            label5.Location = new Point(797, 647);
            label5.Name = "label5";
            label5.Size = new Size(108, 29);
            label5.TabIndex = 93;
            label5.Text = "Inactive:";
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(718, 732);
            button6.Name = "button6";
            button6.Size = new Size(120, 41);
            button6.TabIndex = 95;
            button6.UseVisualStyleBackColor = false;
            button6.Click += backButton;
            // 
            // AdminAccountControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1500, 785);
            Controls.Add(button6);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(display_inactives_aac);
            Controls.Add(label26);
            Controls.Add(display_actives_aac);
            Controls.Add(display_users_aac);
            Controls.Add(button2);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(button4);
            Controls.Add(button8);
            Name = "AdminAccountControl";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Is";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Account_Control_Grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button2;
        private Button button1;
        private Button button8;
        private Button button4;
        private Label label26;
        private Label display_users_aac;
        private Label label2;
        private Label display_actives_aac;
        private Label display_inactives_aac;
        private Label label5;
        private Button button6;
        private DataGridView Account_Control_Grid;
    }
}