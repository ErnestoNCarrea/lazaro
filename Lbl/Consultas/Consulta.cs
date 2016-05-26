using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Consultas
{
        /// <summary>
        /// Representa una consulta parametrizable, que acepta parámetros y devuelve como resultado una tabla o conjunto de registros.
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Consulta")]
        [Lbl.Atributos.Datos(TablaDatos = "consultas", CampoId = "id_consulta")]
        [Lbl.Atributos.Presentacion()]
        public class Consulta : Lbl.ElementoDeDatos
        {
                private Lbl.ColeccionGenerica<Parametro> m_Parametros = null;

                //Heredar constructor
		public Consulta(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

		public Consulta(Lfx.Data.Connection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Consulta(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                public string Query
                {
                        get
                        {
                                return this.GetFieldValue<string>("query");
                        }
                        set
                        {
                                this.Registro["query"] = value;
                        }
                }


                public string QueryGroupBy
                {
                        get
                        {
                                return this.GetFieldValue<string>("query_groupby");
                        }
                        set
                        {
                                this.Registro["query_groupby"] = value;
                        }
                }


                public string QueryWhere
                {
                        get
                        {
                                return this.GetFieldValue<string>("query_where");
                        }
                        set
                        {
                                this.Registro["query_where"] = value;
                        }
                }

                public string QueryOrderBy
                {
                        get
                        {
                                return this.GetFieldValue<string>("query_orderby");
                        }
                        set
                        {
                                this.Registro["query_orderby"] = value;
                        }
                }


                public Lbl.ColeccionGenerica<Parametro> Parametros
                {
                        get
                        {
                                if (m_Parametros == null) {
                                        // Obtener los params de la base de datos
                                        qGen.Select SelParams = new qGen.Select("consultas_parametros");
                                        SelParams.Fields = "*";
                                        SelParams.WhereClause = new qGen.Where("id_consulta", this.Id);
                                        System.Data.DataTable TablaParams = this.Connection.Select(SelParams);

                                        m_Parametros = new Lbl.ColeccionGenerica<Parametro>(this.Connection, TablaParams);
                                }
                                return m_Parametros;
                        }
                        set
                        {
                                m_Parametros = value;
                        }
                }


                public Lazaro.Pres.Spreadsheet.Sheet Ejecutar(Dictionary<string, object> valores)
                {
                        string ConsultaSelect = this.ConstruirConsulta(valores);

                        // Remplazamos los {parametros} por los valores proporcionados por el usuario
                        if (valores != null) {
                                foreach (string ValorNombre in valores.Keys) {
                                        object ValorValor = valores[ValorNombre];
                                        string ValorFormateado;
                                        if (ValorValor == null) { 
                                                ValorFormateado = "NULL";
                                        } else if (ValorValor is decimal || ValorValor is double || ValorValor is Single) {
                                                ValorFormateado = ((decimal)(ValorValor)).ToString("#.00000000");
                                        } else if (ValorValor is DateTime) {
                                                ValorFormateado = ((DateTime)(ValorValor)).ToString(Lfx.Types.Formatting.DateTime.SqlDateTimeFormat);
                                        } else {
                                                ValorFormateado = ValorValor.ToString();
                                        }

                                        ConsultaSelect.Replace("{" + ValorNombre + "}", ValorFormateado);
                                }
                        }

                        DataTable Resultados = this.Connection.Select(ConsultaSelect);
                        Lazaro.Pres.Spreadsheet.Sheet Res = new Lazaro.Pres.Spreadsheet.Sheet();

                        // Creo los encabezados de columna
                        foreach(DataColumn Columna in Resultados.Columns) {
                                Lazaro.Pres.Spreadsheet.ColumnHeader NuevaColumna = new Lazaro.Pres.Spreadsheet.ColumnHeader(Columna.ColumnName);
                                switch(Columna.DataType.ToString()) {
                                        case "System.Int32":
                                        case "System.Int64":
                                        case "System.Decimal":
                                        case "System.Double":
                                        case "System.Single":
                                                NuevaColumna.TextAlignment = Lfx.Types.StringAlignment.Far;
                                                NuevaColumna.Width = 120;
                                                break;
                                        case "System.DateTime":
                                                NuevaColumna.TextAlignment = Lfx.Types.StringAlignment.Far;
                                                NuevaColumna.Width = 120;
                                                break;
                                        default:
                                                NuevaColumna.TextAlignment = Lfx.Types.StringAlignment.Near;
                                                NuevaColumna.Width = 320;
                                                break;

                                }
                                Res.ColumnHeaders.Add(NuevaColumna);
                        }

                        // Lleno la planilla con los registros
                        foreach (DataRow Reg in Resultados.Rows) {
                                Lazaro.Pres.Spreadsheet.Row Renglon = new Lazaro.Pres.Spreadsheet.Row();

                                foreach (DataColumn Columna in Resultados.Columns) {
                                        switch (Columna.DataType.ToString()) {
                                                case "System.Decimal":
                                                case "System.Double":
                                                case "System.Single":
                                                        Renglon.Cells.AddWithValue(System.Convert.ToDecimal(Reg[Columna.ColumnName]));
                                                        break;
                                                case "System.DateTime":
                                                        Renglon.Cells.AddWithValue(System.Convert.ToDateTime(Reg[Columna.ColumnName]));
                                                        break;
                                                default:
                                                        Renglon.Cells.AddWithValue(System.Convert.ToString(Reg[Columna.ColumnName]));
                                                        break;

                                        }
                                }

                                Res.Rows.Add(Renglon);
                        }

                        return Res;
                }


                protected string ConstruirConsulta(Dictionary<string, object> valores)
                {
                        string Res = this.Query;

                        if (string.IsNullOrEmpty(this.QueryWhere) == false) {
                                Res += " WHERE " + this.QueryWhere;
                        }

                        if (string.IsNullOrEmpty(this.QueryGroupBy) == false) {
                                Res += " GROUP BY " + this.QueryGroupBy;
                        }

                        if (string.IsNullOrEmpty(this.QueryOrderBy) == false) {
                                Res += " ORDER BY " + this.QueryOrderBy;
                        }

                        return Res;
                }

        }
}
