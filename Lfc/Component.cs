using Lfx.Components;
using System;
using Lfx;
using Lfx.Types;

namespace Lfc
{
        public class Component : IComponent
        {
                public Workspace Workspace { get; set; }

                public RegisteredTypeCollection GetRegisteredTypes()
                {
                        var Res = new Lfx.Components.RegisteredTypeCollection();

                        // Ordenados por TipoLbl

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Impuestos.Alicuota),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Alicuotas.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Alicuotas.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Articulos.Articulo),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Articulos.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Articulos.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Bancos.Banco),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Bancos.Inicio))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Articulos.Categoria),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Articulos.Categorias.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Articulos.Categorias.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Articulos.Marca),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Articulos.Marcas.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Articulos.Marcas.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Articulos.Margen),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Articulos.Margenes.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Articulos.Margenes.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Articulos.Rubro),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Articulos.Rubros.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Articulos.Rubros.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Articulos.Situacion),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Articulos.Situaciones.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Articulos.Situaciones.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Bancos.ChequeEmitido),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Bancos.Cheques.InicioEmitidos)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Bancos.Cheques.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Bancos.ChequeRecibido),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Bancos.Cheques.InicioRecibidos)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Bancos.Cheques.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Bancos.Chequera),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Bancos.Chequeras.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Bancos.Chequeras.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Cajas.Caja),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Cajas.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Cajas.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Cajas.Concepto),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Cajas.Conceptos.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Cajas.Conceptos.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Vencimientos.Vencimiento),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Cajas.Vencimientos.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Cajas.Vencimientos.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Comprobantes.Comprobante),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Comprobantes.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Comprobantes.Editar)),
                                        new Lfx.Components.Action("print", typeof(Lazaro.Base.Util.Impresion.Comprobantes.ImpresorComprobante))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Comprobantes.ComprobanteDeCompra),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Comprobantes.Compra.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Comprobantes.Compra.Editar)),
                                        new Lfx.Components.Action("print", typeof(Lazaro.Base.Util.Impresion.Comprobantes.ImpresorComprobanteConArticulos))
                                }));


                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Comprobantes.ComprobanteFacturable),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Comprobantes.Facturas.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Comprobantes.Facturas.Editar)),
                                        new Lfx.Components.Action("print", typeof(Lazaro.Base.Util.Impresion.Comprobantes.ImpresorComprobanteConArticulos))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Comprobantes.Factura),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Comprobantes.Facturas.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Comprobantes.Facturas.Editar)),
                                        new Lfx.Components.Action("print", typeof(Lazaro.Base.Util.Impresion.Comprobantes.ImpresorComprobanteConArticulos))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Comprobantes.NotaDeCredito),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Comprobantes.Facturas.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Comprobantes.Facturas.Editar)),
                                        new Lfx.Components.Action("print", typeof(Lazaro.Base.Util.Impresion.Comprobantes.ImpresorComprobanteConArticulos))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Comprobantes.NotaDeDebito),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Comprobantes.Facturas.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Comprobantes.Facturas.Editar)),
                                        new Lfx.Components.Action("print", typeof(Lazaro.Base.Util.Impresion.Comprobantes.ImpresorComprobanteConArticulos))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Comprobantes.Presupuesto),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Comprobantes.Presupuestos.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Comprobantes.Presupuestos.Editar)),
                                        new Lfx.Components.Action("print", typeof(Lazaro.Base.Util.Impresion.Comprobantes.ImpresorPresupuesto))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Comprobantes.Recibo),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Comprobantes.Recibos.InicioCobro)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Comprobantes.Recibos.Editar)),
                                        new Lfx.Components.Action("print", typeof(Lazaro.Base.Util.Impresion.Comprobantes.ImpresorRecibo))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Comprobantes.ReciboDeCobro),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Comprobantes.Recibos.InicioCobro)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Comprobantes.Recibos.Editar)),
                                        new Lfx.Components.Action("print", typeof(Lazaro.Base.Util.Impresion.Comprobantes.ImpresorRecibo))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Comprobantes.ReciboDePago),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Comprobantes.Recibos.InicioPago)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Comprobantes.Recibos.Editar)),
                                        new Lfx.Components.Action("print", typeof(Lazaro.Base.Util.Impresion.Comprobantes.ImpresorRecibo))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Comprobantes.Remito),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Comprobantes.Remitos.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Comprobantes.Editar)),
                                        new Lfx.Components.Action("print", typeof(Lazaro.Base.Util.Impresion.Comprobantes.ImpresorComprobanteConArticulos))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Comprobantes.Ticket),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Comprobantes.Facturas.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Comprobantes.Facturas.Editar)),
                                        new Lfx.Components.Action("print", typeof(Lazaro.Base.Util.Impresion.Comprobantes.ImpresorComprobanteConArticulos))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Comprobantes.PuntoDeVenta),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Pvs.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Pvs.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Comprobantes.Tipo),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Comprobantes.Tipo.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Comprobantes.Tipo.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Impresion.Impresora),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Comprobantes.Impresoras.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Comprobantes.Impresoras.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Entidades.Localidad),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Ciudades.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Ciudades.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Impresion.Plantilla),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Comprobantes.Plantillas.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Comprobantes.Plantillas.Editar)),
                                        new Lfx.Components.Action("print", typeof(Lazaro.Base.Util.Impresion.Comprobantes.ImpresorPlantilla))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Pagos.Cupon),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Tarjetas.Cupones.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Tarjetas.Cupones.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Pagos.FormaDePago),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Pagos.FormasDePago.Inicio))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Pagos.Plan),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Pagos.Planes.Inicio))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Personas.Grupo),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Personas.Grupos.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Personas.Grupos.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Personas.Persona),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Personas.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Personas.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Personas.Proveedor),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Personas.Proveedores.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Personas.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Personas.Usuario),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Personas.Usuarios.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Personas.Usuarios.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Entidades.Sucursal),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Sucursales.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Sucursales.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Tareas.Tarea),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Tareas.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Tareas.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Tareas.EstadoTarea),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Tareas.Estados.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Tareas.Estados.Editar))
                                }));

                        Res.Add(new Lfx.Components.RegisteredType(
                                typeof(Lbl.Tareas.Tipo),
                                new Lfx.Components.ActionCollection() {
                                        new Lfx.Components.Action("list", typeof(Lfc.Tareas.Tipos.Inicio)),
                                        new Lfx.Components.Action("edit", typeof(Lfc.Tareas.Tipos.Editar))
                                }));

                        return Res;
                }

                public OperationResult Register()
                {
                        return new SuccessOperationResult();
                }

                public OperationResult Run()
                {
                        return new SuccessOperationResult();
                }

                public OperationResult Try()
                {
                        return new SuccessOperationResult();
                }

                public object Do(string actionName, object[] argv)
                {
                        return new FailureOperationResult("No existe la función " + actionName);
                }
        }
}
