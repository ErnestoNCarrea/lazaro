using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc
{
        public static class Instanciador
        {
                /// <summary>
                /// Crea un formulario de edición para el ElementoDeDatos proporcionado.
                /// </summary>
                /// <param name="elemento">El ElementoDeDatos que se quiere editar.</param>
                /// <returns>Un formulario derivado de Lfc.FormularioEdicion.</returns>
                public static Lfc.FormularioEdicion InstanciarFormularioEdicion(Lbl.IElementoDeDatos elemento)
                {
                        Lfc.FormularioEdicion Res = new Lfc.FormularioEdicion();
                        Type TipoControlEdicion = InferirControlEdicion(elemento.GetType());
                        if (TipoControlEdicion == null)
                                return null;

                        Res.ControlUnico = InstanciarControlEdicion(TipoControlEdicion);
                        Res.FromRow(elemento);

                        return Res;
                }


                public static Type InferirFormularioListado(Type tipo)
                {
                        Type Res = Lfx.Components.Manager.RegisteredTypes.GetHandler(tipo, "list");
                        return Res;
                }


                public static Lfc.FormularioListado InstanciarFormularioListado(Type tipo, string args)
                {
                        object Res;
                        if (args == null || args == string.Empty)
                                Res = Activator.CreateInstance(tipo);
                        else
                                Res = Activator.CreateInstance(tipo, args);

                        if (Res is Lazaro.Pres.Listings.Listing) {
                                Lfc.FormularioListado NewForm = new Lfc.FormularioListado(Res as Lazaro.Pres.Listings.Listing);
                                return NewForm;
                        } else {
                                return Res as Lfc.FormularioListado;
                        }
                }

                private static Lcc.Edicion.ControlEdicion InstanciarControlEdicion(Type tipo)
                {
                        object Res = Activator.CreateInstance(tipo);
                        return Res as Lcc.Edicion.ControlEdicion;
                }


                private static Type InferirControlEdicion(Type tipo)
                {
                        Type Res = Lfx.Components.Manager.RegisteredTypes.GetHandler(tipo, "edit");
                        return Res;
                }
        }
}
