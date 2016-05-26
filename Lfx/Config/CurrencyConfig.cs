using System;
using System.Collections.Generic;
using System.Text;

namespace Lfx.Config
{
        public class CurrencyConfig
        {
                private ConfigManager ConfigManager;

                public CurrencyConfig(ConfigManager configManager)
                {
                        this.ConfigManager = configManager;
                }

                // La cantidad de decimales para el stock
                private static int m_Decimales = -1;
                public int Decimales
                {
                        get
                        {
                                if (m_Decimales == -1)
                                        m_Decimales = ConfigManager.ReadGlobalSetting<int>("Sistema.Moneda.Decimales", 2);
                                return m_Decimales;
                        }
                }

                private static int m_DecimalesCosto = -1;
                public int DecimalesCosto
                {
                        get
                        {
                                if (m_DecimalesCosto == -1)
                                        m_DecimalesCosto = ConfigManager.ReadGlobalSetting<int>("Sistema.Moneda.DecimalesCosto", this.Decimales);
                                return m_DecimalesCosto;
                        }
                }

                private static int m_DecimalesFinal = -1;
                public int DecimalesFinal
                {
                        get
                        {
                                if (m_DecimalesFinal == -1)
                                        m_DecimalesFinal = ConfigManager.ReadGlobalSetting<int>("Sistema.Moneda.DecimalesFinal", this.Decimales);
                                return m_DecimalesFinal;
                        }
                }
        }
}
