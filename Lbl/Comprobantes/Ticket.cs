namespace Lbl.Comprobantes
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Ticket")]
        [Lbl.Atributos.Datos(TablaDatos = "comprob", CampoId = "id_comprob")]
        [Lbl.Atributos.Presentacion()]
        public class Ticket : ComprobanteFacturable
        {
                //Heredar constructor
                public Ticket(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

                public Ticket(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

                public Ticket(Lfx.Data.Connection dataBase, int itemId)
                        : base(dataBase, itemId) { }

                public override void Crear()
                {
                        base.Crear();
                        this.Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra["T"];
                }
        }
}
