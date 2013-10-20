using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Cliente.Common
{
    public class SoftwareData
    {
        private string _nombre;
        private string _autor;
        private string _url;
        private string _version;
        private string _fechaInstalacion;
        private string _stringDesinstalacion;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Autor
        {
            get { return _autor; }
            set { _autor = value; }
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        public string FechaInstalacion
        {
            get { return _fechaInstalacion; }
            set { _fechaInstalacion = value; }
        }

      /*  public string StringDesinstalacion
        {
            get { return _stringDesinstalacion; }
            set { _stringDesinstalacion = value; }
        }*/

      /*  public static bool DesinstalarSoft(string stringDeDesistanalacion)
        {
            try
            {
                Process unistaller = new Process();
                unistaller.StartInfo.FileName = stringDeDesistanalacion;
                unistaller.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }*/
    }

}
