using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp2
{
    class Usuario
    {
        private string DNI;
        private string Nombre;
        private string Mail;
        private string Password;
        private bool esAdmin;
        private bool bloqueado;

        public Usuario(string DNI, string nom, string mail, string pass)
        {
            this.DNI = DNI;
            Nombre = nom;
            Mail = mail;
            Password = pass;            
        }

        public void setDNI(string dni)
        {
            DNI = dni;
        }
        public string getDNI()
        {
            return DNI;
        }
        public void setNombre(String nom)
        {
            Nombre = nom;
        }
        public String getNombre()
        {
            return Nombre;
        }
        public void setMail(String mail)
        {
            Mail = mail;
        }
        public String getMail()
        {
            return Mail;
        }
        public void setPassword(String pass)
        {
            Password = pass;
        }
        public String getPassword()
        {
            return Password;
        }
        public void setesAdmin(bool adm)
        {
            esAdmin = adm;
        }
        public bool getesAdmin()
        {
            return esAdmin;
        }
        public void setBloqueado(bool bloq)
        {
            bloqueado = bloq;
        }
        public bool getBloqueado()
        {
            return bloqueado;
        }


    }
}
