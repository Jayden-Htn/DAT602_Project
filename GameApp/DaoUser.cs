using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameApp
{
    internal class daoUser : DataAccess
    {
        /// <summary>
        /// Log into an existing account.
        /// </summary>
        /// <param name="username">Username of the player.</param>
        /// <param name="password">Password of the player.</param>
        /// <returns></returns>
        static public string Login(string username, string password)
        {
            var dataSet = MySqlHelper.ExecuteDataset(mySqlConnection, 
                $"call Login('{username}', '{password}')");
            string? message = (dataSet.Tables[0].Rows[0])["Message"].ToString();
            return String.IsNullOrEmpty(message) ? "No message" : message;
        }

        /// <summary>
        /// Register a new account.
        /// </summary>
        /// <param name="username">Unique username.</param>
        /// <param name="password">Password to set.</param>
        /// <returns></returns>
        static public string Register(string username, string password)
        {
            var dataSet = MySqlHelper.ExecuteDataset(mySqlConnection, 
                $"call Register('{username}', '{password}')");
            string? message = (dataSet.Tables[0].Rows[0])["Message"].ToString();
            return String.IsNullOrEmpty(message) ? "No message" : message;
        }

        /// <summary>
        /// Update a player account's details.
        /// </summary>
        /// <param name="playerID">Player ID to change.</param>
        /// <param name="username">New username or null.</param>
        /// <param name="password">New password or null.</param>
        /// <param name="locked">New locked bit or null.</param>
        /// <param name="admin">New admin bit or null.</param>
        /// <param name="highScore">New high score or null.</param>
        /// <returns></returns>
        static public DataRow UpdatePlayer(int playerID, string? username, string? password, 
            int? locked, int? admin, int? highScore)
        {
            // Process null values (Doesn't accept C# null)
            var strUsername = string.IsNullOrEmpty(username) ? "null" : "'" + username + "'";
            var strPassword = string.IsNullOrEmpty(password) ? "null" : "'" + password + "'";
            var strLocked = locked.HasValue ? locked.Value.ToString() : "null";
            var strAdmin = admin.HasValue ? admin.Value.ToString() : "null";
            var strHighScore = highScore.HasValue ? highScore.Value.ToString() : "null";
            DataRow? message;

            try
            {
                var dataSet = MySqlHelper.ExecuteDataset(mySqlConnection,
                $"call UpdatePlayer('{playerID}', {strUsername}, {strPassword}, {strLocked}, " +
                $"{strAdmin}, {strHighScore})");
                message = (dataSet.Tables[0].Rows[0]);
                if (message.Table.Columns.Contains("Message"))
                {
                    string message2 = (string)(dataSet.Tables[0].Rows[0])["Message"];
                    if (message2.Substring(0, 5) == "Error")
                    {
                        throw new Exception(message2.Substring(7));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unknown error occurred while updating player:", ex.ToString());
                DataTable errorTable = new DataTable();
                errorTable.Columns.Add("Message");
                message = errorTable.NewRow();
                message["Message"] = "Error";
            }
            return message;
        }
        
        /// <summary>
        /// Delete a player account and all related data.
        /// </summary>
        /// <param name="playerID">Player's ID.</param>
        /// <returns></returns>
        static public string DeletePlayer(int playerID)
        {
            string message = "";

            try
            {
                var dataSet = MySqlHelper.ExecuteDataset(mySqlConnection, $"call DeletePlayer('{playerID}')");
                message = (string)(dataSet.Tables[0].Rows[0])["Message"];
                if (message.Substring(0, 5) == "Error")
                {
                    throw new Exception(message.Substring(7));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unknown error occurred while deleting player:", ex.ToString());
                message = "Error";
            }
            return message;
        }
    }
}
