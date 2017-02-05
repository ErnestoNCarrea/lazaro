using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Articulos
{
        public partial class CambioMasivoPrecios : Lui.Forms.ChildDialogForm
        {
                public CambioMasivoPrecios()
                {
                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(typeof(Lbl.Articulos.Articulo), Lbl.Sys.Permisos.Operaciones.EditarAvanzado) == false) {
                                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                                this.Close();
                                return;
                        }

                        InitializeComponent();
                }


                public ListView ListadoArticulos
                {
                        get
                        {
                                return this.Listado;
                        }
                }


                public override Lfx.Types.OperationResult Ok()
                {
                        using (var Trans = this.Connection.BeginTransaction()) {
                                foreach (ListViewItem Itm in this.Listado.Items) {
                                        int ArtId = Lfx.Types.Parsing.ParseInt(Itm.Tag.ToString());

                                        decimal Costo = Lfx.Types.Parsing.ParseCurrency(Itm.SubItems[1].Text);
                                        decimal Pvp = Lfx.Types.Parsing.ParseCurrency(Itm.SubItems[3].Text);

                                        decimal NuevoCosto = 0m;
                                        decimal NuevoPvp = 0m;
                                        decimal Aumento = EntradaCantidad.ValueDecimal;

                                        if (EntradaUnidad.TextKey == "pct") {
                                                if (EntradaMovimiento.TextKey == "+") {
                                                        NuevoCosto = Costo * (1m + Aumento / 100m);
                                                        NuevoPvp = Pvp * (1m + Aumento / 100m);
                                                } else {
                                                        NuevoCosto = Costo * (1m - Aumento / 100m);
                                                        NuevoPvp = Pvp * (1m - Aumento / 100m);
                                                }
                                        } else {
                                                if (EntradaMovimiento.TextKey == "+") {
                                                        NuevoCosto = Costo + Aumento;
                                                        NuevoPvp = Pvp + Aumento;
                                                } else {
                                                        NuevoCosto = Costo - Aumento;
                                                        NuevoPvp = Pvp - Aumento;
                                                }
                                        }

                                        qGen.Update ActualizarPrecio = new qGen.Update("articulos");
                                        if (EntradaPrecio.TextKey == "costo" || EntradaPrecio.TextKey == "ambos") {
                                                ActualizarPrecio.ColumnValues.AddWithValue("costo", NuevoCosto);
                                        }
                                        if (EntradaPrecio.TextKey == "pvp" || EntradaPrecio.TextKey == "ambos") {
                                                ActualizarPrecio.ColumnValues.AddWithValue("pvp", NuevoPvp);
                                        }
                                        ActualizarPrecio.WhereClause = new qGen.Where();
                                        ActualizarPrecio.WhereClause.AddWithValue("id_articulo", ArtId);

                                        this.Connection.Execute(ActualizarPrecio);
                                }
                                Trans.Commit();
                        }

                        return new Lfx.Types.SuccessOperationResult();
                }

                private void EntradaUnidad_TextChanged(object sender, EventArgs e)
                {
                        if(EntradaUnidad.TextKey == "pct") {
                                EntradaCantidad.DataType = Lui.Forms.DataTypes.Float;
                                EntradaCantidad.Sufijo = "%";
                                EntradaCantidad.Prefijo = "";
                        } else {
                                EntradaCantidad.DataType = Lui.Forms.DataTypes.Currency;
                                EntradaCantidad.Sufijo = "";
                                EntradaCantidad.Prefijo = "$";
                        }

                        this.Recalcular();
                }

                private void EntradaPrecio_TextChanged(object sender, EventArgs e)
                {
                        this.Recalcular();
                }

                private void EntradaMovimiento_TextChanged(object sender, EventArgs e)
                {
                        this.Recalcular();
                }

                private void EntradaCantidad_TextChanged(object sender, EventArgs e)
                {
                        this.Recalcular();
                }

                protected void Recalcular()
                {
                        foreach (ListViewItem Itm in this.Listado.Items) {
                                Itm.UseItemStyleForSubItems = false;
                                decimal Costo = Lfx.Types.Parsing.ParseCurrency(Itm.SubItems[1].Text);
                                decimal Pvp = Lfx.Types.Parsing.ParseCurrency(Itm.SubItems[3].Text);

                                decimal NuevoCosto = 0m;
                                decimal NuevoPvp = 0m;
                                decimal Aumento = EntradaCantidad.ValueDecimal;

                                if (EntradaUnidad.TextKey == "pct") {
                                        if (EntradaMovimiento.TextKey == "+") {
                                                NuevoCosto = Costo * (1m + Aumento / 100m);
                                                NuevoPvp = Pvp * (1m + Aumento / 100m);
                                        } else {
                                                NuevoCosto = Costo * (1m - Aumento / 100m);
                                                NuevoPvp = Pvp * (1m - Aumento / 100m);
                                        }
                                } else {
                                        if (EntradaMovimiento.TextKey == "+") {
                                                NuevoCosto = Costo + Aumento;
                                                NuevoPvp = Pvp + Aumento;
                                        } else {
                                                NuevoCosto = Costo - Aumento;
                                                NuevoPvp = Pvp - Aumento;
                                        }
                                }

                                if (EntradaPrecio.TextKey == "costo") {
                                        Itm.SubItems[4].Text = Itm.SubItems[3].Text;
                                        Itm.SubItems[2].Text = Lfx.Types.Formatting.FormatCurrency(NuevoCosto);
                                        Itm.SubItems[2].BackColor = System.Drawing.Color.LightGoldenrodYellow;
                                        Itm.SubItems[4].BackColor = System.Drawing.SystemColors.Window;
                                } else if (EntradaPrecio.TextKey == "pvp") {
                                        Itm.SubItems[2].Text = Itm.SubItems[1].Text;
                                        Itm.SubItems[4].Text = Lfx.Types.Formatting.FormatCurrency(NuevoPvp);
                                        Itm.SubItems[2].BackColor = System.Drawing.SystemColors.Window;
                                        Itm.SubItems[4].BackColor = System.Drawing.Color.LightGoldenrodYellow;
                                } else {
                                        Itm.SubItems[2].Text = Lfx.Types.Formatting.FormatCurrency(NuevoCosto);
                                        Itm.SubItems[4].Text = Lfx.Types.Formatting.FormatCurrency(NuevoPvp);
                                        Itm.SubItems[2].BackColor = System.Drawing.Color.LightGoldenrodYellow;
                                        Itm.SubItems[4].BackColor = System.Drawing.Color.LightGoldenrodYellow;
                                }
                        }
                }

                private void CambioMasivoPrecios_Activated(object sender, EventArgs e)
                {
                        this.Recalcular();
                }
        }
}