using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Cajas
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Concepto", Grupo = "Cuentas")]
        [Lbl.Atributos.Datos(TablaDatos = "conceptos", CampoId = "id_concepto")]
        [Lbl.Atributos.Presentacion()]
        public class Concepto : ElementoDeDatos
        {
                private static Concepto m_IngresosPorFacturacion = null, m_AjustesYMovimientos = null;

                //Heredar constructor
                public Concepto(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

		public Concepto(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Concepto(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

                public int Direccion
                {
                        get
                        {
                                return this.GetFieldValue<int>("es");
                        }
                        set
                        {
                                this.Registro["es"] = value;
                        }
                }

                public int Grupo
                {
                        get
                        {
                                return this.GetFieldValue<int>("grupo");
                        }
                        set
                        {
                                this.Registro["grupo"] = value;
                        }
                }

                public override Lfx.Types.OperationResult Guardar()
                {
                        qGen.IStatement Comando;
                        if (this.Existe == false) {
                                Comando = new qGen.Insert("conceptos");
                        } else {
                                Comando = new qGen.Update("conceptos");
                                Comando.WhereClause = new qGen.Where("id_concepto", this.Id);
                        }

                        Comando.ColumnValues.AddWithValue("nombre", this.Nombre);
                        Comando.ColumnValues.AddWithValue("es", this.Direccion);
                        if (this.Grupo == 0)
                                Comando.ColumnValues.AddWithValue("grupo", null);
                        else
                                Comando.ColumnValues.AddWithValue("grupo", this.Grupo);

                        Connection.Execute(Comando);

                        return base.Guardar();
                }

                public static Cajas.Concepto IngresosPorFacturacion
                {
                        get
                        {
                                if (m_IngresosPorFacturacion == null)
                                        m_IngresosPorFacturacion = new Concepto(Lfx.Workspace.Master.MasterConnection, 11000);

                                return m_IngresosPorFacturacion;
                        }
                }

                public static Cajas.Concepto AjustesYMovimientos
                {
                        get
                        {
                                if (m_AjustesYMovimientos == null)
                                        m_AjustesYMovimientos = new Concepto(Lfx.Workspace.Master.MasterConnection, 30000);

                                return m_AjustesYMovimientos;
                        }
                }
        }
}
