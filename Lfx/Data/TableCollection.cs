using System;
using System.Collections.Generic;

namespace Lfx.Data
{
        public class TableCollection : List<Lfx.Data.Table>
        {
                protected Connection DataBase;

                public TableCollection(Connection dataBase)
                {
                        this.DataBase = dataBase;
                }

                new public void Add(Table table)
                {
                        table.Connection = this.DataBase;
                        base.Add(table);
                }

                public bool ContainsKey(string name)
                {
                        foreach (Table Tb in this) {
                                if (Tb.Name == name)
                                        return true;
                        }
                        return false;
                }

		public Table this[string name]
		{
			get
			{
				foreach(Table Tb in this) {
					if(Tb.Name == name)
						return Tb;
				}
                                throw new ArgumentOutOfRangeException("No existe la tabla " + name);
			}
		}
        }
}
