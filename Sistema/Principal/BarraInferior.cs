using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Lazaro.WinMain.Principal
{
        public partial class BarraInferior : UserControl
        {
                private Lfx.Data.Connection m_Connection;
                private int ItemActual, ItemSolicitado;
                private string TablaActual, TablaSolicitada;
                private Lbl.IElementoDeDatos ElementoActual = null;

                public BarraInferior()
                {
                        InitializeComponent();
                        this.BackColor = this.DisplayStyle.BackgroundColor;

                        TimerReloj_Tick(this, null);
                }

                [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public Lfx.Workspace Workspace
                {
                        get
                        {
                                return Lfx.Workspace.Master;
                        }
                }

                [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public Lfx.Data.IConnection Connection
                {
                        get
                        {
                                if (m_Connection == null)
                                        m_Connection = Lfx.Workspace.Master.GetNewConnection("Formulario principal: Barra inferior") as Lfx.Data.Connection;
                                return m_Connection;
                        }
                }

                private void TimerReloj_Tick(object sender, EventArgs e)
                {
                        RelojHora.Text = System.DateTime.Now.ToString("HH:mm");
                        RelojFecha.Text = System.DateTime.Now.ToString("dd/MM/yy");
                }

                private void TimerSlowLink_Tick(object sender, EventArgs e)
                {
                        if (TablaActual != TablaSolicitada || ItemActual != ItemSolicitado)
                                this.ActualizarBarra();
                        TimerSlowLink.Stop();
                }


                public void MostrarItem(string tabla, int item)
                {
                        if (Lfx.Workspace.Master == null)
                                return;

                        if (this.Visible == false)
                                return;

                        TablaSolicitada = tabla;
                        ItemSolicitado = item;

                        if (Lfx.Workspace.Master.SlowLink) {
                                //Reinicio el contador
                                TimerSlowLink.Stop();
                                TimerSlowLink.Start();
                        } else {
                                ActualizarBarra();
                        }
                }

                private void ActualizarBarra()
                {
                        this.SuspendLayout();

                        switch (TablaSolicitada) {
                                case "articulo":
                                case "articulos":
                                        PanelProgreso.Visible = false;
                                        PanelAyuda.Visible = false;
                                        PanelPersona.Visible = false;
                                        PanelArticulo.Visible = true;
                                        Lbl.Articulos.Articulo Art;
                                        try {
                                                Art = new Lbl.Articulos.Articulo(this.Connection, ItemSolicitado);
                                        } catch {
                                                Art = null;
                                        }
                                        if (Art != null && Art.Existe) {
                                                ElementoActual = Art;
                                                ItemActual = ItemSolicitado;
                                                TablaActual = TablaSolicitada;

                                                string Codigos = Art.Id.ToString();
                                                if (Art.Codigo1 != null && Art.Codigo1.Length > 0)
                                                        Codigos += System.Environment.NewLine + Art.Codigo1;
                                                if (Art.Codigo2 != null && Art.Codigo2.Length > 0)
                                                        Codigos += System.Environment.NewLine + Art.Codigo2;
                                                if (Art.Codigo3 != null && Art.Codigo3.Length > 0)
                                                        Codigos += System.Environment.NewLine + Art.Codigo3;
                                                if (Art.Codigo4 != null && Art.Codigo4.Length > 0)
                                                        Codigos += System.Environment.NewLine + Art.Codigo4;
                                                ArticuloCodigos.Text = Codigos;
                                                ArticuloNombre.Text = Art.ToString();
                                                ArticuloDescripcion.Text = Art.Descripcion;
                                                ArticuloPvp.Text = Lfx.Types.Formatting.FormatCurrency(Art.Pvp, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                                                ArticuloStock.Text = Lfx.Types.Formatting.FormatCurrency(Art.Existencias, Lfx.Workspace.Master.CurrentConfig.Moneda.Decimales);
                                                PanelArticulo.Visible = true;
                                        }
                                        break;
                                case "persona":
                                case "personas":
                                        PanelProgreso.Visible = false;
                                        PanelAyuda.Visible = false;
                                        PanelPersona.Visible = true;
                                        PanelArticulo.Visible = false;
                                        Lbl.Personas.Persona Per;
                                        try {
                                                Per = new Lbl.Personas.Persona(this.Connection, ItemSolicitado);
                                        } catch {
                                                Per = null;
                                        }
                                        if (Per != null && Per.Existe) {
                                                ElementoActual = Per;
                                                ItemActual = ItemSolicitado;
                                                TablaActual = TablaSolicitada;

                                                PersonaNombre.Text = Per.ToString();
                                                PersonaDomicilio.Text = Per.Domicilio;
                                                PersonaTelefono.Text = Per.Telefono;
                                                PersonaEmail.Text = Per.Email;
                                                if (Per.Grupo != null) {
                                                        PersonaGrupo.Text = Per.Grupo.ToString();
                                                } else {
                                                        PersonaGrupo.Text = "-";
                                                }

                                                decimal Saldo;

                                                try {
                                                        Saldo = Per.CuentaCorriente.ObtenerSaldo(false);
                                                } catch (Exception ex) {
                                                        System.Console.WriteLine(ex.ToString());
                                                        Saldo = 0;
                                                }

                                                if (Saldo > 0) {
                                                        PersonaComentario.Text = "Registra saldo impago en cuenta corriente por " + Lfx.Types.Formatting.FormatCurrency(Saldo, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal);
                                                        PersonaComentario.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.SmallWarning;
                                                        PersonaComentario.Visible = true;
                                                } else if (Saldo < 0) {
                                                        PersonaComentario.Text = "Registra saldo a favor en cuenta corriente por " + Lfx.Types.Formatting.FormatCurrency(-Saldo, Lfx.Workspace.Master.CurrentConfig.Moneda.DecimalesFinal);
                                                        PersonaComentario.TextStyle = Lazaro.Pres.DisplayStyles.TextStyles.Small;
                                                        PersonaComentario.Visible = true;
                                                } else {
                                                        PersonaComentario.Visible = false;
                                                }
                                                PersonaImagen.Image = Per.Imagen;
                                                PanelPersona.Visible = true;
                                        }
                                        break;
                        }
                        this.ResumeLayout();
                }

                public void MostrarAyuda(string titulo, string texto)
                {
                        this.SuspendLayout();
                        AyudaTitulo.Text = titulo;
                        AyudaTexto.Text = texto;
                        PanelProgreso.Visible = false;
                        PanelAyuda.Visible = true;
                        PanelPersona.Visible = false;
                        PanelArticulo.Visible = false;
                        this.ResumeLayout();
                }


                internal void ShowProgressRoutine(Lfx.Types.OperationProgress progreso)
                {
                        if (progreso.IsDone) {
                                PanelProgreso.Visible = false;
                                PanelAyuda.Visible = true;
                                PanelPersona.Visible = false;
                                PanelArticulo.Visible = false;
                        } else {
                                if (progreso.Value > 0) {
                                        ProgressBar.Maximum = progreso.Max;
                                        ProgressBar.Style = ProgressBarStyle.Continuous;
                                        if (progreso.Value <= ProgressBar.Maximum)
                                                ProgressBar.Value = progreso.Value;
                                } else {
                                        ProgressBar.Style = ProgressBarStyle.Marquee;
                                }
                                PanelProgreso.Visible = true;
                                PanelAyuda.Visible = false;
                                PanelPersona.Visible = false;
                                PanelArticulo.Visible = false;
                                EtiquetaOperacion.Text = progreso.Name;
                                EtiquetaDescripcion.Text = progreso.Status;
                                PanelProgreso.Refresh();
                        }
                }

                private void ArticuloNombre_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                        if (TablaActual != null && ItemActual > 0) {
                                object Res = Ejecutor.Exec("EDITAR " + TablaActual + " " + ItemActual.ToString());
                                if (Res != null)
                                        Aplicacion.FormularioPrincipal.ProcesarObjeto(Res);
                        }
                }

                private void PersonaNombre_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                        if (TablaActual != null && ItemActual > 0) {
                                object Res = Ejecutor.Exec("EDITAR " + TablaActual + " " + ItemActual.ToString());
                                if (Res != null)
                                        Aplicacion.FormularioPrincipal.ProcesarObjeto(Res);
                        }
                }

                private void EnlaceEtiquetas_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {
                        if (ElementoActual != null) {
                                Lfc.Etiquetas FormularioEtiquetas = new Lfc.Etiquetas();
                                FormularioEtiquetas.Elemento = ElementoActual;
                                FormularioEtiquetas.Show();
                        }
                }

                [EditorBrowsable(EditorBrowsableState.Always),
                        Browsable(true),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public virtual Lazaro.Pres.DisplayStyles.IDisplayStyle DisplayStyle
                {
                        get
                        {
                                if (this.Parent is Lui.Forms.IForm)
                                        return ((Lui.Forms.IForm)(this.Parent)).DisplayStyle;
                                else if (this.Parent is Lui.Forms.IDisplayStyleControl)
                                        return ((Lui.Forms.IDisplayStyleControl)(this.Parent)).DisplayStyle;
                                else
                                        return Lazaro.Pres.DisplayStyles.Template.Current.Default;
                        }
                }
        }
}