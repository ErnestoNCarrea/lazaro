using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Impresion
{
        /// <summary>
        /// Representa la relación entre un tipo de comprobante y una impresora.
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Tipo de Comprobante-Impresora")]
        [Lbl.Atributos.Datos(TablaDatos = "comprob_tipo_impresoras", CampoId = "id_tipo_impresora")]
        [Lbl.Atributos.Presentacion()]
        public class TipoImpresora : ElementoDeDatos
        {
                public Lbl.Comprobantes.Tipo Tipo = null;
                public Lbl.Impresion.Impresora Impresora = null;
                public Lbl.Entidades.Sucursal Sucursal = null;
                public Lbl.Comprobantes.PuntoDeVenta PuntoDeVenta = null;

                //Heredar constructor
		public TipoImpresora(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

		public TipoImpresora(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public TipoImpresora(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                public override void Crear()
                {
                        this.Sucursal = Lbl.Sys.Config.Empresa.SucursalActual;
                        base.Crear();
                }


                public override string Nombre
                {
                        get
                        {
                                string NombreStr = this.Tipo.ToString() + " en " + this.Impresora.ToString();
                                if (this.Sucursal != null)
                                        NombreStr += " para Suc. " + this.Sucursal.ToString();

                                if (this.Estacion != null)
                                        NombreStr += " en " + this.Estacion;

                                if (this.PuntoDeVenta != null)
                                        NombreStr += " en PV " + this.PuntoDeVenta.Numero.ToString();
                                return NombreStr;
                        }
                        set
                        {
                                base.Nombre = value;
                        }
                }

                public override Lfx.Types.OperationResult Guardar()
                {
                        qGen.IStatement Comando;
                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.TablaDatos);
                                Comando.ColumnValues.AddWithValue("fecha", qGen.SqlFunctions.Now);
                        } else {
                                Comando = new qGen.Update(this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        Comando.ColumnValues.AddWithValue("nombre", this.Nombre);
                        Comando.ColumnValues.AddWithValue("estacion", this.Estacion);
                        Comando.ColumnValues.AddWithValue("id_impresora", this.Tipo.Id);
                        Comando.ColumnValues.AddWithValue("id_tipo", this.Impresora.Id);
                        if (this.Sucursal == null)
                                Comando.ColumnValues.AddWithValue("id_sucursal", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_sucursal", this.Sucursal.Id);
                        if (this.PuntoDeVenta == null)
                                Comando.ColumnValues.AddWithValue("id_pv", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_pv", this.PuntoDeVenta.Id);

                        this.AgregarTags(Comando);

                        Connection.Execute(Comando);

                        return base.Guardar();
                }

                public override void OnLoad()
                {
                        if (this.GetFieldValue<int>("id_tipo") == 0)
                                this.Tipo = null;
                        else
                                this.Tipo = new Lbl.Comprobantes.Tipo(this.Connection, this.GetFieldValue<int>("id_tipo"));

                        if (this.GetFieldValue<int>("id_impresora") == 0)
                                this.Impresora = null;
                        else
                                this.Impresora = new Impresion.Impresora(this.Connection, this.GetFieldValue<int>("id_impresora"));

                        if (this.GetFieldValue<int>("id_pv") == 0)
                                this.PuntoDeVenta = null;
                        else
                                this.PuntoDeVenta = new Comprobantes.PuntoDeVenta(this.Connection, this.GetFieldValue<int>("id_pv"));

                        if (this.GetFieldValue<int>("id_sucursal") == 0)
                                this.Sucursal = null;
                        else
                                this.Sucursal = new Entidades.Sucursal(this.Connection, this.GetFieldValue<int>("id_sucursal"));

                        base.OnLoad();
                }

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
        }
}
