using System;
using System.Collections.Generic;

namespace Lfx.Components
{
        public class RegisteredType : IRegisteredType
        {
                public ActionCollection Actions { get; set; }
                public Type LblType { get; set; }

                public RegisteredType(Type tipo, Lfx.Components.ActionCollection actions)
                {
                        if (tipo.GetInterface("Lbl.IElementoDeDatos", false) == null)
                                throw new ArgumentException("tipo debe ser un derivado de Lbl.ElementoDeDatos");

                        this.LblType = tipo;
                        this.Actions = new ActionCollection();
                        if (actions != null)
                                this.Actions.AddRange(actions);
                }

                public override string ToString()
                {
                        return this.LblType.ToString();
                }
        }
}
