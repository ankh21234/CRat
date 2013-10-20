#region

using System;
using System.Windows.Forms;

#endregion

namespace MisComponentes
{
    public partial class MiInputBox : Form
    {
        private String _cadena;

        public MiInputBox()
        {
            InitializeComponent();
        }

        public string Cadena
        {
            get { return _cadena; }
        }


        public static String PedirString(String titulo, String msg, IWin32Window ventanaPadre)
        {
            MiInputBox box = new MiInputBox();
            box.Text = titulo;
            box.lblMsg.Text = msg;
            if (ventanaPadre != null)
                box.ShowDialog(ventanaPadre);
            else
                box.ShowDialog();

            return box.Cadena;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _cadena = txtInput.Text;
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _cadena = null;
            Dispose();
        }
    }
}