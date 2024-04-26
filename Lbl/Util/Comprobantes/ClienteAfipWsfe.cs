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
                        var ComprobanteSolCae = new Afip.Ws.FacturaElectronica.ComprobanteSolicitud()
                        {
                                Conceptos = (Afip.Ws.FacturaElectronica.Tablas.Conceptos)comprobante.Articulos.ConceptosAfip(),
                                Numero = numero,
                        };

                        if ((ComprobanteSolCae.Conceptos | Tablas.Conceptos.Servicios) == Tablas.Conceptos.Servicios) {
                                foreach (var Art in comprobante.Articulos) {
                                        if (Art.Articulo != null) {
                                                switch (Art.Articulo.Periodicidad) {
                                                        case Lbl.Articulos.Periodicidad.PorSemana:
                                                                DateTime SemanaPasada = DateTime.Now;
                                                                SemanaPasada.AddDays(-7);
                                                                ComprobanteSolCae.ServicioFechaDesde = new DateTime(SemanaPasada.Year, SemanaPasada.Month, SemanaPasada.Day);
                                                                ComprobanteSolCae.ServicioFechaHasta = DateTime.Now;
                                                                break;

                                                        case Lbl.Articulos.Periodicidad.PorMes:
                                                                DateTime MesPasado = DateTime.Now;
                                                                MesPasado.AddMonths(-1);
                                                                ComprobanteSolCae.ServicioFechaDesde = new DateTime(MesPasado.Year, MesPasado.Month, 1);
                                                                ComprobanteSolCae.ServicioFechaHasta = new DateTime(MesPasado.Year, MesPasado.Month, DateTime.DaysInMonth(MesPasado.Year, MesPasado.Month));
                                                                break;

                                                        case Lbl.Articulos.Periodicidad.PorBimestre:
                                                                DateTime MesPasado1 = DateTime.Now;
                                                                MesPasado1.AddMonths(-1);
                                                                DateTime MesPasado2 = DateTime.Now;
                                                                MesPasado2.AddMonths(-2);
                                                                ComprobanteSolCae.ServicioFechaDesde = new DateTime(MesPasado2.Year, MesPasado2.Month, 1);
                                                                ComprobanteSolCae.ServicioFechaHasta = new DateTime(MesPasado1.Year, MesPasado1.Month, DateTime.DaysInMonth(MesPasado1.Year, MesPasado1.Month));
                                                                break;

                                                        case Lbl.Articulos.Periodicidad.PorOcasion:
                                                        case Lbl.Articulos.Periodicidad.PorMinuto:
                                                        case Lbl.Articulos.Periodicidad.PorHora:
                                                        case Lbl.Articulos.Periodicidad.PorDia:
                                                        default:
                                                                ComprobanteSolCae.ServicioFechaDesde = DateTime.Now;
                                                                ComprobanteSolCae.ServicioFechaHasta = ComprobanteSolCae.ServicioFechaDesde;
                                                                break;
                                                }
                                                break;
                                        }
                                }
                                
                                ComprobanteSolCae.FechaVencimientoPago = DateTime.Now;
                        }

                        // Asignar cliente al comprobante
                        if (comprobante.Cliente.SituacionTributaria == null || comprobante.Cliente.SituacionTributaria.EsConsumidorFinal) {
                                if (string.IsNullOrEmpty(comprobante.Cliente.NumeroDocumento)) {
                                        ComprobanteSolCae.Cliente = new Afip.Ws.FacturaElectronica.Cliente()
                                        {
                                                DocumentoTipo = Afip.Ws.FacturaElectronica.Tablas.DocumentoTipos.SinIdentificar,
                                                DocumentoNumero = Lfx.Types.Parsing.ParseInt(comprobante.Cliente.NumeroDocumento)
                                        };
                                } else {
                                        ComprobanteSolCae.Cliente = new Afip.Ws.FacturaElectronica.Cliente()
                                        {
                                                DocumentoTipo = Afip.Ws.FacturaElectronica.Tablas.DocumentoTipos.Dni,
                                                DocumentoNumero = Lfx.Types.Parsing.ParseInt(comprobante.Cliente.NumeroDocumento)
                                        };
                                }
                        } else {
                                long DocNro = 0;
                                long.TryParse(comprobante.Cliente.Cuit.ToString().Replace("-", "").Replace(" ", "").Replace("/", "").Replace(".", ""), System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out DocNro);
                                ComprobanteSolCae.Cliente = new Afip.Ws.FacturaElectronica.Cliente()
                                {
                                        DocumentoTipo = Afip.Ws.FacturaElectronica.Tablas.DocumentoTipos.Cuit,
                                        DocumentoNumero = DocNro
                                };
                                
                        }

                        // Agregar conceptos al comprobante, agrupados por alícuota
                        if(comprobante.Tipo.Letra == "C") {
                                // El comprobante C lleva características especiales
                                ComprobanteSolCae.ImporteNetoGravado = comprobante.Total;
                        } else if(comprobante.Cliente.ObtenerSituacionIva() == Lbl.Impuestos.SituacionIva.Exento) {
                                // Cliente exento... una sóla alícuota al 0% por el total
                                ComprobanteSolCae.ImportesAlicuotas.Add(new Afip.Ws.FacturaElectronica.ImporteAlicuota()
                                {
                                        Alicuota = Afip.Ws.FacturaElectronica.Tablas.Alicuotas.Iva0,
                                        BaseImponible = comprobante.Total,
                                        Importe = 0m
                                });
                                ComprobanteSolCae.ImporteNetoGravado = ComprobanteSolCae.ImportesAlicuotas.ImporteNetoGravado();
                        } else {
                                // Agregar una o más alícuotas de IVA
                                var Alicuotas = comprobante.AlicuotasUsadas();
                                foreach (Lbl.Impuestos.Alicuota Alic in Alicuotas.Values) {
                                        decimal ImporteIva = comprobante.TotalIvaAlicuota(Alic.Id);
                                        decimal ImporteGravado = comprobante.ImporteGravadoAlicuota(Alic.Id);

                                        ComprobanteSolCae.ImportesAlicuotas.Add(new Afip.Ws.FacturaElectronica.ImporteAlicuota()
                                        {
                                                Alicuota = (Afip.Ws.FacturaElectronica.Tablas.Alicuotas)Lbl.Archivos.Salida.CitiTablas.Alicuotas[Alic.Id],
                                                BaseImponible = ImporteGravado,
                                                Importe = ImporteIva
                                        });
                                }
                                ComprobanteSolCae.ImporteNetoGravado = ComprobanteSolCae.ImportesAlicuotas.ImporteNetoGravado();
                        }

                        if (comprobante.ComprobanteOriginal != null)
                        {
                                ComprobanteSolCae.ComprobantesAsociados = new List<ComprobanteAsociado>()
                                {
                                        new ComprobanteAsociado
                                        {
                                                PuntoDeVenta = comprobante.ComprobanteOriginal.PV,
                                                Tipo = Afip.Ws.FacturaElectronica.Tablas.ComprobantesTiposPorLetra[comprobante.ComprobanteOriginal.Tipo.Nomenclatura],
                                                Cuit= comprobante.ComprobanteOriginal.Cliente.Cuit.ToString().Replace("-", "").Replace(" ", "").Replace(".", ""),
                                                Fecha = comprobante.ComprobanteOriginal.Fecha,
                                                Numero = comprobante.ComprobanteOriginal.Numero
                                        }
                                };
                        }

                        // Agregar el comprobante asociado a la solicitud de CAE
                        SolCae.Comprobantes = new Afip.Ws.FacturaElectronica.ColeccionComprobantesSolicitud()
                        {
                                ComprobanteSolCae
                        };

                        return SolCae;
                }
        }
}
