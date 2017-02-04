using System;
using System.Collections.Generic;
using System.Text;
using Lazaro.Pres.Spreadsheet;

namespace Lbl.Reportes
{
        public class Reporte2
        {
                public Lfx.Data.IConnection DataBase;
                public string Titulo = "Reporte";

                public qGen.Select SelectCommand;
                public Lfx.Data.Grouping Grouping = null;
                public System.Collections.Generic.List<Lfx.Data.Aggregate> Aggregates = new List<Lfx.Data.Aggregate>();
                public Lazaro.Pres.FieldCollection Fields = new Lazaro.Pres.FieldCollection();
                public bool ExpandGroups = true;

                public Reporte2(Lfx.Data.IConnection dataBase, qGen.Select selectCommand)
                {
                        this.DataBase = dataBase;
                        this.SelectCommand = selectCommand;
                }

                public Lazaro.Pres.Spreadsheet.Sheet ToWorkbookSheet()
                {
                        Lazaro.Pres.Spreadsheet.Sheet Res = new Lazaro.Pres.Spreadsheet.Sheet(Titulo);

                        foreach (Lfx.Data.Aggregate Agru in this.Aggregates) {
                                Agru.Reset();
                        }

                        foreach (Lazaro.Pres.Field Field in this.Fields) {
                                Res.ColumnHeaders.Add(new ColumnHeader(Field.Label, Field.Width, Field.Alignment));
                        }

                        if (this.Grouping != null)
                                this.Grouping.Reset();

                        qGen.Select Sel = this.SelectCommand.Clone();
                        if (this.Grouping != null) {
                                if (Sel.Order == null || Sel.Order.Length == 0)
                                        Sel.Order = this.Grouping.FieldName;
                                else
                                        Sel.Order = this.Grouping.FieldName + "," + Sel.Order;
                        }

                        System.Data.DataTable Tabla = DataBase.Select(Sel);
                        foreach (System.Data.DataRow Registro in Tabla.Rows) {
                                if (this.Grouping != null && Lfx.Types.Object.CompareByValue(this.Grouping.LastValue, Registro[Lazaro.Orm.Data.Field.GetNameOnly(this.Grouping.FieldName)]) != 0) {
                                        // Agrego un renglón de subtotales
                                        if (this.Grouping.LastValue != null) {
                                                Lazaro.Pres.Spreadsheet.Row SubTotales;
                                                if (this.ExpandGroups)
                                                        SubTotales = new Lazaro.Pres.Spreadsheet.AggregationRow(Res);
                                                else
                                                        SubTotales = new Lazaro.Pres.Spreadsheet.Row(Res);
                                                for (int i = 0; i < this.Fields.Count; i++) {
                                                        Lazaro.Pres.Spreadsheet.Cell FuncCell = null;
                                                        if (this.Grouping != null && this.Fields[i].Name == this.Grouping.FieldName && this.ExpandGroups == false) {
                                                                FuncCell = new Cell(this.Grouping.LastValue);
                                                        } else {
                                                                foreach (Lfx.Data.Aggregate SubtAgru in this.Aggregates) {
                                                                        if (SubtAgru.FieldName == this.Fields[i].Name) {
                                                                                switch (SubtAgru.Function) {
                                                                                        case Lfx.Data.AggregationFunctions.Count:
                                                                                                FuncCell = new Cell(SubtAgru.Count);
                                                                                                SubtAgru.ResetCounters();
                                                                                                break;
                                                                                        case Lfx.Data.AggregationFunctions.Sum:
                                                                                                FuncCell = new Cell(SubtAgru.Sum);
                                                                                                SubtAgru.ResetCounters();
                                                                                                break;
                                                                                        default:
                                                                                                FuncCell = new Cell("#undef#");
                                                                                                SubtAgru.ResetCounters();
                                                                                                break;
                                                                                }
                                                                        }
                                                                }
                                                        }
                                                        if (FuncCell != null)
                                                                SubTotales.Cells.Add(FuncCell);
                                                        else
                                                                SubTotales.Cells.Add(new Cell(""));
                                                }
                                                Res.Rows.Add(SubTotales);
                                        }
                                        this.Grouping.LastValue = Registro[Lazaro.Orm.Data.Field.GetNameOnly(this.Grouping.FieldName)];

                                        // Agrego un encabezado
                                        if (ExpandGroups)
                                                Res.Rows.Add(new Lazaro.Pres.Spreadsheet.HeaderRow(Registro[Lazaro.Orm.Data.Field.GetNameOnly(this.Grouping.FieldName)].ToString()));
                                }

                                if (Aggregates != null) {
                                        // Calculo las funciones de agregación
                                        foreach (Lfx.Data.Aggregate Agru in this.Aggregates) {
                                                switch (Agru.Function) {
                                                        case Lfx.Data.AggregationFunctions.Count:
                                                                Agru.Count++;
                                                                break;
                                                        case Lfx.Data.AggregationFunctions.Sum:
                                                                Agru.Sum += System.Convert.ToDecimal(Registro[Lazaro.Orm.Data.Field.GetNameOnly(Agru.FieldName)]);
                                                                break;
                                                }
                                        }
                                }
                                if (ExpandGroups) {
                                        Lazaro.Pres.Spreadsheet.Row Renglon = new Lazaro.Pres.Spreadsheet.Row();
                                        foreach (Lazaro.Pres.Field Field in this.Fields) {
                                                Lazaro.Pres.Spreadsheet.Cell Celda = new Cell(Registro[Lazaro.Orm.Data.Field.GetNameOnly(Field.Name)]);
                                                Renglon.Cells.Add(Celda);
                                        }
                                        Res.Rows.Add(Renglon);
                                }
                        }

                        return Res;
                }
        }
}
