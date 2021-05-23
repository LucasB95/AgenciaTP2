using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            Usuario usuario1 = new Usuario("39104528", "Lucas", "basualdo1995@gmail.com", "123456");
            //usuario1.setesAdmin(false);

            Usuario usuario2 = new Usuario("98765432", "Oscar", "@", "123456");
            //usuario2.setesAdmin(true);

            AgenciaManager ag = new AgenciaManager();
            //ag.insertarUsuario(usuario1);
            //ag.insertarUsuario(usuario2);

            //ag.eliminarUsuario("321324325456");

            /* Alojamientos              */

            //Datos creados para prueba de verificacion rapida
            Cabaña elmanquito = new Cabaña(001, "El Manquito", "General San Martin", "Villa Lynch", 3, 5, true, 1526, 2, 1);
            Hotel zurdito = new Hotel(002, "Zurdito", "General San Martin", "Billinghurst", 4, 6, true, 1424);
            Hotel viper = new Hotel(003, "Viper", "Capital Federal", "Nuñez", 5, 3, true, 2000);


            Agencia grupo3 = new Agencia(5);

            //grupo3.insertarAlojamiento(elmanquito);
            //grupo3.insertarAlojamiento(zurdito);
            //grupo3.insertarAlojamiento(viper);

        }
    }
}
