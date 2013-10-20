using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common.Lib;
using Servidor.Negocio;

namespace Servidor.UI
{
    public partial class VInfoSoftware : VInformacionDelSistema
    {
        public VInfoSoftware(Conexion cliente): base(cliente)
        {
            
           // this.groupBox1.Enabled = false;
            InitializeComponent();
            Text = string.Format("Informacion del Sistema: Software Instalado  [{0}]", cliente.IpAddress);
        }

        public override void Actualizar()
        {
            try
            {
                Cliente.Enviar(new NetData((int)Protocolo.Servidor.PedirInfoSoftware));
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Imposible establecer comunicacion con el cliente.", "Fallo en la comunicación",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
