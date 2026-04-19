namespace Fuentes_PrelimsP2
{
    partial class GlobalUserChatModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlobalUserChatModule));
            display_conversation_chat = new FlowLayoutPanel();
            button1 = new Button();
            fill_message_chat = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // display_conversation_chat
            // 
            display_conversation_chat.AutoScroll = true;
            display_conversation_chat.BackColor = Color.Transparent;
            display_conversation_chat.Location = new Point(32, 84);
            display_conversation_chat.Name = "display_conversation_chat";
            display_conversation_chat.Size = new Size(569, 360);
            display_conversation_chat.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(483, 454);
            button1.Name = "button1";
            button1.Size = new Size(121, 43);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = false;
            button1.Click += press_sendchat_chat;
            // 
            // fill_message_chat
            // 
            fill_message_chat.BackColor = Color.PaleGreen;
            fill_message_chat.Location = new Point(32, 460);
            fill_message_chat.Name = "fill_message_chat";
            fill_message_chat.Size = new Size(445, 31);
            fill_message_chat.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Glacial Indifference", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkOliveGreen;
            label1.Location = new Point(452, 57);
            label1.Name = "label1";
            label1.Size = new Size(149, 24);
            label1.TabIndex = 3;
            label1.Text = "Sent to: ADMIN";
            // 
            // GlobalUserChatModule
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(630, 503);
            Controls.Add(label1);
            Controls.Add(fill_message_chat);
            Controls.Add(button1);
            Controls.Add(display_conversation_chat);
            Name = "GlobalUserChatModule";
            Text = "Chat with Admin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel display_conversation_chat;
        private Button button1;
        private TextBox fill_message_chat;
        private Label label1;
    }
}