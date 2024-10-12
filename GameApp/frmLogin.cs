using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace GameApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Get inputs and attempt login
            String username = txtUsername.Text;
            String password = txtPassword.Text;
            string data = DaoUser.Login(username, password);

            txtUsername.Text = "";
            txtPassword.Text = "";

            // Handle login message
            if (int.TryParse(data, out int ID))
            {
                // Success, got player id
                LoadLobby(ID);
            }
            else if (data == "Invalid credentials")
            {
                MessageBox.Show("Your email or password is incorrect.", data, MessageBoxButtons.OK);
            }
            else if (data == "No account")
            {
                DialogResult response = MessageBox.Show("No account found. Would you like to register as a new account?", 
                    "Register?", MessageBoxButtons.OKCancel);
                if (response == DialogResult.OK)
                {
                    string res = DaoUser.Register(username, password);
                    if (int.TryParse(res, out int newID))
                    {
                        // Load lobby with new player
                        LoadLobby(newID);
                    } else
                    {
                        MessageBox.Show("Error making account.", res, MessageBoxButtons.OK);
                    };
                }
            }
            else if (data == "Locked out")
            {
                MessageBox.Show("Your account is locked, please contact an administrator at admin@survivorisland.com."
                    , data, MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Error: ", data, MessageBoxButtons.OK);
            } 
        }

        /// <summary>
        /// Handle setting local data and loading lobby on successful login.
        /// </summary>
        /// <param name="ID">Player ID.</param>
        private void LoadLobby(int ID)
        {
            // Use update with all nulls as a get
            DataRow playerData = DaoUser.UpdatePlayer(ID, null, null, null, null, null);
            GameManager.SetPlayerData(playerData);
            GameManager.LoadNewPage("lobby");
        }
    }
}
