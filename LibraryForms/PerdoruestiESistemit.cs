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
    public partial class PerdoruestiESistemit : Form
    {
        public PerdoruestiESistemit()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();


        public void GetUsers()
        {
            using (SqlConnection conn = ConnectDB.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Users", conn);
                    //SqlCommand cmd = new SqlCommand("SELECT DoctorID, FirstName, LastName, Specialization, Phone, Email, de.DepartmentName from Doctors d\r\ninner join Departments de on de.DepartmentID = d.DepartmentID", conn);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    conn.Open();
                    da.Fill(dt);
                    dgvPerdoruesit.DataSource = dt;
                    //cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
        }


        private void InsertNewUsers()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUserName.Text) ||
                    string.IsNullOrWhiteSpace(txtPsw.Text) ||
                    string.IsNullOrWhiteSpace(cmbRoli.Text))
                {
                    MessageBox.Show("Please fill out all required fields.", "HSM");
                    return;
                }
                else
                {
                    dgvPerdoruesit.DataSource = null;
                    dt.Clear();

                    using (SqlConnection conection = ConnectDB.GetConnection())
                    {
                        try
                        {
                            conection.Open();
                            SqlCommand cmd = new SqlCommand("AddUser", conection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                            cmd.Parameters.AddWithValue("@Password", txtPsw.Text);
                            cmd.Parameters.AddWithValue("@Role", cmbRoli.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data has been Added", "Save");
                            GetUsers();


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }
                }
            }
            catch
            {

            }
        }


        private void UpdateUsers()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUserName.Text) ||
                    string.IsNullOrWhiteSpace(txtPsw.Text) ||
                    string.IsNullOrWhiteSpace(cmbRoli.Text))
                {
                    MessageBox.Show("Please fill out all required fields.", "HSM");
                    return;
                }
                else
                {
                    dgvPerdoruesit.DataSource = null;
                    dt.Clear();

                    using (SqlConnection conection = ConnectDB.GetConnection())
                    {
                        try
                        {
                            conection.Open();
                            SqlCommand cmd = new SqlCommand("UpdateUsers", conection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@UserID", this.txtUID.Text);
                            cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                            cmd.Parameters.AddWithValue("@Password", txtPsw.Text);
                            cmd.Parameters.AddWithValue("@Role", cmbRoli.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data has been Added", "Save");
                            GetUsers();
                            btnSave.Enabled = true;
                            btnUpdate.Enabled = false;
                            ClearFields();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }
                }
            }
            catch
            {

            }
        }




        private void PerdoruestiESistemit_Load(object sender, EventArgs e)
        {
            GetUsers();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InsertNewUsers();
        }

        private void dgvPerdoruesit_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;

            txtUID.Text = dgvPerdoruesit.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtUserName.Text = dgvPerdoruesit.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPsw.Text = dgvPerdoruesit.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmbRoli.Text = dgvPerdoruesit.Rows[e.RowIndex].Cells[3].Value.ToString();
           
        }


        private void ClearFields()
        {
            txtUID.Clear();
            txtUserName.Clear();
            txtPsw.Clear();
            cmbRoli.SelectedIndex = -1;
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateUsers();
        }
    }
}
