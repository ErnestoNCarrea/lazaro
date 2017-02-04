using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using qGen;

namespace Lfx.Backups
{
        public class Manager
        {
                public string BackupPath { get; set; }

                public Manager()
                {
                        this.BackupPath = this.GetDefaultBackupPath();
                }


                public void StartBackup(BackupInfo backupInfo)
                {
                        System.Threading.ThreadStart BackupThread = delegate { this.Backup(backupInfo); };
                        System.Threading.Thread Thr = new System.Threading.Thread(BackupThread);
                        Thr.IsBackground = true;
                        Thr.Start();
                }


                public string GetDefaultBackupPath()
                {
                        return Lfx.Environment.Folders.ApplicationDataFolder + "Backup" + System.IO.Path.DirectorySeparatorChar;
                }


                public void Delete(string Carpeta)
                {
                        if (Carpeta != null && Carpeta.Length > 0 && System.IO.Directory.Exists(BackupPath + Carpeta)) {
                                System.IO.Directory.Delete(BackupPath + Carpeta, true);
                        }
                }


                public string GetOldestBackupName()
                {
                        List<BackupInfo> Lista = this.GetBackups();
                        string MasViejo = "";
                        System.DateTime FechaMasViejo = System.DateTime.MaxValue;
                        foreach (BackupInfo Backup in Lista) {
                                if (Backup.BackupDate < FechaMasViejo) {
                                        MasViejo = Backup.Name;
                                        FechaMasViejo = Backup.BackupDate;
                                }
                        }
                        return MasViejo;
                }


                public string GetNewestBackupName()
                {
                        List<BackupInfo> Lista = GetBackups();
                        string MasNuevo = "";
                        System.DateTime FechaMasNuevo = System.DateTime.MinValue;
                        foreach (BackupInfo Backup in Lista) {
                                if (Backup.BackupDate > FechaMasNuevo) {
                                        MasNuevo = Backup.Name;
                                        FechaMasNuevo = Backup.BackupDate;
                                }
                        }
                        return MasNuevo;
                }


                public List<BackupInfo> GetBackups()
                {
                        Lfx.Environment.Folders.EnsurePathExists(BackupPath);

                        List<BackupInfo> Res = new List<BackupInfo>();
                        System.IO.DirectoryInfo Dir = new System.IO.DirectoryInfo(this.BackupPath);
                        foreach (System.IO.DirectoryInfo DirItem in Dir.GetDirectories("*.*")) {
                                BackupInfo Backup = new BackupInfo();

                                if (System.IO.File.Exists(this.BackupPath + DirItem.Name + System.IO.Path.DirectorySeparatorChar + "info.xml")) {
                                        // Nuevo formato de archivo de información

                                } else if (System.IO.File.Exists(this.BackupPath + DirItem.Name + System.IO.Path.DirectorySeparatorChar + "info.txt")) {
                                        // Antiguo formato de información
                                        string ArchivoIni = Lfx.Types.Strings.ReadTextFile(this.BackupPath + DirItem.Name + System.IO.Path.DirectorySeparatorChar + "info.txt");
                                        Backup.Name = DirItem.Name;
                                        Backup.UserName = Lfx.Types.Ini.ReadString(ArchivoIni, "", "Usuario");
                                        Backup.CompanyName = Lfx.Types.Ini.ReadString(ArchivoIni, "", "Empresa");
                                        Backup.ProgramVersion = Lfx.Types.Ini.ReadString(ArchivoIni, "", "VersiónLazaro");
                                        Backup.BackupDate = DateTime.ParseExact(Lfx.Types.Ini.ReadString(ArchivoIni, "", "FechaYHora"), @"dd\-MM\-yyyy ""a las"" HH\:mm\:ss", System.Globalization.CultureInfo.InvariantCulture);
                                }

                                Res.Add(Backup);
                        }

                        Res.Sort(delegate(BackupInfo b1, BackupInfo b2) { return b1.BackupDate.CompareTo(b2.BackupDate); });
                        Res.Reverse();

                        return Res;
                }


                /// <summary>
                /// Exporta los campos binarios de una tabla en archivos.
                /// </summary>
                public void ExportBlobs(qGen.Select ComandoSelect, string Carpeta)
                {
                        if (char.Parse(Carpeta.Substring(Carpeta.Length - 1, 1)) != System.IO.Path.DirectorySeparatorChar)
                                Carpeta += System.Convert.ToString(System.IO.Path.DirectorySeparatorChar);

                        using (System.Data.DataTable Tabla = Lfx.Workspace.Master.MasterConnection.Select(ComandoSelect.ToString())) {
                                foreach (System.Data.DataRow Registro in Tabla.Rows) {
                                        foreach (System.Data.DataColumn Campo in Tabla.Columns) {
                                                if (Campo.DataType.Name == "Byte[]" && Registro[Campo.ColumnName] != null && ((byte[])(Registro[Campo.ColumnName])).Length > 5) {
                                                        byte[] Contenido = ((byte[])(Registro[Campo.ColumnName]));
                                                        string NombreArchivo = ComandoSelect.Tables + "_" + Campo.ColumnName + "_" + Registro[0].ToString() + ".blb";
                                                        using (System.IO.FileStream Archivo = new System.IO.FileStream(Carpeta + NombreArchivo, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)) {
                                                                Archivo.Write(Contenido, 0, Contenido.Length);
                                                                Archivo.Close();
                                                        }

                                                        using (System.IO.FileStream Archivo = new System.IO.FileStream(Carpeta + "blobs.lst", System.IO.FileMode.Append, System.IO.FileAccess.Write)) {
                                                                System.IO.StreamWriter Escribidor = new System.IO.StreamWriter(Archivo);
                                                                Escribidor.WriteLine(ComandoSelect.Tables + "," + Campo.ColumnName + "," + Tabla.Columns[0].ColumnName + "='" + Registro[0].ToString() + "'," + NombreArchivo);
                                                                Escribidor.Close();
                                                                Archivo.Close();
                                                        }
                                                }
                                        }
                                }
                        }
                }


                /// <summary>
                /// Exporta una tabla en un formato binario propietario, incluyendo BLOBs.
                /// </summary>
                public void ExportTableBin(string nombreTabla, BackupWriter writer)
                {
                        qGen.Select Comando = new qGen.Select(nombreTabla);
                        System.Data.DataTable TablaBackup = Lfx.Workspace.Master.MasterConnection.Select(Comando);

                        bool EmitiTabla = false;
                        string[] Fields = null;
                        foreach (System.Data.DataRow RegistroBackup in TablaBackup.Rows) {
                                if (EmitiTabla == false) {
                                        Fields = new string[TablaBackup.Columns.Count];
                                        for (int i = 0; i < TablaBackup.Columns.Count; i++) {
                                                Fields[i] = TablaBackup.Columns[i].ColumnName;
                                        }
                                        string FieldList = string.Join(",", Fields);
                                        writer.Write(":TBL" + Comando.Tables.Length.ToString("0000") + Comando.Tables);
                                        writer.Write(":FDL" + FieldList.Length.ToString("0000") + FieldList);
                                        EmitiTabla = true;
                                }
                                writer.Write(":ROW");

                                for (int i = 0; i < TablaBackup.Columns.Count; i++) {
                                        object ValorOrigen = RegistroBackup[Fields[i]];
                                        string TipoCampoOrigen = ValorOrigen.GetType().ToString().Replace("System.", "");
                                        string TipoCampoDestino;
                                        switch (TipoCampoOrigen) {
                                                case "Byte[]":
                                                        TipoCampoDestino = "B";
                                                        break;
                                                case "SByte":
                                                case "Byte":
                                                case "Int16":
                                                case "Int32":
                                                case "Int64":
                                                        ValorOrigen = ValorOrigen.ToString();
                                                        TipoCampoDestino = "I";
                                                        break;
                                                case "Single":
                                                case "Double":
                                                        double ValDouble = System.Convert.ToDouble(ValorOrigen);
                                                        ValorOrigen = ValDouble.ToString(System.Globalization.CultureInfo.InvariantCulture);
                                                        TipoCampoDestino = "N";
                                                        break;
                                                case "Decimal":
                                                        decimal ValDecimal = System.Convert.ToDecimal(ValorOrigen);
                                                        ValorOrigen = ValDecimal.ToString(System.Globalization.CultureInfo.InvariantCulture);
                                                        TipoCampoDestino = "N";
                                                        break;
                                                case "DateTime":
                                                        ValorOrigen = ((DateTime)ValorOrigen).ToString(Lfx.Types.Formatting.DateTime.SqlDateTimeFormat);
                                                        TipoCampoDestino = "D";
                                                        break;
                                                case "String":
                                                        TipoCampoDestino = "S";
                                                        break;
                                                case "DBNull":
                                                        TipoCampoDestino = "U";
                                                        ValorOrigen = "";
                                                        break;
                                                default:
                                                        TipoCampoDestino = "S";
                                                        ValorOrigen = ValorOrigen.ToString();
                                                        break;
                                        }

                                        byte[] ValorDestino;

                                        if (ValorOrigen is byte[])
                                                ValorDestino = (byte[])ValorOrigen;
                                        else if (ValorOrigen is string)
                                                ValorDestino = System.Text.Encoding.UTF8.GetBytes((string)ValorOrigen);
                                        else
                                                throw new NotImplementedException();

                                        writer.Write(":FLD" + TipoCampoDestino + ValorDestino.Length.ToString("00000000"));
                                        if (ValorDestino.Length > 0)
                                                writer.Write(ValorDestino);
                                }
                                writer.Write(".ROW");
                                //writer.Write(":REM0002" + Lfx.Types.ControlChars.CrLf);
                        }

                        writer.Write(".TBL");
                }

                /// <summary>
                /// Exporta una tabla a un archivo de texto con una secuencia de comandos SQL.
                /// </summary>
                public void ExportTable(qGen.Select Comando, bool ExportarBlobs, System.IO.StreamWriter writer)
                {
                        System.Data.DataTable Tabla = Lfx.Workspace.Master.MasterConnection.Select(Comando);

                        string NombresCampos = null;
                        // Hago un dump de los campos
                        foreach (System.Data.DataColumn Campo in Tabla.Columns) {
                                if (NombresCampos == null)
                                        NombresCampos = Campo.ColumnName;
                                else
                                        NombresCampos += ", " + Campo.ColumnName;
                        }

                        foreach (System.Data.DataRow Registro in Tabla.Rows) {
                                string Valores = "";
                                foreach (System.Data.DataColumn Campo in Tabla.Columns) {
                                        string Valor = "";
                                        if (Registro[Campo.ColumnName] == DBNull.Value || Registro[Campo.ColumnName] == null) {
                                                Valor = "NULL";
                                        } else {
                                                switch (Campo.DataType.Name) {
                                                        case "Byte[]":
                                                                if (ExportarBlobs) {
                                                                        // FIXME: exportar BLOBS
                                                                } else {
                                                                        Valor = "NULL";
                                                                }
                                                                break;
                                                        case "SByte":
                                                        case "Byte":
                                                        case "Int16":
                                                        case "Int32":
                                                        case "Int64":
                                                                Valor = Registro[Campo.ColumnName].ToString();
                                                                break;
                                                        case "Single":
                                                        case "Double":
                                                                Valor = System.Convert.ToDouble(Registro[Campo.ColumnName]).ToString(System.Globalization.CultureInfo.InvariantCulture);
                                                                break;
                                                        case "Decimal":
                                                                Valor = System.Convert.ToDecimal(Registro[Campo.ColumnName]).ToString(System.Globalization.CultureInfo.InvariantCulture);
                                                                break;
                                                        case "DateTime":
                                                                Valor = "'" + Lfx.Types.Formatting.FormatDateTimeSql(System.Convert.ToDateTime(Registro[Campo.ColumnName])) + "'";
                                                                break;
                                                        case "String":
                                                                Valor = "'" + Lfx.Workspace.Master.MasterConnection.EscapeString(System.Convert.ToString(Registro[Campo.ColumnName])).Replace("\r", @"\r").Replace("\n", @"\n") + "'";
                                                                break;
                                                        default:
                                                                Lfx.Workspace.Master.RunTime.Toast("No se puede restaurar campo tipo " + Campo.DataType.Name, "Error");
                                                                Valor = "'" + Lfx.Workspace.Master.MasterConnection.EscapeString(Registro[Campo.ColumnName].ToString()) + "'";
                                                                break;
                                                }
                                        }
                                        //Quito el primer ", "
                                        Valores += ", " + Valor;
                                }
                                Valores = Valores.Substring(2, Valores.Length - 2);
                                writer.WriteLine("$INSERTORREPLACE$ " + Comando.Tables + " (" + NombresCampos + ") VALUES (" + Valores + ")" + ";");
                        }
                        writer.WriteLine("");
                        writer.WriteLine("");
                        return;
                }


                public Lfx.Types.OperationResult Backup(BackupInfo backupInfo)
                {
                        string WorkFolder = backupInfo.Name + System.IO.Path.DirectorySeparatorChar;

                        Lfx.Environment.Folders.EnsurePathExists(this.BackupPath);

                        if (!System.IO.Directory.Exists(Lfx.Environment.Folders.TemporaryFolder + WorkFolder))
                                System.IO.Directory.CreateDirectory(Lfx.Environment.Folders.TemporaryFolder + WorkFolder);

                        Lfx.Types.OperationProgress Progreso = new Lfx.Types.OperationProgress("Creando copia de seguridad", "Se está creando un volcado completo del almacén de datos en una carpeta, para resguardar.");
                        Progreso.Modal = true;
                        Progreso.Advertise = true;
                        Progreso.Begin();
                        Progreso.Max = Lfx.Workspace.Master.Structure.Tables.Count + 1;

                        Progreso.ChangeStatus("Exportando estructura");
                        Progreso.ChangeStatus(Progreso.Value + 1);
                        System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                        doc.AppendChild(Lfx.Workspace.Master.Structure.ToXml(doc));
                        doc.Save(Lfx.Environment.Folders.TemporaryFolder + WorkFolder + "dbstruct.xml");

                        BackupWriter Writer = new BackupWriter(Lfx.Environment.Folders.TemporaryFolder + WorkFolder + "dbdata.lbd");
                        Writer.Write(":BKP");

                        IList<string> TableList = Lfx.Data.DataBaseCache.DefaultCache.GetTableNames();
                        foreach (string Tabla in TableList) {
                                string NombreTabla = Tabla;
                                if (Lfx.Workspace.Master.Structure.Tables.ContainsKey(Tabla))
                                        NombreTabla = Lfx.Workspace.Master.Structure.Tables[Tabla].Label;

                                Progreso.ChangeStatus("Volcando " + NombreTabla);
                                Progreso.ChangeStatus(Progreso.Value + 1);
                                ExportTableBin(Tabla, Writer);

                        }
                        Writer.Close();

                        System.IO.FileStream Archivo = new System.IO.FileStream(Lfx.Environment.Folders.TemporaryFolder + WorkFolder + "info.txt", System.IO.FileMode.Append, System.IO.FileAccess.Write);
                        using (System.IO.StreamWriter Escribidor = new System.IO.StreamWriter(Archivo, System.Text.Encoding.Default)) {
                                Escribidor.WriteLine("Copia de seguridad de Lázaro");
                                Escribidor.WriteLine("");
                                Escribidor.WriteLine("Empresa=" + backupInfo.CompanyName);
                                Escribidor.WriteLine("EspacioTrabajo=" + Lfx.Workspace.Master.Name);
                                Escribidor.WriteLine("FechaYHora=" + System.DateTime.Now.ToString("dd-MM-yyyy") + " a las " + System.DateTime.Now.ToString("HH:mm:ss"));
                                Escribidor.WriteLine("Usuario=" + backupInfo.UserName);
                                Escribidor.WriteLine("Estación=" + Lfx.Environment.SystemInformation.MachineName);
                                Escribidor.WriteLine("VersiónLazaro=" + backupInfo.ProgramVersion);
                                Escribidor.WriteLine("");
                                Escribidor.WriteLine("Por favor no modifique ni elimine este archivo.");
                                Escribidor.Close();
                                Archivo.Close();
                        }

                        if (Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.ComprimirCopiasDeSeguridad", 0) != 0) {
                                Progreso.ChangeStatus("Comprimiendo los datos");
                                Lfx.FileFormats.Compression.Archive ArchivoComprimido = new Lfx.FileFormats.Compression.Archive(Lfx.Environment.Folders.TemporaryFolder + WorkFolder + "backup.7z");
                                ArchivoComprimido.Add(Lfx.Environment.Folders.TemporaryFolder + WorkFolder + "*");
                                if (System.IO.File.Exists(Lfx.Environment.Folders.TemporaryFolder + WorkFolder + "backup.7z")) {
                                        Progreso.ChangeStatus("Eliminando archivos temporales");
                                        // Borrar los archivos que acabo de comprimir
                                        System.IO.DirectoryInfo Dir = new System.IO.DirectoryInfo(Lfx.Environment.Folders.TemporaryFolder + WorkFolder);
                                        foreach (System.IO.FileInfo DirItem in Dir.GetFiles()) {
                                                if (DirItem.Name != "backup.7z" && DirItem.Name != "info.txt") {
                                                        System.IO.File.Delete(Lfx.Environment.Folders.TemporaryFolder + WorkFolder + DirItem.Name);
                                                }
                                        }
                                }
                        }

                        Progreso.ChangeStatus("Almacenando");
                        Progreso.ChangeStatus(Progreso.Value + 1);
                        Lfx.Environment.Folders.MoveDirectory(Lfx.Environment.Folders.TemporaryFolder + WorkFolder, this.BackupPath + WorkFolder);

                        int GuardarBackups = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sisteam.Backup.CantMax", 14);
                        if (GuardarBackups > 0) {
                                List<BackupInfo> ListaDeBackups = this.GetBackups();
                                if (ListaDeBackups.Count > GuardarBackups) {
                                        Progreso.ChangeStatus("Eliminando copias de seguridad antiguas");
                                        int BorrarBackups = ListaDeBackups.Count - GuardarBackups;
                                        if (BorrarBackups < ListaDeBackups.Count) {
                                                for (int i = 1; i <= BorrarBackups; i++) {
                                                        this.Delete(this.GetOldestBackupName());
                                                }
                                        }
                                }
                        }

                        Progreso.End();

                        return new Lfx.Types.SuccessOperationResult();
                }


                public void Restore(string backupName)
                {
                        string Carpeta = backupName + System.IO.Path.DirectorySeparatorChar;

                        Lfx.Environment.Folders.EnsurePathExists(this.BackupPath);

                        if (Carpeta != null && Carpeta.Length > 0 && System.IO.Directory.Exists(this.BackupPath + Carpeta)) {
                                bool UsandoArchivoComprimido = false;

                                Lfx.Types.OperationProgress Progreso = new Lfx.Types.OperationProgress("Restaurando copia de seguridad", "Este proceso va a demorar varios minutos. Por favor no lo interrumpa");
                                Progreso.Modal = true;

                                /* Progreso.ChangeStatus("Descomprimiendo");
                                // Descomprimir backup si está comprimido
                                if (System.IO.File.Exists(BackupPath + Carpeta + "backup.7z")) {
                                        Lfx.FileFormats.Compression.Archive ArchivoComprimido = new Lfx.FileFormats.Compression.Archive(BackupPath + Carpeta + "backup.7z");
                                        ArchivoComprimido.ExtractAll(BackupPath + Carpeta);
                                        UsandoArchivoComprimido = true;
                                } */

                                Progreso.ChangeStatus("Eliminando datos actuales");
                                using (Lfx.Data.IConnection DataBase = Lfx.Workspace.Master.GetNewConnection("Restauración de copia de seguridad") as Lfx.Data.IConnection) {

                                        Progreso.ChangeStatus("Acomodando estructuras");
                                        Lfx.Workspace.Master.Structure.TagList.Clear();
                                        Lfx.Workspace.Master.Structure.LoadFromFile(this.BackupPath + Carpeta + "dbstruct.xml");
                                        Lfx.Workspace.Master.CheckAndUpdateDataBaseVersion(true, true);

                                        using (BackupReader Lector = new BackupReader(this.BackupPath + Carpeta + "dbdata.lbd"))
                                        using (IDbTransaction Trans = DataBase.BeginTransaction()) {
                                                DataBase.EnableConstraints(false);

                                                Progreso.ChangeStatus("Incorporando tablas de datos");

                                                Progreso.Max = (int)(Lector.Length / 1024);
                                                string TablaActual = null;
                                                string[] ListaCampos = null;
                                                object[] ValoresCampos = null;
                                                int CampoActual = 0;
                                                bool EndTable = false;
                                                qGen.BuilkInsert Insertador = new qGen.BuilkInsert();
                                                do {
                                                        string Comando = Lector.ReadString(4);
                                                        switch (Comando) {
                                                                case ":TBL":
                                                                        TablaActual = Lector.ReadPrefixedString4();
                                                                        string NombreTabla;
                                                                        if (Lfx.Workspace.Master.Structure.Tables.ContainsKey(TablaActual) && Lfx.Workspace.Master.Structure.Tables[TablaActual].Label != null) {
                                                                                NombreTabla = Lfx.Workspace.Master.Structure.Tables[TablaActual].Label;
                                                                        } else {
                                                                                NombreTabla = TablaActual.ToTitleCase();
                                                                        }
                                                                        EndTable = false;
                                                                        Progreso.ChangeStatus("Cargando " + NombreTabla);

                                                                        qGen.Delete DelCmd = new qGen.Delete(TablaActual);
                                                                        DelCmd.EnableDeleleteWithoutWhere = true;
                                                                        DataBase.Execute(DelCmd);
                                                                        break;
                                                                case ":FDL":
                                                                        ListaCampos = Lector.ReadPrefixedString4().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                                                                        ValoresCampos = new object[ListaCampos.Length];
                                                                        CampoActual = 0;
                                                                        break;
                                                                case ":FLD":
                                                                        ValoresCampos[CampoActual++] = Lector.ReadField();
                                                                        break;
                                                                case ".ROW":
                                                                        qGen.Insert Insertar = new qGen.Insert(TablaActual);
                                                                        for (int i = 0; i < ListaCampos.Length; i++) {
                                                                                Insertar.Fields.AddWithValue(ListaCampos[i], ValoresCampos[i]);
                                                                        }
                                                                        Insertador.Add(Insertar);

                                                                        ValoresCampos = new object[ListaCampos.Length];
                                                                        CampoActual = 0;
                                                                        break;
                                                                case ":REM":
                                                                        Lector.ReadPrefixedString4();
                                                                        break;
                                                                case ".TBL":
                                                                        EndTable = true;
                                                                        break;
                                                        }
                                                        if (EndTable || Insertador.Count >= 1000) {
                                                                if (Insertador.Count > 0)
                                                                        DataBase.Execute(Insertador);
                                                                Insertador.Clear();
                                                                Progreso.Value = (int)(Lector.Position / 1024);
                                                        }
                                                } while (Lector.Position < Lector.Length);
                                                Lector.Close();

                                                if (Lfx.Workspace.Master.MasterConnection.SqlMode == qGen.SqlModes.PostgreSql) {
                                                        // PostgreSql: Tengo que actualizar las secuencias
                                                        Progreso.ChangeStatus("Actualizando secuencias");
                                                        string PatronSecuencia = @"nextval\(\'(.+)\'(.*)\)";
                                                        foreach (string Tabla in Lfx.Data.DataBaseCache.DefaultCache.GetTableNames()) {
                                                                string OID = DataBase.FieldString("SELECT c.oid FROM pg_catalog.pg_class c LEFT JOIN pg_catalog.pg_namespace n ON n.oid=c.relnamespace WHERE pg_catalog.pg_table_is_visible(c.oid) AND c.relname ~ '^" + Tabla + "$'");
                                                                System.Data.DataTable Campos = DataBase.Select("SELECT a.attname,pg_catalog.format_type(a.atttypid, a.atttypmod),(SELECT substring(d.adsrc for 128) FROM pg_catalog.pg_attrdef d WHERE d.adrelid = a.attrelid AND d.adnum = a.attnum AND a.atthasdef), a.attnotnull, a.attnum FROM pg_catalog.pg_attribute a WHERE a.attrelid = '" + OID + "' AND a.attnum > 0 AND NOT a.attisdropped ORDER BY a.attnum");
                                                                foreach (System.Data.DataRow Campo in Campos.Rows) {
                                                                        if (Campo[2] != DBNull.Value && Campo[2] != null) {
                                                                                string DefaultCampo = System.Convert.ToString(Campo[2]);
                                                                                if (Regex.IsMatch(DefaultCampo, PatronSecuencia)) {
                                                                                        string NombreCampo = System.Convert.ToString(Campo[0]);
                                                                                        foreach (System.Text.RegularExpressions.Match Ocurrencia in Regex.Matches(DefaultCampo, PatronSecuencia)) {
                                                                                                string Secuencia = Ocurrencia.Groups[1].ToString();
                                                                                                int MaxId = DataBase.FieldInt("SELECT MAX(" + NombreCampo + ") FROM " + Tabla) + 1;
                                                                                                DataBase.ExecuteSql("ALTER SEQUENCE " + Secuencia + " RESTART WITH " + MaxId.ToString());
                                                                                        }
                                                                                }
                                                                        }
                                                                }
                                                        }
                                                }

                                                if (System.IO.File.Exists(this.BackupPath + Carpeta + "blobs.lst")) {
                                                        // Incorporar Blobs
                                                        Progreso.ChangeStatus("Incorporando imágenes");
                                                        System.IO.StreamReader LectorBlobs = new System.IO.StreamReader(this.BackupPath + Carpeta + "blobs.lst", System.Text.Encoding.Default);
                                                        string InfoImagen = null;
                                                        do {
                                                                InfoImagen = LectorBlobs.ReadLine();
                                                                if (InfoImagen != null && InfoImagen.Length > 0) {
                                                                        string Tabla = Lfx.Types.Strings.GetNextToken(ref InfoImagen, ",");
                                                                        string Campo = Lfx.Types.Strings.GetNextToken(ref InfoImagen, ",");
                                                                        string CampoId = Lfx.Types.Strings.GetNextToken(ref InfoImagen, ",");
                                                                        string NombreArchivoImagen = Lfx.Types.Strings.GetNextToken(ref InfoImagen, ",");

                                                                        // Guardar blob nuevo
                                                                        qGen.Update ActualizarBlob = new qGen.Update(DataBase, Tabla);
                                                                        ActualizarBlob.WhereClause = new qGen.Where(Campo, CampoId);

                                                                        System.IO.FileStream ArchivoImagen = new System.IO.FileStream(this.BackupPath + Carpeta + NombreArchivoImagen, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                                                                        byte[] Contenido = new byte[System.Convert.ToInt32(ArchivoImagen.Length) - 1 + 1];
                                                                        ArchivoImagen.Read(Contenido, 0, System.Convert.ToInt32(ArchivoImagen.Length));
                                                                        ArchivoImagen.Close();

                                                                        ActualizarBlob.Fields.AddWithValue(Campo, Contenido);
                                                                        DataBase.Execute(ActualizarBlob);
                                                                }
                                                        }
                                                        while (InfoImagen != null);
                                                        LectorBlobs.Close();
                                                }

                                                if (UsandoArchivoComprimido) {
                                                        Progreso.ChangeStatus("Eliminando archivos temporales");
                                                        // Borrar los archivos que descomprim temporalmente
                                                        System.IO.DirectoryInfo Dir = new System.IO.DirectoryInfo(this.BackupPath + Carpeta);
                                                        foreach (System.IO.FileInfo DirItem in Dir.GetFiles()) {
                                                                if (DirItem.Name != "backup.7z" && DirItem.Name != "info.txt") {
                                                                        System.IO.File.Delete(this.BackupPath + Carpeta + DirItem.Name);
                                                                }
                                                        }
                                                }
                                                Progreso.ChangeStatus("Terminando transacción");
                                                Trans.Commit();
                                        }
                                        Progreso.End();
                                }

                                Lfx.Workspace.Master.RunTime.Toast("La copia de seguridad se restauró con éxito. A continuación se va a reiniciar la aplicación.", "Copia Restaurada");
                        }
                }

        }
}
