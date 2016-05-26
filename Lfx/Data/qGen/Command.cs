using System;

namespace qGen
{
        /// <summary>
        /// Esta clase y sus derivadas se utilizan para evitar escribir los comandos SQL como literales de texto.
        /// Permite la creación de un objeto y asignación de propiedades que luego puede convertirse para su ejecución
        /// en texto SQL (mediante el método ToString()) o en un OdbcCommand (mediante el método ToOdbcCommand()).
        /// Se utilizan principalmente con dos objetivos:
        ///   1.- Solucionar problemas de léxico SQL.
        ///   2.- Agregar extensibilidad al acceso a datos. Así como hoy se implementa ToOdbcCommand() para acceso mediante ODBC, luego se
        ///       pueden implementar otros métodos para acceso mediante otros adaptadores (p. ej. MySQL Connector/Net).
        /// </summary>
        [Serializable]
        public class Command : ICommand
        {
                internal SqlModes m_Mode = SqlModes.Ansi;

                public Where WhereClause { get; set; }

                public Lfx.Data.FieldCollection Fields = new Lfx.Data.FieldCollection();

                [NonSerialized]
                public Lfx.Data.Connection DataBase = null;

                protected Command()
                {
                        // Nada
                }

                protected Command(Lfx.Data.Connection dataBase)
                        : this()
                {
                        this.DataBase = dataBase;
                        this.SqlMode = dataBase.SqlMode;
                }

                protected Command(SqlModes SqlMode)
                        : this()
                {
                        m_Mode = SqlMode;
                }

                public SqlModes SqlMode
                {
                        get
                        {
                                return m_Mode;
                        }
                        set
                        {
                                m_Mode = value;
                        }
                }

                public virtual void SetupDbCommand(ref System.Data.IDbCommand baseCommand)
                {
                        baseCommand.CommandText = this.ToString();
                }
        }
}
