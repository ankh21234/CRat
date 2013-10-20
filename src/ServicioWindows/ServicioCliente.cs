using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using Cliente.Negocio;
using Common;
using Common.Lib;
using TimeoutException = System.TimeoutException;

namespace ServicioWindows
{
    public partial class ServicioCliente : ServiceBase
    {
        private Thread HiloServicio;
        
        private const string IpServidor = "127.0.0.1";
        private const int PuertoServidor = 40000;
        private const int TiempoEsperaReconexion = 1000; //en ms.

        private static TcpClient _client;
        private static readonly IPEndPoint point = new IPEndPoint(IPAddress.Parse(IpServidor), PuertoServidor);
        private static readonly NegocioCliente servicio = new NegocioCliente();

        /*Parametros del Cliente*/
        private static Boolean TienePassword = false;


        /**/
        private static String passwordDelCliente = "hola123";
        private static String passwordRecibida = "";
        public ServicioCliente()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)               
        {
            HiloServicio = new Thread(IniciarServicio);
            HiloServicio.Start();
        }

        public delegate void _iniciarServicio();
        public static void IniciarServicio()
        {
            Console.Out.WriteLine("Cliente--");
            InitCommonControls();
            if (TienePassword)
                servicio.MostrarMsgBox("La password asociada a este cliente es: \n\n" + passwordDelCliente, "Password!",
                                       32);
            Conectar();
            Process.GetCurrentProcess().WaitForExit();                
        }
        protected override void OnStop()
        {
            CerrarConexiones();
            HiloServicio.Abort();
        }


        private static void Conectar()
        {
            try
            {
                _client = TimeOutSocket.Conectar(point, TiempoEsperaReconexion);
                if (_client != null)
                {
                    Console.Out.WriteLine("Conectado!");
                    int protocol = (int)Protocolo.Cliente.Conectado;
                    NetData d = servicio.GenerarInformacionDelSistema(protocol);
                    Enviar(d);

                    _client.GetStream().BeginRead(new byte[] { 0 }, 0, 0, Leer, null);
                }
            }
            catch (Exception)
            {
                Console.Out.WriteLine("Intentando conectar con el servidor " + point);
                CerrarConexiones();
                Conectar();
            }
        }

        private static void Leer(IAsyncResult ar)
        {
            try
            {
                //Thread.Sleep(10); 
                byte[] datosLeidos = new byte[32000];
                int bytesLeidos = _client.GetStream().Read(datosLeidos, 0, datosLeidos.Length);
                byte[] datosObj = new byte[bytesLeidos];
                for (int i = 0; i < bytesLeidos; i++)
                {
                    datosObj[i] = datosLeidos[i];
                }

                Procesar((NetData)Serializador.Deserializar(datosObj));
                _client.GetStream().BeginRead(new byte[] { 0 }, 0, 0, Leer, null);
            }
            catch
            {
                Thread.Sleep(TiempoEsperaReconexion);
                CerrarConexiones();
                Conectar();
            }
        }

        private static void Procesar(NetData objRecibido)
        {
            Console.Out.WriteLine("Recibido msg con codigo de protocolo [" + objRecibido.CodigoDeProtocolo + "]");
            /*mientras  el acceso no este validado...*/
            if (comprobarAuth() == false)
            {
                Enviar(servicio.GenerarPeticionPassword());
                Boolean auth = false;
                /*Si el objeto recibido es una respuesta a la password la valido, si no paso.*/
                if (objRecibido.CodigoDeProtocolo == (int)Protocolo.Servidor.EnviarPassword)
                    auth = validarRespuestaPassword(objRecibido);
                else
                    return;
                /*Si no estoy validado no hago nada... sigo leyendo hasta estarlo.*/
                if (auth == false)
                    return;
            }
            //Si el server esta autorizado (Password -> OK) proceso los msg recibidos. 

            switch (objRecibido.CodigoDeProtocolo)
            {
                //Ventanas
                case (int)Protocolo.Servidor.PedirInfoVentanas:
                    NetData d = servicio.GenerarInfoVentanasVisibles((int)Protocolo.Cliente.RespuestaInfoVentanas);
                    Enviar(d);
                    break;
                //Acciones de Ventana.
                case (int)Protocolo.Servidor.MinimizarVentana:
                case (int)Protocolo.Servidor.BloquearVentana:
                case (int)Protocolo.Servidor.DesbloquearVentana:
                case (int)Protocolo.Servidor.CambiarTituloVentana:
                    try
                    {
                        servicio.ProcesarAccionesDeVentana(objRecibido);
                        Enviar(NetData.RespuestaOk());
                    }
                    catch (Exception ex)
                    {
                        Enviar(NetData.RespuestaError());
                    }
                    break;
                case (int)Protocolo.Servidor.MostrarMsgBox:
                    servicio.MostrarMsgBox(objRecibido.GetDato("Msg"),
                                           objRecibido.GetDato("Titulo"),
                                           int.Parse(objRecibido.GetDato("Tipo")));
                    break;
            }
        }

        private static void Enviar(NetData obj)
        {
            lock (_client)
            {
                byte[] datos = Serializador.Serializar(obj);
                _client.GetStream().Write(datos, 0, datos.Length);
                _client.GetStream().Flush();
                Console.Out.WriteLine("Envio datos al servidor [{0} : {1}]", point.Address,
                                      point.Port + " [ " + (float)datos.Length / 1000 + " Kb's ]");
            }
        }

        private static void CerrarConexiones()
        {
            try
            {
                _client.Close();
            }
            catch (Exception)
            {
            }
        }


        private static Boolean comprobarAuth()
        {
            /*Si no tiene password la autorizacion siempre es correcta.*/
            if (!TienePassword)
                return true;

            return passwordDelCliente == passwordRecibida;
        }

        private static Boolean validarRespuestaPassword(NetData datosRecibidos)
        {
            String psw = datosRecibidos.GetDato("Password");
            if (psw == passwordDelCliente)
            {
                passwordRecibida = psw;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///     Muestra en consola las referencias a las Dll(tanto propias como del Framework .NET) que necesita el cliente para funcionar
        ///     correctamente el cliente.
        /// </summary>
        private static void mostrarDependendias()
        {
            var assemblies = AppDomain.CurrentDomain
                                      .GetAssemblies()
                                      .Where(a => !a.IsDynamic)
                                      .Select(a => a.Location);

            foreach (var asam in assemblies.ToArray())
            {
                Console.Out.WriteLine("" + asam);
            }
        }


        [DllImport("Comctl32.dll")]
        private static extern void InitCommonControls();
    }


    internal class TimeOutSocket
    {
        private static bool ConexionExitosa;
        private static Exception SocketException;
        private static readonly ManualResetEvent TimeoutObject = new ManualResetEvent(false);

        public static TcpClient Conectar(IPEndPoint point, int timeout)
        {
            TimeoutObject.Reset();
            SocketException = null;

            string serverip = Convert.ToString(point.Address);
            int serverport = point.Port;
            TcpClient tcpclient = new TcpClient();

            tcpclient.BeginConnect(serverip, serverport,
                                   CallBackMethod, tcpclient);

            if (TimeoutObject.WaitOne(timeout, false))
            {
                if (ConexionExitosa)
                {
                    return tcpclient;
                }
                else
                {
                    throw SocketException;
                }
            }
            else
            {
                tcpclient.Close();
                throw new TimeoutException("TimeOut Exception");
            }
        }

        private static void CallBackMethod(IAsyncResult asyncresult)
        {
            try
            {
                ConexionExitosa = false;
                TcpClient tcpclient = asyncresult.AsyncState as TcpClient;

                if (tcpclient.Client != null)
                {
                    tcpclient.EndConnect(asyncresult);
                    ConexionExitosa = true;
                }
            }
            catch (Exception ex)
            {
                ConexionExitosa = false;
                SocketException = ex;
            }
            finally
            {
                TimeoutObject.Set();
            }
        }
    }
}
