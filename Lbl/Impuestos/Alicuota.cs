using System;
using System.Collections.Generic;
using System.Text;
using Lazaro.Orm;
using Lazaro.Orm.Attributes;
using Lazaro.Orm.Mapping;

namespace Lbl.Impuestos
{
        /// <summary>
        /// Representa una alícuota de IVA.
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Alícuota", Grupo = "Impuestos")]
        [Lbl.Atributos.Datos(TablaDatos = "alicuotas", CampoId = "id_alicuota")]
        [Lbl.Atributos.Presentacion()]

        [Entity(TableName = "alicuotas", IdFieldName = "id_alicuota")]
        public class Alicuota : ElementoDeDatos, IEntity<Alicuota>, IEntidad
        {
                public Alicuota(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public Alicuota(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Alicuota(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                /// <summary>
                /// Obtiene o establece el nombre del elemento.
                /// </summary>
                [Column(Name = "nombre", Type = ColumnTypes.VarChar, Length = 200, Nullable = false)]
                public virtual string Nombre
                {
                        get
                        {
                                return this.GetFieldValue<string>(CampoNombre);
                        }
                        set
                        {
                                this.Registro[CampoNombre] = value;
                        }
                }


                [Column(Name = "porcentaje")]
                public decimal Porcentaje
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("porcentaje");
                        }
                        set
                        {
                                this.Registro["porcentaje"] = value;
                        }
                }

                [Column(Name = "importe_minimo")]
                public decimal ImporteMinimo
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("importe_minimo");
                        }
                        set
                        {
                                this.Registro["importe_minimo"] = value;
                        }
                }


                public override Lfx.Types.OperationResult Guardar()
                {
                        var Em = new Lazaro.Orm.EntityManager(this.Connection, Lfx.Workspace.Master.MetadataFactory);

                        Em.Persist(this);

                        /* qGen.IStatement Comando;

                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.TablaDatos);
                        } else {
                                Comando = new qGen.Update(this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        Comando.ColumnValues.AddWithValue("nombre", this.Nombre);
                        Comando.ColumnValues.AddWithValue("porcentaje", this.Porcentaje);
                        Comando.ColumnValues.AddWithValue("importe_minimo", this.ImporteMinimo);

                        this.AgregarTags(Comando);

                        this.Connection.ExecuteNonQuery(Comando); */

                        return base.Guardar();
                }
        }
}
