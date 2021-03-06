﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;
using System.Net;

namespace BilboMVP
{
    public partial class PreguntaPanas : Form
    {
        public int numero_captura = 1;
        public string respuesta_puntuaje = "";
        public int numero_respuestas_API = 0;
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
            //((Label)Secundario.Controls["lbInstruccion"]).Text = PantallaPrincipal.Cuestionario[PantallaPrincipal.index_pregunta, 2];
            ((TextBox)Secundario.Controls["txbInstruccion"]).Text = PantallaPrincipal.Cuestionario[PantallaPrincipal.index_pregunta, 2];
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
                timerCapturaPANAS.Enabled = false;
                timerCapturaPANAS.Stop();
                Limpiar_textbox();
                for (int i = 0; i <= 7; i++)
                {
                    PantallaPrincipal.Promedios_emociones[PantallaPrincipal.index_pregunta, i] /= numero_respuestas_API;
                }
                numero_respuestas_API = 0;
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
                    //MessageBox.Show(siguiente_formulario.ToString());
                    if (siguiente_formulario == 2)
                    {
                        //Recargar el formulario
                        txbInstruccion.Text = PantallaPrincipal.Cuestionario[PantallaPrincipal.index_pregunta, 2];
                        timerCapturaPANAS.Enabled = true;
                        timerCapturaPANAS.Start();
                        
                    }
                    else if (siguiente_formulario == 1)
                    {
                        //MessageBox.Show("Sigue Contexto");
                        this.Hide();
                        PantallaPrincipal.activarContexto = true;
                        PantallaPrincipal.contexto1.Show();
                        
                        //Ya se activa el timer al verificar que la forma esta activa
                        //Form Formulario = (Form)PantallaPrincipal.contexto1.Controls["PreguntaContexto1"];
                        //((Timer)Formulario.Controls["timerCapturaContexto"]).Enabled = true;
                        TableLayoutPanel Princial = (TableLayoutPanel)PantallaPrincipal.Panas.Controls["tableLayoutPanelPrincipal"];
                        TableLayoutPanel Secundario = (TableLayoutPanel)Princial.Controls["tableLayoutPanel1"];
                        ((Label)Secundario.Controls["lbInstruccion"]).Text = PantallaPrincipal.Cuestionario[PantallaPrincipal.index_pregunta, 2];
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
            //MessageBox.Show("Entro a verificar respuestas");
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

        private void Limpiar_textbox()
        {
            txbRespuesta1.Text = "";
            txbRespuesta2.Text = "";
            txbRespuesta3.Text = "";
            txbRespuesta4.Text = "";
            txbRespuesta5.Text = "";
            txbRespuesta6.Text = "";
            txbRespuesta7.Text = "";
            txbRespuesta8.Text = "";
            txbRespuesta9.Text = "";
            txbRespuesta10.Text = "";
            txbRespuesta11.Text = "";
            txbRespuesta12.Text = "";
            txbRespuesta13.Text = "";
            txbRespuesta14.Text = "";
            txbRespuesta15.Text = "";
            txbRespuesta16.Text = "";
            txbRespuesta17.Text = "";
            txbRespuesta18.Text = "";
            txbRespuesta19.Text = "";
            txbRespuesta20.Text = "";

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
            //Guardar en carpeta "pero no se tienen permisos, por ello se guarda en Documents"
            //PantallaPrincipal.Imagen.Save(Application.StartupPath + "\\capturas\\capturaPANAS" + numero_captura + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            //string imageFilePath = Application.StartupPath + "\\capturas\\capturaPANAS" + numero_captura + ".jpg";
            PantallaPrincipal.Imagen.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\capturaPANAS" + numero_captura + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            string imageFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\capturaPANAS" + numero_captura + ".jpg";
            numero_captura++;
            MakeRequest(imageFilePath);
        }

        //Funciones de la API
        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
            //MessageBox.Show(imageFilePath);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            byte[] regreso = binaryReader.ReadBytes((int)fileStream.Length);
            fileStream.Close();
            return regreso;
        }

        public async void MakeRequest(string imageFilePath)
        {
            var client = new HttpClient();

            // Request headers - replace this example key with your valid key.
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "f5048231427a4e288ceb67880438b52b"); // 

            // NOTE: You must use the same region in your REST call as you used to obtain your subscription keys.
            //   For example, if you obtained your subscription keys from westcentralus, replace "westus" in the 
            //   URI below with "westcentralus".
            string uri = "https://westus.api.cognitive.microsoft.com/face/v1.0/detect?";
            HttpResponseMessage response;
            string responseContent;

            // Request body. Try this sample with a locally stored JPEG image.
            byte[] byteData = GetImageAsByteArray(imageFilePath);

            using (var content = new ByteArrayContent(byteData))
            {
                // This example uses content type "application/octet-stream".
                // The other content types you can use are "application/json" and "multipart/form-data".
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(uri, content);
                responseContent = response.Content.ReadAsStringAsync().Result;

            }

            // A peek at the raw JSON response.
            //MessageBox.Show(responseContent);

            // Processing the JSON into manageable objects.
            JToken rootToken = JArray.Parse(responseContent).First;

            // First token is always the faceRectangle identified by the API.
            JToken faceRectangleToken = rootToken.First;

            // Second token is all emotion scores.
            JToken scoresToken = rootToken.Last;

            // Show all face rectangle dimensions
            JEnumerable<JToken> faceRectangleSizeList = faceRectangleToken.First.Children();
            foreach (var size in faceRectangleSizeList)
            {
                //MessageBox.Show(size.ToString());
            }

            // Show all scores
            JEnumerable<JToken> scoreList = scoresToken.First.Children();
            respuesta_puntuaje = "";
            int i = 0;
            foreach (var score in scoreList)
            {
                string[] valor = score.ToString().Split(':');
                //MessageBox.Show(valor[1]);
                PantallaPrincipal.Promedios_emociones[PantallaPrincipal.index_pregunta, i] += Convert.ToDouble(valor[1]);
                i++;
                //MessageBox.Show(score.ToString());
                respuesta_puntuaje += score.ToString();
            }
            numero_respuestas_API++;
            PantallaPrincipal.Respuestas_API[PantallaPrincipal.index_pregunta] += "@" + respuesta_puntuaje; ;
            Eliminar_captura_almacenada(imageFilePath);
            //MessageBox.Show(PantallaPrincipal.Respuestas_API[PantallaPrincipal.index_pregunta]);
        }

        private void Eliminar_captura_almacenada(string imageFilePath)
        {
            File.Delete(imageFilePath);
        }

        private void PreguntaPanas_Activated(object sender, EventArgs e)
        {
            if(PantallaPrincipal.activarPANAS)
            {
                PantallaPrincipal.activarPANAS = false;
                txbInstruccion.Text = PantallaPrincipal.Cuestionario[PantallaPrincipal.index_pregunta, 2];
                timerCapturaPANAS.Enabled = true;
                timerCapturaPANAS.Start();
            }
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
