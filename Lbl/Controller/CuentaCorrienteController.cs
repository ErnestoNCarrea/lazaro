using log4net;
using System;
using System.Collections.Generic;
using System.Text;


namespace Lazaro.Base.Controller
{
        public class CuentaCorrienteController : Lazaro.Base.Controller.BaseController
        {
                private static readonly ILog Log = LogManager.GetLogger(typeof(CuentaCorrienteController));

                protected string TablaDatos = "ctacte";
                protected string CampoId = "id_movim";

                protected Lbl.Personas.Persona Persona { get; }
                protected Lazaro.Orm.IEntityManager Em { get; }
                protected Lazaro.Orm.Data.IConnection Connection { get; }

                public CuentaCorrienteController(Lazaro.Orm.IEntityManager em)
                {
                        this.Em = em;
                        this.Connection = em.Connection;
                }

                public CuentaCorrienteController(Lazaro.Orm.IEntityManager em, Lbl.Personas.Persona Persona)
                {
                        this.Em = em;
                        this.Connection = em.Connection;
                        this.Persona = Persona;
                }


                /// <summary>
                /// Devuelve el último movimiento en la cuenta corriente para un cliente.
                /// </summary>
                /// <returns>El último movimiento registrado en la cuenta corriente.</returns>
                public Lbl.CuentasCorrientes.Movimiento ObtenerUltimoMovimiento()
                {
                        var Res = this.Em.FindBy<Lbl.CuentasCorrientes.Movimiento>(
                                new qGen.Where("id_cliente", Persona.Id),
                                "id_movim DESC",
                                new qGen.Window(1)
                                );

                        if (Res.Count == 1) {
                                return Res[0];
                        } else {
                                return null;
                        }

                        #region Por si acaso
                        /*
                        qGen.Select SelUltimoMovim = new qGen.Select(this.TablaDatos);
                        SelUltimoMovim.Columns = new qGen.SqlIdentifierCollection() { "*" };
                        SelUltimoMovim.WhereClause = new qGen.Where("id_cliente", Persona.Id);
                        SelUltimoMovim.Order = this.CampoId + " DESC";
                        SelUltimoMovim.Window = new qGen.Window(1);

                        return new Lbl.CuentasCorrientes.Movimiento(this.Connection, this.Connection.FirstRowFromSelect(SelUltimoMovim));
                        */
                        #endregion
                }



                /// <summary>
                /// Calcula el saldo actual de la cuenta corriente.
                /// </summary>
                /// <returns>El monto adeudado (puede ser positivo o negativo) en la cuenta corriente.</returns>
                public decimal ObtenerSaldo(bool forUpdate)
                {
                        var UltimoMovim = this.Em.FindOneBy<Lbl.CuentasCorrientes.Movimiento>(
                                new qGen.Where("id_cliente", Persona.Id),
                                "id_movim DESC",
                                new qGen.Window(1)
                                );
                        
                        if (UltimoMovim == null) {
                                // En el caso de que la persona sea nueva y no tenga moviemientos en la Ctacte
                                return 0;
                        }

                        Log.Debug("ObtenerSaldo(): " + UltimoMovim.Saldo.ToString());
                        
                        return UltimoMovim.Saldo;

                        /* qGen.Select SelSaldo = new qGen.Select(this.TablaDatos, forUpdate);
                        SelSaldo.Columns = new qGen.SqlIdentifierCollection() { "saldo" };
                        SelSaldo.WhereClause = new qGen.Where("id_cliente", Persona.Id);
                        SelSaldo.Order = this.CampoId + " DESC";
                        SelSaldo.Window = new qGen.Window(1);

                        return this.Connection.FieldDecimal(SelSaldo); */
                }

                public decimal ObtenerSaldoAFecha(DateTime date)
                {
                        var Where = new qGen.Where(
                                new List<qGen.ICondition>()
                                {
                                        new qGen.ComparisonCondition("id_cliente", Persona.Id),
                                        new qGen.ComparisonCondition("fecha", qGen.ComparisonOperators.LessOrEqual, date)
                                }
                                
                                );

                        var UltimoMovim = this.Em.FindOneBy<Lbl.CuentasCorrientes.Movimiento>(
                                Where,
                                "id_movim DESC",
                                new qGen.Window(1)
                                );

                        if (UltimoMovim == null) {
                                // En el caso de que la persona sea nueva y no tenga moviemientos en la Ctacte
                                return 0;
                        }

                        Log.Debug("ObtenerSaldoAFecha(): " + UltimoMovim.Saldo.ToString());

                        return UltimoMovim.Saldo;
                }

                /// <summary>
                /// Recalcula completamente el saldo de la cuenta corriente, para corregir errores de transporte. Principalmente de uso interno
                /// durante verificaciones de consistencia o al desduplicar cuentas.
                /// </summary>
                public void Recalcular()
                {
                        Lfx.Types.OperationProgress Progreso = new Lfx.Types.OperationProgress("Recalculando", "Se va a recalcular el saldo de la cuenta corriente de " + this.Persona.ToString());
                        Progreso.Modal = false;
                        Progreso.Begin();

                        System.Data.DataTable Movims = this.Connection.Select("SELECT id_movim, importe FROM ctacte WHERE id_cliente=" + this.Persona.Id.ToString() + " ORDER BY " + this.CampoId);
                        decimal Saldo = 0;
                        Progreso.Max = Movims.Rows.Count;
                        foreach (System.Data.DataRow Movim in Movims.Rows) {
                                Saldo += System.Convert.ToDecimal(Movim["importe"]);

                                qGen.Update ComandoActualizarSaldo = new qGen.Update(this.TablaDatos);
                                ComandoActualizarSaldo.ColumnValues.AddWithValue("saldo", Saldo);
                                ComandoActualizarSaldo.WhereClause = new qGen.Where(this.CampoId, System.Convert.ToInt32(Movim[this.CampoId]));
                                this.Connection.ExecuteNonQuery(ComandoActualizarSaldo);

                                Progreso.Advance(1);
                        }

                        qGen.Update ComandoActualizarCliente = new qGen.Update("personas");
                        ComandoActualizarCliente.ColumnValues.AddWithValue("saldo_ctacte", Saldo);
                        ComandoActualizarCliente.WhereClause = new qGen.Where("id_persona", this.Persona.Id);
                        this.Connection.ExecuteNonQuery(ComandoActualizarCliente);
                        Progreso.End();
                }

                public void AsentarMovimiento(bool auto,
                        Lbl.Cajas.Concepto concepto,
                        string textoConcepto,
                        decimal importeDebito,
                        string obs,
                        Dictionary<string, object> extras)
                {
                        this.AsentarMovimiento(auto, concepto, textoConcepto, importeDebito, obs, null, null, null, extras);
                }

                public void AsentarMovimiento(bool auto,
                        Lbl.Cajas.Concepto concepto,
                        string textoConcepto,
                        decimal importeDebito,
                        string obs,
                        Lbl.Comprobantes.ComprobanteConArticulos comprob,
                        Lbl.Comprobantes.Recibo recibo,
                        string textoComprob)
                {
                        this.AsentarMovimiento(auto, concepto, textoConcepto, importeDebito, obs, comprob, recibo, textoComprob, null);
                }

                /// <summary>
                /// Asienta un movimiento en la cuenta corriente, y cancela comprobantes asociados.
                /// </summary>
                /// <param name="auto">Indica si es un movimiento automático (generado por el sistema) o manual (generado por el usuario).</param>
                /// <param name="concepto">El concepto bajo el cual se realiza el movimiento.</param>
                /// <param name="textoConcepto">El texto que describe al concepto.</param>
                /// <param name="importeDebito">El importe a debitar de la cuenta. Un importe negativo indica un crédito.</param>
                /// <param name="obs">Observaciones.</param>
                /// <param name="comprob">El comprobante asociado a este movimiento.</param>
                /// <param name="recibo">El recibo asociado a este movimiento.</param>
                /// <param name="textoComprob">Un texto sobre los comprobantes asociados al sistema.</param>
                /// <param name="extras">Colección de campos adicionales para el registro.</param>
                public void AsentarMovimiento(bool auto,
                        Lbl.Cajas.Concepto concepto,
                        string textoConcepto,
                        decimal importeDebito,
                        string obs,
                        Lbl.Comprobantes.ComprobanteConArticulos comprob,
                        Lbl.Comprobantes.Recibo recibo,
                        string textoComprob,
                        Dictionary<string, object> extras)
                {
                        decimal SaldoActual = this.ObtenerSaldo(true);
                        decimal NuevoSaldo = SaldoActual + importeDebito;

                        qGen.Insert ComandoInsertarMovimiento = new qGen.Insert(this.TablaDatos);

                        ComandoInsertarMovimiento.ColumnValues.AddWithValue("auto", auto ? (int)1 : (int)0);
                        if (concepto == null)
                                ComandoInsertarMovimiento.ColumnValues.AddWithValue("id_concepto", null);
                        else
                                ComandoInsertarMovimiento.ColumnValues.AddWithValue("id_concepto", concepto.Id);
                        ComandoInsertarMovimiento.ColumnValues.AddWithValue("concepto", textoConcepto);
                        ComandoInsertarMovimiento.ColumnValues.AddWithValue("id_cliente", this.Persona.Id);
                        ComandoInsertarMovimiento.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                        ComandoInsertarMovimiento.ColumnValues.AddWithValue("importe", importeDebito);
                        if (comprob == null)
                                ComandoInsertarMovimiento.ColumnValues.AddWithValue("id_comprob", null);
                        else
                                ComandoInsertarMovimiento.ColumnValues.AddWithValue("id_comprob", comprob.Id);
                        if (recibo == null)
                                ComandoInsertarMovimiento.ColumnValues.AddWithValue("id_recibo", null);
                        else
                                ComandoInsertarMovimiento.ColumnValues.AddWithValue("id_recibo", recibo.Id);
                        ComandoInsertarMovimiento.ColumnValues.AddWithValue("comprob", textoComprob);
                        ComandoInsertarMovimiento.ColumnValues.AddWithValue("saldo", NuevoSaldo);
                        ComandoInsertarMovimiento.ColumnValues.AddWithValue("obs", obs);

                        if (extras != null && extras.Count > 0) {
                                foreach (KeyValuePair<string, object> extra in extras) {
                                        ComandoInsertarMovimiento.ColumnValues.AddWithValue(extra.Key, extra.Value);
                                }
                        }
                        this.Em.Connection.ExecuteNonQuery(ComandoInsertarMovimiento);

                        qGen.Update ComandoActualizarCliente = new qGen.Update("personas");
                        ComandoActualizarCliente.ColumnValues.AddWithValue("saldo_ctacte", NuevoSaldo);
                        ComandoActualizarCliente.WhereClause = new qGen.Where("id_persona", this.Persona.Id);
                        this.Connection.ExecuteNonQuery(ComandoActualizarCliente);
                }


                /// <summary>
                /// Da por pagado (direccion = 1) o despagado (retrotrae el pago) de uno o más comprobantes con saldo.
                /// </summary>
                /// <param name="importeDebito">El importe a cancelar de los comprobantes. Un importe negativo expresa descancelar comprobantes.</param>
                /// <param name="cancelarPrimero">Indica si debo cancelar primero y luego descancelar (operación normal) o hacerlo en el ordne inverso (anulación de operación normal).</param>
                public void CancelarComprobantesConSaldo(decimal importeDebito, bool cancelarPrimero)
                {
                        decimal ImporteCancelado;

                        if (cancelarPrimero) {
                                ImporteCancelado = CancelarComprobantes(importeDebito);
                                if (importeDebito > 0)
                                        importeDebito -= ImporteCancelado;
                                else
                                        importeDebito += ImporteCancelado;

                                // Si todavía queda más saldo...
                                if (importeDebito != 0)
                                        DesCancelarComprobantes(importeDebito);
                        } else {
                                ImporteCancelado = DesCancelarComprobantes(importeDebito);
                                if (importeDebito > 0)
                                        importeDebito -= ImporteCancelado;
                                else
                                        importeDebito += ImporteCancelado;

                                // Si todavía queda más saldo...
                                if (importeDebito != 0)
                                        CancelarComprobantes(-importeDebito);
                        }
                }


                /// <summary>
                /// Descancela comprobantes hasta el importe solicitado.
                /// </summary>
                /// <param name="importe">El importe a descancelar.</param>
                private decimal DesCancelarComprobantes(decimal importe)
                {
                        return 0;
                }


                /// <summary>
                /// Cancela saldos en comprobantes hasta el importe solicitado.
                /// </summary>
                /// <param name="importe">El importe a cancelar.</param>
                /// <returns>El importe cancelado. Puede ser igual o menor al importe solicitado.</returns>
                private decimal CancelarComprobantes(decimal importe)
                {
                        qGen.Where WhereConSaldo = new qGen.Where();
                        WhereConSaldo.AddWithValue("impresa", qGen.ComparisonOperators.NotEqual, 0);
                        WhereConSaldo.AddWithValue("anulada", 0);
                        WhereConSaldo.AddWithValue("numero", qGen.ComparisonOperators.NotEqual, 0);
                        WhereConSaldo.AddWithValue("id_formapago", qGen.ComparisonOperators.In, new int[] { 1, 3, 99 });
                        WhereConSaldo.AddWithValue("id_cliente", this.Persona.Id);
                        WhereConSaldo.AddWithValue("cancelado", qGen.ComparisonOperators.LessThan, new qGen.SqlExpression("total"));
                        // impresa>0 AND anulada=0 AND numero>0 AND id_formapago IN (1, 3, 99) AND cancelado<total AND id_cliente=this.Persona.Id

                        if (importe > 0) {
                                // Es un crédito, cancelo Facturas y Notas de Débito de venta y Notas de Crédito de compra
                                qGen.Where WhereTipoCredVenta = new qGen.Where();
                                WhereTipoCredVenta.AddWithValue("compra", 0);
                                WhereTipoCredVenta.AddWithValue("tipo_fac", qGen.ComparisonOperators.In, new string[] { "FA", "FB", "FC", "FE", "FM", "NDA", "NDB", "NDC", "NDE", "NDM", "T" });

                                qGen.Where WhereTipoCredCompra = new qGen.Where();
                                WhereTipoCredCompra.AddWithValue("compra", 1);
                                WhereTipoCredCompra.AddWithValue("tipo_fac", qGen.ComparisonOperators.In, new string[] { "NCA", "NCB", "NCC", "NCE", "NCM" });

                                qGen.Where WhereTipoCred = new qGen.Where(qGen.AndOr.Or);
                                WhereTipoCred.AddWithValue(WhereTipoCredVenta);
                                WhereTipoCred.AddWithValue(WhereTipoCredCompra);

                                WhereConSaldo.AddWithValue(WhereTipoCred);

                                /*  AND (compra=0 AND tipo_fac IN ('FA', 'FB', 'FC', 'FE', 'FM', 'NDA', 'NDB', 'NDC', 'NDE', 'NDM')
                                    OR (compra=1 AND tipo_fac IN ('NCA', 'NCB', 'NCC', 'NCE', 'NCM') */

                        } else {
                                // Es un débito. Cancelo Notas de Crédito de venta y Facturas y Notas de Débito de compra
                                qGen.Where WhereTipoCredVenta = new qGen.Where();
                                WhereTipoCredVenta.AddWithValue("compra", 1);
                                WhereTipoCredVenta.AddWithValue("tipo_fac", qGen.ComparisonOperators.In, new string[] { "FA", "FB", "FC", "FE", "FM", "NDA", "NDB", "NDC", "NDE", "NDM", "T" });

                                qGen.Where WhereTipoCredCompra = new qGen.Where();
                                WhereTipoCredCompra.AddWithValue("compra", 0);
                                WhereTipoCredCompra.AddWithValue("tipo_fac", qGen.ComparisonOperators.In, new string[] { "NCA", "NCB", "NCC", "NCE", "NCM" });

                                qGen.Where WhereTipoCred = new qGen.Where(qGen.AndOr.Or);
                                WhereTipoCred.AddWithValue(WhereTipoCredVenta);
                                WhereTipoCred.AddWithValue(WhereTipoCredCompra);

                                WhereConSaldo.AddWithValue(WhereTipoCred);

                                /*  AND (compra=1 AND tipo_fac IN ('FA', 'FB', 'FC', 'FE', 'FM', 'NDA', 'NDB', 'NDC', 'NDE', 'NDM')
                                    OR (compra=0 AND tipo_fac IN ('NCA', 'NCB', 'NCC', 'NCE', 'NCM') */
                        }

                        qGen.Select SelFacturasConSaldo = new qGen.Select("comprob", true);
                        SelFacturasConSaldo.Columns = new qGen.SqlIdentifierCollection() { "id_comprob", "total", "cancelado" };
                        SelFacturasConSaldo.WhereClause = WhereConSaldo;
                        SelFacturasConSaldo.Order = "id_comprob";
                        System.Data.DataTable FacturasConSaldo = this.Connection.Select(SelFacturasConSaldo);

                        decimal ImporteCancelar = Math.Abs(importe);
                        decimal ImporteCancelado = 0;

                        foreach (System.Data.DataRow Factura in FacturasConSaldo.Rows) {
                                decimal SaldoComprob = System.Convert.ToDecimal(Factura["total"]) - System.Convert.ToDecimal(Factura["cancelado"]);
                                decimal ImporteCancelarComprob = SaldoComprob;

                                if (ImporteCancelarComprob > ImporteCancelar)
                                        ImporteCancelarComprob = ImporteCancelar;

                                qGen.Update ActCancelarComprob = new qGen.Update("comprob");
                                ActCancelarComprob.ColumnValues.AddWithValue("cancelado", System.Convert.ToDecimal(Factura["cancelado"]) + ImporteCancelarComprob);
                                ActCancelarComprob.WhereClause = new qGen.Where("id_comprob", System.Convert.ToInt32(Factura["id_comprob"]));
                                this.Connection.ExecuteNonQuery(ActCancelarComprob);
                                ImporteCancelar -= ImporteCancelarComprob;
                                ImporteCancelado += ImporteCancelarComprob;

                                if (ImporteCancelar <= 0)
                                        break;
                        }

                        return ImporteCancelado;
                }
                

        }        
}