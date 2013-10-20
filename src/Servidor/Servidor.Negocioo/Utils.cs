#region

using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Servidor.DB;

#endregion

namespace Servidor.Negocioo
{
    public class Utils
    {
        public static bool ValidarUrl(string url)

        {
            if (string.IsNullOrEmpty(url)) return false;
            if (!url.StartsWith("http://")) url = "http://" + url;
            Regex oRegExp = new Regex(@"(http|ftp|https)://([\w-]+\.)+(/[\w- ./?%&=]*)?", RegexOptions.IgnoreCase);
            return oRegExp.Match(url).Success;
        }

        public static bool EnviarMailConfirmacionCuenta(UsuarioDB user)
        {
            return true;
        }

        public static string cifrarMd5(string str)
        {
            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            Byte[] encodedBytes = md5.ComputeHash(Encoding.Default.GetBytes(str));
            return Regex.Replace(BitConverter.ToString(encodedBytes).ToLower(), @"-", "");
        }
    }
}