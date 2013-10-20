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
    public partial class VInfoProcesos : VInformacionDelSistema
    {

        private readonly Button _btnMatarProceso;

        private readonly Button _btnIniciarProceso;

        public VInfoProcesos(Conexion cliente) : base(cliente)
        {
            Text = string.Format("Informacion del Sistema: Procesos En Ejecución  [{0}]", cliente.IpAddress);

            _btnIniciarProceso = new Button();
            _btnIniciarProceso.Text = "Iniciar Proceso";
            _btnIniciarProceso.Click += GestionBtnAcciones;
            _btnIniciarProceso.Dock = DockStyle.Fill;
            _btnIniciarProceso.Tag = "iniciar";


            _btnMatarProceso = new Button();
            _btnMatarProceso.Text = "Matar Proceso";
            _btnMatarProceso.Dock = DockStyle.Fill;
            _btnMatarProceso.Tag = "matar";
            _btnMatarProceso.Click += GestionBtnAcciones;

            tableAccionesLayaout.Controls.Add(_btnIniciarProceso);
            tableAccionesLayaout.Controls.Add(_btnMatarProceso);
            

        }

        /// <summary>
        ///     Envia un msg al cliente asociado pidiendole informacion sobre sus ventanas.
        /// </summary>
        public override void Actualizar()
        {
            Cliente.Enviar(new NetData((int) Protocolo.Servidor.PedirInfoProcesos));
        }

        //eventos    
        public void GestionBtnAcciones(object sender, EventArgs eventArgs)
        {
            Button btnSeleccionado = (Button) sender;
            String accion = btnSeleccionado.Tag.ToString();
            String nproc = null;
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
                    case "iniciar":
                        msgToClient = new NetData((int) Protocolo.Servidor.EjecutarProceso);
                        if (nproc == null)
                            nproc = MiInputBox.PedirString("Introduce el nombre del proceso",
                                                          "¿Cual es la ruta o nombre del proceso que deseas ejecutar?",
                                                          this);
                        //si no se coloco un titulo...
                        if (nproc == null)
                        {
                            MessageBox.Show("Debes introducir un nombre...");
                            return;
                        } //salgo.


                        msgToClient.AddDato("NombreProceso", nproc);
                        break;
                    case "matar":
                        msgToClient = new NetData((int)Protocolo.Servidor.MatarProceso);
                        break;

                }

                if (msgToClient != null)
                {
                    loadLabel.Visible = true;
                    statusStrip1.Text = "Procesando...";
                    msgToClient.AddDato("Id", row.Cells["Id"].Value.ToString());
                    Cliente.Enviar(msgToClient);                    
                    statusStrip1.Text = "Accion Realizada con exito.";
                    loadLabel.Visible = false;
                }
            }
            //autorefresh.
            Actualizar();
        }
    }
}