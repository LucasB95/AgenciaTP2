using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp2
{
    class Usuario
    {
        private int DNI;
        private string Nombre;
        private string Mail;
        private string Password;
        private bool esAdmin;
        private bool bloqueado;

        public Usuario(int DNI, string nom, string mail, string pass,bool adm,bool bloq)
        {
            this.DNI = DNI;
            Nombre = nom;
            Mail = mail;
            Password = pass;
            esAdmin = adm;
            bloqueado = bloq;
        }

        public void setDNI(int dni)
        {
            DNI = dni;
        }
        public int getDNI()
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
