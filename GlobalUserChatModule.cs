using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Fuentes_PrelimsP2
{
    public partial class GlobalUserChatModule : Form
    {
        private static GlobalUserChatModule instance;


        FirebaseClient userClient = new FirebaseClient("https://project-pananom-chat-support-default-rtdb.asia-southeast1.firebasedatabase.app/");
        public GlobalUserChatModule()
        {
            InitializeComponent();
            BuildChat_Database();
            LoadChatHistoryFromSQL();
            listento_Cloud();
        }

        internal static GlobalUserChatModule Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new GlobalUserChatModule();

                return instance;
            }
        }

        private void listento_Cloud()
        {
            string username = UserSession.UserInstance.FirstName + "_" + UserSession.UserInstance.MiddleName + "_" + UserSession.UserInstance.LastName;

            var observable = userClient
             .Child("Chat_Support_Room")
             .Child("Conversation")
             .Child("Messages")
             .Child(username)
             .Child("History")
             .AsObservable<dynamic>()
             .Subscribe(async d => 
             {
                 if (d.Object != null)
                 {
                     string sender = d.Object.sender;
                     string text = d.Object.text;

                     if (sender == "Admin")
                     {
                         //this section is for email notifications.
                         string farmerEmail = UserSession.UserInstance.Email;
                         string message = "The admin as replied to your chat: " + text;
                         await GlobalEmailNotificationModule.send_Notification(farmerEmail, "New Chat Reply", message);


                         this.Invoke((MethodInvoker)delegate
                         {
                             AddAdminBubbleToUI(text);
                             SaveToSQL(99, text, false);
                         });
                     }
                 }
             });
        }

        private void AddAdminBubbleToUI(string messageText)
        {
            Label adminBubble = new Label();

            adminBubble.Text = "Admin: " + messageText;
            adminBubble.BackColor = Color.LightGray;
            adminBubble.ForeColor = Color.Black;
            adminBubble.AutoSize = true;
            adminBubble.Padding = new Padding(10);
            adminBubble.Margin = new Padding(5, 5, 50, 5); 
            adminBubble.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            display_conversation_chat.Controls.Add(adminBubble);

            display_conversation_chat.ScrollControlIntoView(adminBubble);
        }
        private void AddUserBubbleToUI(string text, string time)
        {
            Panel bubbleContainer = new Panel();
            bubbleContainer.AutoSize = true;
            bubbleContainer.Width = display_conversation_chat.Width - 40;

            Label userBubble = new Label();
            userBubble.Text = text;
            userBubble.BackColor = Color.LightGreen;
            userBubble.AutoSize = true;
            userBubble.MaximumSize = new Size(250, 0); // Prevents bubble from being too wide
            userBubble.Padding = new Padding(10);
            userBubble.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            Label timeLabel = new Label();
            timeLabel.Text = time;
            timeLabel.Font = new Font("Segoe UI", 7, FontStyle.Italic);
            timeLabel.ForeColor = Color.DimGray;
            timeLabel.AutoSize = true;

            userBubble.Location = new Point(bubbleContainer.Width - userBubble.PreferredWidth - 10, 0);
            timeLabel.Location = new Point(bubbleContainer.Width - timeLabel.PreferredWidth - 10, userBubble.Height + 2);

            bubbleContainer.Controls.Add(userBubble);
            bubbleContainer.Controls.Add(timeLabel);

            display_conversation_chat.Controls.Add(bubbleContainer);
            display_conversation_chat.ScrollControlIntoView(bubbleContainer);
        }
        private void BuildChat_Database()
        {
            string masterConnection = @"Server=.\SQLEXPRESS;Database=master;Trusted_Connection=True;Encrypt=False;";

            using(SqlConnection connectionOne = new SqlConnection(masterConnection))
            {
                try
                {
                    connectionOne.Open();

                    string sqlCreateDB = "IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'PananomChatDB') CREATE DATABASE PananomChatDB;";
                    SqlCommand commandDB = new SqlCommand(sqlCreateDB, connectionOne);
                    commandDB.ExecuteNonQuery();
                    connectionOne.Close();

                        string chatConnection = @"Server=.\SQLEXPRESS;Database=PananomChatDB;Trusted_Connection=True;Encrypt=False;";
                    using (SqlConnection connectionTwo = new SqlConnection(chatConnection))
                    {
                        connectionTwo.Open();
                        string sqlCreateTable = @"
                    IF NOT EXISTS (SELECT * FROM sys.objects WHERE name = 'tbl_ChatHistory')
                    CREATE TABLE tbl_ChatHistory (
                        ChatID INT PRIMARY KEY IDENTITY(1,1),
                        SenderID INT NOT NULL,
                        MessageBody NVARCHAR(MAX),
                        IsHardSend BIT DEFAULT 0,
                        Timestamp DATETIME DEFAULT GETDATE()
                    );";
                        SqlCommand commandTable = new SqlCommand(sqlCreateTable, connectionTwo);
                        commandTable.ExecuteNonQuery();
                    }

                    MessageBox.Show("Success! Your SQL Express Database is now alive.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("RDBMS Error: " + ex.Message);
                }

            }
        }

        private void SaveToSQL(int senderId, string message, bool isHardSend)
        {
            // Make sure this string matches the one you used in BuildChat_Database
            string chatConnection= @"Server=.\SQLEXPRESS;Database=PananomChatDB;Trusted_Connection=True;Encrypt=False;";

            string query = "INSERT INTO tbl_ChatHistory (SenderID, MessageBody, IsHardSend) VALUES (@sid, @body, @hard)";

            using (SqlConnection connection = new SqlConnection(chatConnection))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // These parameters prevent "SQL Injection" - a core BSCpE security concept!
                    command.Parameters.AddWithValue("@sid", senderId);
                    command.Parameters.AddWithValue("@body", message);
                    command.Parameters.AddWithValue("@hard", isHardSend);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void LoadChatHistoryFromSQL()
        {
            display_conversation_chat.Controls.Clear(); // Clear the "Blank Canvas"

            string chatConnection = @"Server=.\SQLEXPRESS;Database=PananomChatDB;Trusted_Connection=True;Encrypt=False;";
            string query = "SELECT SenderID, MessageBody, Timestamp FROM tbl_ChatHistory ORDER BY Timestamp ASC";

            using (SqlConnection connection = new SqlConnection(chatConnection))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int senderID = (int)reader["SenderID"];
                    string message = reader["MessageBody"].ToString();
                    string time = Convert.ToDateTime(reader["Timestamp"]).ToString("MMM dd, hh:mm tt");

                    if (senderID == 1) // User
                        AddUserBubbleToUI(message, time);
                    else if (senderID == 99) // Admin
                        AddAdminBubbleToUI(message); // You can update this method to accept 'time' too!
                }
            }
        }

        private async void press_sendchat_chat(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(fill_message_chat.Text)) return;

            string message = fill_message_chat.Text.Trim();

            try
            {
                SaveToSQL(1, message, false);
            
                string username = UserSession.UserInstance.FirstName + "_" + UserSession.UserInstance.MiddleName + "_" + UserSession.UserInstance.LastName;
                string timestamp = DateTime.Now.ToString("MMM dd, yyyy hh:mm tt");
                await userClient
                    .Child("Chat_Support_Room")
                    .Child("Conversation")
                    .Child("Messages")
                    .Child(username)
                    .Child("History")
                    .PostAsync(new { sender = "User", text = message, timestamp = timestamp});

                AddUserBubbleToUI(message, timestamp);

                fill_message_chat.Clear();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error occured: " + ex.Message);
            }
        }
    }
}
