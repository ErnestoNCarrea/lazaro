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

                public decimal Unitario
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
                                return this.Cantidad * this.UnitarioAImprimirConDescuentoORecargo;
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
                /// Devuelve el precio unitario aplicando descuentos o recargos.
                /// </summary>
                public decimal UnitarioSinIvaConDescuentoORecargo
                {
                        get
                        {
                                return this.Unitario * (1 + Recargo / 100);
                        }
                }


                /// <summary>
                /// Devuelve el precio unitario aplicando descuentos o recargos.
                /// </summary>
                public decimal UnitarioConIvaConDescuentoORecargo
                {
                        get
                        {
                                return this.UnitarioConIva * (1 + Recargo / 100);
                        }
                }


                /// <summary>
                /// Devuelve el precio unitario aplicando descuentos o recargos.
                /// </summary>
                public decimal UnitarioAImprimirConDescuentoORecargo
                {
                        get
                        {
                                return this.UnitarioAImprimir * (1 + Recargo / 100);
                        }
                }


                /// <summary>
                /// Devuelve el precio unitario a imprimir, según la discriminación de IVA del comprobante.
                /// </summary>
                public decimal UnitarioAImprimir
                {
                        get
                        {
                                if (this.ElementoPadre == null) {
                                        return this.UnitarioAImprimirConDescuentoORecargo;
                                } else if (ElementoPadre is Lbl.Comprobantes.ComprobanteConArticulos) {
                                        Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.ElementoPadre as Lbl.Comprobantes.ComprobanteConArticulos;
                                        if (Comprob.Cliente.PagaIva == Impuestos.SituacionIva.Exento) {
                                                return this.Unitario;
                                        } else if (Comprob.DiscriminaIva) {
                                                return this.Unitario;
                                        } else {
                                                decimal IvaPct = this.ObtenerAlicuota().Porcentaje;
                                                return Math.Round(this.Unitario * (1 + IvaPct / 100), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                                        }
                                } else {
                                        return this.Unitario;
                                }
                        }
                }


                /// <summary>
                /// Devuelve el precio unitario a facturar, según la discriminación de IVA del comprobante.
                /// </summary>
                public decimal UnitarioConIva
                {
                        get
                        {
                                if (this.ElementoPadre == null) {
                                        return this.UnitarioAImprimirConDescuentoORecargo;
                                } else if (ElementoPadre is Lbl.Comprobantes.ComprobanteConArticulos) {
                                        Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.ElementoPadre as Lbl.Comprobantes.ComprobanteConArticulos;
                                        if (Comprob.Cliente.PagaIva == Impuestos.SituacionIva.Exento) {
                                                return this.Unitario;
                                        } else {
                                                decimal IvaPct = this.ObtenerAlicuota().Porcentaje;
                                                return Math.Round(this.Unitario * (1 + IvaPct / 100), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                                        }
                                } else {
                                        return this.Unitario;
                                }
                        }
                }



                /// <summary>
                /// Devuelve el importe de IVA que corresponde a este artículo.
                /// </summary>
                public decimal ImporteIva
                {
                        get
                        {
                                if (this.ElementoPadre == null) {
                                        return 0;
                                } else if (ElementoPadre is Lbl.Comprobantes.ComprobanteConArticulos) {
                                        Lbl.Comprobantes.ComprobanteConArticulos Comprob = ElementoPadre as Lbl.Comprobantes.ComprobanteConArticulos;
                                        if (Comprob.Cliente.PagaIva != Impuestos.SituacionIva.Exento) {
                                                decimal IvaPct = this.ObtenerAlicuota().Porcentaje;
                                                return Math.Round(this.ImporteSinIva * (IvaPct / 100), Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                                        } else {
                                                return 0;
                                        }
                                } else {
                                        return 0;
                                }
                        }
                }

                /// <summary>
                /// Devuelve la cantidad de IVA que fue discriminado para este artículo, o 0 si no se discriminó IVA.
                /// </summary>
                public decimal ImporteIvaDiscriminado
                {
                        get
                        {
                                if (this.ElementoPadre == null) {
                                        return 0;
                                } else if (ElementoPadre is Lbl.Comprobantes.ComprobanteConArticulos) {
                                        Lbl.Comprobantes.ComprobanteConArticulos Comprob = ElementoPadre as Lbl.Comprobantes.ComprobanteConArticulos;
                                        if (Comprob.DiscriminaIva) {
                                                return this.ImporteIva;
                                        } else {
                                                return 0;
                                        }
                                } else {
                                        return 0;
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
                                        return this.ImporteConIva;
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
                                return 0;
                        } else if (ElementoPadre is Lbl.Comprobantes.ComprobanteConArticulos) {
                                //Lbl.Comprobantes.ComprobanteConArticulos Comprob = ElementoPadre as Lbl.Comprobantes.ComprobanteConArticulos;
                                Lbl.Impuestos.Alicuota AlicArticulo;
                                if (this.Articulo == null)
                                        AlicArticulo = Lbl.Sys.Config.Empresa.AlicuotaPredeterminada;
                                else
                                        AlicArticulo = this.Articulo.ObtenerAlicuota();

                                if (AlicArticulo != null && AlicArticulo.Id == idAlicuota)
                                        return this.ImporteIva;
                                else
                                        return 0;
                        } else {
                                return 0;
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
                                } else {
                                        this.IdArticulo = 0;
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

                        Comando.Fields.AddWithValue("cantidad", this.Cantidad);
                        Comando.Fields.AddWithValue("precio", this.Unitario);
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
                        return this.Cantidad.ToString() + " " + this.Nombre + " a " + Lbl.Sys.Config.Moneda.Simbolo + " " + Lfx.Types.Formatting.FormatCurrency(this.Unitario, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales) + " c/u";
                }
	}
}