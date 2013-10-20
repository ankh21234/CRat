#region

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

#endregion

namespace Servidor.DB
{
    public class UsuarioDB
    {
        private readonly string _apellidos;
        private readonly string _email;
        private readonly DateTime _fechaRegistro;
        private readonly string _nombre;

        public UsuarioDB(string nombre, string apellidos, string email, DateTime fechaRegistro)
        {
            _nombre = nombre;
            _apellidos = apellidos;
            _email = email;
            _fechaRegistro = fechaRegistro;
        }

        public string Nombre
        {
            get { return _nombre; }
        }

        public string Apellidos
        {
            get { return _apellidos; }
        }

        public string Email
        {
            get { return _email; }
        }

        public DateTime FechaRegistro
        {
            get { return _fechaRegistro; }
        }

        /// <summary>
        ///     Genera un serial valido para el usuario, basado en su información
        ///     El formato del serial resultante será : XXXX-XXXX-XXXX-XXXX-XXXX-XXXX-XXXX
        ///     Solo hay un serial válido para los mismos datos de usuario.
        /// </summary>
        /// <returns></returns>
        public string generarSerialKeyValida()
        {
            String clave = Nombre.Reverse() + Apellidos.Substring(2) + Email.Split('@')[0] +
                           Email.Split('@')[1].Reverse();
            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] encodedBytes = md5.ComputeHash(Encoding.Default.GetBytes(clave));
            clave = Regex.Replace(BitConverter.ToString(encodedBytes).ToLower(), @"-", "");
            for (int i = clave.Length - 4; i >= 1; i -= 4)
            {
                clave = clave.Insert(i, "-");
            }
            return clave.ToUpper();
        }
    }
}