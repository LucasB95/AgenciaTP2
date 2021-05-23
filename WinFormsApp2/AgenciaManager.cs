using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace WinFormsApp2
{
    class AgenciaManager
    {
        public Agencia miAgencia;
        public List<Usuario> misUsuarios = new List<Usuario> { };
        public List<Reserva> misReservas = new List<Reserva> { };
        public int contInsertar = 0;

        //string path = @"C:\Users\lu_kp\OneDrive\Escritorio\AgenciaTP2\Usuarios.txt";
        //string usuarios = "Usuarios.txt";
        //string destino = System.IO.Path.Combine(path, usuarios);

        static string Usuarios = "Usuarios.txt";

        static string sourcePath = @"C:\Users\lu_kp\OneDrive\Escritorio\AgenciaTP2";

        static string targetPath = @"C:\Users\lu_kp\OneDrive\Escritorio\AgenciaTP2\Archivos";

        string sourceFile = System.IO.Path.Combine(sourcePath, Usuarios);

        string destFile = System.IO.Path.Combine(targetPath, Usuarios);

        //static string Alojamientos = "Alojamientos.txt";

        //string sourceFileAloj = System.IO.Path.Combine(sourcePath, Alojamientos);

        //string destFileAloj = System.IO.Path.Combine(targetPath, Alojamientos);

        static string Reservas = "Reservas.txt";

        string sourceFileReser = System.IO.Path.Combine(sourcePath, Reservas);

        string destFileReser = System.IO.Path.Combine(targetPath, Reservas);



        public List<Alojamiento> buscarAlojamiento(String Ciudad, DateTime Pdesde, DateTime Phasta, int cantPersonas, String Tipo ) 
        {
            List<Alojamiento> aloj = new List<Alojamiento> { };
            foreach (Alojamiento a in miAgencia.getAlojamientos())
            {
                if (a.getCiudad().Equals(Ciudad))
                {
                   if(a.getCantPersonas() == cantPersonas)
                    {
                        aloj.Add(a);
                        
                    }
                }
            }

            return aloj;
        }

        public bool insertarUsuario(Usuario usu)
        {
            foreach (Usuario a in misUsuarios)
                if (a.igualCodigoUsuario(usu))
                    return false;

            misUsuarios.Add(usu);
            archivoUsuarios();
            contInsertar++;
            return true;
        }


        public void archivoUsuarios()
        {
            foreach (var prueba in misUsuarios)
            {
                File.AppendAllText(Usuarios, prueba.ToString() + Environment.NewLine);
                
            }
           
        }

        public List<Usuario> getUsuarios()
        {
            return misUsuarios;
        }

        public bool modificaUsuario(string dni, string passv, string passn, string passnc)
        {

            StreamReader lectura = File.OpenText(Usuarios);
            string cadena = lectura.ReadLine();
            bool encontrado = false;
            char delimitador = ',';
            StreamWriter escribir = File.CreateText("temp.txt");

            string[] usuario;

            while (cadena != null)
            {
                usuario = cadena.Split(delimitador);
                if (usuario[0] == dni && usuario[3] == passv)
                {
                    if (passn == passnc)
                    {
                        usuario[3] = passn;
                        encontrado = true;

                    }

                }
                else
                {
                    escribir.WriteLine(cadena + Environment.NewLine);
                }
                    cadena = lectura.ReadLine();
                }
      
                escribir.Close();
                lectura.Close();

                File.Delete(Usuarios);
                File.Move("temp.txt", Usuarios);

                return encontrado;
                        
        }

        public bool autenticarUsuario(string DNI, string password)
        {
           
           StreamReader lectura = File.OpenText(Usuarios);
           string cadena = lectura.ReadLine();
           

            bool encontrado = false;
            char delimitador = ',';

            string[] usuario;

            
            if (cadena != null)
            {
                usuario = cadena.Split(delimitador);

                if (usuario[0] == DNI && usuario[3] == password)
                {
                    encontrado = true;
                }

            }

            lectura.Close();

            return encontrado;


        }
        public bool autenticarUsuarioAdmin(string DNI, string password)
        {

            StreamReader lectura = File.OpenText(Usuarios);
            string cadena = lectura.ReadLine();
            bool encontrado = false;
            char delimitador = ',';

            string[] usuario;



            if (cadena != null)
            {
                usuario = cadena.Split(delimitador);

                if (usuario[0] == DNI && usuario[3] == password)
                {
                    if(usuario[5] == "True")
                    {
                        encontrado = true;
                    }
                }

            }

            lectura.Close();

            return encontrado;

        }

        public bool desbloquearUsuario(Usuario usu)
        {
            foreach(Usuario a in misUsuarios)
            {
                if(a != null && a.getBloqueado() != true)
                {                    
                    usu.setBloqueado(true);
                    return true;
                }
            }
            return false;
        }

        public bool bloquearUsuario(string dni)
        {
            foreach (Usuario a in misUsuarios)
            {
                if (a != null && a.getDNI() == dni)
                {
                    misUsuarios.Remove(a);
                    a.setBloqueado(false);
                    misUsuarios.Add(a);
                    return true;
                }
            }
            return false;
        }

        public bool eliminarUsuario(string dni) 
        {

            StreamReader lectura = File.OpenText(Usuarios);
            string cadena = lectura.ReadLine();
            bool encontrado = false;
            char delimitador = ',';
            StreamWriter escribir = File.CreateText("temp.txt");
            
            string[] usuario;

            while(cadena != null)
            {
                usuario = cadena.Split(delimitador);
                if (usuario[0] == dni)
                {
                    encontrado = true;
                }
                else
                {
                    escribir.WriteLine(cadena);
                }
                cadena = lectura.ReadLine();
            }


            escribir.Close();


            lectura.Close();

            File.Delete(Usuarios);
            File.Move("temp.txt", Usuarios);

            return encontrado;


        }

        public bool agregarAlojamiento(Alojamiento aloj)
        {
           if (miAgencia.insertarAlojamiento(aloj))
            {
                return true;
            }
            return false;
        }

        //public void archivoAlojamiento()
        //{
        //    foreach (var prueba in miAgencia.misAlojamientos)
        //    {
        //        File.AppendAllText(Alojamientos, prueba.ToString() + Environment.NewLine);

        //    }

        //}


        public bool modificarAlojamiento(Alojamiento aloj)
        {

            if(miAgencia.modificarAlojamiento(aloj))
            {
                return true;
            }
            return false;
        }
         
        public bool quitarAlojamiento(Alojamiento aloj)
        {
            if (miAgencia.eliminarAlojamiento(aloj))
            {
                return true;
            }
            return false;
        }

        public List<Usuario> buscarReserva(string DNIusuario)
        {
            List<Usuario> usuarios = new List<Usuario> { };
            foreach(Usuario a in misUsuarios)
            {
               if(a.getDNI() == DNIusuario)
                {
                    usuarios.Add(a);
                } 
            }
            return usuarios;
        }

        public bool reservar(int codAloj, int dniUsuario, DateTime Fdesde, DateTime Fhasta)
        {

            Reserva prueba = new Reserva();
            prueba.setFDesde(Fdesde);
            prueba.setFHasta(Fhasta);
           

            misReservas.Add(prueba);

            bool reserva = true;
            foreach(Reserva reser in misReservas)
            {
                if((reser.getFDesde() == Fdesde) && (reser.getFHasta() == Fhasta))
                {
                    reserva = false;
                }
                else
                {
                    reserva = true;
                }
                
            }
                    if (reserva == true)
                    {
                        misReservas.Add(prueba);
                    }

                    return reserva;

        }
        
        public bool modificarReserva(Reserva reservaNueva, int idAModificar) // Datos de Reserva
        {
            bool reserv = false;
            foreach (Reserva reser in misReservas)
            {
                if (idAModificar == reser.getID())
                {
                    misReservas.Remove(reser);
                    misReservas.Add(reservaNueva);
                    reserv = true;
                }
            }
            return reserv;
        }

        public bool eliminarReserva(int codigo)
        {
            foreach (Reserva reser in misReservas)
            {
                if (reser.getID() == codigo)
                {
                    misReservas.Remove(reser);
                    return true;
                }


            }
            return false;

        }

        



    }
}
