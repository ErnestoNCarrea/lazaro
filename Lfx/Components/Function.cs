using System;
using System.Collections.Generic;

namespace Lfx.Components
{
	/// <summary>
	/// Esqueleto del componente.
	/// </summary>
	public abstract class Function : IFunction
	{
                public Lfx.Workspace Workspace { get; set; }
                public string ExecutableName { get; set; }
                public object[] Arguments { get; set; }
                public Lfx.Components.FunctionTypes FunctionType { get; set; } = FunctionTypes.MdiChildren;

		public Function()
		{
		}

		public virtual object Run(bool wait)
		{
			return null;
		}

		public virtual object Run()
		{
			return Run(false);
		}

		public virtual Lfx.Types.OperationResult Try()
		{
			return new Types.SuccessOperationResult();
		}
	}
}
