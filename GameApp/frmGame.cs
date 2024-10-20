using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;

namespace GameApp
{
    public partial class frmGame : FormBase
    {
        private int _gameID;
        private int _mapID;

        private int _characterID;
        private int _colPosition = 1;
        private int _rowPosition = 1;
        private int _score = 0;
        private int _health;

        private List<objTile> _mapTiles;

        public frmGame()
        {
            InitializeComponent();
        }

        public override void LoadData(object? data = null)
        {
            // Set local variables
            if (data is DataRow details)
            {
                _characterID = Convert.ToInt16(details["CharacterID"]);
                _mapID = Convert.ToInt16(details["MapID"]);
                _gameID = Convert.ToInt16(details["GameID"]);
                _colPosition = Convert.ToInt16(details["ColPosition"]);
                _rowPosition = Convert.ToInt16(details["RowPosition"]);
                _score = Convert.ToInt16(details["Score"]);
                _health = Convert.ToInt16(details["CurrentHealth"]);

                UpdateBoard();
            }
        }

        private void UpdateBoard()
        {
            // Get board
            List<objTile> tileList = daoGame.GetMap(_characterID, _gameID);

            // Get character stats
            var details = daoGame.GetCharacterData(_characterID);
            _colPosition = Convert.ToInt16(details["ColPosition"]);
            _rowPosition = Convert.ToInt16(details["RowPosition"]);
            _score = Convert.ToInt16(details["Score"]);
            _health = Convert.ToInt16(details["CurrentHealth"]);

            // Display on screen
            _mapTiles = tileList.ToList();
            lblTest.Text = string.Join(",\n", tileList);
            lblPlayerPosition.Text = $"Player position: {_colPosition}, {_rowPosition}";
            lblHealth.Text = _health.ToString();
            lblScore.Text = _score.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            GameManager.LoadNewPage("lobby");
        }

        private void btnMoveCharacter_Click(object sender, EventArgs e)
        {
            int newCol = _colPosition + 1;
            var result = daoGame.MovePlayer(_characterID, _gameID, newCol, _rowPosition);
            UpdateBoard();
        }

        private void btnMoveCharacter2_Click(object sender, EventArgs e)
        {
            int newRow = _rowPosition + 1;
            var result = daoGame.MovePlayer(_characterID, _gameID, _colPosition, newRow);
            UpdateBoard();
        }

        private void btnInteract_Click(object sender, EventArgs e)
        {
            var result = daoGame.TileInteract(_characterID, _gameID, _colPosition, _rowPosition);
            UpdateBoard();
        }

        private void btnMoveNpcs_Click(object sender, EventArgs e)
        {
            var response = daoGame.NpcMove(_mapID);
            MessageBox.Show(response);
            UpdateBoard();
        }
    }
}
