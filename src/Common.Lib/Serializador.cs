#region

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

#endregion

namespace Common
{
    public class Serializador
    {
        public static char SeparadorDeCampo = '╣'; //usado en objetos con colecciones internas.

        /// <summary>
        /// Devuelve un array de string con los registros del string pasado como parametro.
        /// Estos registros, se obtienen de las propiedades de los objetos
        /// que los necesiten y se guardan dentro de la estructura de diccionario NetData.
        /// </summary>
        /// <param name="strRegistros"></param>
        /// <returns></returns>
        public static String[] DeserializarRegistro(String strRegistros)
        {
            return strRegistros.Split(SeparadorDeCampo);
        }
        /// <summary>
        ///     Rcupera el objeto representado por el array de bytes.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static Object Deserializar(byte[] bytes)
        {
            BinaryFormatter bin = new BinaryFormatter();

            MemoryStream mem = new MemoryStream(bytes);
            return bin.Deserialize(mem);
        }

        /// <summary>
        ///     Transforma el objeto pasado a bytes.
        /// </summary>
        /// <param name="objSerializable"></param>
        /// <returns></returns>
        public static byte[] Serializar(Object objSerializable)
        {
            /*BinaryFormatter bin = new BinaryFormatter();
            MemoryStream mem = new MemoryStream(32768);
            bin.Serialize(mem, objSerializable);
            
            return mem.GetBuffer();*/
            byte[] bytesObj;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, objSerializable);
                bytesObj = memoryStream.ToArray();                
            }
            return bytesObj;
        }
    }
}