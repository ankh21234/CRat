namespace Servidor.UI
{
    partial class VisorDeEventos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarInformeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarAPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarAExcellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarAWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarAHTMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarATXTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TablaEventos = new MisComponentes.MiNetDataGrid(this.components);
            this.bwExportarInforme = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaEventos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(736, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generarInformeToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // generarInformeToolStripMenuItem
            // 
            this.generarInformeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportarAPDFToolStripMenuItem,
            this.exportarAExcellToolStripMenuItem,
            this.exportarAWordToolStripMenuItem,
            this.exportarAHTMLToolStripMenuItem,
            this.exportarATXTToolStripMenuItem});
            this.generarInformeToolStripMenuItem.Name = "generarInformeToolStripMenuItem";
            this.generarInformeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.generarInformeToolStripMenuItem.Text = "Exportar Informe";
            // 
            // exportarAPDFToolStripMenuItem
            // 
            this.exportarAPDFToolStripMenuItem.Name = "exportarAPDFToolStripMenuItem";
            this.exportarAPDFToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.exportarAPDFToolStripMenuItem.Tag = VisorDeEventos.FormatoInforme.Pdf;
            this.exportarAPDFToolStripMenuItem.Text = "Exportar a PDF";
            this.exportarAPDFToolStripMenuItem.Click += new System.EventHandler(this.eventoExportarInforme);
            // 
            // exportarAExcellToolStripMenuItem
            // 
            this.exportarAExcellToolStripMenuItem.Name = "exportarAExcellToolStripMenuItem";
            this.exportarAExcellToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.exportarAExcellToolStripMenuItem.Tag = VisorDeEventos.FormatoInforme.Xls;
            this.exportarAExcellToolStripMenuItem.Text = "Exportar a Excel";
            this.exportarAExcellToolStripMenuItem.Click += new System.EventHandler(this.eventoExportarInforme);
            // 
            // exportarAWordToolStripMenuItem
            // 
            this.exportarAWordToolStripMenuItem.Name = "exportarAWordToolStripMenuItem";
            this.exportarAWordToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.exportarAWordToolStripMenuItem.Tag = VisorDeEventos.FormatoInforme.Doc;
            this.exportarAWordToolStripMenuItem.Text = "Exportar a Word";
            this.exportarAWordToolStripMenuItem.Click += new System.EventHandler(this.eventoExportarInforme);
            // 
            // exportarAHTMLToolStripMenuItem
            // 
            this.exportarAHTMLToolStripMenuItem.Name = "exportarAHTMLToolStripMenuItem";
            this.exportarAHTMLToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.exportarAHTMLToolStripMenuItem.Tag = VisorDeEventos.FormatoInforme.Html;
            this.exportarAHTMLToolStripMenuItem.Text = "Exportar a HTML";
            this.exportarAHTMLToolStripMenuItem.Click += new System.EventHandler(this.eventoExportarInforme);
            // 
            // exportarATXTToolStripMenuItem
            // 
            this.exportarATXTToolStripMenuItem.Name = "exportarATXTToolStripMenuItem";
            this.exportarATXTToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.exportarATXTToolStripMenuItem.Tag = VisorDeEventos.FormatoInforme.Txt;
            this.exportarATXTToolStripMenuItem.Text = "Exportar a TXT";
            this.exportarATXTToolStripMenuItem.Click += new System.EventHandler(this.eventoExportarInforme);
            // 
            // TablaEventos
            // 
            this.TablaEventos.AllowUserToAddRows = false;
            this.TablaEventos.AllowUserToDeleteRows = false;
            this.TablaEventos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TablaEventos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TablaEventos.Location = new System.Drawing.Point(0, 24);
            this.TablaEventos.MultiSelect = false;
            this.TablaEventos.Name = "TablaEventos";
            this.TablaEventos.ReadOnly = true;
            this.TablaEventos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.TablaEventos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TablaEventos.Size = new System.Drawing.Size(736, 489);
            this.TablaEventos.TabIndex = 0;
            this.TablaEventos.VirtualMode = true;
            this.TablaEventos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.TablaEventos_CellFormatting);
            // 
            // bwExportarInforme
            // 
            this.bwExportarInforme.WorkerReportsProgress = true;
            this.bwExportarInforme.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwExportarInforme_DoWork);
            // 
            // VisorDeEventos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 513);
            this.Controls.Add(this.TablaEventos);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "VisorDeEventos";
            this.Text = "Visor De Eventos";
            this.Load += new System.EventHandler(this.VisorDeEventos_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TablaEventos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MisComponentes.MiNetDataGrid TablaEventos;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarInformeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarAPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarAExcellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarAWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarAHTMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportarATXTToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bwExportarInforme;

    }
}