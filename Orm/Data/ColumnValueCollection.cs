using log4net;
using qGen;
using System;
using System.Collections.Generic;

namespace Lazaro.Orm.Data
{
        public class ColumnValueCollection : List<IColumnValue>
	{
                private static readonly ILog Log = LogManager.GetLogger(typeof(ColumnValueCollection));

                public ColumnValueCollection()
		{
		}

                public SqlIdentifierCollection ColumnNames
                {
                        get
                        {
                                var Res = new SqlIdentifierCollection();

                                foreach (IColumnValue Itm in this) {
                                        Res.Add(Itm.ColumnIdentifier);
                                }

                                return Res;
                        }
                }

                public virtual IColumnValue this[string columnName]
		{
			get
			{
				foreach(IColumnValue Itm in this) {
					if(Itm.ColumnIdentifier.EqualsByName(columnName))
						return Itm;
				}

                                // FIXME: No debería crearlo automáticamente
                                // Log.Warn("Dynamically adding column " + columnName + " to a row.");
				var Res = new ColumnValue(columnName);
				this.Add(Res);
				return Res;
			}
			set
			{
				bool Encontrado = false;
				for(int i = 0; i < this.Count; i++) {
					if(this[i].ColumnIdentifier.EqualsByName(columnName)) {
						((ColumnValue)(this[i])).Value = value;
						Encontrado = true;
						break;
					}
				}
				if(Encontrado == false) {
                                        // Si no existe, creo dinámicamente el campo
                                        value.ColumnIdentifier = new SqlIdentifier(columnName);
					this.Add(value);
				}
			}
		}

                public virtual IColumnValue this[SqlIdentifier columnName]
                {
                        get
                        {
                                foreach (IColumnValue Itm in this) {
                                        if (Itm.ColumnIdentifier.EqualsByName(columnName))
                                                return Itm;
                                }

                                // FIXME: No debería crearlo automáticamente
                                // Log.Warn("Dynamically adding column " + columnName + " to a row.");
                                var Res = new ColumnValue(columnName);
                                this.Add(Res);
                                return Res;
                        }
                        set
                        {
                                bool Encontrado = false;
                                for (int i = 0; i < this.Count; i++) {
                                        if (this[i].ColumnIdentifier.EqualsByName(columnName)) {
                                                ((ColumnValue)(this[i])).Value = value;
                                                Encontrado = true;
                                                break;
                                        }
                                }
                                if (Encontrado == false) {
                                        // Si no existe, creo dinámicamente el campo
                                        value.ColumnIdentifier = columnName;
                                        this.Add(value);
                                }
                        }
                }


                /* public IList<string> GetFieldNames()
                {
                        var Res = new List<string>();
                        foreach (IColumnValue Itm in this) {
                                Res.Add(Itm.ColumnIdentifier);
                        }

                        return Res;
                } */


                public bool Contains(string columnName)
                {
                        foreach (IColumnValue Itm in this) {
                                if (Itm.ColumnIdentifier.EqualsByName(columnName))
                                        return true;
                        }
                        return false;
                }


		public override string ToString()
		{
			string Res = "FieldCollection[" + this.Count.ToString() + "] = {";
			string FlList = null;
			foreach (IColumnValue Itm in this) {
				if(FlList == null)
					FlList = "";
				else
					FlList += ", ";
				FlList += Itm.ColumnIdentifier + "=" + Itm.Value.ToString();
			}
			
			return Res + FlList + "}";
		}


                public virtual void AddWithValue(string fieldName, object fieldValue)
                {
                        this.Add(new ColumnValue(fieldName, fieldValue));
                }
	}
}
