using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Lfc.Bancos.Cheques
{
        public partial class Inicio : Lfc.FormularioListado
        {
                protected int Estado = -2;
                protected int Banco, Cliente, Sucursal;
                protected Lfx.Types.DateRange Fechas = new Lfx.Types.DateRange("*");
                protected Lbl.ColeccionCodigoDetalle EstadosCheques = new Lbl.ColeccionCodigoDetalle();

                public Inicio()
                {
                        InitializeComponent();

                        if (this.PanelAcciones.Controls.Contains(this.DepositarPagar) == false) {
                                this.PanelAcciones.Controls.Add(this.DepositarPagar);
                        }
                        if (this.PanelAcciones.Controls.Contains(this.BotonEfectivizar) == false) {
                                this.PanelAcciones.Controls.Add(this.BotonEfectivizar);
                        }

                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Bancos.Cheque),

                                TableName = "bancos_cheques",
                                KeyColumn = new Lazaro.Pres.Field("bancos_cheques.id_cheque", "Cód.", Lfx.Data.InputFieldTypes.Serial, 20),
                                OrderBy = "bancos_cheques.fecha DESC",
                                Joins = new qGen.JoinCollection() { new qGen.Join("bancos", "bancos_cheques.id_banco=bancos.id_banco") },

                                Columns = new Lazaro.Pres.FieldCollection()
			        {
				        new Lazaro.Pres.Field("bancos_cheques.numero", "Número", Lfx.Data.InputFieldTypes.Text, 120),
				        new Lazaro.Pres.Field("bancos_cheques.fechaemision", "Fecha Emision", Lfx.Data.InputFieldTypes.Date, 96),
				        new Lazaro.Pres.Field("bancos_cheques.emitidopor", "Librador", Lfx.Data.InputFieldTypes.Text, 120),
				        new Lazaro.Pres.Field("bancos_cheques.importe", "Importe", Lfx.Data.InputFieldTypes.Currency, 96),
				        new Lazaro.Pres.Field("bancos_cheques.fechacobro", "Fecha de Cobro", Lfx.Data.InputFieldTypes.Date, 96),
				        new Lazaro.Pres.Field("bancos_cheques.concepto", "Concepto", Lfx.Data.InputFieldTypes.Text, 160),
				        new Lazaro.Pres.Field("bancos.nombre", "Banco", Lfx.Data.InputFieldTypes.Text, 120),
				        new Lazaro.Pres.Field("bancos_cheques.estado", "Estado", 96, EstadosCheques),
                                        new Lazaro.Pres.Field("bancos_cheques.obs", "Obs", Lfx.Data.InputFieldTypes.Memo, 320)
			        }
                        };

                        this.Limit = 20000;
                        this.Contadores.Add(new Contador("Total", Lui.Forms.DataTypes.Currency));
                        this.Contadores.Add(new Contador("Sin Cobrar", Lui.Forms.DataTypes.Currency));

                        Listado.CheckBoxes = true;
                        this.HabilitarFiltrar = true;
                        this.HabilitarCrear = false;
                }


                public bool Emitidos
                {
                        get
                        {
                                return this.Definicion.ElementoTipo == typeof(Lbl.Bancos.ChequeEmitido);
                        }
                }


                protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
                {
                        item.SubItems["bancos_cheques.numero"].Text = row.Fields["numero"].ValueInt.ToString("00000000");

                        decimal Importe = row.Fields["importe"].ValueDecimal;
                        this.Contadores[0].AddValue(Importe);

                        switch (row.Fields["estado"].ValueInt) {
                                case 0:
                                        if (this.Emitidos)
                                                item.SubItems["bancos_cheques.estado"].Text = "A pagar";
                                        else
                                                item.SubItems["bancos_cheques.estado"].Text = "A cobrar";
                                        if (DateTime.Compare(row.Fields["fechacobro"].ValueDateTime, System.DateTime.Now) <= 0)
                                                item.ForeColor = System.Drawing.Color.Green;
                                        else
                                                item.ForeColor = System.Drawing.Color.Black;
                                        this.Contadores[1].AddValue(Importe);
                                        break;
                                case 5:
                                        item.SubItems["bancos_cheques.estado"].Text = "Depositado";
                                        this.Contadores[1].AddValue(Importe);
                                        break;
                                case 10:
                                        if (this.Emitidos)
                                                item.SubItems["bancos_cheques.estado"].Text = "Pagado";
                                        else
                                                item.SubItems["bancos_cheques.estado"].Text = "Cobrado";
                                        item.ForeColor = System.Drawing.Color.Gray;
                                        break;
                                case 11:
                                        item.SubItems["bancos_cheques.estado"].Text = "Entregado";
                                        item.ForeColor = System.Drawing.Color.Gray;
                                        break;
                                case 90:
                                        item.SubItems["bancos_cheques.estado"].Text = "Anulado";
                                        item.ForeColor = System.Drawing.Color.Gray;
                                        item.Font = new Font(item.Font, FontStyle.Strikeout);
                                        break;
                        }
                }


                public override Lfx.Types.OperationResult OnFilter()
                {
                        Lfx.Types.OperationResult filtrarReturn = base.OnFilter();
                        if (filtrarReturn.Success == true) {
                                using (Bancos.Cheques.Filtros FormFiltros = new Bancos.Cheques.Filtros()) {
                                        FormFiltros.Connection = this.Connection;
                                        if (this.Emitidos) {
                                                FormFiltros.EntradaEstado.SetData = new string[] {
                                        "Todos|-1",
                                        "A pagar y depositados|-2",
                                        "A pagar|0",
                                        "Depositado|5",
                                        "Pagado|10",
                                        "Anulado|90"};
                                        } else {
                                                FormFiltros.EntradaEstado.SetData = new string[] {
                                        "Todos|-1",
                                        "A cobrar y depositados|-2",
                                        "A cobrar|0",
                                        "Depositado|5",
                                        "Cobrado|10",
                                        "Anulado|90"};
                                        }
                                        FormFiltros.EntradaEstado.TextKey = Estado.ToString();
                                        FormFiltros.EntradaSucursal.ValueInt = Sucursal;
                                        FormFiltros.EntradaBanco.ValueInt = Banco;
                                        FormFiltros.EntradaPersona.ValueInt = Cliente;
                                        FormFiltros.EntradaFechas.Rango = Fechas;

                                        FormFiltros.ShowDialog();
                                        if (FormFiltros.DialogResult == DialogResult.OK) {
                                                Estado = Lfx.Types.Parsing.ParseInt(FormFiltros.EntradaEstado.TextKey);
                                                Sucursal = FormFiltros.EntradaSucursal.ValueInt;
                                                Banco = FormFiltros.EntradaBanco.ValueInt;
                                                Cliente = FormFiltros.EntradaPersona.ValueInt;
                                                Fechas = FormFiltros.EntradaFechas.Rango;
                                                RefreshList();
                                                filtrarReturn.Success = true;
                                        } else {
                                                filtrarReturn.Success = false;
                                        }
                                }
                        }
                        return filtrarReturn;
                }

                protected override void OnBeginRefreshList()
                {
                        this.CustomFilters.Clear();

                        if (this.Emitidos)
                                this.CustomFilters.AddWithValue("bancos_cheques.emitido", 1);
                        else
                                this.CustomFilters.AddWithValue("bancos_cheques.emitido", 0);

                        if (Estado == -2)
                                this.CustomFilters.AddWithValue("bancos_cheques.estado IN (0, 5)");
                        if (Estado >= 0)
                                this.CustomFilters.AddWithValue("bancos_cheques.estado", Estado);

                        if (Sucursal > 0)
                                this.CustomFilters.AddWithValue("bancos_cheques.id_sucursal", Sucursal);

                        if (Banco > 0)
                                this.CustomFilters.AddWithValue("bancos_cheques.id_banco", Banco);

                        if (Cliente > 0)
                                this.CustomFilters.AddWithValue("bancos_cheques.id_cliente", Cliente);

                        if (Fechas.HasRange)
                                this.CustomFilters.AddWithValue("bancos_cheques.fechaemision BETWEEN '" + Lfx.Types.Formatting.FormatDateSql(Fechas.From) + "  00:00:00' AND '" + Lfx.Types.Formatting.FormatDateSql(Fechas.To) + " 23:59:59'");

                        base.OnBeginRefreshList();
                }


                private Lfx.Types.OperationResult Efectivizar()
                {
                        Lfc.Bancos.Cheques.Efectivizar Efectivizar = new Lfc.Bancos.Cheques.Efectivizar();

                        foreach (System.Windows.Forms.ListViewItem itm in Listado.Items) {
                                if (itm.Checked && (itm.SubItems["bancos_cheques.estado"].Text == "A cobrar" || itm.SubItems["bancos_cheques.estado"].Text == "Depositado")) {
                                        int IdCheque = Lfx.Types.Parsing.ParseInt(itm.Text);
                                        Lbl.Bancos.Cheque Ch = new Lbl.Bancos.Cheque(this.Connection, IdCheque);
                                        Efectivizar.EntradaSubTotal.ValueDecimal = Ch.Importe;
                                        Efectivizar.Cheque = Ch;
                                        if (Efectivizar.ShowDialog() != System.Windows.Forms.DialogResult.OK) {
                                                itm.Checked = false;
                                                return new Lfx.Types.CancelOperationResult();
                                        }
                                }
                        }
                        return new Lfx.Types.SuccessOperationResult();
                }

                private void BotonEfectivizar_Click(object sender, System.EventArgs e)
                {
                        if (this.Emitidos == false) {
                                //Depositar
                                Lbl.ListaIds Codigos = this.CodigosSeleccionados;
                                if (Codigos == null || Codigos.Count == 0) {
                                        Lui.Forms.MessageBox.Show("Por favor seleccione uno o más cheques.", "Error");
                                } else {
                                        Lfx.Types.OperationResult Res = this.Efectivizar();
                                        if (Res.Success == false && Res.Message != null)
                                                Lfx.Workspace.Master.RunTime.Toast(Res.Message, "Error");
                                }
                        } else {
                                Lfx.Workspace.Master.RunTime.Toast("Esta opción sólo sirve para cheques recibidos.", "Aviso");
                        }
                }


                private void DepositarPagar_Click(object sender, System.EventArgs e)
                {
                        if (this.Emitidos == false) {
                                //Depositar
                                Lbl.ListaIds Codigos = this.CodigosSeleccionados;
                                if (Codigos == null || Codigos.Count == 0) {
                                        Lui.Forms.MessageBox.Show("Por favor seleccione uno o más cheques.", "Error");
                                } else {
                                        Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("Al depositar un cheque en una cuenta bancaria propia, puede marcarlo como depositado para control interno.\nSirve sólamente para depositos en cajas propias. Para depósitos en cajas de terceros utilice la opción 'Efectivizar'.", "¿Desea marcar los cheques seleccionados como depositados?");
                                        if (Pregunta.ShowDialog() == DialogResult.OK) {
                                                using (IDbTransaction Trans = this.Connection.BeginTransaction()) {
                                                        qGen.Update Depo = new qGen.Update("bancos_cheques");
                                                        Depo.ColumnValues.AddWithValue("estado", 5);
                                                        Depo.WhereClause = new qGen.Where();
                                                        Depo.WhereClause.AddWithValue("estado", 0);
                                                        Depo.WhereClause.AddWithValue("id_cheque", qGen.ComparisonOperators.In, Codigos);
                                                        this.Connection.Execute(Depo);
                                                        Trans.Commit();
                                                }
                                                foreach (System.Windows.Forms.ListViewItem itm in Listado.Items) {
                                                        if (itm.Checked)
                                                                itm.Checked = false;
                                                }
                                                this.RefreshList();
                                        }
                                }
                        } else {
                                Lfx.Types.OperationResult Res = this.Pagar();
                                if (Res.Success == false && Res.Message != null)
                                        Lfx.Workspace.Master.RunTime.Toast(Res.Message, "Error");
                        }
                }

                private Lfx.Types.OperationResult Pagar()
                {
                        int IdCajaOrigen = 0;
                        List<string> Cheques = new List<string>();
                        foreach (System.Windows.Forms.ListViewItem itm in Listado.Items) {
                                if (itm.Checked && (itm.SubItems["bancos_cheques.estado"].Text == "A pagar")) {
                                        Cheques.Add(itm.Text);
                                        if (IdCajaOrigen == 0)
                                                IdCajaOrigen = this.Connection.FieldInt("SELECT id_caja FROM chequeras WHERE (SELECT numero FROM bancos_cheques WHERE id_cheque=" + itm.Text + ") BETWEEN desde AND hasta AND estado=1");
                                }
                        }

                        if (Cheques.Count > 0) {
                                Bancos.Cheques.Pagar FormPagar = new Bancos.Cheques.Pagar();
                                FormPagar.EntradaCajaOrigen.ValueInt = IdCajaOrigen;
                                if (FormPagar.Mostrar(Cheques) == DialogResult.OK) {
                                        foreach (System.Windows.Forms.ListViewItem itm in Listado.Items) {
                                                if (itm.Checked)
                                                        itm.Checked = false;
                                        }
                                        this.RefreshList();
                                        return new Lfx.Types.SuccessOperationResult();
                                } else {
                                        return new Lfx.Types.OperationResult(false);
                                }
                        } else {
                                return new Lfx.Types.FailureOperationResult("Por favor marque uno o más cheques a pagar.");
                        }
                }
        }
}