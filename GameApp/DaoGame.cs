using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    internal class DaoGame : DataAccess
    {
        static public List<string> GetMap(int mapId)
        {
            var data = MySqlHelper.ExecuteDataset(mySqlConnection, $"call GetMap('{mapId}')");

            List<string> tileList = new List<string>();

            foreach (var tile in System.Data.DataTableExtensions.AsEnumerable(data.Tables[0]))
            {
                tileList.Add($"ID: {tile["ID"]}, Type: {tile["TileTypeName"]}, Col: {tile["ColumnPosition"]}, Row: {tile["RowPosition"]}");
            }

            return tileList;
        }
    }
}
