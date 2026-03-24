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
    public partial class Jatekter : Form
    {

        PictureBox[,] cellak;
        int cellameret = 100;

        int elhagyas = 12;
        int koz = 3;

        Babuk Babuk;
        public Jatekter(Babuk ujbabuk)
        {
            Babuk = ujbabuk;
            InitializeComponent();

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
                    cella.Tag = $"{sor}_{oszlop}_0_0000";
                }
            }
            this.ClientSize = new Size( cellameret * 4 + koz * 3 + elhagyas + 10,
                                        cellameret * 4 + koz * 3 + elhagyas + 10);
        }
        private void cekkaKatt(object sender, EventArgs e)
        {
            PictureBox kattintott = sender as PictureBox;

        }

        
    }
}
