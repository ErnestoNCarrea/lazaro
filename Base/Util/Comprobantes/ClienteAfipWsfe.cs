using System;
using System.Collections.Generic;
using System.Text;
using Afip.Ws.FacturaElectronica;

namespace Lazaro.Base.Util.Comprobantes
{
        public static class ClienteAfipWsfe
        {
                public static Afip.Ws.FacturaElectronica.SolicitudCae CrearSolicitudCae(Lbl.Comprobantes.ComprobanteConArticulos comprobante, int numero)
                {
                        // Crear la solicitud de CAE
                        var SolCae = new Afip.Ws.FacturaElectronica.SolicitudCae()
                        {
                                PuntoDeVenta = comprobante.PV,
                                TipoComprobante = Afip.Ws.FacturaElectronica.Tablas.ComprobantesTiposPorLetra[comprobante.Tipo.Nomenclatura]
                        };

                        // Crear el comprobante asociado
                        var ComprobanteAsociado = new Afip.Ws.FacturaElectronica.ComprobanteAsociado()
                        {
                                Conceptos = (Afip.Ws.FacturaElectronica.Tablas.Conceptos)comprobante.Articulos.ConceptosAfip(),
                                Numero = numero,
                        };

                        if ((ComprobanteAsociado.Conceptos | Tablas.Conceptos.Servicios) == Tablas.Conceptos.Servicios) {
                                foreach (var Art in comprobante.Articulos) {
                                        if (Art.Articulo != null) {
                                                switch (Art.Articulo.Periodicidad) {
                                                        case Lbl.Articulos.Periodicidad.PorSemana:
                                                                DateTime SemanaPasada = DateTime.Now;
                                                                SemanaPasada.AddDays(-7);
                                                                ComprobanteAsociado.ServicioFechaDesde = new DateTime(SemanaPasada.Year, SemanaPasada.Month, SemanaPasada.Day);
                                                                ComprobanteAsociado.ServicioFechaHasta = DateTime.Now;
                                                                break;

                                                        case Lbl.Articulos.Periodicidad.PorMes:
                                                                DateTime MesPasado = DateTime.Now;
                                                                MesPasado.AddMonths(-1);
                                                                ComprobanteAsociado.ServicioFechaDesde = new DateTime(MesPasado.Year, MesPasado.Month, 1);
                                                                ComprobanteAsociado.ServicioFechaHasta = new DateTime(MesPasado.Year, MesPasado.Month, DateTime.DaysInMonth(MesPasado.Year, MesPasado.Month));
                                                                break;

                                                        case Lbl.Articulos.Periodicidad.PorBimestre:
                                                                DateTime MesPasado1 = DateTime.Now;
                                                                MesPasado1.AddMonths(-1);
                                                                DateTime MesPasado2 = DateTime.Now;
                                                                MesPasado2.AddMonths(-2);
                                                                ComprobanteAsociado.ServicioFechaDesde = new DateTime(MesPasado2.Year, MesPasado2.Month, 1);
                                                                ComprobanteAsociado.ServicioFechaHasta = new DateTime(MesPasado1.Year, MesPasado1.Month, DateTime.DaysInMonth(MesPasado1.Year, MesPasado1.Month));
                                                                break;

                                                        case Lbl.Articulos.Periodicidad.PorOcasion:
                                                        case Lbl.Articulos.Periodicidad.PorMinuto:
                                                        case Lbl.Articulos.Periodicidad.PorHora:
                                                        case Lbl.Articulos.Periodicidad.PorDia:
                                                        default:
                                                                ComprobanteAsociado.ServicioFechaDesde = DateTime.Now;
                                                                ComprobanteAsociado.ServicioFechaHasta = ComprobanteAsociado.ServicioFechaDesde;
                                                                break;
                                                }
                                                break;
                                        }
                                }
                                
                                ComprobanteAsociado.FechaVencimientoPago = DateTime.Now;
                        }

                        // Asignar cliente al comprobante
                        if (comprobante.Cliente.SituacionTributaria == null || comprobante.Cliente.SituacionTributaria.EsConsumidorFinal) {
                                if (string.IsNullOrEmpty(comprobante.Cliente.NumeroDocumento)) {
                                        ComprobanteAsociado.Cliente = new Afip.Ws.FacturaElectronica.Cliente()
                                        {
                                                DocumentoTipo = Afip.Ws.FacturaElectronica.Tablas.DocumentoTipos.SinIdentificar,
                                                DocumentoNumero = Lfx.Types.Parsing.ParseInt(comprobante.Cliente.NumeroDocumento)
                                        };
                                } else {
                                        ComprobanteAsociado.Cliente = new Afip.Ws.FacturaElectronica.Cliente()
                                        {
                                                DocumentoTipo = Afip.Ws.FacturaElectronica.Tablas.DocumentoTipos.Dni,
                                                DocumentoNumero = Lfx.Types.Parsing.ParseInt(comprobante.Cliente.NumeroDocumento)
                                        };
                                }
                        } else {
                                long DocNro = 0;
                                long.TryParse(comprobante.Cliente.Cuit.ToString().Replace("-", "").Replace(" ", "").Replace("/", "").Replace(".", ""), System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out DocNro);
                                ComprobanteAsociado.Cliente = new Afip.Ws.FacturaElectronica.Cliente()
                                {
                                        DocumentoTipo = Afip.Ws.FacturaElectronica.Tablas.DocumentoTipos.Cuit,
                                        DocumentoNumero = DocNro
                                };
                                
                        }

                        // Agregar conceptos al comprobante, agrupados por alícuota
                        if(comprobante.Tipo.Letra == "C") {
                                // El comprobante C lleva características especiales
                                ComprobanteAsociado.ImporteNetoGravado = comprobante.Total;
                        } else if(comprobante.Cliente.PagaIva == Lbl.Impuestos.SituacionIva.Exento) {
                                // Cliente exento... una sóla alícuota al 0% por el total
                                ComprobanteAsociado.ImportesAlicuotas.Add(new Afip.Ws.FacturaElectronica.ImporteAlicuota()
                                {
                                        Alicuota = Afip.Ws.FacturaElectronica.Tablas.Alicuotas.Iva0,
                                        BaseImponible = comprobante.Total,
                                        Importe = 0m
                                });
                                ComprobanteAsociado.ImporteNetoGravado = ComprobanteAsociado.ImportesAlicuotas.ImporteNetoGravado();
                        } else {
                                // Agregar una o más alícuotas de IVA
                                var Alicuotas = comprobante.AlicuotasUsadas();
                                foreach (Lbl.Impuestos.Alicuota Alic in Alicuotas.Values) {
                                        decimal ImporteIva = comprobante.TotalIvaAlicuota(Alic.Id);
                                        decimal ImporteGravado = comprobante.TotalConIvaAlicuota(Alic.Id) - ImporteIva;

                                        ComprobanteAsociado.ImportesAlicuotas.Add(new Afip.Ws.FacturaElectronica.ImporteAlicuota()
                                        {
                                                Alicuota = (Afip.Ws.FacturaElectronica.Tablas.Alicuotas)Lbl.Archivos.Salida.CitiTablas.Alicuotas[Alic.Id],
                                                BaseImponible = ImporteGravado,
                                                Importe = ImporteIva
                                        });
                                }
                                ComprobanteAsociado.ImporteNetoGravado = ComprobanteAsociado.ImportesAlicuotas.ImporteNetoGravado();
                        }

                        // Agregar el comprobante asociado a la solicitud de CAE
                        SolCae.Comprobantes = new Afip.Ws.FacturaElectronica.ColeccionComprobantesAsociados()
                        {
                                ComprobanteAsociado
                        };

                        return SolCae;
                }
        }
}
