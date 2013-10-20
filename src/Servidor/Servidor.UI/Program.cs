#region

using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Servidor.DB;

#endregion

namespace Servidor.UI
{
    internal static class Program
    {
        /// <summary>
        ///     Punto de entrada principal para la aplicación Servidor.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            
            try
            {
                ManejoDB.ObtenerConexion().Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Imposible conectar con la base de datos MYSQL.\nComprueba la conexión.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new VPpal());
        }
    }
}