using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        int pw;
        bool hide;
        int pwx;
        public Form3()
        {
            InitializeComponent();
            pw = panel2.Width;
            pwx = panel2.Width - 190;
            hide = false;
            pictureBox2.Visible = false;
            MostrarDatos();
        }
        metodos.metodos_farmacia metodos_cliente = new metodos.metodos_farmacia();


        public void MostrarDatos()
        {
            //metodo para mostrar datos
            metodos_cliente.consulta("SELECT * FROM persona", "persona");
            dataGridView1.DataSource = metodos_cliente.ds.Tables["persona"];
            dataGridView1.Columns["telefono"].Visible = false;
            //borrar linea 35
            
            

        }


        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hide)
            {
                panel2.Width = panel2.Width + 10;

                if (panel2.Width == pw)
                {
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = false;
                    bunifuImageButton4.Location = new Point(192, 16);
                    timer1.Stop();
                    hide = false;
                    this.Refresh();
                }
            }
            else
            {
                panel2.Width = panel2.Width - 10;
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
                bunifuImageButton4.Location = new Point(3, 16);

                if (panel2.Width == pwx)
                {

                    timer1.Stop();
                    hide = true;
                    this.Refresh();
                }
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            Form2 usuarios = new Form2();
            usuarios.Show();
            this.Hide();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Form4 productos = new Form4();
            productos.Show();
            this.Hide();

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Form5 ventas = new Form5();
            ventas.Show();
            this.Hide();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            //boton cerrar
            Environment.Exit(0);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            //boton minimizar
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            
        }



       

        private void button1_Click(object sender, EventArgs e)
        {
         
            //nueva persona
            string consulta_agregars = "INSERT INTO persona VALUES ('" + Convert.ToInt32(txt_nitci.Text) + "','" + txt_nombre.Text + "' , '" + txt_appaterno.Text + "' , '" + txt_apmaterno.Text + "' , '" + 0 +"')";
            if (metodos_cliente.InsertarDatos(consulta_agregars))
            {

                MessageBox.Show("Datos insertados");

                MostrarDatos();
            }
            else
            {
                MessageBox.Show("Datos no insertados");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //forma para obtener los registros en los campos al dar click sobre un registro
            DataGridViewRow registro = dataGridView1.Rows[e.RowIndex];
            txt_nitci.Text = registro.Cells["ci_nit_persona"].Value.ToString();
            txt_nombre.Text = registro.Cells["nombres"].Value.ToString();
            txt_appaterno.Text = registro.Cells["ap_paterno"].Value.ToString();
            txt_apmaterno.Text = registro.Cells["ap_materno"].Value.ToString();
            
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            string actualizar = "nombres= '" + txt_nombre.Text + "',ap_paterno='" + txt_appaterno.Text + "',ap_materno='" + txt_apmaterno.Text + "', ci_nit_persona= '" + Convert.ToInt32(txt_nitci.Text) + "'";
            if (MessageBox.Show("Esta seguro de editar los datos del cliente", "Editar Cliente",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            == DialogResult.Yes)
            {
                if (metodos_cliente.ActualizarDatos("persona", actualizar, "ci_nit_persona=" + txt_nitci.Text.Trim()))
                {
                    MessageBox.Show("Datos actualizados");

                    MostrarDatos();

                }
                else
                {
                    MessageBox.Show("Datos no actualizados");

                }
            }
        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar el usuario", "Eliminar Usuario",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question)
       == DialogResult.Yes)
            {
                if (metodos_cliente.EliminarDatos("persona", "ci_nit_persona = " + txt_nitci.Text))
                {
                    MessageBox.Show("Datos de persona eliminado");
                    MostrarDatos();
                }
                else
                {
                    MessageBox.Show("Datos de persona no eliminado");
                }
            }
        }

      
        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            //boton para buscar a traves del CI
            metodos_cliente.Buscar("SELECT * FROM persona WHERE persona.ci_nit_persona=" + txt_nitci.Text.Trim(), "persona");
            dataGridView1.DataSource = metodos_cliente.ds.Tables["persona"];
            dataGridView1.Columns["telefono"].Visible = false;
        }

        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_nitci_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_appaterno_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_apmaterno_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
        

           
    }
}
