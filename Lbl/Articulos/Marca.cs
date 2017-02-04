using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Articulos
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Marca", Grupo = "Artículos")]
        [Lbl.Atributos.Datos(TablaDatos = "marcas", CampoId = "id_marca")]
        [Lbl.Atributos.Presentacion()]
	public class Marca : ElementoDeDatos
	{
		public Personas.Persona Proveedor;
		
		public Marca(Lfx.Data.IConnection dataBase) 
                        : base(dataBase) { }

		public Marca(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Marca(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


		public string Url
		{
			get
			{
				if(this.Registro["url"] == null || this.Registro["url"] == DBNull.Value)
					return null;
				else
					return this.Registro["url"].ToString();
			}
			set
			{
				this.Registro["url"] = value;
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
			Comando.Fields.AddWithValue("url", this.Url);
			if(this.Proveedor == null)
				Comando.Fields.AddWithValue("id_proveedor", null);
			else
				Comando.Fields.AddWithValue("id_proveedor", this.Proveedor.Id);
			Comando.Fields.AddWithValue("obs", this.Obs);
			Comando.Fields.AddWithValue("estado", this.Estado);

			this.AgregarTags(Comando);

                        this.Connection.Execute(Comando);

			return base.Guardar();
		}
	}
}
