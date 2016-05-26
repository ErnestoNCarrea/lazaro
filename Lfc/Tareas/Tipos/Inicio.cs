using System.Collections.Generic;

namespace Lfc.Tareas.Tipos
{
	public partial class Inicio : Lfc.FormularioListado
	{
                public Inicio()
                {
                        Dictionary<int, string> EstadosTickets = new Dictionary<int, string>()
                        {
                                {0, "Inactivo"},
                                {1, "Activo"}
                        };

                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Tareas.Tipo),

                                TableName = "tickets_tipos",
                                KeyColumn = new Lazaro.Pres.Field("tickets_tipos.id_tipo_ticket", "Cód.", Lfx.Data.InputFieldTypes.Serial, 64),

                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("tickets_tipos.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 320),
				        new Lazaro.Pres.Field("tickets_tipos.estado", "Estado", 160, EstadosTickets),
			        },
                                OrderBy = "tickets_tipos.nombre"
                        };

                        this.HabilitarFiltrar = true;
                }
	}
}