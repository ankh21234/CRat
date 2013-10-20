using System.Windows.Forms;
using System.Windows.Forms;

namespace Servidor.UI
{
    partial class VPpal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VPpal));
            this.lblOnline = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnListen = new System.Windows.Forms.Button();
            this.listGridClientes = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnStop = new System.Windows.Forms.Button();
            this.textPuertoEsc = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.iconoDeNotificacion = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnInfoServ = new System.Windows.Forms.Button();
            this.btnInfoWind = new System.Windows.Forms.Button();
            this.btnInfoProc = new System.Windows.Forms.Button();
            this.btnInfoSoft = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDesbloquearSistema = new System.Windows.Forms.Button();
            this.btnBloquearSistema = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSuspenderEquipo = new System.Windows.Forms.Button();
            this.btnReiniciarEquipo = new System.Windows.Forms.Button();
            this.btnApagarEquipo = new System.Windows.Forms.Button();
            this.btnDeslogearSesion = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnConsolaRemota = new System.Windows.Forms.Button();
            this.btnEscritorioRemoto = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnDesconectarCliente = new System.Windows.Forms.Button();
            this.btnPaginaWeb = new System.Windows.Forms.Button();
            this.btnEnviarMsgb = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.loadlabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.verLogDeEventosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spanishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aparienciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.officeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mSNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.button17 = new System.Windows.Forms.Button();
            this.LookAndFeel = new Sunisoft.IrisSkin.SkinEngine();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.contextMenuClienteListBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autentificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informacionDelSoftwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.softwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procesosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventanasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviciosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accionesDeBloqueoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bloquearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desbloquearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accionesDeApagadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apagarEquipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reiniciarEquipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suspenderEquipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accesoRemotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.escritorioRemotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consolaRemotaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.envioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msgBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paginaWebToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desconectarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuClienteListBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblOnline
            // 
            resources.ApplyResources(this.lblOnline, "lblOnline");
            this.lblOnline.Name = "lblOnline";
            this.helpProvider.SetShowHelp(this.lblOnline, ((bool)(resources.GetObject("lblOnline.ShowHelp"))));
            // 
            // txtPort
            // 
            resources.ApplyResources(this.txtPort, "txtPort");
            this.txtPort.Name = "txtPort";
            this.helpProvider.SetShowHelp(this.txtPort, ((bool)(resources.GetObject("txtPort.ShowHelp"))));
            // 
            // btnListen
            // 
            resources.ApplyResources(this.btnListen, "btnListen");
            this.btnListen.Name = "btnListen";
            this.helpProvider.SetShowHelp(this.btnListen, ((bool)(resources.GetObject("btnListen.ShowHelp"))));
            this.btnListen.UseVisualStyleBackColor = true;
            // 
            // listGridClientes
            // 
            this.listGridClientes.AutoArrange = false;
            this.listGridClientes.BackColor = System.Drawing.SystemColors.Window;
            this.listGridClientes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader8});
            resources.ApplyResources(this.listGridClientes, "listGridClientes");
            this.listGridClientes.FullRowSelect = true;
            this.listGridClientes.MultiSelect = false;
            this.listGridClientes.Name = "listGridClientes";
            this.helpProvider.SetShowHelp(this.listGridClientes, ((bool)(resources.GetObject("listGridClientes.ShowHelp"))));
            this.listGridClientes.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listGridClientes.UseCompatibleStateImageBehavior = false;
            this.listGridClientes.View = System.Windows.Forms.View.Details;
            this.listGridClientes.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listGridClientes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listGridClientes_MouseClick);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // columnHeader5
            // 
            resources.ApplyResources(this.columnHeader5, "columnHeader5");
            // 
            // columnHeader6
            // 
            resources.ApplyResources(this.columnHeader6, "columnHeader6");
            // 
            // columnHeader8
            // 
            resources.ApplyResources(this.columnHeader8, "columnHeader8");
            // 
            // btnStop
            // 
            resources.ApplyResources(this.btnStop, "btnStop");
            this.btnStop.Name = "btnStop";
            this.helpProvider.SetShowHelp(this.btnStop, ((bool)(resources.GetObject("btnStop.ShowHelp"))));
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // textPuertoEsc
            // 
            resources.ApplyResources(this.textPuertoEsc, "textPuertoEsc");
            this.textPuertoEsc.Name = "textPuertoEsc";
            this.helpProvider.SetShowHelp(this.textPuertoEsc, ((bool)(resources.GetObject("textPuertoEsc.ShowHelp"))));
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.helpProvider.SetShowHelp(this.button1, ((bool)(resources.GetObject("button1.ShowHelp"))));
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // iconoDeNotificacion
            // 
            resources.ApplyResources(this.iconoDeNotificacion, "iconoDeNotificacion");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnInfoServ);
            this.groupBox1.Controls.Add(this.btnInfoWind);
            this.groupBox1.Controls.Add(this.btnInfoProc);
            this.groupBox1.Controls.Add(this.btnInfoSoft);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.helpProvider.SetShowHelp(this.groupBox1, ((bool)(resources.GetObject("groupBox1.ShowHelp"))));
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnInfoServ
            // 
            resources.ApplyResources(this.btnInfoServ, "btnInfoServ");
            this.btnInfoServ.Image = global::Servidor.UI.Properties.Resources._1368656395_emblem_work;
            this.btnInfoServ.Name = "btnInfoServ";
            this.helpProvider.SetShowHelp(this.btnInfoServ, ((bool)(resources.GetObject("btnInfoServ.ShowHelp"))));
            this.btnInfoServ.UseVisualStyleBackColor = true;
            this.btnInfoServ.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnInfoWind
            // 
            this.helpProvider.SetHelpString(this.btnInfoWind, resources.GetString("btnInfoWind.HelpString"));
            this.btnInfoWind.Image = global::Servidor.UI.Properties.Resources._1368656372_gnome_window_manager;
            resources.ApplyResources(this.btnInfoWind, "btnInfoWind");
            this.btnInfoWind.Name = "btnInfoWind";
            this.helpProvider.SetShowHelp(this.btnInfoWind, ((bool)(resources.GetObject("btnInfoWind.ShowHelp"))));
            this.btnInfoWind.UseVisualStyleBackColor = true;
            this.btnInfoWind.Click += new System.EventHandler(this.eventoBtnInfoVentanasClick);
            // 
            // btnInfoProc
            // 
            this.btnInfoProc.Image = global::Servidor.UI.Properties.Resources._1368656360_kservices;
            resources.ApplyResources(this.btnInfoProc, "btnInfoProc");
            this.btnInfoProc.Name = "btnInfoProc";
            this.helpProvider.SetShowHelp(this.btnInfoProc, ((bool)(resources.GetObject("btnInfoProc.ShowHelp"))));
            this.btnInfoProc.UseVisualStyleBackColor = true;
            this.btnInfoProc.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnInfoSoft
            // 
            this.btnInfoSoft.Image = global::Servidor.UI.Properties.Resources._1368656336_kpackage;
            resources.ApplyResources(this.btnInfoSoft, "btnInfoSoft");
            this.btnInfoSoft.Name = "btnInfoSoft";
            this.helpProvider.SetShowHelp(this.btnInfoSoft, ((bool)(resources.GetObject("btnInfoSoft.ShowHelp"))));
            this.btnInfoSoft.UseVisualStyleBackColor = true;
            this.btnInfoSoft.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDesbloquearSistema);
            this.groupBox2.Controls.Add(this.btnBloquearSistema);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.helpProvider.SetShowHelp(this.groupBox2, ((bool)(resources.GetObject("groupBox2.ShowHelp"))));
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnDesbloquearSistema
            // 
            this.btnDesbloquearSistema.Image = global::Servidor.UI.Properties.Resources.Lock_Open_16;
            resources.ApplyResources(this.btnDesbloquearSistema, "btnDesbloquearSistema");
            this.btnDesbloquearSistema.Name = "btnDesbloquearSistema";
            this.helpProvider.SetShowHelp(this.btnDesbloquearSistema, ((bool)(resources.GetObject("btnDesbloquearSistema.ShowHelp"))));
            this.btnDesbloquearSistema.UseVisualStyleBackColor = true;
            this.btnDesbloquearSistema.Click += new System.EventHandler(this.eventoBtnDesbloquearSistemaClick);
            // 
            // btnBloquearSistema
            // 
            this.btnBloquearSistema.Image = global::Servidor.UI.Properties.Resources.Lock_16;
            resources.ApplyResources(this.btnBloquearSistema, "btnBloquearSistema");
            this.btnBloquearSistema.Name = "btnBloquearSistema";
            this.helpProvider.SetShowHelp(this.btnBloquearSistema, ((bool)(resources.GetObject("btnBloquearSistema.ShowHelp"))));
            this.btnBloquearSistema.UseVisualStyleBackColor = true;
            this.btnBloquearSistema.Click += new System.EventHandler(this.eventoBtnBloquearSistemaClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSuspenderEquipo);
            this.groupBox3.Controls.Add(this.btnReiniciarEquipo);
            this.groupBox3.Controls.Add(this.btnApagarEquipo);
            this.groupBox3.Controls.Add(this.btnDeslogearSesion);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.helpProvider.SetShowHelp(this.groupBox3, ((bool)(resources.GetObject("groupBox3.ShowHelp"))));
            this.groupBox3.TabStop = false;
            // 
            // btnSuspenderEquipo
            // 
            this.btnSuspenderEquipo.Image = global::Servidor.UI.Properties.Resources._1368656238_moon_fill;
            resources.ApplyResources(this.btnSuspenderEquipo, "btnSuspenderEquipo");
            this.btnSuspenderEquipo.Name = "btnSuspenderEquipo";
            this.helpProvider.SetShowHelp(this.btnSuspenderEquipo, ((bool)(resources.GetObject("btnSuspenderEquipo.ShowHelp"))));
            this.btnSuspenderEquipo.Tag = 8;
            this.btnSuspenderEquipo.UseVisualStyleBackColor = true;
            this.btnSuspenderEquipo.Click += new System.EventHandler(this.eventoBotonApagado);
            // 
            // btnReiniciarEquipo
            // 
            this.btnReiniciarEquipo.Image = global::Servidor.UI.Properties.Resources._1368656070_Power__Yellow;
            resources.ApplyResources(this.btnReiniciarEquipo, "btnReiniciarEquipo");
            this.btnReiniciarEquipo.Name = "btnReiniciarEquipo";
            this.helpProvider.SetShowHelp(this.btnReiniciarEquipo, ((bool)(resources.GetObject("btnReiniciarEquipo.ShowHelp"))));
            this.btnReiniciarEquipo.Tag = 2;
            this.btnReiniciarEquipo.UseVisualStyleBackColor = true;
            this.btnReiniciarEquipo.Click += new System.EventHandler(this.eventoBotonApagado);
            // 
            // btnApagarEquipo
            // 
            this.btnApagarEquipo.Image = global::Servidor.UI.Properties.Resources._1368656067_on_off;
            resources.ApplyResources(this.btnApagarEquipo, "btnApagarEquipo");
            this.btnApagarEquipo.Name = "btnApagarEquipo";
            this.helpProvider.SetShowHelp(this.btnApagarEquipo, ((bool)(resources.GetObject("btnApagarEquipo.ShowHelp"))));
            this.btnApagarEquipo.Tag = 1;
            this.btnApagarEquipo.UseVisualStyleBackColor = true;
            this.btnApagarEquipo.Click += new System.EventHandler(this.eventoBotonApagado);
            // 
            // btnDeslogearSesion
            // 
            this.btnDeslogearSesion.Image = global::Servidor.UI.Properties.Resources._1368656073_logout;
            resources.ApplyResources(this.btnDeslogearSesion, "btnDeslogearSesion");
            this.btnDeslogearSesion.Name = "btnDeslogearSesion";
            this.helpProvider.SetShowHelp(this.btnDeslogearSesion, ((bool)(resources.GetObject("btnDeslogearSesion.ShowHelp"))));
            this.btnDeslogearSesion.Tag = 0;
            this.btnDeslogearSesion.UseVisualStyleBackColor = true;
            this.btnDeslogearSesion.Click += new System.EventHandler(this.eventoBotonApagado);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnConsolaRemota);
            this.groupBox4.Controls.Add(this.btnEscritorioRemoto);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.helpProvider.SetShowHelp(this.groupBox4, ((bool)(resources.GetObject("groupBox4.ShowHelp"))));
            this.groupBox4.TabStop = false;
            // 
            // btnConsolaRemota
            // 
            this.btnConsolaRemota.Image = global::Servidor.UI.Properties.Resources._1368655827_itunes2aqua;
            resources.ApplyResources(this.btnConsolaRemota, "btnConsolaRemota");
            this.btnConsolaRemota.Name = "btnConsolaRemota";
            this.helpProvider.SetShowHelp(this.btnConsolaRemota, ((bool)(resources.GetObject("btnConsolaRemota.ShowHelp"))));
            this.btnConsolaRemota.UseVisualStyleBackColor = true;
            this.btnConsolaRemota.Click += new System.EventHandler(this.button13_Click);
            // 
            // btnEscritorioRemoto
            // 
            this.btnEscritorioRemoto.Image = global::Servidor.UI.Properties.Resources._1368655813_preferences_desktop_display;
            resources.ApplyResources(this.btnEscritorioRemoto, "btnEscritorioRemoto");
            this.btnEscritorioRemoto.Name = "btnEscritorioRemoto";
            this.helpProvider.SetShowHelp(this.btnEscritorioRemoto, ((bool)(resources.GetObject("btnEscritorioRemoto.ShowHelp"))));
            this.btnEscritorioRemoto.UseVisualStyleBackColor = true;
            this.btnEscritorioRemoto.Click += new System.EventHandler(this.eventoBtnEscritorioRemotoClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnDesconectarCliente);
            this.groupBox5.Controls.Add(this.btnPaginaWeb);
            this.groupBox5.Controls.Add(this.btnEnviarMsgb);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.helpProvider.SetShowHelp(this.groupBox5, ((bool)(resources.GetObject("groupBox5.ShowHelp"))));
            this.groupBox5.TabStop = false;
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // btnDesconectarCliente
            // 
            this.btnDesconectarCliente.Image = global::Servidor.UI.Properties.Resources._1368658821_gtk_disconnect;
            resources.ApplyResources(this.btnDesconectarCliente, "btnDesconectarCliente");
            this.btnDesconectarCliente.Name = "btnDesconectarCliente";
            this.helpProvider.SetShowHelp(this.btnDesconectarCliente, ((bool)(resources.GetObject("btnDesconectarCliente.ShowHelp"))));
            this.btnDesconectarCliente.UseVisualStyleBackColor = true;
            this.btnDesconectarCliente.Click += new System.EventHandler(this.eventoBtnDesconectarClienteClick);
            // 
            // btnPaginaWeb
            // 
            this.btnPaginaWeb.Image = global::Servidor.UI.Properties.Resources._1368656251_internet_web_browser;
            resources.ApplyResources(this.btnPaginaWeb, "btnPaginaWeb");
            this.btnPaginaWeb.Name = "btnPaginaWeb";
            this.helpProvider.SetShowHelp(this.btnPaginaWeb, ((bool)(resources.GetObject("btnPaginaWeb.ShowHelp"))));
            this.btnPaginaWeb.UseVisualStyleBackColor = true;
            this.btnPaginaWeb.Click += new System.EventHandler(this.eventoBotonEnviarWebClick);
            // 
            // btnEnviarMsgb
            // 
            this.btnEnviarMsgb.Image = global::Servidor.UI.Properties.Resources._1368656312_wall_post;
            resources.ApplyResources(this.btnEnviarMsgb, "btnEnviarMsgb");
            this.btnEnviarMsgb.Name = "btnEnviarMsgb";
            this.helpProvider.SetShowHelp(this.btnEnviarMsgb, ((bool)(resources.GetObject("btnEnviarMsgb.ShowHelp"))));
            this.btnEnviarMsgb.UseVisualStyleBackColor = true;
            this.btnEnviarMsgb.Click += new System.EventHandler(this.eventoBtnEnviarMsgBoxClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadlabel,
            this.txtEstado});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            this.helpProvider.SetShowHelp(this.statusStrip1, ((bool)(resources.GetObject("statusStrip1.ShowHelp"))));
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // loadlabel
            // 
            this.loadlabel.Image = global::Servidor.UI.Properties.Resources.loader;
            resources.ApplyResources(this.loadlabel, "loadlabel");
            this.loadlabel.Name = "loadlabel";
            // 
            // txtEstado
            // 
            this.txtEstado.ForeColor = System.Drawing.Color.Red;
            this.txtEstado.Name = "txtEstado";
            resources.ApplyResources(this.txtEstado, "txtEstado");
            // 
            // menuStrip1
            // 
            this.helpProvider.SetHelpKeyword(this.menuStrip1, resources.GetString("menuStrip1.HelpKeyword"));
            this.helpProvider.SetHelpString(this.menuStrip1, resources.GetString("menuStrip1.HelpString"));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem1,
            this.aparienciaToolStripMenuItem,
            this.aboutToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            this.helpProvider.SetShowHelp(this.menuStrip1, ((bool)(resources.GetObject("menuStrip1.ShowHelp"))));
            // 
            // opcionesToolStripMenuItem1
            // 
            this.opcionesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verLogDeEventosToolStripMenuItem,
            this.idiomaToolStripMenuItem});
            this.opcionesToolStripMenuItem1.Name = "opcionesToolStripMenuItem1";
            resources.ApplyResources(this.opcionesToolStripMenuItem1, "opcionesToolStripMenuItem1");
            // 
            // verLogDeEventosToolStripMenuItem
            // 
            this.verLogDeEventosToolStripMenuItem.Name = "verLogDeEventosToolStripMenuItem";
            resources.ApplyResources(this.verLogDeEventosToolStripMenuItem, "verLogDeEventosToolStripMenuItem");
            this.verLogDeEventosToolStripMenuItem.Click += new System.EventHandler(this.verLogDeEventosToolStripMenuItem_Click);
            // 
            // idiomaToolStripMenuItem
            // 
            this.idiomaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spanishToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.idiomaToolStripMenuItem.Name = "idiomaToolStripMenuItem";
            resources.ApplyResources(this.idiomaToolStripMenuItem, "idiomaToolStripMenuItem");
            // 
            // spanishToolStripMenuItem
            // 
            this.spanishToolStripMenuItem.Name = "spanishToolStripMenuItem";
            resources.ApplyResources(this.spanishToolStripMenuItem, "spanishToolStripMenuItem");
            this.spanishToolStripMenuItem.Click += new System.EventHandler(this.spanishToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // aparienciaToolStripMenuItem
            // 
            this.aparienciaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.officeToolStripMenuItem,
            this.mSNToolStripMenuItem});
            this.aparienciaToolStripMenuItem.Name = "aparienciaToolStripMenuItem";
            resources.ApplyResources(this.aparienciaToolStripMenuItem, "aparienciaToolStripMenuItem");
            this.aparienciaToolStripMenuItem.Click += new System.EventHandler(this.opcionesToolStripMenuItem_Click);
            // 
            // officeToolStripMenuItem
            // 
            this.officeToolStripMenuItem.Name = "officeToolStripMenuItem";
            resources.ApplyResources(this.officeToolStripMenuItem, "officeToolStripMenuItem");
            this.officeToolStripMenuItem.Click += new System.EventHandler(this.officeToolStripMenuItem_Click);
            // 
            // mSNToolStripMenuItem
            // 
            this.mSNToolStripMenuItem.Name = "mSNToolStripMenuItem";
            resources.ApplyResources(this.mSNToolStripMenuItem, "mSNToolStripMenuItem");
            this.mSNToolStripMenuItem.Click += new System.EventHandler(this.mSNToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            resources.ApplyResources(this.aboutToolStripMenuItem1, "aboutToolStripMenuItem1");
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // button17
            // 
            resources.ApplyResources(this.button17, "button17");
            this.button17.Name = "button17";
            this.helpProvider.SetShowHelp(this.button17, ((bool)(resources.GetObject("button17.ShowHelp"))));
            this.button17.Tag = "mostrar";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // LookAndFeel
            // 
            this.LookAndFeel.@__DrawButtonFocusRectangle = true;
            this.LookAndFeel.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.LookAndFeel.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.LookAndFeel.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.LookAndFeel.SerialNumber = "kUb2DF5pvGF3X9dKPFvIdkXQ0sE8LkAVp9fMme9wCnjZ+ArdRVlxKw==";
            this.LookAndFeel.SkinFile = "";
            // 
            // helpProvider
            // 
            resources.ApplyResources(this.helpProvider, "helpProvider");
            // 
            // contextMenuClienteListBox
            // 
            this.contextMenuClienteListBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autentificarToolStripMenuItem,
            this.informacionDelSoftwareToolStripMenuItem,
            this.accionesDeBloqueoToolStripMenuItem,
            this.accionesDeApagadoToolStripMenuItem,
            this.accesoRemotoToolStripMenuItem,
            this.envioToolStripMenuItem,
            this.desconectarToolStripMenuItem});
            this.contextMenuClienteListBox.Name = "contextMenuClienteListBox";
            this.helpProvider.SetShowHelp(this.contextMenuClienteListBox, ((bool)(resources.GetObject("contextMenuClienteListBox.ShowHelp"))));
            resources.ApplyResources(this.contextMenuClienteListBox, "contextMenuClienteListBox");
            this.contextMenuClienteListBox.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuClienteListBox_Opening);
            // 
            // autentificarToolStripMenuItem
            // 
            this.autentificarToolStripMenuItem.Name = "autentificarToolStripMenuItem";
            resources.ApplyResources(this.autentificarToolStripMenuItem, "autentificarToolStripMenuItem");
            this.autentificarToolStripMenuItem.Click += new System.EventHandler(this.autentificarToolStripMenuItem_Click);
            // 
            // informacionDelSoftwareToolStripMenuItem
            // 
            this.informacionDelSoftwareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.softwareToolStripMenuItem,
            this.procesosToolStripMenuItem,
            this.ventanasToolStripMenuItem,
            this.serviciosToolStripMenuItem});
            this.informacionDelSoftwareToolStripMenuItem.Name = "informacionDelSoftwareToolStripMenuItem";
            resources.ApplyResources(this.informacionDelSoftwareToolStripMenuItem, "informacionDelSoftwareToolStripMenuItem");
            // 
            // softwareToolStripMenuItem
            // 
            this.softwareToolStripMenuItem.Name = "softwareToolStripMenuItem";
            resources.ApplyResources(this.softwareToolStripMenuItem, "softwareToolStripMenuItem");
            this.softwareToolStripMenuItem.Click += new System.EventHandler(this.button2_Click);
            // 
            // procesosToolStripMenuItem
            // 
            this.procesosToolStripMenuItem.Name = "procesosToolStripMenuItem";
            resources.ApplyResources(this.procesosToolStripMenuItem, "procesosToolStripMenuItem");
            this.procesosToolStripMenuItem.Click += new System.EventHandler(this.button3_Click);
            // 
            // ventanasToolStripMenuItem
            // 
            this.ventanasToolStripMenuItem.Name = "ventanasToolStripMenuItem";
            resources.ApplyResources(this.ventanasToolStripMenuItem, "ventanasToolStripMenuItem");
            this.ventanasToolStripMenuItem.Click += new System.EventHandler(this.eventoBtnInfoVentanasClick);
            // 
            // serviciosToolStripMenuItem
            // 
            resources.ApplyResources(this.serviciosToolStripMenuItem, "serviciosToolStripMenuItem");
            this.serviciosToolStripMenuItem.Name = "serviciosToolStripMenuItem";
            // 
            // accionesDeBloqueoToolStripMenuItem
            // 
            this.accionesDeBloqueoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bloquearToolStripMenuItem,
            this.desbloquearToolStripMenuItem});
            this.accionesDeBloqueoToolStripMenuItem.Name = "accionesDeBloqueoToolStripMenuItem";
            resources.ApplyResources(this.accionesDeBloqueoToolStripMenuItem, "accionesDeBloqueoToolStripMenuItem");
            // 
            // bloquearToolStripMenuItem
            // 
            this.bloquearToolStripMenuItem.Name = "bloquearToolStripMenuItem";
            resources.ApplyResources(this.bloquearToolStripMenuItem, "bloquearToolStripMenuItem");
            this.bloquearToolStripMenuItem.Click += new System.EventHandler(this.eventoBtnBloquearSistemaClick);
            // 
            // desbloquearToolStripMenuItem
            // 
            this.desbloquearToolStripMenuItem.Name = "desbloquearToolStripMenuItem";
            resources.ApplyResources(this.desbloquearToolStripMenuItem, "desbloquearToolStripMenuItem");
            this.desbloquearToolStripMenuItem.Click += new System.EventHandler(this.eventoBtnDesbloquearSistemaClick);
            // 
            // accionesDeApagadoToolStripMenuItem
            // 
            this.accionesDeApagadoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesionToolStripMenuItem,
            this.apagarEquipoToolStripMenuItem,
            this.reiniciarEquipoToolStripMenuItem,
            this.suspenderEquipoToolStripMenuItem});
            this.accionesDeApagadoToolStripMenuItem.Name = "accionesDeApagadoToolStripMenuItem";
            resources.ApplyResources(this.accionesDeApagadoToolStripMenuItem, "accionesDeApagadoToolStripMenuItem");
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            resources.ApplyResources(this.cerrarSesionToolStripMenuItem, "cerrarSesionToolStripMenuItem");
            this.cerrarSesionToolStripMenuItem.Tag = 0;
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.eventoBotonApagado);
            // 
            // apagarEquipoToolStripMenuItem
            // 
            this.apagarEquipoToolStripMenuItem.Name = "apagarEquipoToolStripMenuItem";
            resources.ApplyResources(this.apagarEquipoToolStripMenuItem, "apagarEquipoToolStripMenuItem");
            this.apagarEquipoToolStripMenuItem.Tag = 1;
            this.apagarEquipoToolStripMenuItem.Click += new System.EventHandler(this.eventoBotonApagado);
            // 
            // reiniciarEquipoToolStripMenuItem
            // 
            this.reiniciarEquipoToolStripMenuItem.Name = "reiniciarEquipoToolStripMenuItem";
            resources.ApplyResources(this.reiniciarEquipoToolStripMenuItem, "reiniciarEquipoToolStripMenuItem");
            this.reiniciarEquipoToolStripMenuItem.Tag = 2;
            this.reiniciarEquipoToolStripMenuItem.Click += new System.EventHandler(this.eventoBotonApagado);
            // 
            // suspenderEquipoToolStripMenuItem
            // 
            this.suspenderEquipoToolStripMenuItem.Name = "suspenderEquipoToolStripMenuItem";
            resources.ApplyResources(this.suspenderEquipoToolStripMenuItem, "suspenderEquipoToolStripMenuItem");
            this.suspenderEquipoToolStripMenuItem.Tag = 8;
            this.suspenderEquipoToolStripMenuItem.Click += new System.EventHandler(this.eventoBotonApagado);
            // 
            // accesoRemotoToolStripMenuItem
            // 
            this.accesoRemotoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.escritorioRemotoToolStripMenuItem,
            this.consolaRemotaToolStripMenuItem});
            this.accesoRemotoToolStripMenuItem.Name = "accesoRemotoToolStripMenuItem";
            resources.ApplyResources(this.accesoRemotoToolStripMenuItem, "accesoRemotoToolStripMenuItem");
            // 
            // escritorioRemotoToolStripMenuItem
            // 
            this.escritorioRemotoToolStripMenuItem.Name = "escritorioRemotoToolStripMenuItem";
            resources.ApplyResources(this.escritorioRemotoToolStripMenuItem, "escritorioRemotoToolStripMenuItem");
            this.escritorioRemotoToolStripMenuItem.Click += new System.EventHandler(this.eventoBtnEscritorioRemotoClick);
            // 
            // consolaRemotaToolStripMenuItem
            // 
            this.consolaRemotaToolStripMenuItem.Name = "consolaRemotaToolStripMenuItem";
            resources.ApplyResources(this.consolaRemotaToolStripMenuItem, "consolaRemotaToolStripMenuItem");
            this.consolaRemotaToolStripMenuItem.Click += new System.EventHandler(this.button13_Click);
            // 
            // envioToolStripMenuItem
            // 
            this.envioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msgBoxToolStripMenuItem,
            this.paginaWebToolStripMenuItem});
            this.envioToolStripMenuItem.Name = "envioToolStripMenuItem";
            resources.ApplyResources(this.envioToolStripMenuItem, "envioToolStripMenuItem");
            // 
            // msgBoxToolStripMenuItem
            // 
            this.msgBoxToolStripMenuItem.Name = "msgBoxToolStripMenuItem";
            resources.ApplyResources(this.msgBoxToolStripMenuItem, "msgBoxToolStripMenuItem");
            this.msgBoxToolStripMenuItem.Click += new System.EventHandler(this.eventoBtnEnviarMsgBoxClick);
            // 
            // paginaWebToolStripMenuItem
            // 
            this.paginaWebToolStripMenuItem.Name = "paginaWebToolStripMenuItem";
            resources.ApplyResources(this.paginaWebToolStripMenuItem, "paginaWebToolStripMenuItem");
            this.paginaWebToolStripMenuItem.Click += new System.EventHandler(this.eventoBotonEnviarWebClick);
            // 
            // desconectarToolStripMenuItem
            // 
            this.desconectarToolStripMenuItem.Name = "desconectarToolStripMenuItem";
            resources.ApplyResources(this.desconectarToolStripMenuItem, "desconectarToolStripMenuItem");
            this.desconectarToolStripMenuItem.Click += new System.EventHandler(this.eventoBtnDesconectarClienteClick);
            // 
            // VPpal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button17);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.textPuertoEsc);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblOnline);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.btnListen);
            this.Controls.Add(this.listGridClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.helpProvider.SetHelpKeyword(this, resources.GetString("$this.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("$this.HelpNavigator"))));
            this.MaximizeBox = false;
            this.Name = "VPpal";
            this.helpProvider.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VPpal_FormClosed);
            this.Load += new System.EventHandler(this.VPpal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuClienteListBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        #endregion

        private System.Windows.Forms.Label lblOnline;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnListen;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.Button btnStop;
        public System.Windows.Forms.TextBox textPuertoEsc;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.NotifyIcon iconoDeNotificacion;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        public ListView listGridClientes;
        private GroupBox groupBox1;
        private Button btnInfoWind;
        private Button btnInfoProc;
        private Button btnInfoSoft;
        private Button btnInfoServ;
        private GroupBox groupBox2;
        private Button btnDesbloquearSistema;
        private Button btnBloquearSistema;
        private GroupBox groupBox3;
        private Button btnSuspenderEquipo;
        private Button btnReiniciarEquipo;
        private Button btnApagarEquipo;
        private Button btnDeslogearSesion;
        private GroupBox groupBox4;
        private Button btnConsolaRemota;
        private Button btnEscritorioRemoto;
        private GroupBox groupBox5;
        private Button btnEnviarMsgb;
        private Button btnPaginaWeb;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel txtEstado;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem aparienciaToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem1;
        private Button button17;
        private ToolStripStatusLabel loadlabel;
        private Sunisoft.IrisSkin.SkinEngine LookAndFeel;
        private ToolStripMenuItem officeToolStripMenuItem;
        private ToolStripMenuItem mSNToolStripMenuItem;
        private HelpProvider helpProvider;
        private Button btnDesconectarCliente;
        private ToolStripMenuItem opcionesToolStripMenuItem1;
        private ToolStripMenuItem verLogDeEventosToolStripMenuItem;
        private ContextMenuStrip contextMenuClienteListBox;
        private ToolStripMenuItem autentificarToolStripMenuItem;
        private ToolStripMenuItem informacionDelSoftwareToolStripMenuItem;
        private ToolStripMenuItem softwareToolStripMenuItem;
        private ToolStripMenuItem procesosToolStripMenuItem;
        private ToolStripMenuItem ventanasToolStripMenuItem;
        private ToolStripMenuItem serviciosToolStripMenuItem;
        private ToolStripMenuItem accionesDeBloqueoToolStripMenuItem;
        private ToolStripMenuItem bloquearToolStripMenuItem;
        private ToolStripMenuItem desbloquearToolStripMenuItem;
        private ToolStripMenuItem accionesDeApagadoToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private ToolStripMenuItem apagarEquipoToolStripMenuItem;
        private ToolStripMenuItem reiniciarEquipoToolStripMenuItem;
        private ToolStripMenuItem suspenderEquipoToolStripMenuItem;
        private ToolStripMenuItem accesoRemotoToolStripMenuItem;
        private ToolStripMenuItem escritorioRemotoToolStripMenuItem;
        private ToolStripMenuItem consolaRemotaToolStripMenuItem;
        private ToolStripMenuItem envioToolStripMenuItem;
        private ToolStripMenuItem msgBoxToolStripMenuItem;
        private ToolStripMenuItem paginaWebToolStripMenuItem;
        private ToolStripMenuItem desconectarToolStripMenuItem;
        private ToolStripMenuItem idiomaToolStripMenuItem;
        private ToolStripMenuItem spanishToolStripMenuItem;
        private ToolStripMenuItem englishToolStripMenuItem;
    }
}

