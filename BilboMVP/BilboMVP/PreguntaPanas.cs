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
            ((Label)Secundario.Controls["lbInstruccion"]).Text = PantallaPrincipal.Cuestionario[PantallaPrincipal.index_pregunta, 2];
            
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
            if (Verificar_respuestas())
            {
                //Checar si estoy en la ultima posición "final matriz"
                if (PantallaPrincipal.index_pregunta == (Convert.ToInt16(PantallaPrincipal.Cuestionario.GetLength(0))) - 1)
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
                    if (siguiente_formulario == 2)
                    {
                        //Recargar el formulario
                        lbInstruccion.Text = PantallaPrincipal.Cuestionario[PantallaPrincipal.index_pregunta, 2];
                        //txbRespuesta.Text = "";
                    }
                    else if (siguiente_formulario == 2)
                    {
                        PantallaPrincipal.contexto1.Show();
                    }
                }
                
            }
            else
            {
                MessageBox.Show("No contesto todas las medidas o la escala no es la correcta, favor de contestar como se pide");
            }

        }

        private bool Verificar_respuestas()
        {
            bool retorno = false;
            MessageBox.Show("Entro a verificar respuestas");
            if((txbRespuesta1.Text=="1")||(txbRespuesta1.Text == "2") || (txbRespuesta1.Text == "3") || (txbRespuesta1.Text == "4") || (txbRespuesta1.Text == "5"))
            {
                //Guardar la respuesta
                PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 0] = PantallaPrincipal.Cuestionario[PantallaPrincipal.index_pregunta, 0];
                PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 1] = PantallaPrincipal.Cuestionario[PantallaPrincipal.index_pregunta, 1];
                PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] = txbRespuesta1.Text;
                if ((txbRespuesta2.Text == "1") || (txbRespuesta2.Text == "2") || (txbRespuesta2.Text == "3") || (txbRespuesta2.Text == "4") || (txbRespuesta2.Text == "5"))
                {
                    PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] +=','+ txbRespuesta2.Text;
                    if ((txbRespuesta3.Text == "1") || (txbRespuesta3.Text == "2") || (txbRespuesta3.Text == "3") || (txbRespuesta3.Text == "4") || (txbRespuesta3.Text == "5"))
                    {
                        PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] += ',' + txbRespuesta3.Text;
                        if ((txbRespuesta4.Text == "1") || (txbRespuesta4.Text == "2") || (txbRespuesta4.Text == "3") || (txbRespuesta4.Text == "4") || (txbRespuesta4.Text == "5"))
                        {
                            PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] += ',' + txbRespuesta4.Text;
                            if ((txbRespuesta5.Text == "1") || (txbRespuesta5.Text == "2") || (txbRespuesta5.Text == "3") || (txbRespuesta5.Text == "4") || (txbRespuesta5.Text == "5"))
                            {
                                PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] += ',' + txbRespuesta5.Text;
                                if ((txbRespuesta6.Text == "1") || (txbRespuesta6.Text == "2") || (txbRespuesta6.Text == "3") || (txbRespuesta6.Text == "4") || (txbRespuesta6.Text == "5"))
                                {
                                    PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] += ',' + txbRespuesta6.Text;
                                    if ((txbRespuesta7.Text == "1") || (txbRespuesta7.Text == "2") || (txbRespuesta7.Text == "3") || (txbRespuesta7.Text == "4") || (txbRespuesta7.Text == "5"))
                                    {
                                        PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] += ',' + txbRespuesta7.Text;
                                        if ((txbRespuesta8.Text == "1") || (txbRespuesta8.Text == "2") || (txbRespuesta8.Text == "3") || (txbRespuesta8.Text == "4") || (txbRespuesta8.Text == "5"))
                                        {
                                            PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] += ',' + txbRespuesta8.Text;
                                            if ((txbRespuesta9.Text == "1") || (txbRespuesta9.Text == "2") || (txbRespuesta9.Text == "3") || (txbRespuesta9.Text == "4") || (txbRespuesta9.Text == "5"))
                                            {
                                                PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] += ',' + txbRespuesta9.Text;
                                                if ((txbRespuesta10.Text == "1") || (txbRespuesta10.Text == "2") || (txbRespuesta10.Text == "3") || (txbRespuesta10.Text == "4") || (txbRespuesta10.Text == "5"))
                                                {
                                                    PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] += ',' + txbRespuesta10.Text;
                                                    if ((txbRespuesta11.Text == "1") || (txbRespuesta11.Text == "2") || (txbRespuesta11.Text == "3") || (txbRespuesta11.Text == "4") || (txbRespuesta11.Text == "5"))
                                                    {
                                                        PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] += ',' + txbRespuesta11.Text;
                                                        if ((txbRespuesta12.Text == "1") || (txbRespuesta12.Text == "2") || (txbRespuesta12.Text == "3") || (txbRespuesta12.Text == "4") || (txbRespuesta12.Text == "5"))
                                                        {
                                                            PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] += ',' + txbRespuesta12.Text;
                                                            if ((txbRespuesta13.Text == "1") || (txbRespuesta13.Text == "2") || (txbRespuesta13.Text == "3") || (txbRespuesta13.Text == "4") || (txbRespuesta13.Text == "5"))
                                                            {
                                                                PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] += ',' + txbRespuesta13.Text;
                                                                if ((txbRespuesta14.Text == "1") || (txbRespuesta14.Text == "2") || (txbRespuesta14.Text == "3") || (txbRespuesta14.Text == "4") || (txbRespuesta14.Text == "5"))
                                                                {
                                                                    PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] += ',' + txbRespuesta14.Text;
                                                                    if ((txbRespuesta15.Text == "1") || (txbRespuesta15.Text == "2") || (txbRespuesta15.Text == "3") || (txbRespuesta15.Text == "4") || (txbRespuesta15.Text == "5"))
                                                                    {
                                                                        PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] += ',' + txbRespuesta15.Text;
                                                                        if ((txbRespuesta16.Text == "1") || (txbRespuesta16.Text == "2") || (txbRespuesta16.Text == "3") || (txbRespuesta16.Text == "4") || (txbRespuesta16.Text == "5"))
                                                                        {
                                                                            PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] += ',' + txbRespuesta16.Text;
                                                                            if ((txbRespuesta17.Text == "1") || (txbRespuesta17.Text == "2") || (txbRespuesta17.Text == "3") || (txbRespuesta17.Text == "4") || (txbRespuesta17.Text == "5"))
                                                                            {
                                                                                PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] += ',' + txbRespuesta17.Text;
                                                                                if ((txbRespuesta18.Text == "1") || (txbRespuesta18.Text == "2") || (txbRespuesta18.Text == "3") || (txbRespuesta18.Text == "4") || (txbRespuesta18.Text == "5"))
                                                                                {
                                                                                    PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] += ',' + txbRespuesta18.Text;
                                                                                    if ((txbRespuesta19.Text == "1") || (txbRespuesta19.Text == "2") || (txbRespuesta19.Text == "3") || (txbRespuesta19.Text == "4") || (txbRespuesta19.Text == "5"))
                                                                                    {
                                                                                        PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] += ',' + txbRespuesta19.Text;
                                                                                        if ((txbRespuesta20.Text == "1") || (txbRespuesta20.Text == "2") || (txbRespuesta20.Text == "3") || (txbRespuesta20.Text == "4") || (txbRespuesta20.Text == "5"))
                                                                                        {
                                                                                            PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] += ',' + txbRespuesta20.Text;
                                                                                            retorno = true;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return retorno;
        }

        private void txbRespuesta1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbRespuesta2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbRespuesta3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbRespuesta4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbRespuesta5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbRespuesta6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbRespuesta7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbRespuesta8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbRespuesta9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbRespuesta10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbRespuesta11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbRespuesta12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbRespuesta13_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbRespuesta13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbRespuesta14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbRespuesta15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbRespuesta16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbRespuesta17_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbRespuesta18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbRespuesta19_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbRespuesta20_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void timerCapturaPANAS_Tick(object sender, EventArgs e)
        {

        }
    }
}
