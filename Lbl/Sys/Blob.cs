using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Sys
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Blob", Grupo = "Blobs")]
        [Lbl.Atributos.Datos(TablaDatos = "sys_blobs", CampoId = "id_blob")]
        [Lbl.Atributos.Presentacion()]
	public class Blob : ElementoDeDatos, IElementoConImagen
	{
		public Blob(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

		public Blob(Lfx.Data.Connection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Blob(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

                public override Lfx.Types.OperationResult Guardar()
                {
                        qGen.TableCommand Comando;
                        if (this.Existe == false) {
                                Comando = new qGen.Insert(Connection, this.TablaDatos);
                                if(this.Id > 0) {
                                        Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                                }
                                Comando.Fields.AddWithValue("fecha", qGen.SqlFunctions.Now);
                        } else {
                                Comando = new qGen.Update(Connection, this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        Comando.Fields.AddWithValue("imagen", this.Imagen);

                        Connection.Execute(Comando);
                        
                        return base.Guardar();
                }
	}
}
