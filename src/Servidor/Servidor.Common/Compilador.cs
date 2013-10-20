#region

using System.CodeDom.Compiler;

#endregion

namespace Servidor.Negocioo
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
            parametros.ReferencedAssemblies.Add("System.dll");
            parametros.CompilerOptions = " /target:winexe";
            parametros.TreatWarningsAsErrors = false;

            result = compilador.CompileAssemblyFromSource(parametros, codigoFuente);

            if (result.Errors.Count > 0)
                return false;
            return true;
        }
    }
}