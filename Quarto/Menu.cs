using System;
using System.Drawing;
using System.Windows.Forms;

namespace Quarto
{
    public partial class Menu : Form
    {
        Button startBTN;      // osztály szintű mezők
        TextBox jatekosNev1;

        public Menu()
        {
            InitializeComponent();

            // Button létrehozása
            startBTN = new Button();
            startBTN.Name = "startBTN";
            startBTN.Size = new Size(117, 89);
            startBTN.Text = "START";
            startBTN.UseVisualStyleBackColor = true;
            startBTN.Click += startBTN_Click;
            Controls.Add(startBTN);

            // TextBox létrehozása
            jatekosNev1 = new TextBox();
            jatekosNev1.Location = new Point(259, 87);
            jatekosNev1.Name = "jatekosNev1";
            jatekosNev1.Size = new Size(100, 23);
            Controls.Add(jatekosNev1);

            // esemény bekötése
            this.Resize += meretez;

            // gomb pozíció középre
            elhelyezesSzamol();
        }

        private void elhelyezesSzamol()
        {
            if (startBTN == null) return;
            if (jatekosNev1 == null) return;

            startBTN.Location = new Point(
                (ClientSize.Width - startBTN.Width) / 2,
                (ClientSize.Height - startBTN.Height) / 2
            );
            jatekosNev1.Location = new Point((ClientSize.Width - jatekosNev1.Width) / 2, startBTN.Location.Y + startBTN.Height + 10);
        }

        private void meretez(object sender, EventArgs e)
        {
            elhelyezesSzamol();
        }

        private void startBTN_Click(object sender, EventArgs e)
        {
            Babuk Babuk = new Babuk();
            Babuk.FormClosed += (s, e) => { Application.Exit(); };
            this.Hide();
            Babuk.Show();
        }
    }
}