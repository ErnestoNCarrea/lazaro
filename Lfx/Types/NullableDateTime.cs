using System;

namespace System
{
        public class NullableDateTime
        {
                public DateTime Value;

                public NullableDateTime(DateTime dateTimeValue)
                {
                        this.Value = dateTimeValue;
                }

                public static implicit operator DateTime(NullableDateTime lDateTimeValue)
                {
                        return lDateTimeValue.Value;
                }

                public static implicit operator DbDateTime(NullableDateTime lDateTimeValue)
                {
                        return new DbDateTime(lDateTimeValue.Value);
                }

                public static implicit operator NullableDateTime(DateTime dateTimeValue)
                {
                        return new NullableDateTime(dateTimeValue);
                }

                public static implicit operator NullableDateTime(DbDateTime dateTimeValue)
                {
                        return new NullableDateTime(dateTimeValue.Value);
                }

                public override string ToString()
                {
                        return this.Value.ToString();
                }

                public string ToString(string format)
                {
                        return this.Value.ToString(format);
                }

                public override bool Equals(object obj)
                {
			NullableDateTime LDat = obj as NullableDateTime;

                        if (object.ReferenceEquals(obj, null)) {
                                if (this.Value.Year == 1 && this.Value.Month == 1 && this.Value.Day == 1)
                                        // 01-01-0001 es igual a null
                                        return true;
                                else
                                        return false;
                        } else {
                                return (this.Value == LDat.Value);
                        }
                }

                public override int GetHashCode()
                {
                        return this.Value.GetHashCode();
                }

                public static bool operator ==(NullableDateTime v1, NullableDateTime v2)
                {
                        if (object.ReferenceEquals(v1, null) && object.ReferenceEquals(v2, null)) {
                                return true;
                        } else if (object.ReferenceEquals(v1, null)) {
                                if (v2.Value.Year == 1 && v2.Value.Month == 1 && v2.Value.Day == 1)
                                        // 01-01-0001 es igual a null
                                        return true;
                                else
                                        return false;
                        } else if (object.ReferenceEquals(v2, null)) {
                                if (v1.Value.Year == 1 && v1.Value.Month == 1 && v1.Value.Day == 1)
                                        // 01-01-0001 es igual a null
                                        return true;
                                else
                                        return false;
                        } else {
                                return (v1.Value == v2.Value);
                        }
                }

                public static bool operator !=(NullableDateTime v1, NullableDateTime v2)
                {
                        return !(v1 == v2);
                }
        }
}
