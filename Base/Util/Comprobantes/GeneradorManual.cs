using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lazaro.Base.Util.Comprobantes
{
        /// <summary>
        /// Un generador de comprobantes que numera manualmente.
        /// 
        /// Se utiliza para los tipos de comprobante que se imprimen en papel prenumerado.
        /// </summary>
        public abstract class GeneradorManual : Generador
        {
                public GeneradorManual(Lbl.Comprobantes.Comprobante comprobante)
                        : base(comprobante)
                { }

                /// <summary>
                /// Numera el comprobante (usando el próximo número en el talonario), guardando automáticamente los cambios.
                /// </summary>
                /// <param name="yMarcarComoImpreso">Si es Verdadero, el comprobante se marca como impreso y se actualiza la fecha.</param>
                public void Numerar(bool yMarcarComoImpreso)
                {
                        if (this.Comprobante.Numero == 0) {
                                int NumeroNuevo = GeneradorManual.ProximoNumero(this.Comprobante);
                                this.Numerar(NumeroNuevo, yMarcarComoImpreso);
                        }
                }


                /// <summary>
                /// Numera el comprobante (usando el número especificado), guardando automáticamente los cambios.
                /// </summary>
                /// <param name="numero">El número que se asignó a este comprobante.</param>
                /// <param name="yMarcarComoImpreso">Si es Verdadero, el comprobante se marca como impreso y se actualiza la fecha.</param>
                public void Numerar(int numero, bool yMarcarComoImpreso)
                {
                        qGen.Update ActualizarComprob = new qGen.Update(this.Comprobante.TablaDatos);

                        // Modifico Registro para no volver a cargar el comprobante desde la BD
                        this.Comprobante.Registro["numero"] = numero;
                        ActualizarComprob.Fields.AddWithValue("numero", numero);

                        string Nombre = this.Comprobante.PV.ToString("0000") + "-" + numero.ToString("00000000");
                        this.Comprobante.Registro["nombre"] = Nombre;
                        ActualizarComprob.Fields.AddWithValue("nombre", Nombre);

                        if (yMarcarComoImpreso) {
                                this.Comprobante.Registro["estado"] = 1;

                                this.Comprobante.Registro["fecha"] = this.Comprobante.Connection.ServerDateTime;

                                if (this.Comprobante.TablaDatos == "recibos") {
                                        ActualizarComprob.Fields.AddWithValue("impreso", 1);
                                        this.Comprobante.Registro["impreso"] = 1;
                                } else {
                                        ActualizarComprob.Fields.AddWithValue("impresa", 1);
                                        this.Comprobante.Registro["impresa"] = 1;
                                }
                                ActualizarComprob.Fields.AddWithValue("estado", 1);
                                ActualizarComprob.Fields.AddWithValue("fecha", qGen.SqlFunctions.Now);
                        }
                        ActualizarComprob.WhereClause = new qGen.Where(this.Comprobante.CampoId, this.Comprobante.Id);

                        this.Comprobante.Connection.Execute(ActualizarComprob);
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
