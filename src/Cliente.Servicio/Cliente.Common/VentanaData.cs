using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Cliente.Common
{
    public class VentanaData
    {
        private IntPtr _handle;
        private String _titulo;
        private Boolean _habilitada;

        public VentanaData(IntPtr handle, string titulo, bool habilitada)
        {
            _handle = handle;
            _titulo = titulo;
            _habilitada = habilitada;
        }

        public VentanaData(IntPtr handle)
        {
            _handle = handle;
        }

        public IntPtr Handle
        {
            get { return _handle; }
        }

        public string Titulo
        {
            get { return _titulo; }
        }

        public String Habilitada
        {
            get { return (_habilitada) ? "SI" : "NO"; }
        }

        public void MinimizarVentana()
        {
            CloseWindow(_handle);
        }
        public void BloquearVentana()
        {
            EnableWindow(_handle, false);
        }
        public void DesbloquearVentana()
        {
            EnableWindow(_handle, true);
        }
       

        public void CambiarTituloVentana(String nuevoTitulo)
        {
            SetWindowText(_handle, nuevoTitulo);
        }

        public static void MinimizarVentanaByHandle(IntPtr handle)
        {
            new VentanaData(handle).MinimizarVentana();
        }

        public static void BloquearVentanaByHandle(IntPtr handle)
        {
            new VentanaData(handle).BloquearVentana();
        }

        public static void DesbloquearVentanaByHandle(IntPtr handle)
        {
            new VentanaData(handle).DesbloquearVentana();
        }

        public static void CambiarTituloVentanaByHandle(IntPtr handle,String nuevoTitulo)
        {
            new VentanaData(handle).CambiarTituloVentana(nuevoTitulo);
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int CloseWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnableWindow(IntPtr hWnd, bool bEnable);


        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(IntPtr hwnd, String lpString);
    }


}
