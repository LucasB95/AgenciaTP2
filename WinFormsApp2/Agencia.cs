using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace WinFormsApp2
{
    class Agencia
    {
        public List<Alojamiento> misAlojamientos;
        public int cantAlojamientos;
        public List<Usuario> misUsuarios;
        public AgenciaManager ag;

        static string sourcePath = @"C:\Users\lu_kp\OneDrive\Escritorio\AgenciaTP2";

        static string targetPath = @"C:\Users\lu_kp\OneDrive\Escritorio\AgenciaTP2\Archivos";

        static string Alojamientos = "Alojamientos.txt";

        string sourceFileAloj = System.IO.Path.Combine(sourcePath, Alojamientos);

        string destFileAloj = System.IO.Path.Combine(targetPath, Alojamientos);


        public Agencia(int CantidadAlojamientos)
        {
            misAlojamientos = new List<Alojamiento>();
            cantAlojamientos = CantidadAlojamientos;
        }

        public bool insertarAlojamiento(Alojamiento aloj)
        {
            foreach (Alojamiento a in misAlojamientos)
            
                if (a != null && a.igualCodigo(aloj))
                
                return false;

            misAlojamientos.Add(aloj);
            archivoAlojamiento();
                                                 
            return true;
        }

        public void archivoAlojamiento()
        {
            foreach (var prueba in misAlojamientos)
            {
                File.AppendAllText(Alojamientos, prueba.ToString() + Environment.NewLine);

            }

        }

        public bool estaAlojamiento(Alojamiento aloj)
        {
            foreach (Alojamiento a in misAlojamientos)
                if ( a.igualCodigo(aloj))
                    return true;
           
            return false;
        }


        public bool eliminarAlojamiento(Alojamiento aloj)
        {

            StreamReader lectura = File.OpenText(Alojamientos);
            string cadena = lectura.ReadLine();
            bool encontrado = false;
            char delimitador = ',';
            StreamWriter escribir = File.CreateText("tempAloj.txt");
            string[] alojamientos;

            while (cadena != null)
            {
                alojamientos = cadena.Split(delimitador);
                if (alojamientos[0] == Convert.ToString(aloj.getCodigo()))
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

            File.Delete(Alojamientos);
            File.Move("tempAloj.txt", Alojamientos);

            return encontrado;

        }

        public bool modificarAlojamiento (Alojamiento aloj)
        {

            StreamReader lectura = File.OpenText(Alojamientos);
            string cadena = lectura.ReadLine();
            bool encontrado = false;
            char delimitador = ',';
            StreamWriter escribir = File.CreateText("tempAloj.txt");

            string[] alojamientos;

            while (cadena != null)
            {
                alojamientos = cadena.Split(delimitador);
                if (alojamientos[0] == Convert.ToString(aloj.getCodigo()))
                {
                    
                        encontrado = true;
                               
                }
                else
                {
                    escribir.WriteLine(cadena + Environment.NewLine);
                }
                cadena = lectura.ReadLine();
            }

            escribir.Close();
            lectura.Close();

            File.Delete(Alojamientos);
            File.Move("tempAloj.txt", Alojamientos);

            return encontrado;
        }

        public List<Alojamiento> getAloj()
        {
            return misAlojamientos;
        }
        public List<Usuario> getUsuario()
        {
            return misUsuarios;
        }

        public bool estaLlena() { return cantAlojamientos == misAlojamientos.Count; }
        public bool hayAlojamientos() { return misAlojamientos.Count > 0; }

        public Agencia soloHoteles()
        {
            Agencia Salida = new Agencia(this.cantAlojamientos);
            foreach (Alojamiento a in misAlojamientos)
                if (a is Hotel)
                    Salida.insertarAlojamiento(a);
            return Salida;
        }

        public Agencia masEstrellas(int cant)
        {
            Agencia Salida = new Agencia(this.cantAlojamientos);
            foreach (Alojamiento a in misAlojamientos)
                if (a.getEstrellas() >= cant)
                    Salida.insertarAlojamiento(a);
            return Salida;
        }

        public Agencia cabañasEntrePrecios(float d, float h)
        {
            Agencia Salida = new Agencia(this.cantAlojamientos);
            foreach (Alojamiento a in misAlojamientos)
                if (a is Cabaña)
                {
                    Cabaña c = (Cabaña)a;
                    if (c.getPrecioPorPersona() <= h && c.getPrecioPorPersona() >= d)
                        Salida.insertarAlojamiento(c);
                }

            return Salida;
        }


        // esto antes no funcionaba esperando respuesta del profe
        public Agencia alojamientosEntrePrecios(float d, float h)
        {
            Agencia Salida = new Agencia(this.cantAlojamientos);

            foreach (Alojamiento a in misAlojamientos)
                if (a is Cabaña)
                {
                    Cabaña c = (Cabaña)a;
                    if (c.getPrecioPorPersona() <= h && c.getPrecioPorPersona() >= d)
                        Salida.insertarAlojamiento(c);
                    Console.WriteLine(c.ToString());
                }
                else if (a is Hotel)
                {
                    Hotel t = (Hotel)a;
                    if (t.getPrecioPorPersona() <= h && t.getPrecioPorPersona() >= d)
                        Salida.insertarAlojamiento(t);
                    Console.WriteLine(t.ToString());
                }

            return Salida;
        }


        public int getCantidad() { return cantAlojamientos; }
        public void setCantidad(int CantAlojamientos) { cantAlojamientos = CantAlojamientos; }

        public List<Alojamiento> getAlojamientos()
        {
            return misAlojamientos.OrderBy(a => a.getEstrellas()).ThenBy(a => a.getCantPersonas()).ThenBy(a => a.getCodigo()).ToList();
        }
    }
}
