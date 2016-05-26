using System;

namespace Lfx.Types
{
        public class Object
        {
                /// <summary>
                /// Intenta comparar dos objetos en cuanto a su valor, de manera felxible e independiente del tipo.
                /// Ejemplos: (int)3 == (decimal)3, (int)0 == null, true == (int)1, (int)0 == "0", etc.
                /// </summary>
                public static int CompareByValue(object val1, object val2)
                {
                        object a = val1, b = val2;

                        // Permito comparación con null
                        if (val1 == null) {
                                if (val2 is int)
                                        return (int)val2 == 0 ? 0 : -1;
                                else if (val2 is double)
                                        return (double)val2 == 0 ? 0 : -1;
                                else if (val2 is decimal)
                                        return (decimal)val2 == 0 ? 0 : -1;
                                else
                                        return val2 == null ? 0 : -1;
                        }

                        if (val2 == null)
                                return val1 == null ? 0 : 1;

                        //Convierto booleanos y enums a enteros para poder comparar
                        if (val1 is bool)
                                a = (bool)val1 ? 1 : 0;
                        else if (val1.GetType().IsEnum)
                                a = (int)val1;
                        else if (val1 is NullableDateTime)
                                a = ((NullableDateTime)(val1)).Value;

                        if (val2 is bool)
                                b = (bool)val2 ? 1 : 0;
                        else if (val2.GetType().IsEnum)
                                b = (int)val2;
                        else if (val2 is NullableDateTime)
                                b = ((NullableDateTime)(val2)).Value;

                        if (a == null && b is int && (int)b == 0) {
                                // Por la forma en la que trabaja FieldCollection[columName], digo que null==0 es true
                                return 0;
                        } else if (a == null && b is double && (double)b == 0) {
                                // Por la forma en la que trabaja FieldCollection[columName], digo que null==0 es true
                                return 0;
                        } else if (a == null && b is decimal && (decimal)b == 0) {
                                // Por la forma en la que trabaja FieldCollection[columName], digo que null==0 es true
                                return 0;
                        } else if (a == null && b is string && (string)b == "") {
                                // Por la forma en la que trabaja FieldCollection[columName], digo que null=="" es true
                                return 0;
                        } else if ((a is short || a is int || a is long)
                           && (b is short || b is int || b is long)) {
                                // Doy a todos los enteros el mismo tratamiento (a los efectos de comparar)
                                return  System.Convert.ToInt64(a).CompareTo(System.Convert.ToInt64(b));
                        } else if (b is double && a is double) {
                                // Compraración de double
                                return Math.Round(System.Convert.ToDouble(a), 4).CompareTo(Math.Round(System.Convert.ToDouble(b), 4));
                        } else if (b is decimal && a is decimal) {
                                // Compraración de decimal
                                return Math.Round(System.Convert.ToDecimal(a), 8).CompareTo(Math.Round(System.Convert.ToDecimal(b), 8));
                        } else if ((b is decimal && a is double) || (b is double && a is decimal)) {
                                // Compraración entre decimal y double
                                return Math.Round(System.Convert.ToDecimal(a), 4).CompareTo(Math.Round(System.Convert.ToDecimal(b), 4));
                        } else if (a is DateTime && b is DateTime) {
                                // Compración de fechas
                                return System.Convert.ToDateTime(a).CompareTo(System.Convert.ToDateTime(b));
                        } else if (a is string && b is string) {
                                // Compración de cadenas
                                return string.Compare(a as string, b as string, StringComparison.CurrentCulture);
                        } else {
                                // El resto, lo comparo por su representación de cadena
                                return string.Compare(System.Convert.ToString(a), System.Convert.ToString(b), StringComparison.CurrentCulture);
                        }
                }
        }
}
