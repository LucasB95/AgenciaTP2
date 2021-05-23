using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {

        
        AgenciaManager inicializar = new AgenciaManager();
        int cont = 0;
        List<Usuario> usuarioForm1 = new List<Usuario> { };
        public string usuario;

        public Form1()
        {
            InitializeComponent(); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


            if ( string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
                {
                MessageBox.Show("No se completaron los datos");
            } 
            else if (textBox1.Text != null && textBox2 != null)
                 {

                string codigo = textBox1.Text;
                string password = textBox2.Text;

                if (cont < 3)
                {
                    if(inicializar.autenticarUsuario(codigo, password) == true)
                    {
                        if (inicializar.autenticarUsuarioAdmin(codigo, password) == true)
                        {
                            this.Hide();
                            ProgramaIniciadoAdmin programaIniciadoAdmin = new ProgramaIniciadoAdmin();
                            programaIniciadoAdmin.Show();
                        }
                        else if (inicializar.autenticarUsuarioAdmin(codigo, password) == false)
                        {

                            this.Hide();
                            ProgramaIniciado programaIniciado = new ProgramaIniciado();
                            programaIniciado.Show();
                        }

                        
                      
                    }
                    else
                    {
                        cont++;
                        MessageBox.Show("Usuario y/o clave incorrectos." + cont);
                        
                    }
                   

                }else if (cont == 3)
                {
                MessageBox.Show("Error en validacion, contacte con administrador");
                inicializar.bloquearUsuario(codigo);
                Application.Exit();
                }

            }

           }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AgregarUsuario agregarUsuario = new AgregarUsuario();
            agregarUsuario.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usuario = textBox1.Text;
            //MessageBox.Show(usuario);
            this.Hide();
            CambiarContraseña cambiarContraseña = new CambiarContraseña();
            cambiarContraseña.Show();

            cambiarContraseña.label4.Text =  textBox1.Text ;
           
        }
    }
}
