using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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
            var dataset = MySqlHelper.ExecuteDataset(mySqlConnection, "call GetActivePlayers()");
            
            List<objPlayer> playerList = new List<objPlayer>();
            foreach (var data in System.Data.DataTableExtensions.AsEnumerable(dataset.Tables[0]))
            {
                playerList.Add(new objPlayer((int)data["ID"], (string)data["Username"], (int)data["HighestScore"]));
            }
            return playerList;
        }

        /// <summary>
        /// Get all games.
        /// </summary>
        /// <returns>List of game objects.</returns>
        static public List<objGame> GetGames()
        {
            var dataset = MySqlHelper.ExecuteDataset(mySqlConnection, "call GetGames()");

            List<objGame> gameList = new List<objGame>();
            foreach (var data in System.Data.DataTableExtensions.AsEnumerable(dataset.Tables[0]))
            {
                gameList.Add(new objGame((int)data["ID"], (string)data["Username1"], (string)data["Username2"]));
            }
            return gameList;
        }
    }
}
