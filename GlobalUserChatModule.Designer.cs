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
            display_conversation_chat = new FlowLayoutPanel();
            button1 = new Button();
            fill_message_chat = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // display_conversation_chat
            // 
            display_conversation_chat.Location = new Point(18, 84);
            display_conversation_chat.Name = "display_conversation_chat";
            display_conversation_chat.Size = new Size(572, 360);
            display_conversation_chat.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(469, 450);
            button1.Name = "button1";
            button1.Size = new Size(121, 33);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += this.press_sendchat_chat;
            // 
            // fill_message_chat
            // 
            fill_message_chat.Location = new Point(18, 450);
            fill_message_chat.Name = "fill_message_chat";
            fill_message_chat.Size = new Size(445, 31);
            fill_message_chat.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(453, 56);
            label1.Name = "label1";
            label1.Size = new Size(137, 25);
            label1.TabIndex = 3;
            label1.Text = "Sent to: ADMIN";
            // 
            // GlobalUserChatModule
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(610, 493);
            Controls.Add(label1);
            Controls.Add(fill_message_chat);
            Controls.Add(button1);
            Controls.Add(display_conversation_chat);
            Name = "GlobalUserChatModule";
            Text = "Form1";
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