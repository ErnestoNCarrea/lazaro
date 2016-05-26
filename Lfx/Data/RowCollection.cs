using System;
using System.Collections.Generic;
using System.Text;

namespace Lfx.Data
{
        [Serializable]
        public class RowCollection : Dictionary<int, Lfx.Data.Row>
        {
                private System.DateTime LastCacheRefresh;
                protected Table Table;

                public RowCollection(Table table)
                {
                        this.Table = table;
                        LastCacheRefresh = System.DateTime.Now;
                }

                private bool LoadAll_Loaded = false;
                public void LoadAll()
                {
                        if (this.Table.Cacheable && LoadAll_Loaded)
                                return;

                        System.Data.DataTable Todo = this.Table.Connection.Select("SELECT * FROM " + this.Table.Name);
                        foreach(System.Data.DataRow Rw in Todo.Rows) {
                                Lfx.Data.Row NewRow = (Lfx.Data.Row)Rw;
                                NewRow.Table = this.Table;
                                int id = System.Convert.ToInt32(NewRow.Fields[this.Table.PrimaryKey].Value);
                                if (this.ContainsKey(id))
                                        this[id] = NewRow;
                                else
                                        this.Add(System.Convert.ToInt32(NewRow[this.Table.PrimaryKey]), NewRow);
                        }
                        LoadAll_Loaded = true;
                        LastCacheRefresh = System.DateTime.Now;
                }

                new public System.Collections.IEnumerator GetEnumerator()
                {
                        //GetEnumerator es llamado antes de un foreach. En ese caso, se cargan todos los registros en memoria.
                        this.LoadAll();
                        return base.GetEnumerator();
                }

                new public Lfx.Data.Row this[int id]
                {
                        get
                        {
                                if (System.DateTime.Now > LastCacheRefresh.AddMinutes(60)) {
                                        System.Console.WriteLine(DateTime.Now.ToShortTimeString() + " vaciando la caché de " + this.Table.Name);
                                        this.ClearCache();
                                        LastCacheRefresh = DateTime.Now;
                                }

                                if (Table.Cacheable == false || (Table.Connection.InTransaction && Table.AlwaysCache == false)) {
					// No uso el caché si hay una transacción activa o se esta tabla no es cacheable
                                        Lfx.Data.Row NewRow = this.Table.Connection.Row(this.Table.Name, this.Table.PrimaryKey, id) as Lfx.Data.Row;
					if (NewRow != null)
                                        	NewRow.Table = this.Table;
                                        return NewRow;
                                } else if (this.ContainsKey(id) == false) {
                                        Lfx.Data.Row NewRow = this.Table.Connection.Row(this.Table.Name, this.Table.PrimaryKey, id);
                                        if (NewRow != null) {
                                                NewRow.Table = this.Table;
                                                // No cachear más de 500 registros
                                                if (this.Count < 500) {
                                                        this.Add(id, NewRow);
                                                }
                                        }
                                        return NewRow;
                                } else {
                                        return ((Lfx.Data.Row)(base[id]));
                                }
                        }
                        set
                        {
                                this.RemoveFromCache(id);
                                this.Add(id, value);
                        }
                }

                public Lfx.Data.Row Select(string fieldName, object value)
                {
                        if(fieldName == this.Table.PrimaryKey)
                                return this[(int)value];
                        
                        foreach(Lfx.Data.Row Rw in this.Values) {
                                if (Rw[fieldName] == value)
                                        return Rw;
                        }
                        return null;
                }

		public void ClearCache()
		{
			this.Clear();
                        LoadAll_Loaded = false;
		}

                public void RemoveFromCache(int id)
                {
                        if (this.ContainsKey(id))
                                this.Remove(id);
                }
        }
}
