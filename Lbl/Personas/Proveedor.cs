using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Personas
{
        /// <summary>
        /// Representa un proveedor.
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Proveedor", Grupo = "Personas")]
        [Lbl.Atributos.Datos(TablaDatos = "personas", CampoId = "id_persona", CampoNombre = "nombre_visible", TablaImagenes = "personas_imagenes")]
        [Lbl.Atributos.Presentacion(PanelExtendido = Lbl.Atributos.PanelExtendido.Automatico)]
        public class Proveedor : Persona
        {
                // Heredar constructores
                public Proveedor(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

		public Proveedor(Lfx.Data.Connection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Proveedor(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

                public override void Crear()
                {
                        base.Crear();
                        this.Tipo = 2;
                }
        }
}
