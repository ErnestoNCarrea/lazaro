using Lfx.Types;
using System;

namespace Lfx.Components
{
        /// <summary>
        /// Un componente cargado en memoria.
        /// </summary>
        public interface IComponent
        {
                Lfx.Workspace Workspace { get; set; }

                OperationResult Try();
                OperationResult Register();
                OperationResult Run();
                object Do(string action, object[] argv);

                Lfx.Components.RegisteredTypeCollection GetRegisteredTypes();
        }
}
