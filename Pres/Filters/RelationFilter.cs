using System;
using System.Collections.Generic;

namespace Lazaro.Pres.Filters
{
        [Serializable]
        public class RelationFilter : Filter
        {
                public Lfx.Data.Relation Relation { get; set; }
                public qGen.Where Filter { get; set; }

                public int ElementId { get; set; }

                public RelationFilter(string label, string columnName)
                        : base(label, columnName)
                {
                }

                public RelationFilter(string label, Lfx.Data.Relation relation)
                        : this(label, relation.Column)
                {
                        this.Relation = relation;
                }


                public RelationFilter(string label, Lfx.Data.Relation relation, qGen.Where filter)
                        : this(label, relation)
                {
                        this.Filter = filter;
                }


                override public bool IsEmpty()
                {
                        return this.Relation == null || this.ElementId == 0;
                }


                public object Elemento
                {
                        get
                        {
                                return this.Value;
                        }
                        set
                        {
                                this.Value = value;
                        }
                }
        }
}
