using log4net;
using NUnit.Framework;
using System;

namespace Lbl.Test.Entity.Comprobantes
{
        public class FacturaTest : Lbl.Test.PruebaConDatos
        {
                private static readonly ILog Log = LogManager.GetLogger(typeof(FacturaTest));

                static Lbl.Personas.Persona Administrador = new Lbl.Personas.Persona(TestSetup.Connection, 1);
                static Lbl.Personas.Persona SocioConsFinalFueguino = new Lbl.Personas.Persona(TestSetup.Connection, 1001);
                static Lbl.Personas.Persona SocioConsFinalPortenio = new Lbl.Personas.Persona(TestSetup.Connection, 1003);
                static Lbl.Personas.Persona ComercioRespInscrFueguino = new Lbl.Personas.Persona(TestSetup.Connection, 1002);
                static Lbl.Personas.Persona ComercioRespInscrPortenio = new Lbl.Personas.Persona(TestSetup.Connection, 1004);

                static Lbl.Pagos.FormaDePago Efectivo = new Lbl.Pagos.FormaDePago(TestSetup.Connection, 1);
                static Lbl.Pagos.FormaDePago CtaCte = new Lbl.Pagos.FormaDePago(TestSetup.Connection, 3);

                static Lbl.Comprobantes.Tipo TipoB = new Lbl.Comprobantes.Tipo(TestSetup.Connection, "FB");
                static Lbl.Comprobantes.Tipo TipoA = new Lbl.Comprobantes.Tipo(TestSetup.Connection, "FA");

                static Lbl.Articulos.Articulo Articulo = new Lbl.Articulos.Articulo(TestSetup.Connection, 1);

                [Test]
                public void ProbarFacturaBConIvaEnCtaCte()
                {
                        var Fac = new Lbl.Comprobantes.Factura(TestSetup.Connection);
                        Fac.Crear();
                        Fac.Vendedor = Administrador;
                        Fac.Cliente = SocioConsFinalPortenio;
                        Fac.FormaDePago = CtaCte;
                        Fac.Tipo = TipoB;

                        var Det = Test.Entity.Comprobantes.DetalleArticuloTest.ObtenerDetalleEjemplo(false, Fac.Cliente.ObtenerSituacionIva() != Impuestos.SituacionIva.Exento);

                        Fac.Articulos.Add(Det);
                        Fac.Descuento = 5;

                        Assert.Equals(528.77m, Fac.Total, "Total debe ser 528.77");

                        Fac.Guardar();

                        var Ctrl = new Lazaro.Base.Controller.ComprobanteController();
                        Ctrl.Imprimir(Fac, this.ObtenerImpresoraNula());

                        // Verificar importes de la factura

                        var FacGuardada = new Lbl.Comprobantes.Factura(TestSetup.Connection, Fac.Id);

                        Assert.Equals(5m, FacGuardada.Descuento, "Descuento debe ser 5");
                        Assert.Equals(528.77m, FacGuardada.Total, "Total debe ser 528.77");
                        Assert.Equals(27.83m, FacGuardada.ImporteDescuentos, "ImporteDescuentos debe ser 27.83");
                        Assert.Equals(0m, FacGuardada.ImporteCancelado, "ImporteCancelado debe ser 0");
                        Assert.Equals(0m, FacGuardada.ImporteIvaDiscriminado, "ImporteIvaDiscriminado debe ser 0");
                        Assert.Equals(0m, FacGuardada.ImporteIvaDiscriminadoFinal, "ImporteIvaDiscriminadoFinal debe ser 0");
                        Assert.Equals(96.6m, FacGuardada.ImporteIva, "ImporteIva debe ser 96.60");
                        Assert.Equals(91.77m, FacGuardada.ImporteIvaFinal, "ImporteIvaFinal debe ser 91.77");

                        var UltMovim = Fac.Cliente.CuentaCorriente.ObtenerUltimoMovimiento();
                        
                        Assert.Equals(528.77m, UltMovim.Importe, "El movimiento en la cuenta corriente debe ser por el total de la factura.");
                }


                [Test]
                public void ProbarFacturaBSinIvaEnEfectivo()
                {
                        var Fac = new Lbl.Comprobantes.Factura(TestSetup.Connection);
                        Fac.Crear();
                        Fac.Vendedor = Administrador;
                        Fac.Cliente = SocioConsFinalFueguino;
                        Fac.FormaDePago = Efectivo;
                        Fac.Tipo = TipoB;

                        var Det = Test.Entity.Comprobantes.DetalleArticuloTest.ObtenerDetalleEjemplo(false, Fac.Cliente.ObtenerSituacionIva() != Impuestos.SituacionIva.Exento);

                        Fac.Articulos.Add(Det);
                        Fac.Descuento = 5;

                        Assert.Equals(437m, Fac.Total, "Total debe ser 437");

                        Fac.Guardar();

                        var Ctrl = new Lazaro.Base.Controller.ComprobanteController();
                        Ctrl.Imprimir(Fac, this.ObtenerImpresoraNula());

                        // Verificar importes de la factura

                        var FacGuardada = new Lbl.Comprobantes.Factura(TestSetup.Connection, Fac.Id);

                        Assert.Equals(5m, FacGuardada.Descuento, "Descuento debe ser 5");
                        Assert.Equals(437m, FacGuardada.Total, "Total debe ser 437");
                        Assert.Equals(23m, FacGuardada.ImporteDescuentos, "ImporteDescuentos debe ser 23");
                        Assert.Equals(437m, FacGuardada.ImporteCancelado, "ImporteCancelado debe ser 437");
                        Assert.Equals(0m, FacGuardada.ImporteIvaDiscriminado, "ImporteIvaDiscriminado debe ser 0");
                        Assert.Equals(0m, FacGuardada.ImporteIvaDiscriminadoFinal, "ImporteIvaDiscriminadoFinal debe ser 0");
                        Assert.Equals(0m, FacGuardada.ImporteIva, "ImporteIva debe ser 0");
                        Assert.Equals(0m, FacGuardada.ImporteIvaFinal, "ImporteIvaFinal debe ser 0");

                        var CajaEfectivo = new Lbl.Cajas.Caja(TestSetup.Connection, 999);
                        var UltMovim = CajaEfectivo.ObtenerUltimoMovimiento();

                        Assert.Equals(437m, UltMovim.Importe, "El último movimiento en efectivo debe ser 437");
                }


                [Test]
                public void ProbarFacturaAConIvaEnCtaCte()
                {
                        var Fac = new Lbl.Comprobantes.Factura(TestSetup.Connection);
                        Fac.Crear();
                        Fac.Vendedor = Administrador;
                        Fac.Cliente = ComercioRespInscrPortenio;
                        Fac.FormaDePago = CtaCte;
                        Fac.Tipo = TipoA;

                        var Det = Test.Entity.Comprobantes.DetalleArticuloTest.ObtenerDetalleEjemplo(true, Fac.Cliente.ObtenerSituacionIva() != Impuestos.SituacionIva.Exento);

                        Fac.Articulos.Add(Det);
                        Fac.Descuento = 5;

                        Assert.Equals(528.77m, Fac.Total, "Total debe ser 528.77");

                        Fac.Guardar();

                        var Ctrl = new Lazaro.Base.Controller.ComprobanteController();
                        Ctrl.Imprimir(Fac, this.ObtenerImpresoraNula());

                        // Verificar importes de la factura

                        var FacGuardada = new Lbl.Comprobantes.Factura(TestSetup.Connection, Fac.Id);

                        Assert.Equals(5m, FacGuardada.Descuento, "Descuento debe ser 5");
                        Assert.Equals(528.77m, FacGuardada.Total, "Total debe ser 528.77");
                        Assert.Equals(23m, FacGuardada.ImporteDescuentos, "ImporteDescuentos debe ser 23");
                        Assert.Equals(0m, FacGuardada.ImporteCancelado, "ImporteCancelado debe ser 0");
                        Assert.Equals(96.6m, FacGuardada.ImporteIvaDiscriminado, "ImporteIvaDiscriminado debe ser 96.6");
                        Assert.Equals(91.77m, FacGuardada.ImporteIvaDiscriminadoFinal, "ImporteIvaDiscriminadoFinal debe ser 91.77");
                        Assert.Equals(96.6m, FacGuardada.ImporteIva, "ImporteIva debe ser 96.60");
                        Assert.Equals(91.77m, FacGuardada.ImporteIvaFinal, "ImporteIvaFinal debe ser 91.77");

                        var UltMovim = Fac.Cliente.CuentaCorriente.ObtenerUltimoMovimiento();

                        Assert.Equals(528.77m, UltMovim.Importe, "El movimiento en la cuenta corriente debe ser por el total de la factura.");
                }


                public Impresion.Impresora ObtenerImpresoraNula()
                {
                        var ImpresoraNula = new Impresion.Impresora(TestSetup.Connection);
                        ImpresoraNula.Clase = Impresion.ClasesImpresora.Nula;

                        return ImpresoraNula;
                }
        }
}
