using System;

namespace System
{
        public static class TypeExtension
        {
                public static T GetAttribute<T>(this System.Type tipo) where T : Attribute
                {
                        object[] Attribs = tipo.GetCustomAttributes(true);
                        foreach (Attribute Attrib in Attribs) {
                                if (Attrib is T)
                                        return Attrib as T;
                        }
                        return null;
                }
        }
}
