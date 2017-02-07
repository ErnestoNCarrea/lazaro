using System;
using System.Collections.Generic;
using System.Text;
using Lazaro.Orm;

namespace Lfx.Types
{
	public static class Formatting
	{
                public static class DateTime
                {
                        public static readonly string ShortDatePattern = "dd/MM/yyyy";
                        public static readonly string LongDatePattern = @"dddd, d ""de"" MMMM ""de"" yyyy";
                        public static readonly string FullDateTimePattern = "dd/MM/yyyy HH:mm:ss";
                        public static readonly string SqlDateFormat = "yyyy-MM-dd";
                        public static readonly string SqlDateTimeFormat = "yyyy-MM-dd HH:mm:ss";
                        public static readonly string MonthAndYearPattern = @"MMMM ""de"" yyyy";
                        public static readonly string ShortMonthAndYearPattern = @"MMM yyyy";
                }

                public static class Currency
                {
                        public static string CurrentPattern = "0.00";
                }

                public static string SpellNumber(decimal number)
		{
                        return SpellNumber(number, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal > 0);
		}

                public static string SpellNumber(decimal number, bool withDecimals)
		{
			string Numero = System.Convert.ToInt32(Math.Abs(Math.Floor(number))).ToString();
			string NumeroInvertido = Numero.StrReverse().PadRight(32, '0');
                        string Resultado = string.Empty;

                        int Billones = int.Parse(NumeroInvertido.Substring(9, 6).StrReverse());

			if(Billones == 1) {
				Resultado += " un billón";
			} else if(Billones > 0) {
				Resultado += " " + Lfx.Types.Formatting.SpellNumber(Billones, false) + " billones";
			}

                        int Millones = int.Parse(NumeroInvertido.Substring(6, 3).StrReverse());

			if(Millones == 1) {
				Resultado += " un millón";
			} else if(Millones > 0) {
				Resultado += " " + Lfx.Types.Formatting.SpellNumber(Millones, false) + " millones";
			}

			int Miles = int.Parse(NumeroInvertido.Substring(3, 3).StrReverse());

			if(Miles == 1) {
				Resultado += " un mil";
			} else if(Miles > 0) {
				Resultado += " " + Lfx.Types.Formatting.SpellNumber(Miles, false) + " mil";
			}

			switch(int.Parse(NumeroInvertido.Substring(2, 1))) {
				case 1:
					if(int.Parse(Numero.Substring(Numero.Length - 2, 2)) > 0)
						Resultado += " ciento ";
					else
						Resultado += " cien ";
					break;

				case 2:
					Resultado += " doscientos ";
					break;

				case 3:
					Resultado += " trescientos ";
					break;

				case 4:
					Resultado += " cuatrocientos ";
					break;

				case 5:
					Resultado += " quinientos ";
					break;

				case 6:
					Resultado += " seiscientos ";
					break;

				case 7:
					Resultado += " setecientos ";
					break;

				case 8:
					Resultado += " ochocientos ";
					break;

				case 9:
					Resultado += " novecientos ";
					break;
			}

                        if (Numero.Length == 1) {
				switch(int.Parse(Numero)) {
					case 1:
						Resultado += " uno";
						break;

					case 2:
						Resultado += " dos";
						break;

					case 3:
						Resultado += " tres";
						break;

					case 4:
						Resultado += " cuatro";
						break;

					case 5:
						Resultado += " cinco";
						break;

					case 6:
						Resultado += " seis";
						break;

					case 7:
						Resultado += " siete";
						break;

					case 8:
						Resultado += " ocho";
						break;

					case 9:
						Resultado += " nueve";
						break;
				}
			} else {
				switch(int.Parse(Numero.Substring(Numero.Length - 2, 2))) {
                                        case 1:
                                                Resultado += " uno";
                                                break;

                                        case 2:
                                                Resultado += " dos";
                                                break;

                                        case 3:
                                                Resultado += " tres";
                                                break;

                                        case 4:
                                                Resultado += " cuatro";
                                                break;

                                        case 5:
                                                Resultado += " cinco";
                                                break;

                                        case 6:
                                                Resultado += " seis";
                                                break;

                                        case 7:
                                                Resultado += " siete";
                                                break;

                                        case 8:
                                                Resultado += " ocho";
                                                break;

                                        case 9:
                                                Resultado += " nueve";
                                                break;

                                        case 10:
						Resultado += " diez";
						break;

					case 11:
						Resultado += " once";
						break;

					case 12:
						Resultado += " doce";
						break;

					case 13:
						Resultado += " trece";
						break;
					case 14:
						Resultado += " catorce";
						break;

					case 15:
						Resultado += " quince";
						break;

					case 16:
					case 17:
					case 18:
					case 19:
						Resultado += " dieci" + SpellNumber(int.Parse(Numero.Substring(Numero.Length - 1, 1)), false);
						break;

					case 20:
						Resultado += " veinte";
						break;

					case 30:
						Resultado += " treinta";
						break;

					case 40:
						Resultado += " cuarenta";
						break;

					case 50:
						Resultado += " cincuenta";
						break;

					case 60:
						Resultado += " sesenta";
						break;

					case 70:
						Resultado += " setenta";
						break;

					case 80:
						Resultado += " ochenta";
						break;

					case 90:
						Resultado += " noventa";
						break;

					default:
						switch(int.Parse(NumeroInvertido.Substring(1, 1))) {
							case 2:
								Resultado += " veinti" + Lfx.Types.Formatting.SpellNumber(int.Parse(Numero.Substring(Numero.Length - 1, 1)), false);
								break;

							case 3:
								Resultado += " treinta y " + Lfx.Types.Formatting.SpellNumber(int.Parse(Numero.Substring(Numero.Length - 1, 1)), false);
								break;

							case 4:
								Resultado += " cuarenta y " + Lfx.Types.Formatting.SpellNumber(int.Parse(Numero.Substring(Numero.Length - 1, 1)), false);
								break;

							case 5:
								Resultado += " cincuenta y " + Lfx.Types.Formatting.SpellNumber(int.Parse(Numero.Substring(Numero.Length - 1, 1)), false);
								break;

							case 6:
								Resultado += " sesenta y " + Lfx.Types.Formatting.SpellNumber(int.Parse(Numero.Substring(Numero.Length - 1, 1)), false);
								break;

							case 7:
								Resultado += " setenta y " + Lfx.Types.Formatting.SpellNumber(int.Parse(Numero.Substring(Numero.Length - 1, 1)), false);
								break;

							case 8:
								Resultado += " ochenta y " + Lfx.Types.Formatting.SpellNumber(int.Parse(Numero.Substring(Numero.Length - 1, 1)), false);
								break;

							case 9:
								Resultado += " noventa y " + Lfx.Types.Formatting.SpellNumber(int.Parse(Numero.Substring(Numero.Length - 1, 1)), false);
								break;
						}
						break;
				}
			}

			if(withDecimals)
				Resultado += " con " + ((number - Math.Floor(number)) * 100).ToString("00") + "/100.";

			return Resultado.Replace("  ", " ").Trim();
		}

                public static string FormatStock(decimal number, int decimals)
		{
			return FormatNumber(number, decimals);
		}

		public static string FormatStock(decimal number)
		{
			return FormatStock(number, 8);
		}

                public static string FormatStockSql(decimal number, int decimals)
		{
			return FormatNumberSql(number, decimals);
		}

                public static string FormatStockSql(decimal number)
		{
			return FormatStockSql(number, 8);
		}


                public static string FormatNumber(decimal number, int decimals)
                {
                        if (decimals < 0)
                                decimals = 8;
                        return number.ToString("0.".PadRight(decimals + 2, '0'), System.Globalization.CultureInfo.InvariantCulture);
                }


                public static string FormatCurrencySql(decimal numero)
		{
			return FormatCurrencySql(numero, -1, true);
		}

                public static string FormatCurrencySql(decimal numero, int decimales, bool redondeo)
		{
			return FormatCurrency(numero, decimales, redondeo);
		}

                public static string FormatCurrency(decimal numero, int decimales)
		{
			return FormatCurrency(numero, decimales, true);
		}

                public static string FormatCurrency(decimal numero)
                {
                        int decimales = 2;
                        if (Lfx.Workspace.Master != null)
                                decimales = Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales;
                        return FormatCurrency(numero, decimales, true);
                }

                public static string FormatCurrency(decimal numero, int decimales, bool redondeo)
		{
			if(decimales < 0)
				decimales = 2;

			if(redondeo == false) {
				long Expo = System.Convert.ToInt64(Math.Pow(10, decimales));
				numero = System.Math.Floor(numero * Expo) / Expo;
			}

			return numero.ToString("0." + "0000000000".Substring(0, decimales), System.Globalization.CultureInfo.InvariantCulture);
		}

                public static string FormatNumberForPrint(decimal numero, int decimales)
                {
                        return numero.ToString("#,##0." + "0000000000".Substring(0, decimales), System.Globalization.CultureInfo.InvariantCulture); //.Replace(",", "'").Replace(".", ",");
                }

                public static string FormatCurrencyForPrint(decimal numero, int decimales)
		{
			return numero.ToString("#,##0." + "0000000000".Substring(0, decimales), System.Globalization.CultureInfo.InvariantCulture); //.Replace(",", "'").Replace(".", ",");
		}

                /// <summary>
                /// Devuelve una fecha en un formato inteligente, como "hoy", "jueves 14", "12 de mayo" o "3 de febrero de 2009".
                /// </summary>
                public static string FormatSmartDateAndTime(System.DateTime fecha)
                {
                        string Res = "";
                        if (fecha.Year == System.DateTime.Now.Year) {
                                if (fecha.Month == System.DateTime.Now.Month) {
                                        if (fecha.Day == System.DateTime.Now.Day) {
                                                Res += "hoy, " + fecha.ToString("HH:mm");
                                        } else if (fecha.Day == System.DateTime.Now.AddDays(-1).Day) {
                                                Res += "ayer, " + fecha.ToString("HH:mm");
                                        } else if (System.DateTime.Now.Day - fecha.Day < 7) {
                                                Res += fecha.ToString(@"dddd d");
                                        } else {
                                                Res += fecha.ToString(@"dd ""de"" MMMM");
                                        }
                                } else {
                                        Res += fecha.ToString(@"dd ""de"" MMMM, HH:mm");
                                }
                        } else {
                                Res += fecha.ToString(@"dd ""de"" MMMM ""de"" yyyy, HH:mm");
                        }
                        return Res;
                }

                /// <summary>
                /// Devuelve una fecha en un formato inteligente, como "hoy", "12/abr" o "3/feb/09".
                /// Lo hace en el formato más compacto posible, a diferencia de FormatSmartDateAndTime que lo hace en un formato más legible.
                /// </summary>
                public static string FormatShortSmartDateAndTime(System.DateTime fecha)
                {
                        string Res = "";
                        if (fecha.Year == System.DateTime.Now.Year) {
                                if (fecha.Month == System.DateTime.Now.Month) {
                                        if (fecha.Day == System.DateTime.Now.Day) {
                                                Res += "hoy, " + fecha.ToString("HH:mm");
                                        } else if (fecha.Day == System.DateTime.Now.AddDays(-1).Day) {
                                                Res += "ayer, " + fecha.ToString("HH:mm");
                                        } else if (System.DateTime.Now.Day - fecha.Day < 7) {
                                                Res += fecha.ToString(@"ddd d");
                                        } else {
                                                Res += fecha.ToString(@"dd/MMM");
                                        }
                                } else {
                                        Res += fecha.ToString(@"dd/MMM");
                                }
                        } else {
                                Res += fecha.ToString(@"dd/MMM/yy");
                        }
                        return Res;
                }

		public static string FormatDateAndTime(object fecha)
		{
			string formatearFechaYHoraReturn = null;

			if(fecha == null || fecha == DBNull.Value) {
                                return string.Empty;
			} else if(fecha is System.DateTime) {
				return ((System.DateTime)fecha).ToString(Formatting.DateTime.FullDateTimePattern);
			} else {
				string FechaString = System.Convert.ToString(fecha);
				formatearFechaYHoraReturn = FormatDate(fecha);

				if(FechaString.Length >= 8 && System.Text.RegularExpressions.Regex.IsMatch(FechaString.Substring(FechaString.Length - 8, 8), @"^[0-2]\d:[0-5]\d:[0-5]\d$"))
					formatearFechaYHoraReturn += " " + FechaString.Substring(FechaString.Length - 8, 8).Substring(0, 8);
				else if(FechaString.Length >= 5 && System.Text.RegularExpressions.Regex.IsMatch(FechaString.Substring(FechaString.Length - 5, 5), @"^[0-2]\d:[0-5]\d$"))
					formatearFechaYHoraReturn += " " + FechaString.Substring(FechaString.Length - 5, 5);
			}

			return formatearFechaYHoraReturn;
		}


		public static string FormatNumberSql(decimal numero)
		{
			return FormatNumberSql(numero, -1);
		}


                public static string FormatNumberSql(decimal numero, int decimales)
                {
                        string formatearNumeroSqlReturn = null;

                        if (decimales < 0)
                                decimales = 4;

                        formatearNumeroSqlReturn = numero.ToString("0." + "0000000000".Substring(0, decimales),
                                System.Globalization.CultureInfo.InvariantCulture);
                        return formatearNumeroSqlReturn;
                }

                public static string FormatDateSql(System.DateTime Fecha)
                {
                        return Fecha.ToString(Formatting.DateTime.SqlDateFormat);
                }

                public static string FormatDateSql(string Fecha)
                {
                        object Res = FormatDateTimeSql(Fecha);
                        if (Res == null || Res is DBNull)
                                return "";
                        else
                                return FormatDateTimeSql(Fecha).ToString().Substring(0, 10);
                }

		public static string FormatDateTimeSql(System.DateTime Fecha)
		{
                        return Fecha.ToString(Formatting.DateTime.SqlDateTimeFormat);
		}

		public static object FormatDateTimeSql(string fecha)
		{
			object formatearFechaSqlReturn = null;

			// Permite DDMMYYYY, DD-MM-YYYY, DD/MM/YYYY, DDMMYY, DD-MM-YY y DD/MM/YY
			if(fecha.Length > 0) {
				long lngDia = 0;
				long lngMes = 0;
				long lngAnio = 0;

                                fecha = fecha.Trim().Replace("-", string.Empty);
                                fecha = fecha.Replace("/", string.Empty);
                                fecha = fecha.Replace(".", string.Empty);

				lngDia = int.Parse(fecha.Substring(0, 2));
				lngMes = int.Parse(fecha.Substring(2, 2));
				lngAnio = int.Parse(fecha.Substring(4, 4));

				if(lngAnio < 50)
					lngAnio = lngAnio + 2000;
				else if(lngAnio < 100)
					lngAnio = lngAnio + 1900;

				string Resultado = (lngAnio.ToString("0000") + "-" + lngMes.ToString("00") + "-" + lngDia.ToString("00"));

				if(fecha.Length > 9)
					Resultado += " " + fecha.Substring(9, fecha.Length - 9).Trim();

				formatearFechaSqlReturn = Resultado;
			} else {
				formatearFechaSqlReturn = null;
			}

			return formatearFechaSqlReturn;
		}

		public static string FormatDate(object fecha)
		{
                        if (fecha == null || fecha == DBNull.Value) {
                                return string.Empty;
                        } else if (fecha is System.DateTime) {
                                return FormatDate(System.Convert.ToDateTime(fecha).ToString(DateTime.ShortDatePattern));
                        } else if (fecha is DbDateTime) {
                                if (fecha == null)
                                        return string.Empty;
                                else
                                        return FormatDate(((DbDateTime)(fecha)).Value);
                        } else if (fecha is Nullable<System.DateTime>) {
                                System.DateTime? fechaNullable = fecha as System.DateTime?;
                                if (fechaNullable.HasValue)
                                        return FormatDate(fechaNullable.Value);
                                else
                                        return string.Empty;
                        } else {
                                return FormatDate(fecha.ToString());
                        }
		}

		public static string FormatDate(string fecha)
		{
			string formatearFechaReturn = null;

			// Permite DDMMYYYY, DD-MM-YYYY, DD/MM/YYYY, DDMMYY, DD-MM-YY y DD/MM/YY
			if(fecha != null && fecha.Length > 0) {
				int intDia = 0;
				int intMes = 0;
				int intAnio = 0;

				fecha = fecha.Trim().Replace("-", "/").Replace(".", "/");

				string[] Partes = fecha.Split('/');

				if(Partes.Length == 1) {
					// Es una sola pieza... espero que tipo ddmmaaaa
					if(fecha.Length >= 2)
						intDia = Parsing.ParseInt(fecha.Substring(0, 2));

					if(fecha.Length >= 4)
						intMes = Parsing.ParseInt(fecha.Substring(2, 2));

					if(fecha.Length >= 6)
						intAnio = Parsing.ParseInt(fecha.Substring(4, fecha.Length - 4));
					else
						intAnio = System.DateTime.Now.Year;
				} else {
					// Son dos o más piezas (tipo dd/mm o dd/mm/aa, etc.)
					if(System.Convert.ToString(Partes[0]).IsNumericInt())
						intDia = System.Convert.ToInt32(Partes[0]);
					else
						intDia = System.DateTime.Now.Day;

                                        if (Partes.Length >= 2 && System.Convert.ToString(Partes[1]).IsNumericInt())
						intMes = System.Convert.ToInt32(Partes[1]);
					else
						intMes = System.DateTime.Now.Month;

					if(Partes.Length >= 3 && Partes[2].Length > 4)
						Partes[2] = Partes[2].Substring(0, 4);

                                        if (Partes.Length >= 3 && System.Convert.ToString(Partes[2]).IsNumericInt())
						intAnio = System.Convert.ToInt32(Partes[2]);
					else
						intAnio = System.DateTime.Now.Year;
				}

				if(intAnio < 50)
					intAnio = intAnio + 2000;
				else if(intAnio < 100)
					intAnio = intAnio + 1900;

				if(intMes < 1)
					intMes = 1;

				if(intMes > 12)
					intMes = 12;

				if(intDia < 1)
					intDia = 1;

				if(intDia > System.DateTime.DaysInMonth(intAnio, intMes))
                                        intDia = System.DateTime.DaysInMonth(intAnio, intMes);

				formatearFechaReturn = intDia.ToString("00") + "/" + intMes.ToString("00") + "/" + intAnio.ToString("0000");

				if(formatearFechaReturn == "00/00/2000")
					formatearFechaReturn = string.Empty;
			} else {
                                formatearFechaReturn = string.Empty;
			}

			return formatearFechaReturn;
		}
	}
}
