using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Lui.Forms
{
	public partial class WorkstationSelectorForm : Lui.Forms.DialogForm
	{
		private System.Windows.Forms.ColumnHeader NombreEstacion;
		private System.Windows.Forms.ColumnHeader Nombre;
                private Lui.Forms.ListView Listado;
		public string Estacion;

                public WorkstationSelectorForm()
		{
			InitializeComponent();
		}

                public override Lfx.Types.OperationResult Ok()
                {
                        if (Listado.SelectedItems != null && Listado.SelectedItems.Count > 0)
                                this.Estacion = Listado.SelectedItems[0].Text;
                        return base.Ok();
                }


                protected override void OnLoad(EventArgs e)
                {
                        base.OnLoad(e);
                        if (this.Connection != null)
                                MostrarDatos();
                }


		private void MostrarDatos()
		{
			Listado.Items.Clear();
			ListViewItem itm = Listado.Items.Add(new ListViewItem (new string[] {Lfx.Environment.SystemInformation.MachineName, "Este equipo"}));
			itm.Selected = (this.Estacion == Lfx.Environment.SystemInformation.MachineName);

			System.Data.DataTable Estaciones = this.Connection.Select("SELECT DISTINCT estacion FROM sys_config ORDER BY estacion");
			foreach(System.Data.DataRow RowEstacion in Estaciones.Rows)
			{
				if((string)RowEstacion["estacion"] != "*" && (string)RowEstacion["estacion"] != Lfx.Environment.SystemInformation.MachineName)
				{
					itm = Listado.Items.Add(new ListViewItem (new string[] {(string)RowEstacion["estacion"], (string)RowEstacion["estacion"]}));
					itm.Selected = (this.Estacion == (string)RowEstacion["estacion"]);
				}
			}	
		}
	}
}

