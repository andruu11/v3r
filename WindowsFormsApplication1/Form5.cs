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
    public partial class Form5 : Form
    {
        int pw;
        bool hide;
        int pwx;
        public Form5()
        {
            InitializeComponent();
            pw = panel2.Width;
            pwx = panel2.Width - 190;
            hide = false;
            pictureBox2.Visible = false;
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

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            Form1 login = new Form1();
            login.Show();
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

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Form4 productos = new Form4();
            productos.Show();
            this.Hide();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            //boton cerrar
            Environment.Exit(0);
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

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            //boton minimizar
            WindowState = FormWindowState.Minimized;
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
