#region

using System;
using System.Windows.Forms;

#endregion

namespace Servidor.UI
{
    public partial class FormEscritorioRemoto : Form
    {
        public FormEscritorioRemoto(string ip, int puerto, bool soloLectura)
        {
            InitializeComponent();
            Text = string.Format("Escritorio Remoto [Cliente {0}]", ip);
            remoteDesktop1.VncPort = puerto;
        }

        public static void AbrirFormEscritorioRemoto(string ip, int puerto, bool soloLectura)
        {
            try
            {
                FormEscritorioRemoto vRemoto = new FormEscritorioRemoto(ip, puerto, soloLectura);
                vRemoto.remoteDesktop1.Connect(ip, false,true);
                vRemoto.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Imposible iniciar una conexión de escritorio remoto con el equipo especificado.",
                                "Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormEscritorioRemoto_Load(object sender, EventArgs e)
        {
        }

        private void FormEscritorioRemoto_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (remoteDesktop1.IsConnected)
                remoteDesktop1.Disconnect();
        }
    }
}