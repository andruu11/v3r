using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.metodos;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        metodo_login nuevo = new metodo_login();
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            //boton minimizar
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            //boton cerrar
            Environment.Exit(0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            string cadenaEncriptada = encriptar.GetMD5(txb_pass.Text.Trim());

            string respuesta = nuevo.Autentificar(txb_usuario.Text.Trim(), cadenaEncriptada);
            if( respuesta == "Intentelo de nuevo"){
                MessageBox.Show(respuesta);
                txb_usuario.Clear();
                txb_pass.Clear();
            }else{
                MessageBox.Show(respuesta);
                Form2 formulario2 = new Form2();
                formulario2.Show();
                this.Hide();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
