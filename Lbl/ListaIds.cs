using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl
{
        public class ListaIds : List<int>
        {
                public ListaIds()
                {
                }

                public ListaIds(string csv)
                {
                        this.FromCsv(csv);
                }


                public ListaIds(IEnumerable<int> lista)
                        : base(lista)
                {
                }

                public ListaIds(System.Data.DataTable dataTable)
                {
                        this.FromDataTable(dataTable);
                }

                public void FromCsv(string csv)
                {
                        this.Clear();
                        string[] Valores = csv.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string Val in Valores) {
                                this.Add(Lfx.Types.Parsing.ParseInt(Val));
                        }
                }

                public void FromDataTable(System.Data.DataTable dataTable)
                {
                        this.Clear();
                        foreach (System.Data.DataRow Row in dataTable.Rows) {
                                this.Add(System.Convert.ToInt32(Row[0]));
                        }
                }

                /// <summary>
                /// Convierte la lista a una cadena, en la forma de una lista de valores separados por comas.
                /// </summary>
                /// <returns>Una lista de valores separados por comas.</returns>
                public override string ToString()
                {
                        StringBuilder Res = new StringBuilder();

                        foreach (int i in this) {
                                if (Res.Length != 0)
                                        Res.Append(", ");
                                Res.Append(i);
                        }

                        return Res.ToString();
                }
        }
}
