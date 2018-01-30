using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
            this.Location = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Location;
            this.MinimumSize = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size;
            this.MaximumSize = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size;
            this.MaximizeBox = true;
            String[] nombres = PantallaPrincipal.Nombre_Alumno.Split(' ');
            lbSaludo.Text = "Buenos días "+nombres[0];
            if(Cargar_Cuestionario())
            {
                timer1.Enabled = true;
            }
            else
            {
                this.Close();
                PantallaPrincipal.loggin.Close();
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PantallaPrincipal.loggin.Close();
            timer1.Stop();
            timer1.Enabled = false;
            if(Convert.ToInt16(PantallaPrincipal.Cuestionario[0,1])==1)
            {
                PantallaPrincipal.contexto1 = new PreguntaContexto1();
                PantallaPrincipal.contexto1.ShowDialog();
            }
            else
            {
                PantallaPrincipal.Panas = new PreguntaPanas();
                PantallaPrincipal.Panas.ShowDialog();
            }
            
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
        private bool Cargar_Cuestionario()
        {
            bool retorno = false;
            PantallaPrincipal.sesion_cuestionario_id = -1;
            string cadena_comando = "SELECT sesion_cuestionario_id FROM sesion WHERE fecha_sesion='" + PantallaPrincipal.Fecha_Actual + "' AND sesion_alumno_tipo_cuestionario='" + PantallaPrincipal.Tipo_Cuestionario_Alumno+"'";
            MySqlCommand comando = new MySqlCommand(cadena_comando, PantallaPrincipal.conexion);
            PantallaPrincipal.conexion.Open();
            MySqlDataReader resultado = comando.ExecuteReader();
            if (resultado.HasRows)
            {
                while (resultado.Read())
                {
                    PantallaPrincipal.sesion_cuestionario_id = Convert.ToInt16(resultado.GetValue(0));
                }
            }
            else
            {
                MessageBox.Show("No tienes cuestionario que contestar el día de hoy");
            }
            resultado.Close();
            PantallaPrincipal.conexion.Close();
            if (PantallaPrincipal.sesion_cuestionario_id >= 1)
            {
                //Contar los registros retornados por la consulta
                MySqlCommand comandoCount = new MySqlCommand("SELECT COUNT(ID) numero_instruccion, tipo_instruccion, instruccion FROM cuestionarios WHERE cuestionario_id = '" + Convert.ToInt16(PantallaPrincipal.sesion_cuestionario_id) + "'", PantallaPrincipal.conexion);
                PantallaPrincipal.conexion.Open();
                int filas = Convert.ToInt16(comandoCount.ExecuteScalar());
                PantallaPrincipal.Cuestionario = new string[filas, 3];  //Creacion matriz Cuestionario
                PantallaPrincipal.Respuestas = new string[filas, 3];    //Creacion matriz Respuestas
                PantallaPrincipal.Respuestas_API = new string[filas];   //Creacion vector Respuestas de la API
                PantallaPrincipal.Promedios_emociones = new double[filas, 8];   //Creacion matriz Promedios emociones de la API
                //MessageBox.Show(filas.ToString());  
                PantallaPrincipal.conexion.Close();
                //
                MySqlCommand comando2 = new MySqlCommand("SELECT numero_instruccion, tipo_instruccion, instruccion FROM cuestionarios WHERE cuestionario_id = '"+Convert.ToInt16(PantallaPrincipal.sesion_cuestionario_id)+"'", PantallaPrincipal.conexion);
                PantallaPrincipal.conexion.Open();
                MySqlDataReader resultado2 = comando2.ExecuteReader();
                int index = 0;
                if (resultado2.HasRows)
                {
                    while (resultado2.Read())
                    {
                        PantallaPrincipal.Cuestionario[index, 0] = resultado2.GetValue(0).ToString();
                        PantallaPrincipal.Cuestionario[index, 1] = resultado2.GetValue(1).ToString();
                        PantallaPrincipal.Cuestionario[index, 2] = resultado2.GetValue(2).ToString();
                        index++;
                    }
                    retorno = true;
                }
                resultado2.Close();
                PantallaPrincipal.conexion.Close();
            }
            return retorno;
        }
    }
}
