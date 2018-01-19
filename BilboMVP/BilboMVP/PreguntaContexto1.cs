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
    public partial class PreguntaContexto1 : Form
    {
        public PreguntaContexto1()
        {
            InitializeComponent();
        }

        private void PreguntaContexto1_Load(object sender, EventArgs e)
        {
            this.Location = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Location;
            this.MinimumSize = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size;
            this.MaximumSize = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size;
            
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            PantallaPrincipal.Panas = new PreguntaPanas();
            PantallaPrincipal.Panas.ShowDialog();
        }

        private void PreguntaContexto1_Move(object sender, EventArgs e)
        {
            if ((Location.X != 0) || (Location.Y != 0))
            {
                Location = new Point(0, 0);

            }
        }
    }
}
