using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lbl
{
        /// <summary>
        /// Permite crear instancias de un objeto Lbl.ElementoDeDatos, o de una clase derivada, a partir de un registro o un id de registro.
        /// </summary>
        public static class Instanciador
        {
                internal static Assembly Ensamblado;

                /// <summary>
                /// Crea una instancia de un Lbl.ElementoDeDatos nuevo.
                /// </summary>
                public static IElementoDeDatos Instanciar(Type tipo, Lfx.Data.IConnection dataBase)
                {
                        System.Reflection.ConstructorInfo TConstr = tipo.GetConstructor(new Type[] { typeof(Lfx.Data.Connection) });
                        Lbl.IElementoDeDatos Res = (Lbl.IElementoDeDatos)(TConstr.Invoke(new object[] { dataBase }));
                        return Res;
                }

                /// <summary>
                /// Crea una instancia de un Lbl.ElementoDeDatos a partir de un registro de base de datos.
                /// </summary>
                public static IElementoDeDatos Instanciar(Type tipo, Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                {
                        System.Reflection.ConstructorInfo TConstr = tipo.GetConstructor(new Type[] { typeof(Lfx.Data.Connection), typeof(Lfx.Data.Row) });
                        Lbl.IElementoDeDatos Res = (Lbl.IElementoDeDatos)(TConstr.Invoke(new object[] { dataBase, row }));
                        return Res;
                }

                /// <summary>
                /// Crea una instancia de un Lbl.ElementoDeDatos a partir de un id de registro.
                /// </summary>
                public static IElementoDeDatos Instanciar(Type tipo, Lfx.Data.IConnection dataBase, int id)
                {
                        System.Reflection.ConstructorInfo TConstr = tipo.GetConstructor(new Type[] { typeof(Lfx.Data.Connection), typeof(int) });
                        Lbl.IElementoDeDatos Res = (Lbl.IElementoDeDatos)(TConstr.Invoke(new object[] { dataBase, id }));
                        return Res;
                }

                /// <summary>
                /// Crea una instancia de un Lbl.ElementoDeDatos a partir de un registro de base de datos.
                /// </summary>
                public static T Instanciar<T>(Lfx.Data.IConnection dataBase, Lfx.Data.Row row) where T : Lbl.ElementoDeDatos
                {
                        Type tipo = typeof(T);
                        System.Reflection.ConstructorInfo TConstr = tipo.GetConstructor(new Type[] { typeof(Lfx.Data.Connection), typeof(Lfx.Data.Row) });
                        return (T)(TConstr.Invoke(new object[] { dataBase, row }));
                }


                private static Dictionary<string, Type> CacheInferencias = new Dictionary<string, Type>();

                /// <summary>
                /// Infiere el tipo (derivado de Lbl.ElementoDeDatos) a partir del nombre de la tabla o el nombre del tipo.
                /// </summary>
                public static Type InferirTipo(string tablaOTipo)
                {
                        if (CacheInferencias.ContainsKey(tablaOTipo))
                                return CacheInferencias[tablaOTipo];

                        Type Res;
                        // Primero busco en los tipos registrados por los componentes
                        foreach (Lfx.Components.IRegisteredType tipo in Lfx.Components.Manager.RegisteredTypes) {
                                if (tipo.LblType.ToString() == tablaOTipo) {
                                        Res = tipo.LblType;
                                        CacheInferencias.Add(tablaOTipo, Res);
                                        return Res;
                                }
                        }

                        switch(tablaOTipo) {
                                case "alicuotas":
                                case "Lbl.Impuestos.ObtenerAlicuota":
                                        Res = typeof(Lbl.Impuestos.Alicuota);
                                        break;
                                case "articulos":
                                case "Lbl.Articulos.Articulo":
                                        Res = typeof(Lbl.Articulos.Articulo);
                                        break;
                                case "articulos_categorias":
                                case "Lbl.Articulos.Categoria":
                                        Res = typeof(Lbl.Articulos.Categoria);
                                        break;
                                case "articulos_rubros":
                                case "Lbl.Articulos.Rubro":
                                        Res = typeof(Lbl.Articulos.Rubro);
                                        break;
                                case "articulos_situaciones":
                                case "Lbl.Articulos.Situacion":
                                        Res = typeof(Lbl.Articulos.Situacion);
                                        break;
                                case "bancos":
                                case "Lbl.Bancos.Banco":
                                        Res = typeof(Lbl.Bancos.Banco);
                                        break;
                                case "bancos_cheques":
                                case "Lbl.Bancos.Cheque":
                                        Res = typeof(Lbl.Bancos.Cheque);
                                        break;
                                case "Lbl.Bancos.ChequeRecibido":
                                        Res = typeof(Lbl.Bancos.ChequeRecibido);
                                        break;
                                case "Lbl.Bancos.ChequeEmitido":
                                        Res = typeof(Lbl.Bancos.ChequeEmitido);
                                        break;
                                case "cajas":
                                case "Lbl.Cajas.Caja":
                                        Res = typeof(Lbl.Cajas.Caja);
                                        break;
                                case "chequeras":
                                case "Lbl.Bancos.Chequera":
                                        Res = typeof(Lbl.Bancos.Chequera);
                                        break;
                                case "ciudades":
                                case "Lbl.Entidades.Localidad":
                                        Res = typeof(Lbl.Entidades.Localidad);
                                        break;
                                case "comprob":
                                case "comprobante":
                                case "Lbl.Comprobantes.ComprobanteConArticulos":
                                        Res = typeof(Lbl.Comprobantes.ComprobanteConArticulos);
                                        break;
                                case "Lbl.Comprobantes.ComprobanteFacturable":
                                        Res = typeof(Lbl.Comprobantes.ComprobanteFacturable);
                                        break;
                                case "Lbl.Comprobantes.Factura":
                                case "FA":
                                case "FB":
                                case "FC":
                                case "FE":
                                case "FM":
                                case "FNCND":
                                        Res = typeof(Lbl.Comprobantes.Factura);
                                        break;
                                case "Lbl.Comprobantes.Ticket":
                                case "T":
                                        Res = typeof(Lbl.Comprobantes.Ticket);
                                        break;
                                case "Lbl.Comprobantes.ComprobanteDeCompra":
                                case "NP":
                                case "PD":
                                case "RP":
                                case "FP":
                                        Res = typeof(Lbl.Comprobantes.ComprobanteDeCompra);
                                        break;
                                case "Lbl.Comprobantes.NotaDeCredito":
                                case "NC":
                                case "NCA":
                                case "NCB":
                                case "NCC":
                                case "NCE":
                                case "NCM":
                                        Res = typeof(Lbl.Comprobantes.NotaDeCredito);
                                        break;
                                case "Lbl.Comprobantes.NotaDeDebito":
                                case "ND":
                                case "NDA":
                                case "NDB":
                                case "NDC":
                                case "NDE":
                                case "NDM":
                                        Res = typeof(Lbl.Comprobantes.NotaDeDebito);
                                        break;
                                case "Lbl.Comprobantes.Presupuesto":
                                case "PS":
                                        Res = typeof(Lbl.Comprobantes.Presupuesto);
                                        break;
                                case "Lbl.Comprobantes.Remito":
                                case "R":
                                        Res = typeof(Lbl.Comprobantes.Remito);
                                        break;
                                case "comprob_detalle":
                                case "Lbl.Comprobantes.DetalleArticulo":
                                        Res = typeof(Lbl.Comprobantes.DetalleArticulo);
                                        break;
                                case "conceptos":
                                case "Lbl.Cajas.Concepto":
                                        Res = typeof(Lbl.Cajas.Concepto);
                                        break;
                                case "documentos_tipos":
                                case "Lbl.Comprobantes.Tipo":
                                        Res = typeof(Lbl.Comprobantes.Tipo);
                                        break;
                                case "impresoras":
                                case "Lbl.Impresion.Impresora":
                                        Res = typeof(Lbl.Impresion.Impresora);
                                        break;
                                case "formaspago":
                                case "Lbl.Pagos.FormaDePago":
                                        Res = typeof(Lbl.Pagos.FormaDePago);
                                        break;
                                case "pagos_valores":
                                case "Lbl.Pagos.Valor":
                                        Res = typeof(Lbl.Pagos.Valor);
                                        break;
                                case "marcas":
                                case "Lbl.Articulos.Marca":
                                        Res = typeof(Lbl.Articulos.Marca);
                                        break;
                                case "margenes":
                                case "Lbl.Articulos.Margen":
                                        Res = typeof(Lbl.Articulos.Margen);
                                        break;
                                case "monedas":
                                case "Lbl.Entidades.Moneda":
                                        Res = typeof(Lbl.Entidades.Moneda);
                                        break;
                                case "personas":
                                case "Lbl.Personas.Persona":
                                        Res = typeof(Lbl.Personas.Persona);
                                        break;
                                case "Lbl.Personas.Usuario":
                                case "acceso":
                                        Res = typeof(Lbl.Personas.Usuario);
                                        break;
                                case "Lbl.Personas.Proveedor":
                                        Res = typeof(Lbl.Personas.Proveedor);
                                        break;
                                case "paises":
                                case "Lbl.Entidades.Pais":
                                        Res = typeof(Lbl.Entidades.Pais);
                                        break;
                                case "personas_grupos":
                                case "Lbl.Personas.Grupo":
                                        Res = typeof(Lbl.Personas.Grupo);
                                        break;
                                case "pvs":
                                case "Lbl.Comprobantes.PuntoDeVenta":
                                        Res = typeof(Lbl.Comprobantes.PuntoDeVenta);
                                        break;
                                case "recibos":
                                case "Lbl.Comprobantes.Recibo":
                                        Res = typeof(Lbl.Comprobantes.Recibo);
                                        break;
                                case "Lbl.Comprobantes.ReciboDeCobro":
                                case "RC":
                                        Res = typeof(Lbl.Comprobantes.ReciboDeCobro);
                                        break;
                                case "Lbl.Comprobantes.ReciboDePago":
                                case "RCP":
                                        Res = typeof(Lbl.Comprobantes.ReciboDePago);
                                        break;
                                case "situaciones":
                                case "Lbl.Impuestos.SituacionTributaria":
                                        Res = typeof(Lbl.Impuestos.SituacionTributaria);
                                        break;
                                case "sucursales":
                                case "Lbl.Entidades.Sucursal":
                                        Res = typeof(Lbl.Entidades.Sucursal);
                                        break;
                                case "sys_log":
                                case "Lbl.Sys.Log.Entry":
                                        Res = typeof(Lbl.Sys.Log.Entrada);
                                        break;
                                case "sys_permisos_objetos":
                                case "Lbl.Sys.Permisos.Objeto":
                                        Res = typeof(Lbl.Sys.Permisos.Objeto);
                                        break;
                                case "sys_permisos":
                                case "Lbl.Sys.Permisos.Permiso":
                                        Res = typeof(Lbl.Sys.Permisos.Permiso);
                                        break;
                                case "sys_plantillas":
                                case "Lbl.Impresion.Plantilla":
                                        Res = typeof(Lbl.Impresion.Plantilla);
                                        break;
                                case "tickets":
                                case "Lbl.Tareas.Tarea":
                                        Res = typeof(Lbl.Tareas.Tarea);
                                        break;
                                case "tickets_tipos":
                                case "Lbl.Tareas.Tipo":
                                        Res = typeof(Lbl.Tareas.Tipo);
                                        break;
                                case "tickets_estados":
                                case "Lbl.Tareas.Estado":
                                case "Lbl.Tareas.EstadoTarea":
                                        Res = typeof(Lbl.Tareas.EstadoTarea);
                                        break;
                                case "tipo_doc":
                                case "Lbl.Entidades.ClaveUnica":
                                        Res = typeof(Lbl.Entidades.ClaveUnica);
                                        break;

                                case "tarjetas_cupones":
                                case "Lbl.Pagos.Cupon":
                                        Res = typeof(Lbl.Pagos.Cupon);
                                        break;
                                        
                                case "tarjetas_planes":
                                case "Lbl.Pagos.Plan":
                                        Res = typeof(Lbl.Pagos.Plan);
                                        break;

                                default:
                                        // Intento cargarlo mediante reflexión
                                        Type Tipo = null;
                                        if (Ensamblado == null) {
                                                try {
                                                        Ensamblado = System.Reflection.Assembly.LoadFrom("Lbl.dll");
                                                        Tipo = Ensamblado.GetType(tablaOTipo);
                                                } catch {
                                                        //Nada
                                                }
                                        }
                                        
                                        if (Tipo != null)
                                                Res = Tipo;
                                        else
                                                throw new NotImplementedException("Lbl.Instanciador.InferirTipo(): No se reconoce la tabla o tipo " + tablaOTipo);
                                        break;
                        }

                        CacheInferencias.Add(tablaOTipo, Res);
                        return Res;
                }
        }
}