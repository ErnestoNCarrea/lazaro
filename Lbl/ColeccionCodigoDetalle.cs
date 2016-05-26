using System;
using System.Collections.Generic;

namespace Lbl
{
        [Serializable]
        public class ColeccionCodigoDetalle : Dictionary<int, string>
        {
                public ColeccionCodigoDetalle()
                {
                }

                public ColeccionCodigoDetalle(System.Data.DataTable table)
                        : this()
                {
                        this.Clear();
                        foreach (System.Data.DataRow Row in table.Rows) {
                                this.Add(System.Convert.ToInt32(Row[0]), Row[1].ToString());
                        }
                }

                public void AddRange(IDictionary<int, string> values)
                {
                        foreach (KeyValuePair<int, string> Vl in values)
                                this.Add(Vl.Key, Vl.Value);
                }
        }
}
