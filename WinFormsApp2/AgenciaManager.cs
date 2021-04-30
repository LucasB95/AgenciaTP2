using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp2
{
    class AgenciaManager
    {
        private Agencia miAgencia;
        private List<Usuario> misUsuarios;
        private List<Reserva> misReservas;


        //List<List<string>> este seria el tipo buscarAlojamiento
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

        public bool agregarAlojamiento(Alojamiento aloj)
        {
           if (miAgencia.insertarAlojamiento(aloj))
            {
                return true;
            }
            return false;
        }


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

        public List<Usuario> buscarReserva(int DNIusuario)
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

        public bool reservar(int codAloj, int dniUsuario, Datetime Fdesde, Datetime Fhasta)
        {

        }

        public bool modificarReserva() // Datos de Reserva
        {

        }

        public bool eliminarReserva(int codigo)
        {

        }

        public bool auntenticarUsuario(int DNI, string password)
        {

        }



     }
}
