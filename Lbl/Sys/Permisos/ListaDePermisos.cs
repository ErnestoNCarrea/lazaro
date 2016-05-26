using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Sys.Permisos
{
        public class ListaDePermisos : Lbl.ColeccionGenerica<Permiso>
        {
                public Lbl.Personas.Usuario Usuario = null;

                public ListaDePermisos(Lbl.Personas.Usuario usuario)
                        : base(usuario.Connection) { }

                public ListaDePermisos(Lbl.Personas.Usuario usuario, System.Data.DataTable tabla)
                        : base(usuario.Connection, tabla)
                {
                        this.Usuario = usuario;
                        foreach (Permiso Perm in this) {
                                Perm.Usuario = usuario;
                        }
                }

                public bool TieneAccesoGlobal()
                {
                        foreach (Permiso Acc in this) {
                                if (Acc.Objeto.Tipo == "Global" && (Acc.Operaciones & Operaciones.Total) == Operaciones.Total) {
                                        return true;
                                }
                        }
                        return false;
                }

                public bool TienePermiso(string tipo, Operaciones operacion)
                {
                        if (this.TieneAccesoGlobal())
                                return true;

                        foreach (Permiso Perm in this) {
                                if (Perm.Objeto.Tipo == tipo &&
                                        ((Perm.Operaciones & operacion) == operacion || (Perm.Operaciones & Operaciones.Total) == Operaciones.Total)) {
                                                return true;
                                }
                        }

                        return false;
                }

                public bool TienePermiso(IElementoDeDatos elemento, Operaciones operacion)
                {
                        if (this.TieneAccesoGlobal())
                                return true;


                        string TipoElemento = elemento.GetType().ToString();
                        foreach (Permiso Perm in this) {
                                if (Perm.Objeto.Tipo == TipoElemento &&
                                        ((Perm.Operaciones & operacion) == operacion || (Perm.Operaciones & Operaciones.Total) == Operaciones.Total) &&
                                        (Perm.Item == null || Perm.Item.Contains(elemento.Id))) {
                                                return true;
                                }
                        }

                        return TienePermiso(elemento.GetType().BaseType, operacion);
                }

                public bool TienePermiso(Type tipo, Operaciones operacion)
                {
                        if (this.TieneAccesoGlobal())
                                return true;

                        if (tipo == null)
                                return false;

                        string TipoElemento = tipo.ToString();
                        foreach (Permiso Perm in this) {
                                if (Perm.Objeto.Tipo == TipoElemento &&
                                        ((Perm.Operaciones & operacion) == operacion || (Perm.Operaciones & Operaciones.Total) == Operaciones.Total)) {
                                                return true;
                                }
                        }

                        if (tipo != typeof(Lbl.ElementoDeDatos) && tipo != typeof(System.Object))
                                return TienePermiso(tipo.BaseType, operacion);
                        else
                                return false;
                }
        }
}
