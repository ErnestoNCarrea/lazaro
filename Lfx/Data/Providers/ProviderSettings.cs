using System;
using System.Collections.Generic;

namespace qGen.Providers
{
        public class ProviderSettings
        {
                public Dictionary<string, string> Keywords { get; set; }

                public virtual bool CompareColumnDefinitions(Lfx.Data.ColumnDefinition col1, Lfx.Data.ColumnDefinition col2)
                {
                        return col1 == col2;
                }
        }
}
