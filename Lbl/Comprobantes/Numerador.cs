using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
	public class Numerador
	{
                public static int ProximoNumero(Lbl.Comprobantes.Comprobante comprobante)
                {
                        string TipoReal = "";

                        // Las notas de crédito y débito comparten la numeración de las comprob
                        switch (comprobante.Tipo.Nomenclatura) {
                                case "A":
                                case "FA":
                                case "NCA":
                                case "NDA":
                                        TipoReal = "'FA', 'NCA', 'NDA'";
                                        break;

                                case "B":
                                case "FB":
                                case "NCB":
                                case "NDB":
                                        TipoReal = "'FB', 'NCB', 'NDB'";
                                        break;

                                case "C":
                                case "FC":
                                case "NCC":
                                case "NDC":
                                        TipoReal = "'FC', 'NCC', 'NDC'";
                                        break;

                                case "E":
                                case "FE":
                                case "NCE":
                                case "NDE":
                                        TipoReal = "'FE', 'NCE', 'NDE'";
                                        break;

                                case "M":
                                case "FM":
                                case "NCM":
                                case "NDM":
                                        TipoReal = "'FM', 'NCM', 'NDM'";
                                        break;

                                default:
                                        TipoReal = "'" + comprobante.Tipo.Nomenclatura + "'";
                                        break;
                        }

                        string SqlWhere = "pv=" + comprobante.PV.ToString() + " AND tipo_fac IN (" + TipoReal + ")";
                        if (comprobante is Lbl.Comprobantes.ComprobanteConArticulos) {
                                // Si es comprobante con artículos, agrego una condicion más para los comprobantes de compra
                                SqlWhere += " AND compra=" + (((Lbl.Comprobantes.ComprobanteConArticulos)(comprobante)).Compra ? "1" : "0");
                        }

                        return comprobante.Connection.FieldInt("SELECT MAX(numero) FROM " + comprobante.TablaDatos + " WHERE " + SqlWhere) + 1;
                }
	}
}
