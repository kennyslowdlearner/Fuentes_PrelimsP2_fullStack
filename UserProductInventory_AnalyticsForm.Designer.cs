namespace Fuentes_PrelimsP2
{
    partial class UserProductInventory_AnalyticsForm
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
            display_panelchart_pi = new Panel();
            SuspendLayout();
            // 
            // display_panelchart_pi
            // 
            display_panelchart_pi.Location = new Point(12, 12);
            display_panelchart_pi.Name = "display_panelchart_pi";
            display_panelchart_pi.Size = new Size(1045, 473);
            display_panelchart_pi.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1069, 497);
            Controls.Add(display_panelchart_pi);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel display_panelchart_pi;
    }
}