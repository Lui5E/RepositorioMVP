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
    }
}
