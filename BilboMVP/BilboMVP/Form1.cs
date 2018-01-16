using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace BilboMVP
{

    public partial class PantallaPrincipal : Form
    {
        //Variables globales
        public bool ExisteDispositivo = false;
        public FilterInfoCollection DispositivoDeVideo;
        public VideoCaptureDevice FuenteDeVideo = null;
        public static Bitmap Imagen = null;
        public int NumImagen = 1;
        public PantallaPrincipal()
        {
            InitializeComponent();
            BuscarDispositivos();
        }

        //Función para cargar las camaras existentes en el combobox
        public void CargarDispositivos(FilterInfoCollection Dispositivos)
        {
            for (int i = 0; i < Dispositivos.Count; i++) ;

            cbxDispositivos.Items.Add(Dispositivos[0].Name.ToString());
            cbxDispositivos.Text = cbxDispositivos.Items[0].ToString();
            if(Dispositivos.Count > 2)
            {
                cbxDispositivos.Visible = true;
            }
            else
            {
                cbxDispositivos.Visible = false;
            }
        }

        //Función para buscar los dispositivos en el equipo y pasarselos a la función "CargarDispositivos"
        public void BuscarDispositivos()
        {
            DispositivoDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (DispositivoDeVideo.Count == 0)
            {
                ExisteDispositivo = false;
            }

            else
            {
                ExisteDispositivo = true;
                CargarDispositivos(DispositivoDeVideo);

            }
        }

        //Función para tomar la captura de la imagen
        public void Nuevo_Frame(object sender, NewFrameEventArgs eventArgs)
        {
            Imagen = (Bitmap)eventArgs.Frame.Clone();
        }

        //Función para iniciar la conexión con la WebCam
        public void IniciarFuenteDeVideo()
        {
            if (ExisteDispositivo)
            {
                FuenteDeVideo = new VideoCaptureDevice(DispositivoDeVideo[cbxDispositivos.SelectedIndex].MonikerString);
                FuenteDeVideo.NewFrame += new NewFrameEventHandler(Nuevo_Frame);
                FuenteDeVideo.Start(); 
                EstadoDispositivo.Text = "Iniciando...";
            }
            else
            {
                EstadoDispositivo.Text = "No se encontro el dispositivo";
            }
        }

        //Función para terminar la conexión con la WebCam
        public void TerminarFuenteDeVideo()
        {
            if (!(FuenteDeVideo == null))
                if (FuenteDeVideo.IsRunning)
                {
                    FuenteDeVideo.SignalToStop();
                    FuenteDeVideo = null;
                }

        }

        private void labelTitulo_Click(object sender, EventArgs e)
        {

        }

        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {
            IniciarFuenteDeVideo();
            TimerIniciado.Enabled = true;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Imagen.Save(Application.StartupPath + "\\capturas\\captura" + NumImagen.ToString() + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            NumImagen++;
            Loggin loggin = new Loggin();
            loggin.Show();
        }

        private void PantallaPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            TerminarFuenteDeVideo();
        }
        
        //Función para checar cuando ya se haya inicializado la camara
        private void TimerIniciado_Tick(object sender, EventArgs e)
        {
            if(FuenteDeVideo.IsRunning)
            {
                EstadoDispositivo.Text = "Listo";
                TimerIniciado.Stop();
                TimerIniciado.Enabled = false;
            }
            
        }
    }
}
