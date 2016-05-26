using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Lcc.Edicion
{
        public partial class Comentarios : ControlDeDatos
        {
                public Comentarios()
                {
                        InitializeComponent();
                }

                public override void ActualizarControl()
                {
                        ListaComentarios.BeginUpdate();
                        ListaComentarios.Items.Clear();
                        qGen.Select SelectComentarios = new qGen.Select("sys_log");
                        SelectComentarios.WhereClause = new qGen.Where();
                        SelectComentarios.WhereClause.Add(new qGen.ComparisonCondition("comando", "Comment"));
                        SelectComentarios.WhereClause.Add(new qGen.ComparisonCondition("tabla", this.Elemento.TablaDatos));
                        SelectComentarios.WhereClause.Add(new qGen.ComparisonCondition("item_id", this.Elemento.Id));
                        SelectComentarios.Order = "id_log DESC";

                        System.Data.DataTable Comentarios = Elemento.Connection.Select(SelectComentarios);
                        foreach (System.Data.DataRow Com in Comentarios.Rows) {
                                Lbl.Sys.Log.Entrada Log = new Lbl.Sys.Log.Entrada(this.Connection, (Lfx.Data.Row)Com);
                                ListViewItem Itm = ListaComentarios.Items.Add(Log.Id.ToString());
                                Itm.SubItems.Add(Lfx.Types.Formatting.FormatShortSmartDateAndTime(Log.Fecha));
                                Itm.SubItems.Add(this.Elemento.Connection.Tables["personas"].FastRows[Log.IdUsuario].Fields["nombre_visible"].Value.ToString());
                                Itm.SubItems.Add(Log.Carga);
                        }

                        ListaComentarios.EndUpdate();

                        EntradaComentario.Enabled = this.Elemento.Existe;
                        BotonAgregar.Enabled = EntradaComentario.Enabled;

                        base.ActualizarControl();
                }

                private void EntradaComentario_TextChanged(object sender, EventArgs e)
                {
                        BotonAgregar.Enabled = EntradaComentario.Text.Length > 5;
                }

                private void BotonAgregar_Click(object sender, EventArgs e)
                {
                        using (IDbTransaction Trans = this.Elemento.Connection.BeginTransaction()) {
                                this.Elemento.AgregarComentario(EntradaComentario.Text);
                                Trans.Commit();
                        }

                        ListaComentarios.BeginUpdate();
                        ListViewItem Itm = ListaComentarios.Items.Insert(0, new ListViewItem(new System.Random().Next().ToString()));
                        Itm.SubItems.Add(Lfx.Types.Formatting.FormatSmartDateAndTime(System.DateTime.Now));
                        Itm.SubItems.Add(Lbl.Sys.Config.Actual.UsuarioConectado.Persona.Nombre);
                        Itm.SubItems.Add(EntradaComentario.Text);
                        ListaComentarios.EndUpdate();

                        EntradaComentario.Text = "";
                }

                private void EntradaComentario_KeyDown(object sender, KeyEventArgs e)
                {
                        if (e.KeyCode == Keys.Return) {
                                e.Handled = true;
                                BotonAgregar.PerformClick();
                        }
                }

                private void ListaComentarios_SizeChanged(object sender, EventArgs e)
                {
                        ColComentario.Width = -2;
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

                public override bool TemporaryReadOnly
                {
                        get
                        {
                                return base.TemporaryReadOnly;
                        }
                        set
                        {
                                // Los comentarios nunca son ReadOnly
                        }
                }


                protected override void OnGotFocus(EventArgs e)
                {
                        SendKeys.Send("{tab}");
                        base.OnGotFocus(e);
                }
        }
}
