using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GameApp
{
    public partial class frmLobby : FormBase
    {
        public frmLobby()
        {
            InitializeComponent();
        }

        public override void LoadData(object? data = null)
        {
            // Load data
            lblPlayer.Text = $"Welcome {GameManager.Username}";
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            // Would get ID of opponent player selected, defaulting to player 2 for now
            int opponentPlayerID = 2;

            // Find game with both self ID and opponent ID
            object result = DaoGame.FindGame(GameManager.PlayerID, opponentPlayerID); 
            
            // Result is DataRow if found game, string if not
            if (result is string message)
            {
                // No game found, start new game
                result = DaoGame.NewGame(GameManager.PlayerID, opponentPlayerID);
            }

            DataRow data = (DataRow)result; // Convert objects to DataRow
            GameManager.LoadNewPage("game", data);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            GameManager.LoadNewPage("admin");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            GameManager.LoadNewPage("login");
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnInvite_Click(object sender, EventArgs e)
        {

        }
    }
}
