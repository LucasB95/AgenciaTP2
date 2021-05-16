using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormsApp2
{
    class AgenciaManager
    {
        private Agencia miAgencia;
        private List<Usuario> misUsuarios = new List<Usuario> { };
        private List<Reserva> misReservas = new List<Reserva> { };


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

        public bool autenticarUsuario( string DNI, string password)
        {


            for( int i = 0; i< misUsuarios.Count(); i++)
            {
                if (misUsuarios[i].getDNI() == DNI && misUsuarios[i].getPassword() == password) ;
                {
                    return true;
                }
            }
            //foreach (Usuario usu in misUsuarios)
            //{
            //    if (usu.getDNI() == DNI && usu.getPassword() == password)
            //    {
            //        return true;
            //    }
            //}
            return false;
        }



    }
}
