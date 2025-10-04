using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MTODotNetTrainingBatch1.WinFormsApp1
{
    public partial class FrmLogin : Form
    {
        private readonly SqlService _queryService;
        public FrmLogin()
        {
            InitializeComponent();
            _queryService = new SqlService();
            textUsername.Text = "Mya";
            textPassword.Text = "123";
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = textUsername.Text.Trim();
            string password = textPassword.Text.Trim();

            string query = $"select * from tbl_user where Username = @Username and Password = @Password";

            //SqlParameter parameter1 = new SqlParameter("@Username",username);
            //SqlParameter parameter2 = new SqlParameter("@Password", password);
            //List<SqlParameter> parameters = new List<SqlParameter>()
            //{
            //    parameter1,
            //    parameter2,
            //};

            //List<SqlParameter> parameters = new List<SqlParameter>()
            //{
            //    new SqlParameter("@Username",username),
            //    new SqlParameter("@Password", password),
            //};

            //parameters.Add(parameters1);
            //parameters.Add(parameters2);

            //var dt = _queryService.Query(query, parameters);

            var dt = _queryService.Query(
                query,
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password)
                );

            //SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder()
            //{
            //    DataSource = ".",
            //    InitialCatalog = "Purchase",
            //    UserID = "sa",
            //    Password = "sasa@123",
            //    TrustServerCertificate = true
            //};

            //SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
            //connection.Open();

            //DataTable dt = new DataTable();
            //SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("@Username",username);
            //command.Parameters.AddWithValue("@Password",password);

            //SqlDataAdapter adapter = new SqlDataAdapter(command);

            //adapter.Fill(dt);

            //connection.Close();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Login Failed.");
                return;
            }
            MessageBox.Show("Login successful.");

            AppSetting.CurrentUserId = Convert.ToInt32(dt.Rows[0]["Id"]);

            textUsername.Clear();
            textPassword.Clear();

            this.Hide();

            FrmMenu frmMenu = new FrmMenu();
            frmMenu.ShowDialog();

            this.Show();

            textUsername.Focus();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            textUsername.Clear();
            textPassword.Clear();
            textUsername.Focus();
        }

        private void textUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textPassword.Focus();
            }
        }

        private void textPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }
    }
}
