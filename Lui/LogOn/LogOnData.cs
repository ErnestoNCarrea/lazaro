using System;
using System.Collections.Generic;
using System.Text;

namespace Lui.LogOn
{
	public static class LogOnData
	{
		public static bool ValidateAccess(string accessName, Lbl.Sys.Permisos.Operaciones operacion)
		{
                        bool Tiene = Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(accessName, operacion);
			if(Tiene == false)
				Lfx.Workspace.Master.RunTime.Toast("No tiene permiso para realizar la operación solicitada.", "Error");
			return Tiene;
		}

                public static bool ValidateAccess(Lbl.IElementoDeDatos elemento, Lbl.Sys.Permisos.Operaciones operacion)
                {
                        bool Tiene = Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(elemento, operacion);
                        if (Tiene == false)
                                Lfx.Workspace.Master.RunTime.Toast("No tiene permiso para realizar la operación solicitada.", "Error");
                        return Tiene;
                }

                public static bool ValidateAccess(Type tipo, Lbl.Sys.Permisos.Operaciones operacion)
                {
                        bool Tiene = Lbl.Sys.Config.Actual.UsuarioConectado.TienePermiso(tipo, operacion);
                        if (Tiene == false)
                                Lfx.Workspace.Master.RunTime.Toast("No tiene permiso para realizar la operación solicitada.", "Error");
                        return Tiene;
                }

		public static bool RevalidateAccess()
		{
			Lui.LogOn.FormRevalidateAccess Reval = new Lui.LogOn.FormRevalidateAccess();
			bool Res = Reval.Revalidate();
                        Reval.Close();
                        Reval.Dispose();
                        Reval = null;
                        return Res;
		}


		public static bool ValidateAsAdmin()
		{
			return ValidateAsAdmin(null);
		}

		public static bool ValidateAsAdmin(string Explain)
		{
			Lui.LogOn.FormRevalidateAccess Reval = new Lui.LogOn.FormRevalidateAccess();
			if(Explain != null)
				Reval.Explain = Explain;
			return Reval.ValidateAs(1);
		}
	}
}