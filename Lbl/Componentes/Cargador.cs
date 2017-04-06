using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Componentes
{
        public class Cargador
        {
                /// <summary>
                /// Carga en memoria los componentes registrados en la base de datos
                /// </summary>
                public static void CargarComponentes()
                {
                        // Cargo el componente Core
                        Lbl.Componentes.Componente ComLfc = new Lbl.Componentes.Componente(Lfx.Workspace.Master.MasterConnection);
                        ComLfc.Crear();

                        ComLfc.Nombre = "Lfc";
                        ComLfc.EspacioNombres = "Lfc";
                        ComLfc.Assembly = System.Reflection.Assembly.LoadFrom("Lfc.dll");
                        Lfx.Components.Manager.RegisterComponent(ComLfc);

                        if (Lfx.Workspace.Master.Tables.ContainsKey("sys_components")) {
                                Lbl.ColeccionGenerica<Lbl.Componentes.Componente> Comps = Lbl.Componentes.Componente.ObtenerActivos();
                                // Inicializar todos los componentes
                                foreach (Lbl.Componentes.Componente Comp in Comps) {
                                        // Registro el componente con el actualizador
                                        if (Lfx.Updates.Updater.Master != null) {
                                                Lfx.Updates.Package Pkg = new Lfx.Updates.Package();
                                                Pkg.Name = Comp.EspacioNombres;
                                                Pkg.RelativePath = "Components" + System.IO.Path.DirectorySeparatorChar + Comp.EspacioNombres + System.IO.Path.DirectorySeparatorChar;
                                                Pkg.Url = Comp.UrlActualizaciones;
                                                Lfx.Updates.Updater.Master.Packages.Add(Pkg);
                                        }

                                        try {
                                                Lfx.Components.Manager.RegisterComponent(Comp);
                                                if (Comp.Estructura != null) {
                                                        var Doc = new System.Xml.XmlDocument();
                                                        Doc.LoadXml(Comp.Estructura);
                                                        Lfx.Workspace.Master.Structure.AddToBuiltIn(Doc);
                                                }
                                                if (Lfx.Environment.SystemInformation.DesignMode == false && Comp.ObtenerVersionActual() > Comp.Version) {
                                                        // Actualizo el CIF y la estrucutra en la BD
                                                        Comp.Version = Comp.ObtenerVersionActual();
                                                        Comp.Guardar();
                                                }
                                        } catch (Exception ex) {
                                                if (Lfx.Workspace.Master != null && Lfx.Workspace.Master.DebugMode == false) {
                                                        Lfx.Workspace.Master.RunTime.Toast("No se puede registrar el componente " + Comp.Nombre + "." + ex.Message, "Error");
                                                        throw;
                                                } else {
                                                        throw;
                                                }
                                        }
                                }
                        }
                }
        }
}
