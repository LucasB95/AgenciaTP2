using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class AgregarUsuario : Form
    {
       
        static List<Usuario> usuarios = new List<Usuario> { };
      

        public AgregarUsuario()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("No se completaron los datos");
            }
            else if (textBox1.Text != null && textBox2 != null && textBox3.Text != null && textBox4.Text != null)
            {
            

                string DNI = textBox1.Text;
                string nom = textBox2.Text;
                string mail = textBox3.Text;
                string pass = textBox4.Text;

                Usuario usuarioAgregado = new Usuario(DNI, nom, mail, pass);


                if (!usuarios.Exists(x => x.getDNI().Contains(textBox1.Text)))
                {
                    
                    usuarios.Add(usuarioAgregado);
                    MessageBox.Show("Usuario creado con exito :" + nom);

                    this.Hide();
                    Form1 login = new Form1();
                    login.Show();

                }
                else
                {
                    MessageBox.Show("Ya existen datos con el DNI");
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
