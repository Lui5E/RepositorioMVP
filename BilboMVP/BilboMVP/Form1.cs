﻿using System;
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
using MySql.Data.MySqlClient;

namespace BilboMVP
{

    public partial class PantallaPrincipal : Form
    {
        //Variables globales
        public bool ExisteDispositivo = false;
        public FilterInfoCollection DispositivoDeVideo;
        public VideoCaptureDevice FuenteDeVideo = null;
        public int NumImagen = 1;
        public static bool Sesion_Activa =false;   //Bandera para saver si esta activa una sesión
        public static string Fecha_Actual;
        public static int sesion_cuestionario_id;
        public static int index_pregunta = 0;       //Orden de la pregunta a presentar del cuestionario
        public static bool activarContexto = true;    //Bandera para saber cuando se debe activar ek timerCapturaContexto
        public static bool activarPANAS = true;    //Bandera para saber cuando se debe activar ek timerCapturaPANAS
        //Datos del alumno que inicio sesión
        public static int ID_Alumno;
        public static string Nombre_Alumno;
        public static int Grado_Alumno;
        public static string Grupo_Alumno;
        public static int Tipo_Cuestionario_Alumno;
        //Matriz con el contenido del cuestionario a aplicar en la sesión
        public static string[,] Cuestionario;
        //Matriz con las respuestas del alumno
        public static string[,] Respuestas;
        public static string[] Respuestas_API;
        public static double[,] Promedios_emociones;
        //Variables que se pueden acceder desde otros formularios
        public static Bitmap Imagen = null;
        public static MySqlConnectionStringBuilder constructor;   //Creación del constructor de conexión
        public static MySqlConnection conexion;      //Creación del objeto de conexión
        //Instancias a formularios
        public static Loggin loggin;        //Instancia de formulario Loggin
        public static PreguntaContexto1 contexto1;  //Instancia de formulario Contexto
        public static PreguntaPanas Panas;  //Intancia de formulario Panas
        public static Despedida despedida;  //Instancia de formulario Despadida
        //
        public PantallaPrincipal()
        {
            InitializeComponent();
            BuscarDispositivos();
        }

        //Función para cargar las camaras existentes en el combobox
        public void CargarDispositivos(FilterInfoCollection Dispositivos)
        {
            for (int i = 0; i < Dispositivos.Count; i++)
            {
                cbxDispositivos.Items.Add(Dispositivos[i].Name.ToString());
                cbxDispositivos.Text = cbxDispositivos.Items[i].ToString();
            }

            
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
            this.Location = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Location;
            this.MinimumSize= System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size;
            this.MaximumSize= System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size;
            tableLayoutPanel1.MinimumSize = this.MinimumSize;
            tableLayoutPanel1.MaximumSize = this.MaximumSize;
            this.MaximizeBox = true;
            //Establecimiento de la conexión a la BD
            try
            {
                constructor = new MySqlConnectionStringBuilder();
                constructor.Server = "localhost";
                constructor.UserID = "root";
                constructor.Password = "";
                constructor.Database = "bilbo";
                conexion = new MySqlConnection(constructor.ToString());
                conexion.Open();
                conexion.Close();
                MessageBox.Show("Conexión establecida");
            }
            catch(Exception Exepcion)
            {
                MessageBox.Show("No se logro establecer conexión con el servidor:  \n\n" + Exepcion.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexion.Close();
            }
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

        private void btnLoggin_Click(object sender, EventArgs e)
        {
            loggin = new Loggin();
            loggin.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
