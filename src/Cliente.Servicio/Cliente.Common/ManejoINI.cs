#region

using System.Runtime.InteropServices;
using System.Text;

#endregion

namespace Ini
{
    /// <summary>
    ///     Crea, Lee y Escribe ficheros Ini de Configuracion.
    /// </summary>
    public class FicheroIni
    {
        public string path;

        /// <summary>
        ///     INIFile Constructor.
        /// </summary>
        /// <PARAM name="INIPath"></PARAM>
        public FicheroIni(string rutaFichero)
        {
            path = rutaFichero;
        }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
                                                             string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                                                          string key, string def, StringBuilder retVal,
                                                          int size, string filePath);

        /// <summary>
        ///     Escribe datos en el fichero.
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// Section name
        /// <PARAM name="Key"></PARAM>
        /// Key Name
        /// <PARAM name="Value"></PARAM>
        /// Value Name
        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, path);
        }

        /// <summary>
        ///     Lee datos del fichero.
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// <PARAM name="Key"></PARAM>
        /// <PARAM name="Path"></PARAM>
        /// <returns></returns>
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp,
                                            255, path);
            return temp.ToString();
        }
    }
}