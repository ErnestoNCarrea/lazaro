using log4net;
using System;
using System.Collections.Generic;
using System.Text;



namespace Lazaro.Base.Controller
{
        public class CajaController : Lazaro.Base.Controller.BaseController
        {
                private static readonly ILog Log = LogManager.GetLogger(typeof(CajaController));

                protected string TablaDatos = "cajas_movim";
                protected string CampoId = "id_movim";

                protected Lazaro.Orm.IEntityManager Em { get; }
                protected Lazaro.Orm.Data.IConnection Connection { get; }
                protected Lbl.Cajas.Caja Caja { get; }

                public CajaController(Lazaro.Orm.IEntityManager em)
                {
                        this.Em = em;
                        this.Connection = em.Connection;
                }

                public CajaController(Lazaro.Orm.IEntityManager em, Lbl.Cajas.Caja caja)
                {
                        this.Em = em;
                        this.Connection = em.Connection;
                        this.Caja = caja;
                }


                /// <summary>
                /// Obtiene el último movimiento de la caja.
                /// </summary>
                /// <returns>El último movimiento registrado en la caja.</returns>
                public Lbl.Cajas.Movimiento ObtenerUltimoMovimiento()
                {
                        var Res = this.Em.FindBy<Lbl.Cajas.Movimiento>(
                                new qGen.Where("id_caja", Caja.Id),
                                "id_movim DESC",
                                new qGen.Window(1)
                                );

                        if (Res.Count == 1) {
                                return Res[0];
                        } else {
                                return null;
                        }
                }


                /// <summary>
                /// Obtiene el saldo actual de la caja.
                /// </summary>
                /// <param name="forUpdate">Indica si es una consulta con fines de actualizar el saldo.</param>
                /// <returns>El saldo en la moneda de la caja.</returns>
                public decimal ObtenerSaldo(bool forUpdate)
                {
                        var UltimoMovim = this.Em.FindOneBy<Lbl.Cajas.Movimiento>(
                                new qGen.Where("id_caja", Caja.Id),
                                "id_movim DESC",
                                new qGen.Window(1)
                                );
                        
                        if (UltimoMovim == null) {
                                // En el caso de que la persona sea nueva y no tenga moviemientos en la Ctacte
                                return 0;
                        }

                        Log.Debug("ObtenerSaldo(): " + UltimoMovim.Saldo.ToString());
                        
                        return UltimoMovim.Saldo;
                }

                public decimal ObtenerSaldoAFecha(DateTime date)
                {
                        var Where = new qGen.Where(
                                new List<qGen.ICondition>()
                                {
                                        new qGen.ComparisonCondition("id_caja", Caja.Id),
                                        new qGen.ComparisonCondition("fecha", qGen.ComparisonOperators.LessOrEqual, date)
                                }
                                
                                );

                        var UltimoMovim = this.Em.FindOneBy<Lbl.Cajas.Movimiento>(
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

                public void Movimiento(bool auto, Lbl.Cajas.Concepto concepto, string textoConcepto,
                        Lbl.Personas.Persona cliente, decimal importe, string obs,
                        Lbl.Comprobantes.ComprobanteConArticulos factura, Lbl.Comprobantes.Recibo recibo, string comprobantes)
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(this.Caja, Lbl.Sys.Permisos.Operaciones.Mover) == false) {
                                throw new Lfx.Types.Exceptions.AccessDeniedException("No tiene permiso para hacer movimientos en la caja solicitada");
                        }

                        decimal SaldoActual = this.ObtenerSaldo(true);

                        qGen.IStatement InsertarMovimiento = new qGen.Insert("cajas_movim");
                        InsertarMovimiento.ColumnValues.AddWithValue("id_caja", this.Caja.Id);
                        InsertarMovimiento.ColumnValues.AddWithValue("id_sucursal", null);
                        InsertarMovimiento.ColumnValues.AddWithValue("auto", auto ? 1 : 0);
                        if (concepto == null)
                                InsertarMovimiento.ColumnValues.AddWithValue("id_concepto", null);
                        else
                                InsertarMovimiento.ColumnValues.AddWithValue("id_concepto", concepto.Id);
                        InsertarMovimiento.ColumnValues.AddWithValue("concepto", textoConcepto);
                        InsertarMovimiento.ColumnValues.AddWithValue("id_persona", Lbl.Sys.Config.Actual.UsuarioConectado.Id);
                        if (cliente == null)
                                InsertarMovimiento.ColumnValues.AddWithValue("id_cliente", null);
                        else
                                InsertarMovimiento.ColumnValues.AddWithValue("id_cliente", cliente.Id);
                        InsertarMovimiento.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                        InsertarMovimiento.ColumnValues.AddWithValue("importe", importe);
                        if (factura == null)
                                InsertarMovimiento.ColumnValues.AddWithValue("id_comprob", null);
                        else
                                InsertarMovimiento.ColumnValues.AddWithValue("id_comprob", factura.Id);
                        if (recibo == null)
                                InsertarMovimiento.ColumnValues.AddWithValue("id_recibo", null);
                        else
                                InsertarMovimiento.ColumnValues.AddWithValue("id_recibo", recibo.Id);
                        InsertarMovimiento.ColumnValues.AddWithValue("comprob", comprobantes);
                        InsertarMovimiento.ColumnValues.AddWithValue("saldo", SaldoActual + importe);
                        InsertarMovimiento.ColumnValues.AddWithValue("obs", obs);                       
                       //System.Data.IDbTransaction Trans =this.Connection.BeginTransaction();
                        this.Connection.ExecuteNonQuery(InsertarMovimiento);
                       // Trans.Commit();

                }


                /// <summary>
                /// Recalcula completamente el saldo de la caja, para corregir errores de transporte. Principalmente de uso interno.
                /// </summary>
                public void Recalcular()
                {
                        Lfx.Types.OperationProgress Progreso = new Lfx.Types.OperationProgress("Recalculando", "Se va a recalcular el saldo de la caja " + this.ToString());
                        Progreso.Begin();

                        System.Data.DataTable Movims = this.Connection.Select("SELECT id_movim, importe FROM cajas_movim WHERE id_caja=" + this.Caja.Id.ToString() + " ORDER BY id_movim");
                        decimal Saldo = 0;
                        Progreso.Max = Movims.Rows.Count;
                        foreach (System.Data.DataRow Movim in Movims.Rows) {
                                Saldo += System.Convert.ToDecimal(Movim["importe"]);

                                qGen.Update Upd = new qGen.Update("cajas_movim");
                                Upd.ColumnValues.AddWithValue("saldo", Saldo);
                                Upd.WhereClause = new qGen.Where("id_movim", System.Convert.ToInt32(Movim["id_movim"]));
                                this.Connection.ExecuteNonQuery(Upd);

                                Progreso.Advance(1);
                        }
                        Progreso.End();
                }
        }        
}