using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace i_HPS
{
    public partial class Login : MetroForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=IT68;Initial Catalog=iHPS;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select role from login where Username='" + txtUserName.Text + "' and password='" + txtPassword.Text + "'", con);
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count==1)
            {
                Dboard ds = new Dboard();
                ds.Show();
                this.Hide();
            }
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            Forgot_Password fp = new Forgot_Password();
            fp.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'iHPSDataSet.Login' table. You can move, or remove it, as needed.
            this.loginTableAdapter.Fill(this.iHPSDataSet.Login);

        }
    }
}
