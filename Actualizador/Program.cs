// Copyright 2004-2009 Carrea Ernesto N.
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
// Este programa es software libre; puede distribuirlo y/o moficiarlo de
// acuerdo a los términos de la Licencia Pública General de GNU (GNU
// General Public License), como la publica la Fundación para el Software
// Libre (Free Software Foundation), tanto la versión 3 de la Licencia
// como (a su elección) cualquier versión posterior.
//
// Este programa se distribuye con la esperanza de que sea útil, pero SIN
// GARANTÍA ALGUNA; ni siquiera la garantía MERCANTIL implícita y sin
// garantizar su CONVENIENCIA PARA UN PROPÓSITO PARTICULAR. Véase la
// Licencia Pública General de GNU para más detalles. 
//
// Debería haber recibido una copia de la Licencia Pública General junto
// con este programa. Si no ha sido así, vea <http://www.gnu.org/licenses/>.

using System;
using System.Net.Mail;
using System.Collections.Generic;

namespace Cargador
{
        static class Program
        {
                private static bool Portable = false;

                /// <summary>
                /// Punto de entrada principal para la aplicación.
                /// </summary>
                static void Main()
                {
                        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionHandler);

                        if (System.IO.File.Exists(ApplicationFolder + "portable.lwf"))
                                Portable = true;

                        string CarpetaTrabajo = ApplicationFolder;
                        if (System.IO.Directory.Exists(CarpetaTrabajo) == false)
                                System.IO.Directory.CreateDirectory(CarpetaTrabajo);

                        string CarpetaDescarga = ApplicationDataFolder + "Updates" + System.IO.Path.DirectorySeparatorChar;
                        if (System.IO.Directory.Exists(CarpetaDescarga) == false)
                                System.IO.Directory.CreateDirectory(CarpetaDescarga);

                        string[] ArchivosNuevos = System.IO.Directory.GetFiles(CarpetaDescarga, "*.new", System.IO.SearchOption.AllDirectories);
                        if (ArchivosNuevos.Length > 0) {
                                if (IsUacActive && IsAdministrator == false && FolderWritable(CarpetaTrabajo) == false) {
                                        System.Console.WriteLine("Ejecutando como Administrador.");
                                        try {
                                                Elevate();
                                        } catch {
                                                // No se pudo elevar. Se va a ejecutar Lázaro sin privilegios.
                                                EjecutarLazaro("/ignoreupdates");
                                        }
                                        return;
                                } else {
                                        System.Console.WriteLine("Se van a actualizar " + ArchivosNuevos.Length.ToString() + " archivos.");
                                }
                        }


                        foreach (string ArchivoNuevo in ArchivosNuevos) {
                                if (ArchivoNuevo.Length > 4) {
                                        System.Console.WriteLine("Actualizando " + ArchivoNuevo);
                                        string NombreFinal = CarpetaTrabajo + ArchivoNuevo.Substring(CarpetaDescarga.Length, ArchivoNuevo.Length - CarpetaDescarga.Length - 4);

                                        // Si existe, lo renombro bak
                                        if (System.IO.File.Exists(NombreFinal)) {
                                                // Si existe un bak, lo borro
                                                if (System.IO.File.Exists(NombreFinal + ".bak"))
                                                        System.IO.File.Delete(NombreFinal + ".bak");
                                                // Y renombro el viejo
                                                try {
                                                        System.IO.File.Move(NombreFinal, NombreFinal + ".bak");
                                                } catch {
                                                        // No pude renombrar a .bak
                                                }
                                        }

                                        // Y ahora renombro el nuevo a .bak
                                        System.Console.WriteLine(" en " + NombreFinal);

                                        try {
                                                string CarpetaDestino = System.IO.Path.GetDirectoryName(NombreFinal);
                                                if (System.IO.Directory.Exists(CarpetaDestino) == false)
                                                        System.IO.Directory.CreateDirectory(CarpetaDestino);
                                        } catch {
                                        }

                                        int Intentos = 3;
                                        while (Intentos-- > 0) {
                                                try {
                                                        System.IO.File.Move(ArchivoNuevo, NombreFinal);
                                                        break;
                                                } catch {
                                                        System.Console.WriteLine("No se puede mover " + NombreFinal);
                                                        System.Threading.Thread.Sleep(1000);
                                                }
                                        }
                                } else {
                                        System.Console.WriteLine("Ignorando " + ArchivoNuevo);
                                }
                        }

                        if (Portable == false && Platform == Platforms.Windows) {
                                try {
                                        ActualizarDatosDeDesinstalacion();
                                } catch {
                                        // Nada
                                }
                        }

                        
                        EjecutarLazaro(null);
                }


                private static void ActualizarDatosDeDesinstalacion()
                {
                        /* string[] DatosDesins = System.IO.Directory.GetFiles(ApplicationFolder, "unins0*.dat");
                        foreach (string DatosDesin in DatosDesins) {
                                using (System.IO.FileStream Fs = new System.IO.FileStream(DatosDesin, System.IO.FileMode.Open))
                                using (System.IO.BinaryWriter Br = new System.IO.BinaryWriter(Fs)) {
                                        Br.Seek(64, System.IO.SeekOrigin.Begin);
                                        Br.Write(System.Text.Encoding.Default.GetBytes("{676653C6-5655-45DD-96F6-CFBB0EC6B5B0}"));
                                }
                        }

                        // Lo mismo, pero con el desinstalador de MySQL
                        DatosDesins = System.IO.Directory.GetFiles(@"C:\mysql", "unins0*.dat");
                        foreach (string DatosDesin in DatosDesins) {
                                using (System.IO.FileStream Fs = new System.IO.FileStream(DatosDesin, System.IO.FileMode.Open))
                                using (System.IO.BinaryWriter Br = new System.IO.BinaryWriter(Fs)) {
                                        Br.Seek(64, System.IO.SeekOrigin.Begin);
                                        Br.Write(System.Text.Encoding.Default.GetBytes("{B664C9CC-F8CB-405D-830D-30EA1D3809BA}"));
                                }
                        } */

                        // El instalador ha cambiado de nombre en varias ocasiones
                        // Además, el nombre que se muestra puede ser viejo
                        using (Microsoft.Win32.RegistryKey SeccionUninstall = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", true)) {
                                if (SeccionUninstall == null)
                                        return;

                                string[] ProgramasInstalados = SeccionUninstall.GetSubKeyNames();

                                Dictionary<string, string> SearchAndReplace = new Dictionary<string, string>() 
                                {
                                        { @"Servidor MySQL_is1", @"B664C9CC-F8CB-405D-830D-30EA1D3809BA_is1" },
                                        { @"Lázaro_is1", @"676653C6-5655-45DD-96F6-CFBB0EC6B5B0_is1" },
                                        { @"Sistema Lázaro_is1", @"676653C6-5655-45DD-96F6-CFBB0EC6B5B0_is1" },
                                        { @"Lázaro 1.0_is1", @"676653C6-5655-45DD-96F6-CFBB0EC6B5B0_is1" },
                                        { @"Lázaro 2011_is1", @"676653C6-5655-45DD-96F6-CFBB0EC6B5B0_is1" },
                                        { @"Lázaro 2012_is1", @"676653C6-5655-45DD-96F6-CFBB0EC6B5B0_is1" }
                                };

                                foreach (string Programa in ProgramasInstalados) {
                                        if (SearchAndReplace.ContainsKey(Programa)) {
                                                string NuevoNombre = SearchAndReplace[Programa];
                                                RenameSubKey(SeccionUninstall, Programa, NuevoNombre);
                                        }
                                }
                        }

                        try {
                                Microsoft.Win32.Registry.LocalMachine.SetValue(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\676653C6-5655-45DD-96F6-CFBB0EC6B5B0_is1\DisplayName", "Lázaro 2012");
                        } catch {
                                // Nada
                        }
                }


                public static bool FolderWritable(string folder)
                {
                        try {
                                string FileName = new Random().Next(1000000, 9999999).ToString();
                                using (System.IO.Stream Str = System.IO.File.Create(folder + FileName)) {
                                        Str.Close();
                                }
                                System.IO.File.Delete(folder + FileName);
                                return true;
                        } catch {
                                return false;
                        }
                }


                public static void RenameSubKey(Microsoft.Win32.RegistryKey parentKey, string subKeyName, string newSubKeyName)
                {
                        using (Microsoft.Win32.RegistryKey Src = parentKey.OpenSubKey(subKeyName, false))
                        using (Microsoft.Win32.RegistryKey Dest = parentKey.CreateSubKey(newSubKeyName)) {
                                CopyKeyRecursive(Src, Dest);
                        }
                        parentKey.DeleteSubKeyTree(subKeyName);
                }


                private static void CopyKeyRecursive(Microsoft.Win32.RegistryKey sourceKey, Microsoft.Win32.RegistryKey destKey)
                {
                        foreach (string ValueName in sourceKey.GetValueNames()) {
                                object Val = sourceKey.GetValue(ValueName);
                                destKey.SetValue(ValueName, Val, sourceKey.GetValueKind(ValueName));
                        }

                        foreach (string SubKeyName in sourceKey.GetSubKeyNames()) {
                                using (Microsoft.Win32.RegistryKey sourceSubKey = sourceKey.OpenSubKey(SubKeyName, false))
                                using (Microsoft.Win32.RegistryKey destSubKey = destKey.CreateSubKey(SubKeyName)) {
                                        CopyKeyRecursive(sourceSubKey, destSubKey);
                                }
                        }
                }


                public static void EjecutarLazaro(string extraParams)
                {
                        string[] ParametrosAPasar = System.Environment.GetCommandLineArgs();
                        ParametrosAPasar[0] = "";
                        string Params = string.Join(" ", ParametrosAPasar).Trim();
                        if (extraParams != null)
                                Params += " " + extraParams;
                        string ExeName = "Lazaro.exe";

                        System.Console.WriteLine("Ejecutando " + ExeName);

                        System.Diagnostics.Process NuevoProceso = new System.Diagnostics.Process();
                        if (RunTime == RunTimes.DotNet) {
                                NuevoProceso.StartInfo = new System.Diagnostics.ProcessStartInfo(ExeName, Params);
                        } else {
                                string MonoName = Platform == Platforms.Windows ? "mono.exe" : "/usr/bin/mono";
                                NuevoProceso.StartInfo = new System.Diagnostics.ProcessStartInfo(MonoName, @"""" + ExeName + @""" " + Params);
                        }

                        NuevoProceso.StartInfo.UseShellExecute = false;
                        NuevoProceso.Start();

                        System.Environment.Exit(0);
                }

                public static void Elevate()
                {
                        string[] ParametrosAPasar = System.Environment.GetCommandLineArgs();
                        ParametrosAPasar[0] = "";
                        string Params = string.Join(" ", ParametrosAPasar).Trim();
                        string ExeName = "ActualizadorLazaro.exe";

                        System.Diagnostics.Process NuevoProceso = new System.Diagnostics.Process();
                        if (RunTime == RunTimes.DotNet) {
                                NuevoProceso.StartInfo = new System.Diagnostics.ProcessStartInfo(ExeName, Params);
                        } else {
                                string MonoName = Platform == Platforms.Windows ? "mono.exe" : "/usr/bin/mono";
                                NuevoProceso.StartInfo = new System.Diagnostics.ProcessStartInfo(MonoName, @"""" + ExeName + @""" " + Params);
                        }

                        NuevoProceso.StartInfo.UseShellExecute = true;
                        NuevoProceso.StartInfo.Verb = "runas";
                        NuevoProceso.Start();

                        System.Environment.Exit(0);
                }

                public static string ApplicationFolder
                {
                        get
                        {
                                string Result = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                                if (Result[Result.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                                        Result += System.IO.Path.DirectorySeparatorChar;
                                return Result;
                        }
                }

                public static string ApplicationDataFolder
                {
                        get
                        {
                                if (Portable)
                                        return ApplicationFolder;

                                string CompletePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData)
                                        + System.IO.Path.DirectorySeparatorChar + "Lazaro" + System.IO.Path.DirectorySeparatorChar;
                                if (!System.IO.Directory.Exists(CompletePath))
                                        System.IO.Directory.CreateDirectory(CompletePath);
                                return CompletePath;
                        }
                }

                public enum RunTimes
                {
                        DotNet,
                        Mono
                }

                public static RunTimes RunTime
                {
                        get
                        {
                                if (Type.GetType("Mono.Runtime") != null)
                                        return RunTimes.Mono;
                                else
                                        return RunTimes.DotNet;
                        }
                }

                public enum Platforms
                {
                        Windows,
                        Unix,
                        Other
                }

                public static Platforms Platform
                {
                        get
                        {
                                if (System.Environment.OSVersion.Platform == PlatformID.Win32NT || System.Environment.OSVersion.Platform == PlatformID.Win32Windows)
                                        return Platforms.Windows;
                                else if ((int)System.Environment.OSVersion.Platform == 4 || (int)System.Environment.OSVersion.Platform == 128)
                                        return Platforms.Unix;
                                else
                                        return Platforms.Other;
                        }
                }

                public static bool IsUacActive
                {
                        get
                        {
                                if (Platform == Platforms.Windows) {
                                        // Es Windows
                                        if (System.Environment.OSVersion.Version.Major >= 6) {
                                                // Es Windows Vista o superior
                                                int Uac = System.Convert.ToInt32(Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System", "EnableLUA", 0));
                                                return Uac != 0;
                                        } else {
                                                return false;
                                        }
                                } else {
                                        return false;
                                }
                        }
                }

                private static bool IsAdministrator
                {
                        get
                        {
                                System.Security.Principal.WindowsIdentity wi = System.Security.Principal.WindowsIdentity.GetCurrent();
                                System.Security.Principal.WindowsPrincipal wp = new System.Security.Principal.WindowsPrincipal(wi);

                                return wp.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
                        }
                }

                private static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs args)
                {
                        ExceptionHandler(args.ExceptionObject as Exception);
                }

                public static void ExceptionHandler(Exception ex)
                {
                        System.Text.StringBuilder Texto = new System.Text.StringBuilder();
                        Texto.AppendLine("Lugar   : " + ex.Source);
                        try {
                                System.Diagnostics.StackTrace Traza = new System.Diagnostics.StackTrace(ex, true);
                                Texto.AppendLine("Línea   : " + Traza.GetFrame(0).GetFileLineNumber());
                                Texto.AppendLine("Columna : " + Traza.GetFrame(0).GetFileColumnNumber());
                        }
                        catch {
                                //Nada
                        }
                        Texto.AppendLine("Equipo  : " + System.Environment.MachineName);
                        Texto.AppendLine("Excepción no controlada: " + ex.ToString());
                        Texto.AppendLine("");

                        Texto.AppendLine("Traza:");
                        Texto.AppendLine(ex.StackTrace);

                        MailMessage Mensaje = new MailMessage();
                        Mensaje.To.Add(new MailAddress("error@sistemalazaro.com.ar"));
                        Mensaje.From = new MailAddress("actualizador@sistemalazaro.com.ar");
                        try {
                                //No sé por qué, pero una vez dió un error al poner el asunto
                                Mensaje.Subject = ex.Message;
                        }
                        catch {
                                Mensaje.Subject = "Excepción no controlada";
                                Texto.Insert(0, ex.Message + System.Environment.NewLine);
                        }

                        Mensaje.Body = Texto.ToString();

                        SmtpClient Cliente = new SmtpClient("mail.sistemalazaro.com.ar");
                        try {
                                Cliente.Send(Mensaje);
                        }
                        catch {
                                // Nada
                        }
                }
        }
}
