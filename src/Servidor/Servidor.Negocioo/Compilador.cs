#region

using System.CodeDom.Compiler;

#endregion

namespace Servidor.Negocio
{
    public class Compilador
    {
        /// <summary>
        ///     Compila el codigo fuente pasado como parametro.
        /// </summary>
        /// <param name="nombreExe"></param>
        /// <param name="codigoFuente"></param>
        /// <returns></returns>
        public static bool Compilar(string nombreExe, string codigoFuente)
        {
            CodeDomProvider compilador = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters parametros = new CompilerParameters();
            CompilerResults result;

            parametros.GenerateExecutable = true;
            parametros.OutputAssembly = nombreExe;
            parametros.ReferencedAssemblies.Add(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll");
            parametros.ReferencedAssemblies.Add(
                @"C:\Users\jjx001\Desktop\Proyecto RAT\4.Construccion\Cliente.Servicio\bin\Debug\Common.Lib.dll");
            parametros.ReferencedAssemblies.Add(
                @"C:\Users\jjx001\Desktop\Proyecto RAT\4.Construccion\Cliente.Servicio\bin\Debug\Cliente.Common.dll");
            parametros.ReferencedAssemblies.Add(
                @"C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System\v4.0_4.0.0.0__b77a5c561934e089\System.dll");
            parametros.ReferencedAssemblies.Add(
                @"C:\Users\jjx001\Desktop\Proyecto RAT\4.Construccion\Cliente.Servicio\bin\Debug\Cliente.Negocio.dll");
            parametros.ReferencedAssemblies.Add(
                @"C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Configuration\v4.0_4.0.0.0__b03f5f7f11d50a3a\System.Configuration.dll");
            parametros.ReferencedAssemblies.Add(
                @"C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Xml\v4.0_4.0.0.0__b77a5c561934e089\System.Xml.dll");
            parametros.ReferencedAssemblies.Add(
                @"C:\Windows\Microsoft.Net\assembly\GAC_MSIL\System.Core\v4.0_4.0.0.0__b77a5c561934e089\System.Core.dll");
            parametros.CompilerOptions = @" /target:winexe /win32icon:C:\Users\jjx001\Downloads\1366051311_28661.ico";
            parametros.TreatWarningsAsErrors = true;
            result = compilador.CompileAssemblyFromSource(parametros, codigoFuente);

            if (result.Errors.Count > 0)
                return false;
            return true;
        }
    }
}