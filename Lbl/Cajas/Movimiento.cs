using System;
using System.Collections.Generic;

namespace Lbl.Cajas
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Movimiento de caja", Grupo = "Cuentas")]
        [Lbl.Atributos.Datos(TablaDatos = "cajas_movim", CampoId = "id_movim", CampoNombre = "concepto")]
        [Lbl.Atributos.Presentacion(PanelExtendido = Lbl.Atributos.PanelExtendido.Nunca)]
        public class Movimiento : Lbl.ElementoDeDatos
        {
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
