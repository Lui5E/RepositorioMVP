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
    public partial class Loggin : Form
    {
        public int Ypos;
        public int Xpos;
        public int Numero = 1;
        public Loggin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PantallaPrincipal.Imagen.Save(Application.StartupPath + "\\capturas\\capturaForm2" + Numero.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Numero++;
        }

        private void Loggin_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            Ypos = Location.Y;
            Xpos = Location.X;
        }

        private void Loggin_Move(object sender, EventArgs e)
        {
            if ((Xpos > 0))
            {
                Location = new Point(Xpos, Ypos);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //Si se autentifico
            Mensaje mensajeform = new Mensaje();
            mensajeform.ShowDialog();
            //
        }
    }
}
