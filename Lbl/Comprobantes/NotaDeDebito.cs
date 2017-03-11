using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Nota de Débito", Grupo = "Comprobantes")]
        [Lbl.Atributos.Datos(TablaDatos = "comprob", CampoId = "id_comprob")]
        [Lbl.Atributos.Presentacion()]

        [Entity(TableName = "comprob", IdFieldName = "id_comprob")]
        public class NotaDeDebito : ComprobanteFacturable
        {
                //Heredar constructor
                public NotaDeDebito(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public NotaDeDebito(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
			: base(dataBase, row) { }

                public NotaDeDebito(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public override void Crear()
                {
                        base.Crear();
                        this.Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra["NDB"];
                }
        }
}
