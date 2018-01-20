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
            //Verificar que haya contestado 
            if ()
            {
                //Guardar la respuesta
                PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 0] = PantallaPrincipal.Cuestionario[PantallaPrincipal.index_pregunta, 0];
                PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 1] = PantallaPrincipal.Cuestionario[PantallaPrincipal.index_pregunta, 2];
                PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] = txbRespuesta.Text;
                //
                //Checar si estoy en la ultima posición "final matriz"
                if (PantallaPrincipal.index_pregunta == (Convert.ToInt16(PantallaPrincipal.Cuestionario[PantallaPrincipal.Cuestionario.GetLength(0), 1])) - 1)
                {
                    //Si estoy en la ultima posición
                    PantallaPrincipal.despedida = new Despedida();
                    PantallaPrincipal.despedida.ShowDialog();
                }
                else
                {
                    //Si no estoy en la ultima posición
                    PantallaPrincipal.index_pregunta++;
                    int siguiente_formulario = Convert.ToInt16(PantallaPrincipal.Cuestionario[PantallaPrincipal.index_pregunta, 1]);
                    if (siguiente_formulario == 1)
                    {
                        //Recargar el formulario
                        lbInstruccion.Text = PantallaPrincipal.Cuestionario[PantallaPrincipal.index_pregunta, 2];
                        txbRespuesta.Text = "";
                    }
                    else if (siguiente_formulario == 2)
                    {
                        PantallaPrincipal.Panas = new PreguntaPanas();
                        PantallaPrincipal.Panas.ShowDialog();
                    }
                }
                PantallaPrincipal.Panas = new PreguntaPanas();
                PantallaPrincipal.Panas.ShowDialog();
            }
            else
            {
                MessageBox.Show("Conteste lo que se le pide porfavor");
            }

        }

        private bool Verificar_respuestas()
        {
            bool retorno = false;
            for(int i=1; i<=20; i++)
            {
                if((txbRespuesta+i).text !="")
                {

                }
            }
        }
    }
}
