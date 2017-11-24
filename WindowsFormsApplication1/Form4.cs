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
    public partial class Form4 : Form
    {
        int pw;
        bool hide;
        int pwx;
        public Form4()
        {
            InitializeComponent();
            pw = panel2.Width;
            pwx = panel2.Width - 190;
            hide = false;
            pictureBox2.Visible = false;
            MostrarComboEstante();
            MostrarComboUnidad();
            MostrarComboPresentacion();
            MostrarComboLaboratorio();
            MostarProductos();
            
            
        }

        metodos.metodos_farmacia metodos_producto = new metodos.metodos_farmacia();
        



        public void MostarProductos()
        {
            metodos_producto.consulta("SELECT * FROM producto", "producto");
            dataGridView1.DataSource = metodos_producto.ds.Tables["producto"];

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

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
            this.Hide();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Form5 ventas = new Form5();
            ventas.Show();
            this.Hide();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Form2 usuarios = new Form2();
            usuarios.Show();
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
            Form5 ventas = new Form5();
            ventas.Show();
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

        public void MostrarProductos()
        { 
            metodos_producto.consulta("SELECT * FROM producto INNER JOIN laboratorio ON producto.id_laboratorio = laboratorio.id_laboratorio INNER JOIN presentacion ON presentacion.id_presentacion = producto.id_presentacion INNER JOIN unidad ON producto.id_unidad = unidad.id_unidad INNER JOIN seccion ON producto.id_seccion = seccion.id_seccion INNER JOIN estante ON seccion.id_estante = estante.id_estante", "producto");
            dataGridView1.DataSource = metodos_producto.ds.Tables["producto"];
            dataGridView1.Columns["id_producto"].Visible = false;
        }
        public void MostrarComboLaboratorio()
        {
            metodos_producto.consulta("SELECT * FROM laboratorio", "laboratorio");
            comboBox1.DataSource = metodos_producto.ds.Tables["laboratorio"];
            comboBox1.DisplayMember = "des_laboratorio";
            comboBox1.ValueMember = "id_laboratorio";

        }
        public void MostrarComboPresentacion()
        {
            metodos_producto.consulta("SELECT * FROM presentacion","presentacion");
            comboBox3.DataSource = metodos_producto.ds.Tables["presentacion"];
            comboBox3.DisplayMember = "des_presentacion";
            comboBox3.ValueMember = "id_presentacion";
        }

        public void MostrarComboUnidad()
        {
            metodos_producto.consulta("SELECT * FROM unidad", "unidad");
            comboBox4.DataSource = metodos_producto.ds.Tables["unidad"];
            comboBox4.DisplayMember = "des_unidad";
            comboBox4.ValueMember = "id_unidad";

        }

        public void MostrarComboEstante()
        {
            metodos_producto.consulta("SELECT * FROM estante","estante");
            comboestante.DataSource = metodos_producto.ds.Tables["estante"];
            comboestante.DisplayMember = "des_estante";
            comboestante.ValueMember = "id_estante";
        
        }
        public void MostrarComboSecciones(int a)
        {

            metodos_producto.consulta("SELECT * FROM `seccion` WHERE seccion.id_estante=" + a, "seccion");
            comboseccion.DataSource = metodos_producto.ds.Tables["seccion"];
            comboseccion.DisplayMember = "des_seccion";
            comboseccion.ValueMember = "id_seccion";


        }



        private void txt_apmaterno_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton9_Click(object sender, EventArgs e)
        {
            string actualizar = "nombre_producto= '" + txt_producto.Text + "',des_producto='" + txt_descripcion.Text + "',id_laboratorio='" + Convert.ToInt32(comboBox1.SelectedValue) + "',id_seccion='" + Convert.ToInt32(comboseccion.SelectedValue) + "',id_presentacion='" + Convert.ToInt32(comboBox3.SelectedValue) + "',id_unidad='" + Convert.ToInt32(comboBox4.SelectedValue) + "',stock='" + Convert.ToInt32(textBox2.Text) + "', precio= '" + Convert.ToInt32(textBox1.Text) + "'";
            if (MessageBox.Show("Esta seguro de editar los datos del Producto", "Editar Producto",
   MessageBoxButtons.YesNo, MessageBoxIcon.Question)
   == DialogResult.Yes)
            {
                if (metodos_producto.ActualizarDatos("producto", actualizar, "id_producto=" + Convert.ToInt32(label1.Text.Trim())))
                {
                    MessageBox.Show("Los productos se actualizaron");

                    MostrarProductos();

                }
                else
                {
                    MessageBox.Show("Productos no actualizados");

                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton11_Click(object sender, EventArgs e)
        {
            //boton para buscar a traves del nombre del producto 
            metodos_producto.Buscar("SELECT * FROM producto WHERE producto.nombre_producto like '" + txt_producto.Text.Trim()+"%'", "producto");
            dataGridView1.DataSource = metodos_producto.ds.Tables["producto"];

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton12_Click(object sender, EventArgs e)
        {
            MostarProductos();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            string consulta_agregars = "INSERT INTO producto VALUES ('"+ "" + "' , '" + txt_producto.Text + "' , '" + txt_descripcion.Text + "' , '" + Convert.ToInt32(comboBox1.SelectedValue) + "' ,'" + Convert.ToInt32(comboseccion.SelectedValue) + "' , '"  + Convert.ToInt32(comboBox3.SelectedValue) + "' , '" + Convert.ToInt32(comboBox4.SelectedValue) + "' , '" + textBox1.Text + "' , '" + textBox2.Text + "')";
            if (metodos_producto.InsertarDatos(consulta_agregars))
            {

                MessageBox.Show("Productos guardados");

                MostarProductos();
            }
            else
            {
                MessageBox.Show("Productos no guardados");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow registro = dataGridView1.Rows[e.RowIndex];
            label1.Text = registro.Cells["id_producto"].Value.ToString();
            txt_producto.Text = registro.Cells["nombre_producto"].Value.ToString();
            txt_descripcion.Text = registro.Cells["des_producto"].Value.ToString();
            textBox1.Text = registro.Cells["precio"].Value.ToString();
            textBox2.Text = registro.Cells["stock"].Value.ToString();
            comboBox1.Text = registro.Cells["id_laboratorio"].Value.ToString();
            comboBox3.Text = registro.Cells["id_presentacion"].Value.ToString();
            comboBox4.Text = registro.Cells["id_unidad"].Value.ToString();
            
        }

        private void comboestante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboestante.SelectedValue.ToString() != null || comboestante.SelectedValue.ToString() != "")
            {

                int var = Convert.ToInt32(comboestante.SelectedIndex.ToString());
                MostrarComboSecciones(var);
            }
        }
            
        }
        }
    

