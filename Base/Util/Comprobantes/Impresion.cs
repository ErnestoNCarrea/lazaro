using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lazaro.Base.Util.Comprobantes
{
        public static class Impresion
        {
                public static Lbl.Impresion.Plantilla ObtenerPlantilla(Lbl.Comprobantes.Comprobante comprobante)
                {
                        if (Lbl.Impresion.Plantilla.TodasPorCodigo.ContainsKey(comprobante.Tipo.Nomenclatura)) {
                                // Busco una plantilla para el tipo exacto
                                return Lbl.Impresion.Plantilla.TodasPorCodigo[comprobante.Tipo.Nomenclatura];
                        } else if (comprobante.Tipo.EsFacturaNCoND && Lbl.Impresion.Plantilla.TodasPorCodigo.ContainsKey("F" + comprobante.Tipo.Letra)) {
                                // En caso de NC y ND, pruebo utilizando la plantilla de facturas
                                return Lbl.Impresion.Plantilla.TodasPorCodigo["F" + comprobante.Tipo.Letra];
                        } else {
                                // TODO: return base.ObtenerPlantilla();
                                return null;
                        }
                }


                public static Lbl.Impresion.Impresora ObtenerImpresora(Lbl.Comprobantes.Comprobante comprobante)
                {
                        // Primero busco una una impresora específica para este comprobante
                        Lbl.Impresion.Impresora Res = comprobante.ObtenerImpresora();

                        // Si no hay, devuelvo la impresora para este tipo de elemento
                        if (Res == null) {
                                // TODO: return base.ObtenerImpresora();
                                return null;
                        } else {
                                return Res;
                        }
                }

                public static Lbl.Impresion.ClasesImpresora ObtenerClaseImpresora(Lbl.Comprobantes.Comprobante comprobante)
                {
                        Lbl.Impresion.ClasesImpresora Res;
                        if (Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero.ContainsKey(comprobante.PV)) {
                                switch (Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero[comprobante.PV].Tipo) {
                                        case Lbl.Comprobantes.TipoPv.Talonario:
                                                Res = Lbl.Impresion.ClasesImpresora.Papel;
                                                break;

                                        case Lbl.Comprobantes.TipoPv.ControladorFiscal:
                                                Res = Lbl.Impresion.ClasesImpresora.FiscalAfip;
                                                break;

                                        case Lbl.Comprobantes.TipoPv.ElectronicoAfip:
                                                Res = Lbl.Impresion.ClasesImpresora.ElectronicaAfip;
                                                break;

                                        case Lbl.Comprobantes.TipoPv.Inactivo:
                                                throw new ApplicationException("No se puede imprimir en un PV inactivo.");

                                        default:
                                                throw new ApplicationException("Tipo de PV no reconocido " + Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero[comprobante.PV].Tipo.ToString());
                                }
                        } else {
                                Res = Lbl.Impresion.ClasesImpresora.Papel;
                        }

                        return Res;
                }
        }
}
