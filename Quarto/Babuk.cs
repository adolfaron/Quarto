using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quarto
{
    public partial class Babuk : Form
    {
        Jatekter Jatekter { get; set; }
        public PictureBox[,] cellak;
        public int cellameret = 100;

        int elhagyas = 12;
        int koz = 3;
        public Image utolsoKep;
        public Point utolsoHely;
        Image kijottKep = Image.FromFile("img/kijelol.png");

        Random rnd = new Random();

        public int kiJon;

        Menu Menu = Program.Menu;
        utasitasok utasitasok;
        //public Babuk(Menu ujmenu, utasitasok ujutasitasok)
        public Babuk()
        {
            InitializeComponent();
            utasitasok = Menu.utasitasok;
            //utasitasok = ujutasitasok;
            //Menu = ujmenu;
            cellak = new PictureBox[4, 4];
            for (int sor = 0; sor < 4; sor++)
            {
                for (int oszlop = 0; oszlop < 4; oszlop++)
                {
                    cellak[sor, oszlop] = new PictureBox();
                    PictureBox cella = cellak[sor, oszlop];
                    cella.Size = new Size(cellameret, cellameret);
                    cella.BackColor = Color.LightGray;
                    cella.Location = new Point(oszlop * (cella.Size.Width + koz) + elhagyas, sor * (cella.Size.Height + koz) + elhagyas);
                    this.Controls.Add(cella);
                    cella.Click += new(cekkaKatt);
                    cella.SizeMode = PictureBoxSizeMode.StretchImage;
                    cella.Image = kepLetrehoz(Convert.ToString(oszlop * 4 + sor, 2).PadLeft(4, '0'));
                    cella.Tag = $"{sor}_{oszlop}_1_" + Convert.ToString(oszlop * 4 + sor, 2).PadLeft(4, '0');
                }
            }
            //this.Width = utolso.X + cellameret + elhagyas * 2;
            //this.Height = utolso.Y + cellameret + elhagyas * 2+34;
            meretez();
            Jatekter = new Jatekter();
            Jatekter.FormClosed += (s, e) =>
            {
                Application.Exit();
            };
            Jatekter.Show();
            kiJon = rnd.Next(2);
            utasitasok.kiir.Text = (kiJon == 0? Menu.jatekos1nev : Menu.jatekos2nev) + " válasszon egy bábut!";
            kiJon = (kiJon == 0 ? 1 : 0);

        }

        private Image kepLetrehoz(string szam)
        {
            List<Image> kepek = new List<Image>();
            /*if (szam[0] == '0')
            {
                kepek.Add(Image.FromFile("img/fekete kör négyzet lyukkal.png"));
            }
            else {
                kepek.Add(Image.FromFile("img/fehér kör négyzet lyukkal.png"));
            }

            

            if (szam[1] == '0')
            {
                kepek.Add(Image.FromFile("img/kis fekete négyzet kör lyukkal.png"));
            }
            else
            {
                kepek.Add(Image.FromFile("img/kis fehér négyzet kör lyukkal.png"));
            }

            if (szam[3] == '0')
            {
                kepek.Add(Image.FromFile("img/kis fekete kör.png"));
            }
            else
            {
                kepek.Add(Image.FromFile("img/kis fehér kör.png"));
            }

            if (szam[2] == '0')
            {
                kepek.Add(Image.FromFile("img/__0_.png"));
            }
            else
            {
                kepek.Add(Image.FromFile("img/__1_.png"));
            }*/


            if (szam[0] == '0') //fekete
            {
                if (szam[1] == '0')//fekete négyzet
                {
                    kepek.Add(Image.FromFile("img/__0_.png"));
                    //kis fehér négyzet
                    if (szam[2] == '0')//kitöltött
                    {
                        kepek.Add(Image.FromFile("img/_1__.png"));
                        if (szam[3] == '0')//kitöltés kör
                        {
                            kepek.Add(Image.FromFile("img/0___.png"));
                        }
                    }
                    else
                    {
                        if (szam[3] == '0')//kitöltés kör
                        {
                            kepek.Add(Image.FromFile("img/0___.png"));
                        }
                    }
                }
                else//1
                {
                    if (szam[2] == '0')//kitöltött
                    {
                        kepek.Add(Image.FromFile("img/_1__.png"));
                        if (szam[3] == '0')//kitöltés kör
                        {
                            kepek.Add(Image.FromFile("img/0___.png"));
                        }
                        else
                        {
                            kepek.Add(Image.FromFile("img/0___.png"));
                            kepek.Add(Image.FromFile("img/_1__.png"));
                        }
                    }
                    else//1
                    {
                        if (szam[3] == '0')//kitöltés kör
                        {
                            kepek.Add(Image.FromFile("img/0___.png"));
                        }
                        else//1
                        {
                            kepek.Add(Image.FromFile("img/fekete kör négyzet lyukkal.png"));
                        }

                    }
                }
            }
            else//1
            {
                if (szam[1] == '0')
                {
                    kepek.Add(Image.FromFile("img/__1_.png"));
                    //kis fehér négyzet
                    if (szam[2] == '0')//kitöltött
                    {
                        kepek.Add(Image.FromFile("img/_0__.png"));
                        if (szam[3] == '0')//kitöltés kör
                        {
                            kepek.Add(Image.FromFile("img/1___.png"));
                        }
                    }
                    else
                    {
                        if (szam[3] == '0')//kitöltés kör
                        {
                            kepek.Add(Image.FromFile("img/1___.png"));
                        }
                    }
                }
                else//1
                {
                    if (szam[2] == '0')//kitöltött
                    {
                        kepek.Add(Image.FromFile("img/_0__.png"));
                        if (szam[3] == '0')//kitöltés kör
                        {
                            kepek.Add(Image.FromFile("img/1___.png"));
                        }
                        else
                        {
                            kepek.Add(Image.FromFile("img/1___.png"));
                            kepek.Add(Image.FromFile("img/_0__.png"));

                        }
                    }
                    else
                    {
                        if (szam[3] == '0')//kitöltés kör
                        {
                            kepek.Add(Image.FromFile("img/1___.png"));
                        }
                        else//1
                        {
                            kepek.Add(Image.FromFile("img/fehér kör négyzet lyukkal.png"));
                        }
                    }
                }
            }
            /*if (szam[1] == '0')
            {
                kepek.Add(Image.FromFile("img/0___.png"));
            }
            else
            {
                kepek.Add(Image.FromFile("img/1___.png"));
            }
            if (szam[0] == '0')
            {
                kepek.Add(Image.FromFile("img/__0_.png"));
            }
            else
            {
                kepek.Add(Image.FromFile("img/__1_.png"));
            }
            
            if (szam[2] == '0')
            {
                kepek.Add(Image.FromFile("img/_0__.png"));
            }
            else
            {
                kepek.Add(Image.FromFile("img/_1__.png"));
            }

            if (szam[3] == '0')
            {
                kepek.Insert(0, kepek[kepek.Count - 1]);
            }
            else
            {
                kepek.RemoveAt(kepek.Count-1);
            }*/


            return kepOsszeRak(kepek.ToArray());
        }

        private void cekkaKatt(object sender, EventArgs e)
        {
            PictureBox kattintott = sender as PictureBox;
            if (utolsoKep != null || kattintott.Image == null) return;
            //MessageBox.Show(kattintott.Tag.ToString().Split('_')[3]);
            int sor = Convert.ToInt32(kattintott.Tag.ToString().Split('_')[0]);
            int oszl = Convert.ToInt32(kattintott.Tag.ToString().Split('_')[1]);
            //Jatekter.kivalaszt(kattintott);
            Jatekter.valasztott = new PictureBox();
            Jatekter.valasztott.Image = (Image)kattintott.Image.Clone();
            Jatekter.valasztott.Tag = kattintott.Tag;
            utolsoKep = kattintott.Image;
            utolsoHely = new Point(sor, oszl);
            cellak[sor, oszl].Image = kepOsszeRak([utolsoKep, kijottKep]);
            utasitasok.kiir.Text = (kiJon == 0 ? Menu.jatekos1nev : Menu.jatekos2nev) + " rakja le valahova a választott bábut!";
        }

        private Image kepOsszeRak(params Image[] images) //ChatGPT
        {
            if (images.Length == 0) return null;

            int width = images[0].Width;
            int height = images[0].Height;
            Bitmap bmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;

                foreach (var img in images)
                {
                    if (img != null)
                        g.DrawImage(img, 0, 0, width, height);
                }
            }

            return bmp;
            /*
                pb.Image = kepOsszeRak(
                Image.FromFile("kep1.png"),
                Image.FromFile("kep3.png"),
                Image.FromFile("kep5.png")
);
             */
        }

        private void meretez()
        {
            cellameret = (this.ClientSize.Width - elhagyas * 2 - koz * 3) / 4;
            for (int sor = 0; sor < 4; sor++)
            {
                for (int oszlop = 0; oszlop < 4; oszlop++)
                {
                    PictureBox cella = cellak[sor, oszlop];
                    cella.Size = new Size(cellameret, cellameret);
                    cella.BackColor = Color.LightGray;
                    cella.Location = new Point(oszlop * (cella.Size.Width + koz) + elhagyas, sor * (cella.Size.Height + koz) + elhagyas);
                }
            }
            this.ClientSize = new Size(
                this.ClientSize.Width,
                cellameret * 4 + koz * 3 + elhagyas + 10
            );
        }

        private void Babuk_Resize(object sender, EventArgs e)
        {
            meretez();
        }
    }
}

