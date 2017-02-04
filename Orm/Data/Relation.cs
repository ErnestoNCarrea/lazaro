using System;

namespace Lazaro.Orm.Data
{
        public class Relation
        {
                /// <summary>
                /// Obtiene o establece el nombre de la columna en la en la tabla de origen.
                /// </summary>
                public string Column { get; set; }

                /// <summary>
                /// Obtiene o establece el nombre de la tabla de destino (de la cual se obtienen los detalles).
                /// </summary>
                public string ReferenceTable { get; set; }

                /// <summary>
                /// Obtiene o establece el nombre de la columna de clave mediante la cual obtener el detalle en la tabla de destino.
                /// </summary>
                public string ReferenceColumn { get; set; }

                /// <summary>
                /// Obtiene o establece el nombre de la columna que contiene los detalles en la tabla de destino.
                /// </summary>
                public string DetailColumn { get; set; }

                public Relation()
                {
                }

                public Relation(string column, string referenceTable, string referenceColumn)
                        : this(column, referenceTable, referenceColumn, null)
                {
                }

                public Relation(string column, string referenceTable, string referenceColumn, string detailColumn)
                {
                        this.Column = column;
                        this.ReferenceTable = referenceTable;
                        this.ReferenceColumn = referenceColumn;

                        if (detailColumn == null)
                                this.DetailColumn = "nombre";
                        else
                                this.DetailColumn = detailColumn;
                }

                public bool IsEmpty()
                {
                        return this.ReferenceColumn == null
                                || this.ReferenceColumn.Length == 0
                                || this.ReferenceTable == null
                                || this.ReferenceTable.Length == 0
                                || this.DetailColumn == null
                                || this.DetailColumn.Length == 0;
                }
        }
}
