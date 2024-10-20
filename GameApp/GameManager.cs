using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameApp
{
    internal static class GameManager
    {
        private static frmLogin _loginForm = new();
        private static frmLobby _lobbyForm = new();
        private static frmGame _gameForm = new();
        private static frmAdmin _adminForm = new();
        private static Dictionary<string, FormBase> _forms = [];

        private static int _playerID = 0;
        private static string? _username;
        private static bool _admin = false;
        private static int _currentGameID;

        public static int PlayerID { get => _playerID; set => _playerID = value; }
        public static string? Username { get => _username; set => _username = value; }
        public static int CurrentGameID { get => _currentGameID; set => _currentGameID = value; }

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
        public static void LoadNewPage(string newActiveForm, object? data = null)
        {
            foreach (KeyValuePair<string, FormBase> form in _forms)
            {
                form.Value.Hide();
            }
            _forms[newActiveForm].Show();
            _forms[newActiveForm].LoadData(data); // Make sure form has updated data
        }

        /// <summary>
        /// Set local player data.
        /// </summary>
        /// <param name="data">Player data object.</param>
        public static void SetPlayerData(DataRow data)
        {
            PlayerID = Convert.ToInt16(data["ID"]);
            Username = Convert.ToString(data["Username"]);
            _admin = Convert.ToInt16(data["Admin"]) == 1 ? true : false;
        }
    }
}
