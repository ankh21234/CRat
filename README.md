#CRAT - Remote Admin Tool

==================

###¿Qué es?
**C-Rat** es una herramienta cuya finalidad consiste en habilitar a un administrador a manejar/interactuar de forma cómoda y rápida los equipos de la red en la que se encuentra o de forma totalmente remota a través de internet, permitiendole obtener información o ejecutar acciones concretas en los equipos.

###Caracteristicas
Las principales características que posee **C-Rat** son:

- Los equipos clientes los que se conecten al equipo **Administrador** automáticamente siempre que les sea posible y no al revés, de forma que el administrador pueda seguir recibiendo conexiones aun **sin saber la dirección de los equipos clientes** y así tener controlada la red.

- El administrador puede **Enviar mensajes de aviso **(información, alerta, error) al equipo que desee.

- Posibilidad de **recopilar información del sistema** del cliente que desee **(Software, Ventanas, Procesos, Servicios...)**.
- Posibilidad de **realizar acciones sobre las ventanas** que se encuentran abiertas en el equipo que desee, pudiendo minimizarlas, bloquearlas permanentemente,desbloquearlas, cambiarle el titulo(Joke).
- Posibilidad de **Iniciar o Matar Procesos** en los clientes que desee.
- Posibilidad de **abrir páginas de forma remota** en los equipos que desee, lanzando el navegador con la web solicitada automáticamente.
- Posibilidad **Apagar, Reiniciar , Suspender y Cerrar sesión** en los equipos.
- Posibilidad de **ejecutar comandos de consola (cmd)** de forma remota y visualizar su respuesta.
- Podrá **iniciar escritorio remoto con el equipo deseado** , tanto en modo visualización como manejable.
- Crea un **historial con todas las acciones que ha realizado el administrador** y las respuestas de los respectivos clientes (almacenado en DB).
- Permite la **personalización** de la aplicación servidora** mediante temas** que se pueden cambiar en tiempo de ejecución.
- Permite la **elección del idioma** de la aplicación (Español/Ingles).
**Genera informes** en base a la información anterior en los formatos **PDF, Word, Excel, txt, HTML,** con una presentación limpia para impresión y manejando de forma eficiente la información de la base de datos para generar gráficas sobre el uso de la aplicación (Por cliente,fecha,en función de acciones...).


Asimismo, la aplicación cliente también dispone de algunas características propias que el administrador podrá definir de formar fácil antes de distribuirla:

- Permite definir la dirección a la que el cliente intentará conectarse [IP : Puerto].
- Permite la **ejecución del cliente en modo consola** (debug) o en forma de **proceso oculto**. 
- Permite **proteger el cliente con una contraseña** , de forma que ningún administrador con la aplicación servidora podrá manejar ese cliente sin autentificarse con posterioridad.
- Permite **definir los tiempos de re-conexión** del cliente.
- Permite **definir una contraseña adicional** para la conexión de **escritorio remoto** , así como el puerto que usará para establecerla.


Para saber mas sobre C-Rat, puedes consultar los siguientes documentos:
> [Documentacion de C-RAT](https://dl.dropboxusercontent.com/u/62577971/Manual%20de%20Usuario%20de%20CRAT.pdf)
