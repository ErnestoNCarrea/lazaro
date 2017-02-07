using System;
using System.Collections.Generic;

namespace Lbl.Notificaciones
{
        /// <summary>
        /// Administrador de notificaciones.
        /// </summary>
        public class Administrador : IDisposable
        {
                public static Lbl.Notificaciones.ColeccionUsuarioConectado Usuarios = new ColeccionUsuarioConectado();

                public static Administrador Principal = null;

                private Lfx.Data.IConnection m_Connection = null;
                private int LastMessageId { get; set; }
                private System.Timers.Timer PollTimer;

                public void Dispose()
                {
                        if (this.PollTimer != null) {
                                this.PollTimer.Stop();
                                this.PollTimer.Dispose();
                                this.PollTimer = null;
                        }
                        if (m_Connection != null) {
                                m_Connection.Dispose();
                                m_Connection = null;
                        }
                        GC.SuppressFinalize(this);
                }


                private Lfx.Data.IConnection Connection
                {
                        get
                        {
                                if (m_Connection == null) {
                                        m_Connection = Lfx.Workspace.Master.GetNewConnection("Administrador de notificaciones") as Lfx.Data.IConnection;
                                        m_Connection.RequiresTransaction = false;
                                }
                                return m_Connection;
                        }
                }


                public void Iniciar()
                {
                        try {
                                qGen.Select SelUltimoId = new qGen.Select("sys_mensajeria");
                                SelUltimoId.Columns = new List<string> { "MAX(id_ultimomensaje)" };
                                SelUltimoId.WhereClause = new qGen.Where();
                                SelUltimoId.WhereClause.AddWithValue("id_usuario", Lbl.Sys.Config.Actual.UsuarioConectado.Id);

                                this.LastMessageId = this.Connection.FieldInt(SelUltimoId);

                                this.PollTimer = new System.Timers.Timer();
                                this.PollTimer.Interval = Lfx.Workspace.Master.SlowLink ? 7000 : 3000;
                                this.PollTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.PollTimer_Elapsed);
                                this.PollTimer.Start();
                        } catch {
                                //if (Lfx.Environment.SystemInformation.DesignMode)
                                        //throw;
                        }
                }

                private void PollTimer_Elapsed(Object sender, System.Timers.ElapsedEventArgs e)
                {
                        this.PollTimer.Stop();
                        try {
                                Poll();
                        } catch {
                                // Nada...
                        }
                        this.PollTimer.Start();
                }


                public void ActualizarUsuariosConectados()
                {
                        Lbl.Notificaciones.ColeccionUsuarioConectado Res = new Lbl.Notificaciones.ColeccionUsuarioConectado();

                        qGen.Select SelUsuarios = new qGen.Select("sys_mensajeria");
                        //SelUsuarios.WhereClause = new qGen.Where();
                        //SelUsuarios.WhereClause.AddWithValue("fecha", qGen.ComparisonOperators.GreaterOrEqual, new qGen.SqlExpression("DATE_SUB(fecha, INTERVAL 20 SECOND)"));
                        DateTime Ahora = Lfx.Workspace.Master.MasterConnection.ServerDateTime;

                        try {
                                System.Data.DataTable TablaUsuarios = this.Connection.Select(SelUsuarios);
                                foreach (System.Data.DataRow Usuario in TablaUsuarios.Rows) {
                                        UsuarioConectado Usu = new UsuarioConectado((Lfx.Data.Row)(Usuario));
                                        Res.Add(Usu);

                                        TimeSpan Dif = Ahora - Usu.Fecha;
                                        Usu.Estado = Dif.TotalSeconds < 30 ? 1 : 0;
                                }
                        } catch {
                        }


                        // Agrego o actualizo la lista
                        foreach (UsuarioConectado Usu in Res.Values) {
                                if (Usuarios.ContainsKey(Usu.Id))
                                        Usuarios[Usu.Id] = Usu;
                                else
                                        Usuarios.Add(Usu);
                        }
                }


                public bool Enviar(INotificacion notif)
                {
                        qGen.Insert InsertarMensaje = new qGen.Insert("sys_mensajes");
                        InsertarMensaje.ColumnValues.AddWithValue("id_remitente", notif.Remitente.Id);
                        InsertarMensaje.ColumnValues.AddWithValue("id_destinatario", notif.Destinatario.Id);
                        InsertarMensaje.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                        InsertarMensaje.ColumnValues.AddWithValue("destino", notif.Destino);
                        InsertarMensaje.ColumnValues.AddWithValue("nombre", notif.Nombre);
                        InsertarMensaje.ColumnValues.AddWithValue("obs", notif.Obs);
                        InsertarMensaje.ColumnValues.AddWithValue("estacion_envia", notif.EstacionOrigen);
                        InsertarMensaje.ColumnValues.AddWithValue("estacion_recibe", notif.EstacionDestino);

                        try {
                                this.Connection.Execute(InsertarMensaje);
                                return false;
                        } catch {
                                return true;
                        }
                }


                public void Poll()
                {
                        if (this.Connection.State != System.Data.ConnectionState.Open)
                                this.Connection.Open();

                        qGen.Where WhereUsuario = new qGen.Where(qGen.AndOr.Or);
                        WhereUsuario.AddWithValue("id_destinatario", Lbl.Sys.Config.Actual.UsuarioConectado.Id);
                        WhereUsuario.AddWithValue("id_destinatario", null);
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.Persona.Grupo != null)
                                WhereUsuario.AddWithValue("id_grupo", Lbl.Sys.Config.Actual.UsuarioConectado.Persona.Grupo.Id);
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.Persona.SubGrupo != null)
                                WhereUsuario.AddWithValue("id_grupo", Lbl.Sys.Config.Actual.UsuarioConectado.Persona.SubGrupo.Id);


                        qGen.Select SelMensajesSinLeer = new qGen.Select("sys_mensajes");

                        SelMensajesSinLeer.WhereClause = new qGen.Where();
                        //SelMensajesSinLeer.WhereClause.AddWithValue("estacion_recibe", Lfx.Environment.SystemInformation.MachineName);
                        SelMensajesSinLeer.WhereClause.AddWithValue("id_mensaje", qGen.ComparisonOperators.GreaterThan, this.LastMessageId);
                        SelMensajesSinLeer.WhereClause.AddWithValue(WhereUsuario);
                        SelMensajesSinLeer.Order = "id_mensaje";

                        System.Data.DataTable TablaMensajes;
                        try {
                                TablaMensajes = this.Connection.Select(SelMensajesSinLeer);
                                foreach (System.Data.DataRow Mensaje in TablaMensajes.Rows) {
                                        INotificacion Res = new NotificacionRegistro(this.Connection, (Lfx.Data.Row)(Mensaje));
                                        this.LastMessageId = System.Convert.ToInt32(Mensaje["id_mensaje"]);
                                        string Destino = System.Convert.ToString(Mensaje["destino"]);
                                        if (Lfx.Components.Manager.ComponentesCargados.ContainsKey(Destino)) {
                                                // Lo notifico via IPC
                                                Lfx.Workspace.Master.RunTime.Notify(Destino, Res);

                                                // Se lo notifico directamente al componente
                                                if (Lfx.Components.Manager.ComponentesCargados[Destino].Funciones.ContainsKey("Notify")) {
                                                        Lfx.Components.Manager.ComponentesCargados[Destino].Funciones["Notify"].Instancia.Arguments = new object[] { Res };
                                                        Lfx.Components.Manager.ComponentesCargados[Destino].Funciones["Notify"].Run();
                                                }
                                        } else {
                                                Lfx.Workspace.Master.RunTime.Notify(Destino, Res);
                                        }
                                }

                                qGen.Insert ActualizarEstado = new qGen.Insert("sys_mensajeria");
                                ActualizarEstado.OnDuplicateKeyUpdate = true;
                                ActualizarEstado.ColumnValues.AddWithValue("id_usuario", Lbl.Sys.Config.Actual.UsuarioConectado.Id);
                                ActualizarEstado.ColumnValues.AddWithValue("estacion", Lfx.Environment.SystemInformation.MachineName);
                                ActualizarEstado.ColumnValues.AddWithValue("nombre", Lbl.Sys.Config.Actual.UsuarioConectado.Nombre);
                                ActualizarEstado.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                                if (this.LastMessageId > 0)
                                        ActualizarEstado.ColumnValues.AddWithValue("id_ultimomensaje", this.LastMessageId);

                                this.Connection.Execute(ActualizarEstado);
                        } catch (Exception ex) {
                                System.Console.WriteLine(ex.Message);
                                if (Lfx.Environment.SystemInformation.DesignMode)
                                        throw;
                                else
                                        return;
                        }
                }
        }
}
