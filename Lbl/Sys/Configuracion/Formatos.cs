using System;
using System.Collections.Generic;

namespace Lbl.Sys.Configuracion
{
        public class Formatos : SeccionConfiguracion
        {
                public Formatos()
                {
                }


                private string m_FormatoMoneda = null;
                public string FormatoMoneda
                {
                        get
                        {
                                if (m_FormatoMoneda == null)
                                        m_FormatoMoneda = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Formato.Moneda", "#.00");
                                return m_FormatoMoneda;
                        }
                }
        }
}
