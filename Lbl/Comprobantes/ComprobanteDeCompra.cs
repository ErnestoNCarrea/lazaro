using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Comprobante de Compra")]
        [Lbl.Atributos.Datos(TablaDatos = "comprob", CampoId = "id_comprob", TablaImagenes = "comprob_imagenes")]
        [Lbl.Atributos.Presentacion()]
        public class ComprobanteDeCompra : ComprobanteConArticulos, Lbl.IElementoConImagen
        {
                //Heredar constructor
                public ComprobanteDeCompra(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

                public ComprobanteDeCompra(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
			: base(dataBase, row) { }

                public ComprobanteDeCompra(Lfx.Data.Connection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public override void Crear()
                {
                        base.Crear();
                        this.Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra["FA"];
                        this.Compra = true;
                        this.Fecha = DateTime.Now;
                        this.FormaDePago = new Pagos.FormaDePago(this.Connection, Pagos.TiposFormasDePago.CuentaCorriente);

                        if (this.SituacionOrigen == null)
                                this.SituacionOrigen = new Lbl.Articulos.Situacion(this.Connection, 998); //Proveedor
                        if (this.SituacionDestino == null)
                                this.SituacionDestino = new Lbl.Articulos.Situacion(this.Connection, Lfx.Workspace.Master.CurrentConfig.Productos.DepositoPredeterminado);
                }

                public override Tipo Tipo
                {
                        get
                        {
                                return base.Tipo;
                        }
                        set
                        {
                                base.Tipo = value;

                                if (this.Compra == false && this.Tipo.EsFacturaNCoND && this.FormaDePago == null)
                                        this.FormaDePago = new Lbl.Pagos.FormaDePago(this.Connection, Lbl.Pagos.TiposFormasDePago.CuentaCorriente);

                                if (this.Tipo.Nomenclatura == "PD" || this.Tipo.Nomenclatura == "NP")
                                        this.Estado = 50;
                        }
                }

                new public ComprobanteDeCompra Convertir(Tipo tipo)
                {
                        Lbl.Comprobantes.ComprobanteConArticulos Res = base.Convertir(tipo);
                        Res.Compra = true;
                        return (ComprobanteDeCompra)Res;
                }
        }
}
