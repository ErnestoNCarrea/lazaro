using System;
using System.Collections.Generic;
using System.Net;

namespace Lfx.Updates
{
        public class Package
        {
                public Updater Updater { get; set; }

                public string Name { get; set; }

                /// <summary>
                /// Ruta de destino relativa a la ruta del actualizador.
                /// </summary>
                public string RelativePath { get; set; }
                public string Url { get; set; }

                public FileCollection Files;

                internal void DownloadUpdatesInformation()
                {
                        this.Updater.Progress.ChangeStatus("Descargando información de versiones de " + this.Name);

                        if (this.Files == null)
                                this.Files = new FileCollection();

                        try {
                                using (WebClient Cliente = new WebClient()) {
                                        Cliente.Encoding = System.Text.Encoding.UTF8;
                                        string VerFileUrl = this.GetFullUrl() + this.Name + ".ver";
                                        byte[] VersionInfo = Cliente.DownloadData(VerFileUrl + "?dm=" + new Random().Next().ToString());

                                        System.Xml.XmlDocument ArchivoVer = new System.Xml.XmlDocument();
                                        System.IO.MemoryStream ms = new System.IO.MemoryStream(VersionInfo);
                                        ArchivoVer.Load(ms);

                                        System.Xml.XmlNodeList PackageList = ArchivoVer.GetElementsByTagName("Package");
                                        foreach (System.Xml.XmlNode Pkg in PackageList) {
                                                string PkgName = Pkg.Attributes["name"].Value;
                                                System.Xml.XmlNode Comp = ArchivoVer.SelectSingleNode("/VersionInfo/Package[@name='" + PkgName + "']");
                                                foreach (System.Xml.XmlNode FileVers in Comp.ChildNodes) {
                                                        if (FileVers.Name == "File") {
                                                                if (FileVers.Attributes["name"] != null && FileVers.Attributes["name"].Value != null) {
                                                                        File FileVersionInfo;
                                                                        string FileName = FileVers.Attributes["name"].Value;
                                                                        if (this.Files.ContainsKey(FileName)) {
                                                                                // Ya existe en la lista de archivos
                                                                                FileVersionInfo = this.Files[FileName];
                                                                        } else {
                                                                                // Lo agrego
                                                                                FileVersionInfo = new File(this);
                                                                                this.Files.Add(FileVersionInfo);
                                                                        }
                                                                        FileVersionInfo.Name = FileName;
                                                                        DateTime Fecha;
                                                                        try {
                                                                                DateTime.TryParseExact(FileVers.Attributes["version"].Value, Lfx.Types.Formatting.DateTime.SqlDateTimeFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal | System.Globalization.DateTimeStyles.AllowWhiteSpaces, out Fecha);
                                                                                
                                                                        } catch {
                                                                                Fecha = DateTime.MinValue;
                                                                        }
                                                                        FileVersionInfo.NewVersion = Fecha;
                                                                        
                                                                        if (FileVers.Attributes["compression"] != null && FileVers.Attributes["compression"].Value != null) {
                                                                                switch(FileVers.Attributes["compression"].Value) {
                                                                                        case "none":
                                                                                        case "":
                                                                                                FileVersionInfo.Compression = CompressionFormats.None;
                                                                                                break;
                                                                                        case "bz2":
                                                                                                FileVersionInfo.Compression = CompressionFormats.Bz2;
                                                                                                break;
                                                                                        default:
                                                                                                FileVersionInfo.Compression = CompressionFormats.OtherUnsupported;
                                                                                                break;
                                                                                }
                                                                        }
                                                                        if (FileVers.Attributes["size"] != null && FileVers.Attributes["size"].Value != null)
                                                                                FileVersionInfo.NewSize = int.Parse(FileVers.Attributes["size"].Value);
                                                                        if (FileVers.Attributes["compsize"] != null && FileVers.Attributes["compsize"].Value != null)
                                                                                FileVersionInfo.NewCompSize = int.Parse(FileVers.Attributes["compsize"].Value);
                                                                }
                                                        }
                                                }
                                        }
                                }
                        } catch (Exception ex) {
                                // No pude descargar
                                System.Console.WriteLine("Updater: " + ex.Message);
                        }
                }


                public string GetFullUrl()
                {
                        return string.Format(this.Url, this.Updater.Channel);
                }


                public string GetFullPath()
                {
                        return System.IO.Path.Combine(this.Updater.Path, this.RelativePath);
                }

                public string GetFullTempPath()
                {
                        return System.IO.Path.Combine(this.Updater.TempPath, this.RelativePath);
                }


                public int GetNewFileCount()
                {
                        if (this.Files == null)
                                return 0;

                        int Res = 0;
                        foreach (File Fil in this.Files) {
                                if (Fil.HasNewVersion())
                                        Res++;
                        }

                        return Res;
                }


                public int GetDownloadedFileCount()
                {
                        if (this.Files == null)
                                return 0;

                        int Res = 0;
                        foreach (File Fil in this.Files) {
                                if (Fil.HasNewVersion() && Fil.IsDownloaded)
                                        Res++;
                        }

                        return Res;
                }


                public void DownloadNewFiles()
                {
                        this.Updater.Progress.ChangeStatus("Descargando archivos nuevos de " + this.Name);
                        if (this.Files == null)
                                return;

                        foreach (File Fil in this.Files) {
                                if (Fil.HasNewVersion() && Fil.IsDownloaded == false) {
                                        Fil.Download();
                                        this.Updater.Progress.Value = this.Updater.GetDownloadedSize();
                                }
                        }
                }


                public bool UpdatesReady()
                {
                        return this.GetNewFileCount() > 0 && this.GetDownloadedFileCount() == this.GetNewFileCount();
                }


                public bool UpdatesPending()
                {
                        if (this.Files == null)
                                return false;

                        foreach (File Fil in this.Files) {
                                if (Fil.UpdatePending)
                                        return true;
                        }

                        return false;
                }



                public void ApplyUpdates()
                {
                        this.Updater.Progress.ChangeStatus("Aplicando actualizaciones de " + this.Name);

                        if (this.Files == null)
                                return;

                        foreach (File Fil in this.Files) {
                                if (Fil.HasNewVersion() && Fil.IsDownloaded)
                                        Fil.ApplyUpdates();
                        }
                }


                public int GetDownloadSize()
                {
                        if (this.Files == null)
                                return 0;

                        int Res = 0;
                        foreach (File Fil in this.Files) {
                                Res += Fil.NewCompSize;
                        }

                        return Res;
                }


                public int GetDownloadedSize()
                {
                        if (this.Files == null)
                                return 0;

                        int Res = 0;
                        foreach (File Fil in this.Files) {
                                if (Fil.IsDownloaded)
                                        Res += Fil.NewCompSize;
                        }

                        return Res;
                }


                public override string ToString()
                {
                        return this.Name;
                }
        }
}
