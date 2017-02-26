using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Mail;

namespace Lfx.Components
{
	/// <summary>
	/// Infraestructura para el manejo de componentes.
	/// </summary>
	public static class Manager
	{
                private static readonly ILog Log = LogManager.GetLogger(typeof(Manager));

                public static Dictionary<string, IComponentInfo> ComponentesCargados = new Dictionary<string, IComponentInfo>();
                public static RegisteredTypeCollection RegisteredTypes = new RegisteredTypeCollection();

                public static Lfx.Types.OperationResult RegisterComponent(IComponentInfo componentInfo)
                {
                        // Simplemente lo cargo... eso ya registra los tipos
                        if (ComponentesCargados.ContainsKey(componentInfo.EspacioNombres) == false) {
                                Log.Info("Cargando componente " + componentInfo.EspacioNombres);
                                var Res = componentInfo.Load();
                                if (Res.Success == false)
                                        return Res;

                                // Primero ejecuto la función Try, para decidir si cargo el componenten o no
                                var TryRes = componentInfo.ComponentInstance.Try();
                                if(TryRes.Success) {
                                        ComponentesCargados.Add(componentInfo.EspacioNombres, componentInfo);

                                        var RegTypes = componentInfo.ComponentInstance.GetRegisteredTypes();
                                        if (RegTypes != null) {
                                                foreach (var Tt in RegTypes) {
                                                        Log.Info("  Agregando tipo " + Tt.LblType.ToString());
                                                        RegisteredTypes.Add(Tt);
                                                }
                                        }
                                }
                        }

                        return new Lfx.Types.SuccessOperationResult();
                }
	}
}
