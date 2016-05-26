using System;
using System.Collections.Generic;

namespace Lfx.Components
{
        public class FunctionInfoCollection : List<FunctionInfo>
        {
                public FunctionInfo this[string functionName]
                {
                        get
                        {
                                foreach (FunctionInfo ti in this) {
                                        if (ti.Nombre == functionName)
                                                return ti;
                                }
                                return null;
                        }
                }


                public bool ContainsKey(string functionName)
                {
                        foreach (FunctionInfo ti in this) {
                                if (ti.Nombre == functionName)
                                        return true;
                        }
                        return false;
                }
        }
}
