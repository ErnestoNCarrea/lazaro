using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System
{
        /// <summary>
        /// Métodos de extension para el tipo string.
        /// </summary>
        public static class StringExtensions
        {
                public static int ParseInt(this string s)
                {
                        if (s == null || s.Length == 0)
                                return 0;
                        decimal Resultado = 0;
                        decimal.TryParse(s, System.Globalization.NumberStyles.Integer, Lfx.Workspace.Master.CultureInfo, out Resultado);
                        if (Resultado > int.MaxValue)
                                return 0;
                        else
                                return System.Convert.ToInt32(Resultado);
                }

                /* public static double ParseDouble(this string s)
                {
                        double Resultado = 0;
                        double.TryParse(s, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out Resultado);
                        return Resultado;
                } */


                public static decimal ParseDecimal(this string s)
                {
                        decimal Resultado = 0;
                        decimal.TryParse(s, System.Globalization.NumberStyles.Float, Lfx.Workspace.Master.CultureInfo, out Resultado);
                        return Resultado;
                }

                public static decimal ParseCurrency(this string s)
                {
                        decimal Resultado = 0;
                        decimal.TryParse(s, System.Globalization.NumberStyles.Currency, Lfx.Workspace.Master.CultureInfo, out Resultado);
                        return Resultado;
                }
        
                public static bool ParseBool(this string s)
                {
                        if (s == null)
                                return false;

                        string ValorMayus = s.ToUpperInvariant();
                        switch (ValorMayus) {
                                case "SI":
                                case "SÍ":
                                case "YES":
                                case "VERDADERO":
                                case "TRUE":
                                        return true;
                                case "NO":
                                case "FALSO":
                                case "FALSE":
                                        return false;
                                default:
                                        return s.ParseInt() != 0;
                        }
                }

                public static DbDateTime ParseDateTime(this string s)
                {
                        // Toma una fecha DD-MM-YYYY y devuelve un Date
                        string FechaTemp = s.Replace("  ", " ").Replace("/", "-").Trim();
                        string[] FormatosAceptados =
				{
                                        "yyyy-MM-dd",
					"dd-MM-yyyy",
					"d-M-yyyy",
					"dd-MM-yy",
					"d-M-yy",
                                        "yyyyMMdd",
                                        "yyMMdd",
				};

                        try {
                                return new DbDateTime(DateTime.ParseExact(FechaTemp, FormatosAceptados, Lfx.Workspace.Master.CultureInfo, System.Globalization.DateTimeStyles.AllowWhiteSpaces));
                        } catch {
                                return null;
                        }
                }

                /// <summary>
                /// Toma una fecha YYYY-MM-DD HH:MM:SS y devuelve un DateTime
                /// </summary>
                public static DateTime ParseSqlDateTime(this string s)
                {
                        string FechaTemp = s.Replace("  ", " ").Replace("/", "-").Trim();
                        string[] FormatosAceptados =
				{
					@"yyyy\-MM\-dd HH\:mm\:ss",
					@"yy\-MM\-dd HH\:mm\:ss",
					@"yyyy\-MM\-dd HH\:mm",
					@"yyyy\-MM\-dd",
					"yyyyMMddHHmmss",
					"yyyyMMdd HHmmss"
				};

                        return DateTime.ParseExact(FechaTemp,
                            FormatosAceptados,
                            System.Globalization.DateTimeFormatInfo.InvariantInfo,
                            System.Globalization.DateTimeStyles.AllowWhiteSpaces);
                }

                /// <summary>
                /// Cambia una cadena a mayúsculas tipo título (mayúscula en la primera letra de cada palabra).
                /// </summary>
                public static string ToTitleCase(this string cadena)
                {
                        string Res = " " + cadena.ToLower() + " ";

                        char[] CaracteresSeparadores =
				{
					' ',
					'.',
                                        '"',
                                        '¿',
                                        '¡',
                                        '(',
                                        '"',
					'-'
				};

                        int r = 0;

                        do {
                                r = Res.IndexOfAny(CaracteresSeparadores, r) + 1;

                                if (r > 0 && r < Res.Length) {
                                        Res = Res.Substring(0,
                                                r) + Res.Substring(r,
                                                1).ToUpper() + Res.Substring(r + 1,
                                                Res.Length - r - 1);
                                }
                        } while (r > 0);

                        Res = Res.Replace(" De ", " de ");
                        Res = Res.Replace(" Del ", " del ");
                        Res = Res.Replace(" El ", " el ");
                        Res = Res.Replace(" La ", " la ");
                        Res = Res.Replace(" Pc ", " PC ");
                        Res = Res.Replace(" En ", " en ");
                        Res = Res.Replace(" A ", " a ");
                        Res = Res.Replace(" Las ", " las ");
                        Res = Res.Replace(" Y ", " y ");
                        Res = Res.Replace(" Srl ", " SRL ");
                        Res = Res.Replace(" Sa ", " SA ");

                        Res = Res.Substring(1, Res.Length - 2);
                        if (Res.Length > 0)
                                Res = Res.Substring(0, 1).ToUpper() + Res.Remove(0, 1);

                        return Res;
                }

                public static bool IsNumericInt(this string cadena)
                {
                        decimal transTemp1 = 0;
                        if (decimal.TryParse(cadena,
                                System.Globalization.NumberStyles.Integer,
                                System.Globalization.CultureInfo.InvariantCulture,
                                out transTemp1)) {
                                if (transTemp1 <= int.MaxValue && transTemp1 >= int.MinValue)
                                        return true;
                                else
                                        return false;
                        } else {
                                return false;
                        }
                }

                public static bool IsNumericFloat(this string cadena)
                {
                        decimal transTemp0 = 0;
                        return decimal.TryParse(cadena,
                                System.Globalization.NumberStyles.Float,
                                System.Globalization.CultureInfo.InvariantCulture,
                                out transTemp0);
                }

                public static bool IsDate(this string str)
                {
                        try {
                                return Lfx.Types.Parsing.ParseDate(str) != null;
                        } catch {
                                return false;
                        }
                }


                /// <summary>
                /// Invierte una cadena, caracter por caracter
                /// </summary>
                public static string StrReverse(this string cadena)
                {
                        System.Text.StringBuilder Resultado = new System.Text.StringBuilder();

                        for (int i = cadena.Length - 1; i >= 0; i--) {
                                Resultado.Append(cadena[i]);
                        }
                        return Resultado.ToString();
                }

                /// <summary>
                /// Convierte o unifica fines de línea en formato Windows (CR+LF).
                /// </summary>
                public static string UnixToWindows(this string str)
                {
                        return str.Replace(Lfx.Types.ControlChars.CrLf, Lfx.Types.ControlChars.Lf.ToString()).Replace(Lfx.Types.ControlChars.Lf.ToString(), Lfx.Types.ControlChars.CrLf);
                }


                public static string QuitarAcentos(this string texto)
                {
                        return texto.QuitarAcentos(true);
                }


                /// <summary>
                /// Quita acentos y otros caracteres no estándar. Convierte espacios a subguiones.
                /// </summary>
                public static string QuitarAcentos(this string texto, bool quitarEnie)
                {
                        string res = texto;
                        res = res.Replace("&", "");
                        res = res.Replace("á", "a");
                        res = res.Replace("é", "e");
                        res = res.Replace("í", "i");
                        res = res.Replace("ó", "o");
                        res = res.Replace("ú", "u");
                        res = res.Replace("ü", "u");
                        res = res.Replace("Á", "A");
                        res = res.Replace("É", "E");
                        res = res.Replace("Í", "I");
                        res = res.Replace("Ó", "O");
                        res = res.Replace("Ú", "U");
                        res = res.Replace("Ü", "U");
                        if (quitarEnie) {
                                res = res.Replace("ñ", "n");
                                res = res.Replace("Ñ", "n");
                        }
                        res = res.Replace(" ", "_");
                        return res;
                }
        }
}
