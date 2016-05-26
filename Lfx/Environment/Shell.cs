using System;
using System.Security.Permissions;

namespace Lfx.Environment
{
        /// <summary>
        /// Provee acceso al shell.
        /// </summary>
        public class Shell
        {
                [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
                public static void Execute(string command, string paramsIdent, System.Diagnostics.ProcessWindowStyle windowStyle, bool wait)
                {
                        System.Diagnostics.Process NuevoProceso = new System.Diagnostics.Process();
                        NuevoProceso.StartInfo = new System.Diagnostics.ProcessStartInfo(command, paramsIdent);
                        NuevoProceso.StartInfo.WindowStyle = windowStyle;
                        if (command.IndexOf(".exe", StringComparison.OrdinalIgnoreCase) < 0)
                                NuevoProceso.StartInfo.UseShellExecute = true;
                        else
                                NuevoProceso.StartInfo.UseShellExecute = false;
			NuevoProceso.Start();

                        if (wait)
                                NuevoProceso.WaitForExit();
                }


                [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
                public static void Reboot()
                {
                        if (Lfx.Workspace.Master != null) {
                                Lfx.Workspace.Master.Disposing = true;
                                Lfx.Workspace.Master.Dispose();
                        }

                        string[] ParametrosAPasar = System.Environment.GetCommandLineArgs();
                        ParametrosAPasar[0] = "";
                        string Params = string.Join(" ", ParametrosAPasar).Trim();

                        string ExeName;
                        if (System.IO.File.Exists(Lfx.Environment.Folders.ApplicationFolder + "ActualizadorLazaro.exe"))
                                ExeName = Lfx.Environment.Folders.ApplicationFolder + "ActualizadorLazaro.exe";
                        else
                                ExeName = Lfx.Environment.Folders.ApplicationFolder + "Lazaro.exe";

                        System.Diagnostics.Process NuevoProceso = new System.Diagnostics.Process();
                        if (Lfx.Environment.SystemInformation.RunTime == Lfx.Environment.SystemInformation.RunTimes.DotNet) {
                                NuevoProceso.StartInfo = new System.Diagnostics.ProcessStartInfo(ExeName, Params);
                        } else {
                                string MonoName = Lfx.Environment.SystemInformation.Platform == SystemInformation.Platforms.Windows ? "mono.exe" : "/usr/bin/mono";
                                NuevoProceso.StartInfo = new System.Diagnostics.ProcessStartInfo(MonoName, @"""" + ExeName + @""" " + Params);
                        }

                        NuevoProceso.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                        NuevoProceso.StartInfo.UseShellExecute = false;
                        NuevoProceso.Start();

                        System.Environment.Exit(0);
                }
        }
}
