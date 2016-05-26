using System;
using System.Collections.Generic;

namespace Lfx.Components
{
        public class RegisteredTypeCollection : List<IRegisteredType>
        {
                new public void Add(IRegisteredType tipo)
                {
                        foreach (IRegisteredType ti in this) {
                                if (ti.LblType == tipo.LblType) {
                                        // Ya existe... lo sobreescribo
                                        ti.Actions.AddRange(tipo.Actions);
                                }
                        }
                        base.Add(tipo);
                }

                public IRegisteredType GetByLblType(Type tipo)
                {
                        foreach (IRegisteredType ti in this) {
                                if (ti.LblType == tipo)
                                        return ti;
                        }
                        return null;
                }


                public Type GetHandler(Type lblType, string verb)
                {
                        // Primero busco en los tipos registrados por los componentes
                        Lfx.Components.IRegisteredType Func = Lfx.Components.Manager.RegisteredTypes.GetByLblType(lblType);
                        if (Func != null && Func.Actions.ContainsKey(verb))
                                return Func.Actions[verb].Handler;

                        // Busco recursivamente hacia abajo en las herencias
                        if (lblType.BaseType != null && lblType.BaseType.ToString() != "Lbl.ElementoDeDatos") {
                                return GetHandler(lblType.BaseType, verb);
                        }

                        return null;
                }
        }
}
