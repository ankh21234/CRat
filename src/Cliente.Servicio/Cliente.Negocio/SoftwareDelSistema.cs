#region

using System;
using System.Collections.Generic;
using Cliente.Common;
using Common;
using Microsoft.Win32;

#endregion

public class SoftwareDelSistema
{
    public readonly List<SoftwareData> _programasInstalados = new List<SoftwareData>();

    public string Nombre
    {
        get
        {
            String nombres = "";
            bool firtLoop = true;
            foreach (SoftwareData soft in _programasInstalados)
            {
                if (firtLoop)
                {
                    firtLoop = false;
                }
                else
                {
                    nombres += Serializador.SeparadorDeCampo;
                }
                nombres += soft.Nombre;
            }
            return nombres;
        }
    }

    public string Version
    {
        get
        {
            String versions = "";
            bool firtLoop = true;
            foreach (SoftwareData soft in _programasInstalados)
            {
                if (firtLoop)
                {
                    firtLoop = false;
                }
                else
                {
                    versions += Serializador.SeparadorDeCampo;
                }
                versions += soft.Version;
            }
            return versions;
        }
    }

    public string Autor
    {
        get
        {
            String Autores = "";
            bool firtLoop = true;
            foreach (SoftwareData soft in _programasInstalados)
            {
                if (firtLoop)
                {
                    firtLoop = false;
                }
                else
                {
                    Autores += Serializador.SeparadorDeCampo;
                }
                Autores += soft.Autor;
            }
            return Autores;
        }
    }

    public string Url
    {
        get
        {
            String urls = "";
            bool firtLoop = true;
            foreach (SoftwareData soft in _programasInstalados)
            {
                if (firtLoop)
                {
                    firtLoop = false;
                }
                else
                {
                    urls += Serializador.SeparadorDeCampo;
                }
                urls += soft.Url;
            }
            return urls;
        }
    }





    public string FechaInstalacion
    {
        get
        {
            String FechasInst = "";
            bool firtLoop = true;
            foreach (SoftwareData soft in _programasInstalados)
            {
                if (firtLoop)
                {
                    firtLoop = false;
                }
                else
                {
                    FechasInst += Serializador.SeparadorDeCampo;
                }
                FechasInst += soft.FechaInstalacion;
            }
            return FechasInst;
        }
    }

  /*  public string StringDesinstalacion
    {
        get
        {
            String strUninstall = "";
            bool firtLoop = true;
            foreach (SoftwareData soft in _programasInstalados)
            {
                if (firtLoop)
                {
                    firtLoop = false;
                }
                else
                {
                    strUninstall += Serializador.SeparadorDeCampo;
                }
                strUninstall += soft.StringDesinstalacion;
            }
            return strUninstall;
        }
    }*/

    
    public static SoftwareDelSistema obtenerInstanciaSW()
    {
        SoftwareDelSistema softwareSO = new SoftwareDelSistema();

        string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
        {
            foreach (string subkey_name in key.GetSubKeyNames())
            {
                using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                {
                    if (subkey.GetValue("DisplayName") != null && subkey.GetValue("Publisher") != null &&
                        subkey.GetValue("DisplayVersion") != null && subkey.GetValue("InstallDate") != null &&
                        subkey.GetValue("URLInfoAbout") != null)
                    {
                        SoftwareData programaEncontrado = new SoftwareData();
                        programaEncontrado.Nombre = (string) subkey.GetValue("DisplayName");
                        programaEncontrado.Autor = (string) subkey.GetValue("Publisher");
                        programaEncontrado.Version = (string) subkey.GetValue("DisplayVersion");
                        programaEncontrado.Url = (string) subkey.GetValue("URLInfoAbout");
                        String fcAux = (String) subkey.GetValue("InstallDate");
                        programaEncontrado.FechaInstalacion =
                            new DateTime(int.Parse(fcAux.Substring(0, 4)), int.Parse(fcAux.Substring(4, 2)),
                                         int.Parse(fcAux.Substring(6, 2))).ToString("dd/MM/yyyy");
                      /*  if (subkey.GetValue("UninstallString") != null)
                            programaEncontrado.StringDesinstalacion = (string) subkey.GetValue("UninstallString");
                        else
                            programaEncontrado.StringDesinstalacion = "";  */                                                  
                        softwareSO._programasInstalados.Add(programaEncontrado);
                    }
                }
            }
        }
        return softwareSO;
    }
}