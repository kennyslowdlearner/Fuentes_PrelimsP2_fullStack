using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Fuentes_PrelimsP2
{
    public partial class GlobalUserChatModule : Form
    {
        public GlobalUserChatModule()
        {
            InitializeComponent();
        }

        private void BuildChat_Database()
        {
            string masterConnection = @"Server=.\SQLEXPRESS;Database=master;Trusted_Connection=True;Encrypt=False;";

            using(SqlConnection connectionOne = new SqlConnection(masterConnection))
            {
                try
                {
                    connectionOne.Open();

                    // 1. Create the Database if it's missing
                    string sqlCreateDB = "IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'PananomChatDB') CREATE DATABASE PananomChatDB;";
                    SqlCommand commandDB = new SqlCommand(sqlCreateDB, connectionOne);
                    commandDB.ExecuteNonQuery();
                    connectionOne.Close();

                    // 2. Now connect to the NEW database to create the table
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
    }
}
