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
    public partial class HuazimetEMaterialeve : Form
    {
        public HuazimetEMaterialeve()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();


        private void GetKlientet()
        {
            using (SqlConnection conn = ConnectDB.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT Client_ID, CONCAT(First_Name, ' ', Last_Name) AS DisplayName FROM Clients", conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt1 = new DataTable();
                    conn.Open();
                    da.Fill(dt1);
                    cmbKlienti.DataSource = dt1;
                    cmbKlienti.DisplayMember = "DisplayName";
                    cmbKlienti.ValueMember = "Client_ID";
                    cmbKlienti.SelectedIndex = -1;
                    //cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
        }

        private void GetMaterialet()
        {
            using (SqlConnection conn = ConnectDB.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT Material_ID, CONCAT(Material_ID, ' - ', Title, ' - ', Author) AS DisplayMaterial FROM Bibliographic_Materials", conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt1 = new DataTable();
                    conn.Open();
                    da.Fill(dt1);
                    cmbMateriali.DataSource = dt1;
                    cmbMateriali.DisplayMember = "DisplayMaterial";
                    cmbMateriali.ValueMember = "Material_ID";
                    cmbMateriali.SelectedIndex = -1;
                    //cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
        }


        public void GetHuazimetEMaterialeve()
        {
            using (SqlConnection conn = ConnectDB.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Loans", conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    conn.Open();
                    da.Fill(dt);
                    dgvHuazimet.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
        }

        private void RegisterLoans()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cmbKlienti.Text) ||
                    string.IsNullOrWhiteSpace(cmbMateriali.Text) ||
                    string.IsNullOrWhiteSpace(dtpHuazimi.Text))
                {
                    MessageBox.Show("Please fill out all required fields.", "HSM");
                    return;
                }
                else
                {
                    dgvHuazimet.DataSource = null;
                    dt.Clear();

                    using (SqlConnection conection = ConnectDB.GetConnection())
                    {
                        try
                        {
                            conection.Open();
                            SqlCommand cmd = new SqlCommand("pppRegisterLoans", conection);
                            cmd.CommandType = CommandType.StoredProcedure;


                            int clientID = Convert.ToInt32(cmbKlienti.SelectedValue);
                            int materialID = Convert.ToInt32(cmbMateriali.SelectedValue);


                            cmd.Parameters.AddWithValue("@ClientID", clientID);
                            cmd.Parameters.AddWithValue("@MaterialID", materialID);
                            cmd.Parameters.AddWithValue("@LoanDate", dtpHuazimi.Value);
                            cmd.Parameters.AddWithValue("@ReturnDate", dtpKthimi.Value);
                            cmd.Parameters.AddWithValue("@ActualReturnDate", dtpAktuale.Value);
                            cmd.Parameters.AddWithValue("@PenaltyFee", Convert.ToDecimal(nudTarifa.Value));
                            //cmd.Parameters.AddWithValue("@Phone", txtPhone.Text); // Use DateTimePicker.Value
                            //cmd.Parameters.AddWithValue("@Address", txtAddress.Text); // Numeric value
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data has been Added", "Save");
                            GetMaterialet();
                            GetKlientet();
                            GetHuazimetEMaterialeve();


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message + "\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void HuazimetEMaterialeve_Load(object sender, EventArgs e)
        {
            GetHuazimetEMaterialeve();
            GetKlientet();
            GetMaterialet();
        }

        private void cmbMateriali_SelectedIndexChanged(object sender, EventArgs e)
        {
            //GetMaterialet();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            RegisterLoans();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbKlienti_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
