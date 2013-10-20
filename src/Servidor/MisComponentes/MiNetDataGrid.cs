#region

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Common;
using Common.Lib;

#endregion

namespace MisComponentes
{
    public partial class MiNetDataGrid : DataGridView
    {
        public delegate void _cargarConNetData(NetData a);

        public MiNetDataGrid()
        {
            InitializeComponent();
            AutoResizeColumns();
            CellContentClick += MiNetDataGrid_CellContentClick;
        }


        public MiNetDataGrid(IContainer container)
        {
            container.Add(this);
            InitializeComponent();

            AutoResizeColumns();

            CellContentClick += MiNetDataGrid_CellContentClick;
        }

        /// <summary>
        ///     Carga el Datagrid con los datos de un NetData de forma Thread-Safe y Asincrona
        ///     utilizando un delegado.
        /// </summary>
        /// <param name="a"></param>
        public void cargarConNetDataASync(NetData a)
        {
            Invoke(new _cargarConNetData(cargarConNetData), a);
        }

        public void cargarConNetData(NetData a)
        {
            limpiar();
            foreach (string clave in a.getClaves())
            {
                Columns.Add(clave, clave);
            }
            int numRegs = Serializador.DeserializarRegistro(a.GetDato(a.getClaves()[0])).Length;
            Rows.Add(numRegs);


            for (int i = 0; i < numRegs; i++)
            {
                int celda = 0;
                foreach (string clave in a.getClaves())
                {
                    string[] datos = Serializador.DeserializarRegistro(a.GetDato(clave));
                    for (int j = 0; j < numRegs; j++)
                    {
                        if (datos[j].IndexOf("www.") >= 0 || datos[j].IndexOf("http:") >= 0)
                            Rows[j].Cells[celda] = new DataGridViewLinkCell();
                        Rows[j].Cells[celda].Value = datos[j];
                    }
                    celda++;
                }
            }
        }

        private void limpiar()
        {
            Rows.Clear();
            Columns.Clear();
        }

        /*Lanzo en navegador con el link pulsado en caso de hacer click en alguno.*/

        private void MiNetDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Rows[e.RowIndex].Cells[e.ColumnIndex].GetType() == typeof (DataGridViewLinkCell))
                {
                    DataGridViewLinkCell celdaClickeada = (DataGridViewLinkCell) Rows[e.RowIndex].Cells[e.ColumnIndex];
                    Process.Start("" + celdaClickeada.Value);
                }
            }
            catch (Exception)
            {
            }
        }

        private void MiNetDataGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}