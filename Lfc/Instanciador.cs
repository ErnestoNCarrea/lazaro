using log4net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc
{
        public static class Instanciador
        {
                private static readonly ILog Log = LogManager.GetLogger(typeof(Instanciador));

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
                        Log.Info("Instanciando " + tipo.FullName);

                        object Res;
                        if (args == null || args == string.Empty) {
                                Res = Activator.CreateInstance(tipo);
                        } else {
                                var ConstructorQueAceptaUnString = tipo.GetConstructor(new Type[] { typeof(string) });
                                if(ConstructorQueAceptaUnString == null) {
                                        // No tiene un constructor que acepta un parámetro string, llamo al constructor sin parámetros
                                        Res = Activator.CreateInstance(tipo);
                                } else {
                                        // Sí tiene un constructor que acepta un parámetro string, le paso el parámetro
                                        Res = Activator.CreateInstance(tipo, args);
                                }
                        }

                        if (Res is Lazaro.Pres.Listings.Listing) {
                                Log.Info("Devolvió Lazaro.Pres.Listings.Listing, creando un formulario para contenerlo");
                                Lfc.FormularioListado NewForm = new Lfc.FormularioListado(Res as Lazaro.Pres.Listings.Listing);
                                return NewForm;
                        } else {
                                Log.Info("Devolvió " + Res.GetType().FullName + ", que deriva de " + Res.GetType().BaseType.FullName);
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
