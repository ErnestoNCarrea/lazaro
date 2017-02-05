using System;
using System.ComponentModel;
using System.Data;

namespace Lcc.Edicion
{
        public class ControlEdicion : Lcc.ControlDeDatos, IControlEdicion
        {
                [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
                public event LccEventHandler SaveRequest;

                [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
                public event EventHandler CloseRequest;

                [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
                public event System.EventHandler FormActionsChanged;

                /// <summary>
                /// Actualiza el elemento con los datos del control.
                /// </summary>
                public virtual void ActualizarElemento()
                {
                }


                /// <summary>
                /// Se dispara cuando el elemento fue guardado.
                /// </summary>
                public virtual Lfx.Types.OperationResult BeforeSave()
                {
                        return new Lfx.Types.SuccessOperationResult();
                }

                /// <summary>
                /// Se dispara cuando el elemento fue guardado.
                /// </summary>
                public virtual void AfterSave(IDbTransaction transaction)
                {
                }


                public Lfx.Types.OperationResult Save()
                {
                        Lfx.Types.OperationResult Res = this.ValidarControl();
                        if (Res.Success == false)
                                return Res;

                        Res = this.BeforeSave();
                        if (Res.Success == false)
                                return Res;

                        if (this.SaveRequest != null) {
                                Lcc.LccEventArgs Args = new Lcc.LccEventArgs();
                                this.SaveRequest(this, ref Args);
                                if (Args.Result != null) {
                                        return Args.Result;
                                } else {
                                        return new Lfx.Types.SuccessOperationResult();
                                }
                        } else {
                                return new Lfx.Types.FailureOperationResult("No se puede grabar");
                        }
                }


                public void Close()
                {
                        if (this.CloseRequest != null)
                                this.CloseRequest(this, new EventArgs());
                }
                


                /// <summary>
                /// Valida los datos del control.
                /// </summary>
                public virtual Lfx.Types.OperationResult ValidarControl()
                {
                        return new Lfx.Types.SuccessOperationResult();
                }


                // Compatibilidad con Lfc.FormularioEdicion
                public void FromRow(Lbl.IElementoDeDatos row)
                {
                        // Si todavía no conozco el tipo de elemento de este formulario, lo tomo de row
                        if (this.ElementoTipo == null || this.ElementoTipo == typeof(Lbl.ElementoDeDatos))
                                this.ElementoTipo = row.GetType();

                        this.Elemento = row;
                        this.ActualizarControl();
                }

                // Compatibilidad con Lfc.FormularioEdicion
                public Lbl.IElementoDeDatos ToRow()
                {
                        this.ActualizarElemento();
                        return this.Elemento;
                }


                public virtual Lfx.Types.OperationResult BeforePrint()
                {
                        return new Lfx.Types.SuccessOperationResult();
                }


                public virtual void AfterPrint()
                {
                        return;
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
                                this.SetControlsReadOnly(this.Controls, m_TemporaryReadOnly);
                        }
                }

                internal void SetControlsReadOnly(System.Windows.Forms.Control.ControlCollection controles, bool newValue)
                {
                        // Pongo los Changed en False
                        foreach (System.Windows.Forms.Control ctl in controles) {
                                if (ctl == null) {
                                        //Nada
                                } else if (ctl is Lui.Forms.Control) {
                                        ((Lui.Forms.Control)ctl).TemporaryReadOnly = newValue;
                                } else if (ctl.Controls != null) {
                                        SetControlsReadOnly(ctl.Controls, newValue);
                                }

                        }
                }

                public virtual bool PuedeEditar()
                {
                        if (this.Elemento.Existe)
                                return Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(this.Elemento, Lbl.Sys.Permisos.Operaciones.Editar);
                        else
                                return Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(this.Elemento, Lbl.Sys.Permisos.Operaciones.Crear);
                }

                public virtual bool PuedeImprimir()
                {
                        return Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(this.Elemento, Lbl.Sys.Permisos.Operaciones.Imprimir);
                }


                public virtual Lazaro.Pres.DisplayStyles.IDisplayStyle HeaderDisplayStyle
                {
                        get
                        {
                                return Lazaro.Pres.DisplayStyles.Template.Current.Generica;
                        }
                }


                protected void FireFormActionsChanged()
                {
                        if(this.FormActionsChanged != null)
                                this.FormActionsChanged(this, null);
                }


                private Lazaro.Pres.Forms.FormActionCollection m_FormActions = null;
                public virtual Lazaro.Pres.Forms.FormActionCollection GetFormActions()
                {
                        if (m_FormActions == null) {
                                m_FormActions = new Lazaro.Pres.Forms.FormActionCollection();
                                // Obtengo una lista de acciones basadas en la tabla sys_tags
                                if (this.ElementoTipo != null && Lfx.Data.DatabaseCache.DefaultCache.Tables.ContainsKey("sys_tags")) {
                                        Lbl.Atributos.Datos AttrDatos = this.ElementoTipo.GetAttribute<Lbl.Atributos.Datos>();
                                        if (AttrDatos != null) {
                                                string NombreTabla = AttrDatos.TablaDatos;

                                                var Conn = this.Connection;
                                                if(Conn == null) {
                                                        Conn = Lfx.Workspace.Master.MasterConnection;
                                                }
                                                System.Data.DataTable TagsTable = Conn.Select("SELECT * FROM sys_tags WHERE fieldtype IN ('action') AND tablename='" + NombreTabla + "'");
                                                foreach (System.Data.DataRow TagRow in TagsTable.Rows) {
                                                        Lfx.Data.Row ActionRow = (Lfx.Data.Row)TagRow;
                                                        Lazaro.Pres.Forms.FormAction NewAction = new Lazaro.Pres.Forms.FormAction(ActionRow.Fields["label"].ValueString, null, ActionRow.Fields["label"].ValueString, 0);
                                                        switch(ActionRow.Fields["inputtype"].ValueString) {
                                                                case "primary":
                                                                case "pri":
                                                                        NewAction.Visibility = Lazaro.Pres.Forms.FormActionVisibility.Main;
                                                                        break;
                                                                case "tertiary":
                                                                case "ter":
                                                                        NewAction.Visibility = Lazaro.Pres.Forms.FormActionVisibility.Tertiary;
                                                                        break;
                                                                case "secondary":
                                                                case "sec":
                                                                default:
                                                                        NewAction.Visibility = Lazaro.Pres.Forms.FormActionVisibility.Secondary;
                                                                        break;

                                                        }
                                                        NewAction.Extra = ActionRow.Fields["extra"].ValueString;
                                                

                                                        m_FormActions.Add(NewAction);
                                                }
                                        }
                                }
                        }

                        return m_FormActions.ShallowClone();
                }

                public virtual Lfx.Types.OperationResult PerformFormAction(string name)
                {
                        if (this.m_FormActions.ContainsKey(name)) {
                                if (this.m_FormActions[name].Extra != null) {
                                        string Extra = this.m_FormActions[name].Extra;

                                        Extra = Extra.Replace("%ElementoTipo%", this.ElementoTipo.ToString());
                                        Extra = Extra.Replace("%Elemento.Id%", this.Elemento.Id.ToString());
                                        Extra = Extra.Replace("%Elemento%", this.Elemento.ToString());

                                        string[] Partes = Extra.Split(new string[] { "::" }, 2, StringSplitOptions.RemoveEmptyEntries);
                                        string Destino, Comando;

                                        if (Partes.Length == 0) {
                                                return null;
                                        } else if (Partes.Length == 1) {
                                                Destino = "lazaro";
                                                Comando = Partes[0];
                                        } else {
                                                Destino = Partes[0];
                                                Comando = Partes[1];
                                        }

                                        string Verbo = Lfx.Types.Strings.GetNextToken(ref Comando, " ");
                                        string[] Params = Comando.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                                        
                                        Lfx.Workspace.Master.RunTime.Execute(Destino, Verbo, Params);
                                }
                        }
                        return null;
                }
        }
}
