using MySql.Data.MySqlClient;

namespace GameApp
{
    public partial class frmLogin : Form
    {
        private MySql.Data.MySqlClient.MySqlConnection MySqlConnection;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String password = txtPassword.Text;
            string data = DaoUser.Login(username, password);
            DialogResult = MessageBox.Show($"User exists: {data}");

            txtUsername.Text = "";
            txtPassword.Text = "";

            GameManager.LoadNewPage("lobby");
        }
    }
}
