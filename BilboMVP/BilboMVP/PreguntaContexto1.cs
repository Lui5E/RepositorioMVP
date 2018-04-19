using System;
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
    public partial class PreguntaContexto1 : Form
    {
        public int numero_captura = 1;
        public string respuesta_puntuaje = "";
        public int numero_respuestas_API = 0;
        public PreguntaContexto1()
        {
            InitializeComponent();
        }

        private void PreguntaContexto1_Load(object sender, EventArgs e)
        {
            this.Location = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Location;
            this.MinimumSize = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size;
            this.MaximumSize = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size;
            String[] nombres = PantallaPrincipal.Nombre_Alumno.Split(' ');
            lbSaludo.Text = "Hola " + nombres[0];
            //Mostramos instrucción
            //lbInstruccion.Text = PantallaPrincipal.Cuestionario[PantallaPrincipal.index_pregunta, 2];
            timerCapturaContexto.Enabled = true;

            
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            //Verificar que haya contestado 
            if(txbRespuesta.Text!="")
            {
                timerCapturaContexto.Enabled = false;
                timerCapturaContexto.Stop();
                //Guardar la respuesta
                PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 0] = PantallaPrincipal.Cuestionario[PantallaPrincipal.index_pregunta, 0];
                PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 1] = PantallaPrincipal.Cuestionario[PantallaPrincipal.index_pregunta, 1];
                PantallaPrincipal.Respuestas[PantallaPrincipal.index_pregunta, 2] = txbRespuesta.Text;
                for(int i=0; i<=7; i++)
                {
                    PantallaPrincipal.Promedios_emociones[PantallaPrincipal.index_pregunta, i] /= numero_respuestas_API;
                }
                //
                txbRespuesta.Text = "";
                numero_respuestas_API = 0;
                //MessageBox.Show("Posición actual" + PantallaPrincipal.index_pregunta);
                //MessageBox.Show("Ultima posición" + ((Convert.ToInt16(PantallaPrincipal.Cuestionario.GetLength(0))) - 1).ToString());
                //Checar si estoy en la ultima posición "final matriz"
                if (PantallaPrincipal.index_pregunta == Convert.ToInt16(PantallaPrincipal.Cuestionario.GetLength(0)) - 1)
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
                    //MessageBox.Show("Siguiente formulario" + siguiente_formulario);
                    if (siguiente_formulario == 1)
                    {
                        //Recargar el formulario
                        lbInstruccion.Text = PantallaPrincipal.Cuestionario[PantallaPrincipal.index_pregunta, 2];
                        timerCapturaContexto.Enabled = true;
                        timerCapturaContexto.Start();
                    }
                    else if (siguiente_formulario == 2)
                    {
                        //MessageBox.Show("Sigue Panas");
                        this.Hide();
                        PantallaPrincipal.Panas = new PreguntaPanas();
                        PantallaPrincipal.activarPANAS = true;
                        PantallaPrincipal.Panas.Show();
                        
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Conteste lo que se le pide porfavor");
            }
            
        }

        private void PreguntaContexto1_Move(object sender, EventArgs e)
        {
            if ((Location.X != 0) || (Location.Y != 0))
            {
                Location = new Point(0, 0);

            }
        }

        private void timerCapturaContexto_Tick(object sender, EventArgs e)
        {
            //Guardar en carpeta "pero no se tienen permisos, por ello se guarda en Documents"
            //PantallaPrincipal.Imagen.Save(Application.StartupPath + "\\capturas\\capturacontexto"+numero_captura+".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            //string imageFilePath = Application.StartupPath + "\\capturas\\capturacontexto" + numero_captura + ".jpg";
            PantallaPrincipal.Imagen.Save(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\capturacontexto" + numero_captura + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            string imageFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\capturacontexto" + numero_captura + ".jpg";
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
            string uri = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize?";
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
            PantallaPrincipal.Respuestas_API[PantallaPrincipal.index_pregunta] += "@" + respuesta_puntuaje;
            Eliminar_captura_almacenada(imageFilePath);
            //MessageBox.Show(PantallaPrincipal.Respuestas_API[PantallaPrincipal.index_pregunta]);
        }

        private void Eliminar_captura_almacenada(string imageFilePath)
        {
            File.Delete(imageFilePath);
        }

        private void PreguntaContexto1_Activated(object sender, EventArgs e)
        {
            if(PantallaPrincipal.activarContexto)
            {
                PantallaPrincipal.activarContexto = false;
                lbInstruccion.Text = PantallaPrincipal.Cuestionario[PantallaPrincipal.index_pregunta, 2];
                timerCapturaContexto.Enabled = true;
                timerCapturaContexto.Start();
            }
            
        }

        private void PreguntaContexto1_Deactivate(object sender, EventArgs e)
        {
            
        }
    }
}
