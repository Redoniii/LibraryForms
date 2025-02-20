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
    public partial class Menaxhimi : Form
    {
        public Menaxhimi()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();


        public void GetBooks()
        {
            using (SqlConnection conn = ConnectDB.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Bibliographic_Materials", conn);
                    //SqlCommand cmd = new SqlCommand("SELECT DoctorID, FirstName, LastName, Specialization, Phone, Email, de.DepartmentName from Doctors d\r\ninner join Departments de on de.DepartmentID = d.DepartmentID", conn);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    conn.Open();
                    da.Fill(dt);
                    dgvMList.DataSource = dt;
                    //cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
        }


        private void InsertNewBooks()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                    string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                    string.IsNullOrWhiteSpace(txtDOI.Text) ||
                    string.IsNullOrWhiteSpace(txtISBN.Text))
                {
                    MessageBox.Show("Please fill out all required fields.", "HSM");
                    return;
                }
                else
                {
                    dgvMList.DataSource = null;
                    dt.Clear();

                    using (SqlConnection conection = ConnectDB.GetConnection())
                    {
                        try
                        {
                            conection.Open();
                            SqlCommand cmd = new SqlCommand("RegisterBibliographicMaterial", conection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                            cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
                            cmd.Parameters.AddWithValue("@CoAuthors", txtCA.Text);
                            cmd.Parameters.AddWithValue("@Publisher", txtPublisher.Text);
                            cmd.Parameters.AddWithValue("@PublicationDate", dtpPDate.Value); // Use DateTimePicker.Value
                            cmd.Parameters.AddWithValue("@ISBN", txtISBN.Text);
                            cmd.Parameters.AddWithValue("@DOI", txtDOI.Text);
                            cmd.Parameters.AddWithValue("@Abstract", txtAbstract.Text);
                            cmd.Parameters.AddWithValue("@MaterialType", cmbMaterialType.Text);
                            cmd.Parameters.AddWithValue("@AvailableCopies", Convert.ToInt32(numCopies.Value)); // Numeric value
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data has been Added", "Save");
                            GetBooks();


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


        private void UpdateMaterials()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                    string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                    string.IsNullOrWhiteSpace(txtISBN.Text))
                {
                    MessageBox.Show("Please fill out all required fields.", "HSM");
                    return;
                }
                else
                {
                    dgvMList.DataSource = null;
                    dt.Clear();

                    using (SqlConnection conection = ConnectDB.GetConnection())
                    {
                        try
                        {
                            conection.Open();
                            SqlCommand cmd = new SqlCommand("UpdateMaterial", conection);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Material_ID", this.txtMaterialID.Text);
                            cmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                            cmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
                            cmd.Parameters.AddWithValue("@Co_Authors", txtCA.Text);
                            cmd.Parameters.AddWithValue("@Publisher", txtPublisher.Text);
                            cmd.Parameters.AddWithValue("@Publication_Date", dtpPDate.Value);
                            cmd.Parameters.AddWithValue("@ISBN", txtISBN.Text);
                            cmd.Parameters.AddWithValue("@DOI", txtDOI.Text);
                            cmd.Parameters.AddWithValue("@Material_Type", cmbMaterialType.Text);
                            cmd.Parameters.AddWithValue("@Available_Copies", Convert.ToInt32(numCopies.Value)); // Numeric value
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data has been Added", "Save");
                            GetBooks();
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


        private void Menaxhimi_Load(object sender, EventArgs e)
        {
            GetBooks();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InsertNewBooks();
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            string fillerText = txtSearchName.Text.ToLower();
            if (!string.IsNullOrEmpty(fillerText))
            {
                DataView dataView = new DataView(dt);
                dataView.RowFilter = $"Author like '%{fillerText}%'";
                dgvMList.DataSource = dataView;
            }
            else
            {
                dgvMList.DataSource = dt;
            }
        }


        private void ClearFields()
        {
            txtMaterialID.Clear();
            txtTitle.Clear();
            txtAuthor.Clear();
            txtCA.Clear();
            dtpPDate.Value = DateTime.Now;
            txtPublisher.Clear();
            txtISBN.Clear();
            txtDOI.Clear();
            cmbMaterialType.SelectedIndex = -1;
            txtAbstract.Clear();
            numCopies.Select();
        }

        private void dgvMList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;

            txtMaterialID.Text = dgvMList.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTitle.Text = dgvMList.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtAuthor.Text = dgvMList.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtCA.Text = dgvMList.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtPublisher.Text = dgvMList.Rows[e.RowIndex].Cells[4].Value.ToString();
            dtpPDate.Text = dgvMList.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtISBN.Text = dgvMList.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtDOI.Text = dgvMList.Rows[e.RowIndex].Cells[7].Value.ToString();
            cmbMaterialType.Text = dgvMList.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtAbstract.Text = dgvMList.Rows[e.RowIndex].Cells[9].Value.ToString();
            numCopies.Text = dgvMList.Rows[e.RowIndex].Cells[10].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateMaterials();
        }

        private void cmbMaterialType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}



//private void GetMaterial()
//{
//    using (SqlConnection conection = ConnectDB.GetConnection())
//    {
//        try
//        {
//            conection.Open();
//            SqlCommand cmd = new SqlCommand("SELECT Material_Type from Bibliographic_Materials", conection);
//            // cmd.CommandType = CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("@Material_Type", cmbMaterialType.Text);
//            cmd.ExecuteNonQuery();
//            //MessageBox.Show("Data has been Added", "Save");
//            //GetBooks();


//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

//        }

//    }
//}
