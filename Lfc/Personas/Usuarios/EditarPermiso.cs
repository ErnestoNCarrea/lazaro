using System;

namespace Lfc.Personas.Usuarios
{
        public partial class EditarPermiso : Lui.Forms.DialogForm
        {
                private Lbl.Sys.Permisos.Permiso m_Permiso = null;
                public Lbl.Personas.Usuario Usuario;

                public EditarPermiso()
                {
                        InitializeComponent();
                }

                private void CheckNivelEditar_CheckedChanged(object sender, EventArgs e)
                {
                        if (CheckNivelEditar.Checked)
                                CheckNivelVer.Checked = true;
                }

                public Lbl.Sys.Permisos.Permiso Permiso
                {
                        get
                        {
                                Lbl.Sys.Permisos.Objeto Obj = EntradaObjeto.Elemento as Lbl.Sys.Permisos.Objeto;

                                Lbl.ListaIds Item = null;
                                if (EntradaItems.Text.Length > 0)
                                        Item = new Lbl.ListaIds(EntradaItems.Text);

                                if (m_Permiso == null) {
                                        m_Permiso = new Lbl.Sys.Permisos.Permiso(this.Usuario, Obj, this.Operaciones, Item);
                                } else {
                                        m_Permiso.Objeto = EntradaObjeto.Elemento as Lbl.Sys.Permisos.Objeto;
                                        m_Permiso.Operaciones = this.Operaciones;
                                        m_Permiso.Item = Item;
                                }

                                return m_Permiso;
                        }
                        set
                        {
                                m_Permiso = value;
                                EntradaObjeto.Elemento = m_Permiso.Objeto;
                                this.Operaciones = m_Permiso.Operaciones;
                                if (m_Permiso.Item == null)
                                        EntradaItems.Text = "";
                                else
                                        EntradaItems.Text = m_Permiso.Item.ToString();
                        }
                }

                public Lbl.Sys.Permisos.Operaciones Operaciones
                {
                        get
                        {
                                Lbl.Sys.Permisos.Operaciones Nivel = Lbl.Sys.Permisos.Operaciones.Ninguno;

                                if (CheckNivelListar.Checked)
                                        Nivel |= Lbl.Sys.Permisos.Operaciones.Listar;
                                if (CheckNivelVer.Checked)
                                        Nivel |= Lbl.Sys.Permisos.Operaciones.Ver;
                                if (CheckNivelImprimir.Checked)
                                        Nivel |= Lbl.Sys.Permisos.Operaciones.Imprimir;
                                if (CheckNivelCrear.Checked)
                                        Nivel |= Lbl.Sys.Permisos.Operaciones.Crear;
                                if (CheckNivelEditar.Checked)
                                        Nivel |= Lbl.Sys.Permisos.Operaciones.Editar;
                                if (CheckNivelEditarAvanzado.Checked)
                                        Nivel |= Lbl.Sys.Permisos.Operaciones.EditarAvanzado;
                                if (CheckNivelMover.Checked)
                                        Nivel |= Lbl.Sys.Permisos.Operaciones.Mover;
                                if (CheckNivelEliminar.Checked)
                                        Nivel |= Lbl.Sys.Permisos.Operaciones.Eliminar;
                                if (CheckNivelAdministrar.Checked)
                                        Nivel |= Lbl.Sys.Permisos.Operaciones.Administrar;
                                if (CheckNivelExtra1.Checked)
                                        Nivel |= Lbl.Sys.Permisos.Operaciones.Extra1;
                                if (CheckNivelExtra2.Checked)
                                        Nivel |= Lbl.Sys.Permisos.Operaciones.Extra2;
                                if (CheckNivelExtra3.Checked)
                                        Nivel |= Lbl.Sys.Permisos.Operaciones.Extra3;
                                if (CheckNivelExtraA.Checked)
                                        Nivel |= Lbl.Sys.Permisos.Operaciones.ExtraA;
                                if (CheckNivelExtraB.Checked)
                                        Nivel |= Lbl.Sys.Permisos.Operaciones.ExtraB;
                                if (CheckNivelExtraC.Checked)
                                        Nivel |= Lbl.Sys.Permisos.Operaciones.ExtraC;
                                if (CheckNivelTotal.Checked)
                                        Nivel |= Lbl.Sys.Permisos.Operaciones.Total;

                                return Nivel;
                        }
                        set
                        {
                                CheckNivelListar.Checked = (value & Lbl.Sys.Permisos.Operaciones.Listar) == Lbl.Sys.Permisos.Operaciones.Listar;
                                CheckNivelVer.Checked = (value & Lbl.Sys.Permisos.Operaciones.Ver) == Lbl.Sys.Permisos.Operaciones.Ver;
                                CheckNivelImprimir.Checked = (value & Lbl.Sys.Permisos.Operaciones.Imprimir) == Lbl.Sys.Permisos.Operaciones.Imprimir;
                                CheckNivelCrear.Checked = (value & Lbl.Sys.Permisos.Operaciones.Crear) == Lbl.Sys.Permisos.Operaciones.Crear;
                                CheckNivelEditar.Checked = (value & Lbl.Sys.Permisos.Operaciones.Editar) == Lbl.Sys.Permisos.Operaciones.Editar;
                                CheckNivelEditarAvanzado.Checked = (value & Lbl.Sys.Permisos.Operaciones.EditarAvanzado) == Lbl.Sys.Permisos.Operaciones.EditarAvanzado;
                                CheckNivelMover.Checked = (value & Lbl.Sys.Permisos.Operaciones.Mover) == Lbl.Sys.Permisos.Operaciones.Mover;
                                CheckNivelEliminar.Checked = (value & Lbl.Sys.Permisos.Operaciones.Eliminar) == Lbl.Sys.Permisos.Operaciones.Eliminar;
                                CheckNivelAdministrar.Checked = (value & Lbl.Sys.Permisos.Operaciones.Administrar) == Lbl.Sys.Permisos.Operaciones.Administrar;
                                CheckNivelExtra1.Checked = (value & Lbl.Sys.Permisos.Operaciones.Extra1) == Lbl.Sys.Permisos.Operaciones.Extra1;
                                CheckNivelExtra2.Checked = (value & Lbl.Sys.Permisos.Operaciones.Extra2) == Lbl.Sys.Permisos.Operaciones.Extra2;
                                CheckNivelExtra3.Checked = (value & Lbl.Sys.Permisos.Operaciones.Extra3) == Lbl.Sys.Permisos.Operaciones.Extra3;
                                CheckNivelExtraA.Checked = (value & Lbl.Sys.Permisos.Operaciones.ExtraA) == Lbl.Sys.Permisos.Operaciones.ExtraA;
                                CheckNivelExtraB.Checked = (value & Lbl.Sys.Permisos.Operaciones.ExtraB) == Lbl.Sys.Permisos.Operaciones.ExtraB;
                                CheckNivelExtraC.Checked = (value & Lbl.Sys.Permisos.Operaciones.ExtraC) == Lbl.Sys.Permisos.Operaciones.ExtraC;
                                CheckNivelTotal.Checked = (value & Lbl.Sys.Permisos.Operaciones.Total) == Lbl.Sys.Permisos.Operaciones.Total;
                        }
                }

                public override Lfx.Types.OperationResult Ok()
                {
                        if (EntradaObjeto.ValueInt == 0)
                                return new Lfx.Types.FailureOperationResult("Seleccione un objeto");

                        if (this.Operaciones == Lbl.Sys.Permisos.Operaciones.Ninguno)
                                return new Lfx.Types.FailureOperationResult("Seleccione al menos un permiso");

                        return base.Ok();
                }

                private void EntradaObjeto_TextChanged(object sender, EventArgs e)
                {
                        Lbl.Sys.Permisos.Objeto Ob = EntradaObjeto.Elemento as Lbl.Sys.Permisos.Objeto;
                        string NombreElemento = "Ítem";

                        if (Ob != null)
                                NombreElemento = EntradaObjeto.TextDetail;

                        CheckNivelListar.Text = CheckNivelListar.Tag.ToString().Replace("%s", NombreElemento);
                        CheckNivelVer.Text = CheckNivelVer.Tag.ToString().Replace("%s", NombreElemento);
                        CheckNivelImprimir.Text = CheckNivelImprimir.Tag.ToString().Replace("%s", NombreElemento);
                        CheckNivelCrear.Text = CheckNivelCrear.Tag.ToString().Replace("%s", NombreElemento);
                        CheckNivelEditar.Text = CheckNivelEditar.Tag.ToString().Replace("%s", NombreElemento);
                        CheckNivelEditarAvanzado.Text = CheckNivelEditarAvanzado.Tag.ToString().Replace("%s", NombreElemento);
                        CheckNivelMover.Text = CheckNivelMover.Tag.ToString().Replace("%s", NombreElemento);
                        CheckNivelEliminar.Text = CheckNivelEliminar.Tag.ToString().Replace("%s", NombreElemento);
                        CheckNivelAdministrar.Text = CheckNivelAdministrar.Tag.ToString().Replace("%s", NombreElemento);

                        if (Ob != null) {
                                if (Ob.NombreExtra1 == null)
                                        CheckNivelExtra1.Text = "Extra 1";
                                else
                                        CheckNivelExtra1.Text = Ob.NombreExtra1;

                                if (Ob.NombreExtra2 == null)
                                        CheckNivelExtra2.Text = "Extra 2";
                                else
                                        CheckNivelExtra2.Text = Ob.NombreExtra2;

                                if (Ob.NombreExtra3 == null)
                                        CheckNivelExtra3.Text = "Extra 3";
                                else
                                        CheckNivelExtra3.Text = Ob.NombreExtra3;

                                if (Ob.NombreExtraA == null)
                                        CheckNivelExtraA.Text = "Extra A";
                                else
                                        CheckNivelExtraA.Text = Ob.NombreExtraA;

                                if (Ob.NombreExtraB == null)
                                        CheckNivelExtraB.Text = "Extra B";
                                else
                                        CheckNivelExtraB.Text = Ob.NombreExtraB;

                                if (Ob.NombreExtraC == null)
                                        CheckNivelExtraC.Text = "Extra C";
                                else
                                        CheckNivelExtraC.Text = Ob.NombreExtraC;
                        } else {
                                CheckNivelExtra1.Text = "Extra 1";
                                CheckNivelExtra2.Text = "Extra 2";
                                CheckNivelExtra3.Text = "Extra 3";
                                CheckNivelExtraA.Text = "Extra A";
                                CheckNivelExtraB.Text = "Extra B";
                                CheckNivelExtraC.Text = "Extra C";
                        }
                }
        }
}