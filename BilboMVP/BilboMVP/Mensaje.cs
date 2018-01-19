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
    public partial class Mensaje : Form
    {
        public int Ypos;
        public int Xpos;
        public Mensaje()
        {
            InitializeComponent();
        }

        private void Mensaje_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            this.Location = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Location;
            this.MinimumSize = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size;
            this.MaximumSize = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size;
            this.MaximizeBox = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PantallaPrincipal.loggin.Close();
            timer1.Stop();
            timer1.Enabled = false;
            PantallaPrincipal.contexto1 = new PreguntaContexto1();
            PantallaPrincipal.contexto1.ShowDialog();
            this.Close();
        }

        private void tableLayoutPanel1_Move(object sender, EventArgs e)
        {
            
        }

        private void Mensaje_Move(object sender, EventArgs e)
        {
            
            if ((Location.X!=0) || (Location.Y != 0))
            {
                Location = new Point(0, 0);
            }
        }
    }
}
