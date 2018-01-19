using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilboMVP
{
    public partial class Despedida : Form
    {
        public int Ypos;
        public int Xpos;
        public Despedida()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            PantallaPrincipal.contexto1.Close();
            PantallaPrincipal.Panas.Close();
            this.Close();
        }

        private void Despedida_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            Ypos = Location.Y;
            Xpos = Location.X;
        }

        private void Despedida_Move(object sender, EventArgs e)
        {
            if ((Xpos > 0))
            {
                Location = new Point(Xpos, Ypos);
            }
        }
    }
}
