namespace Common.Lib
{
     public class Protocolo
    {
         public enum Cliente
         {
             //conexion
             Desconectado = 0x0,
             Conectado = 0x1,                                       
             //password
             PedirPassword = 0x2,  
             AutentificacionCorrecta = 0x30,
             AutentificacionIncorrecta = 0x31,
             //ventanas
             RespuestaInfoVentanas = 0x32,
             //software
             RespuestaInfoSoftware = 0x489,
             //procesos
             RespuestaInfoProcesos = 0x410,
             //Servicios
             RespuestaInfoServicios = 0x470,
             //Consola Remota
             RespuestaComandoCmd = 0x80,
             
             //Respuestas Genericas
             RespuestaSuccess = 0x3e8,
             RespuestaError = 0x3e9
         }
         public enum Servidor
         {
             //password
             EnviarPassword = 0x3,             
             //Ventanas
             PedirInfoVentanas= 0xa,             
             CambiarTituloVentana = 0xb,
             BloquearVentana = 0xc,
             DesbloquearVentana = 0xd,
             MinimizarVentana = 0xe,         
    
             //Procesos
             PedirInfoProcesos = 0x78,
             MatarProceso = 0x79,
             EjecutarProceso = 0x7a,

             //Servicios
             PedirInfoServicios = 0x8c,
             IniciarServicio = 0x8d,
             PararServicio = 0x8e,

             //Software 
             PedirInfoSoftware = 0x82,
             //MsgBox
             MostrarMsgBox = 0x14,             
             //Escritorio Remoto 
             IniciarEscritorioRemoto = 0x45,
             
             //ConsolaRemota
             EnviarCmdCommandRemoto = 0x99,
             //Envio web
             AbrirPaginaWeb = 0xd1,

             //opciones de Apagado
             ApagarEquipo = 0x50,  //engloba Apagar,Suspender,Deslogear y Reiniciar mediante el dato 'Flag'.
             //Bloqueo
             BloquearSistema = 0x64,
             DesbloquearSistema = 0x65,


            //desconexion
             DesconectarCliente = 0x3ea,


         }

    }
}
