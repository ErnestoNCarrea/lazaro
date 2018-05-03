using NUnit.Framework;

namespace Lbl.Test.Entity.Comprobantes
{
        public class DetalleArticuloTest : Lbl.Test.PruebaConDatos
        {
                static Lbl.Articulos.Articulo Articulo = new Lbl.Articulos.Articulo(TestSetup.Connection, 1);
                static Lbl.Impuestos.Alicuota Alicuota21 = new Lbl.Impuestos.Alicuota(TestSetup.Connection, 1);

                [Test]
                public void ProbarImportesComunes()
                {
                        var Det = ObtenerDetalleEjemplo(false, true);

                        Assert.AreEqual(5m, Det.Cantidad, "Cantidad debe ser 5");
                        Assert.AreEqual(0.92m, Det.FactorDescuentoRecargo, "FactorDescuentoRecargo debe ser 0.92");
                }


                [Test]
                public void ProbarImportesSinIvaDiscriminado()
                {
                        var Det = ObtenerDetalleEjemplo(false, true);

                        Assert.IsFalse(Det.ComprobanteDiscriminaIva(), "El comprobante no debe discriminar IVA");

                        // Esto debería ser igual para IVA discriminado y no discriminado
                        Assert.AreEqual(460m, Det.ImporteSinIvaFinal, "ImporteSinIvaFinal debe ser 460");
                        Assert.AreEqual(111.32m, Det.ImporteUnitarioConIvaFinal, "ImporteUnitarioConIvaFinal debe ser 111.32");
                        Assert.AreEqual(19.32m, Det.ImporteIvaUnitarioFinal, "ImporteIvaUnitarioFinal debe ser 19.32");
                        Assert.AreEqual(92m, Det.ImporteUnitarioSinIvaFinal, "ImporteUnitarioSinIvaFinal debe ser 92");

                        Assert.AreEqual(556.6m, Det.ImporteConIvaFinalAlicuota(1), "ImporteConIvaFinalAlicuota(1) debe ser 556.6");
                        Assert.AreEqual(0m, Det.ImporteConIvaFinalAlicuota(2), "ImporteConIvaFinalAlicuota(2) debe ser 0");
                        Assert.AreEqual(96.6m, Det.ImporteIvaFinalAlicuota(1), "ImporteIvaFinalAlicuota(1) debe ser 96.6");
                        Assert.AreEqual(0m, Det.ImporteIvaFinalAlicuota(2), "ImporteIvaFinalAlicuota(2) debe ser 0");
                        Assert.AreEqual(460m, Det.ImporteSinIvaFinalAlicuota(1), "ImporteSinIvaFinalAlicuota(1) debe ser 460");
                        Assert.AreEqual(0m, Det.ImporteSinIvaFinalAlicuota(2), "ImporteSinIvaFinalAlicuota(2) debe ser 0");

                        // Esto debería variar para IVA discriminado y no discriminado
                        Assert.AreEqual(111.32m, Det.ImporteUnitarioFinal, "ImporteUnitarioFinal debe ser 111.32");
                        Assert.AreEqual(121m, Det.ImporteUnitario, "ImporteUnitario debe ser 121");

                        Assert.AreEqual(111.32m, Det.ImporteUnitarioFinalAImprimir, "ImporteAImprimir debe ser 112.32");
                        Assert.AreEqual(556.6m, Det.ImporteAImprimir, "ImporteAImprimir debe ser 556.6");

                        Assert.AreEqual(0m, Det.ImporteIvaDiscriminadoFinal, "ImporteIvaDiscriminadoFinal debe ser 0");
                        Assert.AreEqual(121m, Det.ImporteUnitarioConIva, "ImporteUnitarioConIvaDiscriminado debe ser 121");
                        Assert.AreEqual(0m, Det.ImporteUnitarioIvaDiscriminado, "ImporteUnitarioIvaDiscriminado debe ser 0");
                }


                [Test]
                public void ProbarImportesConIvaDiscriminado()
                {
                        var FacturaA = new Lbl.Comprobantes.Factura(TestSetup.Connection);
                        FacturaA.Tipo = new Lbl.Comprobantes.Tipo(TestSetup.Connection, "FA");

                        var Det = ObtenerDetalleEjemplo(true, true);
                        Det.ElementoPadre = FacturaA;

                        Assert.IsTrue(Det.ComprobanteDiscriminaIva(), "El comprobante no debe discriminar IVA");

                        // Esto debería ser igual para IVA discriminado y no discriminado
                        Assert.AreEqual(460m, Det.ImporteSinIvaFinal, "ImporteSinIvaFinal debe ser 460");
                        Assert.AreEqual(111.32m, Det.ImporteUnitarioConIvaFinal, "ImporteUnitarioConIvaFinal debe ser 111.32");
                        Assert.AreEqual(19.32m, Det.ImporteIvaUnitarioFinal, "ImporteIvaUnitarioFinal debe ser 19.32");
                        Assert.AreEqual(92m, Det.ImporteUnitarioSinIvaFinal, "ImporteUnitarioSinIvaFinal debe ser 92");

                        Assert.AreEqual(556.6m, Det.ImporteConIvaFinalAlicuota(1), "ImporteConIvaFinalAlicuota(1) debe ser 556.6");
                        Assert.AreEqual(0m, Det.ImporteConIvaFinalAlicuota(2), "ImporteConIvaFinalAlicuota(2) debe ser 0");
                        Assert.AreEqual(96.6m, Det.ImporteIvaFinalAlicuota(1), "ImporteIvaFinalAlicuota(1) debe ser 96.6");
                        Assert.AreEqual(0m, Det.ImporteIvaFinalAlicuota(2), "ImporteIvaFinalAlicuota(2) debe ser 0");
                        Assert.AreEqual(460m, Det.ImporteSinIvaFinalAlicuota(1), "ImporteSinIvaFinalAlicuota(1) debe ser 460");
                        Assert.AreEqual(0m, Det.ImporteSinIvaFinalAlicuota(2), "ImporteSinIvaFinalAlicuota(2) debe ser 0");

                        // Esto debería variar para IVA discriminado y no discriminado
                        Assert.AreEqual(92m, Det.ImporteUnitarioFinal, "ImporteUnitarioFinal debe ser 111.32");
                        Assert.AreEqual(100m, Det.ImporteUnitario, "ImporteUnitario debe ser 100");

                        Assert.AreEqual(92m, Det.ImporteUnitarioFinalAImprimir, "ImporteAImprimir debe ser 92");
                        Assert.AreEqual(460m, Det.ImporteAImprimir, "ImporteAImprimir debe ser 460");

                        Assert.AreEqual(96.6m, Det.ImporteIvaDiscriminadoFinal, "ImporteIvaDiscriminadoFinal debe ser 96.6");
                        Assert.AreEqual(121m, Det.ImporteUnitarioConIva, "ImporteUnitarioConIvaDiscriminado debe ser 121");
                        Assert.AreEqual(21m, Det.ImporteUnitarioIvaDiscriminado, "ImporteUnitarioIvaDiscriminado debe ser 21");

                }


                /// <summary>
                /// Genera y devuelve un Detalle de una factura que consta de 1 artículo código 1, a precio $ 100 más 
                /// VA del 21%, cantidad 5, con descuento del 8%.
                /// </summary>
                /// <param name="ivaDiscriminado">Indica si se trata de un detalle con IVA discriminado.</param>
                /// <param name="conIVa">Indica si el cliente paga IVA.</param>
                /// <returns>El detalle generado.</returns>
                public static Lbl.Comprobantes.DetalleArticulo ObtenerDetalleEjemplo(bool ivaDiscriminado, bool conIva)
                {
                        var Det = new Lbl.Comprobantes.DetalleArticulo(TestSetup.Connection);
                        Det.Crear();
                        Det.Articulo = Articulo;
                        Det.Cantidad = 5m;
                        if (conIva) {
                                Det.ImporteUnitario = ivaDiscriminado ? 100m : 121m;
                                Det.ImporteIvaUnitario = 21m;
                        } else {
                                Det.ImporteUnitario = 100m;
                                Det.ImporteIvaUnitario = 0m;
                        }
                        Det.Descuento = 8m;
                        Det.Alicuota = Alicuota21;

                        return Det;
                }
        }
}
