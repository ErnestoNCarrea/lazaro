namespace Lbl.Comprobantes
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Comprobante Facturable")]
        [Lbl.Atributos.Datos(TablaDatos = "comprob", CampoId = "id_comprob")]
        [Lbl.Atributos.Presentacion()]
        public class ComprobanteFacturable : ComprobanteConArticulos
        {
                //Heredar constructor
                public ComprobanteFacturable(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public ComprobanteFacturable(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
			: base(dataBase, row) { }

                public ComprobanteFacturable(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public override void Crear()
                {
                        base.Crear();
                        this.Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra["FB"];
                }
        }
}
