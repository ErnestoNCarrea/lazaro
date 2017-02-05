using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Articulos
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Categoría de Artículos", Grupo = "Artículos")]
        [Lbl.Atributos.Datos(TablaDatos = "articulos_categorias", CampoId = "id_categoria")]
        [Lbl.Atributos.Presentacion()]
        public class Categoria : ElementoDeDatos, IElementoConImagen
	{
                protected Rubro m_Rubro = null;
                protected Impuestos.Alicuota m_Alicuota = null;

		public Categoria(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

		public Categoria(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Categoria(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

		
		public virtual string NombreSingular
		{
			get
			{
				return this.GetFieldValue<string>("nombresing");
			}
			set
			{
				this.Registro["nombresing"] = value;
			}
		}

		public decimal PuntoDeReposicion
		{
			get
			{
				return this.GetFieldValue<decimal>("stock_minimo");
			}
			set
			{
				this.Registro["stock_minimo"] = value;
			}
		}

                public int Garantia
                {
                        get
                        {
                                return this.GetFieldValue<int>("garantia");
                        }
                        set
                        {
                                Registro["garantia"] = value;
                        }
                }

		public int PublicacionWeb
		{
			get
			{
				return System.Convert.ToInt32(this.Registro["web"]);
			}
			set
			{
				this.Registro["web"] = value;
			}
		}

                public Seguimientos Seguimiento
                {
                        get
                        {
                                return ((Seguimientos)(this.GetFieldValue<int>("requierens")));
                        }
                        set
                        {
                                this.Registro["requierens"] = (int)value;
                        }
                }


                /// <summary>
                /// Devuelve el modo de seguimiento para esta categoría, o "Ninguno" si no se especificó un modo de seguimiento.
                /// Este método nunca devuelve "Predeterminado".
                /// </summary>
                /// <returns>El modo de seguimiento para esta categoría.</returns>
                public Seguimientos ObtenerSeguimiento()
                {
                        if (this.Seguimiento == Seguimientos.Predeterminado)
                                return Seguimientos.Ninguno;
                        else
                                return this.Seguimiento;
                }


                public Rubro Rubro
                {
                        get
                        {
                                if (m_Rubro == null && this.GetFieldValue<int>("id_rubro") != 0)
                                        m_Rubro = new Rubro(this.Connection, this.GetFieldValue<int>("id_rubro"));

                                return m_Rubro;
                        }
                        set
                        {
                                m_Rubro = value;
                                this.SetFieldValue("id_rubro", value);
                        }
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

                public Lbl.Impuestos.Alicuota ObtenerAlicuota()
                {
                        if (this.Alicuota != null)
                                return this.Alicuota;
                        else if (this.Rubro != null && this.Rubro.Alicuota != null)
                                return this.Rubro.Alicuota;
                        else
                                return Lbl.Sys.Config.Empresa.AlicuotaPredeterminada;
                }

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
                        Comando.ColumnValues.AddWithValue("nombresing", this.NombreSingular);
                        Comando.ColumnValues.AddWithValue("stock_minimo", this.PuntoDeReposicion);
                        Comando.ColumnValues.AddWithValue("web", this.PublicacionWeb);
                        Comando.ColumnValues.AddWithValue("requierens", ((int)(this.Seguimiento)));
                        Comando.ColumnValues.AddWithValue("obs", this.Obs);
                        if (this.Rubro == null)
                                Comando.ColumnValues.AddWithValue("id_rubro", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_rubro", this.Rubro.Id);
                        if (this.Alicuota == null)
                                Comando.ColumnValues.AddWithValue("id_alicuota", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_alicuota", this.Alicuota.Id);
                        Comando.ColumnValues.AddWithValue("garantia", this.Garantia);

			this.AgregarTags(Comando);

                        this.Connection.Execute(Comando);

			return base.Guardar();
		}

	}
}
