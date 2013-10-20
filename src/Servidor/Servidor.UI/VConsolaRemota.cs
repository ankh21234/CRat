#region

using System;
using System.Windows.Forms;
using Common.Lib;
using Servidor.Negocio;

#endregion

namespace Servidor.UI
{
    public partial class VConsolaRemota : Form
    {
        private readonly Conexion clienteAsociado;

        public VConsolaRemota(Conexion cliente)
        {
            InitializeComponent();
            clienteAsociado = cliente;
            Text = "Consola Remota con " + cliente.IpAddress;
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                NetData nd = new NetData((int) Protocolo.Servidor.EnviarCmdCommandRemoto);
                nd.AddDato("Comando", tbComando.Text);
                clienteAsociado.Enviar(nd);
                tbComando.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha perdido la conexion con el cliente.", "Error de conexion", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                Dispose();
            }
        }

        public void agregarRespuesta(String str)
        {
            rtResultado.AppendText(str);
        }

        private void tbComando_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnEnviar_Click(sender, e);
        }
    }
}