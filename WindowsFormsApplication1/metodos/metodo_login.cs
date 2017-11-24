using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace WindowsFormsApplication1.metodos
{
     public class metodo_login
    {
        MySqlConnection con = new MySqlConnection("Server=127.0.0.1; database=f; Uid=root; pwd=;");
        public MySqlCommandBuilder msqlcmb;
        public DataSet ds = new DataSet();
        public MySqlDataAdapter adaptador;
        public MySqlCommand comando;
        public void Conectar()
        {
            try
            {
                con.Open();
                MessageBox.Show("Conectado con exito");
            }
            catch
            {
                MessageBox.Show("Conectado sin exito");
            }
            finally
            {
                con.Close();
            }
        }
       

        public string Autentificar(string a, string b)
        {
            string resultado = " "; //declaramos la variable entera
            string user_name = " ";
            try
            {
                MySqlCommand consultas = new MySqlCommand(string.Format("SELECT usuario FROM usuario WHERE usuario = '{0}' AND password = '{1}'", a,b ), con); // realizamos la consulta
                MySqlDataAdapter consultas_ap = new MySqlDataAdapter(consultas); //puente entre dataset y mysql
                DataTable dt = new DataTable(); // creamos data table
                consultas_ap.Fill(dt);//ejecuta consulta
                if (dt.Rows.Count == 1)
                {
                    user_name = dt.Rows[0][0].ToString();
                    resultado = "Bienvenido al sistema " + user_name ;
                }
                else
                {
                    resultado = "Intentelo de nuevo";
                }

            }
            catch
            {
            }
            return resultado;
        
    }
    }
}
