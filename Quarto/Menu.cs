using System;
using System.Drawing;
using System.Windows.Forms;

namespace Quarto
{
    public partial class Menu : Form
    {
        Button startBTN;
        TextBox jatekosNev1;
        TextBox jatekosNev2;
        Label jatekos1LBL = new Label();
        Label jatekos2LBL = new Label();
        Button utasitsKiBe = new Button();
        bool utasitasMegj = true;

        public utasitasok utasitasok { get; set; }
        public Babuk Babuk { get; set; }

        public string jatekos1nev;
        public string jatekos2nev;

        

        public Menu()
        {
            InitializeComponent();

            startBTN = new Button();
            startBTN.Name = "startBTN";
            startBTN.Size = new Size(117, 89);
            startBTN.Text = "START";
            startBTN.UseVisualStyleBackColor = true;
            startBTN.Click += startBTN_Click;
            Controls.Add(startBTN);

            jatekosNev1 = new TextBox();
            jatekosNev1.Name = "jatekosNev1";
            jatekosNev1.Size = new Size(100, 23);
            Controls.Add(jatekosNev1);

            jatekosNev2 = new TextBox();
            jatekosNev2.Name = "jatekosNev1";
            jatekosNev2.Size = new Size(100, 23);
            Controls.Add(jatekosNev2);

            jatekos1LBL.AutoSize = true;
            jatekos1LBL.Name = "jatekos1LBL";
            jatekos1LBL.Size = new Size(38, 23);
            jatekos1LBL.TabIndex = 0;
            jatekos1LBL.Text = "Játékos 1:";
            jatekos1LBL.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(jatekos1LBL);

            jatekos2LBL.AutoSize = true;
            jatekos2LBL.Name = "jatekos12LBL";
            jatekos2LBL.Size = new Size(38, 23);
            jatekos2LBL.TabIndex = 0;
            jatekos2LBL.Text = "Játékos 2:";
            jatekos2LBL.TextAlign = ContentAlignment.MiddleCenter;
            Controls.Add(jatekos2LBL);

            utasitsKiBe.Location = new Point(98, 49);
            utasitsKiBe.Name = "utasitsKiBe";
            utasitsKiBe.Size = new Size(120, 35);
            utasitsKiBe.TabIndex = 0;
            utasitsKiBe.Text = "Utasítások ki/be";
            utasitsKiBe.UseVisualStyleBackColor = true;
            utasitsKiBe.Click += utasitasKiBe;
            Controls.Add(utasitsKiBe);

            utasitasok = new utasitasok();
            utasitasok.Show();
            utasitasok.Hide();

            this.Resize += meretez;
            utasitasok.kiir.Text = "Add mag a játékosok nevét";
            elhelyezesSzamol();
        }

        private void utasitasKiBe(object? sender, EventArgs e)
        {
            if (utasitasMegj)
            {                
                utasitasok.Show();
                utasitasMegj = !utasitasMegj;
            }
            else { 
                utasitasok.Hide();
                utasitasMegj = !utasitasMegj;
            }
        }

        private void elhelyezesSzamol()
        {
            if (startBTN == null) return;
            if (jatekosNev1 == null) return;
            if (jatekosNev2 == null) return;
            if (jatekos1LBL == null) return;

            startBTN.Location = new Point(
                (ClientSize.Width - startBTN.Width) / 2,
                (ClientSize.Height - startBTN.Height) / 2
            );
            jatekosNev1.Location = new Point((ClientSize.Width - jatekosNev1.Width) / 2 + jatekos1LBL.Width/2, startBTN.Location.Y + startBTN.Height + 10);
            jatekos1LBL.Location = new Point(jatekosNev1.Location.X-jatekos1LBL.Width, jatekosNev1.Location.Y+ 3);
            jatekosNev2.Location = new Point((ClientSize.Width - jatekosNev2.Width) / 2 + jatekos2LBL.Width / 2, jatekosNev1.Location.Y + jatekosNev1.Height + 10);
            jatekos2LBL.Location = new Point(jatekosNev2.Location.X - jatekos1LBL.Width, jatekosNev2.Location.Y + 3);
        }

        private void meretez(object sender, EventArgs e)
        {
            elhelyezesSzamol();
        }

        private void startBTN_Click(object sender, EventArgs e)
        {
            if (jatekosNev1.Text=="" || jatekosNev2.Text =="")return;
            if (jatekosNev1.Text == jatekosNev2.Text) return;
            jatekos1nev = jatekosNev1.Text;
            jatekos2nev = jatekosNev2.Text;
            Babuk = new Babuk();
            Babuk.FormClosed += (s, e) => { Application.Exit(); };
            this.Hide();
            Babuk.Show();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                startBTN_Click(this, EventArgs.Empty);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}