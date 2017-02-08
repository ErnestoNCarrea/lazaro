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
		public Blob(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

		public Blob(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Blob(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

                public override Lfx.Types.OperationResult Guardar()
                {
                        qGen.IStatement Comando;
                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.TablaDatos);
                                if(this.Id > 0) {
                                        Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                                }
                                Comando.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                        } else {
                                Comando = new qGen.Update(this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        Comando.ColumnValues.AddWithValue("imagen", this.Imagen);

                        Connection.ExecuteNonQuery(Comando);
                        
                        return base.Guardar();
                }
	}
}
