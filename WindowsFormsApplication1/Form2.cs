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
    public partial class Form2 : Form
    {
        int pw;
        bool hide;
        int pwx;
        public Form2()
        {
            InitializeComponent();
            
            pw = panel2.Width;
            pwx = panel2.Width - 190;
            hide = false;
            pictureBox2.Visible = false;
            MostrarCombo();
            MostrarDatos();
        }
       
        metodos.metodos_farmacia metodos_usuario = new metodos.metodos_farmacia();
        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            timer1.Start();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Form4 productos = new Form4();
            productos.Show();
            this.Hide();
        }

              

        private void bunifuImageButton3_Click_1(object sender, EventArgs e)
        {
            //boton maximizar
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBox1.Text);
        }

        public void MostrarCombo()
        {
            //metodo para obtener los datos en el combo
            metodos_usuario.consulta("SELECT * FROM cargo", "cargo");
            comboBox1.DataSource = metodos_usuario.ds.Tables["cargo"];
            comboBox1.DisplayMember = "des_cargo";
            comboBox1.ValueMember = "id_cargo";

        }

        public void MostrarDatos()
        {
            //metodo para mostrar datos
            metodos_usuario.consulta("SELECT * FROM usuario INNER JOIN persona ON usuario.ci_nit_persona= persona.ci_nit_persona INNER JOIN cargo ON cargo.id_cargo = usuario.id_cargo", "persona");
            dataGridView1.DataSource = metodos_usuario.ds.Tables["persona"];
            dataGridView1.Columns["password"].Visible = false;
            dataGridView1.Columns["id_usuario"].Visible = false;
            dataGridView1.Columns["ci_nit_persona1"].Visible = false;
            dataGridView1.Columns["id_cargo"].Visible = false;
            dataGridView1.Columns["id_cargo1"].Visible = false;
            
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            int var_verificacion = metodos.validar.IgualarPassword(textBox7.Text, textBox8.Text);
            if (var_verificacion == 1)
            {
                string pass_encriptado = metodos.encriptar.GetMD5(textBox7.Text.Trim());
                //nueva persona
                string consulta_agregar = "INSERT INTO persona VALUES ('" + Convert.ToInt32(textBox1.Text) + "','" + textBox2.Text + "' , '" + textBox3.Text + "' , '" + textBox4.Text + "' , '" + Convert.ToInt32(textBox5.Text)+ "')";
                string consulta_agregar_usuario = "INSERT INTO usuario VALUES ('" + "" + "','" + textBox6.Text + "','" + pass_encriptado + "' , '" + Convert.ToInt32(textBox1.Text) + "' , '" + Convert.ToInt32(comboBox1.SelectedValue) +"')";
                if (metodos_usuario.InsertarDatos(consulta_agregar) && metodos_usuario.InsertarDatos(consulta_agregar_usuario))
                {
               
                   MessageBox.Show("Datos insertados");
                   
                   MostrarDatos();
                   
                }
                else
                {
                    MessageBox.Show("Datos no insertados");
                }
                              
                
            }
            else {
                MessageBox.Show("Las contraseñas deben coincidir intentelo de nuevo");
                textBox7.Clear();
                textBox8.Clear();
                textBox7.Focus();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //forma para obtener los registros en los campos al dar click sobre un registro
            DataGridViewRow registro = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = registro.Cells["ci_nit_persona"].Value.ToString();
            textBox2.Text = registro.Cells["nombres"].Value.ToString();
            textBox3.Text = registro.Cells["ap_paterno"].Value.ToString();
            textBox4.Text = registro.Cells["ap_materno"].Value.ToString();
            textBox5.Text = registro.Cells["telefono"].Value.ToString();
            comboBox1.Text = registro.Cells["des_cargo"].Value.ToString();
            textBox6.Text = registro.Cells["usuario"].Value.ToString();
            
        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            //Declaramos la variable nombre
            string psw;
            if (MessageBox.Show("Desea actualizar el password", "Actualizar password",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question)
       == DialogResult.Yes)
            {
                //Entrada de datos medianta un inputbox
                psw = Microsoft.VisualBasic.Interaction.InputBox("Ingrese password", "Actualizar Password", " ", 100, 0);
                string psw_encriptado = metodos.encriptar.GetMD5(psw);
                //boton para actualizar datos
                string actualizar = "nombres= '" + textBox2.Text + "',ap_paterno='" + textBox3.Text + "',ap_materno='" + textBox4.Text + "', telefono= '" + Convert.ToInt32(textBox5.Text) + "'";
                string actualizar_usuario = "usuario= '" + textBox6.Text + "',password='" + psw_encriptado + "',id_cargo='" + Convert.ToInt32(comboBox1.SelectedValue) + "'";
                if (MessageBox.Show("Esta seguro de editar los datos del usuario", "Editar Usuario",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question)
       == DialogResult.Yes)
                {
                    if (metodos_usuario.ActualizarDatos("persona", actualizar, "ci_nit_persona=" + textBox1.Text.Trim()) && metodos_usuario.ActualizarDatos("usuario", actualizar_usuario, "ci_nit_persona=" + textBox1.Text.Trim()))
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
            else {
                //boton para actualizar datos
                string actualizar = "nombres= '" + textBox2.Text + "',ap_paterno='" + textBox3.Text + "',ap_materno='" + textBox4.Text + "', telefono= '" + Convert.ToInt32(textBox5.Text) + "'";
                string actualizar_usuario = "usuario = '" + textBox6.Text +"',id_cargo='" + Convert.ToInt32(comboBox1.SelectedValue) + "'";
                if (MessageBox.Show("Esta seguro de editar los datos del usuario", "Editar Usuario",
      MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      == DialogResult.Yes)
                {
                    if (metodos_usuario.ActualizarDatos("persona", actualizar, "ci_nit_persona=" + textBox1.Text.Trim()) && metodos_usuario.ActualizarDatos("usuario", actualizar_usuario, "ci_nit_persona=" + textBox1.Text.Trim()))
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
           
                
            
        }

        private void bunifuFlatButton10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea eliminar el usuario", "Eliminar Usuario",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        == DialogResult.Yes)
            {
                if (metodos_usuario.EliminarDatos("persona", "ci_nit_persona = " + textBox1.Text) && metodos_usuario.EliminarDatos("usuario", "ci_nit_persona = " + textBox1.Text))
                {
                    MessageBox.Show("Datos de persona eliminado");
                    
                }
                else
                {
                    MessageBox.Show("Datos de persona no eliminado");
                }
                MostrarDatos();
            }

            
        }

        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            //boton para buscar a traves del CI
            metodos_usuario.Buscar("SELECT * FROM usuario INNER JOIN persona ON usuario.ci_nit_persona= persona.ci_nit_persona INNER JOIN cargo ON cargo.id_cargo = usuario.id_cargo WHERE persona.ci_nit_persona=" + textBox1.Text.Trim(), "persona");
            dataGridView1.DataSource = metodos_usuario.ds.Tables["persona"];
            dataGridView1.Columns["password"].Visible = false;
            dataGridView1.Columns["id_usuario"].Visible = false;
            dataGridView1.Columns["ci_nit_persona1"].Visible = false;
            dataGridView1.Columns["id_cargo"].Visible = false;
            dataGridView1.Columns["id_cargo1"].Visible = false;
        }

        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            Form3 clientes = new Form3();
            clientes.Show();
            this.Hide();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Form4 productos = new Form4();
            productos.Show();
            this.Hide();
        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Form5 almacen = new Form5();
            almacen.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
