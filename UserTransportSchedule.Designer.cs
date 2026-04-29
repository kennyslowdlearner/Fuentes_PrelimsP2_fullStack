namespace Fuentes_PrelimsP2
{
    partial class UserTransportSchedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserTransportSchedule));
            panel1 = new Panel();
            button6 = new Button();
            button5 = new Button();
            label1 = new Label();
            Transport_Schedule_Grid = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Transport_Schedule_Grid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(Transport_Schedule_Grid);
            panel1.Location = new Point(65, 253);
            panel1.Name = "panel1";
            panel1.Size = new Size(1364, 394);
            panel1.TabIndex = 0;
            // 
            // button6
            // 
            button6.BackColor = Color.Transparent;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button6.Location = new Point(647, 691);
            button6.Name = "button6";
            button6.Size = new Size(120, 41);
            button6.TabIndex = 42;
            button6.UseVisualStyleBackColor = false;
            button6.Click += backButton;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Glacial Indifference", 8.999999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button5.Location = new Point(798, 691);
            button5.Name = "button5";
            button5.Size = new Size(120, 41);
            button5.TabIndex = 43;
            button5.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Glacial Indifference", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.LawnGreen;
            label1.Location = new Point(65, 208);
            label1.Name = "label1";
            label1.Size = new Size(317, 29);
            label1.TabIndex = 44;
            label1.Text = "Current Transport Schedule";
            // 
            // Transport_Schedule_Grid
            // 
            Transport_Schedule_Grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Transport_Schedule_Grid.Location = new Point(3, 3);
            Transport_Schedule_Grid.Name = "Transport_Schedule_Grid";
            Transport_Schedule_Grid.RowHeadersWidth = 62;
            Transport_Schedule_Grid.Size = new Size(1358, 388);
            Transport_Schedule_Grid.TabIndex = 0;
            // 
            // UserTransportSchedule
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1500, 785);
            Controls.Add(label1);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(panel1);
            Name = "UserTransportSchedule";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Transport Schedule";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Transport_Schedule_Grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button button6;
        private Button button5;
        private Label label1;
        private DataGridView Transport_Schedule_Grid;
    }
}