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
    internal class DaoAdmin : DataAccess
    {
        static public List<string> GetAllPlayers()
        {
            var data = MySqlHelper.ExecuteDataset(mySqlConnection, "call GetAllPlayers()");
            
            List<string> playerList = new List<string>();
            
            foreach (var player in System.Data.DataTableExtensions.AsEnumerable(data.Tables[0]))
            {
                playerList.Add(player["Username"].ToString());
            }

            return playerList;
        }
    }
}
