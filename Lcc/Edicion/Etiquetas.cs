using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Lcc.Edicion
{
        public partial class Etiquetas : Lcc.Edicion.ControlEdicion
        {
                public Etiquetas()
                {
                        InitializeComponent();
                }

                public override string Text
                {
                        get
                        {
                                return GroupLabel.Text;
                        }
                        set
                        {
                                GroupLabel.Text = value;
                                base.Text = value;
                        }
                }

                private void Lista_ItemChecked(object sender, ItemCheckedEventArgs e)
                {
                        /* int ItemId = Lfx.Types.Parsing.ParseInt(e.Item.Text);
                        if (ItemId != 0) {
                                if(e.Item.Checked) {
                                        //Agrego
                                        if(Elemento.Etiquetas.Contains(ItemId) == false)
                                                m_Elemento.Etiquetas.Add(new Lbl.Etiqueta(m_Elemento.Connection, ItemId));
                                } else {
                                        //Lo quito
                                        if (Elemento.Etiquetas.Contains(ItemId))
                                                m_Elemento.Etiquetas.RemoveById(ItemId);
                                }
                        } */
                }

                public override void ActualizarControl()
                {
                        Lista.SuspendLayout();
                        Lista.Items.Clear();
                        Lfx.Data.Table TablaEtiquetas = Lfx.Workspace.Master.Tables["sys_labels"];
                        TablaEtiquetas.PreLoad();
                        foreach (Lfx.Data.Row Rw in TablaEtiquetas.FastRows.Values) {
                                Lbl.Etiqueta Eti = new Lbl.Etiqueta(this.Connection, Rw);
                                if (Eti.TablaReferencia == m_Elemento.TablaDatos) {
                                        ListViewItem Itm = Lista.Items.Add(Eti.Id.ToString());
                                        Itm.SubItems.Add(Eti.Nombre);
                                        if (Elemento.Etiquetas.Contains(Eti.Id))
                                                Itm.Checked = true;
                                }
                        }
                        Lista.ResumeLayout();

                        base.ActualizarControl();
                }

                public override void ActualizarElemento()
                {
                        foreach (ListViewItem Itm in Lista.Items) {
                                int ItemId = Lfx.Types.Parsing.ParseInt(Itm.Text);
                                if (ItemId != 0) {
                                        if (Itm.Checked) {
                                                //Agrego
                                                if (Elemento.Etiquetas.Contains(ItemId) == false)
                                                        m_Elemento.Etiquetas.Add(new Lbl.Etiqueta(m_Elemento.Connection, ItemId));
                                        } else {
                                                //Lo quito
                                                if (Elemento.Etiquetas.Contains(ItemId))
                                                        m_Elemento.Etiquetas.RemoveById(ItemId);
                                        }
                                }
                        }
                        base.ActualizarElemento();
                }
        }
}
