using System;
using System.Collections.Generic;
using System.Text;
using Lazaro.Orm;
using Lazaro.Orm.Attributes;

namespace Lbl.Impuestos
{
        /// <summary>
        /// Representa una alícuota de IVA.
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Alícuota", Grupo = "Impuestos")]
        [Lbl.Atributos.Datos(TablaDatos = "alicuotas", CampoId = "id_alicuota")]
        [Lbl.Atributos.Presentacion()]

        [Entity(TableName = "alicuotas", IdFieldName = "id_alicuota")]
        public class Alicuota : ElementoDeDatos, IEntity<Alicuota>
        {
                public Alicuota(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public Alicuota(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Alicuota(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


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
                        qGen.TableCommand Comando;

                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.Connection, this.TablaDatos);
                        } else {
                                Comando = new qGen.Update(this.Connection, this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        Comando.Fields.AddWithValue("nombre", this.Nombre);
                        Comando.Fields.AddWithValue("porcentaje", this.Porcentaje);
                        Comando.Fields.AddWithValue("importe_minimo", this.ImporteMinimo);

                        this.AgregarTags(Comando);

                        this.Connection.Execute(Comando);

                        return base.Guardar();
                }
        }
}
