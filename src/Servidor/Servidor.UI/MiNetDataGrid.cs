using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Common;
using Common.Lib;

namespace Servidor.UI
{
    public partial class MiNetDataGrid : DataGridView
    {
        public MiNetDataGrid()
        {
            InitializeComponent();          
            this.AutoResizeColumns();
            this.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public MiNetDataGrid(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            
            AutoResizeColumns();

            AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;            
        }
        public void cargarConNetDataASync(NetData a)
        {
            this.Invoke(new _cargarConNetData(cargarConNetData));
        }

        public delegate void _cargarConNetData(NetData a);
        public void cargarConNetData(NetData a)
        {
            limpiar();
            foreach (string clave in a.getClaves())
            {
                this.Columns.Add(clave, clave);
                
            }
            int numRegs = Serializador.DeserializarRegistro(a.GetDato(a.getClaves()[0])).Count();
            this.Rows.Add(numRegs);
            

            for (int i = 0; i < numRegs; i++)
            {
                int celda = 0;
                foreach (string clave in a.getClaves())
                {
                    string[] datos = Serializador.DeserializarRegistro(a.GetDato(clave));
                    for (int j = 0; j < numRegs; j++)
                    {
                        if (datos[j].IndexOf("www.") >= 0 || datos[j].IndexOf("http:") >=0)
                            this.Rows[j].Cells[celda] = new DataGridViewLinkCell();
                        this.Rows[j].Cells[celda].Value = datos[j];
                    }
                    celda++;
                }
            }
            
        }
        private void limpiar()
        {
            this.Rows.Clear();
            this.Columns.Clear();
        }

        private void MiNetDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType() == typeof(DataGridViewLinkCell))
            {
                DataGridViewLinkCell celdaClickeada = (DataGridViewLinkCell) this.Rows[e.RowIndex].Cells[e.ColumnIndex];
                Process.Start(""+celdaClickeada.Value);
            }
        }
    }
}
