using System;
using System.Collections.Generic;

namespace Lbl.Sys
{
        public partial class Config
        {
                public class Articulos
                {
                        /// <summary>
                        /// La cantidad de decimales para las existencias.
                        /// </summary>
                        public static int Decimales = 0;

                        /* 
                        private int m_Decimales = -1;
                        /// <summary>
                        /// La cantidad de decimales para las existencias.
                        /// </summary>
                        public int Decimales
                        {
                                get
                                {
                                        if (m_Decimales == -1)
                                                m_Decimales = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Stock.Decimales", 0);
                                        return m_Decimales;
                                }
                                set
                                {
                                        m_Decimales = value;
                                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Stock.Decimales", m_Decimales);
                                }
                        } */
                }
        }
}
