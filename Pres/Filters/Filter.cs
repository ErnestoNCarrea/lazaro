using System;
using System.Collections.Generic;

namespace Lazaro.Pres.Filters
{
        [Serializable]
        public class Filter : IFilter
        {
                public string Label { get; set; }
                public string ColumnName { get; set; }

                /// <summary>
                /// Obtiene o establece el valor actual del filtro.
                /// </summary>
                public object Value { get; set; }

                /// <summary>
                /// Obtiene o establece el segundo valor del filtro, para el caso de los filtros de rango que tienen 2 valores (por ejemplo mínimo/máximo o desde/hasta).
                /// </summary>
                public object Value2 { get; set; }

                // El control asociado a este filtro, cuando se lo presenta en un formulario
                public object Control { get; set; }

                public Filter(string label, string columnName)
                {
                        this.Label = label;
                        this.ColumnName = columnName;
                }


                virtual public bool IsEmpty()
                {
                        return true;
                }

                public override string ToString()
                {
                        return this.GetType().ToString() + " on " + this.ColumnName;
                }
        }
}
