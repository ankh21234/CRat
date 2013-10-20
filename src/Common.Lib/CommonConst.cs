namespace Common.Lib
{
    /// <summary>
    ///     Clase que contiene las constantes (que no son del protocolo) que necesitan el cliente
    ///     y el servidor para comunicarse.
    /// </summary>
    public class CommonConst
    {
        /// <summary>
        ///     Constantes necesarias para indicar el tipo de Acción que queremos que realice el
        ///     pc cliente durante la acción de apagado.
        /// </summary>
        public enum ShutdownFlags
        {
            DESLOGUEAR = 0,
            FORZAR_DESLOGEAR = 4,
            APAGAR = 1,
            FORZAR_APAGAR = 5,
            REINICIAR = 2,
            FORZAR_REINICIAR = 6,
            SUSPENDER = 8,
            FORZAR_SUSPENDER = 12
        }

        /// <summary>
        ///     Constantes necesarias para indicar el tipo de MsgBox que queremos invocar mediante
        ///     el API de Windows en el cliente.
        /// </summary>
        public class MsgBoxConst
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