using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public override void LoadData()
        {
            // Load data
            lblPlayer.Text = $"Welcome {GameManager.Username}";
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            GameManager.LoadNewPage("game");
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
