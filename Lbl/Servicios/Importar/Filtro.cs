using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Servicios.Importar
{
        /// <summary>
        /// Describe un filtro de importación.
        /// </summary>
        public class Filtro
        {
                protected System.Data.IDbConnection ConexionExterna { get; set; }
                protected Lfx.Types.OperationProgress Progreso;
                protected Lfx.Data.IConnection Connection { get; set; }
                protected IDictionary<string, IDictionary<string, object>> CacheConversiones = new Dictionary<string, IDictionary<string, object>>();

                public Opciones Opciones { get; set; }
                public ColeccionMapaDeTablas MapaDeTablas;
                public string Nombre = "Filtro de importación genérico";
                public IList<Reemplazo> Reemplazos = new List<Reemplazo>();

                public Filtro(Lfx.Data.IConnection dataBase, Opciones opciones)
                {
                        this.Connection = dataBase;
                        this.Opciones = opciones;
                }


                public void Importar()
                {
                        this.Progreso = new Lfx.Types.OperationProgress("Importando datos de " + this.Nombre, "Se están importando los datos del filtro " + this.Nombre);
                        this.Progreso.Modal = true;
                        this.Progreso.Begin();

                        this.PrepararTablasLazaro();
                        this.PreImportar();
                        this.ImportarTodo();
                        this.PostImportar();

                        this.Progreso.End();
                }


                public virtual void PreImportar()
                {
                }


                public virtual void PostImportar()
                {
                }

                /// <summary>
                /// Comienza la importación de todos los mapas.
                /// </summary>
                public void ImportarTodo()
                {
                        foreach (MapaDeTabla Mapa in MapaDeTablas) {
                                ImportarTabla(Mapa);
                        }
                }


                public virtual void ImportarTabla(MapaDeTabla mapa)
                {
                        Progreso.Value = 0;
                        Progreso.ChangeStatus("Leyendo la tabla " + mapa.ToString());

                        string SqlSelect = @"SELECT * FROM " + mapa.TablaExterna;
                        if (mapa.Where != null)
                                SqlSelect += " WHERE " + mapa.Where;

                        // Hago un SELECT de la tabla
                        System.Data.IDbCommand TableCommand = ConexionExterna.CreateCommand();
                        TableCommand.CommandText = SqlSelect;
                        System.Data.DataTable ReadTable = new System.Data.DataTable();
                        ReadTable.Locale = System.Globalization.CultureInfo.CurrentCulture;
                        ReadTable.Load(TableCommand.ExecuteReader());

                        if (mapa.AutoSaltear) {
                                mapa.Saltear = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Importar.RegistrosImportados." + this.Nombre + "." + mapa.Nombre, 0);
                                if (mapa.Saltear > 1)
                                        mapa.Saltear--;
                        }

                        System.Data.IDbTransaction Trans = this.Connection.BeginTransaction();
                        // Navegar todos los registros
                        Progreso.ChangeStatus("Incorporando " + ReadTable.Rows.Count.ToString() + " registros de la tabla " + mapa.ToString());
                        Progreso.Max = ReadTable.Rows.Count;
                        int RowNumber = 0;
                        foreach (System.Data.DataRow OriginalRow in ReadTable.Rows) {
                                ++RowNumber;

                                if (mapa.Saltear == 0 || RowNumber > mapa.Saltear) {
                                        Lfx.Data.Row ProcessedRow = this.ProcesarRegistro(mapa, OriginalRow);
                                        this.ImportarRegistro(mapa, ProcessedRow);
                                }

                                if ((RowNumber % 200) == 0) {
                                        Progreso.Advance(200);
                                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Importar.RegistrosImportados." + this.Nombre + "." + mapa.Nombre, RowNumber);
                                        Trans.Commit();
                                        Trans.Dispose();
                                        Trans = this.Connection.BeginTransaction();
                                }

                                if (mapa.Limite > 0 && RowNumber > mapa.Limite)
                                        break;
                        }

                        Trans.Commit();
                        Trans.Dispose();
                        Trans = null;
                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Importar.RegistrosImportados." + this.Nombre + "." + mapa.Nombre, RowNumber);
                }
                

                public virtual void ImportarRegistro(MapaDeTabla mapa, Lfx.Data.Row importedRow)
                {
                        object ImportIdValue = importedRow.Fields[mapa.ColumnaIdLazaro].Value;
                        string ImportIdSqlValue;
                        if (ImportIdValue is string) {
                                ImportIdSqlValue = "'" + ImportIdValue.ToString() + "'";
                        } else if (ImportIdValue is decimal || ImportIdValue is double) {
                                ImportIdSqlValue = Lfx.Types.Formatting.FormatNumberSql(System.Convert.ToDecimal(ImportIdValue));
                        } else if (ImportIdValue is DateTime) {
                                ImportIdSqlValue = "'" + Lfx.Types.Formatting.FormatDateTimeSql(System.Convert.ToDateTime(ImportIdValue)) + "'";
                        } else {
                                ImportIdSqlValue = ImportIdValue.ToString();
                        }

                        Lfx.Data.Row CurrentRow = this.Connection.FirstRowFromSelect("SELECT * FROM " + mapa.TablaLazaro + " WHERE " + mapa.ColumnaIdLazaro + "=" + ImportIdSqlValue);
                        Lbl.IElementoDeDatos Elem = ConvertirRegistroEnElemento(mapa, importedRow, CurrentRow);

                        if (Elem != null) {
                                this.GuardarElemento(mapa, Elem);

                                if (this.Opciones.ImportarStock && Elem is Lbl.Articulos.Articulo && importedRow.Fields.Contains("stock_actual")) {
                                        // Actualizo el stock
                                        Lbl.Articulos.Articulo Art = Elem as Lbl.Articulos.Articulo;

                                        decimal StockActual = Art.ObtenerExistencias();
                                        decimal NuevoStock = System.Convert.ToDecimal(importedRow["stock_actual"]);
                                        decimal Diferencia = NuevoStock - StockActual;

                                        if (Diferencia != 0)
                                                Art.MoverExistencias(null, Diferencia, "Stock importado desde " + this.Nombre, null, new Articulos.Situacion(this.Connection, Lfx.Workspace.Master.CurrentConfig.Productos.DepositoPredeterminado), null);
                                }
                        }
                }


                /// <summary>
                /// Convierte un registro en un elemento de datos.
                /// </summary>
                /// <param name="mapa">El mapa del cual proviene el registro.</param>
                /// <param name="externalRow">El registro externo (importado).</param>
                /// <param name="internalRow">El registro interno (de Lázaro) o null si se está importando un elemento nuevo.</param>
                /// <returns>Un elemento de datos</returns>
                public virtual Lbl.IElementoDeDatos ConvertirRegistroEnElemento(MapaDeTabla mapa, Lfx.Data.Row externalRow, Lfx.Data.Row internalRow)
                {
                        Lbl.IElementoDeDatos Elem;

                        object ImportIdValue = externalRow.Fields[mapa.ColumnaIdLazaro].Value;
                        if (internalRow == null) {
                                Elem = this.CrearElemento(mapa, externalRow);
                                Elem.Registro[mapa.ColumnaIdLazaro] = ImportIdValue;
                        } else if (this.Opciones.ActualizarRegistros && mapa.ActualizaRegistros) {
                                Elem = this.CargarElemento(mapa, internalRow);
                                foreach (MapaDeColumna mapaCol in mapa.MapaDeColumnas) {
                                        Elem.Registro[mapaCol.ColumnaLazaro] = externalRow.Fields[mapaCol.ColumnaLazaro].Value;
                                }
                        } else {
                                Elem = null;
                        }

                        return Elem;
                }


                /// <summary>
                /// Procesa un registro según el mapa de columnas correspondiente a la tabla y devuelve un Lfx.Data.Row
                /// </summary>
                public Lfx.Data.Row ProcesarRegistro(MapaDeTabla mapa, System.Data.DataRow externalRow)
                {
                        Lfx.Data.Row internalRow = new Lfx.Data.Row();
                        internalRow.IsNew = true;
                        internalRow.Table = Lfx.Workspace.Master.Tables[mapa.TablaLazaro];

                        foreach (MapaDeColumna Col in mapa.MapaDeColumnas) {
                                object FieldValue = null;
                                switch (Col.Conversion) {
                                        case ConversionDeColumna.ConvertirAMinusculas:
                                                FieldValue = externalRow[Col.ColumnaExterna].ToString().ToLowerInvariant();
                                                break;
                                        case ConversionDeColumna.ConvertirAMayusculasYMinusculas:
                                                FieldValue = externalRow[Col.ColumnaExterna].ToString().ToTitleCase();
                                                break;
                                        case ConversionDeColumna.InterpretarNombreYApellido:
                                                FieldValue = externalRow[Col.ColumnaExterna].ToString().ToTitleCase();
                                                string Nombre = FieldValue.ToString();
                                                string Apellido = Lfx.Types.Strings.GetNextToken(ref Nombre, " ");
                                                internalRow["nombre"] = Nombre.Trim();
                                                internalRow["apellido"] = Apellido.Trim();
                                                if (Nombre.Length > 0 && Apellido.Length > 0)
                                                        FieldValue = Apellido + ", " + Nombre;
                                                break;
                                        case ConversionDeColumna.InterpretarSql:
                                                string Sql = Col.ParametroConversion.ToString();
                                                string ClaveBuscada = externalRow[Col.ColumnaExterna].ToString();

                                                if (this.CacheConversiones.ContainsKey(Sql) && this.CacheConversiones[Sql].ContainsKey(ClaveBuscada)){
                                                        FieldValue = this.CacheConversiones[Sql][ClaveBuscada];
                                                } else {
                                                        Lfx.Data.Row Result = this.Connection.FirstRowFromSelect(Sql.Replace("$VALOR$", ClaveBuscada));
                                                        if (Result == null || Result[0] == null)
                                                                FieldValue = null;
                                                        else
                                                                FieldValue = Result[0];

                                                        if (this.CacheConversiones.ContainsKey(Sql) == false)
                                                                // Agrego esta conversión a la cache
                                                                this.CacheConversiones.Add(Sql, new Dictionary<string, object>());
                                                        this.CacheConversiones[Sql].Add(ClaveBuscada, FieldValue);
                                                }
                                                
                                                break;
                                        case ConversionDeColumna.Ninguna:
                                                if (Col.ColumnaExterna != null) {
                                                        FieldValue = externalRow[Col.ColumnaExterna];
                                                } else {
                                                        FieldValue = Col.ValorPredeterminado;
                                                }
                                                break;
                                        default:
                                                throw new NotImplementedException("Lbl.Servicios.Importar.Filtro: no implementa ConversionDeColumna." + Col.Conversion.ToString());
                                }
                                internalRow.Fields.AddWithValue(Col.ColumnaLazaro, FieldValue);
                                if (Col.ColumnaExterna != null)
                                        internalRow.Fields.AddWithValue("original_" + Col.ColumnaExterna, externalRow[Col.ColumnaExterna]);
                        }

                        // El id de seguimiento de importación
                        string[] ColumnasExternas = mapa.ColumnaIdExterna.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (ColumnasExternas.Length == 1) {
                                internalRow[mapa.ColumnaIdLazaro] = externalRow[mapa.ColumnaIdExterna];
                                internalRow.Fields.AddWithValue("original_" + mapa.ColumnaIdExterna, externalRow[mapa.ColumnaIdExterna]);
                        } else {
                                string Valor = null;
                                foreach (string ColumnaExterna in ColumnasExternas) {
                                        if (Valor == null)
                                                Valor = externalRow[ColumnaExterna].ToString();
                                        else
                                                Valor += "--" + externalRow[ColumnaExterna].ToString();
                                        internalRow.Fields.AddWithValue("original_" + ColumnaExterna, externalRow[ColumnaExterna]);
                                }
                                internalRow[mapa.ColumnaIdLazaro] = Valor;
                        }
                        
                        this.ProcesarRemplazos(mapa, ref internalRow);

                        return internalRow;
                }

                /// <summary>
                /// Prepara las tablas internas para recibir los datos importados.
                /// </summary>
                public void PrepararTablasLazaro()
                {
                        using (System.Data.IDbTransaction Trans = this.Connection.BeginTransaction()) {
                                System.Collections.Generic.List<string> TablasModificadas = new List<string>();
                                System.Console.WriteLine("Lbl.Servicios.Importar.Filtro: Preparando tablas internas...");
                                foreach (MapaDeTabla Map in this.MapaDeTablas) {
                                        if (Map.ColumnaIdExterna != null) {
                                                Lfx.Data.TableStructure Tabla = Lfx.Workspace.Master.Structure.Tables[Map.TablaLazaro];
                                                if (Tabla.Columns.ContainsKey(Map.ColumnaIdLazaro) == false) {
                                                        // Si la columna Id no existe, agrego un tag
                                                        Lfx.Data.Tag ImportTag = new Lfx.Data.Tag(Map.TablaLazaro, Map.ColumnaIdLazaro, "ImportId");
                                                        ImportTag.DataBase = this.Connection;
                                                        ImportTag.FieldType = Lazaro.Orm.ColumnTypes.VarChar;
                                                        ImportTag.Nullable = true;
                                                        ImportTag.Internal = true;
                                                        Lfx.Workspace.Master.Tables[Map.TablaLazaro].Tags.Add(ImportTag);
                                                        ImportTag.Save();
                                                        TablasModificadas.Add(Map.TablaLazaro);
                                                        Lfx.Workspace.Master.Structure.LoadBuiltIn();
                                                }
                                        }
                                }

                                // Me aseguro de que los tags se incorporen a las estructuras de la base de datos
                                if (TablasModificadas.Count > 0) {
                                        foreach (string NombreTabla in TablasModificadas) {
                                                Lfx.Data.TableStructure Tabla = Lfx.Workspace.Master.Structure.Tables[NombreTabla];
                                                this.Connection.SetTableStructure(Tabla);
                                        }
                                }
                                Trans.Commit();
                        }
                }


                /// <summary>
                /// Realiza los reemplazos de la lista de reemplazos definidos para este filtro.
                /// </summary>
                public void ProcesarRemplazos(MapaDeTabla mapa, ref Lfx.Data.Row row)
                {
                        foreach (Lazaro.Orm.Data.Field Fld in row.Fields) {
                                foreach (Reemplazo Rmp in this.Reemplazos) {
                                        if (Fld.DataType == Rmp.Tipo 
                                                && (Rmp.NombreCampo == null || Rmp.NombreCampo == Fld.ColumnName
                                                        || Rmp.NombreCampo == mapa.TablaExterna + ":" + Fld.ColumnName))
                                                Fld.Value = Rmp.Reemplazar(Fld.Value);
                                }
                        }
                }

                /// <summary>
                /// Crea un derivado de ElementoDeDatos del tipo correspondiente para el mapa de tabla actual a partir de un Lfx.Data.Row.
                /// </summary>
                /// <param name="mapa">El mapa de la tabla a la cual corresponde el registro.</param>
                /// <param name="row">El registro a partir del cual crear un ElementoDeDatos.</param>
                /// <returns>Un objeto de alguna clase derivada de ElementoDeDatos.</returns>
                protected Lbl.IElementoDeDatos CrearElemento(MapaDeTabla mapa, Lfx.Data.Row row)
                {
                        return Lbl.Instanciador.Instanciar(mapa.TipoElemento, this.Connection, row);
                }

                /// <summary>
                /// Carga un elemento existente desde la base de datos.
                /// </summary>
                /// <param name="mapa"></param>
                /// <param name="row"></param>
                /// <returns></returns>
                protected Lbl.IElementoDeDatos CargarElemento(MapaDeTabla mapa, Lfx.Data.Row row)
                {
                        return Lbl.Instanciador.Instanciar(mapa.TipoElemento, this.Connection, row.Fields[Lfx.Workspace.Master.Tables[mapa.TablaLazaro].PrimaryKey].ValueInt);
                }


                /// <summary>
                /// Guarda un elemento.
                /// </summary>
                /// <param name="mapa"></param>
                /// <param name="elemento"></param>
                protected virtual void GuardarElemento(MapaDeTabla mapa, Lbl.IElementoDeDatos elemento)
                {
                        elemento.Guardar();
                }


                public override string ToString()
                {
                        return this.Nombre;
                }
        }
}
