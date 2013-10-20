#region

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Cliente.Common;
using Common;

#endregion

namespace Cliente.Negocio
{
    public class InformacionVentanasSO    
    {
        private static readonly List<VentanaData> _ventanas = new List<VentanaData>();
        
        public InformacionVentanasSO()
        {
            _ventanas.Clear();
            EnumWindows(ObtenerVentanasSO, 0);
        }

        public String Handle
        {
            get
            {
                String handleStr = "";
                bool firtLoop = true;
                foreach (VentanaData ventanaData in _ventanas)
                {
                    if (firtLoop)
                    {
                        firtLoop = false;
                    }
                    else
                    {
                        handleStr += Serializador.SeparadorDeCampo;
                    }
                    handleStr += ventanaData.Handle;
                }
                return handleStr;
            }
        }

        public String Titulo
        {
            get
            {
                String titulos = "";
                bool firtLoop = true;
                foreach (VentanaData ventanaData in _ventanas)
                {
                    if (firtLoop)
                    {
                        firtLoop = false;
                    }
                    else
                    {
                        titulos += Serializador.SeparadorDeCampo;
                    }
                    titulos += ventanaData.Titulo;
                }
                return titulos;
            }
        }

        public String Habilitada
        {
            get
            {
                String habilitada = "";
                bool firtLoop = true;
                foreach (VentanaData ventanaData in _ventanas)
                {
                    if (firtLoop)
                    {
                        firtLoop = false;
                    }
                    else
                    {
                        habilitada += Serializador.SeparadorDeCampo;
                    }
                    habilitada += ventanaData.Habilitada;
                }
                return habilitada;
            }            
        }


        /// <summary>
        ///     Metodo que se llamará como delegado en el metodo EnumWindows.
        ///     Recoge los manejadores y informacion de la ventana en las estructuras de datos
        ///     VentanaData.
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="parametro"></param>
        /// <returns></returns>
        private static bool ObtenerVentanasSO(IntPtr hWnd, int parametro)
        {
            StringBuilder titulo = new StringBuilder(new string(' ', 256));
            int ret;
            string nombreVentana;
            
            ret = GetWindowText(hWnd, titulo, titulo.Length);
            if (ret == 0) return true;
            
            nombreVentana = titulo.ToString().Substring(0, ret);            
            if (nombreVentana != null && nombreVentana.Length > 0)
            {
                if (IsWindowVisible(hWnd))
                {
                    _ventanas.Add(new VentanaData(hWnd, nombreVentana,IsWindowEnabled(hWnd)));
                }
            }
            return true;
        }

        //
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsDelegate lpfn, int lParam);

        //
        [DllImport("user32.dll")]
        private static extern int EnumChildWindows(IntPtr hWndParent, EnumWindowsDelegate lpEnumFunc, int lParam);

        //
        //
        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int cch);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(IntPtr hwnd, String lpString);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowEnabled(IntPtr hWnd);

        private delegate bool EnumWindowsDelegate(IntPtr hWnd, int parametro);
    }
}