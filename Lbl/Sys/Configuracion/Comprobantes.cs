using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Sys.Configuracion
{
        public class Comprobantes : SeccionConfiguracion
        {
                public Comprobantes()
                {
                }

                public int IdClientePredeterminado
                {
                        get
                        {
                                return Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Documentos.ClientePredet", 0);
                        }
                }
        }
}
