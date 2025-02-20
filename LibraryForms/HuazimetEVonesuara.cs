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
    public partial class HuazimetEVonesuara : Form
    {
        public HuazimetEVonesuara()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();



        public void GetHuazimet()
        {
            using (SqlConnection conn = ConnectDB.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Pamje_Huazimet_e_Klienteve_te_Vonuar", conn);
                    //SqlCommand cmd = new SqlCommand("SELECT DoctorID, FirstName, LastName, Specialization, Phone, Email, de.DepartmentName from Doctors d\r\ninner join Departments de on de.DepartmentID = d.DepartmentID", conn);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    conn.Open();
                    da.Fill(dt);
                    dgvHuazimetEVonesuara.DataSource = dt;
                    //cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
        }
        private void dgvHuazimetEVonesuara_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HuazimetEVonesuara_Load(object sender, EventArgs e)
        {
            GetHuazimet();
        }

        private void txtSearchTime_TextChanged(object sender, EventArgs e)
        {
            string fillerText = txtSearchDitVonese.Text;

            if (int.TryParse(fillerText, out int day))  // Try to parse fillerText as an integer
            {
                DataView dataView = new DataView(dt);
                dataView.RowFilter = $"Dite_Vonese = {day}";
                dgvHuazimetEVonesuara.DataSource = dataView;
            }
            else
            {
                dgvHuazimetEVonesuara.DataSource = dt;  // No filter if the input is not a valid integer
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
