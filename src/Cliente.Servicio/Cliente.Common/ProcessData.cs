using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Cliente.Common
{
    public class ProcessData
    {
        private string _id;
        private string _nombre;
        private string _ventanaAsociada;

        public ProcessData(string id, string nombre, string ventanaAsociada)
        {
            _id = id;
            _nombre = nombre;
            _ventanaAsociada = ventanaAsociada;
        }

        public string Id
        {
            get { return _id; }
        }

        public string Nombre
        {
            get { return _nombre; }
        }

        public string VentanaAsociada
        {
            get { return _ventanaAsociada; }
        }

        public static void MatarProceso(string idProceso)
        {
            try
            {
                Process proceso = Process.GetProcessById(int.Parse(idProceso));
                proceso.Kill();
            }
            catch (Exception ex){}
        }

        public static void IniciarProceso(string name,bool oculto)
        {
            try
            {
                Process procesoNuevo = new Process();
                procesoNuevo.StartInfo.FileName = name;
                procesoNuevo.StartInfo.UseShellExecute = !oculto;
                procesoNuevo.Start();
            }
            catch (Exception ex)
            {

            }

        }
    }
}
