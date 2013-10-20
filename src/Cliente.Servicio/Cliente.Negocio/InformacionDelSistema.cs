#region

using System;
using System.Globalization;
using System.Management;

#endregion

namespace Cliente.Negocio

{
    /// <summary>
    ///     Proporciona informacion basica sobre el sistema en el cual se crea el objeto.
    /// </summary>
    public class InformacionDelSistema
    {
        private readonly String _idiomaSO;
        private readonly String _nombrePC;
        private readonly String _nombreSo;
        private readonly String _usuarioLogeado;
        private readonly String _versionSo;

        public InformacionDelSistema()
        {
            _idiomaSO = CultureInfo.CurrentCulture.DisplayName;
            string os_query = "SELECT * FROM Win32_OperatingSystem";
            ManagementObjectSearcher os_searcher = new ManagementObjectSearcher(os_query);
            foreach (ManagementObject info in os_searcher.Get())
            {
                _nombreSo = info["Caption"].ToString();
                _versionSo = info["Version"].ToString();
            }
            _usuarioLogeado = Environment.UserName;
            _nombrePC = Environment.MachineName;
        }

        public string NombrePc
        {
            get { return _nombrePC; }
        }

        public string NombreSo
        {
            get { return _nombreSo; }
        }

        public string VersionSo
        {
            get { return _versionSo; }
        }

        public string UsuarioLogeado
        {
            get { return _usuarioLogeado; }
        }

        public string IdiomaSo
        {
            get { return _idiomaSO; }
        }
    }
}