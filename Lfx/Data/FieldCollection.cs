using System;
using System.Collections.Generic;

namespace Lfx.Data
{
        [Serializable]
	public class FieldCollection : List<Field>
	{
		public FieldCollection()
		{
		}

		public virtual Field this[string columnName]
		{
			get
			{
				foreach(Field Itm in this) {
					if(Itm.ColumnName == columnName)
						return Itm;
				}

                                foreach (Field Itm in this) {
                                        if (Itm.ColumnName != null && Lfx.Data.Field.GetNameOnly(Itm.ColumnName) == columnName)
                                                return Itm;
                                }

                                foreach (Field Itm in this) {
                                        if (Itm.ColumnName == Lfx.Data.Field.GetNameOnly(columnName))
                                                return Itm;
                                }
				//Si no existe, creo dinámicamente el campo
				Field Res = new Field(columnName);
				this.Add(Res);
				return Res;
			}
			set
			{
				bool Encontrado = false;
				for(int i = 0; i < this.Count; i++) {
					if(this[i].ColumnName == columnName) {
						((Field)(this[i])).Value = value;
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

                public bool Contains(string columnName)
                {
                        foreach (Field Itm in this) {
                                if (Itm.ColumnName.ToUpperInvariant() == columnName.ToUpperInvariant())
                                        return true;
                        }
                        return false;
                }

		public override string ToString()
		{
			string Res = "FieldCollection[" + this.Count.ToString() + "] = {";
			string FlList = null;
			foreach (Field Itm in this) {
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
                        this.Add(new Field(fieldName, fieldValue));
                }
	}
}
