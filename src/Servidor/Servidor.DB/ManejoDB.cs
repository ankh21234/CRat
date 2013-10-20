#region

using System;
using System.Data.SqlClient;
using System.Threading;
using Common.Lib;
using MySql.Data.MySqlClient;
using Servidor.DB.DataSetV_LOGTableAdapters;

#endregion

namespace Servidor.DB
{
    public class ManejoDB
    {
        private static readonly string Server = CRatIniPropiedades.HostDB;
        private static readonly string Database = CRatIniPropiedades.DataBase;
        private static readonly string Uid = CRatIniPropiedades.UsuarioDB;
        private static readonly string Password = CRatIniPropiedades.PasswordDB;

        public static MySqlConnection ObtenerConexion()
        {
            string connectionString = string.Format("SERVER={0};DATABASE={1};UID={2};PASSWORD={3};", Server, Database,
                                                    Uid, Password);
            return new MySqlConnection(connectionString);
        }


        public static void InsertarNuevoCliente(string ip, string nombreUsuario, string nombrePC, string so, string vSo,
                                                string idioma)
        {
            string sqlQuery =
                string.Format(@"INSERT INTO Clientes
                  (DireccionIP,NombreUsuario,NombrePC,SistemaOperativo,VersionSO,Idioma)
                  VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')",
                              ip,
                              nombreUsuario,
                              nombrePC,
                              so,
                              vSo,
                              idioma
                    );

            EjecutarQueryAsincrona(sqlQuery, ObtenerConexion());
        }

        public static void InsertarAccion(string clienteDeLaAccion, NetData nd)
        {
            /*Acciones de las que se permite llevar el registro en la base de datos.
             *Son las acciones que realiza el usuario sobre los clientes.
             *Los codigos corresponde al codigo de Protocolo definido en Common.Libs.Protocolo
             *y al ID de la tabla Acciones de la DB.
             */
            int[] accionesHabilitadasParaGuardado =
                {
                    10, 11, 12, 13, 14, 20, 69, 80, 100, 101, 120, 121, 121, 130, 140,
                    141, 142, 209, 1000, 1001, 1002
                };
            if (Array.BinarySearch(accionesHabilitadasParaGuardado, nd.CodigoDeProtocolo) >= 0)
            {
                string query =
                    string.Format(
                        "INSERT INTO accion_cliente (ipCliente,idAccion,InformacionAdiccional,FechaAccion) VALUES ('{0}',{1},'{2}',NOW())",
                        clienteDeLaAccion, nd.CodigoDeProtocolo, "msjAdicional Test");
                MySqlConnection conn = ObtenerConexion();
                EjecutarQueryAsincrona(query, conn);
            }
        }

        /// <summary>
        ///     Devuelve el DataSet tipado con la Vista V_LOG de la base de datos.
        /// </summary>
        /// <returns></returns>
        public static DataSetV_LOG ObtenerLogAccionesDB()
        {
            try
            {
                DataSetV_LOG ds = new DataSetV_LOG();
                ds.EnforceConstraints = false;
                new v_logTableAdapter().Fill(ds.v_log);
                return ds;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Error al conectar con la base de datos MySQL");
            }
        }

        /// <summary>
        ///     Ejecuta la query pasada como parametro de forma Asincrona en un hilo independiente.     ///
        /// </summary>
        /// <param name="querySQL"></param>
        /// <param name="connection"></param>
        private static void EjecutarQueryAsincrona(string querySQL, MySqlConnection connection)
        {
            Thread t = new Thread(() => EjecutarQuery(querySQL,connection));
            t.Start();
        }

        /// <summary>
        ///     Inserta datos en la DB de forma automatica y asincrona, basandose en los datos que
        ///     contiene el NetData.
        ///     Se deduce el tipo de inserción que debe realizar en funcion del Protocolo que implementa
        ///     el NetData pasado como parametro, y obtiene los datos de la estructura diccionario que posee.
        /// </summary>
        /// <param name="nd"></param>
        public static void InsertarFromNetData(string destinatario, NetData nd)
        {
            switch (nd.CodigoDeProtocolo)
            {
                case (int) Protocolo.Cliente.Conectado:
                    InsertarNuevoCliente(destinatario,
                                         nd.GetDato("UsuarioLogeado"),
                                         nd.GetDato("NombrePc"),
                                         nd.GetDato("NombreSo"),
                                         nd.GetDato("VersionSo"),
                                         nd.GetDato("IdiomaSo"));
                    /* default:

                    break;*/
                    break;
                default:
                    InsertarAccion(destinatario, nd);
                    break;
            }
        }
        
        public static void EjecutarQuery(string querySQL, MySqlConnection connection)      
            {
                try
                {
                    MySqlCommand command = new MySqlCommand(querySQL, connection);
                    connection.Open();
                    IAsyncResult result = command.BeginExecuteNonQuery();
                    while (!result.IsCompleted)
                    {
                        Thread.Sleep(50);
                    }
                    command.EndExecuteNonQuery(result);
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (InvalidOperationException ex)
                {
                    throw ex;
                }
                catch (MySqlException ex)
                {
                    //Se captura en el caso de intentar guardar un cliente que ya esta en 
                    //la base de datos. Como no me interesa guardarlo, no hago nada.
                    if (ex.Message.IndexOf("PRIMARY", StringComparison.Ordinal) <= 0)
                        throw ex;
                }
            }            
        
    }
}