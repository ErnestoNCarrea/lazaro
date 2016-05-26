using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Archivos
{
        /// <summary>
        /// Clase base para archivos de entrada o salida con Comprobantes.
        /// </summary>
        public abstract class ArchivoConComprobantesFacturables : Archivo
        {
                public DateTime FechaCompensacion, FechaArchivo;
                public System.Collections.Generic.List<Lbl.Comprobantes.ComprobanteFacturable> Comprobantes;

                public ArchivoConComprobantesFacturables()
                        : base()
                {
                        Comprobantes = new List<Lbl.Comprobantes.ComprobanteFacturable>();
                }

                public ArchivoConComprobantesFacturables(Lfx.Types.OperationProgress progreso)
                        : this()
                {
                        this.Progreso = progreso;
                }

                /// <summary>
                /// Devuelve el importe total de los comprobantes facturables.
                /// </summary>
                public decimal Total
                {
                        get
                        {
                                decimal Res = 0;
                                foreach (Lbl.Comprobantes.Comprobante C in this.Comprobantes) {
                                        Res += C.Total;
                                }
                                return Res;
                        }
                }

                /// <summary>
                /// Devuelve un nuevo objeto ArchivoConComprobanteFacturable conteniendo sólamente los comprobantes de las fechas seleccionadas.
                /// </summary>
                /// <param name="fechas">La lista de fechas a incluir</param>
                /// <returns>Objeto ArchivoConComprobanteFacturable conteniendo sólamente los comprobantes de las fechas seleccionadas.</returns>
                public ArchivoConComprobantesFacturables FiltrarFechas(IList<DateTime> fechas)
                {
                        ArchivoConComprobantesFacturables Res = (ArchivoConComprobantesFacturables)this.MemberwiseClone();
                        Res.Comprobantes = new List<Lbl.Comprobantes.ComprobanteFacturable>();
                        foreach (Lbl.Comprobantes.ComprobanteFacturable C in this.Comprobantes) {
                                if (fechas.Contains(C.Fecha))
                                        Res.Comprobantes.Add(C);
                        }
                        return Res;
                }

                /// <summary>
                /// Devuelve un diccionario con los importes totales para cada cliente que tiene transacciones.
                /// </summary>
                public System.Collections.Generic.Dictionary<string, decimal> TotalesPorCliente()
                {
                        System.Collections.Generic.Dictionary<string, decimal> Res = new Dictionary<string, decimal>();
                        foreach (Lbl.Comprobantes.Comprobante Cf in this.Comprobantes) {
                                if (Res.ContainsKey(Cf.Cliente.ToString())) {
                                        Res[Cf.Cliente.ToString()] += Cf.Total;
                                } else {
                                        Res[Cf.Cliente.ToString()] = Cf.Total;
                                }
                        }
                        return Res;
                }

                /// <summary>
                /// Devuelve un diccionario con los importes totales para cada fecha en la que hay transacciones.
                /// </summary>
                public System.Collections.Generic.Dictionary<DateTime, decimal> TotalesPorFecha()
                {
                        System.Collections.Generic.Dictionary<DateTime, decimal> Res = new Dictionary<DateTime, decimal>();
                        foreach (Lbl.Comprobantes.Comprobante Cf in this.Comprobantes) {
                                if (Res.ContainsKey(Cf.Fecha)) {
                                        Res[Cf.Fecha] += Cf.Total;
                                } else {
                                        Res[Cf.Fecha] = Cf.Total;
                                }
                        }
                        return Res;
                }
        }
}
