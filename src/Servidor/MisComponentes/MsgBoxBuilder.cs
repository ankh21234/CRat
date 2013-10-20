#region

using System;
using System.Windows.Forms;
using Common.Lib;

#endregion

namespace Servidor.UI
{
    public partial class MsgBoxBuilder : Form
    {
        private String _msg;
        private String[] _netDataInfo;
        private int _tipo;
        private String _titulo;

        public MsgBoxBuilder()
        {
            InitializeComponent();

            //Tags de los RadioButton.

            //tiposdeMsg
            rbNinguno.Tag = 0;
            rbInformacion.Tag = CommonConst.MsgBoxConst.TipoMsg.INFORMACION;
            rbAlerta.Tag = CommonConst.MsgBoxConst.TipoMsg.WARNING;
            rbError.Tag = CommonConst.MsgBoxConst.TipoMsg.ERROR;
            //botones
            rbOK.Tag = CommonConst.MsgBoxConst.Botones.OK;
            rbOkCancelar.Tag = CommonConst.MsgBoxConst.Botones.OK_CANCELAR;
            rbReintentarCancelar.Tag = CommonConst.MsgBoxConst.Botones.REINTENTAR_CANCELAR;
            rbSiNo.Tag = CommonConst.MsgBoxConst.Botones.SI_NO;
            rbSiNoCancelar.Tag = CommonConst.MsgBoxConst.Botones.SI_NO_CANCELAR;
            rbAnularReintentarIgnorar.Tag = CommonConst.MsgBoxConst.Botones.ANULAR_REINTENTAR_IGNORAR;
            rbCancelarIntentarContinuar.Tag = CommonConst.MsgBoxConst.Botones.CANCELAR_INTENTAR_CONTINUAR;
        }

        public String[] NetData
        {
            get { return _netDataInfo; }
        }

        private RadioButton ObtenerRadioButtonSeleccionado(Control container)
        {
            foreach (var control in container.Controls)
            {
                RadioButton radio = control as RadioButton;

                if (radio != null && radio.Checked)
                {
                    return radio;
                }
            }

            return null;
        }

        public static String[] obtenerMsgBoxDataInfo(String ipClienteTitulo)
        {
            MsgBoxBuilder form = new MsgBoxBuilder();
            if (ipClienteTitulo.Length > 0)
            {
                form.Text += string.Format(" [Cliente: {0}] ", ipClienteTitulo);
            }
            form.ShowDialog();
            return form.NetData;
        }

        public static String[] obtenerMsgBoxDataInfo()
        {
            return obtenerMsgBoxDataInfo("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _titulo = textBox1.Text;
            _msg = richTextBox1.Text;
            _tipo = (int) ObtenerRadioButtonSeleccionado(contTipoMsg).Tag +
                    (int) ObtenerRadioButtonSeleccionado(contBotones).Tag;

            if (_titulo.Length <= 0 || _msg.Length <= 0)
            {
                MessageBox.Show("No puede haber campos vacios.");
                return;
            }
            _netDataInfo = new string[3];
            _netDataInfo[0] = _msg;
            _netDataInfo[1] = _titulo;
            _netDataInfo[2] = _tipo.ToString();
            Dispose();
        }
    }
}