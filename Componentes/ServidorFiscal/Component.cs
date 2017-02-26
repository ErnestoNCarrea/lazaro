using Lfx.Components;
using System;
using Lfx;
using Lfx.Types;
using System.Windows.Forms;

namespace ServidorFiscal
{
        public class Component : IComponent
        {
                public Workspace Workspace { get; set; }

                public RegisteredTypeCollection GetRegisteredTypes()
                {
                        return null;
                }

                public OperationResult Register()
                {
                        return new SuccessOperationResult();
                }

                public OperationResult Run()
                {
                        return new SuccessOperationResult();
                }

                public OperationResult Try()
                {
                        return new SuccessOperationResult();
                }

                public object Do(string actionName, object[] argv)
                {
                        switch (actionName) {
                                case "ServidorFiscal":
                                        var Sf = new ServidorFiscal();
                                        return Sf.Run(argv);
                                default:
                                        return new FailureOperationResult("No existe la función " + actionName);
                        }
                }
        }
}
