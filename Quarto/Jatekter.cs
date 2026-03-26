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

        public PictureBox valasztott;
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
            if (kattintott.Image != null || Babuk.utolsoKep == null) return;
            int sor = Convert.ToInt32(kattintott.Tag.ToString().Split('_')[0]);
            int oszl = Convert.ToInt32(kattintott.Tag.ToString().Split('_')[1]);

            cellak[sor, oszl].Image = valasztott.Image;
            cellak[sor, oszl].Tag = valasztott.Tag;
            Babuk.cellak[Babuk.utolsoHely.X, Babuk.utolsoHely.Y].Image = null;
            Babuk.utolsoKep = null;
            for (int s = 0; s  < 4; s ++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (cellak[s, 0].Tag.ToString().Split('_')[2] == "1" &&
                        cellak[s, 1].Tag.ToString().Split('_')[2] == "1" &&
                        cellak[s, 2].Tag.ToString().Split('_')[2] == "1" &&
                        cellak[s, 3].Tag.ToString().Split('_')[2] == "1" &&

                        cellak[s, 0].Tag.ToString().Split('_')[3][i] == cellak[s, 1].Tag.ToString().Split('_')[3][i] && 
                        cellak[s, 1].Tag.ToString().Split('_')[3][i] == cellak[s, 2].Tag.ToString().Split('_')[3][i] &&
                        cellak[s, 2].Tag.ToString().Split('_')[3][i] == cellak[s, 3].Tag.ToString().Split('_')[3][i])
                    {
                        MessageBox.Show("Kijött!");
                        return;
                    }
                }
            }
            for (int o = 0; o < 4; o++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (cellak[0, o].Tag.ToString().Split('_')[2] == "1" &&
                        cellak[1, o].Tag.ToString().Split('_')[2] == "1" &&
                        cellak[2, o].Tag.ToString().Split('_')[2] == "1" &&
                        cellak[3, o].Tag.ToString().Split('_')[2] == "1" &&

                        cellak[0, o].Tag.ToString().Split('_')[3][i] == cellak[1, o].Tag.ToString().Split('_')[3][i] &&
                        cellak[1, o].Tag.ToString().Split('_')[3][i] == cellak[2, o].Tag.ToString().Split('_')[3][i] &&
                        cellak[2, o].Tag.ToString().Split('_')[3][i] == cellak[3, o].Tag.ToString().Split('_')[3][i])
                    {
                        MessageBox.Show("Kijött!");return;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (cellak[0, 0].Tag.ToString().Split('_')[2] == "1" &&
                        cellak[1, 1].Tag.ToString().Split('_')[2] == "1" &&
                        cellak[2, 2].Tag.ToString().Split('_')[2] == "1" &&
                        cellak[3, 3].Tag.ToString().Split('_')[2] == "1" &&

                        cellak[0, 0].Tag.ToString().Split('_')[3][i] == cellak[1, 1].Tag.ToString().Split('_')[3][i] &&
                        cellak[1, 1].Tag.ToString().Split('_')[3][i] == cellak[2, 2].Tag.ToString().Split('_')[3][i] &&
                        cellak[2, 2].Tag.ToString().Split('_')[3][i] == cellak[3, 3].Tag.ToString().Split('_')[3][i])
                {
                    MessageBox.Show("Kijött!"); return;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (cellak[0, 3].Tag.ToString().Split('_')[2] == "1" &&
                        cellak[1, 2].Tag.ToString().Split('_')[2] == "1" &&
                        cellak[2, 1].Tag.ToString().Split('_')[2] == "1" &&
                        cellak[3, 0].Tag.ToString().Split('_')[2] == "1" &&

                        cellak[0, 3].Tag.ToString().Split('_')[3][i] == cellak[1, 2].Tag.ToString().Split('_')[3][i] &&
                        cellak[1, 2].Tag.ToString().Split('_')[3][i] == cellak[2, 1].Tag.ToString().Split('_')[3][i] &&
                        cellak[2, 1].Tag.ToString().Split('_')[3][i] == cellak[3, 0].Tag.ToString().Split('_')[3][i])
                {
                    MessageBox.Show("Kijött!"); return;
                }
            }
            for (int s = 0; s < 4; s++)
            {
                for (int o = 0; o < 4; o++)
                {
                    if (cellak[s, o].Tag.ToString().Split('_')[2] == "0") return;
                }
            }
            MessageBox.Show("döntetlen");
        }

        
    }
}
