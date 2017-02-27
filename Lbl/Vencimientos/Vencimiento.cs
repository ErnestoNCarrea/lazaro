using Lazaro.Orm;
using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Vencimientos
{
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Vencimiento", Grupo = "Cajas")]
        [Lbl.Atributos.Datos(TablaDatos = "vencimientos", CampoId = "id_vencimiento")]
        [Lbl.Atributos.Presentacion()]
        public class Vencimiento : ElementoDeDatos
        {
                public Cajas.Concepto Concepto;

                //Heredar constructor
                public Vencimiento(Lfx.Data.IConnection dataBase)
                        : base(dataBase) {}

                public Vencimiento(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Vencimiento(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
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
                                this.Registro["obs"] = value.Trim(new char[] { '\n', '\r', ' ' });
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


                public override void Crear()
                {
                        base.Crear();
                        this.Estado = 1;
                        this.FechaInicio = System.DateTime.Now;
                        this.Frecuencia = Frecuencias.Diaria;
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

                public int Repetir
                {
                        get
                        {
                                return this.GetFieldValue<int>("repetir");
                        }
                        set
                        {
                                this.Registro["repetir"] = value;
                        }
                }

                public int Ocurrencia
                {
                        get
                        {
                                return this.GetFieldValue<int>("ocurrencia");
                        }
                        set
                        {
                                this.Registro["ocurrencia"] = value;
                        }
                }

                public Frecuencias Frecuencia
                {
                        get
                        {
                                if (this.GetFieldValue<string>("frecuencia") == null)
                                        return Frecuencias.Unica;

                                switch (this.GetFieldValue<string>("frecuencia").ToUpperInvariant()) {
                                        case "UNICA":
                                                return Frecuencias.Unica;
                                        case "DIARIA":
                                                return Frecuencias.Diaria;
                                        case "SEMANAL":
                                                return Frecuencias.Semanal;
                                        case "MENSUAL":
                                                return Frecuencias.Mensual;
                                        case "BIMESTRAL":
                                                return Frecuencias.Bimestral;
                                        case "TRIMESTRAL":
                                                return Frecuencias.Trimestral;
                                        case "CUATRIMESTRAL":
                                                return Frecuencias.Cuatrimestral;
                                        case "SEMESTRAL":
                                                return Frecuencias.Semestral;
                                        case "ANUAL":
                                                return Frecuencias.Anual;
                                        default:
                                                return Frecuencias.Unica;
                                }
                        }
                        set
                        {
                                this.Registro["frecuencia"] = value.ToString().ToLowerInvariant();
                        }
                }

                public DbDateTime FechaInicio
                {
                        get
                        {
                                return this.FieldDateTime("fecha_inicio");
                        }
                        set
                        {
                                this.Registro["fecha_inicio"] = value;
                        }
                }

                public DbDateTime FechaProxima
                {
                        get
                        {
                                return this.FieldDateTime("fecha_proxima");
                        }
                        set
                        {
                                this.Registro["fecha_proxima"] = value;
                        }
                }

                public DbDateTime FechaFin
                {
                        get
                        {
                                return this.FieldDateTime("fecha_fin");
                        }
                        set
                        {
                                this.Registro["fecha_fin"] = value;
                        }
                }

                public override void OnLoad()
                {
                        if (this.Registro != null) {
                                if (Lfx.Data.Connection.ConvertDBNullToZero(Registro["id_concepto"]) > 0)
                                        this.Concepto = new Cajas.Concepto(this.Connection, System.Convert.ToInt32(Registro["id_concepto"]));
                                else
                                        this.Concepto = null;
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

                        Comando.ColumnValues.AddWithValue("nombre", this.Nombre);
                        Comando.ColumnValues.AddWithValue("fecha_inicio", this.FechaInicio);
                        Comando.ColumnValues.AddWithValue("fecha_proxima", this.FechaProxima);
                        Comando.ColumnValues.AddWithValue("fecha_fin", this.FechaFin);
                        switch(this.Frecuencia) {
                                case Frecuencias.Unica:
                                        Comando.ColumnValues.AddWithValue("frecuencia", "unica");
                                        break;
                                case Frecuencias.Diaria:
                                        Comando.ColumnValues.AddWithValue("frecuencia", "diaria");
                                        break;
                                case Frecuencias.Semanal:
                                        Comando.ColumnValues.AddWithValue("frecuencia", "semanal");
                                        break;
                                case Frecuencias.Mensual:
                                        Comando.ColumnValues.AddWithValue("frecuencia", "mensual");
                                        break;
                                case Frecuencias.Bimestral:
                                        Comando.ColumnValues.AddWithValue("frecuencia", "bimestral");
                                        break;
                                case Frecuencias.Trimestral:
                                        Comando.ColumnValues.AddWithValue("frecuencia", "trimestral");
                                        break;
                                case Frecuencias.Cuatrimestral:
                                        Comando.ColumnValues.AddWithValue("frecuencia", "cuatrimestral");
                                        break;
                                case Frecuencias.Semestral:
                                        Comando.ColumnValues.AddWithValue("frecuencia", "semestral");
                                        break;
                                case Frecuencias.Anual:
                                        Comando.ColumnValues.AddWithValue("frecuencia", "anual");
                                        break;
                        }
                        Comando.ColumnValues.AddWithValue("importe", this.Importe);
                        Comando.ColumnValues.AddWithValue("repetir", this.Repetir);
                        Comando.ColumnValues.AddWithValue("ocurrencia", this.Ocurrencia);
                        Comando.ColumnValues.AddWithValue("obs", this.Obs);
                        Comando.ColumnValues.AddWithValue("estado", this.Estado);

                        if (this.Concepto == null)
                                Comando.ColumnValues.AddWithValue("id_concepto", null);
                        else
                                Comando.ColumnValues.AddWithValue("id_concepto", this.Concepto.Id);

                        this.AgregarTags(Comando);

                        this.Connection.ExecuteNonQuery(Comando);

                        return new Lfx.Types.SuccessOperationResult();
                }
        }
}
