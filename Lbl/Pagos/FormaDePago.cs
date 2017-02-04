using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Pagos
{
        /// <summary>
        /// Representa una forma de pago. Tanto para emitir pagos como para recibir pagos.
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Forma de pago", Grupo = "Cobros y pagos")]
        [Lbl.Atributos.Datos(TablaDatos = "formaspago", CampoId = "id_formapago")]
        [Lbl.Atributos.Presentacion()]
        public class FormaDePago : ElementoDeDatos
        {
                private Lbl.Cajas.Caja m_Caja;

                //Heredar constructor
		public FormaDePago(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public FormaDePago(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public FormaDePago(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

                public FormaDePago(Lfx.Data.IConnection dataBase, TiposFormasDePago tipoFormaPago)
                        : this(dataBase)
                {
                        m_ItemId = (int)tipoFormaPago;
                }

		
                public override void Crear()
                {
                        base.Crear();
                        m_Caja = null;
                }

                public override Lfx.Types.OperationResult Cargar()
                {
                        Lfx.Types.OperationResult Res = base.Cargar();
                        if (Res.Success) {
                                if (Registro["id_caja"] == null)
                                        m_Caja = null;
                                else
                                        m_Caja = new Lbl.Cajas.Caja(this.Connection, System.Convert.ToInt32(Registro["id_caja"]));
                        }

                        return Res;
                }

                public TiposFormasDePago Tipo
                {
                        get
                        {
                                return ((TiposFormasDePago)(this.GetFieldValue<int>("tipo")));
                        }
                        set
                        {
                                this.Registro["tipo"] = (int)value;
                        }
                }

                public decimal Descuento
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("descuento");
                        }
                        set
                        {
                                this.Registro["descuento"] = value;
                        }
                }

                public decimal Retencion
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("retencion");
                        }
                        set
                        {
                                this.Registro["retencion"] = value;
                        }
                }

                public int DiasAcreditacion
                {
                        get
                        {
                                return this.GetFieldValue<int>("dias_acred");
                        }
                        set
                        {
                                this.Registro["dias_acred"] = value;
                        }
                }

                public bool AutoAcreditacion
                {
                        get
                        {
                                return this.GetFieldValue<int>("autoacred") == 1;
                        }
                        set
                        {
                                this.Registro["autoacred"] = value ? 1 : 0;
                        }
                }

                public bool AutoPresentacion
                {
                        get
                        {
                                return this.GetFieldValue<int>("autopres") == 1;
                        }
                        set
                        {
                                this.Registro["autopres"] = value ? 1 : 0;
                        }
                }

                public bool PuedeHacerPagos
                {
                        get
                        {
                                return this.GetFieldValue<int>("pagos") == 1;
                        }
                        set
                        {
                                this.Registro["pagos"] = value ? 1 : 0;
                        }
                }

                public bool PuedeHacerCobros
                {
                        get
                        {
                                return this.GetFieldValue<int>("cobros") == 1;
                        }
                        set
                        {
                                this.Registro["cobros"] = value ? 1 : 0;
                        }
                }

                public Lbl.Cajas.Caja Caja
                {
                        get
                        {
                                if (m_Caja == null && this.GetFieldValue<int>("id_caja") > 0)
                                        m_Caja = new Lbl.Cajas.Caja(this.Connection, this.GetFieldValue<int>("id_caja"));
                                return m_Caja;
                        }
                        set
                        {
                                m_Caja = value;
                        }
                }
        }
}
