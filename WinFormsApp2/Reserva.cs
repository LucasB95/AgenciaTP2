using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp2
{
    class Reserva {
        private int id;
        private DateTime fdesde;
        private DateTime fhasta;
        private Alojamiento propiedad;
        private Usuario persona;
        private float precio;

        public override string ToString()
        {
            return id + " - " + fdesde + " - " + fhasta + " - " + propiedad + " - " + persona + " - " + precio;
        }

        public void setID(int ID) { id = ID; }
        public void setFDesde(DateTime FDesde) { fdesde = FDesde; }
        public void setFHasta(DateTime FHasta) { fhasta = FHasta; }
        public void setPropiedad(Alojamiento Propiedad) { propiedad = Propiedad; }
        public void setPersona(Usuario persona) { this.persona = persona; }
        public void setPrecio(float Precio) { precio = Precio; }

        public int getID() { return id; }
        public DateTime getFDesde() { return fdesde; }
        public DateTime getFHasta() { return fhasta; }
        public Alojamiento getPropiedad() { return propiedad; }
        public Usuario getPersona() { return persona; }
        public float getPrecio() { return precio; }
    }
}
