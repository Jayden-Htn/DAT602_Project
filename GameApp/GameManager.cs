using System;
using System.Collections.Generic;
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

        public static frmLogin LoadLogin()
        {
            _forms.Add("login", _loginForm);
            _forms.Add("lobby", _lobbyForm);
            _forms.Add("game", _gameForm);
            _forms.Add("admin", _adminForm);

            _forms["login"].Show();
            return _loginForm;
        }

        public static void LoadNewPage(string newActiveForm)
        {
            foreach (KeyValuePair<string, Form> form in _forms)
            {
                form.Value.Hide();
            }
            _forms[newActiveForm].Show();
        }
    }
}
