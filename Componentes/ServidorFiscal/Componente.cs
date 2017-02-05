using System;
using System.Net.Mail;
using System.Windows.Forms;
using System.Data;

namespace ServidorFiscal
{
        /// <summary>
        /// La función Try se usa para decidir si cargar el componente o no.
        /// </summary>
        public class Try : Lfx.Components.TryFunction
        {
                public override object Run()
                {
                        return new Lfx.Types.SuccessOperationResult();
                }
        }

        /// <summary>
        /// Servidor de Impresora Fiscal
        /// </summary>
        public class ServidorFiscal : Lfx.Components.Function
        {
                public Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Impresora Impresora;
                private Lbl.Comprobantes.PuntoDeVenta m_PuntoDeVenta = null;
                private System.Timers.Timer Programador;
                private System.Timers.Timer Watchdog;
                private System.DateTime Watchdog_LastOp = System.DateTime.Now;
                private Forms.Estado FormEstado = null;
                public Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ImpresoraEventArgs UltimoEvento;

                public ServidorFiscal()
                {
                        this.FunctionType = Lfx.Components.FunctionTypes.Loadable;
                }

                public override object Run(bool wait)
                {
                        try {
                                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ThreadExceptionHandler);
                                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionHandler);
                                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                        } catch {
                                // Esto puede dar una excepción
                                // "El modo de excepción del subproceso no se puede cambiar una vez que se creen Controles en el subproceso."
                                // Simplemente la ignoramos.
                        }

                        Lbl.Sys.Config.Actual.UsuarioConectado = new Lbl.Sys.Configuracion.UsuarioConectado(new Lbl.Personas.Usuario(Lfx.Workspace.Master.MasterConnection, 1));
                        FormEstado = new Forms.Estado();
                        FormEstado.ServidorAsociado = this;

                        try {
                                using (System.Diagnostics.Process Yo = System.Diagnostics.Process.GetCurrentProcess()) {
                                        Yo.PriorityClass = System.Diagnostics.ProcessPriorityClass.High;
                                }
                        } catch (Exception Ex) {
                                System.Console.WriteLine("ServidorFiscal: Imposible elevar la prioridad del proceso (" + Ex.ToString() + "). Continuando de todos modos.");
                                //Seguramente no me permitió cambiar la prioridad por ser un usuario sin privilegios.
                                //No es crítico, así que continúo sin problema
                        }

                        Impresora = new Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Impresora(Lfx.Workspace.Master);

                        Lfx.Workspace.Master.RunTime.IpcEvent += new Lfx.RunTimeServices.IpcEventHandler(Componente_IpcEvent);
                        Impresora.Notificacion += new Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.NotificacionEventHandler(ConFiscal_EventoConexion);

                        Programador = new System.Timers.Timer(1000);
                        Programador.Elapsed += new System.Timers.ElapsedEventHandler(EventoProgramador);
                        Programador.Start();

                        Watchdog = new System.Timers.Timer(60000);
                        Watchdog.Elapsed += new System.Timers.ElapsedEventHandler(EventoWatchdog);
                        Watchdog.Start();

                        if (wait) {
                                while (Impresora.EstadoServidor != Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Apagando
                                        && Impresora.EstadoServidor != Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Reiniciando) {
                                        System.Threading.Thread.Sleep(100);
                                        System.Windows.Forms.Application.DoEvents();
                                }

                                if (Impresora.EstadoServidor == Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Reiniciando)
                                        this.End(true);
                                else if (Impresora.EstadoServidor == Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Apagando)
                                        this.End(false);
                        }

                        return null;
                }


                public Lbl.Comprobantes.PuntoDeVenta PuntoDeVenta
                {
                        get
                        {
                                if (m_PuntoDeVenta == null) {
                                        int NumeroPv = this.Impresora.Connection.FieldInt("SELECT id_pv FROM pvs WHERE UPPER(estacion)='" + Lfx.Environment.SystemInformation.MachineName.ToUpperInvariant() + "' AND tipo=2 AND id_sucursal=" + Lbl.Sys.Config.Empresa.SucursalActual.Id.ToString());
                                        if (NumeroPv > 0) {
                                                m_PuntoDeVenta = new Lbl.Comprobantes.PuntoDeVenta(this.Impresora.Connection, NumeroPv);
                                                if (m_PuntoDeVenta.Existe == false)
                                                        m_PuntoDeVenta = null;
                                                this.Impresora.PuntoDeVenta = m_PuntoDeVenta;
                                        }
                                }

                                return m_PuntoDeVenta;
                        }
                        set
                        {
                                m_PuntoDeVenta = value;
                        }
                }


                public void ConFiscal_EventoConexion(object sender, Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ImpresoraEventArgs e)
                {
                        UltimoEvento = e;
                        switch (e.EventType) {
                                case Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ImpresoraEventArgs.EventTypes.Inicializada:
                                        FormEstado.MostrarEstado("Inicializado");
                                        break;
                                case Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ImpresoraEventArgs.EventTypes.Estado:
                                        FormEstado.MostrarEstado(e.MensajeEstado);
                                        break;
                                case Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ImpresoraEventArgs.EventTypes.InicioImpresion:
                                        FormEstado.MostrarEstado("Se inició el proceso de impresión");
                                        break;
                                case Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ImpresoraEventArgs.EventTypes.FinImpresion:
                                        FormEstado.MostrarEstado("Finalizó el proceso de impresión");
                                        break;
                        }
                }

                public void Componente_IpcEvent(object sender, ref Lfx.RunTimeServices.IpcEventArgs e)
                {
                        if (e.Destination == "servidorfiscal") {
                                switch (e.Verb) {
                                        case "END":
                                                Impresora.EstadoServidor = Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Apagando;
                                                break;

                                        case "REBOOT":
                                                Impresora.EstadoServidor = Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Reiniciando;
                                                break;
                                }
                        }
                }


                private void EventoWatchdog(object source, System.Timers.ElapsedEventArgs e)
                {
                        //Hace un minuto que no se dispara un evento. Reinicio el servidor fiscal.
                        if (System.DateTime.Now > Watchdog_LastOp.AddMinutes(5)) {
                                System.IO.BinaryWriter wr = new System.IO.BinaryWriter(new System.IO.FileStream(Lfx.Environment.Folders.ApplicationDataFolder + "watchdog.log", System.IO.FileMode.Append));
                                wr.Write("ServidorFiscal: REBOOT " + System.DateTime.Now.ToString() + System.Environment.NewLine);
                                wr.Close();

                                Impresora.EstadoServidor = Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Reiniciando;
                        }
                }

                private int PV
                {
                        get
                        {
                                if (this.PuntoDeVenta == null)
                                        return 0;
                                else
                                        return this.PuntoDeVenta.Numero;
                        }
                }
              
                private int PVenta
                {
                        get
                        {
                                if (this.PuntoDeVenta == null)
                                        return 0;
                                else
                                        return this.PuntoDeVenta.Id;
                        }
                }
                
                private void EventoProgramador(object source, System.Timers.ElapsedEventArgs e)
                {
                        Programador.Stop();
                        Watchdog_LastOp = System.DateTime.Now;

                        //Busco un PV que corresponda a esta terminal
                        if (this.PV == 0) {
                                Programador.Start();
                                return;
                        }

                        Watchdog.Stop();
                        try {
                                using (IDbTransaction Trans = this.Impresora.Connection.BeginTransaction()) {
                                        var Actualizar = new qGen.Update("pvs", new qGen.Where("id_pv", this.PVenta));
                                        Actualizar.ColumnValues.AddWithValue("lsa", qGen.SqlFunctions.Now);
                                        this.Impresora.Connection.Execute(Actualizar);
                                        Trans.Commit();
                                }
                        } catch {
                                // Nada
                                }

                        Lfx.Services.Task ProximaTarea = Lfx.Workspace.Master.DefaultScheduler.GetNextTask("fiscal" + this.PV.ToString());
                        if (ProximaTarea != null) {
                                string Comando = ProximaTarea.Command;
                                string SubComando = Lfx.Types.Strings.GetNextToken(ref Comando, " ").Trim().ToUpper();

                                Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta Res;
                                switch (SubComando) {
                                        case "REBOOT":
                                                FormEstado.MostrarEstado("Reiniciando...");
                                                Impresora.EstadoServidor = Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Reiniciando;
                                                //this.End(true);
                                                break;

                                        case "END":
                                                FormEstado.MostrarEstado("Cerrando...");
                                                Impresora.EstadoServidor = Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.EstadoServidorFiscal.Apagando;
                                                //this.End(false);
                                                break;

                                        case "CIERRE":
                                                FormEstado.MostrarEstado("Imprimiendo cierre...");
                                                Res = Impresora.ObtenerEstadoImpresora();
                                                if (Res.EstadoFiscal.DocumentoFiscalAbierto) {
                                                        Res = Impresora.CancelarDocumentoFiscal();
                                                        System.Threading.Thread.Sleep(500);
                                                } else if (Res.Error == Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ErroresFiscales.Ok) {
                                                        string SubComandoCierre = Lfx.Types.Strings.GetNextToken(ref Comando, " ").Trim().ToUpper();
                                                        Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta ResultadoCierre = Impresora.Cierre(SubComandoCierre, true);
                                                        if (SubComandoCierre == "Z" && ResultadoCierre.Error == Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ErroresFiscales.Ok) {
                                                                //Si hizo un cierre Z correctamente, actualizo la variable LCZ
                                                                using (IDbTransaction Trans = this.Impresora.Connection.BeginTransaction()) {
                                                                        qGen.Update Actualizar = new qGen.Update("pvs", new qGen.Where("id_pv", this.PVenta));
                                                                        Actualizar.ColumnValues.AddWithValue("ultimoz", qGen.SqlFunctions.Now);
                                                                        this.Impresora.Connection.Execute(Actualizar);
                                                                        Trans.Commit();
                                                                }
                                                        }
                                                        if (ResultadoCierre.Error != Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ErroresFiscales.Ok) {
                                                                MostrarErrorFiscal(ResultadoCierre);
                                                        }
                                                        System.Threading.Thread.Sleep(100);
                                                }
                                                break;

                                        case "CANCELAR":
                                                FormEstado.MostrarEstado("Cancelando comprobante...");
                                                string ItemCancelar = Lfx.Types.Strings.GetNextToken(ref Comando, " ").Trim().ToUpper();
                                                switch (ItemCancelar) {
                                                        case "FISCAL":
                                                                Impresora.CancelarDocumentoFiscal();
                                                                System.Threading.Thread.Sleep(500);
                                                                break;
                                                }
                                                break;

                                        case "IMPRIMIR":
                                                FormEstado.MostrarEstado("Imprimiendo...");
                                                int IdFactura = Lfx.Types.Parsing.ParseInt(Lfx.Types.Strings.GetNextToken(ref Comando, " ").Trim());
                                                Res = Impresora.ObtenerEstadoImpresora();

                                                if (Res.EstadoFiscal.DocumentoFiscalAbierto) {
                                                        Res = Impresora.CancelarDocumentoFiscal();
                                                        System.Threading.Thread.Sleep(500);
                                                }

                                                if (Res.HacerCierreZ) {
                                                        Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("Hacer Cierre Z", "Es obligatorio hacer un Cierre Z antes de continuar. ¿Desea hacer el cierre ahora?");
                                                        Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;

                                                        if (Pregunta.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                                                                // Hago el cierre, y Res es el resultado del cierre
                                                                Res = Impresora.Cierre("Z", true);
                                                                System.Threading.Thread.Sleep(500);
                                                        } else {
                                                                // No quiso hacer el cierre. Devuelvo un error
                                                                Programador.Start();
                                                                Watchdog.Start();
                                                                return;
                                                        }
                                                }

                                                if (Res.Error == Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ErroresFiscales.Ok)
                                                        Res = Impresora.ImprimirComprobante(IdFactura);

                                                if (Res.Error != Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.ErroresFiscales.Ok) {
                                                        MostrarErrorFiscal(Res);
                                                        FormEstado.MostrarEstado("Cancelando documento...");
                                                        if (Res.EstadoFiscal.DocumentoFiscalAbierto)
                                                                Res = Impresora.CancelarDocumentoFiscal();
                                                        Programador.Start();
                                                        Watchdog.Start();
                                                        return;
                                                }
                                                break;
                                }
                        }
                        Programador.Start();
                        Watchdog.Start();
                }

                private void MostrarErrorFiscal(Lazaro.Base.Util.Impresion.Comprobantes.Fiscal.Respuesta Res)
                {
                        FormError FormFiscalError = new FormError();
                        FormFiscalError.Mostrar(Res);
                        FormFiscalError.ShowDialog();
                }

                public void End(bool reboot)
                {
                        Programador.Stop();

                        if (this.PV != 0) {
                                using (System.Data.IDbTransaction Trans = this.Impresora.Connection.BeginTransaction()) {
                                        qGen.Update Actualizar = new qGen.Update("pvs", new qGen.Where("id_pv", this.PVenta));
                                        Actualizar.ColumnValues.AddWithValue("lsa", null);
                                        this.Impresora.Connection.Execute(Actualizar);
                                        Trans.Commit();
                                }
                        }

                        Impresora.Terminar();
                        FormEstado.Close();

                        if (reboot) {
                                string[] ParametrosAPasar = (string[])(this.Arguments);
                                ParametrosAPasar[0] = "";
                                string Params = string.Join(" ", ParametrosAPasar).Trim();

                                Lfx.Environment.Shell.Execute(this.ExecutableName, Params, System.Diagnostics.ProcessWindowStyle.Minimized, false);
                        }
                        System.Windows.Forms.Application.Exit();
                }

                public static void ThreadExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
                {
                        UnknownExceptionHandler(e.Exception);
                }

                private static void GlobalExceptionHandler(object sender, UnhandledExceptionEventArgs args)
                {
                        UnknownExceptionHandler(args.ExceptionObject as Exception);
                        Application.Exit();
                }

                /// <summary>
                /// Manejador de excepciones desconocidas. Presenta una ventana con el error y envía un informe por correo electrónico.
                /// </summary>
                /// <param name="ex">La excepción a reportar.</param>
                public static void UnknownExceptionHandler(Exception ex)
                {
                        try {
                                System.Text.StringBuilder Texto = new System.Text.StringBuilder();
                                Texto.AppendLine("Lugar   : " + ex.Source);
                                try {
                                        System.Diagnostics.StackTrace Traza = new System.Diagnostics.StackTrace(ex, true);
                                        Texto.AppendLine("Línea   : " + Traza.GetFrame(0).GetFileLineNumber());
                                        Texto.AppendLine("Columna : " + Traza.GetFrame(0).GetFileColumnNumber());
                                } catch {
                                        //Nada
                                }
                                Texto.AppendLine("Equipo  : " + Lfx.Environment.SystemInformation.MachineName);
                                Texto.AppendLine("Plataf. : " + Lfx.Environment.SystemInformation.PlatformName);
                                Texto.AppendLine("RunTime : " + Lfx.Environment.SystemInformation.RuntimeName);
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
                                Texto.AppendLine(ex.StackTrace);

                                MailMessage Mensaje = new MailMessage();
                                Mensaje.To.Add(new MailAddress("error@lazarogestion.com"));
                                Mensaje.From = new MailAddress(Lbl.Sys.Config.Empresa.Email, Lbl.Sys.Config.Actual.UsuarioConectado.Nombre + " en " + Lbl.Sys.Config.Empresa.Nombre);
                                try {
                                        //No sé por qué, pero una vez dió un error al poner el asunto
                                        Mensaje.Subject = ex.Message;
                                } catch {
                                        Mensaje.Subject = "Excepción no controlada";
                                        Texto.Insert(0, ex.Message + System.Environment.NewLine);
                                }

                                Mensaje.Body = Texto.ToString();

                                SmtpClient Cliente = new SmtpClient("mail.lazarogestion.com");
                                Cliente.Send(Mensaje);
                        } catch {
                                // No pude enviar el reporte. No importa.
                        }
                }
        }
}