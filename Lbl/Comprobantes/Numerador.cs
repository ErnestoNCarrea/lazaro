using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
	public class Numerador
	{
                protected Lbl.Comprobantes.Comprobante Comprob;

                public Numerador(Lbl.Comprobantes.Comprobante comprob)
                {
                        this.Comprob = comprob;
                }

                /// <summary>
                /// Numerar el comprobante. Ver Numerar(numero, cae, vencimientoCae, yMarcarComoImpreso) 
                /// </summary>
                public void Numerar(int numero, bool yMarcarComoImpreso)
                {
                        this.Numerar(numero, null, null, yMarcarComoImpreso);
                }

                /// <summary>
                /// Numera el comprobante (usando el número especificado), guardando automáticamente los cambios.
                /// </summary>
                /// <param name="numero">El número que se asignó a este comprobante.</param>
                /// <param name="cae">El CAE (sólo factura electrónica AFIP).</param>
                /// <param name="vencimientoCae">La fecha de vencimiento del CAE.</param>
                /// <param name="yMarcarComoImpreso">Si es Verdadero, el comprobante se marca como impreso y se actualiza la fecha.</param>
                public void Numerar(int numero, string cae, DateTime? vencimientoCae, bool yMarcarComoImpreso)
                {
                        qGen.Update ActualizarComprob = new qGen.Update(this.Comprob.TablaDatos);

                        // Modifico Registro para no volver a cargar el comprobante desde la BD
                        this.Comprob.Numero = numero;
                        this.Comprob.Registro["numero"] = this.Comprob.Numero;
                        ActualizarComprob.ColumnValues.AddWithValue("numero", numero);

                        string Nombre = this.Comprob.PV.ToString("0000") + "-" + numero.ToString("00000000");
                        this.Comprob.Nombre = Nombre;
                        this.Comprob.Registro["nombre"] = this.Comprob.Nombre;
                        ActualizarComprob.ColumnValues.AddWithValue("nombre", Nombre);

                        if (yMarcarComoImpreso) {
                                this.Comprob.Estado = 1;
                                this.Comprob.Registro["estado"] = this.Comprob.Estado;
                                ActualizarComprob.ColumnValues.AddWithValue("estado", 1);

                                this.Comprob.Fecha = this.Comprob.Connection.ServerDateTime;
                                this.Comprob.Registro["fecha"] = this.Comprob.Fecha;
                                ActualizarComprob.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));

                                if (this.Comprob.TablaDatos == "recibos") {
                                        this.Comprob.Impreso = true;
                                        this.Comprob.Registro["impreso"] = this.Comprob.Impreso ? 1 : 0;
                                        ActualizarComprob.ColumnValues.AddWithValue("impreso", 1);
                                } else {
                                        this.Comprob.Impreso = true;
                                        this.Comprob.Registro["impresa"] = this.Comprob.Impreso ? 1 : 0;
                                        ActualizarComprob.ColumnValues.AddWithValue("impresa", 1);
                                }
                        }

                        if (this.Comprob is ComprobanteFacturable && string.IsNullOrEmpty(cae) == false && vencimientoCae.HasValue) {
                                var ComprobFact = Comprob as ComprobanteFacturable;
                                ComprobFact.CaeNumero = cae;
                                ActualizarComprob.ColumnValues.AddWithValue("cae_numero", ComprobFact.CaeNumero);
                                ComprobFact.CaeVencimiento = vencimientoCae.Value;
                                ActualizarComprob.ColumnValues.AddWithValue("cae_vencimiento", ComprobFact.CaeVencimiento);
                        }

                        ActualizarComprob.WhereClause = new qGen.Where(this.Comprob.CampoId, this.Comprob.Id);

                        this.Comprob.Connection.Execute(ActualizarComprob);
                }

                /// <summary>
                /// Numera el comprobante (usando el próximo número en el talonario), guardando automáticamente los cambios.
                /// </summary>
                /// <param name="yMarcarComoImpreso">Si es Verdadero, el comprobante se marca como impreso y se actualiza la fecha.</param>
                public void Numerar(bool yMarcarComoImpreso)
                {
                        if (this.Comprob.Numero == 0) {
                                int NumeroNuevo = Numerador.ProximoNumero(this.Comprob);
                                this.Numerar(NumeroNuevo, yMarcarComoImpreso);
                        }
                }

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
