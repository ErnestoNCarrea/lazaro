using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Lcc
{
        public class ControlDeDatos : Lui.Forms.DataControl
        {
                public Type m_ElementoTipo = null;
                protected Lbl.IElementoDeDatos m_Elemento = null;

                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public virtual Type ElementoTipo
                {
                        get
                        {
                                return m_ElementoTipo;
                        }
                        set
                        {
                                m_ElementoTipo = value;
                        }
                }


                [EditorBrowsable(EditorBrowsableState.Never),
                        System.ComponentModel.Browsable(false),
                        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public virtual Lbl.IElementoDeDatos Elemento
                {
                        get
                        {
                                return m_Elemento;
                        }
                        set
                        {
                                m_Elemento = value;
                                if(m_Elemento != null && (m_ElementoTipo == null || m_ElementoTipo == typeof(Lbl.ElementoDeDatos)))
                                        this.ElementoTipo = value.GetType();
                        }
                }

                /// <summary>
                /// Actualiza el control con los datos del elemento.
                /// </summary>
                public virtual void ActualizarControl()
                {
                        this.SetControlsChanged(this.Controls, false);
                }
        }
}
