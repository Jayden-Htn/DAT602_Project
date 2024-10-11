using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    internal class DaoGame : DataAccess
    {
        /// <summary>
        /// Get map tiles around a player.
        /// </summary>
        /// <param name="mapID">Map ID for the game.</param>
        /// <param name="playerID">Player to get tiles around.</param>
        /// <returns></returns>
        static public List<Tile> GetMap(int mapID, int playerID)
        {
            var data = MySqlHelper.ExecuteDataset(mySqlConnection, $"call Layout('{mapID}', '{playerID}')");

            // Create list of tiles
            List<Tile> tileList = new List<Tile>();
            foreach (var tile in System.Data.DataTableExtensions.AsEnumerable(data.Tables[0]))
            {
                tileList.Add(new Tile((int)tile["ID"], (int)tile["MapID"], (int)tile["ColPosition"], 
                    (int)tile["RowPosition"], (string)tile["TileTypeName"]));
            }
            return tileList;
        }

        /// <summary>
        /// Generate a new map for a new game.
        /// </summary>
        /// <param name="gameID">Game ID to generate a map for.</param>
        /// <returns></returns>
        static public List<Tile> GenerateMap(int gameID)
        {
            var data = MySqlHelper.ExecuteDataset(mySqlConnection, $"call GenerateMap('{gameID}')");

            // Create list of tiles
            List<Tile> tileList = new List<Tile>();
            foreach (var tile in System.Data.DataTableExtensions.AsEnumerable(data.Tables[0]))
            {
                tileList.Add(new Tile((int)tile["ID"], (int)tile["MapID"], (int)tile["ColPosition"], 
                    (int)tile["RowPosition"], (string)tile["TileTypeName"]));
            }
            return tileList;

        }

        /// <summary>
        /// Move character/player in game to valid tile.
        /// </summary>
        /// <param name="characterID">Character's ID.</param>
        /// <param name="gameID">Game's ID.</param>
        /// <param name="newCol">Column position the player is moving to.</param>
        /// <param name="newRow">Row position the player is moving to.</param>
        /// <returns></returns>
        static public string MovePlayer(int characterID, int gameID, int newCol, int newRow)
        {
            var data = MySqlHelper.ExecuteDataset(mySqlConnection, 
                $"call MovePlayer('{characterID}', '{gameID}', '{newCol}', '{newRow}')");
            string message = (string)(data.Tables[0].Rows[0])["Message"];
            return message;
        }

        /// <summary>
        /// Update the score of a character.
        /// </summary>
        /// <param name="characterID">Character's ID to update.</param>
        /// <param name="scoreChange">Amount to change the score by.</param>
        /// <returns></returns>
        static public string UpdateScore(int characterID, int scoreChange)
        {
            var data = MySqlHelper.ExecuteDataset(mySqlConnection, 
                $"call UpdateScore('{characterID}', '{scoreChange}')");
            string message = (string)(data.Tables[0].Rows[0])["Message"];
            return message;
        }

        /// <summary>
        /// Player interacts with a tile.
        /// </summary>
        /// <param name="characterID">Character's ID</param>
        /// <param name="mapID">Map ID.</param>
        /// <param name="colPos">Column of the tile to interact with.</param>
        /// <param name="rowPos">Row of the tile to interact with.</param>
        /// <returns></returns>
        static public string TileInteract(int characterID, int mapID, int colPos, int rowPos)
        {
            var data = MySqlHelper.ExecuteDataset(mySqlConnection, 
                $"call TileInteract('{characterID}', '{mapID}', '{colPos}', '{rowPos}')");
            string message = (string)(data.Tables[0].Rows[0])["Message"];
            return message;
        }

        /// <summary>
        /// Move all NPCs in a map.
        /// </summary>
        /// <param name="mapID">Map ID.</param>
        /// <returns></returns>
        static public string NpcMove(int mapID)
        {
            var data = MySqlHelper.ExecuteDataset(mySqlConnection, $"call NpcMove('{mapID}')");
            string? message = (data.Tables[0].Rows[0])["Message"].ToString();
            return !String.IsNullOrEmpty(message) ? message : "No Message";
        }

        /// <summary>
        /// Stop one or all games.
        /// </summary>
        /// <param name="gameID">Game ID or enter null to stop all games.</param>
        /// <returns></returns>
        static public string StopGame(int? gameID)
        {
            var strGameID = gameID.HasValue ? gameID.Value.ToString() : "null"; // Doesn't accept null
            var data = MySqlHelper.ExecuteDataset(mySqlConnection, $"call StopGame({strGameID})");
            string message = (string)(data.Tables[0].Rows[0])["Message"];
            return message;
        }
    }
}
