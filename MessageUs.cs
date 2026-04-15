using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Fuentes_PrelimsP2
{
    public partial class MessageUs : Form
    {
        //this is for Firebase connection for feedback purposes
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "pYlcicIZWqHhoKha9CYpVH8lml5cEpmJDhLkaIEw",
            BasePath = "https://project-pananom-message-cloud-default-rtdb.asia-southeast1.firebasedatabase.app/"
        };

        IFirebaseClient client;

        public MessageUs()
        {
            InitializeComponent();

            try
            {
                client = new FireSharp.FirebaseClient(config);
            }

            catch
            {

            }
        }

        private void messageBack_Click(object sender, EventArgs e)
        { 
            Homepageee.Instance.Show();
            this.Close();
        }

        private async void MessageUs_Send(object sender, EventArgs e)
        {
            string reverseTimestamp = (DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks).ToString("d19");


            if (client == null)
                client = new FireSharp.FirebaseClient(config);

            if (client == null)
            {
                MessageBox.Show("Cloud Connecion failed. Check your internet connection", "Error");
                return;
            }

            if (client == null)
            {
                MessageBox.Show("Firebase is not initialized. Checking connection...");
                client = new FireSharp.FirebaseClient(config);
                if (client == null) return;
            }
            if (string.IsNullOrEmpty(messageFeedback.Text))
            {
                MessageBox.Show("Please enter a message before sending.", "Empty Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                

            var data = new UserFeedback
            {
                FeedbackID = reverseTimestamp,
                UserName = "Windows Forms User",
                Message = messageFeedback.Text,
                Timestamp = DateTime.Now.ToString("MM dd, yyyy hh:mm tt"),
                Status = "New",
            };

            try
            {
                SetResponse response = await client.SetAsync("Feedback/" + data.FeedbackID, data); //ask why not SetTaskAsync
                //UserFeedback result = response.ResultAs<UserFeedback>();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                { 
                    MessageBox.Show("Message sent to Project Pananom Developer's Cloud. Thank you!", "Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    messageFeedback.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send message: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

    //this is for Firebase, but we won't be using it for now. We can use it in the future if we want to store the feedback in a database.
    public class UserFeedback
    {
        public string FeedbackID { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public string Timestamp { get; set; }
        public string Status { get; set; }
        public long Priority { get; set; }

    }
}
