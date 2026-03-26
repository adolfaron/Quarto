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
    public partial class utasitasok : Form
    {
        
        public utasitasok()
        {
            InitializeComponent();
            kiir.Location = new Point(5, 5);
            kiir.Text = "";
        }

        private void utasitasok_Resize(object sender, EventArgs e)
        {
            kiir.Width = this.ClientSize.Width-10;
            kiir.Height = this.ClientSize.Height-10;
        }

    }
}
