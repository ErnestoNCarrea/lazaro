using System;
using System.Collections.Generic;

namespace Lazaro.Pres
{
        public class FieldCollection : List<Field>
        {
                public Field this[string index]
                {
                        get
                        {
                                foreach (Field Fld in this) {
                                        if (Fld.Name == index)
                                                return Fld;
                                }

                                foreach (Field Fld in this) {
                                        if (Lazaro.Orm.Data.ColumnValue.GetNameOnly(Fld.Name) == index)
                                                return Fld;
                                }
                                return null;
                        }
                }

                public bool ContainsKey(string key)
                {
                        return this[key] != null;
                }

                public FieldCollection Clone()
                {
                        FieldCollection Res = new FieldCollection();

                        foreach (Field Fld in this) {
                                Res.Add(Fld.Clone());
                        }

                        return Res;
                }
        }
}
