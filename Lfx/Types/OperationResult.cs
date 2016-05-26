using System;
using System.Collections.Generic;
using System.Text;

namespace Lfx.Types
{
        /// <summary>
        /// Representa el resultado de una operación.
        /// </summary>
	public class OperationResult
	{
		public bool Success = false;
		public string Message = null;
                public bool Cancel = false;

		public OperationResult()
		{
		}

		public OperationResult(bool success)
		{
			this.Success = success;
		}

		public OperationResult(bool success, string message)
		{
			this.Success = success;
			this.Message = message;
		}

                public override string ToString()
                {
                        string Res = this.GetType().ToString();
                        if (this.Message != null)
                                Res += ": " + this.Message;

                        return Res;
                }
	}
        
        /// <summary>
        /// Representa el resultado exitoso de una operación.
        /// </summary>
	public class SuccessOperationResult : OperationResult
	{
		public SuccessOperationResult()
			: base(true)
		{
		}

                public SuccessOperationResult(string message)
                        : base(true, message)
                {
                }
	}

        /// <summary>
        /// Representa la cancelación de una operación, pero sin un error.
        /// </summary>
        public class CancelOperationResult : OperationResult
        {
                public CancelOperationResult()
                        : base(false)
                {
                        this.Cancel = true;
                }
        }

        /// <summary>
        /// Representa un error en una operación.
        /// </summary>
	public class FailureOperationResult : OperationResult
	{
		public FailureOperationResult(string message)
			: base (false, message)
		{
		}
	}

	public class NoAccessOperationResult : FailureOperationResult
	{
                public NoAccessOperationResult(string mensaje)
                        : base(mensaje)
                {
                }

		public NoAccessOperationResult()
			:base ("No tiene permiso para realizar la operación solicitada")
		{
		}
	}
}