using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryForms
{
    public partial class Klientet : Form
    {
        public Klientet()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();

        public void GetClients()
        {
            using (SqlConnection conn = ConnectDB.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Clients", conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    conn.Open();
                    da.Fill(dt);
                    dgvLKlientet.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
        }


        private void UpdateClients()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFName.Text) ||
                    string.IsNullOrWhiteSpace(txtLName.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Please fill out all required fields.", "HSM");
                    return;
                }
                else
                {
                    dgvLKlientet.DataSource = null;
                    dt.Clear();

                    using (SqlConnection conection = ConnectDB.GetConnection())
                    {
                        try
                        {
                            conection.Open();
                            SqlCommand cmd = new SqlCommand("UpdateClients", conection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Client_ID", this.txtKID.Text);
                            cmd.Parameters.AddWithValue("@First_Name", txtFName.Text);
                            cmd.Parameters.AddWithValue("@Last_Name", txtLName.Text);
                            cmd.Parameters.AddWithValue("@Date_Of_Birth", dtpBirth.Value);
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text); // Use DateTimePicker.Value
                            cmd.Parameters.AddWithValue("@Address", txtAddress.Text); // Numeric value
                            cmd.Parameters.AddWithValue("@Membership_Active", cmbActive.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data has been Added", "Save");
                            GetClients();
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


        private void InsertNewClients()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFName.Text) ||
                    string.IsNullOrWhiteSpace(txtLName.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("Please fill out all required fields.", "HSM");
                    return;
                }
                else
                {
                    dgvLKlientet.DataSource = null;
                    dt.Clear();

                    using (SqlConnection conection = ConnectDB.GetConnection())
                    {
                        try
                        {
                            conection.Open();
                            SqlCommand cmd = new SqlCommand("RegisterClient", conection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@FirstName", txtFName.Text);
                            cmd.Parameters.AddWithValue("@LastName", txtLName.Text);
                            cmd.Parameters.AddWithValue("@DateOfBirth", dtpBirth.Value);
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text); // Use DateTimePicker.Value
                            cmd.Parameters.AddWithValue("@Address", txtAddress.Text); // Numeric value
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data has been Added", "Save");
                            GetClients();


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


        private void btnSave_Click(object sender, EventArgs e)
        {
            InsertNewClients();
        }
        
        private void cmbStauts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Klientet_Load(object sender, EventArgs e)
        {
            GetClients();
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            string fillerText = txtSearchName.Text.ToLower();
            if (!string.IsNullOrEmpty(fillerText))
            {
                DataView dataView = new DataView(dt);
                dataView.RowFilter = $"First_Name like '%{fillerText}%'";
                dgvLKlientet.DataSource = dataView;
            }
            else
            {
                dgvLKlientet.DataSource = dt;
            }
        }

        private void dgvLKlientet_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;

            txtKID.Text = dgvLKlientet.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtFName.Text = dgvLKlientet.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtLName.Text = dgvLKlientet.Rows[e.RowIndex].Cells[2].Value.ToString();
            dtpBirth.Text = dgvLKlientet.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtEmail.Text = dgvLKlientet.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtPhone.Text = dgvLKlientet.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtAddress.Text = dgvLKlientet.Rows[e.RowIndex].Cells[6].Value.ToString();
            cmbActive.Text = dgvLKlientet.Rows[e.RowIndex].Cells[7].Value.ToString();

        }


        private void ClearFields()
        {
            txtKID.Clear();
            txtFName.Clear();
            txtLName.Clear();
            dtpBirth.Value = DateTime.Now;
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            cmbActive.SelectedIndex = -1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateClients();
        }
    }
}
