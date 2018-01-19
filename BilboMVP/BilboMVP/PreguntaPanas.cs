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
    public partial class PreguntaPanas : Form
    {
        public PreguntaPanas()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PreguntaPanas_Load(object sender, EventArgs e)
        {
            this.Location = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Location;
            this.MinimumSize = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size;
            this.MaximumSize = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size;
            this.MaximizeBox = true;
            TableLayoutPanel Princial = (TableLayoutPanel)PantallaPrincipal.Panas.Controls["tableLayoutPanelPrincipal"];
            TableLayoutPanel Secundario = (TableLayoutPanel)Princial.Controls["tableLayoutPanel1"];
            ((Label)Secundario.Controls["lbInstruccion"]).Text = "Señala en que medida te sentiste de la siguiente manera deacuerdo al contexto anterior";
            //((Label)PantallaPrincipal.Panas.Controls["lbInstruccion"]).Text = "Señalar en que medida te sentiste deacuerdo al contexto anterior";
        }

        private void PreguntaPanas_Move(object sender, EventArgs e)
        {
            if ((Location.X != 0) || (Location.Y != 0))
            {
                Location = new Point(0, 0);
            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            Despedida despedida = new Despedida();
            despedida.ShowDialog();
        }
    }
}
