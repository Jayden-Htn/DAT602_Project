using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;

namespace GameApp
{
    public partial class frmLogin : FormBase
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
            string data = daoUser.Login(username, password);

            txtUsername.Text = "";
            txtPassword.Text = "";

            // Handle login message
            if (int.TryParse(data, out int ID))
            {
                LoadLobby(ID); // Success, got player id, load lobby
            }
            else
            {
                switch (data)
                {
                    case "Invalid credentials":
                        MessageBox.Show("Your email or password is incorrect.", "Invalid credentials", 
                            MessageBoxButtons.OK);
                        break;
                    case "No account":
                        DialogResult response = MessageBox.Show("No account found. Would you like to register " +
                            "as a new account?", "Register?", MessageBoxButtons.OKCancel);
                        if (response == DialogResult.OK)
                        {
                            string res = daoUser.Register(username, password);
                            if (int.TryParse(res, out int newID))
                            {
                                LoadLobby(newID); // Load lobby with new player
                            }
                            else
                            {
                                MessageBox.Show("Error making account.", res, MessageBoxButtons.OK);
                            }
                        }
                        break;
                    case "Locked out":
                        MessageBox.Show("Your account is locked. Please contact an administrator at " +
                            "admin@survivorisland.com.", "Locked out", MessageBoxButtons.OK);
                        break;
                    default:
                        MessageBox.Show("Error: " + data, "Unknown Error", MessageBoxButtons.OK);
                        break;
                }
            }

        }

        /// <summary>
        /// Handle setting local data and loading lobby on successful login.
        /// </summary>
        /// <param name="ID">Player ID.</param>
        private void LoadLobby(int ID)
        {
            // Use update with all nulls as a get
            DataRow playerData = daoUser.UpdatePlayer(ID, null, null, null, null, null);
            GameManager.SetPlayerData(playerData);
            GameManager.LoadNewPage("lobby");
        }
    }
}
