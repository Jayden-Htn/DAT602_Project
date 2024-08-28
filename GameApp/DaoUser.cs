using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    internal class DaoUser : DataAccess
    {
        static public bool LoginPlayer(string username, string password)
        {
            var dataSet = MySqlHelper.ExecuteDataset(mySqlConnection, $"call LoginPlayer('{username}', '{password}')");
            bool userExists = Convert.ToBoolean((dataSet.Tables[0].Rows[0])["Exists"]);
            return userExists;
        }
    }
}
