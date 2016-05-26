using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Articulos.Categorias
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
        {
                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Articulos.Categoria);

                        InitializeComponent();
                }

                public override void ActualizarControl()
                {
                        Lbl.Articulos.Categoria Cat = this.Elemento as Lbl.Articulos.Categoria;

                        EntradaNombre.Text = Cat.Nombre;
                        EntradaNombreSing.Text = Cat.NombreSingular;
                        EntradaStockMinimo.Text = Lfx.Types.Formatting.FormatStock(Cat.PuntoDeReposicion);
                        EntradaWeb.TextKey = Cat.PublicacionWeb.ToString();
                        EntradaSeguimiento.TextKey = ((int)(Cat.Seguimiento)).ToString();
                        EntradaItem.Text = Lfx.Types.Formatting.FormatStock(this.Connection.FieldDecimal("SELECT COUNT(id_articulo) FROM articulos WHERE id_categoria=" + Cat.Id.ToString()));
                        EntradaItemStock.Text = Lfx.Types.Formatting.FormatStock(this.Connection.FieldDecimal("SELECT COUNT(id_articulo) FROM articulos WHERE stock_actual>0 AND id_categoria=" + Cat.Id.ToString()));
                        EntradaStockActual.Text = Lfx.Types.Formatting.FormatStock(this.Connection.FieldDecimal("SELECT SUM(stock_actual) FROM articulos WHERE id_categoria=" + Cat.Id.ToString()));
                        EntradaCosto.Text = Lfx.Types.Formatting.FormatStock(this.Connection.FieldDecimal("SELECT SUM(costo) FROM articulos WHERE id_categoria=" + Cat.Id.ToString()));
                        EntradaGarantia.Text = Cat.Garantia.ToString();
                        EntradaRubro.Elemento = Cat.Rubro;
                        EntradaAlicuota.Elemento = Cat.Alicuota;

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Articulos.Categoria Cat = this.Elemento as Lbl.Articulos.Categoria;

                        Cat.Nombre = EntradaNombre.Text;
                        Cat.NombreSingular = EntradaNombreSing.Text;
                        Cat.PuntoDeReposicion = Lfx.Types.Parsing.ParseStock(EntradaStockMinimo.Text);
                        Cat.PublicacionWeb = Lfx.Types.Parsing.ParseInt(EntradaWeb.TextKey);
                        Cat.Seguimiento = ((Lbl.Articulos.Seguimientos)(Lfx.Types.Parsing.ParseInt(EntradaSeguimiento.TextKey)));
                        Cat.Garantia = Lfx.Types.Parsing.ParseInt(EntradaGarantia.Text);
                        Cat.Rubro = EntradaRubro.Elemento as Lbl.Articulos.Rubro;
                        Cat.Alicuota = EntradaAlicuota.Elemento as Lbl.Impuestos.Alicuota;

                        base.ActualizarElemento();
                }

                public override Lazaro.Pres.DisplayStyles.IDisplayStyle HeaderDisplayStyle
                {
                        get
                        {
                                return Lazaro.Pres.DisplayStyles.Template.Current.Articulos;
                        }
                }
        }
}
