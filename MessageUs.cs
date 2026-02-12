using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Fuentes_PrelimsP2
{
    public partial class MessageUs : Form
    {
        public MessageUs()
        {
            InitializeComponent();
        }
        // Back button closes the form (wired in designer)
        private void messageBack_Click(object sender, EventArgs e)
        {

            Homepage homepage = new Homepage();

            homepage.Show();
            this.Close();
        }

        // Send button: show confirmation and clear the message box
        private void messageSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                MessageBox.Show("Please enter a message before sending.", "Empty Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // In this simple implementation just acknowledge and clear
            MessageBox.Show("Message sent. Thank you!", "Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            richTextBox1.Clear();
        }

    }

}
