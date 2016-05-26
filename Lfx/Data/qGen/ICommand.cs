using System;
using System.Collections.Generic;

namespace qGen
{
        public interface ICommand
        {
                Where WhereClause { get; set; }
                SqlModes SqlMode { get; set; }

                void SetupDbCommand(ref System.Data.IDbCommand baseCommand);
        }
}
