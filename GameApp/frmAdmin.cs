using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GameApp
{
    public partial class frmAdmin : FormBase
    {
        private List<objPlayer> _playerObjects = [];
        private List<string> _playerStrings = [];
        private List<objGame> _gameObjects = [];
        private List<string> _gameStrings = [];

        public frmAdmin()
        {
            InitializeComponent();
        }

        public override void LoadData(object? data = null)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            // List active players
            _playerObjects = daoAdmin.GetActivePlayers();
            _playerStrings.Clear();
            foreach (objPlayer player in _playerObjects)
            {
                _playerStrings.Add(player.ToString());
            }
            lstPlayers.DataSource = null;
            lstPlayers.DataSource = _playerStrings;

            // List games
            _gameObjects = daoAdmin.GetGames();
            _gameStrings.Clear();
            foreach (objGame game in _gameObjects)
            {
                _gameStrings.Add(game.ToString());
            }
            lstGames.DataSource = null;
            lstGames.DataSource = _gameStrings;
        }

        private void btnEditPlayer_Click(object sender, EventArgs e)
        {
            daoUser.UpdatePlayer(1, "SuperVader", null, null, null, null);
            UpdateData();
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            daoUser.Register("MegaX", "Password123");
            MessageBox.Show("New user created", "User Creation");
            UpdateData();
        }

        private void btnDeletePlayer_Click(object sender, EventArgs e)
        {
            int index = lstPlayers.SelectedIndex;
            objPlayer player = _playerObjects[index];
            daoUser.DeletePlayer(player.ID);
            UpdateData();
        }

        private void btnEndGame_Click(object sender, EventArgs e)
        {
            int index = lstGames.SelectedIndex;
            objGame game = _gameObjects[index];
            daoGame.StopGame(game.ID);
            UpdateData();
        }

        private void btnEndAllGames_Click(object sender, EventArgs e)
        {
            daoGame.StopGame(null);
            UpdateData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GameManager.LoadNewPage("lobby");
        }
    }
}

