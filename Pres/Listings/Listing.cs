using System;
using System.Collections.Generic;

namespace Lazaro.Pres.Listings
{
        /// <summary>
        /// Define los datos para emitir un listado.
        /// </summary>
        [Serializable]
        public class Listing
        {
                public Listing()
                {
                        this.Sortable = true;
                }

                public Type ElementoTipo { get; set; }

                public string TableName { get; set; }
                public Lazaro.Pres.Field KeyColumn { get; set; }
                public string DetailColumnName { get; set; }
                public Lazaro.Pres.FieldCollection Columns { get; set; }
                public Lazaro.Pres.FieldCollection ExtraSearchColumns { get; set; }
                public Lazaro.Pres.FieldCollection SortColumns { get; set; }
                public Filters.FilterCollection Filters { get; set; }

                public Lazaro.Pres.Field GroupBy { get; set; }
                public string OrderBy { get; set; }
                public qGen.JoinCollection Joins = new qGen.JoinCollection();

                public qGen.Where Having { get; set; }
                public qGen.Where Where { get; set; }

                public bool Sortable { get; set; }
        }
}
