using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Articulos
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Márgen", Grupo = "Artículos")]
        [Lbl.Atributos.Datos(TablaDatos = "margenes", CampoId = "id_margen")]
        [Lbl.Atributos.Presentacion()]
	public class Margen : ElementoDeDatos
	{
		public Margen(Lfx.Data.Connection dataBase) : base(dataBase) { }

		public Margen(Lfx.Data.Connection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Margen(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                public decimal Porcentaje
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("porcentaje");
                        }
                        set
                        {
                                this.SetFieldValue("porcentaje", value);
                        }
                }


                public bool Predeterminado
                {
                        get
                        {
                                return this.GetFieldValue<bool>("predet");
                        }
                        set
                        {
                                this.SetFieldValue("predet", value ? 1 : 0);
                        }
                }


                public override Lfx.Types.OperationResult Guardar()
                {
                        qGen.TableCommand Comando;

                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.Connection, this.TablaDatos);
                                Comando.Fields.AddWithValue("fecha", qGen.SqlFunctions.Now);
                        } else {
                                Comando = new qGen.Update(this.Connection, this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        Comando.Fields.AddWithValue("nombre", this.Nombre);
                        Comando.Fields.AddWithValue("porcentaje", this.Porcentaje);
                        Comando.Fields.AddWithValue("predet", this.Predeterminado ? 1 : 0);
                        Comando.Fields.AddWithValue("obs", this.Obs);
                        Comando.Fields.AddWithValue("estado", this.Estado);

                        this.AgregarTags(Comando);

                        this.Connection.Execute(Comando);

                        return base.Guardar();
                }
	}
}
