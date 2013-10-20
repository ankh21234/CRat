#region

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Common.Lib;

#endregion

namespace Servidor.Negocio
{
    /// <summary>
    ///     Clase abstracta que representa al servidor central que espera conexiones de los clientes.
    /// </summary>
    public abstract class ServidorBase
    {
        public static List<Conexion> Clientes = new List<Conexion>();
        protected TcpListener _listener;
        protected Thread _listenerThread;
        protected int _online = 0;
        protected int port = 0;

        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        public int Online
        {
            get { return _online; }
            set { _online = value; }
        }

        public void IniciarEscuchaDefaultPort()
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _listenerThread = new Thread(EscucharConexiones);
            _listenerThread.Start();
        }

        private void EscucharConexiones()
        {
            try
            {
                _listener.Start();
                while (true)
                {
                    Conexion clientConexion = new Conexion(_listener.AcceptTcpClient());
                    clientConexion.DisconnectedEvent += EventoClienteDesconectado;
                    clientConexion.ReceivedEvent += EventoDatosRecibidos;
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void PararEscucha()
        {
            try
            {
                _listener.Stop();
                _listenerThread.Abort();
            }
            catch
            {
            }
        }

        protected abstract void EventoDatosRecibidos(Conexion client, NetData objetoRecibido);

        protected abstract void EventoClienteDesconectado(Conexion client);
    }
}