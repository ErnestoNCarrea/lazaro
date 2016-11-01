using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;

namespace Lcc.Entrada.Articulos
{
        public partial class DetalleComprobante : ControlSeleccionElemento
        {
                protected bool m_MostrarExistencias, m_DiscriminarIva = false, m_AplicarIva = true;
                protected Precios m_Precio = Precios.Pvp;
                protected ControlesSock m_ControlStock = ControlesSock.Ambos;
                protected Lbl.Articulos.ColeccionDatosSeguimiento m_DatosSeguimiento = new Lbl.Articulos.ColeccionDatosSeguimiento();
                protected Lbl.Impuestos.Alicuota m_Alicuota = null;
                protected decimal m_ImporteUnitarioIva = 0m;

                new public event System.Windows.Forms.KeyEventHandler KeyDown;
                public event System.EventHandler ImportesChanged;
                public event System.EventHandler ObtenerDatosSeguimiento;

                public DetalleComprobante()
                {
                        InitializeComponent();
                }


                protected override void OnLoad(EventArgs e)
                {
                        base.OnLoad(e);
                        if (Lfx.Workspace.Master != null) {
                                switch (m_Precio) {
                                        case Precios.Costo:
                                                EntradaUnitario.DecimalPlaces = Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesCosto;
                                                EntradaImporte.DecimalPlaces = Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesCosto;
                                                break;
                                        case Precios.Pvp:
                                                EntradaUnitario.DecimalPlaces = Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales;
                                                EntradaImporte.DecimalPlaces = Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales;
                                                break;
                                }
                        }
                }

                public ControlesSock ControlStock
                {
                        get
                        {
                                return m_ControlStock;
                        }
                        set
                        {
                                m_ControlStock = value;
                                PonerFiltros();
                        }
                }

                [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                override public bool ShowChanged
                {
                        set
                        {
                                base.ShowChanged = value;
                                EntradaArticulo.ShowChanged = value;
                                EntradaDescuento.ShowChanged = value;
                                EntradaCantidad.ShowChanged = value;
                                EntradaUnitario.ShowChanged = value;
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public bool AutoUpdate
                {
                        get
                        {
                                return EntradaArticulo.AutoUpdate;
                        }
                        set
                        {
                                EntradaArticulo.AutoUpdate = value;
                        }
                }


                public bool PermiteCrear
                {
                        get
                        {
                                return EntradaArticulo.CanCreate;
                        }
                        set
                        {
                                EntradaArticulo.CanCreate = value;
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public override bool IsEmpty
                {
                        get
                        {
                                return EntradaArticulo.IsEmpty;
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                new public int ValueInt
                {
                        get
                        {
                                return EntradaArticulo.ValueInt;
                        }
                        set
                        {
                                if (EntradaArticulo.ValueInt != value)
                                        EntradaArticulo.ValueInt = value;
                        }
                }

                [EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public Lbl.Articulos.ColeccionDatosSeguimiento DatosSeguimiento
                {
                        get
                        {
                                return m_DatosSeguimiento;
                        }
                        set
                        {
                                if (m_DatosSeguimiento != value) {
                                        this.Changed = true;
                                }
                                m_DatosSeguimiento = value;
                                if (m_DatosSeguimiento == null || m_DatosSeguimiento.Count == 0) {
                                        LabelSerials.Visible = false;
                                } else {
                                        LabelSerials.Text = "Seguimiento: " + m_DatosSeguimiento.ToString();
                                        LabelSerials.Visible = true;
                                        if (this.Cantidad != m_DatosSeguimiento.CantidadTotal)
                                                this.Cantidad = m_DatosSeguimiento.CantidadTotal;
                                }
                        }
                }

                public bool MuestraPrecio
                {
                        get
                        {
                                return EntradaUnitario.Visible;
                        }
                        set
                        {
                                EntradaUnitario.Visible = value;
                                EntradaIva.Visible = value;
                                EntradaCantidad.Visible = value;
                                EntradaDescuento.Visible = value;
                                EntradaImporte.Visible = value;
                                if (value)
                                        EntradaArticulo.Width = EntradaUnitario.Left - 1;
                                else
                                        EntradaArticulo.Width = this.Width;
                        }
                }


                // Oculta al changed de abajo
                [EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                new public bool Changed
                {
                        get
                        {
                                return EntradaArticulo.Changed || EntradaCantidad.Changed || EntradaUnitario.Changed || EntradaDescuento.Changed;
                        }
                        set
                        {
                                EntradaArticulo.Changed = value;
                                EntradaDescuento.Changed = value;
                                EntradaCantidad.Changed = value;
                                EntradaUnitario.Changed = value;
                        }
                }

                public Precios UsarPrecio
                {
                        get
                        {
                                return m_Precio;
                        }
                        set
                        {
                                m_Precio = value;
                                this.CambiarArticulo(this.Articulo);
                                this.Changed = false;
                        }
                }


                public bool BloquearAtriculo
                {
                        get
                        {
                                return EntradaArticulo.TemporaryReadOnly;
                        }
                        set
                        {
                                EntradaArticulo.TemporaryReadOnly = value;
                        }
                }


                public bool BloquearCantidad
                {
                        get
                        {
                                return EntradaCantidad.TemporaryReadOnly;
                        }
                        set
                        {
                                EntradaCantidad.TemporaryReadOnly = value;
                        }
                }


                public bool BloquearPrecio
                {
                        get
                        {
                                return EntradaUnitario.TemporaryReadOnly;
                        }
                        set
                        {
                                EntradaUnitario.ReadOnly = value;
                                EntradaDescuento.ReadOnly = value || this.BloquearDescuento;
                        }
                }


                public bool BloquearDescuento
                {
                        get
                        {
                                return EntradaDescuento.TemporaryReadOnly;
                        }
                        set
                        {
                                EntradaDescuento.ReadOnly = value || this.BloquearPrecio;
                        }
                }


                public bool MostrarExistencias
                {
                        get
                        {
                                return m_MostrarExistencias;
                        }
                        set
                        {
                                m_MostrarExistencias = value;
                                VerificarStock();
                        }
                }


                /// <summary>
                /// Indica si los precios se muestran con IVA discriminado.
                /// </summary>
                public bool DiscriminarIva
                {
                        get
                        {
                                return m_DiscriminarIva;
                        }
                        set
                        {
                                bool AntesDiscriminaba = m_DiscriminarIva;
                                m_DiscriminarIva = value;
                                EntradaIva.Enabled = this.DiscriminarIva && this.AplicarIva;

                                if (m_DiscriminarIva != AntesDiscriminaba && m_AplicarIva && m_Alicuota != null) {
                                        if (value) {
                                                // Antes no discriminaba y ahora sí
                                                this.EstablecerImporteUnitarioOriginal(this.ImporteUnitario / (1 + m_Alicuota.Porcentaje / 100m));
                                        } else {
                                                // Antes discriminaba y ahora no
                                                this.EstablecerImporteUnitarioOriginal(this.ImporteUnitario);
                                        }

                                        this.RecalcularImporteFinal();

                                        if (null != ImportesChanged) {
                                                ImportesChanged(this, null);
                                        }
                                }

                                this.RecalcularImporteFinal();
                        }
                }


                /// <summary>
                /// Indica si debe aplicar IVA al cliente.
                /// </summary>
                public bool AplicarIva
                {
                        get
                        {
                                return m_AplicarIva;
                        }
                        set
                        {
                                bool AntesAplicaba = m_AplicarIva;
                                m_AplicarIva = value;
                                EntradaIva.Enabled = this.DiscriminarIva && this.AplicarIva;

                                if (m_AplicarIva != AntesAplicaba && m_Alicuota != null) {
                                        decimal NuevoImporteUnitarioIva = this.ImporteUnitario * (m_Alicuota.Porcentaje / 100m);
                                        if (value) {
                                                // Antes no aplicaba y ahora sí
                                                this.EstablecerImporteUnitarioOriginal(this.ImporteUnitario);
                                        } else {
                                                // Antes aplicaba y ahora no
                                                this.EstablecerImporteUnitarioOriginal((this.ImporteUnitario + this.ImporteIvaDiscriminadoUnitario) / (1m + m_Alicuota.Porcentaje / 100m));
                                        }

                                        this.RecalcularImporteFinal();

                                        if (null != ImportesChanged) {
                                                ImportesChanged(this, null);
                                        }
                                }
                        }
                }


                public bool Required
                {
                        get
                        {
                                return EntradaArticulo.Required;
                        }
                        set
                        {
                                EntradaArticulo.Required = value;
                        }
                }

                [System.ComponentModel.Category("Datos")]
                public string FreeTextCode
                {
                        get
                        {
                                return EntradaArticulo.FreeTextCode;
                        }
                        set
                        {
                                EntradaArticulo.FreeTextCode = value;
                        }
                }

                public int UnitarioLeft
                {
                        get
                        {
                                return EntradaUnitario.Left;
                        }
                }

                public int DescuentoLeft
                {
                        get
                        {
                                return EntradaDescuento.Left;
                        }
                }

                public int CantidadLeft
                {
                        get
                        {
                                return EntradaCantidad.Left;
                        }
                }

                public int IvaLeft
                {
                        get
                        {
                                return EntradaIva.Left;
                        }
                }

                public int ImporteLeft
                {
                        get
                        {
                                return EntradaImporte.Left;
                        }
                }

                public override string Text
                {
                        get
                        {
                                if (EntradaArticulo.Text == EntradaArticulo.FreeTextCode && EntradaArticulo.FreeTextCode.Length > 0)
                                        return EntradaArticulo.Text;
                                else
                                        return EntradaArticulo.ValueInt.ToString();
                        }
                        set
                        {
                                if (EntradaArticulo.Text != value) {
                                        EntradaArticulo.Text = value;
                                }
                                this.Changed = false;
                        }
                }
                public string TextDetail
                {
                        get
                        {
                                return EntradaArticulo.TextDetail;
                        }
                        set
                        {
                                EntradaArticulo.TextDetail = value;
                                this.Changed = false;
                        }
                }


                /// <summary>
                /// El importe final, con IVA, por cantidad y con descuento.
                /// </summary>
                [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public decimal ImporteFinal
                {
                        get
                        {
                                return EntradaImporte.ValueDecimal;
                        }
                        set
                        {
                                EntradaImporte.ValueDecimal = value;
                                this.Changed = false;
                        }
                }

                /// <summary>
                /// El importe de IVA unitario (sin descuento).
                /// </summary>
                [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public decimal ImporteIvaUnitario
                {
                        get
                        {
                                return this.m_ImporteUnitarioIva;
                        }
                        set
                        {
                                this.m_ImporteUnitarioIva = value;
                                if(this.DiscriminarIva) {
                                        this.EntradaUnitarioIvaDescuentoCantidad_TextChanged(this, null);
                                }
                                this.Changed = false;
                        }
                }

                /// <summary>
                /// El importe de IVA discriminado unitario (sin descuento), o 0 si el IVA no está discriminado.
                /// </summary>
                [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public decimal ImporteIvaDiscriminadoUnitario
                {
                        get
                        {
                                return EntradaIva.ValueDecimal;
                        }
                        set
                        {
                                EntradaIva.ValueDecimal = value;
                                this.Changed = false;
                        }
                }

                /// <summary>
                /// El importe de IVA final, por cantidad y con descuento.
                /// </summary>
                [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public decimal ImporteIvaUnitarioFinal
                {
                        get
                        {
                                return this.ImporteIvaUnitario * this.Cantidad * (1m - this.Descuento / 100m);
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public decimal ImporteUnitario
                {
                        get
                        {
                                return EntradaUnitario.ValueDecimal;
                        }
                        set
                        {
                                EntradaUnitario.ValueDecimal = value;
                                this.Changed = false;
                        }
                }

                /// <summary>
                /// El importe unitario final, por cantidad y con descuento.
                /// </summary>
                [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public decimal ImporteUnitarioFinal
                {
                        get
                        {
                                return this.ImporteUnitario * this.Cantidad * (1m - this.Descuento / 100m);
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public decimal Descuento
                {
                        get
                        {
                                return EntradaDescuento.ValueDecimal;
                        }
                        set
                        {
                                EntradaDescuento.ValueDecimal = value;
                                this.Changed = false;
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public Lbl.Articulos.Articulo Articulo
                {
                        get
                        {
                                return EntradaArticulo.Elemento as Lbl.Articulos.Articulo;
                        }
                        set
                        {
                                EntradaArticulo.Elemento = value;
                                this.Elemento = value;
                                if(value == null) {
                                        this.m_Alicuota = null;
                                } else {
                                        this.m_Alicuota = value.ObtenerAlicuota();
                                }
                                EntradaArticulo_TextChanged(this, null);
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public Lbl.Impuestos.Alicuota Alicuota
                {
                        get
                        {
                                return m_Alicuota;
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public decimal Cantidad
                {
                        get
                        {
                                if (this.EstoyUsandoUnidadPrimaria())
                                        return EntradaCantidad.ValueDecimal;
                                else
                                        return EntradaCantidad.ValueDecimal / Articulo.Rendimiento;
                        }
                        set
                        {
                                if (this.EstoyUsandoUnidadPrimaria())
                                        EntradaCantidad.ValueDecimal = value;
                                else
                                        EntradaCantidad.ValueDecimal = value * this.Articulo.Rendimiento;
                                this.Changed = false;
                        }
                }

                private bool EstoyUsandoUnidadPrimaria()
                {
                        return (this.Articulo == null || Articulo.Unidad == null || EntradaCantidad.Sufijo == Articulo.Unidad || (EntradaCantidad.Sufijo.Length == 0 && Articulo.Unidad == "u") || Articulo.Rendimiento == 0);

                }

                private void EntradaArticulo_TextChanged(object sender, System.EventArgs e)
                {
                        if (this.Connection == null)
                                return;

                        EntradaUnitario.TabStop = EntradaArticulo.IsFreeText;

                        if (this.Elemento != EntradaArticulo.Elemento || EntradaArticulo.IsFreeText) {
                                this.Elemento = EntradaArticulo.Elemento;
                                if (this.Articulo != null) {
                                        this.m_Alicuota = this.Articulo.ObtenerAlicuota();
                                }
                                this.CambiarArticulo(this.Articulo);
                        }

                        this.DatosSeguimiento = null;
                        this.Changed = true;
                        this.OnTextChanged(EventArgs.Empty);
                }


                private void EntradaUnitarioIvaDescuentoCantidad_TextChanged(object sender, System.EventArgs e)
                {
                        if (this.Connection != null) {
                                decimal ValorAnterior = EntradaImporte.ValueDecimal;
                                this.RecalcularImporteFinal();
                                this.VerificarStock();
                                if (EntradaImporte.ValueDecimal != ValorAnterior) {
                                        this.Changed = true;
                                        if (null != ImportesChanged) {
                                                ImportesChanged(this, null);
                                        }
                                }
                        }
                }


                private void VerificarStock()
                {
                        if (m_MostrarExistencias && Articulo != null) {
                                if (this.TemporaryReadOnly == false && this.Articulo.TipoDeArticulo != Lbl.Articulos.TiposDeArticulo.Servicio && this.Articulo.Existencias < this.Cantidad) {
                                        if (this.Articulo.Existencias + this.Articulo.Pedido >= this.Cantidad) {
                                                //EntradaArticulo.Font = null;
                                                EntradaArticulo.ForeColor = Color.OrangeRed;
                                        } else {
                                                //EntradaArticulo.Font = new Font(this.Font, FontStyle.Strikeout);
                                                EntradaArticulo.ForeColor = Color.Red;
                                        }
                                } else {
                                        //EntradaArticulo.Font = null;
                                        EntradaArticulo.ForeColor = this.DisplayStyle.TextColor;
                                }
                        } else {
                                //EntradaArticulo.Font = null;
                                EntradaArticulo.ForeColor = this.DisplayStyle.TextColor;
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
                                base.TemporaryReadOnly = value;
                                if (value) {
                                        EntradaArticulo.TemporaryReadOnly = true;
                                        EntradaUnitario.TemporaryReadOnly = true;
                                        EntradaDescuento.TemporaryReadOnly = true;
                                        EntradaCantidad.TemporaryReadOnly = true;
                                }
                                this.VerificarStock();
                        }
                }

                private void EntradaArticulo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
                {
                        if (e.Alt == false && e.Control == false && e.Shift == false) {
                                switch (e.KeyCode) {
                                        case Keys.Right:
                                        case Keys.Return:
                                                e.Handled = true;
                                                if (EntradaUnitario.Visible && this.ReadOnly == false && this.TemporaryReadOnly == false) {
                                                        if (this.BloquearPrecio)
                                                                EntradaCantidad.Focus();
                                                        else
                                                                EntradaUnitario.Focus();
                                                } else {
                                                        System.Windows.Forms.SendKeys.Send("{tab}");
                                                }
                                                break;
                                        default:
                                                if (KeyDown != null)
                                                        KeyDown(sender, e);
                                                this.AutoUpdate = true;
                                                break;
                                }
                        }
                        if (e.Alt == false && e.Control == true && e.Shift == false) {
                                switch (e.KeyCode) {
                                        case Keys.S:
                                                this.ObtenerDatosSeguimientoSiEsNecesario();
                                                break;
                                }
                        }
                }


                protected void ObtenerDatosSeguimientoSiEsNecesario()
                {
                        if (this.Articulo != null && this.Articulo.ObtenerSeguimiento() != Lbl.Articulos.Seguimientos.Ninguno && this.ObtenerDatosSeguimiento != null)
                                this.ObtenerDatosSeguimiento(this, new EventArgs());
                }


                protected override void OnLeave(EventArgs e)
                {
                        Lbl.Articulos.Articulo Art = this.Elemento as Lbl.Articulos.Articulo;

                        if (this.Cantidad != 0 && Art != null && Art.ObtenerSeguimiento() != Lbl.Articulos.Seguimientos.Ninguno && (this.DatosSeguimiento == null || this.DatosSeguimiento.Count != this.Cantidad)) {
                                this.ObtenerDatosSeguimientoSiEsNecesario();
                        }

                        base.OnLeave(e);
                }

                private void EntradaUnitario_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
                {
                        switch (e.KeyCode) {
                                case Keys.E:
                                        if (e.Control) {
                                                EntradaUnitario.SelectionLength = 0;
                                                EntradaUnitario.SelectionStart = EntradaUnitario.Text.Length;
                                                e.Handled = true;
                                        }
                                        break;
                                case Keys.Left:
                                        if (EntradaUnitario.SelectionStart == 0) {
                                                e.Handled = true;
                                                EntradaArticulo.Focus();
                                        }
                                        break;
                                case Keys.Right:
                                case Keys.Return:
                                        if (EntradaUnitario.SelectionStart >= EntradaUnitario.TextRaw.Length || EntradaUnitario.SelectionLength > 0) {
                                                e.Handled = true;
                                                EntradaCantidad.Focus();
                                        }
                                        break;
                                case Keys.Up:
                                        System.Windows.Forms.SendKeys.Send("+{tab}");
                                        break;
                                case Keys.Down:
                                        System.Windows.Forms.SendKeys.Send("{tab}");
                                        break;
                                default:
                                        if (null != KeyDown)
                                                KeyDown(sender, e);
                                        break;
                        }

                }

                private void EntradaDescuento_KeyDown(object sender, KeyEventArgs e)
                {
                        switch (e.KeyCode) {
                                case Keys.Left:
                                        if (EntradaDescuento.SelectionStart == 0) {
                                                e.Handled = true;
                                                EntradaCantidad.Focus();
                                        }
                                        break;
                                case Keys.Up:
                                        System.Windows.Forms.SendKeys.Send("+{tab}");
                                        break;
                                case Keys.Down:
                                        System.Windows.Forms.SendKeys.Send("{tab}");
                                        break;
                                default:
                                        if (null != KeyDown)
                                                KeyDown(sender, e);
                                        break;
                        }
                }


                private void EntradaCantidad_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
                {
                        switch (e.KeyCode) {
                                case Keys.Left:
                                        e.Handled = true;
                                        if (this.BloquearPrecio)
                                                EntradaArticulo.Focus();
                                        else
                                                EntradaUnitario.Focus();
                                        break;
                                case Keys.Right:
                                case Keys.Return:
                                        if (EntradaCantidad.SelectionStart >= EntradaCantidad.TextRaw.Length || EntradaCantidad.SelectionLength > 0) {
                                                if (this.BloquearPrecio == false) {
                                                        e.Handled = true;
                                                        EntradaDescuento.Focus();
                                                }
                                        }
                                        break;
                                case Keys.Up:
                                        System.Windows.Forms.SendKeys.Send("+{tab}");
                                        break;
                                case Keys.Down:
                                        System.Windows.Forms.SendKeys.Send("{tab}");
                                        break;
                                case Keys.D0:
                                case Keys.D1:
                                case Keys.D2:
                                case Keys.D3:
                                case Keys.D4:
                                case Keys.D5:
                                case Keys.D6:
                                case Keys.D7:
                                case Keys.D8:
                                case Keys.D9:
                                case Keys.Space:
                                        e.Handled = true;
                                        this.ObtenerDatosSeguimientoSiEsNecesario();
                                        break;
                                default:
                                        if (KeyDown != null)
                                                KeyDown(sender, e);
                                        break;
                        }
                }


                protected override void OnEnter(EventArgs e)
                {
                        base.OnEnter(e);
                        if (EntradaArticulo.Focused == false)
                                EntradaArticulo.Focus();
                }


                private void PonerFiltros()
                {
                        string Filtros = "";
                        switch (m_ControlStock) {
                                case ControlesSock.ConControlStock:
                                        Filtros += "control_stock=1";
                                        break;
                                case ControlesSock.SinControlStock:
                                        Filtros += "control_stock=0";
                                        break;
                        }

                        EntradaArticulo.Filter = Filtros;
                }


                private void RecalcularAltura(object sender, System.EventArgs e)
                {
                        LabelSerialsCruz.Visible = LabelSerials.Visible;
                        if (LabelSerials.Visible)
                                this.Height = this.LabelSerials.Bottom + this.EntradaArticulo.Top;
                        else
                                this.Height = this.EntradaArticulo.Bottom + this.EntradaArticulo.Top;
                }

                private void EntradaCantidad_KeyPress(object sender, KeyPressEventArgs e)
                {
                        if (e.KeyChar == ' ') {
                                if (Articulo != null) {
                                        if (this.EstoyUsandoUnidadPrimaria()) {
                                                //Cambio a unidad secundaria
                                                EntradaCantidad.Sufijo = Articulo.UnidadRendimiento;
                                                EntradaCantidad.Text = Lfx.Types.Formatting.FormatStock(Lfx.Types.Parsing.ParseStock(EntradaCantidad.Text) * this.Articulo.Rendimiento);
                                        } else {
                                                //Cambio a unidad primaria
                                                EntradaCantidad.Sufijo = Articulo.Unidad == "u" ? "" : Articulo.Unidad;
                                                EntradaCantidad.Text = Lfx.Types.Formatting.FormatStock(Lfx.Types.Parsing.ParseStock(EntradaCantidad.Text) / this.Articulo.Rendimiento, 4);
                                        }
                                        e.Handled = true;
                                }
                        }
                }

                private void EntradaCantidad_Click(object sender, EventArgs e)
                {
                        this.ObtenerDatosSeguimientoSiEsNecesario();
                }


                protected void CambiarArticulo(Lbl.Articulos.Articulo articulo)
                {
                        if (this.Articulo != null) {
                                EntradaUnitario.Enabled = true;
                                EntradaUnitario.Enabled = true;
                                EntradaDescuento.Enabled = true;
                                EntradaCantidad.Enabled = true;
                                EntradaImporte.Enabled = true;
                                EntradaCantidad.TemporaryReadOnly = this.Articulo.ObtenerSeguimiento() != Lbl.Articulos.Seguimientos.Ninguno || this.TemporaryReadOnly;
                                EntradaUnitario.TemporaryReadOnly = this.TemporaryReadOnly || this.BloquearPrecio;
                                EntradaDescuento.TemporaryReadOnly = this.TemporaryReadOnly || this.BloquearPrecio;
                                if (this.AutoUpdate) {
                                        if (this.Articulo == null) {
                                                return;
                                        }

                                        if (this.Articulo.Unidad != "u") {
                                                EntradaCantidad.Sufijo = Articulo.Unidad;
                                        } else {
                                                EntradaCantidad.Sufijo = "";
                                        }

                                        decimal UnitarioMostrar;
                                        if (m_Precio == Precios.Costo) {
                                                UnitarioMostrar = Articulo.Costo;
                                        } else {
                                                UnitarioMostrar = Articulo.Pvp;
                                        }

                                        if (this.Cantidad == 0) {
                                                this.Cantidad = 1;
                                        }

                                        this.EstablecerImporteUnitarioOriginal(UnitarioMostrar);
                                        this.RecalcularImporteFinal();
                                }
                        } else if (EntradaArticulo.IsFreeText) {
                                EntradaUnitario.Enabled = true;
                                EntradaDescuento.Enabled = true;
                                EntradaCantidad.Enabled = true;
                                EntradaCantidad.TemporaryReadOnly = this.TemporaryReadOnly;
                                EntradaUnitario.TemporaryReadOnly = this.TemporaryReadOnly || this.BloquearPrecio;
                                EntradaDescuento.TemporaryReadOnly = this.TemporaryReadOnly || this.BloquearPrecio;
                                EntradaImporte.Enabled = true;
                                if (this.AutoUpdate) {
                                        if (this.Cantidad == 0) {
                                                this.Cantidad = 1;
                                        }
                                }
                        } else if (EntradaArticulo.Text.Length == 0 || (EntradaArticulo.Text.IsNumericInt() && EntradaArticulo.ValueInt == 0)) {
                                EntradaUnitario.Enabled = false;
                                EntradaDescuento.Enabled = false;
                                EntradaCantidad.Enabled = false;
                                EntradaCantidad.TemporaryReadOnly = this.TemporaryReadOnly;
                                EntradaUnitario.TemporaryReadOnly = this.TemporaryReadOnly || this.BloquearPrecio;
                                EntradaDescuento.TemporaryReadOnly = this.TemporaryReadOnly || this.BloquearPrecio;
                                EntradaImporte.Enabled = false;
                                if (this.AutoUpdate) {
                                        EntradaCantidad.ValueDecimal = 0m;
                                        EntradaImporte.ValueDecimal = 0m;
                                        this.EstablecerImporteUnitarioOriginal(0m);
                                        EntradaDescuento.ValueDecimal = 0m;
                                }
                        }
                }


                /// <summary>
                /// Cambia el importe unitario original (sin IVA), y además recalcula el IVA y lo muestra discriminado si corresponde.
                /// </summary>
                /// <param name="unitario">El precio unitario a mostrar y usar como base para el cálculo de IVA e importe final.</param>
                protected void EstablecerImporteUnitarioOriginal(decimal unitario)
                {
                        if (this.AplicarIva && m_Alicuota != null) {
                                this.ImporteIvaUnitario = unitario * (m_Alicuota.Porcentaje / 100m);
                                if (this.DiscriminarIva) {
                                        EntradaUnitario.ValueDecimal = unitario;
                                        EntradaIva.ValueDecimal = this.ImporteIvaUnitario;
                                } else {
                                        EntradaUnitario.ValueDecimal = unitario + this.ImporteIvaUnitario;
                                        EntradaIva.ValueDecimal = 0m;
                                }
                        } else {
                                this.ImporteIvaUnitario = 0m;
                                EntradaUnitario.ValueDecimal = unitario;
                                EntradaIva.ValueDecimal = 0;
                        }
                }


                /// <summary>
                /// Recalcula el importe final, según importe, IVA, cantidad y descuento.
                /// </summary>
                protected void RecalcularImporteFinal()
                {
                        if(m_DiscriminarIva) {
                                if(m_AplicarIva && this.m_Alicuota != null) {
                                        decimal Iva = this.ImporteUnitario * (this.m_Alicuota.Porcentaje / 100m);
                                        if(Math.Abs(this.ImporteIvaUnitario - Iva) > 0.01m) {
                                                this.ImporteIvaUnitario = Iva;
                                        }
                                } else {
                                        if(this.ImporteIvaUnitario != 0m) {
                                                this.ImporteIvaUnitario = 0m;
                                        }
                                }
                                EntradaIva.ValueDecimal = this.ImporteIvaUnitario;
                        } else {
                                EntradaIva.ValueDecimal = 0m;
                        }

                        try {
                                decimal ImporteFinal = (this.ImporteUnitario + this.ImporteIvaDiscriminadoUnitario) * this.Cantidad * (1m - this.Descuento / 100m);
                                EntradaImporte.ValueDecimal = ImporteFinal;
                        } catch {
                                EntradaImporte.ValueDecimal = 0m;
                        }

                        if (m_MostrarExistencias) {
                                VerificarStock();
                        }
                }
        }
}