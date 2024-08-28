using MySql.Data.MySqlClient;

namespace GameApp
{
    internal class DataAccess
    {
        private static string connectionString
        {
            get { return "Server=localhost; Port=3306; Database=GameDB; Uid=root; password='root123';"; }
        }

        private static MySqlConnection _mySqlConnection = null;
        public static MySqlConnection mySqlConnection
        {
            get
            {
                if (_mySqlConnection == null)
                {
                    _mySqlConnection = new MySqlConnection(connectionString);
                }
                return _mySqlConnection;
            }
        }
    }
}
