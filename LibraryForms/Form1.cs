using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryForms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conection = ConnectDB.GetConnection())

                {
                    conection.Open();
                    SqlCommand cmd = new SqlCommand("VerifyUserWithRole", conection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //string query = "SELECT COUNT(*) FROM Users WHERE Username=@Username AND Password=@Password AND Role=@Role";
                    //SqlCommand cmd = new SqlCommand(query, conection);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@Password", txtpsw.Text);
                    cmd.Parameters.AddWithValue("@Role", "Admin");

                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        Panel panel = new Panel();
                        panel.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Wrong username or password or you are not an Admin", "Alert");
                        txtUsername.Clear();
                        txtpsw.Clear();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL Error: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtpsw.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txtpsw_TextChanged(object sender, EventArgs e)
        {
            txtpsw.PasswordChar = '*';
        }
    }
}
