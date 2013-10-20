#region

using System;
using System.Threading;
using System.Windows.Forms;
using Common.Lib;
using MisComponentes;
using Servidor.Negocio;

#endregion

namespace Servidor.UI
{
    public partial class VInfoVentanas : VInformacionDelSistema
    {
        private readonly Button _btnBloquear;
        private readonly Button _btnCambiarTitulo;
        private readonly Button _btnDesbloquear;
        private readonly Button _btnMinimizar;

        public VInfoVentanas(Conexion cliente) : base(cliente)
        {
            Text = string.Format("Informacion del Sistema: Ventanas Visibles  [{0}]", cliente.IpAddress);

            _btnMinimizar = new Button();
            _btnMinimizar.Text = "Minimizar";
            _btnMinimizar.Click += GestionBtnAcciones;
            _btnMinimizar.Dock = DockStyle.Fill;
            _btnMinimizar.Tag = "minimizar";

            _btnBloquear = new Button();
            _btnBloquear.Text = "Bloquear";
            _btnBloquear.Dock = DockStyle.Fill;
            _btnBloquear.Tag = "bloquear";
            _btnBloquear.Click += GestionBtnAcciones;

            _btnDesbloquear = new Button();
            _btnDesbloquear.Text = "Desbloquear";
            _btnDesbloquear.Dock = DockStyle.Fill;
            _btnDesbloquear.Tag = "desbloquear";
            _btnDesbloquear.Click += GestionBtnAcciones;

            _btnCambiarTitulo = new Button();
            _btnCambiarTitulo.Text = "Cambiar Titulo";
            _btnCambiarTitulo.Dock = DockStyle.Fill;
            _btnCambiarTitulo.Tag = "cambiartitulo";
            _btnCambiarTitulo.Click += GestionBtnAcciones;


            tableAccionesLayaout.Controls.Add(_btnCambiarTitulo);
            tableAccionesLayaout.Controls.Add(_btnMinimizar);
            tableAccionesLayaout.Controls.Add(_btnBloquear);
            tableAccionesLayaout.Controls.Add(_btnDesbloquear);
        }

        /// <summary>
        ///     Envia un msg al cliente asociado pidiendole informacion sobre sus ventanas.
        /// </summary>
        public override void Actualizar()
        {
            Cliente.Enviar(new NetData((int) Protocolo.Servidor.PedirInfoVentanas));
        }

        //eventos    
        public void GestionBtnAcciones(object sender, EventArgs eventArgs)
        {
            Button btnSeleccionado = (Button) sender;
            String accion = btnSeleccionado.Tag.ToString();
            String ntit = null;
            if (miGrid.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Debes seleccionar alguna ventana", "No hay ningun objetivo");
                return;
            }
            foreach (DataGridViewRow row in miGrid.SelectedRows)
            {
                //creo el NetData segun la accion seleccionada.
                NetData msgToClient = null;
                switch (accion)
                {
                    case "minimizar":
                        msgToClient = new NetData((int) Protocolo.Servidor.MinimizarVentana);
                        break;
                    case "desbloquear":
                        msgToClient = new NetData((int) Protocolo.Servidor.DesbloquearVentana);
                        break;
                    case "bloquear":
                        msgToClient = new NetData((int) Protocolo.Servidor.BloquearVentana);
                        break;
                    case "cambiartitulo":
                        msgToClient = new NetData((int) Protocolo.Servidor.CambiarTituloVentana);
                        if (ntit == null)
                            ntit = MiInputBox.PedirString("Introduce un titulo",
                                                          "¿Qué titulo deseas para las ventanas seleccionadas?",
                                                          this);
                        //si no se coloco un titulo...
                        if (ntit == null)
                        {
                            MessageBox.Show("Debes introducir un titulo...");
                            return;
                        } //salgo.


                        msgToClient.AddDato("NuevoTitulo", ntit);
                        break;
                }

                if (msgToClient != null)
                {
                    loadLabel.Visible = true;
                    statusStrip1.Text = "Procesando...";
                    msgToClient.AddDato("Handle", row.Cells["Handle"].Value.ToString());
                    Cliente.Enviar(msgToClient);
                    Thread.Sleep(80);
                    statusStrip1.Text = "Accion Realizada con exito.";
                    loadLabel.Visible = false;
                }
            }
            //autorefresh.
            Actualizar();
        }
    }
}