using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Presupuesto")]
        [Lbl.Atributos.Datos(TablaDatos = "comprob", CampoId = "id_comprob", TablaImagenes = "comprob_imagenes")]
        [Lbl.Atributos.Presentacion(PanelExtendido = Lbl.Atributos.PanelExtendido.Automatico)]

        [Entity(TableName = "comprob", IdFieldName = "id_comprob")]
        public class Presupuesto : ComprobanteConArticulos
        {
                //Heredar constructor
                public Presupuesto(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public Presupuesto(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
			: base(dataBase, row) { }

                public Presupuesto(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public override void Crear()
                {
                        base.Crear();
                        this.Fecha = System.DateTime.Now;
                        this.Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra["PS"];
                }
        }
}
