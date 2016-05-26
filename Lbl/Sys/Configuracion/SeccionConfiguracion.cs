using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Sys.Configuracion
{
        public class SeccionConfiguracion
        {
                public Lfx.Data.Connection DataBase
                {
                        get
                        {
                                return Lfx.Workspace.Master.MasterConnection;
                        }
                }
        }
}
