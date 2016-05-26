namespace Lbl.Comprobantes
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Factura", Grupo = "Comprobantes")]
        [Lbl.Atributos.Datos(TablaDatos = "comprob", CampoId = "id_comprob")]
        [Lbl.Atributos.Presentacion(PanelExtendido = Lbl.Atributos.PanelExtendido.Nunca)]
        public class Factura : ComprobanteFacturable
        {
                 //Heredar constructor
                public Factura(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

                public Factura(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
			: base(dataBase, row) { }

                public Factura(Lfx.Data.Connection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public override void Crear()
                {
                        base.Crear();
                        this.Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra["FB"];
                        if (Lbl.Sys.Config.Actual.Comprobantes.IdClientePredeterminado > 0)
                                this.Cliente = new Personas.Persona(this.Connection, Lbl.Sys.Config.Actual.Comprobantes.IdClientePredeterminado);
                }
        }
}
