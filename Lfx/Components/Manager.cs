using System;
using System.Collections.Generic;

namespace Lfx.Components
{
	/// <summary>
	/// Infraestructura para el manejo de componentes.
	/// </summary>
	public static class Manager
	{
                public static Dictionary<string, IComponent> ComponentesCargados = new Dictionary<string, IComponent>();
                public static FunctionInfoCollection Functiones = new FunctionInfoCollection();
                public static RegisteredTypeCollection RegisteredTypes = new RegisteredTypeCollection();


                public static Lfx.Types.OperationResult RegisterComponent(IComponent componentInfo)
                {
                        // Simplemente lo cargo... eso ya registra los tipos
                        if (ComponentesCargados.ContainsKey(componentInfo.EspacioNombres) == false) {
                                var Res = componentInfo.Load();
                                if (Res.Success == false)
                                        return Res;

                                // Primero ejecuto la función Try, para decidir si cargo el componenten o no
                                var TryResult = componentInfo.Funciones["Try"].Run() as Lfx.Types.OperationResult;

                                if (TryResult != null && TryResult.Success) {
                                        ComponentesCargados.Add(componentInfo.EspacioNombres, componentInfo);
                                        if (componentInfo.Funciones != null) {
                                                foreach (FunctionInfo Func in componentInfo.Funciones) {
                                                        Func.Load();
                                                        Functiones.Add(Func);
                                                }
                                        }

                                        if (componentInfo.TiposRegistrados != null) {
                                                foreach (IRegisteredType Regt in componentInfo.TiposRegistrados) {
                                                        RegisteredTypes.Add(Regt);
                                                }
                                        }
                                } else {
                                        return TryResult;
                                }
                        }

                        return new Lfx.Types.SuccessOperationResult();
                }


                /* public static Lfx.Components.Function LoadComponent(string componentName)
		{
			return LoadComponent(componentName, componentName);
		}


                public static Lfx.Components.Function LoadComponent(string componentName, string functionName)
		{
			string[] WhereToLook;
			if(Lfx.Workspace.Master.DebugMode) {
				WhereToLook = new string[] {
                                        Lfx.Environment.Folders.ApplicationFolder + @"../../../Componentes/bin/" + componentName + ".dll",
					Lfx.Environment.Folders.ApplicationFolder + @"../../../" + componentName + @"/bin/" + componentName + ".dll",
					Lfx.Environment.Folders.ApplicationFolder + @"../../../" + componentName + @"/bin/Debug/" + componentName + ".dll",
                                        Lfx.Environment.Folders.ApplicationFolder + @"../../../Componentes/" + componentName + @"/bin/" + componentName + ".dll",
					Lfx.Environment.Folders.ApplicationFolder + @"../../../Componentes/" + componentName + @"/bin/Debug/" + componentName + ".dll",
					Lfx.Environment.Folders.ComponentsFolder + componentName + ".dll",
					Lfx.Environment.Folders.ApplicationFolder + componentName + ".dll"
				};
			} else {
				WhereToLook = new string[] {
					Lfx.Environment.Folders.ComponentsFolder + componentName + ".dll",
					Lfx.Environment.Folders.ApplicationFolder + componentName + ".dll"
				};
			}

			System.Reflection.Assembly ComponentAssembly = null;
			foreach(string Archivo in WhereToLook) {
				if(System.IO.File.Exists(Archivo)) {
					try {
						ComponentAssembly = System.Reflection.Assembly.LoadFrom(Archivo);
						break;
					}
					catch {
						//Nada
					}
				}
			}
		
			if(ComponentAssembly == null)
				return null;
			
                        Lfx.Components.Function Res = (Lfx.Components.Function)ComponentAssembly.CreateInstance(componentName + "." + functionName);
                        return Res;
		} */
	}
}
