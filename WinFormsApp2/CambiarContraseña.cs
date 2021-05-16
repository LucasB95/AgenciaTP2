using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class CambiarContraseña : Form
    {

        List<Usuario> usu = new List<Usuario> { };
        public CambiarContraseña()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("No se completaron los datos");
            }
            else if (textBox1.Text != null && textBox2 != null && textBox3.Text != null)
            {


                string passNuevo = textBox1.Text;
                string passViejo = textBox2.Text;
                string passViejoComprobacion = textBox3.Text;

                List<Usuario> usu = new List<Usuario> { };

                //AgregarUsuario agregarUsuario = new AgregarUsuario();

                //agregarUsuario.usuarios = CambiarContraseña.usu;
                 
               


                //if (!usuarios.Exists(x => x.getDNI().Contains(textBox1.Text)))
                //{

                //    usuarios.Add(usuarioAgregado);
                //    MessageBox.Show("Usuario creado con exito :" + nom);

                //    //this.Hide();
                //    //Form1 login = new Form1();
                //    //login.Show();

                //}
                //else
                //{
                //    MessageBox.Show("Ya existen datos con el DNI");
                //}


            }





        }
    }
}
