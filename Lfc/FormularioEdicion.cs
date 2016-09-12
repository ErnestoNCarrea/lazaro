using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Lfc
{
        public partial class FormularioEdicion : Lui.Forms.ChildForm
        {
                public Form FormOpener;
                public System.Windows.Forms.Control ControlDestino { get; set; }
                public Lbl.IElementoDeDatos Elemento;
                public Type ElementoTipo = null;

                Lazaro.Pres.Forms.FormActionCollection FormActions;

                private Lbl.Atributos.PanelExtendido MuestraPanel = Lbl.Atributos.PanelExtendido.Automatico;
                private bool m_ReadOnly = false;

                public FormularioEdicion()
                {
                        this.DisplayStyle = Lazaro.Pres.DisplayStyles.Template.Current.EditForm;
                        InitializeComponent();
                        this.FormActions = new Lazaro.Pres.Forms.FormActionCollection()
                        {
                                new Lazaro.Pres.Forms.FormAction("Cancelar", "Esc", "cancelar", 20),
                                new Lazaro.Pres.Forms.FormAction("Guardar", "F9", "aceptar", 10),
                                new Lazaro.Pres.Forms.FormAction("Imprimir", "F8", "imprimir", 30, Lazaro.Pres.Forms.FormActionVisibility.Hidden),
                                new Lazaro.Pres.Forms.FormAction("Comentarios", null, "comentarios", 30, Lazaro.Pres.Forms.FormActionVisibility.Tertiary),
                                new Lazaro.Pres.Forms.FormAction("Historial", null, "historial", 20, Lazaro.Pres.Forms.FormActionVisibility.Tertiary),
                                new Lazaro.Pres.Forms.FormAction("Más datos", null, "panelextendido", 10, Lazaro.Pres.Forms.FormActionVisibility.Hidden)
                        };
                        this.ActualizarFormActions();
                        if(Screen.PrimaryScreen.Bounds.Width <= 1024) {
                                // Más ajustado en pantallas más pequeñas
                                this.PanelEdicion.Padding = new System.Windows.Forms.Padding(12, 12, 8, 8);
                                this.PanelExtendido.Width = 320;
                        } else {
                                this.PanelEdicion.Padding = new System.Windows.Forms.Padding(24, 24, 16, 16);
                                this.PanelExtendido.Width = 360;
                        }
                }


                protected override void OnKeyDown(KeyEventArgs e)
                {
                        if (e.Control == true && e.Alt == false && e.Shift == false) {
                                switch(e.KeyCode) {
                                        case Keys.H:
                                                e.Handled = true;
                                                MostrarHistorial();
                                                break;
                                }
                        }
                        base.OnKeyDown(e);
                }


                private Lcc.Edicion.ControlEdicion m_ControlUnico = null;

                public Lcc.Edicion.ControlEdicion ControlUnico
                {
                        get
                        {
                                return this.m_ControlUnico;
                        }
                        set
                        {
                                if (m_ControlUnico != null && this.Controls.Contains(m_ControlUnico))
                                        this.Controls.Remove(m_ControlUnico);

                                m_ControlUnico = value;
                                this.ElementoTipo = m_ControlUnico.ElementoTipo;

                                this.SuspendLayout();
                                m_ControlUnico.TabIndex = 0;
                                m_ControlUnico.Dock = System.Windows.Forms.DockStyle.Fill;

                                if (m_ControlUnico.HeaderDisplayStyle == null) {
                                        this.Encabezado.Visible = false;
                                        this.PanelAccionesTerciarias.Visible = false;
                                } else {
                                        this.Encabezado.DisplayStyle = m_ControlUnico.HeaderDisplayStyle;
                                        IntPtr Hicon = m_ControlUnico.HeaderDisplayStyle.Icon.GetHicon();
                                        this.Icon = System.Drawing.Icon.FromHandle(Hicon);
                                        this.Encabezado.Visible = true;
                                        this.PanelAccionesTerciarias.Visible = true;
                                }

                                this.PanelEdicion.AutoScrollMinSize = m_ControlUnico.MinimumSize;
                                this.PanelEdicion.Controls.Add(m_ControlUnico);
                                this.PanelAccionesPrimariasYSecundarias.FormActions.AddAndUpdate(m_ControlUnico.GetFormActions());
                                this.PanelAccionesPrimariasYSecundarias.ActualizarControl();

                                this.ResumeLayout(true);

                                m_ControlUnico.SaveRequest += new Lcc.LccEventHandler(this.ControlUnico_SaveRequest);
                                m_ControlUnico.CloseRequest += new EventHandler(this.ControlUnico_CloseRequest);
                                m_ControlUnico.TextChanged += new EventHandler(this.ControlUnico_TextChanged);
                                m_ControlUnico.FormActionsChanged += new EventHandler(this.ControlUnico_FormActionsChanged);
                        }
                }


                private void ControlUnico_CloseRequest(object sender, EventArgs e)
                {
                        this.Close();
                }


                private void ControlUnico_SaveRequest(object sender, ref Lcc.LccEventArgs e)
                {
                        e.Result = this.Save();
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public virtual bool SaveEnable
                {
                        get
                        {
                                return this.PanelAccionesPrimariasYSecundarias.FormActions["aceptar"].Enabled && this.PanelAccionesPrimariasYSecundarias.FormActions["aceptar"].Visibility != Lazaro.Pres.Forms.FormActionVisibility.Hidden;
                        }
                        set
                        {
                                this.PanelAccionesPrimariasYSecundarias.FormActions["aceptar"].Visibility = value ? Lazaro.Pres.Forms.FormActionVisibility.Main : Lazaro.Pres.Forms.FormActionVisibility.Hidden;
                                this.ActualizarFormActions();
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public virtual bool ReadOnly
                {
                        get
                        {
                                return m_ReadOnly;
                        }
                        set
                        {
                                m_ReadOnly = value;
                                this.SaveEnable = !m_ReadOnly;
                                if (value)
                                        this.PanelAccionesPrimariasYSecundarias.FormActions["cancelar"].Text = "Cerrar";
                                else
                                        this.PanelAccionesPrimariasYSecundarias.FormActions["cancelar"].Text = "Cancelar";
                                this.ActualizarFormActions();
                                this.SetControlsReadOnly(this.Controls, m_ReadOnly);
                        }
                }


                public Lfx.Types.OperationResult Save()
                {
                        if (this.ReadOnly)
                                return new Lfx.Types.FailureOperationResult("No se puede guardar porque es un formulario sólo-lectura");

                        Lfx.Types.OperationResult Resultado = this.ControlUnico.ValidarControl();
                        if (Resultado.Success == false)
                                return Resultado;

                        Resultado = this.ControlUnico.BeforeSave();
                        if (Resultado.Success == false)
                                return Resultado;

                        bool WasNew = !this.Elemento.Existe;
                        this.Elemento = this.ToRow();
                        if (this.GetControlsChanged(this.Controls) || this.Elemento.Modificado) {
                                // Guardo sólo si hubo cambios
                                IDbTransaction Trans = null;
                                if (this.Elemento.Connection.InTransaction == false)
                                        Trans = this.Elemento.Connection.BeginTransaction(IsolationLevel.Serializable);

                                if (Lfx.Workspace.Master.DebugMode) {
                                        Resultado = this.Elemento.Guardar();
                                } else {
                                        try {
                                                Resultado = this.Elemento.Guardar();
                                        } catch (Lfx.Types.DomainException dex) {
                                                if (Trans != null)
                                                        Trans.Rollback();
                                                Resultado = new Lfx.Types.FailureOperationResult(dex.Message);
                                        } catch (Exception ex) {
                                                if (Trans != null)
                                                        Trans.Rollback();
                                                if (this.Elemento != null && this.Name != null)
                                                        ex.HelpLink = this.Name + ".Save: " + this.ElementoTipo.ToString();
                                                throw ex;
                                        }
                                }
                                if (Resultado.Success) {
                                        this.ControlUnico.AfterSave(Trans);
                                        if (Trans != null) {
                                                Trans.Commit();
                                                Trans = null;
                                        }
                                } else {
                                        if (Trans != null) {
                                                Trans.Rollback();
                                                Trans = null;
                                        }
                                }
                        }

                        if (Resultado.Success) {
                                this.SetControlsChanged(this.Controls, false);

                                if (WasNew) {
                                        if (ControlDestino != null) {
                                                ControlDestino.Text = this.Elemento.Id.ToString();
                                                ControlDestino.Focus();
                                        }

                                        Lbl.Atributos.Presentacion AttrMuestraMsg = this.ElementoTipo.GetAttribute<Lbl.Atributos.Presentacion>();
                                        if (AttrMuestraMsg != null && AttrMuestraMsg.MensajeAlCrear)
                                                Lui.Forms.MessageBox.Show("Acaba de crear " + this.Elemento.ToString(), "Crear");
                                }

                                if (FormOpener != null) {
                                        FormOpener.Focus();
                                        FormOpener.Activate();
                                }

                                this.DialogResult = DialogResult.OK;
                        }
                        return Resultado;
                }

                public virtual Lfx.Types.OperationResult Cancelar()
                {
                        this.Close();

                        if (FormOpener != null) {
                                FormOpener.Focus();
                                FormOpener.Activate();
                        }

                        this.DialogResult = DialogResult.Cancel;
                        return new Lfx.Types.SuccessOperationResult();
                }

                private void Guardar()
                {
                        Lfx.Types.OperationResult Result = this.Save();

                        if (Result.Success == true) {
                                this.Close();
                        } else {
                                if (Result.Message != null && Result.Message.Length > 0)
                                        Lui.Forms.MessageBox.Show(Result.Message, "Error");
                        }
                }


                protected override void OnFormClosing(FormClosingEventArgs e)
                {
                        if (this.GetControlsChanged(this.Controls)) {
                                Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("Si cierra el formulario en este momento, no se guardarán los cambios realizados (subrayados en color rojo). ¿Desea cerrar el formulario de todos modos y perder los cambios realizados?", "Hay cambios sin guardar");
                                Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;

                                this.ShowChanged = true;
                                DialogResult Res = Pregunta.ShowDialog();
                                this.ShowChanged = false;

                                if (Res == DialogResult.Cancel) {
                                        e.Cancel = true;
                                } else {
                                        e.Cancel = false;
                                }
                        }
                        base.OnFormClosing(e);
                }


                /// <summary>
                /// Pongo la propiedad ReadOnly de los controles hijos en cascada.
                /// </summary>
                internal void SetControlsReadOnly(System.Windows.Forms.Control.ControlCollection controles, bool newValue)
                {
                        if (controles == null)
                                return;

                        foreach (System.Windows.Forms.Control ctl in controles) {
                                if (ctl == null || ctl is Lcc.Edicion.Comentarios) {
                                        //Nada
                                } else if (ctl is Lui.Forms.Control) {
                                        ((Lui.Forms.Control)ctl).TemporaryReadOnly = newValue;
                                } else if (ctl.Controls != null && ctl.Controls.Count > 0) {
                                        SetControlsReadOnly(ctl.Controls, newValue);
                                }
                        }
                }

                public void FromRow(Lbl.IElementoDeDatos row)
                {
                        // Si todavía no conozco el tipo de elemento de este formulario, lo tomo de row
                        if (this.ElementoTipo == null || this.ElementoTipo == typeof(Lbl.ElementoDeDatos))
                                this.ElementoTipo = row.GetType();

                        this.ReadOnly = true;
                        this.Connection = row.Connection;
                        this.Elemento = row;

                        if (this.Encabezado.Visible && this.Encabezado.DisplayStyle.Icon == null) {
                                if (this.Elemento.Existe)
                                        this.StockImage = "editar";
                                else
                                        this.StockImage = "crear";
                        }

                        bool PuedeVerHistorial = Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(this.Elemento, Lbl.Sys.Permisos.Operaciones.Administrar) || Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(typeof(Lbl.Sys.Log.Entrada), Lbl.Sys.Permisos.Operaciones.Ver);
                        this.PanelAccionesTerciarias.FormActions["historial"].Visibility = (this.Elemento.Existe && PuedeVerHistorial) ? Lazaro.Pres.Forms.FormActionVisibility.Tertiary : Lazaro.Pres.Forms.FormActionVisibility.Hidden;
                        this.PanelAccionesTerciarias.FormActions["comentarios"].Visibility = this.Elemento.Existe ? Lazaro.Pres.Forms.FormActionVisibility.Tertiary : Lazaro.Pres.Forms.FormActionVisibility.Hidden;

                        Lbl.Atributos.Presentacion AttrMuestraPanel = this.ElementoTipo.GetAttribute<Lbl.Atributos.Presentacion>();
                        if (AttrMuestraPanel != null) {
                                EntradaComentarios.Visible = this.Elemento.Existe;
                                MuestraPanel = AttrMuestraPanel.PanelExtendido;
                                this.PanelAccionesTerciarias.FormActions["panelextendido"].Visibility = (MuestraPanel != Lbl.Atributos.PanelExtendido.Nunca) ? Lazaro.Pres.Forms.FormActionVisibility.Tertiary : Lazaro.Pres.Forms.FormActionVisibility.Hidden;
                        }

                        if (this.ControlUnico != null) {
                                this.ControlUnico.FromRow(row);
                                if (this.MuestraPanel != Lbl.Atributos.PanelExtendido.Nunca) {
                                        if (row is Lbl.IElementoConImagen) {
                                                EntradaImagen.Elemento = row;
                                                EntradaImagen.ActualizarControl();
                                                EntradaImagen.Visible = true;
                                        } else {
                                                EntradaImagen.Visible = false;
                                        }

                                        EntradaComentarios.Elemento = row;
                                        EntradaTags.Elemento = row;

                                        EntradaComentarios.ActualizarControl();
                                        EntradaTags.ActualizarControl();

                                        if (MuestraPanel == Lbl.Atributos.PanelExtendido.Siempre)
                                                PanelExtendido.Show();
                                }
                        }

                        Lbl.Atributos.Nomenclatura Attr = this.ElementoTipo.GetAttribute<Lbl.Atributos.Nomenclatura>();
                        if (row != null && row.Existe) {
                                if (Attr != null && Attr.PrefijarNombreConTipo)
                                        this.Text = Attr.NombreSingular + " " + row.ToString();
                                else
                                        this.Text = row.ToString();
                        } else {
                                if (Attr != null)
                                        this.Text = "Creando " + Attr.NombreSingular.ToLowerInvariant();
                                else
                                        this.Text = "Creando " + row.GetType().ToString();
                        }

                        this.ReadOnly = !this.PuedeEditar();

                        this.PanelAccionesPrimariasYSecundarias.FormActions["imprimir"].Visibility = this.PuedeImprimir() ? Lazaro.Pres.Forms.FormActionVisibility.Main : Lazaro.Pres.Forms.FormActionVisibility.Hidden;
                        this.ActualizarFormActions();
                        this.SetControlsChanged(this.Controls, false);
                }

                public virtual Lbl.IElementoDeDatos ToRow()
                {
                        if (this.ControlUnico != null) {
                                Lbl.IElementoDeDatos Res = this.ControlUnico.ToRow();
                                if (this.MuestraPanel != Lbl.Atributos.PanelExtendido.Nunca) {
                                        if (Res is Lbl.IElementoConImagen)
                                                EntradaImagen.ActualizarElemento();
                                        //EntradaComentarios.ActualizarElemento();
                                        EntradaTags.ActualizarElemento();
                                }
                                return Res;
                        } else {
                                return this.Elemento;
                        }
                }

                private void MostrarHistorial()
                {
                        Lfx.Workspace.Master.RunTime.Execute("HISTORIAL", new string[] { this.Elemento.TablaDatos, this.Elemento.Id.ToString() });
                }

                public virtual bool PuedeEditar()
                {
                        if (this.ControlUnico == null)
                                return false;
                        else
                                return this.ControlUnico.PuedeEditar();
                }

                public virtual bool PuedeImprimir()
                {
                        if (this.ControlUnico == null)
                                return false;
                        else
                                return this.ControlUnico.PuedeImprimir();
                }

                private void EditarComentarios()
                {
                        if (this.Elemento != null && this.Elemento.Existe) {
                                Lfc.Etiquetas FormularioEtiquetas = new Lfc.Etiquetas();
                                FormularioEtiquetas.Elemento = this.Elemento;
                                FormularioEtiquetas.Show();
                        }
                }

                private void Imprimir()
                {
                        Lfx.Types.OperationResult Res;
                        if (this.ReadOnly) {
                                Res = new Lfx.Types.SuccessOperationResult();
                        } else {
                                if (this.Elemento.Existe == false) {
                                        // Si es nuevo, lo guardo sin preguntar.
                                        Res = this.Save();
                                } else if (this.Changed) {
                                        // Si es edición, y hay cambios, pregunto si quiere guardar
                                        using (Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("Hay modificaciones sin guardar (subrayadas en color rojo). Antes de imprimir el ducumento se guardarán las modificaciones. ¿Desea continuar?", "Imprimir")) {
                                                Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                                                this.ShowChanged = true;
                                                if (Pregunta.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                                                        Res = this.Save();
                                                } else {
                                                        Res = new Lfx.Types.CancelOperationResult();
                                                }
                                                this.ShowChanged = false;
                                        }
                                } else {
                                        // Es edición y no hay cambios... continúo
                                        Res = new Lfx.Types.SuccessOperationResult();
                                }
                        }

                        if (Res.Success)
                                Res = this.ControlUnico.BeforePrint();

                        if (Res.Success) {
                                Lbl.Impresion.Impresora Impresora = null;
                                if ((System.Windows.Forms.Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
                                        using (Lui.Printing.PrinterSelectionDialog FormularioSeleccionarImpresora = new Lui.Printing.PrinterSelectionDialog()) {
                                                if (FormularioSeleccionarImpresora.ShowDialog() == DialogResult.OK) {
                                                        Impresora = FormularioSeleccionarImpresora.SelectedPrinter;
                                                } else {
                                                        return;
                                                }
                                        }
                                }

                                string NombreDocumento = Elemento.ToString();
                                Lbl.Impresion.CargasPapel Carga = Lbl.Impresion.CargasPapel.Automatica;
                                if (Impresora != null && Impresora.CargaPapel == Lbl.Impresion.CargasPapel.Manual) {
                                        Carga = Lbl.Impresion.CargasPapel.Manual;
                                } else if (this.Elemento is Lbl.Comprobantes.ComprobanteConArticulos) {
                                        Lbl.Comprobantes.ComprobanteConArticulos Comprob = this.Elemento as Lbl.Comprobantes.ComprobanteConArticulos;

                                        if (Lbl.Comprobantes.PuntoDeVenta.TodosPorNumero[Comprob.PV].Tipo != Lbl.Comprobantes.TipoPv.Talonario) {
                                                Carga = Lbl.Impresion.CargasPapel.Automatica;
                                        } else {
                                                // El tipo de comprobante puede forzar a una carga manual
                                                Carga = Comprob.Tipo.CargaPapel;

                                                // Intento averiguar el número de comprobante, en caso de que aun no esté numerado
                                                if (Comprob.Numero == 0) {
                                                        int ProximoNumero = Lbl.Comprobantes.Numerador.ProximoNumero(Comprob);
                                                        NombreDocumento = NombreDocumento.Replace("00000000", ProximoNumero.ToString("00000000"));
                                                }
                                        }
                                }

                                if (Carga == Lbl.Impresion.CargasPapel.Manual) {
                                        using (Lui.Printing.ManualFeedDialog FormularioCargaManual = new Lui.Printing.ManualFeedDialog()) {
                                                FormularioCargaManual.DocumentName = NombreDocumento;
                                                // Muestro el nombre de la impresora
                                                if (Impresora != null) {
                                                        FormularioCargaManual.PrinterName = Impresora.Nombre;
                                                } else {
                                                        System.Drawing.Printing.PrinterSettings ObjPrint = new System.Drawing.Printing.PrinterSettings();
                                                        FormularioCargaManual.PrinterName = ObjPrint.PrinterName;
                                                }
                                                if (FormularioCargaManual.ShowDialog() == DialogResult.Cancel)
                                                        return;
                                        }
                                }

                                if (Impresora != null && Impresora.EsVistaPrevia) {
                                        Lazaro.Base.Util.Impresion.ImpresorElemento ImpresorVistaPrevia = Lazaro.Base.Util.Impresion.Instanciador.InstanciarImpresor(this.Elemento, null);
                                        ImpresorVistaPrevia.PrintController = new System.Drawing.Printing.PreviewPrintController();
                                        Lui.Printing.PrintPreviewForm VistaPrevia = new Lui.Printing.PrintPreviewForm();
                                        VistaPrevia.MdiParent = this.ParentForm.MdiParent;
                                        VistaPrevia.PrintPreview.Document = ImpresorVistaPrevia;
                                        VistaPrevia.Show();
                                } else if(this.Elemento is Lbl.Comprobantes.Comprobante) {
                                        Lfx.Types.OperationProgress Progreso = new Lfx.Types.OperationProgress("Imprimiendo", "El documento se está enviando a la impresora.");
                                        if (Impresora != null)
                                                Progreso.Description = "El documento se está enviando a la impresora " + Impresora.ToString();
                                        Progreso.Modal = false;
                                        Progreso.Begin();

                                        using (IDbTransaction Trans = this.Elemento.Connection.BeginTransaction()) {
                                                var Controlador = new Lazaro.Base.Controller.ComprobanteController(Trans);

                                                if (Lfx.Environment.SystemInformation.DesignMode) {
                                                        Res = Controlador.Imprimir(this.Elemento as Lbl.Comprobantes.Comprobante, Impresora);
                                                } else {
                                                        try {
                                                                Res = Controlador.Imprimir(this.Elemento as Lbl.Comprobantes.Comprobante, Impresora);
                                                        } catch (Exception ex) {
                                                                Res = new Lfx.Types.FailureOperationResult(ex.Message);
                                                        }
                                                }
                                                Progreso.End();
                                                if (Res.Success == false) {
                                                        if (Controlador.Transaction != null) {
                                                                // Puede que la transacción ya haya sido finalizada por el impresor
                                                                Controlador.Transaction.Rollback();
                                                                Controlador.Transaction = null;
                                                        }
                                                        Lui.Forms.MessageBox.Show(Res.Message, "Error");
                                                } else {
                                                        if (Controlador.Transaction != null) {
                                                                // Puede que la transacción ya haya sido finalizada por el impresor
                                                                Controlador.Transaction.Commit();
                                                                Controlador.Transaction = null;
                                                        }
                                                        this.Elemento.Cargar();
                                                        this.FromRow(this.Elemento);
                                                        this.ControlUnico.AfterPrint();
                                                }
                                        }
                                } else {
                                        Lazaro.Base.Util.Impresion.ImpresorElemento Impresor = Lazaro.Base.Util.Impresion.Instanciador.InstanciarImpresor(this.Elemento, null);
                                        Res = Impresor.Imprimir();
                                }
                        } 
                        
                        if (Res.Success == false && Res.Message != null) {
                                Lui.Forms.MessageBox.Show(Res.Message, "Imprimir");
                        }
                }


                protected override void OnTextChanged(EventArgs e)
                {
                        if (this.Encabezado != null)
                                this.Encabezado.Text = this.Text;
                        base.OnTextChanged(e);
                }


                private void EditarPanelExtendido()
                {
                        PanelExtendido.Visible = !PanelExtendido.Visible;
                }

                private void ControlUnico_TextChanged(object sender, EventArgs e)
                {
                        if (ControlUnico.Text != null && ControlUnico.Text.Length > 0)
                                this.Text = ControlUnico.Text;
                }

                private void ControlUnico_FormActionsChanged(object sender, EventArgs e)
                {
                        ActualizarFormActions();
                }

                private void ActualizarFormActions()
                {
                        Lazaro.Pres.Forms.FormActionCollection CombinedFormActions = new Lazaro.Pres.Forms.FormActionCollection();

                        CombinedFormActions.AddRange(this.FormActions);
                        if (m_ControlUnico != null)
                                CombinedFormActions.AddAndUpdate(m_ControlUnico.GetFormActions());

                        this.PanelAccionesPrimariasYSecundarias.FormActions = CombinedFormActions;
                        this.PanelAccionesTerciarias.FormActions = CombinedFormActions;
                        this.PanelAccionesPrimariasYSecundarias.ActualizarControl();
                        this.PanelAccionesTerciarias.ActualizarControl();
                }

                private void LowerPanel_ButtonClick(object sender, EventArgs e)
                {
                        string ActionName = null;
                        Lui.Forms.Button SenderButton = sender as Lui.Forms.Button;
                        if (SenderButton != null) {
                                ActionName = SenderButton.Name;
                        } else {
                                Lui.Forms.LinkLabel SenderLinkLabel = sender as Lui.Forms.LinkLabel;
                                if (SenderLinkLabel != null)
                                        ActionName = SenderLinkLabel.Name;
                        }

                        if (ActionName != null) {
                                // doy la oportunidad de que lo procese el ControlUnico.
                                Lfx.Types.OperationResult Res = this.ControlUnico.PerformFormAction(ActionName);
                                if (Res != null) {
                                        if (Res.Success == false && Res.Cancel == false && Res.Message != null)
                                                Lfx.Workspace.Master.RunTime.Toast(Res.Message, "Error");
                                } else {
                                        // No lo procesó, así que puedo hacerlo yo
                                        switch (ActionName) {
                                                case "aceptar":
                                                        Guardar();
                                                        break;
                                                case "cancelar":
                                                        Cancelar();
                                                        break;
                                                case "imprimir":
                                                        Imprimir();
                                                        break;
                                                case "comentarios":
                                                        EditarComentarios();
                                                        break;
                                                case "historial":
                                                        MostrarHistorial();
                                                        break;
                                                case "panelextendido":
                                                        EditarPanelExtendido();
                                                        break;
                                        }
                                }
                        }
                }

                private void PanelAccionesTerciarias_ButtonClick(object sender, EventArgs e)
                {
                        LowerPanel_ButtonClick(sender, e);
                }

        }
}