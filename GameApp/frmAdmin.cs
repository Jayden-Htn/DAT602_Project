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
    public partial class frmAdmin : FormBase
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void btnListPlayers_Click(object sender, EventArgs e)
        {
            List<string> data = DaoAdmin.GetAllPlayers();
            // string players = string.Join(", ", data);
            lstPlayers.Items.Clear();
            lstPlayers.DataSource = data;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            GameManager.LoadNewPage("lobby");
        }
    }
}
