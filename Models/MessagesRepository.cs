﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SRTest.SignalR.Hubs;
using Orchard;

namespace SRTest.SignalR.Models {
    public class MessagesRepository {
        //private readonly IOrchardServices services;
        private readonly string _connString = "Data Source = CNS; Initial Catalog = BlogDemos; Integrated Security = True;"; //ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public IEnumerable<Messages> GetAllMessages() {
            var messages = new List<Messages>();
            using (var connection = new SqlConnection(_connString)) {
                connection.Open();
                using (var command = new SqlCommand(@"SELECT [MessageID], [Message], [EmptyMessage], [Date] FROM [dbo].[Messages]", connection)) {
                    command.Notification = null;

                    var dependency = new SqlDependency(command);
                    dependency.OnChange += (dependency_OnChange); //new OnChangeEventHandler

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read()) {
                        messages.Add(new Messages {MessageID = (int) reader["MessageID"], Message = (string) reader["Message"], EmptyMessage = reader["EmptyMessage"] != DBNull.Value ? (string) reader["EmptyMessage"] : "", MessageDate = Convert.ToDateTime(reader["Date"])});
                    }
                }

            }
            return messages;
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e) {
            if (e.Type == SqlNotificationType.Change) {
                //MessagesHub test = new MessagesHub(services);
                //test.SendMessages();
                MessagesHub.SendMessages();
            }
        }
    }
}