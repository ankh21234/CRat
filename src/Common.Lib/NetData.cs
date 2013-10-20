#region

using System;
using System.Collections.Generic;
using System.Reflection;

#endregion

namespace Common.Lib
{
    /// <summary>
    ///     Estructura basica de un dato enviado por la red. Representado por un codigo de protocolo
    ///     y un mapa de valores  ['clave' ==> 'valor' ].
    /// </summary>
    [Serializable]
    public class NetData
    {
        /// <summary>
        ///     Mapa de datos enviado.
        /// </summary>
        private readonly Dictionary<string, string> _datos;

        /// <summary>
        ///     Representa el codigo del mensaje enviado. Entendido por el protocolo de la aplicación.
        /// </summary>
        private int _codigoDeProtocolo;

        public NetData(int codigoDeProtocolo)
        {
            _codigoDeProtocolo = codigoDeProtocolo;
            _datos = new Dictionary<string, string>();
        }

        public int CodigoDeProtocolo
        {
            get { return _codigoDeProtocolo; }
            set { _codigoDeProtocolo = value; }
        }

        /// <summary>
        ///     Recupera el dato asignado a la clave pasada como parametro.
        /// </summary>
        /// <param name="clave"></param>
        /// <returns></returns>
        public String GetDato(String clave)
        {
            return _datos[clave];
        }

        /// <summary>
        ///     Añade un nuevo dato al mapa de datos.
        /// </summary>
        /// <param name="clave"></param>
        /// <param name="valor"></param>
        public void AddDato(String clave, String valor)
        {
            _datos.Add(clave, valor);
        }

        /// <summary>
        ///     Obtiene las claves disponibles en el mapa de datos.
        /// </summary>
        /// <returns></returns>
        public List<string> getClaves()
        {
            List<string> claves = new List<string>();
            foreach (string s in _datos.Keys)
            {
                claves.Add(s);
            }
            return claves;
        }

        /// <summary>
        ///     Genera un objeto del tipo NetData a partir de otro objeto cualquiera
        ///     basandose en sus propiedades (getters)
        ///     mediante reflexion.
        /// </summary>
        /// <param name="msgCode"></param>
        /// Codigo del protocolo para el NEtData.
        /// <param name="obj"></param>
        /// Fuente de propiedades.
        /// <returns></returns>
        public static NetData GenerarNetDataDesdeObjeto(int msgCode, Object obj)

        {
            NetData datoDeRed = new NetData(msgCode);
            Type clase = obj.GetType();
            foreach (PropertyInfo campo in clase.GetProperties())
            {
                datoDeRed.AddDato(campo.Name, campo.GetValue(obj, null).ToString());
            }
            return datoDeRed;
        }

        public static NetData RespuestaOk(String msg)
        {
            NetData ndSuccess = new NetData((int) Protocolo.Cliente.RespuestaSuccess);
            ndSuccess.AddDato("Mensaje", msg);
            return ndSuccess;
        }

        public static NetData RespuestaError(String msg)
        {
            NetData ndError = new NetData((int) Protocolo.Cliente.RespuestaError);
            ndError.AddDato("Mensaje", msg);
            return ndError;
        }

        public static NetData RespuestaOk()
        {
            return RespuestaOk("");
        }

        public static NetData RespuestaError()
        {
            return RespuestaError("");
        }
    }
}