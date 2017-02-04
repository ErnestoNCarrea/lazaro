using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Comprobantes.Compra
{
	public partial class Inicio : Lfc.FormularioListado
	{
                private int m_Estado = -2;
                private string m_Tipo = "FP";
                private Lbl.Personas.Persona m_Proveedor;
		private Lfx.Types.DateRange m_Fechas = new Lfx.Types.DateRange("mes-0");
                //Requiere permisos de comprobantes con articulos 
        	public Inicio()
		{
                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Comprobantes.ComprobanteDeCompra),

                                TableName = "comprob",
                                Joins = new qGen.JoinCollection() {
                                        new qGen.Join("comprob_detalle", "comprob.id_comprob=comprob_detalle.id_comprob"),
                                        new qGen.Join("personas", "comprob.id_cliente=personas.id_persona")
                                },
                                KeyColumn = new Lazaro.Pres.Field("comprob.id_comprob", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                GroupBy = new Lazaro.Pres.Field("comprob.id_comprob", "Cód.", Lfx.Data.InputFieldTypes.Serial, 0),
                                OrderBy = "comprob.fecha DESC",
                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("comprob.tipo_fac", "Tipo", Lfx.Data.InputFieldTypes.Text, 48),
				        new Lazaro.Pres.Field("comprob.pv", "PV", Lfx.Data.InputFieldTypes.Integer, 80),
				        new Lazaro.Pres.Field("comprob.numero", "Número", Lfx.Data.InputFieldTypes.Integer, 120),
				        new Lazaro.Pres.Field("comprob.fecha", "Fecha", Lfx.Data.InputFieldTypes.Date, 96),
				        new Lazaro.Pres.Field("personas.nombre_visible", "Proveedor", Lfx.Data.InputFieldTypes.Relation, 160),
				        new Lazaro.Pres.Field("comprob.total", "Total", Lfx.Data.InputFieldTypes.Currency, 96),
                                        new Lazaro.Pres.Field("comprob.total-comprob.cancelado AS pendiente", "Pendiente", Lfx.Data.InputFieldTypes.Currency, 96),
				        new Lazaro.Pres.Field("comprob.estado", "Estado", Lfx.Data.InputFieldTypes.Text, 0),
                                        new Lazaro.Pres.Field("comprob.id_formapago", "Pago", Lfx.Data.InputFieldTypes.Text, 0)
			        },

                                ExtraSearchColumns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("comprob_detalle.series", "Números de Serie", Lfx.Data.InputFieldTypes.Text, 0),
				        new Lazaro.Pres.Field("comprob.obs", "Observaciones", Lfx.Data.InputFieldTypes.Memo, 0)
			        },

                                Filters = new Lazaro.Pres.Filters.FilterCollection()
                                {
                                        new Lazaro.Pres.Filters.SetFilter("Tipo", "comprob.tipo_fac", new string[] {
                                                "Notas de Pedido|NP",
                                                "Pedidos|PD",
                                                "Remitos|R",
                                                "Facturas A|FA",
                                                "Facturas B|FB",
                                                "Facturas C|FC",
                                                "Facturas E|FE",
                                                "Facturas M|FM",
                                                "Notas de Crédito|NC",
                                                "Notas de Débito|ND",
                                                "Facturas (todas)|FP",
                                                "Todo|*" }, "NP"),
                                        new Lazaro.Pres.Filters.SetFilter("Estado", "comprob.estado", new string[] {
                                                "Todos|-2",
                                                "No pedidos|-1",
						"Pedidos|100",
                                                "Cancelados|200" }, "-2"),
                                        new Lazaro.Pres.Filters.RelationFilter("Proveedor", new Lazaro.Orm.Data.Relation("comprob.id_cliente", "personas", "id_persona", "nombre_visible"), new qGen.Where("(tipo&2)=2")),
                                        new Lazaro.Pres.Filters.DateRangeFilter("Fecha", "comprob.fecha", new Lfx.Types.DateRange("mes-0"))
                                }
                        };

                        this.Tipo = "FP";
                        this.Estado = -2;
                        this.Fechas = new Lfx.Types.DateRange("mes-0");
                        this.FixedFilters.AddWithValue("comprob.anulada", 0);
                        this.Contadores.Add(new Contador("Total", Lui.Forms.DataTypes.Currency));
                        this.Contadores.Add(new Contador("Pendiente", Lui.Forms.DataTypes.Currency));

                        this.HabilitarFiltrar = true;
                }


                public Inicio(string comando)
                        : this()
                {
                        this.Tipo = comando;
                }


                public override void OnFiltersChanged(Lazaro.Pres.Filters.FilterCollection filters)
                {
                        this.Tipo = this.Definicion.Filters["comprob.tipo_fac"].Value as string;
                        this.Estado = Lfx.Types.Parsing.ParseInt(this.Definicion.Filters["comprob.estado"].Value as string);
                        this.Proveedor = this.Definicion.Filters["comprob.id_cliente"].Value as Lbl.Personas.Persona;
                        this.Fechas = this.Definicion.Filters["comprob.fecha"].Value as Lfx.Types.DateRange;

                        base.OnFiltersChanged(filters);
                }


                public string Tipo
                {
                        get
                        {
                                return m_Tipo;
                        }
                        set
                        {
                                if (value != m_Tipo) {
                                        Lazaro.Pres.Filters.SetFilter SetFil = this.Definicion.Filters["comprob.estado"] as Lazaro.Pres.Filters.SetFilter;
                                        switch (value) {
                                                case "NP":
                                                        SetFil.SetData = new string[] {
                                                                "Todos|-2",
                                                                "No pedidos|-1",
						                "Pedidos|100",
                                                                "Cancelados|200"
					                };
                                                        this.Estado = -2;
                                                        break;
                                                case "PD":
                                                        SetFil.SetData = new string[] {
                                                                "Todos|-2",
						                "Sin especificar|0",
						                "No recibidos|-1",
						                "Recibidos|100"
					                };
                                                        this.Estado = -2;
                                                        break;
                                                default:
                                                        SetFil.SetData = new string[] { "Todos|-2" };
                                                        this.Estado = -2;
                                                        break;
                                        }
                                }

                                m_Tipo = value;
                                this.Definicion.Filters["comprob.tipo_fac"].Value = value;
                        }
                }

                public int Estado
                {
                        get
                        {
                                return m_Estado;
                        }
                        set
                        {
                                m_Estado = value;
                                this.Definicion.Filters["comprob.estado"].Value = value.ToString();
                        }
                }


                public Lfx.Types.DateRange Fechas
                {
                        get
                        {
                                return m_Fechas;
                        }
                        set
                        {
                                m_Fechas = value;
                                this.Definicion.Filters["comprob.fecha"].Value = value;
                        }
                }


                public Lbl.Personas.Persona Proveedor
                {
                        get
                        {
                                return m_Proveedor;
                        }
                        set
                        {
                                m_Proveedor = value;
                                this.Definicion.Filters["comprob.id_cliente"].Value = value;
                        }
                }


                public override Lbl.IElementoDeDatos Crear()
                {
                        Lbl.IElementoDeDatos Res = base.Crear();
                        if (Res is Lbl.Comprobantes.ComprobanteDeCompra) {
                                string Tipo = this.Tipo;
                                using (Crear FormCrear = new Crear()) {
                                        if (FormCrear.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                                                Tipo = FormCrear.TipoComprob;
                                        } else {
                                                return null;
                                        }
                                }
                                Lbl.Comprobantes.ComprobanteDeCompra Comprob = Res as Lbl.Comprobantes.ComprobanteDeCompra;

                                switch (Tipo) {
                                        case "FP":
                                                Tipo = "FA";
                                                break;
                                        case "NC":
                                                Tipo = "NCA";
                                                break;
                                        case "ND":
                                                Tipo = "NDA";
                                                break;
                                }

                                if (Lbl.Comprobantes.Tipo.TodosPorLetra.ContainsKey(Tipo)) {
                                        Comprob.Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra[Tipo];
                                } else {
                                        
                                        throw new InvalidOperationException("No se puede crear el tipo " + Tipo);
                                }
                        }
                        return Res;
                }


                protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
                {
                        item.SubItems["comprob.pv"].Text = row.Fields["comprob.pv"].ValueInt.ToString("0000");
                        item.SubItems["comprob.numero"].Text = row.Fields["comprob.numero"].ValueInt.ToString("00000000");
                        Contadores[0].AddValue(row.Fields["comprob.total"].ValueDecimal);
                        Contadores[1].AddValue(row.Fields["pendiente"].ValueDecimal);

                        //Lfx.Data.Row Persona = this.Connection.Tables["personas"].FastRows[row.Fields["comprob.id_cliente"].ValueInt];
                        //if (Persona != null)
                        //        item.SubItems["comprob.id_cliente"].Text = Persona.Fields["personas.nombre_visible"].ToString();

                        switch (row.Fields["comprob.estado"].ValueInt) {
                                case 50:
                                        item.ForeColor = System.Drawing.Color.DarkOrange;
                                        break;
                                case 100:
                                        item.ForeColor = System.Drawing.Color.DarkGreen;
                                        break;
                                case 200:
                                        item.ForeColor = System.Drawing.Color.DarkRed;
                                        item.Font = new Font(item.Font, System.Drawing.FontStyle.Strikeout);
                                        break;
                        }

                        if (row.Fields["comprob.id_formapago"] != null) {
                                switch (row.Fields["id_formapago"].ValueInt) {
                                        case 3:
                                                //Controla Pago
                                                break;
                                        default:
                                                item.SubItems["comprob.total-comprob.cancelado AS pendiente"].Text = "";
                                                break;
                                }
                        }
                }


                protected override void OnBeginRefreshList()
                {
                        this.CustomFilters.Clear();
                        this.CustomFilters.AddWithValue("compra", 1);
                        switch (Tipo) {
                                case "NP":
                                        this.CustomFilters.AddWithValue("comprob.tipo_fac", "NP");
                                        if (this.Estado == -1)
                                                this.CustomFilters.AddWithValue("(comprob.estado<=50)");
                                        break;

                                case "PD":
                                        this.CustomFilters.AddWithValue("comprob.tipo_fac", "PD");
                                        if (this.Estado == -1)
                                                this.CustomFilters.AddWithValue("(comprob.estado<=50)");
                                        break;

                                case "FP":
                                        this.CustomFilters.AddWithValue("comprob.tipo_fac IN ('FA', 'FB', 'FC', 'FE', 'FM')");
                                        break;

                                case "NC":
                                        this.CustomFilters.AddWithValue("comprob.tipo_fac IN ('NCA', 'NCB', 'NCC', 'NCE', 'NCM')");
                                        break;

                                case "ND":
                                        this.CustomFilters.AddWithValue("comprob.tipo_fac IN ('NDA', 'NDB', 'NDC', 'NDE', 'NDM')");
                                        break;

                                case "RP":
                                case "FA":
                                case "FB":
                                case "FC":
                                case "FE":
                                case "FM":
                                default:
                                        this.CustomFilters.AddWithValue("comprob.tipo_fac", Tipo);
                                        break;
                        }

                        if (this.Proveedor != null)
                                this.CustomFilters.AddWithValue("comprob.id_cliente", this.Proveedor.Id);

                        if (this.Estado >= 0)
                                this.CustomFilters.AddWithValue("comprob.estado", this.Estado);

                        if (this.Fechas.HasRange)
                                this.CustomFilters.AddWithValue("(comprob.fecha BETWEEN '" + Lfx.Types.Formatting.FormatDateSql(this.Fechas.From) + " 00:00:00' AND '" + Lfx.Types.Formatting.FormatDateSql(this.Fechas.To) + " 23:59:59')");

                        base.OnBeginRefreshList();
                }
	}
}