using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Lazaro.Base.Util.Impresion
{
        public class Instanciador
        {
                public static ImpresorElemento InstanciarImpresor(Lbl.IElementoDeDatos elemento, IDbTransaction transaction)
                {
                        Type tipo = InferirImpresor(elemento.GetType());
                        System.Reflection.ConstructorInfo TConstr = tipo.GetConstructor(new Type[] { typeof(Lbl.ElementoDeDatos), typeof(IDbTransaction) });
                        return (ImpresorElemento)(TConstr.Invoke(new object[] { elemento, transaction }));
                }

                public static Type InferirImpresor(Type tipo)
                {
                        Type Res = Lfx.Components.Manager.RegisteredTypes.GetHandler(tipo, "print");

                        if (Res != null) {
                                return Res;
                        } else {
                                Res = InferirImpresor(tipo.ToString());

                                if (Res == typeof(Lazaro.Base.Util.Impresion.ImpresorElemento) && tipo.BaseType != null)
                                        // Intento buscar un impresora para la clase base
                                        Res = InferirImpresor(tipo.BaseType);
                        }
                        return Res;
                }

                private static Type InferirImpresor(string tipoOTabla)
                {
                        switch (tipoOTabla) {
                                case "Lbl.Impresion.Plantilla":
                                        return typeof(Impresion.Comprobantes.ImpresorPlantilla);
                                case "Lbl.Comprobantes.Comprobante":
                                        return typeof(Impresion.Comprobantes.ImpresorComprobante);
                                case "Lbl.Comprobantes.Presupuesto":
                                        return typeof(Impresion.Comprobantes.ImpresorPresupuesto);
                                case "Lbl.Comprobantes.Recibo":
                                case "Lbl.Comprobantes.ReciboDeCobro":
                                case "Lbl.Comprobantes.ReciboDePago":
                                        return typeof(Impresion.Comprobantes.ImpresorRecibo);
                                case "Lbl.Comprobantes.ComprobanteConArticulo":
                                case "Lbl.Comprobantes.ComprobanteFacturable":
                                case "Lbl.Comprobantes.Factura":
                                case "Lbl.Comprobantes.NotaDeDebito":
                                case "Lbl.Comprobantes.NotaDeCredito":
                                case "Lbl.Comprobantes.Remito":
                                        return typeof(Impresion.Comprobantes.ImpresorComprobanteConArticulos);
                                default:
                                        return typeof(ImpresorElemento);
                        }
                }
        }
}
