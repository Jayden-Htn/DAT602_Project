using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GameApp
{
    internal class daoAdmin : DataAccess
    {
        /// <summary>
        /// Get active players.
        /// </summary>
        /// <returns>List of player objects.</returns>
        static public List<objPlayer> GetActivePlayers()
        {
            List<objPlayer> playerList = new List<objPlayer>();

            try
            {
                var dataset = MySqlHelper.ExecuteDataset(mySqlConnection, "call GetActivePlayers()");

                foreach (var data in System.Data.DataTableExtensions.AsEnumerable(dataset.Tables[0]))
                {
                    playerList.Add(new objPlayer((int)data["ID"], (string)data["Username"], (int)data["HighestScore"]));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unknown error occurred while getting players: {ex.Message}");
                playerList.Add(new objPlayer(0, "Error", 0)); // Make error placeholder player
            }

            return playerList;
        }

        /// <summary>
        /// Get all games.
        /// </summary>
        /// <returns>List of game objects.</returns>
        static public List<objGame> GetGames()
        {
            List<objGame> gameList = new List<objGame>();

            try
            {
                var dataset = MySqlHelper.ExecuteDataset(mySqlConnection, "call GetGames()");

                foreach (var data in System.Data.DataTableExtensions.AsEnumerable(dataset.Tables[0]))
                {
                    gameList.Add(new objGame((int)data["ID"], (string)data["Username1"], (string)data["Username2"]));
                }
                return gameList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unknown error occurred while getting games: {ex.Message}");
                gameList.Add(new objGame(0, "Error", ""));
            }
            return gameList;
        }
    }
}
