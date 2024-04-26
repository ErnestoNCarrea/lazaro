using Lazaro.Orm;
using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
    [Lbl.Atributos.Nomenclatura(NombreSingular = "Comprobante")]
    [Lbl.Atributos.Datos(TablaDatos = "comprob", CampoId = "id_comprob", TablaImagenes = "comprob_imagenes")]
    [Lbl.Atributos.Presentacion(PanelExtendido = Lbl.Atributos.PanelExtendido.Nunca)]

    [Entity(TableName = "comprob", IdFieldName = "id_comprob")]
    public abstract class Comprobante : ElementoDeDatos, IElementoConImagen, ICamposBaseEstandar
    {
        private Personas.Persona m_Vendedor, m_Cliente;
        private Entidades.Sucursal m_Sucursal;
        private ComprobanteConArticulos m_ComprobanteOriginal;
        private Tipo m_Tipo;

        //Heredar constructor
        protected Comprobante(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

        protected Comprobante(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
    : base(dataBase, row) { }

        protected Comprobante(Lfx.Data.IConnection dataBase, int itemId)
    : base(dataBase, itemId) { }


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


        /// <summary>
        /// Obtiene o establece un texto que representa las observaciones del elemento.
        /// </summary>
        [Column(Name = "obs")]
        public string Obs
        {
            get
            {
                if (this.Registro["obs"] == null || this.Registro["obs"] == DBNull.Value)
                    return null;
                else
                    return this.Registro["obs"].ToString();
            }
            set
            {
                if (value == null) {
                    this.Registro["obs"] = null;
                } else {
                    this.Registro["obs"] = value.Trim(new char[] { '\n', '\r', ' ' });
                }
            }
        }


        /// <summary>
        /// Devuelve o establece el estado del elemento. El valor de esta propiedad tiene diferentes significados para cada clase derivada.
        /// </summary>
        [Column(Name = "estado")]
        public int Estado
        {
            get
            {
                return this.GetFieldValue<int>("estado");
            }
            set
            {
                this.Registro["estado"] = value;
            }
        }


        [Column(Name = "tipo_fac")]
        public string TipoFac
        {
            get
            {
                return this.GetFieldValue<string>("tipo_fac");
            }
            set
            {
                this.Registro["tipo_fac"] = value;
            }
        }


        public virtual Tipo Tipo
        {
            get
            {
                if (m_Tipo == null && this.GetFieldValue<string>("tipo_fac") != null)
                    m_Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra[this.GetFieldValue<string>("tipo_fac")];
                return m_Tipo;
            }
            set
            {
                m_Tipo = value;

                if (value == null) {
                    this.Registro["tipo_fac"] = null;
                } else {
                    this.Registro["tipo_fac"] = value.Nomenclatura;

                    if (this.PV == 0) {
                        this.PV = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Documentos." + Tipo.Nomenclatura + ".PV", 0);
                        if (this.PV /* still */ == 0) {
                            if (Tipo.EsFactura)
                                this.PV = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Documentos.ABC.PV", 0);
                            else if (Tipo.EsNotaCredito)
                                this.PV = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Documentos.NC.PV", 0);
                            else if (Tipo.EsNotaDebito)
                                this.PV = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Documentos.ND.PV", 0);
                        }

                        if (this.PV /* still */ == 0)
                            this.PV = this.Connection.FieldInt("SELECT MIN(numero) FROM pvs WHERE CONCAT(',', tipo_fac, ',') LIKE '%," + this.Tipo.Nomenclatura + ",%' AND tipo>0");
                        if (this.PV /* still */ == 0)
                            this.PV = this.Connection.FieldInt("SELECT MIN(numero) FROM pvs WHERE CONCAT(',', tipo_fac, ',') LIKE '%," + this.Tipo.TipoBase + ",%' AND tipo>0");
                        if (this.PV /* still */ == 0)
                            this.PV = this.Connection.FieldInt("SELECT MIN(numero) FROM pvs WHERE CONCAT(',', tipo_fac, ',') LIKE '%," + this.Tipo.Letra + ",%' AND tipo>0");

                        if (this.PV /* still */ == 0)
                            this.PV = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Documentos.PV", 1);
                    }
                }
            }
        }


        [Column(Name = "numero")]
        public int Numero
        {
            get
            {
                return System.Convert.ToInt32(Registro["numero"]);
            }
            set
            {
                Registro["numero"] = value;
            }
        }


        [Column(Name = "pv")]
        public int PV
        {
            get
            {
                return System.Convert.ToInt32(Registro["pv"]);
            }
            set
            {
                Registro["pv"] = value;
            }
        }


        [Column(Name = "fecha")]
        public DateTime Fecha
        {
            get
            {
                return this.GetFieldValue<DateTime>("fecha");
            }
            set
            {
                Registro["fecha"] = value;
            }
        }


        public override void Crear()
        {
            base.Crear();
            this.Estado = 0;
        }

        public override string ToString()
        {
            string Res = this.Tipo.ToString() + " " + this.PV.ToString("0000") + "-" + this.Numero.ToString("00000000");
            if (this.Cliente != null)
                Res += " de " + this.Cliente.ToString();
            return Res;
        }


        [Column(Name = "id_cliente")]
        [ManyToOne]
        public Lbl.Personas.Persona Cliente
        {
            get
            {
                if (m_Cliente == null && this.GetFieldValue<int>("id_cliente") > 0)
                    m_Cliente = this.GetFieldValue<Personas.Persona>("id_cliente");
                return m_Cliente;
            }
            set
            {
                m_Cliente = value;
                this.SetFieldValue("id_cliente", value);
            }
        }


        [Column(Name = "id_vendedor")]
        [ManyToOne]
        public Lbl.Personas.Persona Vendedor
        {
            get
            {
                if (m_Vendedor == null && this.GetFieldValue<int>("id_vendedor") > 0)
                    m_Vendedor = this.GetFieldValue<Personas.Persona>("id_vendedor");
                return m_Vendedor;
            }
            set
            {
                m_Vendedor = value;
                this.SetFieldValue("id_vendedor", value);
            }
        }


        [Column(Name = "id_sucursal")]
        [ManyToOne]
        public Lbl.Entidades.Sucursal Sucursal
        {
            get
            {
                if (m_Sucursal == null && this.GetFieldValue<int>("id_sucursal") > 0)
                    m_Sucursal = this.GetFieldValue<Lbl.Entidades.Sucursal>("id_sucursal");
                return m_Sucursal;
            }
            set
            {
                m_Sucursal = value;
                this.SetFieldValue("id_sucursal", value);
            }
        }


        public virtual Lbl.Impresion.Impresora ObtenerImpresora()
        {
            if (this.Tipo == null || this.Tipo.Impresoras == null || this.Tipo.Impresoras.Count == 0)
                return null;

            // Intento obtener una impresora para esta susursal, para esta estación
            foreach (Lbl.Impresion.TipoImpresora Impr in Tipo.Impresoras) {
                if ((Impr.PuntoDeVenta == null || Impr.PuntoDeVenta.Numero == this.PV) && (Impr.Estacion != null && Impr.Estacion.Equals(System.Environment.MachineName, StringComparison.InvariantCultureIgnoreCase)
                        && Impr.Sucursal != null && Impr.Sucursal.Id == Lbl.Sys.Config.Empresa.SucursalActual.Id))
                    return Impr.Impresora;
            }

            // Intento obtener una impresora para esta estación, cualquier sucursal
            foreach (Lbl.Impresion.TipoImpresora Impr in Tipo.Impresoras) {
                if ((Impr.PuntoDeVenta == null || Impr.PuntoDeVenta.Numero == this.PV) && (Impr.Estacion != null && Impr.Estacion.Equals(System.Environment.MachineName, StringComparison.InvariantCultureIgnoreCase)
                        && Impr.Sucursal == null))
                    return Impr.Impresora;
            }

            // Intento obtener una impresora para esta sucursal, cualquier estacion, para este PV
            foreach (Lbl.Impresion.TipoImpresora Impr in Tipo.Impresoras) {
                if ((Impr.PuntoDeVenta == null || Impr.PuntoDeVenta.Numero == this.PV) && (Impr.Estacion == null
                        && Impr.Sucursal != null && Impr.Sucursal.Id == Lbl.Sys.Config.Empresa.SucursalActual.Id))
                    return Impr.Impresora;
            }

            // Intento obtener una impresora para esta sucursal, cualquier estacion
            foreach (Lbl.Impresion.TipoImpresora Impr in Tipo.Impresoras) {
                if ((Impr.PuntoDeVenta == null || Impr.PuntoDeVenta.Numero == this.PV) && (Impr.Estacion == null
                        && Impr.Sucursal != null && Impr.Sucursal.Id == Lbl.Sys.Config.Empresa.SucursalActual.Id))
                    return Impr.Impresora;
            }

            // Intento obtener una impresora para cualquier sucursal, cualquier estacion
            foreach (Lbl.Impresion.TipoImpresora Impr in Tipo.Impresoras) {
                if ((Impr.PuntoDeVenta == null || Impr.PuntoDeVenta.Numero == this.PV) && (Impr.Estacion == null && Impr.Sucursal == null))
                    return Impr.Impresora;
            }

            return null;
        }


        [Column(Name = "impresa")]
        public bool Impreso
        {
            get
            {
                return System.Convert.ToBoolean(Registro["impresa"]);
            }
            set
            {
                Registro["impresa"] = value ? 1 : 0;
            }
        }


        public static string FacturasDeUnRecibo(Lfx.Data.IConnection dataBase, int ReciboId)
        {
            System.Text.StringBuilder Facturas = new System.Text.StringBuilder();
            System.Data.DataTable TablaFacturas = dataBase.Select("SELECT id_comprob FROM recibos_comprob WHERE id_recibo=" + ReciboId.ToString());

            foreach (System.Data.DataRow Factura in TablaFacturas.Rows) {
                if (Facturas.Length == 0)
                    Facturas.Append(Lbl.Comprobantes.Comprobante.TipoYNumeroCompleto(dataBase, Lfx.Data.Connection.ConvertDBNullToZero(Factura["id_comprob"])));
                else
                    Facturas.Append(", " + Lbl.Comprobantes.Comprobante.TipoYNumeroCompleto(dataBase, Lfx.Data.Connection.ConvertDBNullToZero(Factura["id_comprob"])));
            }

            return Facturas.ToString();
        }

        /// <summary>
        /// Devuelve el tipo de comprobante según las tablas de AFIP.
        /// https://www.afip.gob.ar/fe/ayuda/tablas.asp
        /// </summary>
        public static int TipoCompAfip(string tipoComprob)
        {
            switch (tipoComprob) {
                case "T":
                    return 83;
                case "A":
                case "FA":
                    return 1;
                case "F":
                case "B":
                case "FB":
                    return 6;
                case "C":
                case "FC":
                    return 11;
                case "E":
                case "FE":
                    return 19;
                case "M":
                case "FM":
                    return 51;
                case "RC":
                case "RCP":
                    return 9;
                case "NCA":
                    return 3;
                case "NDA":
                    return 2;
                case "NC":
                case "NCB":
                    return 8;
                case "ND":
                case "NDB":
                    return 7;
                case "NCD":
                    return 13;
                case "NDD":
                    return 12;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Devuelve el nombre de un tipo de comprobante.
        /// Por ejemplo, para el parmetro "NCA", devuelve "Nota de Crédito A"
        /// </summary>
        public static string NombreTipo(string tipoComprob)
        {
            switch (tipoComprob) {
                case "F":
                    return "Factura";

                case "T":
                    return "Ticket";

                case "FA":
                    return Lbl.Comprobantes.Tipo.TodosPorLetra["FA"].Nombre;

                case "FB":
                    return Lbl.Comprobantes.Tipo.TodosPorLetra["FB"].Nombre;

                case "FC":
                    return "Factura C";

                case "FE":
                    return "Factura E";

                case "FM":
                    return "Factura M";

                case "R":
                    return "Remito";

                case "RC":
                    return "Recibo";

                case "RCP":
                    return "Recibo de pago";

                case "NC":
                    return "Nota de crédito";

                case "ND":
                    return "Nota de débito";

                case "NCA":
                    return "Nota de crédito A";

                case "NDA":
                    return "Nota de débito A";

                case "NCB":
                    return "Nota de crédito B";

                case "NDB":
                    return "Nota de débito B";

                case "NCD":
                    return "Nota de crédito C";

                case "NDD":
                    return "Nota de débito C";

                case "PS":
                    return "Presupuesto";

                case "OE":
                    return "Orden de Entrega";

                // Sección Pedidos
                case "NP":
                    return "Nota de Pedido";

                case "PD":
                    return "Pedido";

                case "NV":
                    return "Nota de Venta";

                default:
                    return tipoComprob;
            }
        }


        /// <summary>
        /// Devuelve el tipo y número de un comprobante (por ejemplo: B 0001-00000135).
        /// </summary>
        public static string TipoYNumeroCompleto(Lfx.Data.IConnection connection, int itemId)
        {
            Lfx.Data.Row Comp = Lfx.Workspace.Master.Tables["comprob"].FastRows[itemId];

            if (Comp == null)
                return "";
            else
                return (string)Comp["tipo_fac"].ToString() + " " + System.Convert.ToInt32(Comp["pv"]).ToString("0000") + "-" + System.Convert.ToInt32(Comp["numero"]).ToString("00000000");
        }

        /// <summary>
        /// Devuelve el número de un comprobante (por ejemplo: 0001-00000135).
        /// </summary>
        public static string NumeroCompleto(Lfx.Data.IConnection connection, int itemId)
        {
            Lfx.Data.Row Comp;
            if (connection.InTransaction) {
                Comp = connection.Row("comprob", "id_comprob", itemId);
            } else {
                Comp = Lfx.Workspace.Master.Tables["comprob"].FastRows[itemId];
            }

            if (Comp == null)
                return "";
            else
                return System.Convert.ToInt32(Comp["pv"]).ToString("0000") + "-" + System.Convert.ToInt32(Comp["numero"]).ToString("00000000");
        }

        public static string NombreCompletoRecibo(Lfx.Data.IConnection dataBase, int iId)
        {
            // Toma el Id del recibo y devuelve el tipo y número (por ejemplo: "Recibo #003" o "Comprobante de Pago #256")
            Lfx.Data.Row TmpRecibo = dataBase.Row("recibos", "id_recibo", iId);

            if (TmpRecibo == null)
                return "";
            else if (System.Convert.ToInt32(TmpRecibo["numero"]) > 0)
                return "Recibo Nº " + System.Convert.ToInt32(TmpRecibo["numero"]).ToString("00000000");
            else
                return "Recibo S/N";
        }


        [Column(Name = "id_comprob_orig")]
        [ManyToOne]
        public Lbl.Comprobantes.ComprobanteConArticulos ComprobanteOriginal
        {
            get
            {
                if (m_ComprobanteOriginal == null)
                    m_ComprobanteOriginal = this.GetFieldValue<ComprobanteConArticulos>("id_comprob_orig");
                return m_ComprobanteOriginal;
            }
            set
            {
                m_ComprobanteOriginal = value;
                this.SetFieldValue("id_comprob_orig", value);
            }
        }


        public virtual decimal Total
        {
            get
            {
                return 0;
            }
        }
    }
}