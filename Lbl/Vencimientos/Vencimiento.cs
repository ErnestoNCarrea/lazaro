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
                public Vencimiento(Lfx.Data.Connection dataBase)
                        : base(dataBase) {}

                public Vencimiento(Lfx.Data.Connection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Vencimiento(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

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

                public NullableDateTime FechaInicio
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

                public NullableDateTime FechaProxima
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

                public NullableDateTime FechaFin
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
                        qGen.TableCommand Comando;

                        if (this.Existe == false) {
                                Comando = new qGen.Insert(this.Connection, this.TablaDatos);
                                Comando.Fields.AddWithValue("fecha", qGen.SqlFunctions.Now);
                        } else {
                                Comando = new qGen.Update(this.Connection, this.TablaDatos);
                                Comando.WhereClause = new qGen.Where(this.CampoId, this.Id);
                        }

                        Comando.Fields.AddWithValue("nombre", this.Nombre);
                        Comando.Fields.AddWithValue("fecha_inicio", this.FechaInicio);
                        Comando.Fields.AddWithValue("fecha_proxima", this.FechaProxima);
                        Comando.Fields.AddWithValue("fecha_fin", this.FechaFin);
                        switch(this.Frecuencia) {
                                case Frecuencias.Unica:
                                        Comando.Fields.AddWithValue("frecuencia", "unica");
                                        break;
                                case Frecuencias.Diaria:
                                        Comando.Fields.AddWithValue("frecuencia", "diaria");
                                        break;
                                case Frecuencias.Semanal:
                                        Comando.Fields.AddWithValue("frecuencia", "semanal");
                                        break;
                                case Frecuencias.Mensual:
                                        Comando.Fields.AddWithValue("frecuencia", "mensual");
                                        break;
                                case Frecuencias.Bimestral:
                                        Comando.Fields.AddWithValue("frecuencia", "bimestral");
                                        break;
                                case Frecuencias.Trimestral:
                                        Comando.Fields.AddWithValue("frecuencia", "trimestral");
                                        break;
                                case Frecuencias.Cuatrimestral:
                                        Comando.Fields.AddWithValue("frecuencia", "cuatrimestral");
                                        break;
                                case Frecuencias.Semestral:
                                        Comando.Fields.AddWithValue("frecuencia", "semestral");
                                        break;
                                case Frecuencias.Anual:
                                        Comando.Fields.AddWithValue("frecuencia", "anual");
                                        break;
                        }
                        Comando.Fields.AddWithValue("importe", this.Importe);
                        Comando.Fields.AddWithValue("repetir", this.Repetir);
                        Comando.Fields.AddWithValue("ocurrencia", this.Ocurrencia);
                        Comando.Fields.AddWithValue("obs", this.Obs);
                        Comando.Fields.AddWithValue("estado", this.Estado);

                        if (this.Concepto == null)
                                Comando.Fields.AddWithValue("id_concepto", null);
                        else
                                Comando.Fields.AddWithValue("id_concepto", this.Concepto.Id);

                        this.AgregarTags(Comando);

                        this.Connection.Execute(Comando);

                        return new Lfx.Types.SuccessOperationResult();
                }
        }
}
