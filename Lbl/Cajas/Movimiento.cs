using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;

namespace Lbl.Cajas
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Movimiento de caja", Grupo = "Cuentas")]
        [Lbl.Atributos.Datos(TablaDatos = "cajas_movim", CampoId = "id_movim", CampoNombre = "concepto")]
        [Lbl.Atributos.Presentacion(PanelExtendido = Lbl.Atributos.PanelExtendido.Nunca)]
        [Entity(TableName = "cajas_movim", IdFieldName = "id_movim")]
        public class Movimiento : Lbl.ElementoDeDatos
        {
                public Movimiento()
                        : base() { }

                //Heredar constructor
                public Movimiento(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

		public Movimiento(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Movimiento(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                /// <summary>
                /// El importe del movimiento.
                /// </summary>
                [Column(Name = "importe")]
                public decimal Importe
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("importe");
                        }
                        set
                        {
                                this.Registro["importe"] = value;
                        }
                }


                /// <summary>
                /// El saldo después de hacer este movimiento.
                /// </summary>
                [Column(Name = "saldo")]
                public decimal Saldo
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("saldo");
                        }
                        set
                        {
                                this.Registro["saldo"] = value;
                        }
                }
        }
}
