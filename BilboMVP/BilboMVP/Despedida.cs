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
            for (int i=0; i<=(Convert.ToInt16(PantallaPrincipal.Cuestionario.GetLength(0))) - 1; i++)
            {
                //MessageBox.Show(PantallaPrincipal.Fecha_Actual + "," + PantallaPrincipal.ID_Alumno + "," + PantallaPrincipal.sesion_cuestionario_id + "," + PantallaPrincipal.Respuestas[i, 0] + "," + PantallaPrincipal.Respuestas[i, 1] + "," + PantallaPrincipal.Promedios_emociones[i, 0] + "," + PantallaPrincipal.Promedios_emociones[i, 1] + "," + PantallaPrincipal.Promedios_emociones[i, 2] + "," + PantallaPrincipal.Promedios_emociones[i, 3] + "," + PantallaPrincipal.Promedios_emociones[i, 4] + "," + PantallaPrincipal.Promedios_emociones[i, 5] + "," + PantallaPrincipal.Promedios_emociones[i, 6] + "," + PantallaPrincipal.Promedios_emociones[i, 7]);
                try
                {
                    //Insercion a tabla "respuestas_alumnos"
                    //string cadena_comando1 = "INSERT INTO respuestas_alumnos VALUES('"+PantallaPrincipal.Fecha_Actual+"',"+PantallaPrincipal.ID_Alumno+ "," +PantallaPrincipal.sesion_cuestionario_id+ "," +PantallaPrincipal.Respuestas[i, 0]+ "," +PantallaPrincipal.Respuestas[i, 1]+ ",'" + PantallaPrincipal.Respuestas[i, 2] + "','"+PantallaPrincipal.Respuestas_API[i]+"')";
                    //MySqlCommand comando = new MySqlCommand(cadena_comando1, PantallaPrincipal.conexion);
                    //PantallaPrincipal.conexion.Open();
                    //comando.ExecuteNonQuery();
                    //Insercion de promedio de emociones por parte de la API en tabla "promedio_respuestas_api"
                    //string cadena_comando2= "INSERT INTO promedio_respuestas_api VALUES('"+PantallaPrincipal.Fecha_Actual + "'," + PantallaPrincipal.ID_Alumno + "," + PantallaPrincipal.sesion_cuestionario_id + "," + PantallaPrincipal.Respuestas[i, 0] + "," + PantallaPrincipal.Respuestas[i, 1] + ","+PantallaPrincipal.Promedios_emociones[i,0] + "," + PantallaPrincipal.Promedios_emociones[i, 1] + "," + PantallaPrincipal.Promedios_emociones[i, 2] + "," + PantallaPrincipal.Promedios_emociones[i, 3] + "," + PantallaPrincipal.Promedios_emociones[i, 4] + "," + PantallaPrincipal.Promedios_emociones[i, 5] + "," + PantallaPrincipal.Promedios_emociones[i, 6] + "," + PantallaPrincipal.Promedios_emociones[i, 7] + ")";
                    //MySqlCommand comando2 = new MySqlCommand(cadena_comando2, PantallaPrincipal.conexion);
                    //comando2.ExecuteNonQuery();
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
