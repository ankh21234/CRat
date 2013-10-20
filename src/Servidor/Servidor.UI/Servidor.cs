#region

using System.Windows.Forms;
using Common.Lib;
using Servidor.DB;
using Servidor.Negocio;

#endregion

namespace Servidor.UI
{
    public class Servidor : ServidorBase
    {
        private readonly VPpal _v;

        public Servidor(VPpal v)
        {
            _v = v;
        }

        public VPpal V
        {
            get { return _v; }
        }

        protected override void EventoDatosRecibidos(Conexion client, NetData objetoRecibido)
        {
            ManejoDB.InsertarFromNetData(client.IpAddress, objetoRecibido); //insercion db async.
            switch (objetoRecibido.CodigoDeProtocolo)
            {
                case (int) Protocolo.Cliente.Conectado:
                    V.Invoke(new VPpal._AddClient(V.AddNuevoCliente), client, objetoRecibido);
                    Clientes.Add(client);
                    break;
                case (int) Protocolo.Cliente.RespuestaInfoVentanas:
                    V.VentanaInfoVentanas.info = objetoRecibido;
                    V.VentanaInfoVentanas.Bw.RunWorkerAsync();
                    break;
                case (int)Protocolo.Cliente.RespuestaInfoSoftware:
                    V.VentanaInfoSoftware.info = objetoRecibido;
                    V.VentanaInfoSoftware.Bw.RunWorkerAsync();
                    break;
                case (int) Protocolo.Cliente.RespuestaInfoProcesos:
                    V.VentanaInfoProcesos.info = objetoRecibido;
                    V.VentanaInfoProcesos.Bw.RunWorkerAsync();
                    break;

                case (int) Protocolo.Cliente.AutentificacionCorrecta:
                    MessageBox.Show(V,
                                    "Has sido autentificado en el cliente", "Login Correcto", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    V.AutentificarCliente(client);
                    break;
                case (int) Protocolo.Cliente.AutentificacionIncorrecta:
                    MessageBox.Show(V,
                                    "Fallo al intentar autentificarse en el cliente.\n" + "La contraseña es incorrecta.",
                                    "Cliente Protegido",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Stop);
                    break;
                case (int) Protocolo.Cliente.PedirPassword:
                    MessageBox.Show(V,
                                    "El cliente sobre el que intentas realizar la accion está protegido por contraseña." +
                                    "Por favor, autentificate en el cliente.", "Cliente Protegido", MessageBoxButtons.OK,
                                    MessageBoxIcon.Stop);
                    break;
                case (int) Protocolo.Cliente.RespuestaComandoCmd:
                    if (!V.VentanaConsolaRemota.IsDisposed && V.VentanaConsolaRemota != null)
                    {
                        V.VentanaConsolaRemota.agregarRespuesta(objetoRecibido.GetDato("RespuestaCmd"));
                    }
                    break;
            }
        }

        protected override void EventoClienteDesconectado(Conexion client)
        {
            //llamada a traves del delegado para evitar problemas con los hilos.
            V.Invoke(new VPpal._DesconectarClient(V.DesconectarClient), client);
            Clientes.Remove(client);
        }
    }
}