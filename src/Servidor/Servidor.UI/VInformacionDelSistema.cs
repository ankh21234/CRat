#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Common.Lib;
using Servidor.Negocio;

#endregion

namespace Servidor.UI
{
    public abstract partial class VInformacionDelSistema : Form
    {
        public delegate void _actualizarConNetData(NetData nd);

        private readonly Conexion _cliente;
        public NetData info;


        public VInformacionDelSistema(Conexion cliente)
        {
            _cliente = cliente;

            InitializeComponent();
        }

        public VInformacionDelSistema()
        {
        }

        public Conexion Cliente
        {
            get { return _cliente; }
        }

        public BackgroundWorker Bw
        {
            get { return backgroundWorker1; }
        }

        //delegado para evitar problemas con threads.
        public void actualizarConNetData(NetData nd)
        {
            toolStripStatusLabel1.ForeColor = Color.Green;
            toolStripStatusLabel1.Text = "Cargando";
            loadLabel.Visible = true;
            miGrid.cargarConNetDataASync(nd);
            toolStripStatusLabel1.Text = "Se recibieron " + miGrid.Rows.Count + " registros";
            loadLabel.Visible = false;
            info = null;
        }

        public abstract void Actualizar();


        private void button1_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void VInformacionDelSistema_Load(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }


        private void actualizador_Tick(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (info != null)
            {
                Invoke(new _actualizarConNetData(actualizarConNetData), info);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}