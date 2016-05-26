using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace Lfc.Tareas
{
	public partial class Inicio : Lfc.FormularioListado
	{
                private Lbl.Tareas.Tipo m_Tipo { get; set; }
                private Lbl.Entidades.Localidad m_Localidad { get; set; }
                private Lbl.Personas.Persona m_Cliente { get; set; }
                private string m_Estado { get; set; }

                protected int Activos;
                protected int Terminados;
                protected int Retrasados;
                protected int Nuevos;
                protected Lbl.ColeccionCodigoDetalle EstadosTickets = null;

                public Inicio()
                {
                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Tareas.Tarea),

                                TableName = "tickets",
                                Joins = new qGen.JoinCollection() { new qGen.Join("personas", "tickets.id_persona=personas.id_persona") },
                                KeyColumn = new Lazaro.Pres.Field("tickets.id_ticket", "Cód.", Lfx.Data.InputFieldTypes.Serial, 64),

                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("tickets.nombre", "Asunto", Lfx.Data.InputFieldTypes.Text, 320),
				        new Lazaro.Pres.Field("personas.nombre_visible", "Cliente", Lfx.Data.InputFieldTypes.Text, 240),
				        new Lazaro.Pres.Field("tickets.estado", "Estado", 160, new Dictionary<int,string>()),
				        new Lazaro.Pres.Field("tickets.fecha_ingreso", "Ingreso", Lfx.Data.InputFieldTypes.DateTime, 160),
                                        new Lazaro.Pres.Field("tickets.entrega_limite", "Vencimiento", Lfx.Data.InputFieldTypes.Date, 96),
                                        new Lazaro.Pres.Field("tickets.id_tecnico_recibe", "Encargado", Lfx.Data.InputFieldTypes.Text, 240),
                                        new Lazaro.Pres.Field("DATEDIFF(NOW(), tickets.fecha_ingreso) AS fechadiff", "Antigüedad", Lfx.Data.InputFieldTypes.Integer, 60)
			        },

                                Filters = new Lazaro.Pres.Filters.FilterCollection() 
                                {
                                        new Lazaro.Pres.Filters.RelationFilter("Cliente", new Lfx.Data.Relation("tickets.id_persona", "personas", "id_persona", "nombre_visible")),
                                        new Lazaro.Pres.Filters.RelationFilter("Localidad", new Lfx.Data.Relation("personas.id_ciudad", "ciudades", "id_ciudad"), new qGen.Where("id_provincia", qGen.ComparisonOperators.NotEqual, null)),
                                        new Lazaro.Pres.Filters.RelationFilter("Tipo", new Lfx.Data.Relation("tickets.id_tipo_ticket", "tickets_tipos", "id_tipo_ticket")),
                                        new Lazaro.Pres.Filters.SetFilter("Estado", "tickets.estado", new string[] {
                                                "Todos|todos",
                                                "Sin Terminar|<30", 
                                                "Terminados Sin Verificar|<40",
                                                "Terminados Sin Entregar|<50" }, "<50"),
                                        new Lazaro.Pres.Filters.SetFilter("Orden", "ORDER BY", new string[] {
                                                "Los más nuevos primero|tickets.id_ticket DESC",
                                                "Los más antiguos primero|tickets.id_ticket",
                                                "Por nombre del Cliente|personas.nombre_visible" }, "tickets.id_ticket DESC")
                                },

                                OrderBy = "tickets.id_ticket DESC",
                        };

                        this.Estado = "<50";

                        this.HabilitarFiltrar = true;
                }


                protected override void OnLoad(EventArgs e)
                {
                        base.OnLoad(e);
                        if (this.Connection != null) {
                                EstadosTickets = new Lbl.ColeccionCodigoDetalle(this.Connection.Select("SELECT id_ticket_estado, nombre FROM tickets_estados"));
                                this.Definicion.Columns["tickets.estado"].SetValues = EstadosTickets;
                        }
                }


                public string Estado
                {
                        get
                        {
                                return m_Estado;
                        }
                        set
                        {
                                m_Estado = value;
                                this.Definicion.Filters["tickets.estado"].Value = value;
                        }                                
                }


                public Lbl.Personas.Persona Cliente
                {
                        get
                        {
                                return m_Cliente;
                        }
                        set
                        {
                                m_Cliente = value;
                                this.Definicion.Filters["tickets.id_persona"].Value = value;
                        }
                }


                public Lbl.Tareas.Tipo Tipo
                {
                        get
                        {
                                return m_Tipo;
                        }
                        set
                        {
                                m_Tipo = value;
                                this.Definicion.Filters["tickets.id_tipo_ticket"].Value = value;
                        }
                }


                public Lbl.Entidades.Localidad Localidad
                {
                        get
                        {
                                return m_Localidad;
                        }
                        set
                        {
                                m_Localidad = value;
                                this.Definicion.Filters["personas.id_ciudad"].Value = value;
                        }
                }


		protected override void OnBeginRefreshList()
		{
                        Activos = 0;
                        Terminados = 0;
                        Retrasados = 0;

                        this.CustomFilters.Clear();

                        if (this.Tipo != null)
                                this.CustomFilters.AddWithValue("tickets.id_tipo_ticket", this.Tipo.Id);

                        if (this.Cliente != null)
                                this.CustomFilters.AddWithValue("tickets.id_persona", this.Cliente.Id);

                        if (this.Localidad != null)
                                this.CustomFilters.AddWithValue("personas.id_ciudad", this.Localidad.Id);

			switch (this.Estado)
			{
				case "todos":
					// Nada
					break;
				case "<30":
					this.CustomFilters.AddWithValue("tickets.estado<30");
					break;
				case "<35":
					this.CustomFilters.AddWithValue("tickets.estado IN (30, 35)");
					break;
                                case null:
				case "<50":
					this.CustomFilters.AddWithValue("tickets.estado<50");
					break;
				default:
					this.CustomFilters.AddWithValue("tickets.estado", Lfx.Types.Parsing.ParseInt(Estado));
					break;
			}

			base.OnBeginRefreshList();
		}


                public override void OnFiltersChanged(Lazaro.Pres.Filters.FilterCollection filters)
                {
                        this.Cliente = this.Definicion.Filters["tickets.id_persona"].Value as Lbl.Personas.Persona;
                        this.Tipo = this.Definicion.Filters["tickets.id_tipo_ticket"].Value as Lbl.Tareas.Tipo;
                        this.Localidad = this.Definicion.Filters["personas.id_ciudad"].Value as Lbl.Entidades.Localidad;
                        this.Estado = this.Definicion.Filters["tickets.estado"].Value as string;
                        this.Definicion.OrderBy = this.Definicion.Filters["ORDER BY"].Value as string;

                        base.OnFiltersChanged(filters);
                }


                protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
                {
                        int IdEncargado = row.Fields["tickets.id_tecnico_recibe"].ValueInt;
                        if (IdEncargado > 0)
                                item.SubItems["tickets.id_tecnico_recibe"].Text = this.Connection.Tables["personas"].FastRows[IdEncargado].Fields["nombre"].ValueString;

                        int IdEstado = row.Fields["tickets.estado"].ValueInt;
                        DateTime FechaLimite = row.Fields["tickets.entrega_limite"].ValueDateTime;
                        if (FechaLimite > DateTime.Now) {
                                item.SubItems["tickets.entrega_limite"].BackColor = Color.Red;
                                item.SubItems["tickets.entrega_limite"].ForeColor = Color.White;
                        }
                        int Dias = row.Fields["tickets.fechadiff"].ValueInt;
                        switch (IdEstado) {
                                case 0:
                                case 1:
                                        Nuevos++;
                                        if (Dias > 1) {
                                                item.ForeColor = Color.Crimson;
                                                Retrasados++;
                                        }
                                        break;
                                case 5:
                                        Activos++;
                                        if (Dias > 3) {
                                                item.ForeColor = Color.Crimson;
                                                Retrasados++;
                                        }
                                        break;
                                case 10:
                                case 20:
                                        Activos++;
                                        if (Dias > 4) {
                                                item.ForeColor = Color.Crimson;
                                                Retrasados++;
                                        }
                                        break;
                                case 30:
                                case 35:
                                        item.ForeColor = Color.DarkGreen;
                                        Terminados++;
                                        break;
                                case 50:
                                        item.ForeColor = System.Drawing.Color.Gray;
                                        break;
                                case 80:
                                case 90:
                                        item.Font = new Font(item.Font, FontStyle.Strikeout);
                                        break;
                        }
                }
	}
}