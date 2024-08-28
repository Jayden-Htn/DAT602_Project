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
            String userName = txtUsername.Text;
            String password = txtPassword.Text;
            DialogResult = MessageBox.Show("Button clicked.");
        }
    }
}
