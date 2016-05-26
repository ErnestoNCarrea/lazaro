using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace Lui.Forms
{
        public class DataControl : EditableControl, IDataControl, IEditableControl
        {
                protected Lfx.Data.Connection m_DataBase = null;

                /// <summary>
                /// IDataControl
                /// </summary>
                [EditorBrowsable(EditorBrowsableState.Never), System.ComponentModel.Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
                public Lfx.Data.Connection Connection
                {
                        get
                        {
                                if (m_DataBase == null) {
                                        if (this.ParentForm is IDataForm) {
                                                // Obtengo la conexión del formulario
                                                m_DataBase = ((IDataForm)(this.ParentForm)).Connection;
                                        } else {
                                                // De lo contrario, intento buscar una conexión en los controles parent
                                                System.Windows.Forms.Control MiParent = this.Parent;
                                                while (MiParent != null) {
                                                        if (MiParent is Lui.Forms.IDataControl) {
                                                                m_DataBase = ((Lui.Forms.IDataControl)(MiParent)).Connection;
                                                                break;
                                                        } else {
                                                                MiParent = MiParent.Parent;
                                                        }
                                                }
                                        }
                                }
                                return m_DataBase;
                        }
                }
        }
}
