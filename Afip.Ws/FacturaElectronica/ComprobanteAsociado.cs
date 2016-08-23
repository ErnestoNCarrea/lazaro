using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afip.Ws.FacturaElectronica
{
        /// <summary>
        /// Representa un comprobante asociado a una solicitud de CAE.
        /// </summary>
        public class ComprobanteAsociado
        {
                /// <summary>
                /// El número de comprobante.
                /// </summary>
                public int Numero { get; set; }

                /// <summary>
                /// Los conceptos contenidos en el comprobante.
                /// </summary>
                public Tablas.Conceptos Conceptos { get; set; }

                /// <summary>
                /// El cliente.
                /// </summary>
                public Cliente Cliente { get; set; }

                /// <summary>
                /// El importe neto gravado.
                /// </summary>
                public decimal ImporteNetoGravado { get; set; }

                /// <summary>
                /// El importe neto no gravado.
                /// </summary>
                public decimal ImporteNetoNoGravado { get; set; }

                /// <summary>
                /// El importe exento.
                /// </summary>
                public decimal ImporteExento { get; set; }

                /// <summary>
                /// El importe total de otros tributos.
                /// </summary>
                public decimal ImporteTributos { get; set; }

                /// <summary>
                /// Para facturas de servicios, la fecha de inicio de los servicios facturados.
                /// </summary>
                public DateTime ServicioFechaDesde { get; set; }
                
                /// <summary>
                /// Para facturas de servicios, la fecha de fin de los servicios facturados.
                /// </summary>
                public DateTime ServicioFechaHasta { get; set; }
                
                /// <summary>
                /// La fecha de vencimiento para el pago de la factura.
                /// </summary>
                public DateTime FechaVencimientoPago { get; set; }

                /// <summary>
                /// Contiene el CAE una vez autorizado el comprobante.
                /// </summary>
                public Cae Cae { get; set; }

                /// <summary>
                /// Contiene las observaciones una vez autorizado o rechazado el comprobante.
                /// </summary>
                public Observacion Obs { get; set; }


                public ComprobanteAsociado()
                {
                        this.ImportesAlicuotas = new Afip.Ws.FacturaElectronica.ColeccionImportesAlicuotas();
                }

                /// <summary>
                /// Una lista de los importes correspondientes a cada alícuota de IVA.
                /// </summary>
                public ColeccionImportesAlicuotas ImportesAlicuotas { get; set; }

                /// <summary>
                /// Devuelve el total del comprobante. 
                /// Según AFIP: debe ser igual a Importe neto no gravado + Importe exento + Importe neto gravado + todos los campos de IVA al XX% + Importe de tributos.
                /// </summary>
                public decimal ImporteTotal()
                {
                        return this.ImporteNetoNoGravado + this.ImporteExento + this.ImporteNetoGravado + this.ImporteIva() + this.ImporteTributos;
                }

                /* /// <summary>
                /// Devuelve el total de neto gravado (bases imponibles), tomado de la colección de alícuotas.
                /// </summary>
                public decimal ImporteNetoGravado()
                {
                        if (this.ImportesAlicuotas == null) {
                                return 0;
                        } else {
                                return this.ImportesAlicuotas.ImporteNetoGravado();
                        }
                } */

                /// <summary>
                /// Devuelve el total de IVA, tomado de la colección de alícuotas.
                /// </summary>
                public decimal ImporteIva()
                {
                        if(this.ImportesAlicuotas == null) {
                                return 0;
                        } else {
                                return this.ImportesAlicuotas.ImporteIva();
                        }
                }
        }
}
