using System;
using System.Collections.Generic;
using System.Text;

namespace Lcc
{
        public class LccEventArgs : System.EventArgs
	{
                public Lfx.Types.OperationResult Result;
        }

        public delegate void LccEventHandler(object sender, ref LccEventArgs e);
}
