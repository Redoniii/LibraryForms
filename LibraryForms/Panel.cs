using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryForms
{
    public partial class Panel : Form
    {
        public Panel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Button clickedButton = sender as Button;
            //if (clickedButton != null)
            //{
            //    clickedButton.BackColor = Color.FromArgb(106, 138, 234); // New color after click
            //}

            // Krijo një instancë të formës Menaxhimi
            Menaxhimi menaxhimi = new Menaxhimi();

            // Vendoseni formën si një kontroll
            menaxhimi.TopLevel = false;
            menaxhimi.FormBorderStyle = FormBorderStyle.None;
            menaxhimi.Dock = DockStyle.Fill;

            // Shto formën në një Panel 
            panel2.Controls.Clear(); // Pastron panelin nëse ka ndonjë kontroll
            panel2.Controls.Add(menaxhimi);

            // Shfaq formën
            menaxhimi.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {

            // Krijo një instancë të formës Menaxhimi
            PagesatTotale pagesatTotale = new PagesatTotale();

            // Vendoseni formën si një kontroll
            pagesatTotale.TopLevel = false;
            pagesatTotale.FormBorderStyle = FormBorderStyle.None;
            pagesatTotale.Dock = DockStyle.Fill;

            // Shto formën në një Panel 
            panel2.Controls.Clear(); // Pastron panelin nëse ka ndonjë kontroll
            panel2.Controls.Add(pagesatTotale);

            // Shfaq formën
            pagesatTotale.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Krijo një instancë të formës Menaxhimi
            PerdoruestiESistemit perdoruestiESistemit = new PerdoruestiESistemit();

            // Vendoseni formën si një kontroll
            perdoruestiESistemit.TopLevel = false;
            perdoruestiESistemit.FormBorderStyle = FormBorderStyle.None;
            perdoruestiESistemit.Dock = DockStyle.Fill;

            // Shto formën në një Panel 
            panel2.Controls.Clear(); // Pastron panelin nëse ka ndonjë kontroll
            panel2.Controls.Add(perdoruestiESistemit);

            // Shfaq formën
            perdoruestiESistemit.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Krijo një instancë të formës Menaxhimi
            Pagesat pagesat = new Pagesat();

            // Vendoseni formën si një kontroll
            pagesat.TopLevel = false;
            pagesat.FormBorderStyle = FormBorderStyle.None;
            pagesat.Dock = DockStyle.Fill;

            // Shto formën në një Panel
            panel2.Controls.Clear(); // Pastron panelin nëse ka ndonjë kontroll
            panel2.Controls.Add(pagesat);

            // Shfaq formën
            pagesat.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Krijo një instancë të formës Menaxhimi
            HuazimetEMaterialeve huazimetEMaterialeve = new HuazimetEMaterialeve();

            // Vendoseni formën si një kontroll
            huazimetEMaterialeve.TopLevel = false;
            huazimetEMaterialeve.FormBorderStyle = FormBorderStyle.None;
            huazimetEMaterialeve.Dock = DockStyle.Fill;

            // Shto formën në një Panel 
            panel2.Controls.Clear(); // Pastron panelin nëse ka ndonjë kontroll
            panel2.Controls.Add(huazimetEMaterialeve);

            // Shfaq formën
            huazimetEMaterialeve.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Krijo një instancë të formës Menaxhimi
            Klientet klientet = new Klientet();

            // Vendoseni formën si një kontroll
            klientet.TopLevel = false;
            klientet.FormBorderStyle = FormBorderStyle.None;
            klientet.Dock = DockStyle.Fill;

            // Shto formën në një Panel 
            panel2.Controls.Clear(); // Pastron panelin nëse ka ndonjë kontroll
            panel2.Controls.Add(klientet);

            // Shfaq formën
            klientet.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Krijo një instancë të formës Menaxhimi
            HuazimetEVonesuara huazimetEVonesuara = new HuazimetEVonesuara();

            // Vendoseni formën si një kontroll
            huazimetEVonesuara.TopLevel = false;
            huazimetEVonesuara.FormBorderStyle = FormBorderStyle.None;
            huazimetEVonesuara.Dock = DockStyle.Fill;

            // Shto formën në një Panel 
            panel2.Controls.Clear(); // Pastron panelin nëse ka ndonjë kontroll
            panel2.Controls.Add(huazimetEVonesuara);

            // Shfaq formën
            huazimetEVonesuara.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Krijo një instancë të formës Menaxhimi
            KlientetAktiv klientetAktiv = new KlientetAktiv();

            // Vendoseni formën si një kontroll
            klientetAktiv.TopLevel = false;
            klientetAktiv.FormBorderStyle = FormBorderStyle.None;
            klientetAktiv.Dock = DockStyle.Fill;

            // Shto formën në një Panel
            panel2.Controls.Clear(); // Pastron panelin nëse ka ndonjë kontroll
            panel2.Controls.Add(klientetAktiv);

            // Shfaq formën
            klientetAktiv.Show();
        }


        private void MakeButtonRounded(Button button)
        {
            // Create a GraphicsPath for the button's rounded corners
            var path = new System.Drawing.Drawing2D.GraphicsPath();

            // Set the radius of the corners
            int radius = 20; // Adjust this value for more or less rounded corners

            // Create a rounded rectangle
            path.AddArc(0, 0, radius, radius, 180, 90); // Top-left corner
            path.AddArc(button.Width - radius - 1, 0, radius, radius, 270, 90); // Top-right corner
            path.AddArc(button.Width - radius - 1, button.Height - radius - 1, radius, radius, 0, 90); // Bottom-right corner
            path.AddArc(0, button.Height - radius - 1, radius, radius, 90, 90); // Bottom-left corner
            path.CloseFigure();

            // Set the button's region to this rounded rectangle path
            button.Region = new System.Drawing.Region(path);
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel_Load(object sender, EventArgs e)
        {
            MakeButtonRounded(button1);
            MakeButtonRounded(button2);
            MakeButtonRounded(button3);
            MakeButtonRounded(button4);
            MakeButtonRounded(button5);
            MakeButtonRounded(button6);
            MakeButtonRounded(button7);
            MakeButtonRounded(button8);
            button1.FlatAppearance.BorderSize = 0; // Remove button borders
            button2.FlatAppearance.BorderSize = 0; // Remove button borders
            button3.FlatAppearance.BorderSize = 0; // Remove button borders
            button4.FlatAppearance.BorderSize = 0; // Remove button borders
            button5.FlatAppearance.BorderSize = 0; // Remove button borders
            button6.FlatAppearance.BorderSize = 0; // Remove button borders
            button7.FlatAppearance.BorderSize = 0; // Remove button borders
            button8.FlatAppearance.BorderSize = 0; // Remove button borders


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();

            Login login = new Login();
            login.Show();

            MessageBox.Show("You have been Logged Out");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
