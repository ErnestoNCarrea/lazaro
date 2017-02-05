using System;
using System.Collections.Generic;

namespace Lazaro.Orm.Data
{
	public class ColumnValueCollection : List<IColumnValue>
	{
		public ColumnValueCollection()
		{
		}

		public virtual IColumnValue this[string columnName]
		{
			get
			{
				foreach(IColumnValue Itm in this) {
					if(Itm.ColumnName == columnName)
						return Itm;
				}

                                foreach (IColumnValue Itm in this) {
                                        // FIXME: no puedo depender de Field
                                        if (Itm.ColumnName != null && ColumnValue.GetNameOnly(Itm.ColumnName) == columnName)
                                                return Itm;
                                }

                                foreach (IColumnValue Itm in this) {
                                        // FIXME: no puedo depender de Field
                                        if (Itm.ColumnName == ColumnValue.GetNameOnly(columnName))
                                                return Itm;
                                }
				//Si no existe, creo dinámicamente el campo
				var Res = new ColumnValue(columnName);
				this.Add(Res);
				return Res;
			}
			set
			{
				bool Encontrado = false;
				for(int i = 0; i < this.Count; i++) {
					if(this[i].ColumnName == columnName) {
						((ColumnValue)(this[i])).Value = value;
						Encontrado = true;
						break;
					}
				}
				if(Encontrado == false) {
					//Si no existe, creo dinámicamente el campo
					value.ColumnName = columnName;
					this.Add(value);
				}
			}
		}


                public IList<string> GetFieldNames()
                {
                        var Res = new List<string>();
                        foreach (IColumnValue Itm in this) {
                                Res.Add(Itm.ColumnName);
                        }

                        return Res;
                }


                public bool Contains(string columnName)
                {
                        foreach (IColumnValue Itm in this) {
                                if (Itm.ColumnName.ToUpperInvariant() == columnName.ToUpperInvariant())
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
				FlList += Itm.ColumnName + "=" + Itm.Value.ToString();
			}
			
			return Res + FlList + "}";
		}


                public virtual void AddWithValue(string fieldName, object fieldValue)
                {
                        // FIXME: no puedo depender de Field
                        this.Add(new ColumnValue(fieldName, fieldValue));
                }
	}
}
