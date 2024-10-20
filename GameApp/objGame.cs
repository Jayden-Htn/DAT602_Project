using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    internal class objGame
    {
        private int _id;
        private string _username1;
        private string _username2;

        public int ID { get => _id; set => _id = value; }

        public objGame(int id, string username1, string username2)
        {
            ID = id;
            _username1 = username1;
            _username2 = username2;
        }

        public override string ToString()
        {
            return string.Format($"{_username1} vs {_username2}");
        }
    }
}
