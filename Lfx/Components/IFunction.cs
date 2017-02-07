using System;

namespace Lfx.Components
{
        public interface IFunction
        {
                Lfx.Workspace Workspace { get; set; }
                string ExecutableName { get; set; }
                object[] Arguments { get; set; }
                Lfx.Components.FunctionTypes FunctionType { get; set; }

                object Run(bool wait);
                object Run();
                Lfx.Types.OperationResult Try();
        }
}
