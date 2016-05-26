using System;
using System.Collections.Generic;
using System.Text;

namespace Lfx.Types
{
        public enum DateRangeTypes
        {
                All,
                Day,
                Week,
                Month,
                Range
        }

        public class DateRange
        {
                public string Rep = "*";
                private DateTime m_From, m_To;
                public bool AllowPast { get; set; }
                public bool AllowFuture { get; set; }

                public DateRange()
                {
                        this.AllowFuture = false;
                        this.AllowPast = true;
                }

                public DateRange(string rep)
                        : this()
                {
                        this.Rep = rep;
                }


                public DateRange(DateTime from, DateTime to)
                        : this()
                {
                        this.Rep = "-";
                        this.From = from;
                        this.To = to;
                }


                public bool HasRange
                {
                        get
                        {
                                return this.RangeType != DateRangeTypes.All;
                        }
                }

                public TimeSpan Diff
                {
                        get
                        {
                                TimeSpan Diff = this.To - this.From;
                                return Diff;
                        }
                }

                public DateRangeTypes RangeType
                {
                        get
                        {
                                if (this.Rep == "mes" || this.Rep.StartsWith("mes-") || this.Rep.StartsWith("mes+"))
                                        return DateRangeTypes.Month;
                                else if (this.Rep == "dia" || this.Rep.StartsWith("dia-") || this.Rep.StartsWith("dia+"))
                                        return DateRangeTypes.Day;
                                else if (this.Rep == "semana" || this.Rep.StartsWith("semana-") || this.Rep.StartsWith("semana+"))
                                        return DateRangeTypes.Week;
                                else if (this.Rep == "*")
                                        return DateRangeTypes.All;
                                else if (this.Rep == "-")
                                        return DateRangeTypes.Range;
                                else
                                        throw new InvalidOperationException("DateRange: representación inválida (" + this.Rep + ")");
                        }
                }

                /// <summary>
                /// Devuelve la fecha inicial del rango, con hora 00:00:00.
                /// </summary>
                public DateTime From
                {
                        get
                        {
                                DateTime RawDate = this.InternalFrom;
                                return new DateTime(RawDate.Year, RawDate.Month, RawDate.Day, 0, 0, 0);
                        }
                        set
                        {
                                m_From = value;
                        }
                }

                /// <summary>
                /// Devuelve la fecha final del rango, con hora 23:59:59.
                /// </summary>
                public DateTime To
                {
                        get
                        {
                                DateTime RawDate = this.InternalTo;
                                return new DateTime(RawDate.Year, RawDate.Month, RawDate.Day, 23, 59, 59);
                        }
                        set
                        {
                                m_To = value;
                        }
                }

                /// <summary>
                /// Devuelve lo mismo que this.From, pero sin tener cuidado de la hora.
                /// </summary>
                private DateTime InternalFrom
                {
                        get
                        {
                                switch(this.Rep) {
                                        case "dia-0":
                                        case "dia+0":
                                                return DateTime.Now;
                                        case "dia-1":
                                                return DateTime.Now.AddDays(-1);
                                        case "dia-2":
                                                return DateTime.Now.AddDays(-2);
                                        case "dia-3":
                                                return DateTime.Now.AddDays(-3);
                                        case "dia-4":
                                                return DateTime.Now.AddDays(-4);
                                        case "dia-5":
                                                return DateTime.Now.AddDays(-5);
                                        case "dia+1":
                                                return DateTime.Now.AddDays(1);
                                        case "dia+2":
                                                return DateTime.Now.AddDays(2);
                                        case "dia+3":
                                                return DateTime.Now.AddDays(3);
                                        case "dia+4":
                                                return DateTime.Now.AddDays(4);
                                        case "dia+5":
                                                return DateTime.Now.AddDays(5);
                                        case "dia":
                                                return m_From;

                                        case "semana-0":
                                                return DateTime.Now.AddDays(-((int)(DateTime.Now.DayOfWeek)));

                                        case "semana-1":
                                                return DateTime.Now.AddDays(-((int)(DateTime.Now.DayOfWeek)) - 7);

                                        case "semana-2":
                                                return DateTime.Now.AddDays(-((int)(DateTime.Now.DayOfWeek)) - 14);

                                        case "semana-3":
                                                return DateTime.Now.AddDays(-((int)(DateTime.Now.DayOfWeek)) - 21);

                                        case "semana+1":
                                                return DateTime.Now.AddDays(-((int)(DateTime.Now.DayOfWeek)) + 7);

                                        case "semana":
                                                return m_From.AddDays(-((int)(m_From.DayOfWeek)));

                                        case "mes-0":
                                        case "mes+0":
                                                return new DateTime(DateTime.Now.Year,DateTime.Now.Month, 1);
                                        case "mes-1":
                                                return new DateTime(DateTime.Now.AddMonths(-1).Year, DateTime.Now.AddMonths(-1).Month, 1);
                                        case "mes-2":
                                                return new DateTime(DateTime.Now.AddMonths(-2).Year, DateTime.Now.AddMonths(-2).Month, 1);
                                        case "mes-3":
                                                return new DateTime(DateTime.Now.AddMonths(-3).Year, DateTime.Now.AddMonths(-3).Month, 1);
                                        case "mes-4":
                                                return new DateTime(DateTime.Now.AddMonths(-4).Year, DateTime.Now.AddMonths(-4).Month, 1);
                                        case "mes-5":
                                                return new DateTime(DateTime.Now.AddMonths(-5).Year, DateTime.Now.AddMonths(-5).Month, 1);
                                        case "mes-6":
                                                return new DateTime(DateTime.Now.AddMonths(-6).Year, DateTime.Now.AddMonths(-6).Month, 1);
                                        case "mes-7":
                                                return new DateTime(DateTime.Now.AddMonths(-7).Year, DateTime.Now.AddMonths(-7).Month, 1);
                                        case "mes-8":
                                                return new DateTime(DateTime.Now.AddMonths(-8).Year, DateTime.Now.AddMonths(-8).Month, 1);
                                        case "mes+1":
                                                return new DateTime(DateTime.Now.AddMonths(1).Year, DateTime.Now.AddMonths(1).Month, 1);
                                        case "mes+2":
                                                return new DateTime(DateTime.Now.AddMonths(2).Year, DateTime.Now.AddMonths(2).Month, 1);
                                        case "mes+3":
                                                return new DateTime(DateTime.Now.AddMonths(3).Year, DateTime.Now.AddMonths(3).Month, 1);
                                        case "mes+4":
                                                return new DateTime(DateTime.Now.AddMonths(4).Year, DateTime.Now.AddMonths(4).Month, 1);
                                        case "mes+5":
                                                return new DateTime(DateTime.Now.AddMonths(5).Year, DateTime.Now.AddMonths(5).Month, 1);
                                        case "mes+6":
                                                return new DateTime(DateTime.Now.AddMonths(6).Year, DateTime.Now.AddMonths(6).Month, 1);
                                        case "mes+7":
                                                return new DateTime(DateTime.Now.AddMonths(7).Year, DateTime.Now.AddMonths(7).Month, 1);
                                        case "mes+8":
                                                return new DateTime(DateTime.Now.AddMonths(8).Year, DateTime.Now.AddMonths(8).Month, 1);

                                        case "*":
                                                return m_From;

                                        default:
                                                return m_From;
                                }
                        }
                }

                /// <summary>
                /// Devuelve lo mismo que this.To, pero sin tener cuidado de la hora.
                /// </summary>
                private DateTime InternalTo
                {
                        get
                        {
                                if (this.Rep == "dia" || this.Rep.StartsWith("dia-") || this.Rep.StartsWith("dia+"))
                                                return this.From;
                                if (this.Rep == "semana" || this.Rep.StartsWith("semana-") || this.Rep.StartsWith("semana+"))
                                                return this.From.AddDays(7);
                                if (this.Rep == "mes" || this.Rep.StartsWith("mes-") || this.Rep.StartsWith("mes+"))
                                                return new DateTime(this.From.Year, this.From.Month, System.DateTime.DaysInMonth(this.From.Year, this.From.Month));
                                else
                                                return m_To;
                        }
                }

                public override string ToString()
                {
                        switch (this.Rep) {
                                case "dia-0":
                                        return "hoy";
                                case "dia-1":
                                        return "ayer";
                                case "dia-2":
                                        return "anteayer";
                                case "dia-3":
                                case "dia-4":
                                case "dia-5":
                                case "dia+3":
                                case "dia+4":
                                case "dia+5":
                                        return "el " + this.From.ToString("dddd d");
                                case "dia":
                                        return "el " + this.From.ToString(Lfx.Types.Formatting.DateTime.ShortDatePattern);
                                case "dia+1":
                                        return "mañana";
                                case "dia+2":
                                        return "pasado mañana";

                                case "semana-0":
                                        return "esta semana";
                                case "semana-1":
                                        return "la semana pasada";
                                case "semana+1":
                                        return "la semana que viene";
                                case "semana-2":
                                case "semana-3":
                                case "semana+2":
                                case "semana+3":
                                        return "la semana del " + this.From.ToString("dd/MM") + " al " + this.From.ToString("dd/MM");
                                case "semana":
                                        return "la semana del " + this.From.ToString("dd/MM") + " al " + this.From.ToString("dd/MM/yyyy");

                                case "mes-0":
                                        return "este mes";
                                case "mes-1":
                                        return "el mes pasado";
                                case "mes+1":
                                        return "el mes que viene";
                                case "mes-2":
                                case "mes-3":
                                case "mes-4":
                                case "mes-5":
                                case "mes-6":
                                case "mes-7":
                                case "mes-8":
                                case "mes+2":
                                case "mes+3":
                                case "mes+4":
                                case "mes+5":
                                case "mes+6":
                                case "mes+7":
                                case "mes+8":
                                        return this.From.ToString("MMMM");

                                case "*":
                                        return "cualquiera";

                                default:
                                        if (this.From.Year == this.To.Year && this.From.Year == DateTime.Now.Year)
                                                return "del " + this.From.ToString("dd/MM") + " al " + this.From.ToString("dd/MM");
                                        else
                                                return "del " + this.From.ToString("dd/MM/yyyy") + " al " + this.From.ToString("dd/MM/yyyy");
                        }
                }
        }
}