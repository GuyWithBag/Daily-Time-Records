﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Daily_Time_Records.Repositories
{
    class UserRepository
    {
        string _connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        public bool IsValidUser(string username, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE username = @username AND password = SHA1(@password)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public string getUserRole(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT role FROM users WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                object execute = cmd.ExecuteScalar();
                return execute.ToString();
            }
        }

        public void LogLogin(string username)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string query = "INSERT INTO login_log (username, login_time) VALUES (@username, @loginTime)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@loginTime", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
