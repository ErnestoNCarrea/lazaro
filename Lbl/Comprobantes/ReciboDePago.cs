using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Recibo de pago", Grupo = "Comprobantes")]
        [Lbl.Atributos.Datos(TablaDatos = "recibos", CampoId = "id_recibo", TablaImagenes = "recibos_imagenes")]
        [Lbl.Atributos.Presentacion()]
        public class ReciboDePago : Recibo
        {
                //Heredar constructor
                public ReciboDePago(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

                public ReciboDePago(Lfx.Data.Connection dataBase, Personas.Persona cliente)
                        : this(dataBase)
                {
                        this.Crear();
                        this.Cliente = cliente;
                }

                public ReciboDePago(Lfx.Data.Connection dataBase, int idRecibo)
                        : base(dataBase, idRecibo) { }

                public ReciboDePago(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

                public override void Crear()
                {
                        base.Crear();
                        this.Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra["RCP"];
                        this.Vendedor = new Personas.Persona(this.Connection, Lbl.Sys.Config.Actual.UsuarioConectado.Id);
                }
        }
}
