using System.Collections.Generic;
using System.Windows.Forms;

namespace Lfc.Personas.Usuarios
{
	public partial class Editar : Lcc.Edicion.ControlEdicion
	{
                private int TipoOriginal = 0;

                public Editar()
                {
                        ElementoTipo = typeof(Lbl.Personas.Usuario);

                        InitializeComponent();
                }

                public override void ActualizarControl()
                {
                        Lbl.Personas.Usuario Usu = this.Elemento as Lbl.Personas.Usuario;

                        EntradaContrasena.Text = "";
                        EntradaNombreUsuario.Text = Usu.NombreUsuario;

                        TipoOriginal = Usu.Tipo;
                        if ((Usu.Tipo & 4) == 4)
                                EntradaAcceso.TextKey = "1";
                        else
                                EntradaAcceso.TextKey = "0";

                        // No se pueden agregar o quitar permisos del usuario Administrador, sólo cambiar la contraseña
                        EntradaAcceso.TemporaryReadOnly = Usu.Id == 1;
                        BotonAgregar.Enabled = Usu.Id != 1;
                        BotonQuitar.Enabled = Usu.Id != 1;

                        this.MostrarPermisos(Usu);

                        base.ActualizarControl();
                }


                private void MostrarPermisos(Lbl.Personas.Usuario usuario)
                {
                        Listado.SuspendLayout();
                        Listado.Items.Clear();

                        foreach (Lbl.Sys.Permisos.Permiso Perm in usuario.Pemisos) {
                                this.MostrarPermiso(Perm);
                        }

                        Listado.Sorting = SortOrder.Ascending;
                        Listado.Sort();

                        Listado.ResumeLayout();
                }

                private void MostrarPermiso(Lbl.Sys.Permisos.Permiso permiso)
                {
                        Lbl.Sys.Permisos.Operaciones Nivel = permiso.Operaciones;
                        string Key = permiso.GetHashCode().ToString();
                        ListViewItem Itm = Listado.Items.Add(Key, permiso.Objeto.Nombre, 0);
                        Itm.Tag = permiso;
                        Itm.SubItems.Add(Nivel.ToString());
                        if (permiso.Item == null)
                                Itm.SubItems.Add("Todos");
                        else
                                Itm.SubItems.Add(permiso.Item.ToString());

                        if ((Nivel | Lbl.Sys.Permisos.Operaciones.Total) == Lbl.Sys.Permisos.Operaciones.Total)
                                Itm.ForeColor = System.Drawing.Color.Tomato;
                        else
                                Itm.ForeColor = Listado.ForeColor;
                }

	
                public override void ActualizarElemento()
                {
                        Lbl.Personas.Usuario Pers = this.Elemento as Lbl.Personas.Usuario;

                        int Tipo = TipoOriginal;
                        if (EntradaAcceso.TextKey == "1")
                                Tipo = Tipo | 4;
                        else
                                Tipo = Tipo & (~4);

                        Pers.Tipo = Tipo;

                        Pers.NombreUsuario = EntradaNombreUsuario.Text;

                        if (EntradaContrasena.Text.Length > 0)
                                Pers.Contrasena = EntradaContrasena.Text;

                        base.ActualizarElemento();
                }


                public override Lfx.Types.OperationResult ValidarControl()
                {
                        if (EntradaContrasena.Text.Length > 0) {
                                if (EntradaContrasena.Text.Length < 6 || EntradaContrasena.Text.Length > 32)
                                        return new Lfx.Types.FailureOperationResult("La contraseña debe tener entre 6 y 32 caracteres");
                        }

                        if (Listado.Items.Count == 0) {
                                Lui.Forms.YesNoDialog Pregunta = new Lui.Forms.YesNoDialog("El usuario no tiene ningún permiso asignado y por lo tanto no podrá operar con el sistema. ¿Desea continuar de todos modos?", "Permisos");
                                Pregunta.DialogButtons = Lui.Forms.DialogButtons.YesNo;
                                if(Pregunta.ShowDialog() != DialogResult.OK)
                                        return new Lfx.Types.FailureOperationResult("Debe asignar al menos un permiso al usuario. Utilice la tecla 'Agregar' (F6) para asignar uno o más permisos.");
                        }

                        return base.ValidarControl();
                }

                private void QuitarPermiso(Lbl.Sys.Permisos.Permiso permiso)
                {
                        Lbl.Personas.Usuario Usu = this.Elemento as Lbl.Personas.Usuario;

                        Usu.Pemisos.Remove(permiso);
                        Listado.Items.RemoveByKey(permiso.GetHashCode().ToString());
                        Listado.Changed = true;
                }


                private void BotonQuitar_Click(object sender, System.EventArgs e)
                {
                        if (Listado.SelectedItems.Count > 0) {
                                Lbl.Sys.Permisos.Permiso Perm = Listado.SelectedItems[0].Tag as Lbl.Sys.Permisos.Permiso;
                                if(Perm != null)
                                        QuitarPermiso(Perm);
                        }
                }


                private void BotonAgregar_Click(object sender, System.EventArgs e)
                {
                        Lbl.Personas.Usuario Usu = this.Elemento as Lbl.Personas.Usuario;
                        EditarPermiso FormularioAgregar = new EditarPermiso();
                        FormularioAgregar.Usuario = Usu;

                        if (FormularioAgregar.ShowDialog() == DialogResult.OK) {
                                Lbl.Sys.Permisos.Permiso NuevoPerm = FormularioAgregar.Permiso;
                                Usu.Pemisos.Add(NuevoPerm);
                                Listado.Changed = true;
                                this.MostrarPermiso(NuevoPerm);
                        }
                }

                private void Listado_DoubleClick(object sender, System.EventArgs e)
                {
                        if(Listado.SelectedItems.Count > 0) {
                                ListViewItem Itm = Listado.SelectedItems[0];
                                Lbl.Sys.Permisos.Permiso Perm = Itm.Tag as Lbl.Sys.Permisos.Permiso;
                                if (Perm != null) {
                                        Lbl.Personas.Usuario Usu = this.Elemento as Lbl.Personas.Usuario;
                                        EditarPermiso FormularioAgregar = new EditarPermiso();
                                        FormularioAgregar.Usuario = Usu;
                                        FormularioAgregar.Permiso = Perm;

                                        if (FormularioAgregar.ShowDialog() == DialogResult.OK) {
                                                // Elimino el permiso viejo
                                                Listado.Items.Remove(Itm);
                                                Usu.Pemisos.Remove(Perm);

                                                // Agrego el nuevo
                                                Lbl.Sys.Permisos.Permiso NuevoPerm = FormularioAgregar.Permiso;
                                                Usu.Pemisos.Add(NuevoPerm);

                                                Listado.Changed = true;
                                                this.MostrarPermiso(NuevoPerm);
                                        }
                                }
                        }
                }


                public override Lazaro.Pres.DisplayStyles.IDisplayStyle HeaderDisplayStyle
                {
                        get
                        {
                                return Lazaro.Pres.DisplayStyles.Template.Current.Personas;
                        }
                }
	}
}