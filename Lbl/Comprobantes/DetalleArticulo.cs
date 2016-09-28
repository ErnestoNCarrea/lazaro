using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Detalle de Comprobante", Grupo = "Comprobantes")]
        [Lbl.Atributos.Datos(TablaDatos = "comprob_detalle", CampoId = "id_comprob_detalle")]
        [Lbl.Atributos.Presentacion()]
	public class DetalleArticulo : ElementoDeDatos
	{
                private Articulos.Articulo m_Articulo = null;
                private Impuestos.Alicuota m_Alicuota = null;
                private Lbl.ElementoDeDatos m_ElementoPadre = null;

		//Heredar constructor
                public DetalleArticulo(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

                public DetalleArticulo(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

                public DetalleArticulo(Lbl.ElementoDeDatos elementoPadre)
                        : base(elementoPadre.Connection)
                {
                        this.ElementoPadre = elementoPadre;
                }

                public DetalleArticulo(Lbl.Comprobantes.ComprobanteConArticulos comprobante, int itemId)
                        : base(comprobante.Connection, itemId)
                {
                        this.ElementoPadre = comprobante;
                }

                public DetalleArticulo(Lbl.Comprobantes.ComprobanteConArticulos comprobante, Lfx.Data.Row row)
                        : base(comprobante.Connection, row)
                {
                        this.ElementoPadre = comprobante;
                }


                /// <summary>
                /// El precio unitario original del renglón (sin descuento ni cantidad).
                /// </summary>
                public decimal ImporteUnitario
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("precio");
                        }
                        set
                        {
                                this.Registro["precio"] = value;
                        }
                }

                /// <summary>
                /// El precio unitario final del renglón (con descuento y cantidad).
                /// </summary>
                public decimal ImporteUnitarioFinal
                {
                        get
                        {
                                return this.ImporteUnitario * (1m - this.Descuento / 100m);
                        }
                }


                /// <summary>
                /// El importe de IVA original del renglón (sin descuento ni cantidad).
                /// </summary>
                public decimal ImporteUnitarioIva
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("iva");
                        }
                        set
                        {
                                this.Registro["iva"] = value;
                        }
                }


                /// <summary>
                /// El importe de IVA final del renglón (con descuento y cantidad).
                /// </summary>
                public decimal ImporteUnitarioIvaFinal
                {
                        get
                        {
                                return this.ImporteUnitarioIva * (1m - this.Descuento / 100m);
                        }
                }


                /// <summary>
                /// El porcentaje de descuento aplicado a este renglón.
                /// </summary>
                public decimal Descuento
                {
                        get
                        {
                                return -this.Recargo;
                        }
                        set
                        {
                                this.Recargo = -value;
                        }
                }


                /// <summary>
                /// La cantidad del renglón.
                /// </summary>
                public decimal Cantidad
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("cantidad");
                        }
                        set
                        {
                                this.Registro["cantidad"] = value;
                        }
                }


                /// <summary>
                /// El precio de costo del artículo al momento de guardar o de imprimir (si corresponde).
                /// </summary>
                public decimal Costo
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("costo");
                        }
                        set
                        {
                                this.Registro["costo"] = value;
                        }
                }


                /// <summary>
                /// La descripción del renglón (puede ser texto libre o el nombre del artículo al momento de guardar o de imprimir).
                /// </summary>
                public string Descripcion
                {
                        get
                        {
                                return this.GetFieldValue<string>("descripcion");
                        }
                        set
                        {
                                this.Registro["descripcion"] = value;
                        }
                }


                /// <summary>
                /// Devuelve el importe final a imprimir en la factura (precio unitario multiplicado por la cantidad,
                /// más descuentos y recargos, incluyendo o no el IVA según el comprobante discrimine o no).
                /// </summary>
                public decimal ImporteAImprimir
                {
                        get
                        {
                                return this.Cantidad * this.ImporteUnitarioFinalAImprimir;
                        }
                }


                /// <summary>
                /// Devuelve el importe final a facturar (precio unitario multiplicado por la cantidad, más descuentos y recargos).
                /// </summary>
                public decimal ImporteSinIva
                {
                        get
                        {
                                return this.Cantidad * this.UnitarioSinIvaConDescuentoORecargo;
                        }
                }

                /// <summary>
                /// Devuelve el importe final a facturar (precio unitario multiplicado por la cantidad, más descuentos y recargos).
                /// </summary>
                public decimal ImporteConIva
                {
                        get
                        {
                                return this.Cantidad * this.UnitarioConIvaConDescuentoORecargo;
                        }
                }

                /// <summary>
                /// Devuelve el importe final a facturar (precio unitario multiplicado por la cantidad, más descuentos y recargos).
                /// </summary>
                public decimal ImporteConIvaDiscriminado
                {
                        get
                        {
                                return this.Cantidad * this.UnitarioFinalConIva;
                        }
                }


                /// <summary>
                /// Devuelve el precio unitario aplicando descuentos o recargos.
                /// </summary>
                public decimal UnitarioSinIvaConDescuentoORecargo
                {
                        get
                        {
                                return this.ImporteUnitario * (1 + Recargo / 100);
                        }
                }


                /// <summary>
                /// Devuelve el precio unitario con IVA aplicando descuentos o recargos.
                /// </summary>
                public decimal UnitarioConIvaConDescuentoORecargo
                {
                        get
                        {
                                return this.ImporteUnitarioConIva * (1 + Recargo / 100);
                        }
                }


                /// <summary>
                /// Devuelve el importe unitario final, más IVA, aplicando descuentos o recargos.
                /// </summary>
                public decimal UnitarioFinalConIva
                {
                        get
                        {
                                return this.ImporteUnitarioConIva * (1 + Recargo / 100);
                        }
                }


                /// <summary>
                /// Devuelve el importe unitario final a mostrar en el comprobante aplicando descuentos o recargos.
                /// </summary>
                public decimal ImporteUnitarioFinalAImprimir
                {
                        get
                        {
                                return this.ImporteUnitarioAImprimir * (1 + this.Recargo / 100);
                        }
                }


                /// <summary>
                /// Devuelve el importe unitario a imprimir, según la discriminación de IVA del comprobante.
                /// </summary>
                public decimal ImporteUnitarioAImprimir
                {
                        get
                        {
                                Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.ElementoPadre as Lbl.Comprobantes.ComprobanteConArticulos;
                                if(Comprob != null && Comprob.Tipo.DiscriminaIva) {
                                        return this.ImporteUnitario;
                                } else {
                                        return this.ImporteUnitarioConIva;
                                }
                        }
                }


                /// <summary>
                /// Devuelve el importe unitario original con IVA incluido.
                /// </summary>
                public decimal ImporteUnitarioConIva
                {
                        get
                        {
                                return this.ImporteUnitario + this.ImporteUnitarioIva;
                        }
                }


                /// <summary>
                /// Devuelve el precio unitario a facturar, según la discriminación de IVA del comprobante.
                /// </summary>
                public decimal ImporteUnitarioConIvaDiscriminado
                {
                        get
                        {
                                return this.ImporteUnitario + this.ImporteUnitarioIvaDiscriminado;
                        }
                }


                /// <summary>
                /// Devuelve la cantidad de IVA que fue discriminado para este artículo, o 0 si no se discriminó IVA.
                /// </summary>
                public decimal ImporteUnitarioIvaDiscriminado
                {
                        get
                        {
                                Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.ElementoPadre as Lbl.Comprobantes.ComprobanteConArticulos;
                                if (Comprob != null && Comprob.Tipo.DiscriminaIva) {
                                        return this.ImporteUnitarioIva;
                                } else {
                                        return 0m;
                                }
                        }
                }


                /// <summary>
                /// Devuelve la cantidad de IVA que fue discriminado para este artículo, o 0 si no se discriminó IVA.
                /// </summary>
                public decimal ImporteFinalIvaDiscriminado
                {
                        get
                        {
                                Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.ElementoPadre as Lbl.Comprobantes.ComprobanteConArticulos;
                                if (Comprob != null && Comprob.Tipo.DiscriminaIva) {
                                        return this.ImporteUnitarioIva * (1m - this.Descuento / 100m) * this.Cantidad;
                                } else {
                                        return 0m;
                                }
                        }
                }


                /// <summary>
                /// Ídem ImporteIvaAlicuota, pero con el precio del artículo incluído.
                /// </summary>
                public decimal ImporteConIvaAlicuota(int idAlicuota)
                {
                        if (this.ElementoPadre == null) {
                                return 0;
                        } else if (ElementoPadre is Lbl.Comprobantes.ComprobanteConArticulos) {
                                //Lbl.Comprobantes.ComprobanteConArticulos Comprob = ElementoPadre as Lbl.Comprobantes.ComprobanteConArticulos;
                                Lbl.Impuestos.Alicuota AlicArticulo;
                                if (this.Articulo == null)
                                        AlicArticulo = Lbl.Sys.Config.Empresa.AlicuotaPredeterminada;
                                else
                                        AlicArticulo = this.Articulo.ObtenerAlicuota();

                                if (AlicArticulo != null && AlicArticulo.Id == idAlicuota)
                                        return this.ImporteConIvaDiscriminado;
                                else
                                        return 0;
                        } else {
                                return 0;
                        }
                }



                /// <summary>
                /// Devuelve la cantidad de IVA que este artículo lleva de una alícuota en particular, o 0 si este artículo no se le aplica esa alícuota.
                /// Útil para Paraguay, donde por cada renglón de la factura van dos columnas, una con el importe IVA tasa regular y
                /// otra con la tasa reducida (o cero). Una de las dos columnas puede estar en blanco.
                /// </summary>
                public decimal ImporteIvaAlicuota(int idAlicuota)
                {
                        if (this.ElementoPadre == null) {
                                return 0m;
                        } else if (ElementoPadre is Lbl.Comprobantes.ComprobanteConArticulos) {
                                if (this.Alicuota != null && this.Alicuota.Id == idAlicuota) {
                                        var Comprob = ElementoPadre as Lbl.Comprobantes.ComprobanteConArticulos;
                                        if (Comprob.DiscriminaIva) {
                                                return this.ImporteUnitarioIvaFinal * this.Cantidad;
                                        } else {
                                                return this.ImporteConIva - this.ImporteConIva / (1m + this.Alicuota.Porcentaje / 100m);
                                        }
                                } else {
                                        return 0m;
                                }
                        } else {
                                return 0m;
                        }
                }


                /// <summary>
                /// Devuelve el importe son IVA que este artículo lleva de una alícuota en particular, o 0 si este artículo no se le aplica esa alícuota.
                /// </summary>
                public decimal ImporteSinIvaAlicuota(int idAlicuota)
                {
                        if (this.ElementoPadre == null) {
                                return 0;
                        } else if (ElementoPadre is Lbl.Comprobantes.ComprobanteConArticulos) {
                                //Lbl.Comprobantes.ComprobanteConArticulos Comprob = ElementoPadre as Lbl.Comprobantes.ComprobanteConArticulos;
                                Lbl.Impuestos.Alicuota AlicArticulo;
                                if (this.Articulo == null)
                                        AlicArticulo = Lbl.Sys.Config.Empresa.AlicuotaPredeterminada;
                                else
                                        AlicArticulo = this.Articulo.ObtenerAlicuota();

                                if (AlicArticulo != null && AlicArticulo.Id == idAlicuota)
                                        return this.ImporteSinIva;
                                else
                                        return 0;
                        } else {
                                return 0;
                        }
                }


                /// <summary>
                /// Devuelve o establece el Id del artículo facturado, si corresponde.
                /// </summary>
                protected internal int IdArticulo
                {
                        get
                        {
                                return this.GetFieldValue<int>("id_articulo");
                        }
                        set
                        {
                                this.Registro["id_articulo"] = value;
                                m_Articulo = null;
                        }
                }


                protected internal int IdAlicuota
                {
                        get
                        {
                                return this.GetFieldValue<int>("id_alicuota");
                        }
                        set
                        {
                                this.Registro["id_alicuota"] = value;
                                m_Alicuota = null;
                        }
                }


                protected internal int IdComprobante
                {
                        get
                        {
                                return this.GetFieldValue<int>("id_comprob");
                        }
                        set
                        {
                                this.Registro["id_comprob"] = value;
                                m_ElementoPadre = null;
                        }
                }


                public int Orden
                {
                        get
                        {
                                return this.GetFieldValue<int>("orden");
                        }
                        set
                        {
                                this.Registro["orden"] = value;
                        }
                }

                public Lbl.Impuestos.Alicuota ObtenerAlicuota()
                {
                        if (this.Articulo == null)
                                return Lbl.Sys.Config.Empresa.AlicuotaPredeterminada;
                        else
                                return this.Articulo.ObtenerAlicuota();
                }


                public Articulos.Articulo Articulo
                {
                        get
                        {
                                if (m_Articulo == null && this.IdArticulo != 0)
                                        m_Articulo = new Lbl.Articulos.Articulo(this.Connection, this.IdArticulo);
                                
                                return m_Articulo;
                        }
                        set
                        {
                                if (value != null) {
                                        this.IdArticulo = value.Id;
                                        this.Nombre = value.Nombre;
                                        this.Descripcion = value.Descripcion;
                                        this.Alicuota = value.ObtenerAlicuota();
                                } else {
                                        this.IdArticulo = 0;
                                }
                        }
                }


                /// <summary>
                /// Devuelve o establece la alícuota utilizada al momento de guardar o imprimir el comprobante.
                /// </summary>
                public Impuestos.Alicuota Alicuota
                {
                        get
                        {
                                if (m_Alicuota == null && this.IdAlicuota != 0)
                                        m_Alicuota = new Lbl.Impuestos.Alicuota(this.Connection, this.IdAlicuota);

                                return m_Alicuota;
                        }
                        set
                        {
                                if (value != null) {
                                        this.IdAlicuota = value.Id;
                                } else {
                                        this.IdAlicuota = 0;
                                }
                        }
                }


                public Lbl.ElementoDeDatos ElementoPadre
                {
                        get
                        {
                                if (m_ElementoPadre == null && this.IdComprobante != 0)
                                        m_ElementoPadre = new Lbl.Comprobantes.ComprobanteConArticulos(this.Connection, this.IdComprobante);

                                return m_ElementoPadre;
                        }
                        set
                        {
                                if (value != null) {
                                        this.IdComprobante = value.Id;
                                        m_ElementoPadre = value;
                                        this.Connection = value.Connection;
                                } else {
                                        this.IdComprobante = 0;
                                        m_ElementoPadre = null; 
                                }
                        }
                }


                public Lbl.Articulos.ColeccionDatosSeguimiento DatosSeguimiento
                {
                        get
                        {
                                return new Articulos.ColeccionDatosSeguimiento(this.GetFieldValue<string>("series"));
                        }
                        set
                        {
                                if (value == null)
                                        Registro["series"] = null;
                                else
                                        Registro["series"] = value.ToString();
                        }
                }


                public decimal Recargo
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("recargo");
                        }
                        set
                        {
                                Registro["recargo"] = value;
                        }
                }


                public override Lfx.Types.OperationResult Guardar()
                {
                        qGen.TableCommand Comando = new qGen.Insert(this.Connection, this.TablaDatos);
                        Comando.Fields.AddWithValue("id_comprob", this.IdComprobante);
                        Comando.Fields.AddWithValue("orden", this.Orden);

                        if (this.Articulo == null) {
                                Comando.Fields.AddWithValue("id_articulo", null);
                                Comando.Fields.AddWithValue("nombre", this.Nombre);
                                Comando.Fields.AddWithValue("descripcion", "");
                        } else {
                                Comando.Fields.AddWithValue("id_articulo", this.Articulo.Id);
                                Comando.Fields.AddWithValue("nombre", this.Articulo.Nombre);
                                Comando.Fields.AddWithValue("descripcion", this.Articulo.Descripcion);
                        }

                        if (this.Alicuota == null) {
                                Comando.Fields.AddWithValue("id_alicuota", null);
                        } else {
                                Comando.Fields.AddWithValue("id_alicuota", this.Alicuota.Id);
                        }

                        Comando.Fields.AddWithValue("cantidad", this.Cantidad);
                        Comando.Fields.AddWithValue("precio", this.ImporteUnitario);
                        Comando.Fields.AddWithValue("iva", this.ImporteUnitarioIva);
                        Comando.Fields.AddWithValue("recargo", this.Recargo);
                        if (this.Costo == 0 && this.Articulo != null)
                                Comando.Fields.AddWithValue("costo", this.Articulo.Costo);
                        else
                                Comando.Fields.AddWithValue("costo", this.Costo);
                        Comando.Fields.AddWithValue("importe", this.ImporteAImprimir);
                        Comando.Fields.AddWithValue("series", this.DatosSeguimiento);
                        Comando.Fields.AddWithValue("obs", this.Obs);

                        this.AgregarTags(Comando, this.Registro, this.TablaDatos);

                        this.Connection.Execute(Comando);

                        return base.Guardar();
                }


                public virtual DetalleArticulo Clone()
                {
                        DetalleArticulo Res;
                        Res = new DetalleArticulo(this.Connection);
                        Res.m_ItemId = this.Id;
                        Res.m_Registro = this.m_Registro.Clone();
                        return Res;
                }

                public override string ToString()
                {
                        return this.Cantidad.ToString() + " " + this.Nombre + " a " + Lbl.Sys.Config.Moneda.Simbolo + " " + Lfx.Types.Formatting.FormatCurrency(this.ImporteUnitario, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales) + " c/u";
                }
	}
}