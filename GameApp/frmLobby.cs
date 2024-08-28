using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameApp
{
    public partial class frmLobby : Form
    {
        public frmLobby()
        {
            InitializeComponent();
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
    }
}
