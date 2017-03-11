using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Security.Permissions;
using System.Windows.Forms;

namespace Lazaro.WinMain
{
        public class Aplicacion
        {
                private static readonly ILog Log = LogManager.GetLogger(typeof(Application));

                public static Lui.Forms.ProgressForm FormularioProgreso;
                public static IList<Lfx.Types.OperationProgress> Operaciones = new List<Lfx.Types.OperationProgress>();
                public static bool Flotante;

                /// <summary>
                /// Obtiene la versión del ejecutable principal.
                /// </summary>
                [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
                public static string Version()
                {
                        System.Diagnostics.FileVersionInfo Ver = System.Diagnostics.FileVersionInfo.GetVersionInfo(Lfx.Environment.Folders.ApplicationFolder + "Lazaro.exe");
                        return Ver.ProductVersion.ToString();
                }

                /// <summary>
                /// Obtiene la fecha del ejecutable principal.
                /// </summary>
                public static DateTime BuildDate()
                {
                        System.IO.FileInfo InfoArchivo = new System.IO.FileInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        return InfoArchivo.LastWriteTime;
                }

                /// <summary>
                /// Punto de entrada principal del programa. Hace la conexión a la base de datos y llama a IniciarNormal.
                /// </summary>
                [STAThread, SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
                public static int Main(string[] args)
                {
                        System.Threading.Thread.CurrentThread.Name = "Lazaro";

                        bool ReconfigDB = false, DebugMode = false, /* TraceMode = false, */ IgnoreUpdates = false;
                        bool MostrarAsistenteConfig = false, ClearCache = false;

                        string NombreConfig = "default";

                        if (args != null) {
                                foreach (string Argumento in args) {
                                        switch (Argumento) {
                                                case "/config":
                                                case "--config":
                                                        ReconfigDB = true;
                                                        break;

                                                case "/wizard":
                                                case "--wizard":
                                                        MostrarAsistenteConfig = true;
                                                        break;

                                                case "/ignoreupdates":
                                                case "--ignoreupdates":
                                                        IgnoreUpdates = true;
                                                        break;

                                                case "/clearcache":
                                                case "--clearcache":
                                                        ClearCache = true;
                                                        break;

                                                case "/help":
                                                case "--help":
                                                case "/?":
                                                        if (Lfx.Environment.SystemInformation.Platform == Lfx.Environment.SystemInformation.Platforms.Windows)
                                                                System.Windows.Forms.MessageBox.Show(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + @" [/config] [/ignoreupdates] [/debug] [/clearcache] [/ignoreupdates] [EspacioTrabajo]", "Ayuda");
                                                        else
                                                                System.Windows.Forms.MessageBox.Show(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + @" [--config] [--ignoreupdates] [--debug] [--clearcache] [--ignoreupdates] [EspacioTrabajo]", "Ayuda");
                                                        System.Environment.Exit(0);
                                                        break;

                                                case "/debug":
                                                case "--debug":
                                                        DebugMode = true;
                                                        IgnoreUpdates = true;
                                                        break;

                                                /* case "/trace":
                                                case "--trace":
                                                        TraceMode = true;
                                                        break; */

                                                case "/portable":
                                                case "--portable":
                                                        Lfx.Environment.Folders.PortableMode = true;
                                                        break;

                                                default:
                                                        NombreConfig = System.IO.Path.GetFileNameWithoutExtension(Argumento);
                                                        break;
                                        }
                                }
                        }


                        try {
                                Lfx.Environment.Folders.EnsurePathExists(Lfx.Environment.Folders.ApplicationFolder);
                        } catch (Exception ex) {
                                Lui.Forms.MessageBox.Show("No se puede crear la carpeta " + Lfx.Environment.Folders.ApplicationFolder + ". " + ex.Message, "Error");
                        }
                        try {
                                Lfx.Environment.Folders.EnsurePathExists(Lfx.Environment.Folders.ApplicationDataFolder);
                        } catch (Exception ex) {
                                Lui.Forms.MessageBox.Show("No se puede crear la carpeta " + Lfx.Environment.Folders.ApplicationDataFolder + ". " + ex.Message, "Error");
                        }

                        if (System.IO.File.Exists(Lfx.Environment.Folders.ApplicationFolder + "portable.lwf")) {
                                NombreConfig = "portable";
                                Lfx.Environment.Folders.PortableMode = true;
                        }


                        // Manejadores de excepciones
                        Application.EnableVisualStyles();
                        if (DebugMode == false) {
                                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ThreadExceptionHandler);
                                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionHandler);
                                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                        }

                        if (System.IO.File.Exists(Lfx.Environment.Folders.ApplicationDataFolder + "clear.txt"))
                                ClearCache = true;


                        // Busco actualización en la caché
                        if (ClearCache) {
                                try {
                                        Lfx.Environment.Folders.DeleteWithWildcards(Lfx.Environment.Folders.TemporaryFolder, "*.*");
                                } catch {
                                        // Si algún archivo no se puede borrar, no importa
                                }

                                try {
                                        Lfx.Environment.Folders.DeleteWithWildcards(Lfx.Environment.Folders.UpdatesFolder, "*.*");
                                        Lfx.Environment.Folders.DeleteWithWildcards(Lfx.Environment.Folders.UpdatesFolder + "Components" + System.IO.Path.DirectorySeparatorChar, "*.*");
                                } catch {
                                        // Si algún archivo no se puede borrar, no importa
                                }

                                try {
                                        Lfx.Environment.Folders.DeleteWithWildcards(Lfx.Environment.Folders.ApplicationDataFolder, "clear.txt");
                                } catch {
                                        // Si algún archivo no se puede borrar, no importa
                                }

                        }

                        // Verifico estar utilizando un Encoding compatible (ISO-8859-1 o UTF-8)
                        if (System.Text.Encoding.Default.BodyName != "iso-8859-1"
                                && System.Text.Encoding.Default.BodyName != "utf-8") {
                                System.Windows.Forms.MessageBox.Show("La códificación " + System.Text.Encoding.Default.BodyName.ToUpperInvariant() + " no es válida. Sólo se permiten las codificaciones ISO-8859-1 (Latin-1) y UTF-8.", "Error");
                                System.Windows.Forms.Application.Exit();
                        }


                        if (IgnoreUpdates == false && System.IO.Directory.Exists(Lfx.Environment.Folders.UpdatesFolder)) {
                                // Si hay actualizaciones pendientes, reinicio para que ActualizadorLazaro se encargue de ellas.
                                string[] ArchivosNuevos = System.IO.Directory.GetFiles(Lfx.Environment.Folders.UpdatesFolder, "*.new", System.IO.SearchOption.AllDirectories);
                                if (ArchivosNuevos.Length > 0) {
                                        System.Console.WriteLine("Existen actualizaciones pendientes. Ejecutando ActualizadorLazaro");
                                        if (Lfx.Environment.SystemInformation.IsUacActive)
                                                Lui.Forms.MessageBox.Show("Lázaro se va a actualizar ahora. Es probable que el sistema le solicite autorización durante la actualización.", "Lázaro");
                                        Lfx.Environment.Shell.Reboot();
                                }
                        }


                        DescargarArchivosNecesarios();

                        //Si no hay espacio de trabajo predeterminado (default.lwf), presento una ventana de selección
                        System.IO.DirectoryInfo Dir = new System.IO.DirectoryInfo(Lfx.Environment.Folders.ApplicationDataFolder);
                        if (Dir.GetFiles(NombreConfig + ".lwf").Length == 0 && Dir.GetFiles("*.lwf").Length >= 1) {
                                using (Lui.Forms.WorkspaceSelectorForm SelectEspacio = new Lui.Forms.WorkspaceSelectorForm()) {
                                        if (SelectEspacio.ShowDialog() == DialogResult.OK) {
                                                NombreConfig = SelectEspacio.WorkspaceName;
                                                if (NombreConfig == null)
                                                        System.Environment.Exit(0);
                                        } else {
                                                System.Environment.Exit(0);
                                        }
                                }
                        }

                        // Inicio el espacio de trabajo
                        Lfx.Workspace.Master = new Lfx.Workspace(NombreConfig, false, false);
                        Lfx.Workspace.Master.DebugMode = DebugMode;
                        //Lfx.Workspace.Master.TraceMode = TraceMode;
                        Lfx.Workspace.Master.RunTime.IpcEvent += new Lfx.RunTimeServices.IpcEventHandler(Workspace_IpcEvent);

                        // Asigno a la aplicación WinForms la misma cultura que se está usando en el espacio de trabajo
                        System.Windows.Forms.Application.CurrentCulture = Lfx.Workspace.Master.CultureInfo;

                        // Si no hay datos de configuración, voy a presentar el asistente
                        if (Lfx.Workspace.Master.CurrentConfig.ReadLocalSettingString("Data", "DataSource", null) == null)
                                MostrarAsistenteConfig = true;

                        if (MostrarAsistenteConfig || ReconfigDB) {
                                // Presento el asistente de configurar almacén de datos
                                using (Config.Inicial AsistenteInicial = new Config.Inicial()) {
                                        if (AsistenteInicial.ShowDialog() == DialogResult.Cancel)
                                                System.Environment.Exit(0);
                                }
                        }

                        IniciarDatos();

                        Lfx.Workspace.Master.InitUpdater();

                        Lbl.Componentes.Cargador.CargarComponentes();

                        if (IgnoreUpdates == false) {
                                // Verifico la versión de Lázaro requerida por la BD
                                DateTime FechaLazaroExe = System.IO.File.GetLastWriteTime(System.Reflection.Assembly.GetExecutingAssembly().Location);
                                DateTime MinVersion = DateTime.ParseExact(Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.DB.VersionMinima", "2000-01-01 00:00:00"), Lfx.Types.Formatting.DateTime.SqlDateTimeFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal);
                                if (FechaLazaroExe < MinVersion) {
                                        Misc.ActualizarAhora Act = new Misc.ActualizarAhora();
                                        DialogResult Res = Act.ShowDialog();
                                        switch (Res) {
                                                case DialogResult.OK:
                                                        Lfx.Environment.Shell.Reboot();
                                                        break;
                                                default:
                                                        Lfx.Workspace.Master.RunTime.Toast("La versión de Lázaro que está utilizando es demasiado antigua. Descargue e instale la última versión para continuar. Si desea más información ingrese a la página web www.lazarogestion.com", "Toast");
                                                        break;
                                        }
                                        System.Environment.Exit(1);
                                } else {
                                        // Cumple con la versión requerida, pero de todos modos verifico si es necesario actualizar Lázaro
                                        DateTime VersionEstructura = DateTime.ParseExact(Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.DB.VersionEstructura", "2000-01-01 00:00:00"), Lfx.Types.Formatting.DateTime.SqlDateTimeFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AssumeUniversal);
                                        TimeSpan Diferencia = FechaLazaroExe - VersionEstructura;

                                        if (Diferencia.TotalHours < -12) {
                                                // Lázaro es más viejo que la bd por al menos 12 horas
                                                Misc.ActualizarAhora Act = new Misc.ActualizarAhora();
                                                DialogResult Res = Act.ShowDialog();
                                                switch (Res) {
                                                        case DialogResult.OK:
                                                                Lfx.Environment.Shell.Reboot();
                                                                break;
                                                        default:
                                                                Lfx.Workspace.Master.RunTime.Toast("La versión de Lázaro que está utilizando es antigua. Es recomendable que descargue e instale la última versión.", "Aviso");
                                                                break;
                                                }
                                        }
                                }
                        }

                        if (Lfx.Environment.SystemInformation.DesignMode == false) {
                                // Si es necesario, actualizo la estructura de la base de datos
                                Lfx.Workspace.Master.CheckAndUpdateDatabaseVersion(false, false);
                        }

                        Lfx.Types.OperationResult ResultadoInicio = IniciarGui();

                        if (ResultadoInicio.Success == false)
                                Lui.Forms.MessageBox.Show(ResultadoInicio.Message, "Error al Iniciar");

                        return 0;
                }


                /// <summary>
                /// Descarga en caso de que haga falta algunos ensamblados necesarios para el funcionamiento del programa.
                /// </summary>
                private static void DescargarArchivosNecesarios()
                {
                        IList<string> ArchivosNecesarios = new List<string>()
                        {
                                "Interop.WIA.dll",
                                "MySql.Data.dll",
                                "ICSharpCode.SharpZipLib.dll",
                                "PdfSharp.dll",
                                "BarcodeLib.dll",
                        };
                        IList<string> ArchivosFaltantes = new List<string>();

                        foreach (string Arch in ArchivosNecesarios) {
                                if (System.IO.File.Exists(Arch) == false)
                                        ArchivosFaltantes.Add(Arch);
                        }

                        if (ArchivosFaltantes.Count > 0) {
                                Lfx.Types.OperationProgress Progreso = new Lfx.Types.OperationProgress("Descargando archivos adicionales", "Se van a descargar algunos archivos necesarios para el funcionamiento de Lázaro");
                                Progreso.Max = ArchivosFaltantes.Count;
                                Progreso.Begin();

                                bool CanWriteToAppFolder = Lfx.Environment.SystemInformation.CanWriteToAppFolder;
                                using (WebClient Cliente = new WebClient()) {
                                        foreach (string Arch in ArchivosFaltantes) {
                                                Progreso.ChangeStatus("Descargando " + Arch);
                                                string ArchDestino;
                                                if (CanWriteToAppFolder)
                                                        // Lo descargo directamente a la carpeta de la aplicación
                                                        ArchDestino = Lfx.Environment.Folders.ApplicationFolder + Arch;
                                                else
                                                        // Tengo UAC, lo descargo a la carpeta de actualizaciones y luego tengo que iniciar el ActualizadorLazaro.exe
                                                        ArchDestino = Lfx.Environment.Folders.UpdatesFolder + Arch + ".new";

                                                try {
                                                        Cliente.DownloadFile(@"http://www.lazarogestion.com/aslnlwc/" + Arch, ArchDestino);
                                                } catch {
                                                        // Nada
                                                }
                                                Progreso.Advance(1);
                                        }
                                }
                                Progreso.End();

                                if (CanWriteToAppFolder == false)
                                        Lfx.Environment.Shell.Reboot();
                        }
                }

                /// <summary>
                /// Maneja eventos disparados por el (mal llamado) IPC (comunicación inter-proceso) del espacio de trabajo.
                /// </summary>
                public static void Workspace_IpcEvent(object sender, ref Lfx.RunTimeServices.IpcEventArgs e)
                {
                        if (e.Destination == "lazaro") {
                                switch (e.EventType) {
                                        case Lfx.RunTimeServices.IpcEventArgs.EventTypes.ActionRequest:
                                                if (e.Arguments != null)
                                                        e.ReturnValue = Ejecutor.Exec(e.Verb + " " + string.Join(" ", (string[])e.Arguments));
                                                else
                                                        e.ReturnValue = Ejecutor.Exec(e.Verb);
                                                break;
                                        case Lfx.RunTimeServices.IpcEventArgs.EventTypes.Progress:
                                                Lfx.Types.OperationProgress Prog = (Lfx.Types.OperationProgress)(e.Arguments[0]);
                                                if (Operaciones.Contains(Prog) == false)
                                                        // Agrego a la lista de operaciones en progreso
                                                        Operaciones.Add(Prog);

                                                if (Prog.Advertise) {
                                                        if (Aplicacion.FormularioPrincipal == null || Prog.Modal) {
                                                                if (Aplicacion.FormularioProgreso == null) {
                                                                        Aplicacion.FormularioProgreso = new Lui.Forms.ProgressForm();
                                                                        Aplicacion.FormularioProgreso.Show();
                                                                }
                                                                if (Aplicacion.FormularioProgreso.InvokeRequired) {
                                                                        MethodInvoker Mi = delegate { Aplicacion.FormularioProgreso.MostrarProgreso(Operaciones, Prog); };
                                                                        Aplicacion.FormularioProgreso.Invoke(Mi);
                                                                } else {
                                                                        Aplicacion.FormularioProgreso.MostrarProgreso(Operaciones, Prog);
                                                                }
                                                        } else {
                                                                if (Aplicacion.FormularioPrincipal.InvokeRequired) {
                                                                        MethodInvoker Mi = delegate { Aplicacion.FormularioPrincipal.ShowProgress(Prog); };
                                                                        Aplicacion.FormularioPrincipal.Invoke(Mi);
                                                                } else {
                                                                        Aplicacion.FormularioPrincipal.ShowProgress(Prog);
                                                                }
                                                        }
                                                }

                                                if (Prog.IsDone || Prog.IsRunning == false) {
                                                        if (Operaciones.Contains(Prog))
                                                                Operaciones.Remove(Prog);

                                                        if (Operaciones.Count == 0) {
                                                                // Si no quedan más operaciones en progreso, deshecho el formulario
                                                                if (Aplicacion.FormularioProgreso != null) {
                                                                        try {
                                                                                Aplicacion.FormularioProgreso.Close();
                                                                                Aplicacion.FormularioProgreso.Dispose();
                                                                                Aplicacion.FormularioProgreso = null;
                                                                        } catch {
                                                                                // Nada
                                                                        }
                                                                }
                                                        }
                                                }
                                                System.Windows.Forms.Application.DoEvents();
                                                break;
                                        case Lfx.RunTimeServices.IpcEventArgs.EventTypes.Information:
                                                switch (e.Verb) {
                                                        case "HINT":
                                                                if (Aplicacion.FormularioPrincipal != null)
                                                                        Aplicacion.FormularioPrincipal.MostrarAyuda(e.Arguments[1].ToString(), e.Arguments[0].ToString());
                                                                break;
                                                        case "TOAST":
                                                                Lui.Forms.MessageBox.Show(e.Arguments[0].ToString(), e.Arguments[1].ToString());
                                                                break;
                                                        case "ITEMFOCUS":
                                                                if (Aplicacion.FormularioPrincipal != null) {
                                                                        if (e.Arguments.Length >= 3 && e.Arguments[0].ToString() == "TABLE") {
                                                                                string Tabla = e.Arguments[1].ToString();
                                                                                int ItemId = e.Arguments[2].ToString().ParseInt();
                                                                                Aplicacion.FormularioPrincipal.MostrarItem(Tabla, ItemId);
                                                                        }
                                                                }
                                                                break;
                                                }
                                                break;
                                }
                        }
                }

                /// <summary>
                /// Inicia el acceso al almacén de datos.
                /// </summary>
                private static void IniciarDatos()
                {
                        do {
                                Lfx.Types.OperationResult Res = AbrirConexion();

                                // Si no pudo conectar, muestro la configuración de la base de datos
                                // Si hay DSN, muestro el error
                                if (Res.Success == false) {
                                        bool MostrarConfig = true;

                                        if (Lfx.Workspace.Master.CurrentConfig.ReadLocalSettingString("Data", "DataSource", null) != null) {
                                                using (Config.ErrorConexion FormError = new Config.ErrorConexion()) {
                                                        if (Res.Message.IndexOf("Unable to connect to any of the specified MySQL hosts") >= 0) {
                                                                if (Lfx.Workspace.Master.ConnectionParameters.ServerName.ToLowerInvariant() == "localhost") {
                                                                        string TipoServidor = "";
                                                                        switch (Lfx.Data.DatabaseCache.DefaultCache.AccessMode) {
                                                                                case Lfx.Data.AccessModes.MySql:
                                                                                        TipoServidor = "MariaDB/MySQL";
                                                                                        break;
                                                                                case Lfx.Data.AccessModes.MSSql:
                                                                                        TipoServidor = "SQL Server";
                                                                                        break;
                                                                                case Lfx.Data.AccessModes.Npgsql:
                                                                                        TipoServidor = "PostgreSQL";
                                                                                        break;
                                                                                case Lfx.Data.AccessModes.Oracle:
                                                                                        TipoServidor = "Oracle";
                                                                                        break;
                                                                        }
                                                                        FormError.Ayuda = @"No se puede conectar con el servidor local. Verifique que el servidor " + TipoServidor + @" se encuentra instalado y funcionando en el equipo.
Si necesita información sobre cómo instalar o configurar un servidor SQL para Lázaro, consulte la ayuda en línea en www.lazarogestion.com";
                                                                } else {
                                                                        FormError.Ayuda = "No se puede conectar con el servidor remoto. Verifique que el servidor en el equipo remoto '" + Lfx.Workspace.Master.ConnectionParameters.ServerName + @"' se encuentre funcionando y que su conexión de red esté activa.";
                                                                }
                                                        } else if (Res.Message.IndexOf("Access denied for user") >= 0) {
                                                                FormError.Ayuda = "El servidor impidió el acceso debido a que el nombre de usuario o la contraseña son incorrectos. Haga clic en 'Configurarción' y luego en 'Configuración avanzada' y verifique la configuración proporcionada.";
                                                        } else if (Res.Message.IndexOf("Debe preparar el almacén") >= 0) {
                                                                FormError.Ayuda = "Debe preparar el servidor SQL para que Lázaro pueda utilizarlo como almacén de datos.";
                                                        } else {
                                                                FormError.Ayuda = "No se dispone de información extendida sobre el error. Por favor lea el mensaje de error original a continuación:";
                                                        }

                                                        FormError.ErrorOriginal = Res.Message;

                                                        switch (FormError.ShowDialog()) {
                                                                case DialogResult.Cancel:
                                                                        MostrarConfig = false;
                                                                        System.Environment.Exit(0);
                                                                        break;

                                                                case DialogResult.Retry:
                                                                        MostrarConfig = false;
                                                                        break;

                                                                case DialogResult.Yes:
                                                                        MostrarConfig = true;
                                                                        break;
                                                        }
                                                }
                                        }

                                        if (MostrarConfig) {
                                                using (Config.Inicial ConfigBD = new Config.Inicial()) {
                                                        if (ConfigBD.ShowDialog() == DialogResult.Cancel) {
                                                                MostrarConfig = false;
                                                                System.Environment.Exit(0);
                                                        }
                                                }
                                        }
                                } else {
                                        break;
                                }
                        } while (true);

                        // Habilito el gestor de configuración
                        Lbl.Sys.Config.Actual = new Lbl.Sys.Configuracion.Global();
                        Lbl.Sys.Config.Cargar();

                        // Habilito la recuperación de conexiones
                        Lfx.Workspace.Master.MasterConnection.EnableRecover = true;
                }

                /// <summary>
                /// Inicia una conexión con la base de datos y verifica si la versión de la la misma es la última disponible. En caso contrario la actualiza.
                /// </summary>
                internal static Lfx.Types.OperationResult AbrirConexion()
                {
                        Lfx.Types.OperationResult iniciarReturn = new Lfx.Types.SuccessOperationResult();

                        //Si el servidor SQL es esta misma PC, intento iniciar el servidor
                        if (Lfx.Environment.SystemInformation.Platform == Lfx.Environment.SystemInformation.Platforms.Windows && Lfx.Workspace.Master.ConnectionParameters.ServerName.ToUpperInvariant() == "LOCALHOST") {
                                switch (Lfx.Data.DatabaseCache.DefaultCache.AccessMode) {
                                        case Lfx.Data.AccessModes.MySql:
                                                Lfx.Environment.Shell.Execute("net", "start mysql", ProcessWindowStyle.Hidden, true);
                                                break;
                                        case Lfx.Data.AccessModes.Npgsql:
                                                // FIXME: detectar el nombre del servicio.
                                                Lfx.Environment.Shell.Execute("net", "start postgresql-9.0", ProcessWindowStyle.Hidden, true);
                                                break;
                                }
                        }

                        try {
                                Lfx.Workspace.Master.MasterConnection.Open();
                        } catch (Exception ex) {
                                return new Lfx.Types.FailureOperationResult(ex.Message);
                        }

                        if (Lfx.Workspace.Master.IsPrepared() == false) {
                                using (Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog(@"Aparentemente es la primera vez que utiliza este almacén de datos. Antes de poder utilizarlo debe prepararlo con una carga inicial de datos.
Responda 'Sí' sólamente si es la primera vez que utiliza Lázaro o está restaurando desde una copia de seguridad.", @"¿Desea preparar el almacén de datos?")) {
                                        Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                                        if (Pregunta.ShowDialog() == DialogResult.OK) {
                                                Lfx.Types.OperationResult Res;
                                                using (var Connection = Lfx.Workspace.Master.GetNewConnection("Preparar almacén de datos") as Lfx.Data.Connection) {
                                                        Connection.RequiresTransaction = false;
                                                        Res = Lfx.Workspace.Master.Prepare(null);
                                                }
                                                if (Res.Success == false)
                                                        return Res;
                                        } else {
                                                return new Lfx.Types.FailureOperationResult("Debe preparar el almacén de datos.");
                                        }
                                }
                        }

                        // Configuro el nivel de aislación predeterminado
                        // FIXME: no puedo obtener esto de la BD (System.Data.IsolationLevel)(Enum.Parse(typeof(System.Data.IsolationLevel), Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Datos.Aislacion", "Serializable")));
                        Lfx.Data.DatabaseCache.DefaultCache.DefaultIsolationLevel = System.Data.IsolationLevel.Serializable;

                        return iniciarReturn;
                }

                /// <summary>
                /// Inicia la interfaz gráfica del programa.
                /// </summary>
                private static Lfx.Types.OperationResult IniciarGui()
                {
                        int Configurado = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Configurado", 0);
                        if ((Configurado == 0 && Lbl.Sys.Config.Empresa.ClaveTributaria == null) || string.IsNullOrEmpty(Lbl.Sys.Config.Empresa.Nombre)) {
                                Config.Preferencias FormConfig = new Config.Preferencias();
                                FormConfig.PrimeraVez = true;
                                if (FormConfig.ShowDialog() != DialogResult.OK)
                                        Ejecutor.Exec("QUIT");
                        }

                        System.DateTime FechaServidor = System.Convert.ToDateTime(Lfx.Workspace.Master.MasterConnection.FirstRowFromSelect("SELECT NOW()")[0]);
                        System.TimeSpan Diferencia = FechaServidor - System.DateTime.Now;
                        if (Math.Abs(Diferencia.TotalMinutes) > 10) {
                                string DiferenciaExplicada = "";
                                if (Math.Abs(Diferencia.TotalDays) >= 2)
                                        DiferenciaExplicada = Math.Ceiling(Math.Abs(Diferencia.TotalDays)).ToString() + " días";
                                else if (Math.Abs(Diferencia.TotalHours) >= 2)
                                        DiferenciaExplicada = Math.Ceiling(Math.Abs(Diferencia.TotalHours)).ToString() + " horas";
                                else
                                        DiferenciaExplicada = Math.Ceiling(Math.Abs(Diferencia.TotalMinutes)).ToString() + " minutos";

                                Lfx.Workspace.Master.RunTime.Toast("Existe una diferencia de " + DiferenciaExplicada + " entre el reloj del servidor SQL y el reloj de este equipo. Es necesario que revise y ajuste el reloj de ambos equipos a la brevedad.", "Error de fecha y hora");
                        }


                        // Si el administrador tiene la contraseña predeterminada y aquí entro siempre como administrador
                        // o todavía no entré nunca, ingreso directamente sin pedir contraseña.
                        int UltimoUsuario = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Ingreso.UltimoUsuario", 1);
                        if(UltimoUsuario == 1) {
                                Lbl.Personas.Usuario Usu = new Lbl.Personas.Usuario(Lfx.Workspace.Master.MasterConnection, 1);
                                if (Usu.ContrasenaValida("admin"))
                                        Lbl.Sys.Config.Actual.UsuarioConectado = new Lbl.Sys.Configuracion.UsuarioConectado(Usu);
                        }

                        if (Lbl.Sys.Config.Actual.UsuarioConectado.Id == 0) {
                                using (Lazaro.WinMain.Misc.Ingreso FormIngreso = new Lazaro.WinMain.Misc.Ingreso()) {
                                        FormIngreso.Connection = Lfx.Workspace.Master.MasterConnection;
                                        FormIngreso.ShowDialog();
                                }
                        }


                        if (Lbl.Sys.Config.Actual.UsuarioConectado.Id > 0) {
                                if (Lfx.Workspace.Master.SlowLink == false && Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Backup.Tipo", "0") == "2") {
                                        string FechaActual = System.DateTime.Now.ToString("yyyy-MM-dd");
                                        string FechaBackup = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Backup.Ultimo", "");
                                        if (FechaActual != FechaBackup) {
                                                int Articulos = Lfx.Workspace.Master.MasterConnection.FieldInt("SELECT COUNT(id_articulo) FROM articulos");
                                                if (Articulos > 0) {
                                                        //Hago un backup automático, una vez por día, siempre que haya al menos 1 artículo en la BD
                                                        //Esto es para evitar hacer backup de una BD vacía
                                                        Ejecutor.Exec("BACKUP NOW");
                                                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Backup.Ultimo", FechaActual);
                                                }
                                        }
                                }

                                // Mostrar qué hay de nuevo
                                string FechaWhatsnew = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Usuario." + Lbl.Sys.Config.Actual.UsuarioConectado.Id.ToString() + ".Whatsnew.Ultimo", "firsttime");
                                if (FechaWhatsnew == "firsttime") {
                                        // Primera vez que entra. No muestro qué hay de nuevo (TODO: pero podría darle una bienvenida)
                                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Usuario." + Lbl.Sys.Config.Actual.UsuarioConectado.Id.ToString() + ".Whatsnew.Ultimo", System.DateTime.Now.ToString("yyyy-MM-dd"));
                                } else {
                                        // Veo si hay novedades para mostrar
                                        // string FechaWhatsnewOriginal = FechaWhatsnew;
                                        System.IO.StreamReader Whatsnew = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("Lazaro.whatsnew.txt"));
                                        System.Text.StringBuilder Mostrar = null;
                                        bool Mostrando = false;
                                        while (Whatsnew.EndOfStream == false) {
                                                string Linea = Whatsnew.ReadLine();
                                                if (Linea.Length > 4 && Linea.Substring(0, 4) == "*** ") {
                                                        string FechaLinea = Linea.Substring(4, Linea.Length - 4);
                                                        if (string.Compare(FechaLinea, FechaWhatsnew) > 0) {
                                                                FechaWhatsnew = FechaLinea;
                                                                Linea = Lfx.Types.Parsing.ParseDate(FechaLinea).Value.ToString(Lfx.Types.Formatting.DateTime.LongDatePattern) + ":";
                                                                Mostrando = true;
                                                        }
                                                }

                                                if (Mostrando) {
                                                        if (Mostrar == null) {
                                                                Mostrar = new System.Text.StringBuilder();
                                                                Mostrar.AppendLine("Por favor tómese un momento para leer sobre las novedades incorporadas recientemente en Lázaro:");
                                                                Mostrar.AppendLine("");
                                                        }
                                                        Mostrar.AppendLine(Linea.Replace("* ", "• "));
                                                }
                                        }
                                        Whatsnew.BaseStream.Close();
                                        Whatsnew.Close();
                                        if (Mostrar != null && Mostrar.Length > 0) {
                                                Lfx.Workspace.Master.RunTime.Toast(Mostrar.ToString(), "Novedades");
                                                Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Usuario." + Lbl.Sys.Config.Actual.UsuarioConectado.Id.ToString(), "Whatsnew.Ultimo", FechaWhatsnew);
                                        }
                                }

                                InicarServidorFiscal();

                                // Mostrar el formulario
                                Lfx.Workspace.Master.MainForm = new Principal.Inicio();
                                Aplicacion.FormularioPrincipal.Show();
                                if (FechaWhatsnew == "firsttime") {
                                        Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("¡Hola! ¿Le gustaría ver una página sencilla con un poco de información sobre cómo utilizar Lázaro?", "Primeros pasos");
                                        Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                                        if (Pregunta.ShowDialog() == DialogResult.OK)
                                                Help.ShowHelp(Aplicacion.FormularioPrincipal, "http://www.lazarogestion.com/soporte/primeros-pasos");
                                }
                                Application.Run(Aplicacion.FormularioPrincipal);
                        }

                        return new Lfx.Types.SuccessOperationResult();
                }

                /// <summary>
                /// Iniciar un servidor fiscal, si esta es una estación fiscal y si no hay uno iniciado
                /// </summary>
                public static void InicarServidorFiscal()
                {
                        // Buscar si algún punto de venta fiscal corresponde a este equipo
                        foreach (var Pv in Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero.Values) {
                                if (Pv.Tipo == Lbl.Comprobantes.TipoPv.ControladorFiscal && Pv.Estacion == Lfx.Environment.SystemInformation.MachineName) {
                                        // Buscar un servidor fiscal ejecutándose
                                        Process[] ServidoresFiscales = Process.GetProcessesByName("ServidorFiscal.exe");
                                        if (ServidoresFiscales.Length == 0) {
                                                // Si no hay ninguno, lo inicio
                                                Lfx.Workspace.Master.RunTime.Execute("FISCAL INICIAR");
                                        }
                                        break;
                                }
                        }
                }



                /// <summary>
                /// Envía datos anónimos sobre el equipo en el que se está ejecutando Lázaro.
                /// </summary>
                [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
                public static void EnviarEstadisticas()
                {
                        try {
                                string[] Vars = new string[] {
                                                                "estacion=" + System.Uri.EscapeUriString(System.Environment.MachineName),
                                                                "so=" + System.Uri.EscapeUriString(Lfx.Environment.SystemInformation.PlatformName),
                                                                "runtime=" + System.Uri.EscapeUriString(Lfx.Environment.SystemInformation.RuntimeName),
                                                                "empresa=" + System.Uri.EscapeUriString(Lbl.Sys.Config.Empresa.Nombre),
                                                                "email=" + System.Uri.EscapeUriString(Lbl.Sys.Config.Empresa.Email),
                                                                "canal=" + System.Uri.EscapeUriString(Lfx.Updates.Updater.Master != null ? Lfx.Updates.Updater.Master.Channel : ""),
                                                                "version=" + System.Uri.EscapeUriString(Aplicacion.Version()),
                                                                "cpu=" + System.Uri.EscapeUriString(Lfx.Environment.SystemInformation.ProcessorName),
                                                                "server=" + System.Uri.EscapeUriString(Lfx.Workspace.Master.ServerVersion),
                                                                "pais=" + System.Uri.EscapeUriString(Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Pais", "0")),
                                                                "loc=" + System.Uri.EscapeUriString(Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Localidad", "0"))
                                                        };
                                System.Net.WebRequest WebRequest = System.Net.WebRequest.Create(new System.Uri("http://www.lazarogestion.com/stats/index.php"));
                                WebRequest.ContentType = "application/x-www-form-urlencoded";
                                WebRequest.Method = "POST";
                                byte[] PostData = System.Text.Encoding.Default.GetBytes(string.Join("&", Vars));
                                WebRequest.ContentLength = PostData.Length;
                                using (System.IO.Stream ReqStream = WebRequest.GetRequestStream()) {
                                        //Escribimos los datos
                                        ReqStream.Write(PostData, 0, PostData.Length);
                                        ReqStream.Close();
                                }
                        } catch {
                                // Nada
                        }
                }


                private static void ThreadExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
                {
                        GenericExceptionHandler(e.Exception);
                }

                private static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs args)
                {
                        GenericExceptionHandler(args.ExceptionObject as Exception);
                }

                private static void GenericExceptionHandler(Exception ex)
                {
                        if (ex is System.Drawing.Printing.InvalidPrinterException) {
                                KnownExceptionHandler(ex, null);
                        } else if (ex.Source == "MySql.Data") {
                                Exception ex2 = ex;
                                bool Found = false;
                                while (ex2 != null) {
                                        if (string.Compare(ex2.Message, "Reading from the stream has failed.", true) == 0
                                                || string.Compare(ex2.Message, "Unable to connect to any of the specified MySQL hosts.", true) == 0
                                                || string.Compare(ex2.Message, "Connection unexpectedly terminated.", true) == 0
                                                || string.Compare(ex2.Message, "Timeout expired.", true) == 0
                                                || string.Compare(ex2.Message, "Connection must be valid and open.", true) == 0
                                                || string.Compare(ex2.Message, "No se pueden leer los datos de la conexión de transporte: Se ha forzado la interrupción de una conexión existente por el host remoto.", true) == 0) {
                                                KnownExceptionHandler(ex, "Error de comunicación con el servidor.");
                                                Found = true;
                                                break;
                                        } else if (string.Compare(ex2.Message, "Lock wait timeout exceeded; try restarting transaction", true) == 0) {
                                                KnownExceptionHandler(ex, "El servidor está ocupado. Intente nuevamente más tarde.");
                                                Found = true;
                                                break;
                                        }
                                        ex2 = ex2.InnerException;
                                }
                                if (Found == false) {
                                        UnknownExceptionHandler(ex);
                                }
                        } else if (ex.Message.IndexOf("El servidor RPC no está disponible", StringComparison.CurrentCultureIgnoreCase) >= 0
                                || ex.Message.IndexOf("RPC server unavailable", StringComparison.CurrentCultureIgnoreCase) >= 0) {
                                KnownExceptionHandler(ex, "La impresora no está disponible");
                        } else if (ex is Lfx.Types.Exceptions.AccessDeniedException) {
                                KnownExceptionHandler(ex, ex.Message);
                        } else {
                                UnknownExceptionHandler(ex);
                        }
                }


                /// <summary>
                /// Manejador de excepciones conocidas. Presenta una ventana con el error. Se utiliza para excepciones como InvalidPrinterException.
                /// No genera un reporte por correo electrónico.
                /// </summary>
                /// <param name="ex">La excepción a reportar.</param>
                /// <param name="mensajeDescriptivo">Una mejor descripción de la excepción que el mensaje orginal.</param>
                public static void KnownExceptionHandler(Exception ex, string mensajeDescriptivo)
                {
                        Log.Error(mensajeDescriptivo, ex);

                        Errores.ExcepcionControlada FormularioError = new Errores.ExcepcionControlada();
                        if (mensajeDescriptivo == null)
                                FormularioError.EtiquetaDescripcion.Text = ex.Message;
                        else
                                FormularioError.EtiquetaDescripcion.Text = mensajeDescriptivo;
                        FormularioError.EtiquetaMasInformacion.Text = ex.ToString();
                        FormularioError.Show();
                        FormularioError.Refresh();
                }

                /// <summary>
                /// Manejador de excepciones desconocidas. Presenta una ventana con el error y envía un informe por correo electrónico.
                /// </summary>
                /// <param name="ex">La excepción a reportar.</param>
                [EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
                private static void UnknownExceptionHandler(Exception ex)
                {
                        Log.Error(ex.Message, ex);

                        Errores.ExcepcionNoControlada FormularioError = new Errores.ExcepcionNoControlada();
                        FormularioError.Text = ex.Message;
                        FormularioError.Show();
                        FormularioError.Refresh();
                        System.Windows.Forms.Application.DoEvents();

                        System.Text.StringBuilder Texto = new System.Text.StringBuilder();
                        Texto.AppendLine("Lugar   : " + ex.Source);
                        try {
                                System.Diagnostics.StackTrace Traza = new System.Diagnostics.StackTrace(ex, true);
                                Texto.AppendLine("Línea   : " + Traza.GetFrame(0).GetFileLineNumber());
                                Texto.AppendLine("Columna : " + Traza.GetFrame(0).GetFileColumnNumber());
                        } catch {
                                // Nada
                        }
                        Texto.AppendLine("Equipo  : " + Lfx.Environment.SystemInformation.MachineName);
                        Texto.AppendLine("Plataf. : " + Lfx.Environment.SystemInformation.PlatformName);
                        Texto.AppendLine("Runtime : " + Lfx.Environment.SystemInformation.RuntimeName);
                        Texto.AppendLine("Servidor: " + Lfx.Workspace.Master.ServerVersion);
                        if (ex.HelpLink != null)
                                Texto.AppendLine("Ayuda   : " + ex.HelpLink);
                        if (ex.Source != null)
                                Texto.AppendLine("Origen  : " + ex.Source);
                        if (ex.Data != null) {
                                try {
                                        Texto.AppendLine("Datos   : ");
                                        foreach (KeyValuePair<object, object> Dt in ex.Data) {
                                                Texto.AppendLine("  " + Dt.Key.ToString() + ": " + Dt.Value.ToString());
                                        }
                                } catch (Exception xx) {
                                        Texto.AppendLine("          " + xx.Message);
                                }
                        }
                        Texto.AppendLine("Excepción no controlada: " + ex.ToString());
                        Texto.AppendLine("");

                        Texto.AppendLine("Lazaro versión " + System.Diagnostics.FileVersionInfo.GetVersionInfo(Lfx.Environment.Folders.ApplicationFolder + "Lazaro.exe").ProductVersion + " del " + new System.IO.FileInfo(Lfx.Environment.Folders.ApplicationFolder + "Lazaro.exe").LastWriteTime.ToString(Lfx.Types.Formatting.DateTime.FullDateTimePattern));
                        System.IO.DirectoryInfo Dir = new System.IO.DirectoryInfo(Lfx.Environment.Folders.ApplicationFolder);
                        foreach (System.IO.FileInfo DirItem in Dir.GetFiles("*.dll")) {
                                Texto.AppendLine(DirItem.Name + " versión " + System.Diagnostics.FileVersionInfo.GetVersionInfo(DirItem.FullName).ProductVersion + " del " + new System.IO.FileInfo(DirItem.FullName).LastWriteTime.ToString(Lfx.Types.Formatting.DateTime.FullDateTimePattern));
                        }

                        Dir = new System.IO.DirectoryInfo(Lfx.Environment.Folders.ComponentsFolder);
                        foreach (System.IO.FileInfo DirItem in Dir.GetFiles("*.dll")) {
                                Texto.AppendLine(DirItem.Name + " versión " + System.Diagnostics.FileVersionInfo.GetVersionInfo(DirItem.FullName).ProductVersion + " del " + new System.IO.FileInfo(DirItem.FullName).LastWriteTime.ToString(Lfx.Types.Formatting.DateTime.FullDateTimePattern));
                        }

                        Texto.AppendLine("Traza:");

                        MailMessage Mensaje = new MailMessage();
                        Mensaje.To.Add(new MailAddress("error@lazarogestion.com"));
                        Mensaje.From = new MailAddress(Lbl.Sys.Config.Empresa.Email, Lbl.Sys.Config.Actual.UsuarioConectado.Nombre + " en " + Lbl.Sys.Config.Empresa.Nombre);
                        try {
                                // No sé por qué, pero una vez dio un error al poner el asunto
                                Mensaje.Subject = ex.Message;
                        } catch {
                                Mensaje.Subject = "Excepción no controlada";
                                Texto.Insert(0, ex.Message + System.Environment.NewLine);
                        }

                        Mensaje.Body = Texto.ToString();

                        SmtpClient Cliente = new SmtpClient("mail.lazarogestion.com");
                        try {
                                Cliente.Send(Mensaje);
                                FormularioError.EtiquetaDescripcion.Text = "Se envió un reporte de error. Haga clic en Continuar.";
                        } catch (Exception ExSnd) {
                                FormularioError.EtiquetaDescripcion.Text = "No se puedo enviar el reporte de error (" + ExSnd.Message + "). Haga clic en Continuar.";
                        }

                        FormularioError.BotonCerrar.Visible = true;
                        FormularioError.BotonCerrar.Enabled = true;
                        FormularioError.Refresh();
                        System.Windows.Forms.Application.DoEvents();
                }


                public static Principal.Inicio FormularioPrincipal
                {
                        get
                        {
                                if (Lfx.Workspace.Master == null)
                                        return null;
                                else
                                        return Lfx.Workspace.Master.MainForm as Principal.Inicio;
                        }
                }
        }
}