using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Lfc.Tarjetas.Cupones
{
        public partial class Inicio : Lfc.FormularioListado
        {
                protected internal string m_Tabla = "tarjetas_cupones";
                protected internal int m_Cliente, m_FormaDePago, m_Plan, m_Estado = -2;
                protected internal Lfx.Types.DateRange m_Fecha = new Lfx.Types.DateRange("*");
                protected internal qGen.Select m_SelectCommand;

                public Inicio()
                {
                        InitializeComponent();

                        Lbl.ColeccionCodigoDetalle SetEstados = new Lbl.ColeccionCodigoDetalle()
                        {
                                {(int)Lbl.Pagos.EstadosCupones.Acreditado, "Acreditado"},
                                {(int)Lbl.Pagos.EstadosCupones.Anulado, "Anulado"},
                                {(int)Lbl.Pagos.EstadosCupones.Presentado, "Presentado"},
                                {(int)Lbl.Pagos.EstadosCupones.Rechazaro, "Rechazado"},
                                {(int)Lbl.Pagos.EstadosCupones.SinPresentar, "Sin presentar"}

                        };

                        this.Definicion = new Lazaro.Pres.Listings.Listing()
                        {
                                ElementoTipo = typeof(Lbl.Pagos.Cupon),
                                TableName = "tarjetas_cupones",
                                Joins = new qGen.JoinCollection() { new qGen.Join("formaspago", "tarjetas_cupones.id_tarjeta=formaspago.id_formapago"), new qGen.Join("personas", "tarjetas_cupones.id_cliente=personas.id_persona") },
                                KeyColumn = new Lazaro.Pres.Field("tarjetas_cupones.id_cupon", "Cód.", Lfx.Data.InputFieldTypes.Serial, 28),

                                Columns = new Lazaro.Pres.FieldCollection()
			        {
                                        new Lazaro.Pres.Field("tarjetas_cupones.concepto", "Concepto", Lfx.Data.InputFieldTypes.Text, 240),
                                        new Lazaro.Pres.Field("formaspago.nombre", "Tarjeta", Lfx.Data.InputFieldTypes.Text, 240),
				        new Lazaro.Pres.Field("tarjetas_cupones.numero", "Cupón", Lfx.Data.InputFieldTypes.Text, 100),
                                        new Lazaro.Pres.Field("tarjetas_cupones.importe", "Importe", Lfx.Data.InputFieldTypes.Currency, 100),
				        new Lazaro.Pres.Field("tarjetas_cupones.estado", "Estado", 120, SetEstados),
				        new Lazaro.Pres.Field("tarjetas_cupones.fecha", "Fecha", Lfx.Data.InputFieldTypes.Date, 120)
			        },
                                OrderBy = "tarjetas_cupones.id_cupon DESC"
                        };


                        this.HabilitarBusqueda = false;
                        this.HabilitarCrear = false;
                        this.HabilitarFiltrar = true;
                        this.CheckBoxes = true;

                        this.Contadores.Add(new Contador("Presentados", Lui.Forms.DataTypes.Currency));
                        this.Contadores.Add(new Contador("SinPresentar", Lui.Forms.DataTypes.Currency));
                        this.Contadores.Add(new Contador("Acreditados", Lui.Forms.DataTypes.Currency));
                }

                public override Lfx.Types.OperationResult OnFilter()
                {
                        using (Lfc.Tarjetas.Cupones.Filtros FormFiltros = new Lfc.Tarjetas.Cupones.Filtros()) {
                                FormFiltros.Connection = this.Connection;
                                FormFiltros.EntradaFormaDePago.Text = m_FormaDePago.ToString();
                                FormFiltros.EntradaPlan.Text = m_Plan.ToString();
                                FormFiltros.EntradaEstado.TextKey = m_Estado.ToString();
                                FormFiltros.EntradaCliente.Text = m_Cliente.ToString();
                                FormFiltros.EntradaFechas.Rango = m_Fecha;
                                if (FormFiltros.ShowDialog() == DialogResult.OK) {
                                        m_FormaDePago = FormFiltros.EntradaFormaDePago.ValueInt;
                                        m_Plan = FormFiltros.EntradaPlan.ValueInt;
                                        m_Estado = Lfx.Types.Parsing.ParseInt(FormFiltros.EntradaEstado.TextKey);
                                        m_Cliente = FormFiltros.EntradaCliente.ValueInt;
                                        m_Fecha = FormFiltros.EntradaFechas.Rango;
                                        this.RefreshList();
                                        return new Lfx.Types.SuccessOperationResult();
                                } else {
                                        return new Lfx.Types.CancelOperationResult();
                                }
                        }
                }

                protected override void OnBeginRefreshList()
                {
                        this.CustomFilters.Clear();

                        if (m_Cliente > 0)
                                this.CustomFilters.AddWithValue("tarjetas_cupones.id_cliente", m_Cliente);

                        if (m_FormaDePago > 0)
                                this.CustomFilters.AddWithValue("tarjetas_cupones.id_tarjeta", m_FormaDePago);

                        if (m_Estado >= 0)
                                this.CustomFilters.AddWithValue("tarjetas_cupones.estado", m_Estado);
                        else if (m_Estado == -2)
                                this.CustomFilters.AddWithValue("tarjetas_cupones.estado", qGen.ComparisonOperators.In, new int[] { 0, 10 });

                        if (m_Fecha.HasRange)
                                this.CustomFilters.AddWithValue("tarjetas_cupones.fecha", m_Fecha.From, m_Fecha.To);

                        base.OnBeginRefreshList();
                }

                protected override void OnItemAdded(ListViewItem item, Lfx.Data.Row row)
                {
                        switch (((Lbl.Pagos.EstadosCupones)System.Convert.ToInt32(row["estado"]))) {
                                case Lbl.Pagos.EstadosCupones.SinPresentar:
                                        this.Contadores[1].AddValue(row.Fields["importe"].ValueDecimal);
                                        break;
                                case Lbl.Pagos.EstadosCupones.Anulado:
                                        item.ForeColor = Color.Gray;
                                        item.Font = new Font(item.Font, FontStyle.Strikeout);
                                        break;
                                case Lbl.Pagos.EstadosCupones.Rechazaro:
                                        item.ForeColor = Color.Gray;
                                        item.Font = new Font(item.Font, FontStyle.Strikeout);
                                        break;
                                case Lbl.Pagos.EstadosCupones.Presentado:
                                        this.Contadores[0].AddValue(row.Fields["importe"].ValueDecimal);
                                        item.ForeColor = Color.DarkGreen;
                                        break;
                                case Lbl.Pagos.EstadosCupones.Acreditado:
                                        this.Contadores[2].AddValue(row.Fields["importe"].ValueDecimal);
                                        item.ForeColor = Color.Gray;
                                        break;
                        }

                        base.OnItemAdded(item, row);
                }


                private void BotonAcreditar_Click(object sender, System.EventArgs e)
                {
                        if (Listado.CheckedItems.Count == 0) {
                                Lui.Forms.MessageBox.Show("Debe marcar uno o más cupones para acreditar.", "Acreditar");
                                return;
                        }

                        using (Lfc.Tarjetas.Cupones.Acreditar FormularioAcreditacion = new Lfc.Tarjetas.Cupones.Acreditar()) {
                                Lfx.Types.OperationProgress Progreso = new Lfx.Types.OperationProgress("Acreditando cupones", "Se están marcando los cupones seleccionados como 'Acreditado'.");
                                Progreso.Modal = false;

                                decimal Total = 0;
                                decimal TotalAcreditar = 0;
                                int iCantidad = 0;

                                System.Text.StringBuilder Cupones = new System.Text.StringBuilder();
                                decimal ComisionTarjeta = 0;
                                decimal ComisionPlan = 0;
                                decimal GestionDeCobro = 0;

                                Progreso.Max = Listado.Items.Count + 2;
                                Progreso.Begin();
                                Progreso.ChangeStatus("Analizando");

                                Lbl.Pagos.FormaDePago Tarjeta = null;
                                foreach (System.Windows.Forms.ListViewItem itm in Listado.Items) {
                                        if (itm.Checked) {
                                                iCantidad++;
                                                Lbl.Pagos.Cupon Cupon = new Lbl.Pagos.Cupon(Connection, Lfx.Types.Parsing.ParseInt(itm.Text));
                                                Total += Cupon.Importe;
                                                if (Cupones.Length > 0)
                                                        Cupones.Append("," + Cupon.Numero);
                                                else
                                                        Cupones.Append(Cupon.Numero);

                                                if (Cupon.FormaDePago != null) {
                                                        if (Tarjeta == null) {
                                                                Tarjeta = Cupon.FormaDePago;
                                                        } else if (Tarjeta.Id != Cupon.FormaDePago.Id) {
                                                                //Mezcla de tarjetas
                                                                Progreso.End();
                                                                Lui.Forms.MessageBox.Show("No todos los cupones seleccionados pertenecen a la misma forma de pago.", "Error");
                                                                return;
                                                        }

                                                        ComisionTarjeta += Cupon.Importe * (Tarjeta.Retencion / 100);
                                                        if (Cupon.Plan != null) {
                                                                ComisionPlan += Cupon.Importe * (Cupon.Plan.Comision / 100);
                                                        }
                                                }
                                        }
                                        Progreso.ChangeStatus(itm.Index);
                                }

                                FormularioAcreditacion.IgnorarCambios = true;
                                FormularioAcreditacion.EntradaCuponesCantidad.Text = iCantidad.ToString();
                                FormularioAcreditacion.EntradaCuponesSubTotal.Text = Lfx.Types.Formatting.FormatCurrency(Total, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                                FormularioAcreditacion.EntradaComisionTarjeta.Text = Lfx.Types.Formatting.FormatCurrency(ComisionTarjeta, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                                FormularioAcreditacion.EntradaComisionPlan.Text = Lfx.Types.Formatting.FormatCurrency(ComisionPlan, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                                FormularioAcreditacion.EntradaComisionUsuario.Text = "0";
                                FormularioAcreditacion.EntradaTotal.Text = Lfx.Types.Formatting.FormatCurrency(Total - ComisionTarjeta - ComisionPlan, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                                FormularioAcreditacion.IgnorarCambios = false;

                                bool Aceptar = false;
                                Lfc.Comprobantes.Recibos.EditarCobro FormularioPago = new Lfc.Comprobantes.Recibos.EditarCobro();
                                do {
                                        if (FormularioAcreditacion.ShowDialog() == DialogResult.OK) {
                                                TotalAcreditar = Lfx.Types.Parsing.ParseCurrency(FormularioAcreditacion.EntradaTotal.Text);
                                                GestionDeCobro = Total - TotalAcreditar;
                                                FormularioPago.Cobro.FromCobro(new Lbl.Comprobantes.Cobro(this.Connection, ((Lbl.Pagos.TiposFormasDePago)(Lfx.Types.Parsing.ParseInt(FormularioAcreditacion.EntradaFormaPago.TextKey)))));
                                                FormularioPago.Cobro.FormaDePagoEditable = false;
                                                FormularioPago.Cobro.Importe = TotalAcreditar;
                                                FormularioPago.Cobro.ImporteEditable = false;
                                                if (Tarjeta != null && Tarjeta.Caja != null)
                                                        FormularioPago.Cobro.EntradaCaja.ValueInt = Tarjeta.Caja.Id;
                                                FormularioPago.Cobro.Obs = "Cupones Nº " + Cupones.ToString();
                                                FormularioPago.Cobro.ObsEditable = false;
                                                if (FormularioPago.ShowDialog() == DialogResult.OK) {
                                                        Aceptar = true;
                                                        break;
                                                }
                                        } else {
                                                Aceptar = false;
                                                break;
                                        }
                                }
                                while (true);
                                if (Aceptar) {
                                        IDbTransaction Trans = Connection.BeginTransaction(IsolationLevel.Serializable);

                                        Progreso.ChangeStatus("Asentando el movimiento");
                                        Progreso.Max = Listado.Items.Count + 2;
                                        Progreso.Begin();

                                        // Marcar los cupones como acreditados
                                        foreach (System.Windows.Forms.ListViewItem itm in Listado.Items) {
                                                if (itm.Checked) {
                                                        Lbl.Pagos.Cupon Cupon = new Lbl.Pagos.Cupon(this.Connection, Lfx.Types.Parsing.ParseInt(itm.Text));
                                                        if (Cupon.Estado == 0 || Cupon.Estado == 10)
                                                                Cupon.Acreditar();
                                                }
                                                Progreso.ChangeStatus(itm.Index);
                                        }

                                        Progreso.ChangeStatus("Acreditando el importe");
                                        // Acreditar el dinero
                                        Lbl.Comprobantes.Cobro MiCobro = FormularioPago.Cobro.ToCobro(Connection);
                                        switch (FormularioPago.Cobro.FormaDePago.Tipo) {
                                                case Lbl.Pagos.TiposFormasDePago.Efectivo:
                                                        Lbl.Cajas.Caja CajaDiaria = new Lbl.Cajas.Caja(Connection, Lfx.Workspace.Master.CurrentConfig.Empresa.CajaDiaria);
                                                        CajaDiaria.Movimiento(true,
                                                                Lbl.Cajas.Concepto.IngresosPorFacturacion,
                                                                "Acreditación de Cupones",
                                                                null,
                                                                Total,
                                                                "Cupones Nº " + Cupones.ToString(),
                                                                null,
                                                                null,
                                                                null);
                                                        CajaDiaria.Movimiento(true,
                                                                new Lbl.Cajas.Concepto(this.Connection, 24010),
                                                                "Gestión de Cobro de Cupones",
                                                                null,
                                                                -GestionDeCobro,
                                                                "Cupones Nº " + Cupones.ToString(),
                                                                null,
                                                                null,
                                                                null);
                                                        break;
                                                case Lbl.Pagos.TiposFormasDePago.ChequePropio:
                                                        Lbl.Bancos.Cheque Cheque = MiCobro.Cheque;
                                                        Cheque.Concepto = Lbl.Cajas.Concepto.IngresosPorFacturacion;
                                                        Cheque.ConceptoTexto = "Acreditación Tarjetas";
                                                        Cheque.Guardar();
                                                        break;
                                                case Lbl.Pagos.TiposFormasDePago.Caja:
                                                        MiCobro.CajaDestino.Movimiento(true,
                                                                Lbl.Cajas.Concepto.IngresosPorFacturacion,
                                                                "Acreditación de Cupones",
                                                                null,
                                                                Total,
                                                                "Cupones Nº " + Cupones.ToString(),
                                                                null,
                                                                null,
                                                                null);
                                                        MiCobro.CajaDestino.Movimiento(true,
                                                                new Lbl.Cajas.Concepto(this.Connection, 24010),
                                                                "Gestión de Cobro de Cupones",
                                                                null,
                                                                -GestionDeCobro,
                                                                "Cupones Nº " + Cupones.ToString(),
                                                                null,
                                                                null,
                                                                null);
                                                        break;
                                        }


                                        Trans.Commit();
                                        Progreso.End();
                                }
                        }
                        this.RefreshList();
                }

                private void BotonAnular_Click(object sender, System.EventArgs e)
                {
                        if (Listado.CheckedItems.Count == 0) {
                                Lui.Forms.MessageBox.Show("Debe marcar uno o más cupones para anular.", "Acreditar");
                                return;
                        }

                        int CantidadCupones = 0;
                        foreach (System.Windows.Forms.ListViewItem itm in Listado.Items) {
                                if (itm.Checked) {
                                        CantidadCupones++;
                                        if (itm.SubItems["tarjetas_cupones.estado"].Text != "Sin presentar" && itm.SubItems["estado"].Text != "Presentado") {
                                                Lui.Forms.MessageBox.Show("Sólo se pueden anular cupones que no han sido acreditados o rechazados.", "Anular de cupones");
                                                return;
                                        }
                                }
                        }

                        if (CantidadCupones == 0) {
                                Lui.Forms.MessageBox.Show("Debe seleccionar uno o más cupones para anular.", "Anular de cupones");
                                return;
                        }


                        using (Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("¿Desea eliminar de manera permanente los cupones seleccionados?", "Anular cupones")) {
                                Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                                if (Pregunta.ShowDialog() == DialogResult.OK) {
                                        IDbTransaction Trans = Connection.BeginTransaction(IsolationLevel.Serializable);
                                        Lfx.Types.OperationProgress Progreso = new Lfx.Types.OperationProgress("Anulando cupones", "Se van a eleiminar los cupones seleccionados");
                                        Progreso.Max = CantidadCupones;
                                        Progreso.Begin();
                                        foreach (System.Windows.Forms.ListViewItem itm in Listado.Items) {
                                                if (itm.Checked) {
                                                        Progreso.Advance(1);
                                                        Lbl.Pagos.Cupon Cupon = new Lbl.Pagos.Cupon(this.Connection, Lfx.Types.Parsing.ParseInt(itm.Text));
                                                        if (Cupon.Estado == 0 || Cupon.Estado == 10)
                                                                Cupon.Anular();
                                                }
                                        }
                                        Trans.Commit();
                                        Progreso.End();
                                        this.RefreshList();
                                }
                        }
                }

                private void BotonPresentar_Click(object sender, EventArgs e)
                {
                        if (Listado.CheckedItems.Count == 0) {
                                Lui.Forms.MessageBox.Show("Debe marcar uno o más cupones para presentar.", "Acreditar");
                                return;
                        }

                        int CantidadCupones = 0;
                        foreach (System.Windows.Forms.ListViewItem itm in Listado.Items) {
                                if (itm.Checked) {
                                        CantidadCupones++;
                                        if (itm.SubItems["tarjetas_cupones.estado"].Text != "Sin presentar") {
                                                Lui.Forms.MessageBox.Show("Sólo se pueden hacer presentaciones de cupones que no han sido presentados.", "Presentación de cupones");
                                                return;
                                        }
                                }
                        }

                        if (CantidadCupones == 0) {
                                Lui.Forms.MessageBox.Show("Debe seleccionar uno o más cupones para presentar.", "Presentación de cupones");
                                return;
                        }


                        using (Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("¿Desea marcar los cupones seleccionados como presentados?", "Presentación de cupones")) {
                                Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                                if (Pregunta.ShowDialog() == DialogResult.OK) {
                                        IDbTransaction Trans = Connection.BeginTransaction(IsolationLevel.Serializable);
                                        Lfx.Types.OperationProgress Progreso = new Lfx.Types.OperationProgress("Presentación de cupones", "Se están marcando los cupones seleccionados como 'Presentados'.");
                                        Progreso.Max = CantidadCupones;
                                        Progreso.Begin();
                                        foreach (System.Windows.Forms.ListViewItem itm in Listado.Items) {
                                                if (itm.Checked) {
                                                        Progreso.Advance(1);
                                                        Lbl.Pagos.Cupon Cupon = new Lbl.Pagos.Cupon(this.Connection, Lfx.Types.Parsing.ParseInt(itm.Text));
                                                        if (Cupon.Estado == 0)
                                                                Cupon.Presentar();
                                                }
                                        }
                                        Progreso.End();
                                        Trans.Commit();
                                        this.RefreshList();
                                }
                        }
                }
        }
}