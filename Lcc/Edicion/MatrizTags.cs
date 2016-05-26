using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Lcc.Edicion
{
        public partial class MatrizTags : MatrizCampos
        {
                Lfx.Data.Table Tabla;

                public MatrizTags()
                {
                        InitializeComponent();
                }

                /// <summary>
                /// Actualiza el control con los datos del elemento.
                /// </summary>
                public override void ActualizarControl()
                {
                        Lazaro.Pres.Forms.Section Sect = new Lazaro.Pres.Forms.Section("Campos adicionales");
                        this.Tabla = m_Elemento.Connection.Tables[m_Elemento.TablaDatos];
                        Tabla.Connection = this.Connection;
                        if (Tabla.Tags != null) {
                                foreach (Lfx.Data.Tag Tg in Tabla.Tags) {
                                        if (Tg.Internal == false) {
                                                Lazaro.Pres.Field Fld = new Lazaro.Pres.Field(Tg.FieldName, Tg.Label, Tg.InputFieldType);
                                                if (string.IsNullOrEmpty(Tg.LblType) == false) {
                                                        Fld.LblType = Lbl.Instanciador.InferirTipo(Tg.LblType);
                                                }
                                                if (Tg.Access > 0) {
                                                        Lbl.Sys.Permisos.Operaciones Oper = (Lbl.Sys.Permisos.Operaciones)(Tg.Access);
                                                        if (Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(m_Elemento, Oper) == false) {
                                                                Fld.ReadOnly = true;
                                                        }
                                                }
                                                Fld.Relation = Tg.Relation;
                                                Sect.Fields.Add(Fld);
                                        }
                                }
                        }

                        this.FromSection(Sect);

                        base.ActualizarControl();
                }

                /// <summary>
                /// Actualiza el elemento con los datos del control.
                /// </summary>
                public override void ActualizarElemento()
                {
                        if (Tabla.Tags != null) {
                                foreach (Campo Cmp in this.Campos) {
                                        object FieldValue = null;
                                        switch (Tabla.Tags[Cmp.ControlEntrada.FieldName].InputFieldType) {
                                                case Lfx.Data.InputFieldTypes.Bool:
                                                        FieldValue = ((Lui.Forms.YesNo)(Cmp.ControlEntrada)).Value ? 1 : 0;
                                                        break;
                                                case Lfx.Data.InputFieldTypes.Set:
                                                        FieldValue = ((Lui.Forms.ComboBox)(Cmp.ControlEntrada)).TextKey;
                                                        break;
                                                case Lfx.Data.InputFieldTypes.Relation:
                                                        FieldValue = ((Entrada.CodigoDetalle)(Cmp.ControlEntrada)).ValueInt;
                                                        if (object.Equals(FieldValue, 0))
                                                                FieldValue = null;
                                                        break;
                                                default:
                                                        Lui.Forms.TextBox TextField = Cmp.ControlEntrada as Lui.Forms.TextBox;
                                                        switch (Tabla.Tags[Cmp.ControlEntrada.FieldName].InputFieldType) {
                                                                case Lfx.Data.InputFieldTypes.Currency:
                                                                        FieldValue = TextField.ValueDecimal;
                                                                        break;
                                                                case Lfx.Data.InputFieldTypes.Date:
                                                                        FieldValue = Lfx.Types.Parsing.ParseDate(TextField.Text);
                                                                        break;
                                                                case Lfx.Data.InputFieldTypes.DateTime:
                                                                        FieldValue = Lfx.Types.Parsing.ParseDate(TextField.Text);
                                                                        break;
                                                                case Lfx.Data.InputFieldTypes.Numeric:
                                                                        FieldValue = TextField.ValueDecimal;
                                                                        break;
                                                                case Lfx.Data.InputFieldTypes.Integer:
                                                                        FieldValue = TextField.ValueInt;
                                                                        break;
                                                                default:
                                                                        FieldValue = TextField.Text;
                                                                        break;
                                                        }
                                                        break;
                                        }

                                        this.Elemento.SetFieldValue(Cmp.ControlEntrada.FieldName, FieldValue);
                                }
                        }

                        base.ActualizarElemento();
                }
        }
}
