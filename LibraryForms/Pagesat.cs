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
    public partial class Pagesat : Form
    {
        public Pagesat()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();


        public void GetPayments()
        {
            using (SqlConnection conn = ConnectDB.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Payments", conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    conn.Open();
                    da.Fill(dt);
                    dgvLPagesat.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
        }


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
                    cmbClient.DataSource = dt1;
                    cmbClient.DisplayMember = "DisplayName";
                    cmbClient.ValueMember = "Client_ID";
                    cmbClient.SelectedIndex = -1;
                    //cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
        }


        private void InsertNewPayments()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cmbClient.Text) ||
                    string.IsNullOrWhiteSpace(cmbPType.Text) ||
                    string.IsNullOrWhiteSpace(nudAmount.Text) ||
                    string.IsNullOrWhiteSpace(dtpPDate.Text))
                {
                    MessageBox.Show("Please fill out all required fields.", "HSM");
                    return;
                }
                else
                {
                    dgvLPagesat.DataSource = null;
                    dt.Clear();

                    using (SqlConnection conection = ConnectDB.GetConnection())
                    {
                        try
                        {
                            conection.Open();
                            SqlCommand cmd = new SqlCommand("RegisterPayments", conection);
                            cmd.CommandType = CommandType.StoredProcedure;


                            int clientID = Convert.ToInt32(cmbClient.SelectedValue);
                           // int paymenttype = Convert.ToInt32(cmbPType.SelectedValue);


                            cmd.Parameters.AddWithValue("@ClientID", clientID);
                            cmd.Parameters.AddWithValue("@Amount", Convert.ToDecimal(nudAmount.Value));
                            cmd.Parameters.AddWithValue("@PaymentType", cmbPType.Text);
                            cmd.Parameters.AddWithValue("@PaymentDate", dtpPDate.Value);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data has been Added", "Save");
                            GetPayments();
                            GetKlientet();


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



        private void Pagesat_Load(object sender, EventArgs e)
        {
            GetPayments();
            GetKlientet();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InsertNewPayments();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
