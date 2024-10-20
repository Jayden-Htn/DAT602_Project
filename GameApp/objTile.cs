using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    internal class objTile
    {
        private int _id;
        private int _mapID;
        private int _colPosition;
        private int _rowPosition;
        private string _tileType;

        public objTile(int id, int mapId, int colPosition, int rowPosition, string tileType)
        {
            _id = id;
            _mapID = mapId;
            _colPosition = colPosition;
            _rowPosition = rowPosition;
            _tileType = tileType;
        }

        public override string ToString()
        {
            return string.Format($"ID: {_id}, MapID: {_mapID}, Col: {_colPosition}, Row: {_rowPosition}, Type: {_tileType}");
        }
    }
}
