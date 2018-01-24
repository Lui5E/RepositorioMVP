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
    public partial class Despedida : Form
    {
        public int Ypos;
        public int Xpos;
        public Despedida()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            PantallaPrincipal.contexto1.Close();
            PantallaPrincipal.Panas.Close();
            this.Close();
        }

        private void Despedida_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            Ypos = Location.Y;
            Xpos = Location.X;
            for(int i=0; i<=PantallaPrincipal.Respuestas.GetLength(0)-1; i++)
            {
                MessageBox.Show("Respuesta No: "+i+" , "+PantallaPrincipal.Respuestas[i,2]);
            }
            Almacenar_respuestas();
        }

        private void Despedida_Move(object sender, EventArgs e)
        {
            if ((Xpos > 0))
            {
                Location = new Point(Xpos, Ypos);
            }
        }

        private void Almacenar_respuestas()
        {
            /*int Alumno_id = Convert.ToInt16(PantallaPrincipal.ID_Alumno);
            int Cuestionario_id = Convert.ToInt16(PantallaPrincipal.sesion_cuestionario_id);
            int Numero_respuesta = Convert.ToInt16(PantallaPrincipal.Respuestas[0, 0]);
            MessageBox.Show(PantallaPrincipal.Respuestas[0, 1]);
            int Tipo_respuesta = Convert.ToInt16(PantallaPrincipal.Respuestas[0, 1]);
            string Respuesta = PantallaPrincipal.Respuestas[0, 2];
            string cadena_comando1 = "INSERT INTO respuestas_alumnos VALUES(" + Alumno_id + "," + Cuestionario_id + "," + Numero_respuesta + "," + Tipo_respuesta + ",'" + Respuesta + "')";
            MessageBox.Show(cadena_comando1);
            try
            {
                
                //string cadena_comando1 = "INSERT INTO respuestas_alumnos VALUES(" + Alumno_id + "," + Cuestionario_id + "," + Numero_respuesta + "," + Tipo_respuesta + ",'" + Respuesta + "')";
                MessageBox.Show(cadena_comando1);
                MySqlCommand comando = new MySqlCommand(cadena_comando1, PantallaPrincipal.conexion);
                PantallaPrincipal.conexion.Open();
                comando.ExecuteNonQuery();
                MessageBox.Show("Prueba directa exitosa");
                PantallaPrincipal.conexion.Close();
            }
            catch
            {
                MessageBox.Show("Prueba directa fallida");
            }*/
            for (int i=0; i<=(Convert.ToInt16(PantallaPrincipal.Cuestionario.GetLength(0))) - 1; i++)
            {
                try
                {
                    string cadena_comando1 = "INSERT INTO respuestas_alumnos VALUES('"+PantallaPrincipal.Fecha_Actual+"',"+PantallaPrincipal.ID_Alumno+ "," +PantallaPrincipal.sesion_cuestionario_id+ "," +PantallaPrincipal.Respuestas[i, 0]+ "," +PantallaPrincipal.Respuestas[i, 1]+ ",'" + PantallaPrincipal.Respuestas[i, 2] + "','"+PantallaPrincipal.Respuestas_API[i]+"')";
                    MySqlCommand comando = new MySqlCommand(cadena_comando1, PantallaPrincipal.conexion);
                    PantallaPrincipal.conexion.Open();
                    comando.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("No se pudieron guardar las respuestas del alumno");
                }
                PantallaPrincipal.conexion.Close();
            }
            
        }
    }
}
