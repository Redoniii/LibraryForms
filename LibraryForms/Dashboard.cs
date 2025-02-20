using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryForms
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }


        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            PerdoruestiESistemit perdoruestiESistemit = new PerdoruestiESistemit();
            perdoruestiESistemit.MdiParent = Dashboard.ActiveForm;
            perdoruestiESistemit.Show();
        }

        private void pagesatTotaleTeKlienteveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PagesatTotale pagesat = new PagesatTotale();
            pagesat.MdiParent = Dashboard.ActiveForm;
            pagesat.Show();
        }

        private void huazimetEVonuaraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HuazimetEVonesuara huazimetEVonesuara = new HuazimetEVonesuara();
            huazimetEVonesuara.MdiParent = Dashboard.ActiveForm;
            huazimetEVonesuara.Show();
        }

        private void klientetAktivToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KlientetAktiv klientetAktiv = new KlientetAktiv();
            klientetAktiv.MdiParent = Dashboard.ActiveForm;
            klientetAktiv.Show();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Menaxhimi menaxhimi = new Menaxhimi();
            menaxhimi.MdiParent = Dashboard.ActiveForm;
            menaxhimi.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Klientet klientet = new Klientet();
            klientet.MdiParent = Dashboard.ActiveForm;
            klientet.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            HuazimetEMaterialeve hmaterialet = new HuazimetEMaterialeve();
            hmaterialet.MdiParent = Dashboard.ActiveForm;
            hmaterialet.Show();
        }



        private void btnEXIT_Click(object sender, EventArgs e)
        {
            this.Close();

            Login login = new Login();
            login.Show();

            MessageBox.Show("You have been Logged Out");


        }
    }
}
