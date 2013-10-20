#region

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using Servidor.DB;

#endregion

namespace Servidor.UI
{
    public partial class VisorDeEventos : Form
    {
        private readonly string _normbreArchivo = string.Format("informe[{0}]", DateTime.Today.ToString("dd-MM-yyyy"));
                                //nombre del archivo donde se exportara el informe.

        private string _exportPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //determina la ruta y el formato con el que se exportará el archivo.        

        private FormatoInforme _formato = FormatoInforme.Pdf; //_formato del informe generado.


        public VisorDeEventos()
        {
            _exportPath += "\\InformesCrat";
            InitializeComponent();
        }

        private void VisorDeEventos_Load(object sender, EventArgs e)
        {
            try
            {
                DataSetV_LOG.v_logDataTable datos = ManejoDB.ObtenerLogAccionesDB().v_log;
                TablaEventos.DataSource = datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Dispose();
            }
        }

        private void eventoExportarInforme(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem) sender;
            _formato = (FormatoInforme) mi.Tag;
            bwExportarInforme.RunWorkerAsync();
        }

        private void TablaEventos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < TablaEventos.Rows.Count; i++)
            {
                if (TablaEventos.Rows[i].Cells["EmisorAccion"].Value.ToString().CompareTo("Cliente") == 0)
                {
                    TablaEventos.Rows[i].DefaultCellStyle.BackColor = Color.Moccasin;
                }
                else
                {
                    TablaEventos.Rows[i].DefaultCellStyle.BackColor = Color.OldLace;
                }
            }
        }

        private void bwExportarInforme_DoWork(object sender, DoWorkEventArgs e)
        {
            string pathArchivo = _exportPath + "\\" + _normbreArchivo + "." + _formato;
            pathArchivo = pathArchivo.ToLower();

            string fullPath = (pathArchivo).ToLower();

            InformeEventos informe = new InformeEventos();
            informe.SetDataSource(ManejoDB.ObtenerLogAccionesDB());
            ExportFormatType tipoFormato = ExportFormatType.NoFormat;
            switch (_formato)
            {
                case FormatoInforme.Doc:
                    tipoFormato = ExportFormatType.WordForWindows;
                    break;
                case FormatoInforme.Html:
                    tipoFormato = ExportFormatType.HTML40;
                    break;
                case FormatoInforme.Pdf:
                    tipoFormato = ExportFormatType.PortableDocFormat;
                    break;
                case FormatoInforme.Xls:
                    tipoFormato = ExportFormatType.Excel;
                    break;
                case FormatoInforme.Txt:
                    tipoFormato = ExportFormatType.Text;
                    break;
            }
            try
            {
                if (!Directory.Exists(_exportPath))
                    Directory.CreateDirectory(_exportPath);
                informe.ExportToDisk(tipoFormato, fullPath);
                MessageBox.Show("El informe se generó corrrectamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                                "Ocurrio un error al guardar el informe, Asegurese de que el archivo no esta en uso.",
                                "Error al guardar el Informe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                Process.Start(fullPath);
            }
            catch (Exception)
            {
            }
        }

        private enum FormatoInforme
        {
            Pdf,
            Doc,
            Xls,
            Html,
            Txt
        };
    }
}