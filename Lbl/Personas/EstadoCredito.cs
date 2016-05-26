using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Personas
{
	public enum EstadoCredito
	{
		Normal = 0,
		EnPlanDePagos = 5,
		Suspendido = 10,
		SuspendidoPermanente = 100,
                Judicializado = 110
	}
}
