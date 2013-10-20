#region

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Cliente.Common;
using Common;

#endregion

namespace Cliente.Negocio
{
    internal class ProcesosDelSistema
    {
        private readonly List<ProcessData> procesos = new List<ProcessData>();

        public String Id
        {
            get
            {
                String id = "";
                bool firtLoop = true;
                foreach (ProcessData proceso in procesos)
                {
                    if (firtLoop)
                    {
                        firtLoop = false;
                    }
                    else
                    {
                        id += Serializador.SeparadorDeCampo;
                    }
                    id += proceso.Id;
                }
                return id;
            }
        }

        public String Nombre
        {
            get
            {
                String nombres = "";
                bool firtLoop = true;
                foreach (ProcessData proceso in procesos)
                {
                    if (firtLoop)
                    {
                        firtLoop = false;
                    }
                    else
                    {
                        nombres += Serializador.SeparadorDeCampo;
                    }
                    nombres += proceso.Nombre;
                }
                return nombres;
            }
        }

        public String VentanaAsociada
        {
            get
            {
                String ventanaAsociada = "";
                bool firtLoop = true;
                foreach (ProcessData proceso in procesos)
                {
                    if (firtLoop)
                    {
                        firtLoop = false;
                    }
                    else
                    {
                        ventanaAsociada += Serializador.SeparadorDeCampo;
                    }
                    ventanaAsociada += proceso.VentanaAsociada;
                }
                return ventanaAsociada;
            }
        }

        public static ProcesosDelSistema generarInstanciaProcesos()
        {
            ProcesosDelSistema procesosDelSistema = new ProcesosDelSistema();
            Process[] procs = Process.GetProcesses();
            foreach (Process pr in procs)
            {
                ProcessData proceso = new ProcessData("" + pr.Id, pr.ProcessName, pr.MainWindowTitle);
                procesosDelSistema.procesos.Add(proceso);
            }
            return procesosDelSistema;
        }

        public static void IniciarProceso(string proceso,Boolean oculto)
        {
            ProcessData.IniciarProceso(proceso,oculto);
        }
        public static void MatarProceso(string id)
        {
            ProcessData.MatarProceso(id);
        }
    }
}