using Lazaro.Orm.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lfx.Data
{
	public class Row
	{
                public bool IsNew { get; set; }
                public bool m_IsModified;
                public ColumnValueCollection Fields { get; set; }
                public System.Data.DataTable DataTable { get; set; }
                public Lfx.Data.Table Table { get; set; }

                public bool IsModified {
                        get
                        {
                                return m_IsModified;
                        }
                        set
                        {
                                m_IsModified = value;
                        }
                }

		public Row()
		{
                        this.IsNew = true;
                        if (Fields == null)
                                Fields = new ColumnValueCollection();
		}

                public static explicit operator Lfx.Data.Row(System.Data.DataRow row)
		{
			Row Res = new Row();
			if (row != null)
			{
				Res.DataTable = row.Table;
				foreach (System.Data.DataColumn Col in row.Table.Columns)
				{
                                        if (row[Col] is DBNull)
                                                Res[Col.ColumnName] = null;
                                        else
                                                Res[Col.ColumnName] = row[Col];
				}
				Res.IsNew = false;
				Res.IsModified = false;
			}
			return Res;
		}

		public object this[string fieldName]
		{
			get
			{
                                if (Fields == null)
                                        return null;
                                else if (Fields[fieldName].Value is DBNull)
                                        return null;
                                else
					return Fields[fieldName].Value;
			}
			set
			{
				if(Fields == null)
					Fields = new ColumnValueCollection();
                                if (Fields[fieldName].Value != value && this.IsModified == false)
                                        this.IsModified = true;
				Fields[fieldName].Value = value;
			}
		}

		public object this[int index]
		{
			get
			{
				if(this.Fields == null || this.Fields[index].Value is DBNull)
                                        return null;
                                else
                                        return this.Fields[index].Value;
			}
		}

                public virtual Row Clone()
                {
                        Lfx.Data.Row Res = new Lfx.Data.Row();
                        Res.DataTable = this.DataTable;
                        foreach (Lazaro.Orm.Data.ColumnValue Fld in this.Fields) {
                                Res.Fields.Add(Fld.Clone());
                        }
                        Res.IsModified = this.IsModified;
                        Res.IsNew = this.IsNew;
                        return Res;
                }
	}
}
