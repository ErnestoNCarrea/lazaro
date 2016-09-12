using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Comprobantes
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Tipo de Comprobante", Grupo = "Comprobantes")]
        [Lbl.Atributos.Datos(TablaDatos = "documentos_tipos", CampoId = "id_tipo")]
        [Lbl.Atributos.Presentacion()]
        public class Tipo : ElementoDeDatos
        {
                private Articulos.Situacion m_SituacionOrigen, m_SituacionDestino;
                public ColeccionGenerica<Lbl.Impresion.TipoImpresora> m_Impresoras = null;

                //Heredar constructor
                public Tipo(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

                public Tipo(Lfx.Data.Connection dataBase, int itemId)
                        : base(dataBase, itemId) { }

                public Tipo(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

                public Tipo(Lfx.Data.Connection dataBase, string nomenclatura)
                        : base(dataBase)
                {
                        Lfx.Data.Row Rw = this.Connection.FirstRowFromSelect("SELECT * FROM documentos_tipos WHERE letra='" + nomenclatura + "'");
                        this.FromRow(Rw);
                }

                public override void Crear()
                {
                        m_Impresoras = new ColeccionGenerica<Lbl.Impresion.TipoImpresora>(this.Connection);

                        base.Crear();
                }


                public Lbl.Articulos.Situacion SituacionOrigen
                {
                        get
                        {
                                if (m_SituacionOrigen == null && this.GetFieldValue<int>("situacionorigen") > 0)
                                        m_SituacionOrigen = new Lbl.Articulos.Situacion(this.Connection, System.Convert.ToInt32(Registro["situacionorigen"]));
                                return m_SituacionOrigen;
                        }
                        set
                        {
                                m_SituacionOrigen = value;
                        }
                }

                public Lbl.Articulos.Situacion SituacionDestino
                {
                        get
                        {
                                if (m_SituacionDestino == null && this.GetFieldValue<int>("situaciondestino") > 0)
                                        m_SituacionDestino = new Lbl.Articulos.Situacion(this.Connection, System.Convert.ToInt32(Registro["situaciondestino"]));
                                return m_SituacionDestino;
                        }
                        set
                        {
                                m_SituacionDestino = value;
                        }
                }

                public Impresion.CargasPapel CargaPapel
                {
                        get
                        {
                                return (Impresion.CargasPapel)this.GetFieldValue<int>("cargapapel");
                        }
                        set
                        {
                                this.Registro["cargapapel"] = (int)value;
                        }
                }

                public bool NumerarAlImprimir
                {
                        get
                        {
                                return this.GetFieldValue<int>("numerar_imprimir") != 0;
                        }
                        set
                        {
                                this.Registro["numerar_imprimir"] = value ? 1 : 0;
                        }
                }

                public bool NumerarAlGuardar
                {
                        get
                        {
                                return System.Convert.ToBoolean(Registro["numerar_guardar"]);
                        }
                        set
                        {
                                Registro["numerar_guardar"] = value ? 1 : 0;
                        }
                }


                public bool ImprimirAlGuardar
                {
                        get
                        {
                                return System.Convert.ToBoolean(Registro["imprimir_guardar"]);
                        }
                        set
                        {
                                Registro["imprimir_guardar"] = value ? 1 : 0;
                        }
                }

                public decimal MueveExistencias
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("mueve_stock");
                        }
                        set
                        {
                                this.Registro["mueve_stock"] = value;
                        }
                }


                /// <summary>
                /// Indica si permite hacer comprobantes de venta de este tipo.
                /// </summary>
                public bool PermiteVenta
                {
                        get
                        {
                                return System.Convert.ToBoolean(Registro["venta"]);
                        }
                        set
                        {
                                Registro["venta"] = value ? 1 : 0;
                        }
                }


                /// <summary>
                /// Indica si permite hacer comprobantes de compra de este tipo.
                /// </summary>
                public bool PermiteCompra
                {
                        get
                        {
                                return System.Convert.ToBoolean(Registro["compra"]);
                        }
                        set
                        {
                                Registro["compra"] = value ? 1 : 0;
                        }
                }


                public decimal DireccionCtaCte
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("direc_ctacte");
                        }
                        set
                        {
                                this.Registro["direc_ctacte"] = value;
                        }
                }


                public ColeccionGenerica<Lbl.Impresion.TipoImpresora> Impresoras
                {
                        get
                        {
                                if (m_Impresoras == null && this.Existe) {
                                        System.Data.DataTable Impr = this.Connection.Select("SELECT * FROM comprob_tipo_impresoras WHERE id_tipo=" + this.Id);
                                        m_Impresoras = new ColeccionGenerica<Lbl.Impresion.TipoImpresora>(this.Connection, Impr);
                                }
                                return m_Impresoras;
                        }
                }

                /// <summary>
                /// Devuelve sólamente el tipo (F, NC, ND, sin letra A, B, etc.).
                /// </summary>
                public string TipoBase
                {
                        get
                        {
                                if (this.EsFactura)
                                        return "F";
                                else if (this.EsNotaCredito)
                                        return "NC";
                                else if (this.EsNotaDebito)
                                        return "ND";
                                else
                                        return this.Nomenclatura;
                        }
                }


                /// <summary>
                /// Devuelve el tipo nombre largo del tipo de comprobante.
                /// </summary>
                public string NombreLargo
                {
                        get
                        {
                                return this.GetFieldValue<string>("nombrelargo");
                        }
                        set
                        {
                                this.SetFieldValue("nombrelargo", value);
                        }
                }



                /// <summary>
                /// Devuelve el tipo Lbl.
                /// </summary>
                public string NombreTipoLbl
                {
                        get
                        {
                                return this.GetFieldValue<string>("tipo");
                        }
                }


                public Type ObtenerTipoLbl()
                {
                        return Lbl.Instanciador.InferirTipo(this.NombreTipoLbl);
                }


                /// <summary>
                /// Devuelve True si el comprobante discrimina IVA el los precios de los detalles (por ejemplo en Argentina factura A).
                /// </summary>
                public bool DiscriminaIva
                {
                        get
                        {
                                return this.Letra == "A";
                        }
                }


                /// <summary>
                /// La nomenclatura del tipo de comprobante (A, B, NCA, NDE, etc.). Está formada por el TipoBase y la Letra.
                /// </summary>
                public string Nomenclatura
                {
                        get
                        {
                                return this.GetFieldValue<string>("letra");
                        }
                        set
                        {
                                this.Registro["letra"] = value;
                        }
                }


                /// <summary>
                /// Devuelve sólamente la letra (A, B, C, E o M, independientemente de que sea NCA, NDE, etc.)
                /// </summary>
                public string Letra
                {
                        get
                        {
                                return this.GetFieldValue<string>("letrasola");
                        }
                        set
                        {
                                this.Registro["letrasola"] = value;
                        }
                }


                /// <summary>
                /// Devuelve la letra del comprobante, o si no tiene subdivisión por letras devuelve la nomenclatura.
                /// </summary>
                public string LetraONomenclatura
                {
                        get
                        {
                                if (string.IsNullOrEmpty(this.Letra))
                                        return this.Nomenclatura;
                                else
                                        return this.Letra;

                        }
                }


                /// <summary>
                /// Devuleve Verdadero si este tipo de comprobante es una Nota de Crédito.
                /// </summary>
                public bool EsNotaCredito
                {
                        get
                        {
                                return this.Nomenclatura.Length > 2 && this.Nomenclatura.Substring(0, 2).ToUpperInvariant() == "NC";
                        }
                }


                /// <summary>
                /// Devuleve Verdadero si este tipo de comprobante es una Nota de Débito.
                /// </summary>
                public bool EsNotaDebito
                {
                        get
                        {
                                return this.Nomenclatura.Length > 2 && this.Nomenclatura.Substring(0, 2).ToUpperInvariant() == "ND";
                        }
                }


                /// <summary>
                /// Devuleve Verdadero si este tipo de comprobante es un ticket.
                /// </summary>
                public bool EsTicket
                {
                        get
                        {
                                switch (this.Nomenclatura.ToUpperInvariant()) {
                                        case "T":
                                                return true;
                                        default:
                                                return false;
                                }
                        }
                }


                /// <summary>
                /// Devuleve Verdadero si este tipo de comprobante es una factura.
                /// </summary>
                public bool EsFactura
                {
                        get
                        {
                                switch (this.Nomenclatura.ToUpperInvariant()) {
                                        case "A":
                                        case "B":
                                        case "C":
                                        case "E":
                                        case "M":
                                        case "FA":
                                        case "FB":
                                        case "FC":
                                        case "FE":
                                        case "FM":
                                        case "FP":
                                                return true;
                                        default:
                                                return false;
                                }
                        }
                }


                public bool EsFacturaOTicket
                {
                        get
                        {
                                return this.EsFactura || this.EsTicket;
                        }
                }


                public bool EsFacturaNCoND
                {
                        get
                        {
                                return this.EsFacturaOTicket || this.EsNotaCredito || this.EsNotaDebito;
                        }
                }


                public bool EsRemito
                {
                        get
                        {
                                return this.Nomenclatura.ToUpperInvariant() == "R";
                        }
                }


                public bool EsPedido
                {
                        get
                        {
                                return this.Nomenclatura.ToUpperInvariant() == "PD";
                        }
                }


                public bool EsPresupuesto
                {
                        get
                        {
                                return this.Nomenclatura.ToUpperInvariant() == "PS";
                        }
                }


                public bool PermiteImprimirVariasVeces
                {
                        get
                        {
                                return this.GetFieldValue<int>("imprimir_repetir") != 0;
                        }
                        set
                        {
                                this.Registro["imprimir_repetir"] = value ? 1 : 0;
                        }
                }


                public bool PermiteModificarImpresos
                {
                        get
                        {
                                return this.GetFieldValue<int>("imprimir_modificar") != 0;
                        }
                        set
                        {
                                this.Registro["imprimir_modificar"] = value ? 1 : 0;
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

                        Comando.Fields.AddWithValue("letra", this.Nomenclatura);
                        Comando.Fields.AddWithValue("letrasola", this.Letra == null ? "" : this.Letra);
                        Comando.Fields.AddWithValue("nombre", this.Nombre);
                        Comando.Fields.AddWithValue("nombrelargo", this.NombreLargo);
                        Comando.Fields.AddWithValue("mueve_stock", this.MueveExistencias);
                        Comando.Fields.AddWithValue("direc_ctacte", this.DireccionCtaCte);
                        Comando.Fields.AddWithValue("compra", this.PermiteCompra ? 1 : 0);
                        Comando.Fields.AddWithValue("venta", this.PermiteVenta ? 1 : 0);
                        Comando.Fields.AddWithValue("numerar_guardar", this.NumerarAlGuardar ? 1 : 0);
                        Comando.Fields.AddWithValue("numerar_imprimir", this.NumerarAlImprimir ? 1 : 0);
                        Comando.Fields.AddWithValue("imprimir_guardar", this.ImprimirAlGuardar ? 1 : 0);
                        Comando.Fields.AddWithValue("imprimir_repetir", this.PermiteImprimirVariasVeces ? 1 : 0);
                        Comando.Fields.AddWithValue("imprimir_modificar", this.PermiteModificarImpresos ? 1 : 0);
                        Comando.Fields.AddWithValue("cargapapel", (int)(this.CargaPapel));

                        if (this.SituacionOrigen == null)
                                Comando.Fields.AddWithValue("situacionorigen", null);
                        else
                                Comando.Fields.AddWithValue("situacionorigen", this.SituacionOrigen.Id);

                        if (this.SituacionDestino == null)
                                Comando.Fields.AddWithValue("situaciondestino", null);
                        else
                                Comando.Fields.AddWithValue("situaciondestino", this.SituacionDestino.Id);

                        this.AgregarTags(Comando);

                        this.Connection.Execute(Comando);

                        if (this.Impresoras != null && this.Impresoras.HayCambios) {
                                // Eliminar todas las impresoras asociadas con el tipo
                                qGen.Delete EliminarImpresorasActuales = new qGen.Delete("comprob_tipo_impresoras");
                                EliminarImpresorasActuales.WhereClause = new qGen.Where("id_tipo", this.Id);
                                this.Connection.Execute(EliminarImpresorasActuales);

                                // Guardar la nueva lista de permisos del usuario
                                foreach (Lbl.Impresion.TipoImpresora Impr in this.Impresoras) {
                                        qGen.Insert InsertarImpresora = new qGen.Insert("comprob_tipo_impresoras");
                                        InsertarImpresora.Fields.AddWithValue("id_tipo", this.Id);
                                        InsertarImpresora.Fields.AddWithValue("id_impresora", Impr.Impresora.Id);
                                        if (Impr.Sucursal == null)
                                                InsertarImpresora.Fields.AddWithValue("id_sucursal", null);
                                        else
                                                InsertarImpresora.Fields.AddWithValue("id_sucursal", Impr.Sucursal.Id);
                                        if (Impr.PuntoDeVenta == null)
                                                InsertarImpresora.Fields.AddWithValue("id_pv", null);
                                        else
                                                InsertarImpresora.Fields.AddWithValue("id_pv", Impr.PuntoDeVenta.Id);
                                        InsertarImpresora.Fields.AddWithValue("estacion", Impr.Estacion);
                                        InsertarImpresora.Fields.AddWithValue("nombre", Impr.Nombre);

                                        this.Connection.Execute(InsertarImpresora);
                                }
                        }

                        return base.Guardar();
                }

                private static Dictionary<string, Tipo> m_TodosPorLetra = null;
                public static Dictionary<string, Tipo> TodosPorLetra
                {
                        get
                        {
                                if (m_TodosPorLetra == null || m_TodosPorLetra.Count == 0) {
                                        m_TodosPorLetra = new Dictionary<string, Tipo>();
                                        System.Data.DataTable TablaTipos = Lfx.Workspace.Master.MasterConnection.Select("SELECT * FROM documentos_tipos WHERE estado=1");
                                        foreach (System.Data.DataRow RegTipo in TablaTipos.Rows) {
                                                m_TodosPorLetra.Add(RegTipo["letra"].ToString(), new Lbl.Comprobantes.Tipo(Lfx.Workspace.Master.MasterConnection, (Lfx.Data.Row)RegTipo));
                                        }
                                }
                                return m_TodosPorLetra;
                        }
                }


                public static string[] ToSetData(IList<Tipo> lista)
                {
                        if(lista == null || lista.Count == 0)
                                return new string[0];

                        string[] Res = new string[lista.Count];
                        int i = 0;
                        foreach (Tipo Tp in lista)
                                Res[i++] = Tp.Nombre + "|" + Tp.Nomenclatura;

                        return Res;
                }
        }
}