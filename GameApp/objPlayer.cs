using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    internal class objPlayer
    {
        private int _id;
        private string _username;
        private int _highestScore;

        public int ID { get => _id; set => _id = value; }
        public string Username { get => _username; set => _username = value; }
        public int HighestScore { get => _highestScore; set => _highestScore = value; }

        public objPlayer(int id, string username, int highestScore)
        {
            ID = id;
            Username = username;
            HighestScore = highestScore;
        }

        public override string ToString()
        {
            return string.Format($"{Username}, {HighestScore}");
        }
    }
}
