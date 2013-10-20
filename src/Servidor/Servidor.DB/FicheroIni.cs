#region

using System;
using System.Runtime.InteropServices;
using System.Text;

#endregion

namespace Servidor.DB
{
    public class FicheroIni
    {
        public string ruta;

        public FicheroIni(string iniRuta)
        {
            ruta = iniRuta;
        }

        
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string seccion,
                                                             string clave, string val, string ruta);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string seccion,
                                                          string clave, string def, StringBuilder retVal,
                                                          int size, string ruta);


        /// <summary>
        ///     Escribe un valor en el fichero .ini
        /// </summary>
        /// <PARAM name="seccion"></PARAM>
        /// seccion name
        /// <PARAM name="clave"></PARAM>
        /// clave Name
        /// <PARAM name="valor"></PARAM>
        /// valor Name
        public void EscribirDato(string seccion, string clave, string valor)
        {
            WritePrivateProfileString(seccion, clave, valor, ruta);
        }

        /// <summary>
        ///     Lee un valor del Fichero .ini
        /// </summary>
        /// <PARAM name="seccion"></PARAM>
        /// <PARAM name="clave"></PARAM>
        /// <PARAM name="Path"></PARAM>
        /// <returns></returns>
        public string LeerDato(string seccion, string clave)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(seccion, clave, "", temp,
                                            255, ruta);
            return temp.ToString();
        }
    }

    /// <summary>
    ///     Propiedades de Configuración
    ///     Cualquier cambio en las propiedades se registra automaticamente en el fichero ini
    ///     definido en 'archivoConfiguracion'
    /// </summary>
    public class CRatIniPropiedades
    {
        private static readonly FicheroIni archivoConfiguracion = new FicheroIni("config/configuracion.ini");
        //usuario.
        public static String Nombre
        {
            get { return archivoConfiguracion.LeerDato("Usuario", "Nombre"); }
            set { archivoConfiguracion.EscribirDato("Usuario", "Nombre", value); }
        }

        public static String Apellidos
        {
            get { return archivoConfiguracion.LeerDato("Usuario", "Apellidos"); }
            set { archivoConfiguracion.EscribirDato("Usuario", "Apellidos", value); }
        }

        public static String Email
        {
            get { return archivoConfiguracion.LeerDato("Usuario", "Email"); }
            set { archivoConfiguracion.EscribirDato("Usuario", "Email", value); }
        }

        public static String Serial
        {
            get { return archivoConfiguracion.LeerDato("Usuario", "Serial"); }
            set { archivoConfiguracion.EscribirDato("Usuario", "Serial", value); }
        }

        //BaseDeDatos.        
        public static String HostDB
        {
            get { return archivoConfiguracion.LeerDato("ConfigDB", "Host"); }
            set { archivoConfiguracion.EscribirDato("ConfigDB", "Host", value); }
        }

        public static String DataBase
        {
            get { return archivoConfiguracion.LeerDato("ConfigDB", "DataBase"); }
            set { archivoConfiguracion.EscribirDato("ConfigDB", "DataBase", value); }
        }

        public static String PuertoDB
        {
            get { return archivoConfiguracion.LeerDato("ConfigDB", "Puerto"); }
            set { archivoConfiguracion.EscribirDato("ConfigDB", "Puerto", value); }
        }

        public static String UsuarioDB
        {
            get { return archivoConfiguracion.LeerDato("ConfigDB", "Usuario"); }
            set { archivoConfiguracion.EscribirDato("ConfigDB", "Usuario", value); }
        }

        public static String PasswordDB
        {
            get { return archivoConfiguracion.LeerDato("ConfigDB", "Password"); }
            set { archivoConfiguracion.EscribirDato("ConfigDB", "Password", value); }
        }

        //Apariencia
        public static String Tema
        {
            get { return archivoConfiguracion.LeerDato("Apariencia", "Tema_Por_Defecto"); }
            set { archivoConfiguracion.EscribirDato("Apariencia", "Tema_Por_Defecto", value); }
        }
        
        public static String Idioma
        {
            get
            {
                string idioma =  archivoConfiguracion.LeerDato("Apariencia", "Idioma");
                if (idioma != "en" && idioma != "es")
                    return "es";               
                return idioma;
            }
            set { archivoConfiguracion.EscribirDato("Apariencia", "Idioma", value); }
        }
    }
}