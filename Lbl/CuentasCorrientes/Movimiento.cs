using System;
using System.Collections.Generic;

namespace Lbl.CuentasCorrientes
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Movimiento de cuenta corriente", Grupo = "Cuentas")]
        [Lbl.Atributos.Datos(TablaDatos = "ctacte", CampoId = "id_movim", CampoNombre = "concepto")]
        [Lbl.Atributos.Presentacion(PanelExtendido = Lbl.Atributos.PanelExtendido.Nunca)]
        public class Movimiento : ElementoDeDatos
        {
                //Heredar constructor
		public Movimiento(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

		public Movimiento(Lfx.Data.Connection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Movimiento(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                public override Lfx.Types.OperationResult Guardar()
                {
                        qGen.TableCommand Comando;

                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.Connection, this.TablaDatos);
                        } else {
                                Comando = new qGen.Update(this.Connection, this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        Comando.Fields.AddWithValue("fecha", this.Fecha);
                        Comando.Fields.AddWithValue("auto", this.Auto ? 1 : 0);
                        Comando.Fields.AddWithValue("concepto", this.Nombre);
                        Comando.Fields.AddWithValue("id_cliente", this.IdCliente);
                        Comando.Fields.AddWithValue("importe", this.Importe);
                        Comando.Fields.AddWithValue("comprob", this.Comprobantes);
                        Comando.Fields.AddWithValue("obs", this.Obs);

                        if (this.IdConcepto == 0)
                                Comando.Fields.AddWithValue("id_concepto", null);
                        else
                                Comando.Fields.AddWithValue("id_concepto", this.IdConcepto);

                        this.AgregarTags(Comando);

                        this.Connection.Execute(Comando);

                        return base.Guardar();
                }


                protected internal int IdCliente
                {
                        get
                        {
                                return this.GetFieldValue<int>("id_cliente");
                        }
                        set
                        {
                                this.Registro["id_cliente"] = value;
                        }
                }


                protected internal int IdConcepto
                {
                        get
                        {
                                return this.GetFieldValue<int>("id_concepto");
                        }
                        set
                        {
                                this.Registro["id_concepto"] = value;
                        }
                }


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


                public string Comprobantes
                {
                        get
                        {
                                return this.GetFieldValue<string>("comprob");
                        }
                        set
                        {
                                this.Registro["comprob"] = value;
                        }
                }

                public bool Auto
                {
                        get
                        {
                                return this.GetFieldValue<int>("auto") != 0;
                        }
                        set
                        {
                                this.Registro["auto"] = value ? 1 : 0;
                        }
                }

        }

}
