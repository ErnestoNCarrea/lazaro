using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Consultas
{
        /// <summary>
        /// Representa un parámetro de una Consulta.
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Parámetro")]
        [Lbl.Atributos.Datos(TablaDatos = "consultas_parametros", CampoId = "id_parametro")]
        [Lbl.Atributos.Presentacion()]
        public class Parametro : Lbl.ElementoDeDatos
        {
                private Consulta m_Consulta = null;

                //Heredar constructor
		public Parametro(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

		public Parametro(Lfx.Data.Connection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Parametro(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                public override void OnLoad()
                {
                        m_Consulta = null;
                        base.OnLoad();
                }

                public Consulta Consulta
                {
                        get
                        {
                                if (m_Consulta == null)
                                        m_Consulta = this.GetFieldValue<Consulta>("id_consulta");
                                return m_Consulta;
                        }
                        set
                        {
                                m_Consulta = value;
                                this.SetFieldValue("id_consulta", value.Id);
                        }
                }


                public string Variable
                {
                        get
                        {
                                return this.GetFieldValue<string>("variable");
                        }
                        set
                        {
                                this.Registro["variable"] = value;
                        }
                }


                public Lfx.Data.InputFieldTypes TipoEntrada
                {
                        get
                        {
                                return (Lfx.Data.InputFieldTypes)(Enum.Parse(typeof(Lfx.Data.InputFieldTypes), this.GetFieldValue<string>("tipoentrada")));
                        }
                        set
                        {
                                this.Registro["tipoentrada"] = value.ToString();
                        }
                }


                public int Orden
                {
                        get
                        {
                                return this.GetFieldValue<int>("orden");
                        }
                        set
                        {
                                this.Registro["orden"] = value;
                        }
                }
        }
}
