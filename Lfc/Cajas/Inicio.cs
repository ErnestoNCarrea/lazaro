using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Cajas
{
	public partial class Inicio : Lfc.FormularioListado
	{
                public Inicio()
                {
                        Lbl.ColeccionCodigoDetalle SetTipos = new Lbl.ColeccionCodigoDetalle()
                        {
                                {0, "Efectivo"},
                                {1, "Caja de ahorro"},
                                {2, "Cuenta corriente"}
                        };

                        Lbl.ColeccionCodigoDetalle SetEstados = new Lbl.ColeccionCodigoDetalle()
                        {
                                {0, "Inactiva"},
                                {1, "Activa"}
                        };

                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Cajas.Caja),

                                TableName = "cajas",
                                KeyColumn = new Lazaro.Pres.Field("cajas.id_caja", "Cód.", Lfx.Data.InputFieldTypes.Serial, 96),
                                OrderBy = "cajas.nombre",

                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("cajas.id_banco", "Banco", Lfx.Data.InputFieldTypes.Relation, 120),
				        new Lazaro.Pres.Field("cajas.numero", "Número", Lfx.Data.InputFieldTypes.Text, 120),
				        new Lazaro.Pres.Field("cajas.nombre", "Nombre", Lfx.Data.InputFieldTypes.Text, 240),
				        new Lazaro.Pres.Field("cajas.tipo", "Tipo", 80, SetTipos),
				        new Lazaro.Pres.Field("0", "Saldo Actual", Lfx.Data.InputFieldTypes.Currency, 120),
                                        new Lazaro.Pres.Field("1", "Saldo Futuro", Lfx.Data.InputFieldTypes.Currency, 120),
                                        new Lazaro.Pres.Field("estado", "Estado", 96, SetEstados),
			        }
                        };


                        this.Contadores.Add(new Contador("Total", Lui.Forms.DataTypes.Currency, "$", null));
                        this.Contadores.Add(new Contador("Activos", Lui.Forms.DataTypes.Currency, "$", null));

                        this.Connection.Tables["bancos"].PreLoad();
                }

                protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
		{
                        int IdBanco = Lfx.Types.Parsing.ParseInt(item.SubItems["cajas.id_banco"].Text);
                        if (IdBanco != 0)
                                item.SubItems["cajas.id_banco"].Text = this.Connection.Tables["bancos"].FastRows[IdBanco].Fields["nombre"].ValueString;

                        int IdCaja = Lfx.Types.Parsing.ParseInt(item.Text);
                        decimal Saldo = this.Connection.FieldDecimal("SELECT saldo FROM cajas_movim WHERE id_caja=" + IdCaja.ToString() + " ORDER BY id_movim DESC LIMIT 1");
                        decimal Pasivos = this.Connection.FieldDecimal("SELECT SUM(importe) FROM bancos_cheques WHERE estado IN (0, 5) AND emitido=1 AND id_chequera IN (SELECT chequeras.id_chequera FROM chequeras WHERE estado=1 AND id_caja=" + IdCaja.ToString() + ")");

                        this.Contadores[0].AddValue(Saldo);
			if (Saldo > 0)
                                this.Contadores[1].AddValue(Saldo);
			
                        item.SubItems["0"].Text = Lfx.Types.Formatting.FormatCurrency(Saldo, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                        item.SubItems["1"].Text = Lfx.Types.Formatting.FormatCurrency(Saldo - Pasivos, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
		}
	}
}