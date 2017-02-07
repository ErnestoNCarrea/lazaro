using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
        public enum TipoPv
        {
                Inactivo = 0,
                Talonario = 1,
                ControladorFiscal = 2,
                ElectronicoAfip = 10
        }

        [Lbl.Atributos.Nomenclatura(NombreSingular = "Punto de Venta")]
        [Lbl.Atributos.Datos(TablaDatos = "pvs", CampoId = "id_pv", CampoNombre = "numero")]
        [Lbl.Atributos.Presentacion()]
        public class PuntoDeVenta : ElementoDeDatos
        {
                public Lbl.Entidades.Sucursal Sucursal;
                public Lbl.Impresion.Impresora Impresora;

                public PuntoDeVenta(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public PuntoDeVenta(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public PuntoDeVenta(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                public override void Crear()
                {
                        base.Crear();
                        this.Sucursal = Lbl.Sys.Config.Empresa.SucursalActual;
                        this.Numero = this.Connection.FieldInt("SELECT MAX(id_pv)+1 FROM pvs");
                }

                public override void OnLoad()
                {
                        base.OnLoad();

                        if (this.GetFieldValue<int>("id_sucursal") != 0)
                                this.Sucursal = new Entidades.Sucursal(this.Connection, this.GetFieldValue<int>("id_sucursal"));
                        else
                                this.Sucursal = null;

                        if (this.GetFieldValue<int>("id_impresora") != 0)
                                this.Impresora = new Lbl.Impresion.Impresora(this.Connection, this.GetFieldValue<int>("id_impresora"));
                        else
                                this.Impresora = null;
                }

                /// <summary>
                /// Indica el tipo de punto de venta.
                /// 
                /// Puede ser:
                ///  * Talonario: talonario o resma de facturas de papel preimpreso.
                ///  * ControladorFiscal: controlador fiscal AFIP conectado por puerto serie.
                ///  * ElectronicoAfip: factura electrónica de AFIP.
                /// </summary>
                public TipoPv Tipo
                {
                        get
                        {
                                return (TipoPv)(this.GetFieldValue<int>("tipo"));
                        }
                        set
                        {
                                this.Registro["tipo"] = (int)value;
                        }
                }


                /// <summary>
                /// El modelo de controlador fiscal.
                /// Sólo válido si Tipo == ControladorFiscal.
                /// </summary>
                public Lbl.Impresion.ModelosFiscales FiscalModeloImpresora
                {
                        get
                        {
                                return (Lbl.Impresion.ModelosFiscales)(this.GetFieldValue<int>("modelo"));
                        }
                        set
                        {
                                this.Registro["modelo"] = (int)value;
                        }
                }


                /// <summary>
                /// El número de puerto serie (1 para COM1, 2 para COM2, etc.).
                /// Sólo válido si Tipo == ControladorFiscal.
                /// </summary>
                public int FiscalPuerto
                {
                        get
                        {
                                return this.GetFieldValue<int>("puerto");
                        }
                        set
                        {
                                this.Registro["puerto"] = value;
                        }
                }


                /// <summary>
                /// La velocidad del puerto serie en bps.
                /// Sólo válido si Tipo == ControladorFiscal.
                /// </summary>
                public int FiscalBps
                {
                        get
                        {
                                return this.GetFieldValue<int>("bps");
                        }
                        set
                        {
                                this.Registro["bps"] = value;
                        }
                }


                /// <summary>
                /// La variante de diseño.
                /// Especialmente útil si Tipo == ElectronicoAfip.
                /// </summary>
                public int Variante
                {
                        get
                        {
                                return this.GetFieldValue<int>("variante");
                        }
                        set
                        {
                                this.Registro["variante"] = value;
                        }
                }


                public override string Nombre
                {
                        get
                        {
                                if (this.Prefijo == 0)
                                        return this.Numero.ToString("0000");
                                else
                                        return this.Prefijo.ToString("000") + "-" + this.Numero.ToString("000");
                        }
                }


                /// <summary>
                /// El número de punto de venta.
                /// </summary>
                public int Numero
                {
                        get
                        {
                                return this.GetFieldValue<int>("numero");
                        }
                        set
                        {
                                this.Registro["numero"] = value;
                        }
                }


                /// <summary>
                /// El prefijo del número de punto venta.
                /// En especial, válido en Paraguay, donde los puntos de venta tienen el formato XXXX-YYYY.
                /// </summary>
                public int Prefijo
                {
                        get
                        {
                                return this.GetFieldValue<int>("prefijo");
                        }
                        set
                        {
                                this.Registro["prefijo"] = value;
                        }
                }


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


                /// <summary>
                /// La estación (equipo o PC) a la cual está asociado este punto de venta.
                /// Especialmente útil cuando Tipo == ControladorFiscal.
                /// </summary>
                public string Estacion
                {
                        get
                        {
                                return this.GetFieldValue<string>("estacion");
                        }
                        set
                        {
                                this.Registro["estacion"] = value;
                        }
                }

                public bool CuentaIva
                {
                        get
                        {
                                return this.GetFieldValue<int>("cuenta_iva") != 0;
                        }
                        set
                        {
                                this.Registro["cuenta_iva"] = value;
                        }
                }


                public bool CuentaIngresosBrutos
                {
                        get
                        {
                                return this.GetFieldValue<int>("cuenta_iibb") != 0;
                        }
                        set
                        {
                                this.Registro["cuenta_iibb"] = value;
                        }
                }


                public bool UsaTalonario
                {
                        get
                        {
                                return this.GetFieldValue<int>("detalonario") != 0;
                        }
                        set
                        {
                                this.Registro["detalonario"] = value ? 1 : 0;
                        }
                }


                /// <summary>
                /// Indica si este punto de venta utiliza carga manual de comprobantes.
                /// 
                /// Por ejemplo, si utiliza comprobantes prenumerados que se cargan uno a uno en la impresora.
                /// Si es True, Lázaro solicitará confirmación antes imprimir cada comprobante en este PV.
                /// </summary>
                public bool CargaManual
                {
                        get
                        {
                                return this.GetFieldValue<int>("carga") != 0;
                        }
                        set
                        {
                                this.Registro["carga"] = value ? 1 : 0;
                        }
                }


                public override Lfx.Types.OperationResult Guardar()
                {
                        qGen.IStatement Comando;
                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.TablaDatos);
                                Comando.ColumnValues.AddWithValue("fecha", new qGen.SqlExpression("NOW()"));
                        } else {
                                Comando = new qGen.Update(this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        Comando.ColumnValues.AddWithValue("prefijo", this.Prefijo);
                        Comando.ColumnValues.AddWithValue("numero", this.Numero);
                        Comando.ColumnValues.AddWithValue("nombre", this.Nombre);
                        
                        if (this.Sucursal == null)
                                Comando.ColumnValues.AddWithValue("id_sucursal", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_sucursal", this.Sucursal.Id);
                        
                        if (this.Impresora == null)
                                Comando.ColumnValues.AddWithValue("id_impresora", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_impresora", this.Impresora.Id);
                        Comando.ColumnValues.AddWithValue("tipo", (int)(this.Tipo));
                        Comando.ColumnValues.AddWithValue("tipo_fac", this.TipoFac);
                        Comando.ColumnValues.AddWithValue("detalonario", this.UsaTalonario ? 1 : 0);
                        Comando.ColumnValues.AddWithValue("estacion", this.Estacion);
                        Comando.ColumnValues.AddWithValue("carga", this.CargaManual ? 1 : 0);
                        Comando.ColumnValues.AddWithValue("modelo", (int)(this.FiscalModeloImpresora));
                        Comando.ColumnValues.AddWithValue("puerto", this.FiscalPuerto);
                        Comando.ColumnValues.AddWithValue("bps", this.FiscalBps);
                        Comando.ColumnValues.AddWithValue("variante", (int)this.Variante);

                        this.AgregarTags(Comando);

                        Connection.Execute(Comando);

                        return base.Guardar();
                }

                private static Dictionary<int, PuntoDeVenta> m_TodosPorNumero = null;
                /// <summary>
                /// Contiene una colección de todos los puntos de venta existentes, indizados por número.
                /// </summary>
                public static Dictionary<int, PuntoDeVenta> TodosPorNumero
                {
                        get
                        {

                                if (m_TodosPorNumero == null || m_TodosPorNumero.Count == 0) {
                                        m_TodosPorNumero = new Dictionary<int, PuntoDeVenta>();
                                        lock (m_TodosPorNumero) {
                                                System.Data.DataTable TablaPvs = Lfx.Workspace.Master.MasterConnection.Select("SELECT * FROM pvs WHERE numero>0");
                                                foreach (System.Data.DataRow RegPv in TablaPvs.Rows) {
                                                        m_TodosPorNumero.Add(System.Convert.ToInt32(RegPv["numero"]), new Lbl.Comprobantes.PuntoDeVenta(Lfx.Workspace.Master.MasterConnection, (Lfx.Data.Row)RegPv));
                                                }
                                        }
                                }

                                return m_TodosPorNumero;
                        }
                }
        }
}