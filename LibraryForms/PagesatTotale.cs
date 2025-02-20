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
    public partial class PagesatTotale : Form
    {
        public PagesatTotale()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();

        public void GetPagesat()
        {
            using (SqlConnection conn = ConnectDB.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM ViewTotalPaymentsPerClientWithTime", conn);
                    //SqlCommand cmd = new SqlCommand("SELECT DoctorID, FirstName, LastName, Specialization, Phone, Email, de.DepartmentName from Doctors d\r\ninner join Departments de on de.DepartmentID = d.DepartmentID", conn);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    conn.Open();
                    da.Fill(dt);
                    dgvPagesatTotale.DataSource = dt;
                    //cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
        }

        private void PagesatTotale_Load(object sender, EventArgs e)
        {
            GetPagesat();
        }

        private void txtSearchTime_TextChanged(object sender, EventArgs e)
        {
            string fillerText = txtSearchTime.Text;

            if (int.TryParse(fillerText, out int year))  // Try to parse fillerText as an integer
            {
                DataView dataView = new DataView(dt);
                dataView.RowFilter = $"PaymentYear = {year}";
                dgvPagesatTotale.DataSource = dataView;
            }
            else
            {
                dgvPagesatTotale.DataSource = dt;  // No filter if the input is not a valid integer
            }


        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        //private void txtSearchTime2_TextChanged(object sender, EventArgs e)
        //{
        //    string fillerText = txtSearchTime.Text;

        //    if (int.TryParse(fillerText, out int month))  // Try to parse fillerText as an integer
        //    {
        //        DataView dataView = new DataView(dt);
        //        dataView.RowFilter = $"PaymentMonth = {month}";
        //        dgvPagesatTotale.DataSource = dataView;
        //    }
        //    else
        //    {
        //        dgvPagesatTotale.DataSource = dt;  // No filter if the input is not a valid integer
        //    }

        //}
    }
}
