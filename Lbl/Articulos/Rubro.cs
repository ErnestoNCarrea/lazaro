using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Articulos
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Rubro", Grupo = "Artículos")]
        [Lbl.Atributos.Datos(TablaDatos = "articulos_rubros", CampoId = "id_rubro")]
        [Lbl.Atributos.Presentacion()]
	public class Rubro : ElementoDeDatos
	{
                private Lbl.Impuestos.Alicuota m_Alicuota = null;

		public Rubro(Lfx.Data.IConnection dataBase) 
                        : base(dataBase) { }

		public Rubro(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Rubro(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

		public override Lfx.Types.OperationResult Guardar()
                {
			qGen.IStatement Comando;

                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.TablaDatos);
                        } else {
                                Comando = new qGen.Update(this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        Comando.ColumnValues.AddWithValue("nombre", this.Nombre);
                        if (this.Alicuota == null)
                                Comando.ColumnValues.AddWithValue("id_alicuota", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_alicuota", this.Alicuota.Id);

			this.AgregarTags(Comando);

                        this.Connection.Execute(Comando);

			return base.Guardar();
		}

                public Lbl.Impuestos.Alicuota Alicuota
                {
                        get
                        {
                                if (m_Alicuota == null && this.GetFieldValue<int>("id_alicuota") != 0)
                                        m_Alicuota = this.GetFieldValue<Impuestos.Alicuota>("id_alicuota");
                                return m_Alicuota;
                        }
                        set
                        {
                                m_Alicuota = value;
                                this.SetFieldValue("id_alicuota", value);
                        }
                }
	}
}
