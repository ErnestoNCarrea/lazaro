using System;

namespace Lfx.Services
{
        /// <summary>
        /// Programador de tareas
        /// </summary>
        public class Scheduler : IDisposable
        {
                private Lfx.Workspace Workspace;
                private Lfx.Data.IConnection m_DataBase = null;
                private DateTime m_LastGetTask = DateTime.MinValue;

                public Scheduler(Workspace workspace)
                {
                        Workspace = workspace;
                }

                public void Dispose()
                {
                        if (m_DataBase != null)
                                m_DataBase.Dispose();
                        GC.SuppressFinalize(this);
                }

                public bool AddTask(string commandString)
                {
                        return AddTask(commandString, "lazaro", Lfx.Environment.SystemInformation.MachineName);
                }

                public bool AddTask(string commandString, string component)
                {
                        return AddTask(commandString, component, Lfx.Environment.SystemInformation.MachineName);
                }

                public DateTime LastGetTask
                {
                        get
                        {
                                return m_LastGetTask;
                        }
                }

                private Lfx.Data.IConnection DataBase
                {
                        get
                        {
                                if (m_DataBase == null) {
                                        m_DataBase = Lfx.Workspace.Master.GetNewConnection("Programador de tareas") as Lfx.Data.IConnection;
                                        m_DataBase.RequiresTransaction = false;
                                }
                                return m_DataBase;
                        }
                }

                public bool AddTask(string commandString, string component, string terminalName)
                {
                        if (terminalName == null || terminalName.Length == 0)
                                terminalName = Lfx.Environment.SystemInformation.MachineName;

                        qGen.Insert Comando = new qGen.Insert(this.DataBase, "sys_programador");
                        Comando.Fields.AddWithValue("crea_estacion", Lfx.Environment.SystemInformation.MachineName);
                        Comando.Fields.AddWithValue("crea_usuario", "");        // TODO: que ponga el nombre de usuario
                        Comando.Fields.AddWithValue("estacion", terminalName);
                        Comando.Fields.AddWithValue("comando", commandString);
                        Comando.Fields.AddWithValue("componente", component);
                        Comando.Fields.AddWithValue("fecha", qGen.SqlFunctions.Now);
                        Comando.Fields.AddWithValue("fechaejecutar", null);

                        try {
                                using (System.Data.IDbTransaction Trans = this.DataBase.BeginTransaction()) {
                                        this.DataBase.Execute(Comando);
                                        Trans.Commit();
                                }
                        }
                        catch {
                                return true;
                        }

                        return false;
                }

                public Task GetNextTask(string component)
                {
                        if (Workspace == null)
                                return null;

                        if (this.DataBase.State != System.Data.ConnectionState.Open)
                                this.DataBase.Open();

                        qGen.Where WhereEstacion = new qGen.Where(qGen.AndOr.Or);
                        WhereEstacion.AddWithValue("estacion", this.DataBase.EscapeString(Lfx.Environment.SystemInformation.MachineName));
                        WhereEstacion.AddWithValue("estacion", "*");

                        qGen.Where WhereFecha = new qGen.Where(qGen.AndOr.Or);
                        WhereFecha.AddWithValue("fechaejecutar", qGen.ComparisonOperators.LessOrEqual, qGen.SqlFunctions.Now);
                        WhereFecha.AddWithValue("fechaejecutar", null);

                        m_LastGetTask = DateTime.Now;
                        qGen.Select NextTask = new qGen.Select("sys_programador");
                        NextTask.WhereClause = new qGen.Where("estado", 0);
                        NextTask.WhereClause.AddWithValue("componente", component);
                        NextTask.WhereClause.AddWithValue(WhereEstacion);
                        NextTask.WhereClause.AddWithValue(WhereFecha);

                        NextTask.Order = "id_evento";

                        Lfx.Data.Row TaskRow;
                        try {
                                TaskRow = this.DataBase.FirstRowFromSelect(NextTask);
                        } catch {
                                TaskRow = null;
                        }
                        if (TaskRow != null) {
                                Task Result = new Task();

                                Result.Id = System.Convert.ToInt32(TaskRow["id_evento"]);
                                Result.Command = TaskRow["comando"].ToString();
                                Result.Component = TaskRow["componente"].ToString();
                                Result.Creator = TaskRow["crea_usuario"].ToString();
                                Result.CreatorComputerName = TaskRow["crea_estacion"].ToString();
                                Result.ComputerName = TaskRow["estacion"].ToString();
                                Result.Schedule = System.Convert.ToDateTime(TaskRow["fecha"]);
                                Result.Status = System.Convert.ToInt32(TaskRow["estado"]);

                                //Elimino tareas viejas
                                qGen.Update Actualizar = new qGen.Update("sys_programador", new qGen.Where("id_evento", Result.Id));
                                Actualizar.Fields.AddWithValue("estado", 1);

                                using (System.Data.IDbTransaction Trans = this.DataBase.BeginTransaction()) {
                                        this.DataBase.Execute(Actualizar);
                                        this.DataBase.Execute(new qGen.Delete("sys_programador", new qGen.Where("fecha", qGen.ComparisonOperators.LessThan, System.DateTime.Now.AddDays(-7))));
                                        Trans.Commit();
                                }

                                return Result;
                        } else
                                return null;
                }
        }
}
