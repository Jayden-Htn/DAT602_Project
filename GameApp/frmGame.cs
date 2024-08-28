using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;

namespace GameApp
{
    public partial class frmGame : Form
    {
        public frmGame()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            GameManager.LoadNewPage("lobby");
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            List<string> tileList = DaoGame.GetMap(1);
            
            lblTest.Text = string.Join(",\n", tileList);
        }
    }
}
