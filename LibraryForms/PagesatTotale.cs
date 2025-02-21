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
                    SqlCommand cmd = new SqlCommand("SELECT * FROM vViewTotalPaymentsPerClient", conn);
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


        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value.Date; // Get selected date
            DataView dataView = new DataView(dt);

            // Filter by Data_huazimit
            dataView.RowFilter = $"Payment_Date = #{selectedDate:MM/dd/yyyy}#";

            dgvPagesatTotale.DataSource = dataView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvPagesatTotale.DataSource = dt;

            // Clear any applied filters
            DataView dataView = new DataView(dt);
            dataView.RowFilter = ""; // Remove any filtering
            dgvPagesatTotale.DataSource = dataView;
        }

    }
}
