using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WinFormsApp2
{
    class Agencia
    {
        private List<Alojamiento> misAlojamientos;
        private int cantAlojamientos;
        private List<Usuario> misUsuarios;

        public Agencia(int CantidadAlojamientos)
        {
            misAlojamientos = new List<Alojamiento>();
            cantAlojamientos = CantidadAlojamientos;
        }

        public bool insertarAlojamiento(Alojamiento aloj)
        {
            foreach (Alojamiento a in misAlojamientos)
                if (a.igualCodigo(aloj))
                    return false;
            
            misAlojamientos.Add(aloj);
            return true;
        }
        public bool estaAlojamiento(Alojamiento aloj)
        {
            foreach (Alojamiento a in misAlojamientos)
                if (a.igualCodigo(aloj))
                    return true;
           
            return false;
        }


        public bool eliminarAlojamiento(Alojamiento aloj) { 
            foreach(Alojamiento a in misAlojamientos)
            {
                if (a.igualCodigo(aloj))
                {
                    misAlojamientos.Remove(aloj);
                    return true;
                }
            }
            return false;
        }

        public bool modificarAlojamiento (Alojamiento aloj)
        {
            foreach(Alojamiento a in misAlojamientos)
            {
                if (a.igualCodigo(aloj))
                {
                    misAlojamientos.Remove(aloj);
                    misAlojamientos.Add(aloj);

                }
                   return true;
            }
            return false;
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
        //public Agencia alojamientosEntrePrecios(float d, float h)
        //{
        //    Agencia Salida = new Agencia(this.cantAlojamientos);
                   
        //    foreach (Alojamiento a in misAlojamientos)
        //        if (a is Cabaña)
        //        {
        //            Cabaña c = (Cabaña)a;
        //            if (c.getPrecioPorPersona() <= h && c.getPrecioPorPersona() >= d)
        //                Salida.insertarAlojamiento(c);
        //        }
        //        else if (a is Hotel)
        //        {
        //            Hotel t = (Hotel) a;
        //            if (t.getPrecioPorPersona() <= h && t.getPrecioPorPersona() >= d)
        //                Salida.insertarAlojamiento(t);
        //        }

        //    return Salida;
        //}


        public int getCantidad() { return cantAlojamientos; }
        public void setCantidad(int CantAlojamientos) { cantAlojamientos = CantAlojamientos; }

        public List<Alojamiento> getAlojamientos()
        {
            return misAlojamientos.OrderBy(a => a.getEstrellas()).ThenBy(a => a.getCantPersonas()).ThenBy(a => a.getCodigo()).ToList();
        }
    }
}
