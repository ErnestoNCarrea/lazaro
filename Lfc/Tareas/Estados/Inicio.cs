using System.Collections.Generic;

namespace Lfc.Tareas.Estados
{
	public partial class Inicio : Lfc.FormularioListado
	{
                public Inicio()
                {
                        /* Dictionary<int, string> EstadosTickets = new Dictionary<int, string>()
                        {
                                {0, "Inactivo"},
                                {1, "Activo"}
                        }; */

                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Tareas.Estado),

                                TableName = "tickets_estados",
                                KeyColumn = new Lazaro.Pres.Field("tickets_estados.id_ticket_estado", "Cód.", Lfx.Data.InputFieldTypes.Serial, 64),

                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("tickets_estados.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 320),
			        },

                                OrderBy = "tickets_estados.nombre"
                        };
                        this.HabilitarFiltrar = true;
                }
	}
}