#region

using System.Runtime.InteropServices;

#endregion

namespace Cliente.Common
{
    public class MiMsgBox
    {
        [DllImport("User32.dll")]
        public static extern int MessageBoxA(int manejador, string msg, string titulo, int tipo);

        public class Tipos
        {
            public enum Botones
            {
                ANULAR_REINTENTAR_IGNORAR = (int) 0x00000002L,
                CANCELAR_INTENTAR_CONTINUAR = (int) 0x00000006L,
                OK = (int) 0x00000000L,
                OK_CANCELAR = (int) 0x00000001L,
                REINTENTAR_CANCELAR = (int) 0x00000005L,
                SI_NO = (int) 0x00000004L,
                SI_NO_CANCELAR = (int) 0x00000003L
            };

            public enum TipoMsg
            {
                EXCLAMACION = (int) 0x00000030L,
                WARNING = (int) 0x00000030L,
                INFORMACION = (int) 0x00000040L,
                RIESGO = (int) 0x00000040L,
                PREGUNTA = (int) 0x00000020L,
                ERROR = (int) 0x00000010L,
            }
        }        
    }
}