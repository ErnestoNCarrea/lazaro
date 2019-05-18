using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lfc.Comprobantes
{
        public partial class Editar : Lcc.Edicion.ControlEdicion
        {
                protected internal string TipoPredet = null;
                protected bool m_DiscriminarIva = false, m_AplicaIva = true;

                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Comprobantes.ComprobanteConArticulos);

                        InitializeComponent();
                }


                public Editar(string tipo)
                        : this()
                {
                        TipoPredet = tipo;
                }

                private bool IgnorarEventos = false;

                protected override void OnLoad(EventArgs e)
                {
                        base.OnLoad(e);
                        if (Lfx.Workspace.Master != null && Lfx.Workspace.Master.CurrentConfig != null) {
                                EntradaTotal.DecimalPlaces = Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal;
                                EntradaProductos.BloquearPrecio = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Documentos.CambiaPrecioItemFactura", 0) == 0 && Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(this.ElementoTipo, Lbl.Sys.Permisos.Operaciones.EditarAvanzado) == false;
                        }
                }

                public override Lfx.Types.OperationResult ValidarControl()
                {
                        Lfx.Types.OperationResult Res = base.ValidarControl();
                        Lbl.Entidades.Pais PaisActual = new Lbl.Entidades.Pais(this.Connection, Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Pais", 1));

                        if (EntradaVendedor.ValueInt == 0) {
                                Res.Success = false;
                                Res.Message += "Seleccione un vendedor." + Environment.NewLine;
                        }

                        if (EntradaCliente.ValueInt == 0) {
                                Res.Success = false;
                                Res.Message += "Seleccione un cliente." + Environment.NewLine;
                        }

                        if (EntradaTotal.ValueDecimal <= 0) {
                                Res.Success = false;
                                Res.Message += "El comprobante debe tener un importe superior a " + PaisActual.Moneda.Simbolo + " 0.00." + Environment.NewLine;
                        }

                        if (Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero.ContainsKey(EntradaPV.ValueInt) == false)
                                // Borro la caché de PV, por las dudas
                                Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero.Clear();

                        if (Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero.ContainsKey(EntradaPV.ValueInt) == false) {
                                Res.Success = false;
                                Res.Message += "Seleccione un punto de venta (PV) válido para este tipo de comprobante." + Environment.NewLine;
                        } else {
                                int PV = EntradaPV.ValueInt;
                                System.Data.DataTable PVAdmitidos = this.Connection.Select(@"SELECT * FROM pvs WHERE (
                                CONCAT(',', tipo_fac, ',') LIKE '%," + this.Tipo.Letra + @",%'
                                OR CONCAT(',', tipo_fac, ',') LIKE '%," + this.Tipo.TipoBase + @",%'
                                OR CONCAT(',', tipo_fac, ',') LIKE '%," + this.Tipo.Nomenclatura + @",%'
                                ) AND tipo>0");
                                if (PVAdmitidos.Rows.Count > 0) {
                                        bool Admitido = false;
                                        foreach (System.Data.DataRow PVAdmitido in PVAdmitidos.Rows) {
                                                if (System.Convert.ToInt32(PVAdmitido["numero"]) == PV) {
                                                        Admitido = true;
                                                        break;
                                                }
                                        }

                                        if (Admitido == false) {
                                                Res.Success = false;
                                                Res.Message += "Seleccione un punto de venta (PV) válido para este tipo de comprobante." + Environment.NewLine;
                                        }
                                }
                        }

                        Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
                        if (Comprob.Tipo.MueveExistencias != 0) {
                                if (Comprob.SituacionOrigen == null || Comprob.SituacionDestino == null || Comprob.SituacionOrigen.Id == Comprob.SituacionDestino.Id) {
                                        Res.Success = false;
                                        Res.Message += "Seleccione la situación de origen y de destino (usando el botón Más datos)." + Environment.NewLine;
                                }
                        }

                        return Res;
                }


                public override void ActualizarControl()
                {
                        IgnorarEventos = true;

                        Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;

                        this.SuspendLayout();

                        EntradaPV.Text = Comprob.PV.ToString();
                        EntradaVendedor.Elemento = Comprob.Vendedor;

                        Ignorar_EntradaCliente_TextChanged = true;
                        EntradaCliente.Elemento = Comprob.Cliente;
                        Ignorar_EntradaCliente_TextChanged = false;

                        if (this.DiscriminarIva) {
                                EntradaSubTotal.ValueDecimal = Comprob.SubtotalSinIva;
                                EntradaIva.ValueDecimal = Comprob.ImporteIvaDiscriminado;
                        } else {
                                EntradaSubTotal.ValueDecimal = Comprob.SubtotalSinIva + Comprob.ImporteIva;
                                EntradaIva.ValueDecimal = 0m;
                        }
                        EntradaDescuento.ValueDecimal= Comprob.Descuento;
                        EntradaInteres.ValueDecimal = Comprob.Recargo;
                        EntradaCuotas.ValueInt = Comprob.Cuotas;

                        EntradaSubTotalIva.ValueDecimal = EntradaSubTotal.ValueDecimal + EntradaIva.ValueDecimal;
                        EntradaTotal.ValueDecimal = Comprob.Total;

                        if (this.Elemento.Existe == true || this.PuedeEditar() == false) {
                                // No actualizar automáticamente detalles
                                EntradaProductos.AutoUpdate = false;
                        } else {
                                EntradaProductos.AutoUpdate = true;
                        }

                        // Cargo el detalle del comprobante
                        EntradaProductos.CargarArticulos(Comprob.Articulos);

                        this.ResumeLayout();

                        this.PonerTitulo();
                        base.ActualizarControl();

                        IgnorarEventos = false;
                }

                public override bool PuedeEditar()
                {
                        Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;

                        if (Comprob.Estado != 0)
                                return false;
                        else if (Comprob.Impreso && Comprob.Tipo != null && Comprob.Tipo.PermiteModificarImpresos == false)
                                return false;
                        else
                                return base.PuedeEditar();
                }

                public override bool PuedeImprimir()
                {
                        Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;

                        if (Comprob.Tipo != null && Comprob.Tipo.PermiteImprimirVariasVeces == false && Comprob.Impreso)
                                return false;
                        else
                                return base.PuedeImprimir();
                }

                public override void ActualizarElemento()
                {
                        Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;

                        Comprob.PV = EntradaPV.ValueInt;
                        Comprob.Vendedor = new Lbl.Personas.Persona(Comprob.Connection, EntradaVendedor.ValueInt);
                        Comprob.Cliente = new Lbl.Personas.Persona(Comprob.Connection, EntradaCliente.ValueInt);

                        Comprob.Descuento = EntradaDescuento.ValueDecimal;
                        Comprob.Recargo = EntradaInteres.ValueDecimal;
                        Comprob.Cuotas = EntradaCuotas.ValueInt;

                        Comprob.Articulos = EntradaProductos.ObtenerArticulos(Comprob);

                        base.ActualizarElemento();
                }


                /// <summary>
                /// Indica si debe mostrar el IVA discriminado.
                /// </summary>
                public bool DiscriminarIva
                {
                        get
                        {
                                return m_DiscriminarIva;
                        }
                        set
                        {
                                m_DiscriminarIva = value;
                                EntradaProductos.DiscriminarIva = value;
                                this.RecalcularTotal(this, null);
                        }
                }


                /// <summary>
                /// Indica si debe aplicar IVA al cliente.
                /// </summary>
                public bool AplicaIva
                {
                        get
                        {
                                return m_AplicaIva;
                        }
                        set
                        {
                                EntradaProductos.AplicaIva = value;
                                this.RecalcularTotal(this, null);
                        }
                }



                public override bool TemporaryReadOnly
                {
                        get
                        {
                                return base.TemporaryReadOnly;
                        }
                        set
                        {
                                EntradaProductos.TemporaryReadOnly = value;
                                base.TemporaryReadOnly = value;
                        }
                }

                private void PonerTitulo()
                {
                        Lbl.Comprobantes.ComprobanteConArticulos Registro = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
                        string NuevoTitulo = "";

                        if (Registro.Tipo != null) {
                                NuevoTitulo += Registro.Tipo.NombreLargo;
                        }

                        if (Registro.Numero > 0) {
                                NuevoTitulo += " ";

                                if (Registro.PV > 0)
                                        NuevoTitulo += Registro.PV.ToString("0000") + "-";

                                NuevoTitulo += Registro.Numero.ToString("00000000");
                        } else {
                                if (Registro.PV > 0)
                                        NuevoTitulo += " PV " + Registro.PV.ToString("0000");
                        }

                        this.Text = NuevoTitulo;
                }


                private void EditarObs()
                {
                        Lui.Forms.AuxForms.TextEdit EditarObs = new Lui.Forms.AuxForms.TextEdit();
                        if (((Lbl.ICamposBaseEstandar)(this.Elemento)).Obs != null)
                                EditarObs.EditText = ((Lbl.ICamposBaseEstandar)(this.Elemento)).Obs;
                        else
                                EditarObs.EditText = "";
                        EditarObs.ReadOnly = EntradaCliente.TemporaryReadOnly;

                        if (EditarObs.ShowDialog() == DialogResult.OK) {
                                if (EditarObs.EditText.Length > 0)
                                        ((Lbl.ICamposBaseEstandar)(this.Elemento)).Obs = EditarObs.EditText;
                                else
                                        ((Lbl.ICamposBaseEstandar)(this.Elemento)).Obs = null;
                        }
                }

                private void Convertir()
                {
                        Comprobantes.Convertir FormConvertir = new Comprobantes.Convertir();
                        FormConvertir.OrigenTipo = this.Tipo.Nomenclatura;
                        FormConvertir.DestinoTipo = "F";
                        FormConvertir.OrigenNombre = this.Elemento.ToString();

                        if (FormConvertir.ShowDialog() == DialogResult.OK) {
                                string ConvertirEnTipo = FormConvertir.DestinoTipo;
                                if (ConvertirEnTipo == "F" || ConvertirEnTipo == "NC" || ConvertirEnTipo == "ND") {
                                        if (this.Tipo.Letra.Length > 0 && "ABCEM".IndexOf(this.Tipo.Letra) >= 0) {
                                                ConvertirEnTipo += this.Tipo.Letra;
                                        } else {
                                                Lbl.Comprobantes.ComprobanteConArticulos Compr = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
                                                if (Compr != null && Compr.Cliente != null && Compr.Cliente.LetraPredeterminada().Length > 0)
                                                        ConvertirEnTipo += Compr.Cliente.LetraPredeterminada();
                                                else
                                                        ConvertirEnTipo += "B";
                                        }
                                }
                                Lfx.Types.OperationResult Resultado = ConvertirEn(ConvertirEnTipo);

                                if (Resultado.Success == false)
                                        Lui.Forms.MessageBox.Show(Resultado.Message, "Error");
                        }
                }

                internal virtual Lfx.Types.OperationResult ConvertirEn(string tipoComprob)
                {
                        Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
                        if (Comprob.Existe) {
                                Lbl.Comprobantes.Tipo NuevoTipo = Lbl.Comprobantes.Tipo.TodosPorLetra[tipoComprob];
                                Lbl.Comprobantes.ComprobanteConArticulos Nuevo = Comprob.Convertir(NuevoTipo) as Lbl.Comprobantes.ComprobanteConArticulos;

                                FormularioEdicion NuevoComprob = Instanciador.InstanciarFormularioEdicion(Nuevo);
                                NuevoComprob.ControlDestino = EntradaComprobanteId;
                                NuevoComprob.MdiParent = this.ParentForm.MdiParent;
                                NuevoComprob.Show();
                                return new Lfx.Types.SuccessOperationResult();
                        } else {
                                return new Lfx.Types.FailureOperationResult("Debe guardar el comprobante antes de poder convertirlo.");
                        }
                }


                private void EntradaProductos_TotalChanged(System.Object sender, System.EventArgs e)
                {
                        if (this.TemporaryReadOnly == false) {
                                EntradaSubTotal.ValueDecimal = EntradaProductos.Total_ImporteUnitarioFinal;

                                if(this.DiscriminarIva) {
                                        var ImporteIva = EntradaProductos.Total_ImporteIvaFinal;
                                        EntradaIva.ValueDecimal = ImporteIva;
                                        EntradaSubTotalIva.ValueDecimal = Math.Round(EntradaSubTotal.ValueDecimal + ImporteIva, Lbl.Sys.Config.Moneda.DecimalesFinal);
                                } else {
                                        EntradaIva.ValueDecimal = 0m;
                                        EntradaSubTotalIva.ValueDecimal = EntradaSubTotal.ValueDecimal;
                                }

                                this.RecalcularTotal(this, null);
                        }
                }


                private bool Ignorar_EntradaCliente_TextChanged = false;
                private void EntradaCliente_TextChanged(object sender, System.EventArgs e)
                {
                        if (Ignorar_EntradaCliente_TextChanged)
                                return;

                        Lbl.Personas.Persona Cliente = EntradaCliente.Elemento as Lbl.Personas.Persona;

                        if (Cliente != null && Cliente.Grupo != null && Cliente.Grupo.Descuento > 0 && EntradaDescuento.ValueDecimal == 0) {
                                EntradaDescuento.ValueDecimal = Cliente.Grupo.Descuento;
                                // TODO: EntradaDescuento.ShowBalloon("Se aplicó el descuento que corresponde al tipo de cliente.");
                        }

                        if(Cliente != null) {
                                EntradaProductos.AplicaIva = Cliente.ObtenerSituacionIva() != Lbl.Impuestos.SituacionIva.Exento;
                        }

                        if (this.Tipo != null && this.Tipo.EsFacturaNCoND && this.Elemento.Existe == false && Cliente != null) {
                                string LetraComprob = Cliente.LetraPredeterminada();

                                switch (LetraComprob) {
                                        case "A":
                                        case "B":
                                        case "C":
                                        case "M":
                                        case "E":
                                                string NuevoTipoComprob = "NC" + LetraComprob;
                                                if (this.Tipo.EsNotaCredito) {
                                                        NuevoTipoComprob = "NC" + LetraComprob;
                                                } else if (this.Tipo.EsNotaDebito) {
                                                        NuevoTipoComprob = "NF" + LetraComprob;
                                                } else {
                                                        NuevoTipoComprob = "F" + LetraComprob;
                                                }
                                                if (Lbl.Comprobantes.Tipo.TodosPorLetra.ContainsKey(NuevoTipoComprob))
                                                        this.Tipo = Lbl.Comprobantes.Tipo.TodosPorLetra[NuevoTipoComprob];
                                                break;
                                }
                        }

                        // Recalculo el IVA
                        EntradaProductos_TotalChanged(sender, e);
                }


                private void EditarMasDatos()
                {
                        Lbl.Comprobantes.ComprobanteConArticulos Registro = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
                        using (Comprobantes.FormComprobanteMasDatos FormMasDatos = new Comprobantes.FormComprobanteMasDatos()) {
                                FormMasDatos.Owner = this.ParentForm;
                                FormMasDatos.EntradaDesdeSituacion.Elemento = Registro.SituacionOrigen;
                                FormMasDatos.EntradaHaciaSituacion.Elemento = Registro.SituacionDestino;
                                FormMasDatos.EntradaDesdeSituacion.TemporaryReadOnly = EntradaCliente.TemporaryReadOnly;
                                FormMasDatos.EntradaHaciaSituacion.TemporaryReadOnly = EntradaCliente.TemporaryReadOnly;
                                FormMasDatos.EntradaBloqueada.TextKey = ((Lbl.ICamposBaseEstandar)(this.Elemento)).Estado.ToString();

                                if (Registro.Tipo.EsFactura)
                                        FormMasDatos.EntradaDesdeSituacion.Filter = "facturable=1";
                                else
                                        FormMasDatos.EntradaDesdeSituacion.Filter = "";

                                if (FormMasDatos.ShowDialog() == DialogResult.OK) {
                                        Lbl.Articulos.Situacion NuevoOrigen = FormMasDatos.EntradaDesdeSituacion.Elemento as Lbl.Articulos.Situacion;
                                        if ((NuevoOrigen == null && Registro.SituacionOrigen != null)
                                                || (NuevoOrigen != null && Registro.SituacionOrigen == null)
                                                || (NuevoOrigen != null && NuevoOrigen.Id != Registro.SituacionOrigen.Id)) {
                                                // Cambió la situación de origen... borro los datos de seguimiento
                                                EntradaProductos.BorrarDatosDeSeguimiento();
                                        }
                                        Registro.SituacionOrigen = NuevoOrigen;
                                        Registro.SituacionDestino = FormMasDatos.EntradaHaciaSituacion.Elemento as Lbl.Articulos.Situacion;
                                        ((Lbl.ICamposBaseEstandar)(this.Elemento)).Estado = Lfx.Types.Parsing.ParseInt(FormMasDatos.EntradaBloqueada.TextKey);
                                        this.TemporaryReadOnly = Lfx.Types.Parsing.ParseInt(FormMasDatos.EntradaBloqueada.TextKey) != 0;
                                }
                        }
                }


                internal virtual void RecalcularTotal(object sender, System.EventArgs e)
                {
                        if (IgnorarEventos)
                                return;

                        IgnorarEventos = true;

                        decimal Descuento = EntradaDescuento.ValueDecimal / 100m;
                        decimal Recargo = EntradaInteres.ValueDecimal / 100m;
                        decimal SubTotal = EntradaSubTotalIva.ValueDecimal;

                        decimal Total = SubTotal * (1 + Recargo - Descuento);
                        if (Lbl.Sys.Config.Moneda.UnidadMonetariaMinima > 0) {
                                Total = Math.Floor(Total / Lbl.Sys.Config.Moneda.UnidadMonetariaMinima) * Lbl.Sys.Config.Moneda.UnidadMonetariaMinima;
                        }

                        EntradaTotal.ValueDecimal = Total;

                        int Cuotas = EntradaCuotas.ValueInt;
                        if (Cuotas > 0)
                                EntradaValorCuota.ValueDecimal = Total / Cuotas;
                        else
                                EntradaValorCuota.ValueDecimal = 0m;

                        IgnorarEventos = false;
                }


                private void EntradaTotal_TextChanged(object sender, System.EventArgs e)
                {
                        if (IgnorarEventos)
                                return;

                        IgnorarEventos = true;
                        if (EntradaSubTotal.ValueDecimal > 0) {
                                decimal Descuento = (EntradaTotal.ValueDecimal - EntradaIva.ValueDecimal) / EntradaSubTotal.ValueDecimal;
                                if (Descuento < 1) {
                                        EntradaDescuento.ValueDecimal = (1 - Descuento) * 100m;
                                        EntradaInteres.ValueDecimal = 0m;
                                } else {
                                        EntradaInteres.ValueDecimal = (Descuento - 1) * 100m;
                                        EntradaDescuento.ValueDecimal = 0m;
                                        // TODO: EntradaInteres.ShowBalloon("Se aplicó un recargo.");
                                }
                        }
                        IgnorarEventos = false;
                }


                [EditorBrowsable(EditorBrowsableState.Never), System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public virtual Lbl.Comprobantes.Tipo Tipo
                {
                        get
                        {
                                Lbl.Comprobantes.ComprobanteConArticulos Registro = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
                                if (Registro == null)
                                        return null;
                                return Registro.Tipo;
                        }
                        set
                        {
                                if (this.Elemento != null) {
                                        Lbl.Comprobantes.ComprobanteConArticulos Registro = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;
                                        Registro.Tipo = value;
                                        PnlCuotas.Visible = value.EsPresupuesto;
                                        this.PonerTitulo();
                                }
                        }
                }


                public override void AfterSave(System.Data.IDbTransaction transaction)
                {
                        Lbl.Comprobantes.Comprobante Comprob = this.Elemento as Lbl.Comprobantes.Comprobante;
                        if (Comprob != null && Comprob.Tipo != null && Comprob.Tipo.ImprimirAlGuardar) {
                                if (transaction == null) {
                                        using (transaction = this.Connection.BeginTransaction()) {
                                                var Controlador = new Lazaro.Base.Controller.ComprobanteController(transaction);
                                                Controlador.Imprimir(Comprob, null);
                                                transaction.Commit();
                                                transaction = null;
                                        }
                                } else {
                                        var Controlador = new Lazaro.Base.Controller.ComprobanteController(transaction);
                                        Controlador.Imprimir(Comprob, null);
                                }
                        }
                }


                private void EntradaProductos_ObtenerDatosSeguimiento(object sender, EventArgs e)
                {
                        Lcc.Entrada.Articulos.DetalleComprobante Prod = sender as Lcc.Entrada.Articulos.DetalleComprobante;

                        if (Prod == null)
                                return;

                        int IdArticulo = Prod.ValueInt;

                        if (IdArticulo == 0)
                                return;

                        decimal Cant = Prod.Cantidad;

                        Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;

                        Lfc.Articulos.EditarSeguimiento Editar = new Lfc.Articulos.EditarSeguimiento();
                        Editar.Connection = this.Connection;
                        Editar.Articulo = new Lbl.Articulos.Articulo(this.Connection, IdArticulo);
                        Editar.Cantidad = Math.Abs(System.Convert.ToInt32(Cant));
                        Editar.SituacionOrigen = Comprob.SituacionOrigen;
                        Editar.DatosSeguimiento = Prod.DatosSeguimiento;
                        if (Editar.ShowDialog() == DialogResult.OK) {
                                Prod.DatosSeguimiento = Editar.DatosSeguimiento;
                        }
                }


                public override Lazaro.Pres.Forms.FormActionCollection GetFormActions()
                {
                        Lazaro.Pres.Forms.FormActionCollection Res = base.GetFormActions();
                        Res.Add(new Lazaro.Pres.Forms.FormAction("Observaciones", "F7", "obs", 20, Lazaro.Pres.Forms.FormActionVisibility.Secondary));
                        Res.Add(new Lazaro.Pres.Forms.FormAction("Más datos", "F5", "masdatos", 10, Lazaro.Pres.Forms.FormActionVisibility.Secondary));
                        Res.Add(new Lazaro.Pres.Forms.FormAction("Convertir", "F4", "convertir", 50, Lazaro.Pres.Forms.FormActionVisibility.Secondary));
                        return Res;
                }


                public override Lfx.Types.OperationResult PerformFormAction(string name)
                {
                        switch(name)
                        {
                                case "obs":
                                        EditarObs();
                                        return new Lfx.Types.SuccessOperationResult();
                                case "masdatos":
                                        EditarMasDatos();
                                        return new Lfx.Types.SuccessOperationResult();
                                case "convertir":
                                        Convertir();
                                        return new Lfx.Types.SuccessOperationResult();
                                default:
                                        return base.PerformFormAction(name);
                        }
                }


                public override Lazaro.Pres.DisplayStyles.IDisplayStyle HeaderDisplayStyle
                {
                        get
                        {
                                return Lazaro.Pres.DisplayStyles.Template.Current.Comprobantes;
                        }
                }
        }
}