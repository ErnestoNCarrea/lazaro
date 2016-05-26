using System;
using Microsoft.Win32;

namespace Lazaro.Pres.Spreadsheet
{
        internal static class ExternalPrograms
        {
                internal static class OpenOffice
                {
                        internal static string GetPath()
                        {
                                // FIXME: versión Linux
                                string Res = null;
                                RegistryKey ProgKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OpenOffice.org\OpenOffice.org", false);
                                if (ProgKey != null) {

                                        foreach (string Version in ProgKey.GetSubKeyNames()) {
                                                RegistryKey ProgVersionKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\OpenOffice.org\OpenOffice.org\" + Version, false);
                                                if (ProgVersionKey != null && ProgVersionKey.GetValue("Path") != null) {
                                                        Res = System.IO.Path.GetDirectoryName(ProgVersionKey.GetValue("Path").ToString());
                                                        ProgVersionKey.Close();
                                                        break;
                                                }
                                                ProgVersionKey.Close();
                                        }
                                        ProgKey.Close();
                                        if (Res != null && Res.Substring(Res.Length - 1, 1) != System.IO.Path.DirectorySeparatorChar.ToString())
                                                Res += System.IO.Path.DirectorySeparatorChar;
                                }
                                return Res;
                        }

                        internal static bool IsCalcInstalled()
                        {
                                string SofficePath = GetPath();
                                if (SofficePath != null)
                                        return System.IO.File.Exists(SofficePath + "scalc.exe");
                                else
                                        return false;
                        }

                        internal static void PrintWithCalc(string fileName)
                        {
                                string SofficePath = GetPath();
                                if (SofficePath != null) {
                                        Lfx.Environment.Shell.Execute(SofficePath + "scalc.exe", @"-pt """ + fileName + @"""", System.Diagnostics.ProcessWindowStyle.Normal, false);
                                }
                        }
                }

                internal static class MsOffice
                {
                        internal static string GetPath()
                        {
                                if (Lfx.Environment.SystemInformation.Platform != Lfx.Environment.SystemInformation.Platforms.Windows)
                                        return null;

                                string Res = null;
                                RegistryKey ProgKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Office", false);
                                if (ProgKey != null) {

                                        foreach (string Version in ProgKey.GetSubKeyNames()) {
                                                RegistryKey ProgVersionKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Office\" + Version + @"\Excel\InstallRoot", false);
                                                if (ProgVersionKey != null) {
                                                        if (ProgVersionKey.GetValue("Path") != null) {
                                                                Res = System.IO.Path.GetDirectoryName(ProgVersionKey.GetValue("Path").ToString());
                                                                ProgVersionKey.Close();
                                                                break;
                                                        }
                                                        ProgVersionKey.Close();
                                                }
                                        }
                                        ProgKey.Close();
                                        if (Res != null && Res.Substring(Res.Length - 1, 1) != System.IO.Path.DirectorySeparatorChar.ToString())
                                                Res += System.IO.Path.DirectorySeparatorChar;
                                }
                                return Res;
                        }

                        internal static bool IsExcelInstalled()
                        {
                                string OfficePath = GetPath();
                                if (OfficePath != null)
                                        return System.IO.File.Exists(OfficePath + "excel.exe");
                                else
                                        return false;
                        }

                        internal static void PrintWithExcel(string fileName)
                        {
                                string OfficePath = GetPath();
                                if (OfficePath != null) {
                                        Lfx.Environment.Shell.Execute(OfficePath + "excel.exe", @"/e """ + fileName + @"""", System.Diagnostics.ProcessWindowStyle.Normal, false);
                                }
                        }
                }
        }
}
