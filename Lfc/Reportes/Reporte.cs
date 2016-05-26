using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Reportes
{
        public partial class Reporte : Lui.Forms.ChildForm
        {
                public Lbl.Reportes.Reporte2 ReporteAMostrar;

                public Reporte()
                {
                        InitializeComponent();
                }

                private void BotonActualizar_Click(object sender, EventArgs e)
                {
                        this.ReporteAMostrar.ExpandGroups = EntradaExpandirGrupos.TextKey == "1";
                        Lazaro.Pres.Spreadsheet.Sheet ReportSheet = this.ReporteAMostrar.ToWorkbookSheet();
                        ReportSheet.Sort(2, false);
                        ListViewReporte.FromSheet(ReportSheet);
                }
        }
}
