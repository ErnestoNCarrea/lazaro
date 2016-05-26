using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Recibos
{
	public partial class Inicio : Lfc.FormularioListado
	{
		protected internal Lfx.Types.DateRange m_Fecha = new Lfx.Types.DateRange("mes-0");
		protected internal int m_Sucursal, m_Cliente;
		protected internal int m_Vendedor;

                public Inicio()
                {
                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Comprobantes.Recibo),

                                TableName = "recibos",
                                Joins = new qGen.JoinCollection() { new qGen.Join("personas", "recibos.id_cliente=personas.id_persona") },
                                KeyColumn = new Lazaro.Pres.Field("recibos.id_recibo", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                OrderBy = "recibos.fecha DESC",
                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("recibos.nombre", "Número", Lfx.Data.InputFieldTypes.Text, 120),
				        new Lazaro.Pres.Field("recibos.fecha", "Fecha", Lfx.Data.InputFieldTypes.Date, 96),
				        new Lazaro.Pres.Field("recibos.total", "Importe", Lfx.Data.InputFieldTypes.Currency, 96),
				        new Lazaro.Pres.Field("0", "Facturas", Lfx.Data.InputFieldTypes.Text, 160),
				        new Lazaro.Pres.Field("personas.nombre_visible", "Cliente", Lfx.Data.InputFieldTypes.Text, 240),
				        new Lazaro.Pres.Field("recibos.concepto", "Concepto", Lfx.Data.InputFieldTypes.Text, 320),
				        new Lazaro.Pres.Field("recibos.obs", "Obs.", Lfx.Data.InputFieldTypes.Memo, 320),
                                        new Lazaro.Pres.Field("recibos.estado", "Estado", Lfx.Data.InputFieldTypes.Integer, 0)
			        }
                        };

                        this.Contadores.Add(new Contador("Total", Lui.Forms.DataTypes.Currency, "$", null));

                        this.HabilitarFiltrar = true;
                        this.HabilitarBorrar = true;
                }

                protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
		{
                        this.Contadores[0].AddValue(row.Fields["total"].ValueDecimal);

                        if (Lfx.Workspace.Master.SlowLink || this.Listado.Items.Count > 300)
                                item.SubItems["0"].Text = "";
                        else
                                item.SubItems["0"].Text = Lbl.Comprobantes.Comprobante.FacturasDeUnRecibo(this.Connection, row.Fields["id_recibo"].ValueInt);

                        if (row.Fields["estado"].ValueInt == 90)
                                item.Font = new Font(item.Font, FontStyle.Strikeout);
		}


                public override Lfx.Types.OperationResult OnFilter()
                {
                        Lfx.Types.OperationResult filtrarReturn = base.OnFilter();

                        if (filtrarReturn.Success == true) {
                                using (Comprobantes.Recibos.Filtros FormFiltros = new Comprobantes.Recibos.Filtros()) {
                                        FormFiltros.Connection = this.Connection;
                                        FormFiltros.EntradaSucursal.ValueInt = m_Sucursal;
                                        FormFiltros.EntradaCliente.ValueInt = m_Cliente;
                                        FormFiltros.EntradaVendedor.ValueInt = m_Vendedor;
                                        FormFiltros.EntradaFechas.Rango = m_Fecha;
                                        FormFiltros.Owner = this;
                                        FormFiltros.ShowDialog();

                                        if (FormFiltros.DialogResult == DialogResult.OK) {
                                                m_Sucursal = FormFiltros.EntradaSucursal.ValueInt;
                                                m_Cliente = FormFiltros.EntradaCliente.ValueInt;
                                                m_Vendedor = FormFiltros.EntradaVendedor.ValueInt;
                                                m_Fecha = FormFiltros.EntradaFechas.Rango;

                                                this.RefreshList();
                                                filtrarReturn.Success = true;
                                        } else {
                                                filtrarReturn.Success = false;
                                        }
                                }
                        }

                        return filtrarReturn;
                }


                public override Lfx.Types.OperationResult SolicitudEliminacion(Lbl.ListaIds codigos)
                {
                        Lfx.Workspace.Master.RunTime.Execute("INSTANCIAR Lfc.Comprobantes.Recibos.Anular " + codigos[0].ToString());
                        return new Lfx.Types.SuccessOperationResult();
                }

                public override string SearchText
                {
                        get
                        {
                                return base.SearchText;
                        }
                        set
                        {
                                if (value == null) {
                                        base.SearchText = null;
                                } else if (System.Text.RegularExpressions.Regex.IsMatch(value, @"^[0-3]\d(-|/)[0-1]\d(-|/)(\d{2}|\d{4})$")) {
                                        this.SearchText = Lfx.Types.Formatting.FormatDateTimeSql(value).ToString();
                                } else if (System.Text.RegularExpressions.Regex.IsMatch(value, @"^[0-3]\d(-|/)[0-1]\d$")) {
                                        this.SearchText = Lfx.Types.Formatting.FormatDateTimeSql(value + System.DateTime.Now.ToString("yyyy")).ToString();
                                } else {
                                        base.SearchText = value;
                                }
                        }
                }

		protected override void OnBeginRefreshList()
		{
                        this.CustomFilters.Clear();

                        if (this.Definicion.ElementoTipo == typeof(Lbl.Comprobantes.ReciboDeCobro))
                                this.CustomFilters.AddWithValue("recibos.tipo_fac", "RC");
                        else
                                this.CustomFilters.AddWithValue("recibos.tipo_fac", "RCP");

                        if (SearchText == null || SearchText.Length == 0) {
                                if (m_Sucursal > 0)
                                        this.CustomFilters.AddWithValue("recibos.id_sucursal", m_Sucursal);

                                if (m_Cliente > 0)
                                        this.CustomFilters.AddWithValue("recibos.id_cliente", m_Cliente);

                                if (m_Vendedor > 0)
                                        this.CustomFilters.AddWithValue("recibos.id_vendedor", m_Vendedor);

                                if (m_Fecha.HasRange)
                                        this.CustomFilters.AddWithValue("(recibos.fecha BETWEEN '" + Lfx.Types.Formatting.FormatDateSql(m_Fecha.From) + " 00:00:00' AND '" + Lfx.Types.Formatting.FormatDateSql(m_Fecha.To) + " 23:59:59')");
                        }

                        base.OnBeginRefreshList();
		}
	}
}