using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.CuentasCorrientes
{
        /// <summary>
        /// Representa la cuenta corriente de una persona (cliente o proveedor).
        /// No es realmente un ElementoDeDatos.
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Cuenta corriente", Grupo = "Cuentas")]
        [Lbl.Atributos.Datos(TablaDatos = "ctacte", CampoId = "id_movim")]
        [Lbl.Atributos.Presentacion()]
        public class CuentaCorriente : ICuenta
        {
                private static readonly ILog Log = LogManager.GetLogger(typeof(CuentaCorriente));

                Lbl.Personas.Persona Persona;
                Lazaro.Base.Controller.CuentaCorrienteController CtaCteController = null;

                public CuentaCorriente(Lbl.Personas.Persona persona)
                {
                        this.Persona = persona;
                        CtaCteController = new Lazaro.Base.Controller.CuentaCorrienteController(
                                new Lazaro.Orm.EntityManager(this.Connection, Lfx.Workspace.Master.MetadataFactory),
                                Persona
                                );
                }

                public string TablaDatos
                {
                        get
                        {
                                return "ctacte";
                        }
                }

                public string CampoId
                {
                        get
                        {
                                return "id_movim";
                        }
                }

                public Lfx.Data.IConnection Connection
                {
                        get
                        {
                                return this.Persona.Connection;
                        }
                }


                /// <summary>
                /// Devuelve el último movimiento en la cuenta corriente para un cliente.
                /// </summary>
                /// <returns>El último movimiento registrado en la cuenta corriente.</returns>
                public CuentasCorrientes.Movimiento ObtenerUltimoMovimiento()
                {
                        return CtaCteController.ObtenerUltimoMovimiento();
                }


                /// <summary>
                /// Calcula el saldo actual de la cuenta corriente.
                /// </summary>
                /// <returns>El monto adeudado (puede ser positivo o negativo) en la cuenta corriente.</returns>
                public decimal ObtenerSaldo(bool forUpdate)
                {
                        return CtaCteController.ObtenerSaldo(forUpdate);
                }


                public decimal ObtenerSaldoAFecha(DateTime date)
                {
                        return CtaCteController.ObtenerSaldoAFecha(date);
                }


                /// <summary>
                /// Recalcula completamente el saldo de la cuenta corriente, para corregir errores de transporte. Principalmente de uso interno
                /// durante verificaciones de consistencia o al desduplicar cuentas.
                /// </summary>
                public void Recalcular()
                {
                        CtaCteController.Recalcular();
                }

                public void AsentarMovimiento(bool auto,
                        Lbl.Cajas.Concepto concepto,
                        string textoConcepto,
                        decimal importeDebito,
                        string obs,
                        Dictionary<string, object> extras)
                {
                        CtaCteController.AsentarMovimiento(auto, concepto, textoConcepto, importeDebito, obs, null, null, null, extras);
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
                        CtaCteController.AsentarMovimiento(auto, concepto, textoConcepto, importeDebito, obs, comprob, recibo, textoComprob, null);
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
                        CtaCteController.AsentarMovimiento(auto, concepto, textoConcepto, importeDebito, obs, comprob, recibo, textoComprob, extras);
                }


                /// <summary>
                /// Da por pagado (direccion = 1) o despagado (retrotrae el pago) de uno o más comprobantes con saldo.
                /// </summary>
                /// <param name="importeDebito">El importe a cancelar de los comprobantes. Un importe negativo expresa descancelar comprobantes.</param>
                /// <param name="cancelarPrimero">Indica si debo cancelar primero y luego descancelar (operación normal) o hacerlo en el ordne inverso (anulación de operación normal).</param>
                public void CancelarComprobantesConSaldo(decimal importeDebito, bool cancelarPrimero)
                {
                        CtaCteController.CancelarComprobantesConSaldo(importeDebito, cancelarPrimero);
                }
                                
        }
}