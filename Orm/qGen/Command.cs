using System;
using Lazaro.Orm.Data;

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
                //internal SqlModes m_Mode { get; set; } = SqlModes.Ansi;

                public Where WhereClause { get; set; }
                public FieldCollection Fields { get; set; } = new FieldCollection();
                public IConnection DataBase { get; set; } = null;

                protected Command()
                {
                        // Nada
                }

                protected Command(IConnection dataBase)
                        : this()
                {
                        this.DataBase = dataBase;
                        //this.SqlMode = dataBase.SqlMode;
                }

                public override string ToString()
                {
                        throw new Exception("Not allowed");
                }
        }
}
