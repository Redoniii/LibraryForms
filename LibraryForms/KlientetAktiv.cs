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
    public partial class KlientetAktiv : Form
    {
        public KlientetAktiv()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();


        public void GetKlientetAktiv()
        {
            using (SqlConnection conn = ConnectDB.GetConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM ViewActiveClients", conn);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    conn.Open();
                    da.Fill(dt);
                    dgvKlientetAktiv.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
        }


        private void KlientetAktiv_Load(object sender, EventArgs e)
        {
            GetKlientetAktiv();
        }

        private void txtSearchDitVonese_TextChanged(object sender, EventArgs e)
        {
            string fillerText = txtSearchbyName.Text.ToLower();
            if (!string.IsNullOrEmpty(fillerText))
            {
                DataView dataView = new DataView(dt);
                dataView.RowFilter = $"First_Name like '%{fillerText}%'";
                dgvKlientetAktiv.DataSource = dataView;
            }
            else
            {
                dgvKlientetAktiv.DataSource = dt;
            }
        }
    }
}
