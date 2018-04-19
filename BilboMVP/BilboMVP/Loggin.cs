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
using System.IO;
using System.Runtime.InteropServices;
using System.Net;

namespace BilboMVP
{
    public partial class Loggin : Form
    {
        public int Ypos;
        public int Xpos;
        public int Numero = 1;
        public Loggin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Loggin_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            Ypos = Location.Y;
            Xpos = Location.X;
        }

        private void Loggin_Move(object sender, EventArgs e)
        {
            if ((Xpos > 0))
            {
                Location = new Point(Xpos, Ypos);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(Autentificacion())   //Si se autentifico
            {
                PantallaPrincipal.Sesion_Activa = true;
                Obtener_fecha_actual();
                Mensaje mensajeform = new Mensaje();
                mensajeform.ShowDialog();
            }
        }

        private bool Autentificacion()
        {
            bool valor = false;
            //Validación de que el usaurio ha ingresado un nombre de usuario y una contraseña
            if(txbCorreo.Text!="" && txbContra.Text!="")
            {
                //Consulta de datos del alumno con la BD
                MySqlCommand comando = new MySqlCommand("SELECT * FROM alumnos", PantallaPrincipal.conexion);
                PantallaPrincipal.conexion.Open();
                MySqlDataReader resultado = comando.ExecuteReader();
                if (resultado.HasRows)
                {
                    while (resultado.Read())
                    {
                        //Si el nombre del usaurio y contraseña coinciden
                        if((resultado.GetValue(1).ToString()==txbCorreo.Text) && (resultado.GetValue(2).ToString()==txbContra.Text))
                        {
                            PantallaPrincipal.ID_Alumno = Convert.ToInt16(resultado.GetValue(0));
                            PantallaPrincipal.Nombre_Alumno = resultado.GetValue(3).ToString();
                            PantallaPrincipal.Grado_Alumno = Convert.ToInt16(resultado.GetValue(4));
                            PantallaPrincipal.Grupo_Alumno = resultado.GetValue(5).ToString();
                            PantallaPrincipal.Tipo_Cuestionario_Alumno = Convert.ToInt16(resultado.GetValue(6));
                            valor = true;
                        }
                    }
                    if(valor==false)
                    {
                        MessageBox.Show("El usuario no existe");
                    }

                }
                resultado.Close();
                PantallaPrincipal.conexion.Close();
            }
            else
            {
                MessageBox.Show("Ingresa todos los datos solicitados");
                
            }
            return valor;
        }
        private void Obtener_fecha_actual()
        {
            DateTime Hoy = DateTime.Today;
            PantallaPrincipal.Fecha_Actual = Hoy.ToString("yyyy-MM-dd");
        }

        private void txbContra_Enter(object sender, EventArgs e)
        {
           
        }

        private void txbContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar==(int)Keys.Enter)
            {
                if (Autentificacion())   //Si se autentifico
                {
                    PantallaPrincipal.Sesion_Activa = true;
                    Obtener_fecha_actual();
                    Mensaje mensajeform = new Mensaje();
                    mensajeform.ShowDialog();
                }
            }
        }
    }
}
