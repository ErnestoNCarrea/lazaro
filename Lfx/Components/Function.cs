using System;
using System.Collections.Generic;

namespace Lfx.Components
{
	/// <summary>
	/// Esqueleto del componente.
	/// </summary>
	public class Function
	{
                protected Lfx.Workspace m_Workspace;
		public string ExecutableName = null;
		public object[] Arguments = null;
                public Lfx.Components.FunctionTypes FunctionType = FunctionTypes.MdiChildren;

		public Function()
		{
		}

		public Lfx.Workspace Workspace
		{
			get
			{
				return m_Workspace;
			}
			set
			{
				m_Workspace = value;
			}
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
