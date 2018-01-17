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
            PreguntaContexto1 contexto1 = new PreguntaContexto1();
            contexto1.ShowDialog();
            this.Close();
        }
    }
}
