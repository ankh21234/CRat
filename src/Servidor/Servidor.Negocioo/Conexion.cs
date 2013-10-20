#region

using System;
using System.Net.Sockets;
using Common;
using Common.Lib;
using Servidor.DB;

#endregion

namespace Servidor.Negocio
{
    public class Conexion
    {
        public delegate void Disconnected(Conexion client);

        public delegate void Received(Conexion client, NetData objetoRecivido);

        private readonly TcpClient _client; //Establece la conexion con el cliente.
        private readonly string _ip; // Ip del cliente.

        public Conexion(TcpClient client)
        {
            _client = client;
            _ip = client.Client.RemoteEndPoint.ToString()
                        .Remove(client.Client.RemoteEndPoint.ToString().LastIndexOf(':'));
            byte[] datosLeidos = new byte[_client.ReceiveBufferSize];
            _client.GetStream().BeginRead(datosLeidos, 0, datosLeidos.Length, Leer, datosLeidos); //Lectura de datos.
        }

        public string IpAddress
        {
            get { return _ip; }
        }

        public NetworkStream ClientNetworkStream
        {
            get { return _client.GetStream(); }
        }

        public event Disconnected DisconnectedEvent;
        public event Received ReceivedEvent;

        private void Leer(IAsyncResult ar)
        {
            try
            {
                int lectura = _client.GetStream().EndRead(ar);
                if (lectura <= 0)
                {
                    DisconnectedEvent(this);
                }
                byte[] datosLeidos = ar.AsyncState as byte[];
                ReceivedEvent(this, (NetData) Serializador.Deserializar(datosLeidos));
                _client.GetStream().BeginRead(datosLeidos, 0, datosLeidos.Length, Leer, datosLeidos);
            }
            catch (Exception ex)
            {
                DisconnectedEvent(this);
            }
        }


        public void Enviar(NetData obj)
        {
            ManejoDB.InsertarFromNetData(IpAddress, obj); //db insercion asincrona.
            byte[] objSerializado = Serializador.Serializar(obj);
            ClientNetworkStream.Write(objSerializado, 0, objSerializado.Length);
            ClientNetworkStream.Flush();
        }
    }
}