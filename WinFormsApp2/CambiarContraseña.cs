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

        //List<Usuario> usu = new List<Usuario> { };
        AgenciaManager ag = new AgenciaManager();
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
                Form1 f1 = new Form1();
                
                string usuario = label4.Text;
                string passViejo = textBox1.Text;
                string passNuevoComprobacion = textBox2.Text;
                string passNuevo = textBox3.Text;

                //List<Usuario> usu = new List<Usuario> { };

                //MessageBox.Show(usuario);

                //ag.modificaUsuario(usuario,passNuevo,passNuevoComprobacion,passViejo);

              if(ag.modificaUsuario(usuario, passViejo, passNuevoComprobacion, passNuevo) == true)
                {
                    MessageBox.Show("Modificacion Correcta");
                }
                else
                {
                    MessageBox.Show("Error");

                }                  
                
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
