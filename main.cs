# PO-kosci

using System;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace KosciApplication
{
    public partial class Main : Form
    {
        Kostka kostka = new Kostka(6);
        Gracz user = new Gracz();
        Gracz user2 = new Gracz();
        Gracz komp = new Gracz();

        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //User:

            button1.Enabled = false;

            Kulanie();

            ZapamietajWynikRundy(user);

            radioButton1.Text += " (miałem " + kostka.AktualnieWylosowano + ")";

            //Komp:

            Thread.Sleep(1000);
            radioButton2.Checked = true;
            Thread.Sleep(1000);

            Kulanie();

            ZapamietajWynikRundy(komp);

            //Sędziowanie

            DoliczPunkty();

            AktualizujWynik();

            pictureBox1.Image = null;
            radioButton1.Text = "Ja";
            radioButton1.Checked = true;

            button1.Enabled = true;

        }

        private void DoliczPunkty1() // doliczanie punktow w starciu z Userem
        {
            if (user2.LiczbaOczekWRundzie > user.LiczbaOczekWRundzie)
            {
                MessageBox.Show("Wygral gracz 2");
                user2.DodajPunkt();
            }

            else if (user2.LiczbaOczekWRundzie < user.LiczbaOczekWRundzie)
            {
                MessageBox.Show("Wygral gracz 1");
                user.DodajPunkt();
            }

            else
            {
                MessageBox.Show("Remis.");
            }
        }


        private void DoliczPunkty() // Doliczanie punktow w starciu z komputerem
        {
            if (komp.LiczbaOczekWRundzie > user.LiczbaOczekWRundzie)
            {
                MessageBox.Show("Przegrałeś");
                komp.DodajPunkt();
            }

            else if (komp.LiczbaOczekWRundzie < user.LiczbaOczekWRundzie)
            {
                MessageBox.Show("Gratulacje");
                user.DodajPunkt();
            }

            else
            {
                MessageBox.Show("Remis.");
            }
        }

        private void ZapamietajWynikRundy(Gracz gracz)
        {
            gracz.LiczbaOczekWRundzie = kostka.AktualnieWylosowano;
        }

        private void AktualizujWynik() // Aktualizuj wynik w starciu z komputerem
        {
            textBox1.Text = user.LiczbaPunktow.ToString();
            textBox2.Text = komp.LiczbaPunktow.ToString();
        }


        private void AktualizujWynik2() // Aktualizuj wynik w starciu z userem
        {
            textBox1.Text = user.LiczbaPunktow.ToString();
            textBox3.Text = user2.LiczbaPunktow.ToString();
        }

        private void Kulanie()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(i*(i < 7 ? 1 : 2)*20);
                kostka.Przekulnij();
                pictureBox1.Image = Properties.Resources.ResourceManager.GetObject("_" + kostka.AktualnieWylosowano) as Bitmap;
                Application.DoEvents();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ekranStartowy.Image = null;
            WidocznoscGUI(false);
            groupBox1.Focus();
        }

        private void WidocznoscGUI(bool stanDocelowy)
        {
            groupBox1.Visible = stanDocelowy;
            groupBox2.Visible = stanDocelowy;
            groupBox3.Visible = stanDocelowy;
            groupBox4.Visible = stanDocelowy;
        }

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void oKościToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string msg = "Gra w kości\n";
           msg += "Copyright by A.H i D.W. na 3.0";
            MessageBox.Show(msg);


        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            groupBox1.Focus();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            groupBox1.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rywalKomputerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            ekranStartowy.Visible = false;
            WidocznoscGUI(true);
            radioButton1.Text = "Ja";
            pictureBox1.Image = null;
            radioButton1.Checked = true;

            user.ZerujLiczbePunktow();
            komp.ZerujLiczbePunktow();

            AktualizujWynik();
        }

        private void rywalUżytkownik2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ekranStartowy.Visible = false;
            WidocznoscGUI(true);
            radioButton1.Text = "Ja";
            pictureBox1.Image = null;
            radioButton1.Checked = true;
            button1.Enabled = false;
            user2.ZerujLiczbePunktow();
            komp.ZerujLiczbePunktow();

            AktualizujWynik();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;

            Kulanie();

            ZapamietajWynikRundy(user);

            radioButton1.Text += " (miałem " + kostka.AktualnieWylosowano + ")";
            radioButton3.Checked = true;

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;

            Kulanie();

            ZapamietajWynikRundy(user2);

            radioButton3.Text += " (miałem " + kostka.AktualnieWylosowano + ")";

            DoliczPunkty1();

            AktualizujWynik2();

            pictureBox1.Image = null;
            radioButton1.Text = "Ja";
            radioButton1.Checked = true;

            button2.Enabled = true;
            button3.Enabled = true;

            pictureBox1.Image = null;
            radioButton3.Text = "Ja";

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }


    }
}
