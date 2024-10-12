using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApp
{
    internal static class GameManager
    {
        private static frmLogin _loginForm = new frmLogin();
        private static frmLobby _lobbyForm = new frmLobby();
        private static frmGame _gameForm = new frmGame();
        private static frmAdmin _adminForm = new frmAdmin();
        private static Dictionary<string, Form> _forms = new Dictionary<string, Form>();

        private static int _playerID = 0;
        private static int _gameID;
        private static string? _username;
        private static bool _admin = false;
        private static int _highScore = 0;

        public static int PlayerID { get => _playerID; set => _playerID = value; }

        /// <summary>
        /// Create form array and loan login form.
        /// </summary>
        /// <returns>Login form.</returns>
        public static frmLogin LoadLogin()
        {
            _forms.Add("login", _loginForm);
            _forms.Add("lobby", _lobbyForm);
            _forms.Add("game", _gameForm);
            _forms.Add("admin", _adminForm);

            _forms["login"].Show();
            return _loginForm;
        }

        /// <summary>
        /// Load a new page from the form dictionary.
        /// </summary>
        /// <param name="newActiveForm">String key in forms dictionary.</param>
        public static void LoadNewPage(string newActiveForm)
        {
            foreach (KeyValuePair<string, Form> form in _forms)
            {
                form.Value.Hide();
            }
            _forms[newActiveForm].Show();
        }

        /// <summary>
        /// Set local player data.
        /// </summary>
        /// <param name="data">Player data object.</param>
        public static void SetPlayerData(DataRow data)
        {
            PlayerID = Convert.ToInt16(data["ID"]);
            _username = Convert.ToString(data["Username"]);
            _admin = Convert.ToInt16(data["Admin"]) == 1 ? true : false;
            _highScore = Convert.ToInt16(data["HighScore"]);
        }
    }
}
