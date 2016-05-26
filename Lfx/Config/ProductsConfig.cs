using System;
using System.Collections.Generic;
using System.Text;

namespace Lfx.Config
{
        public class ProductsConfig
        {
                private ConfigManager ConfigManager;

                public ProductsConfig(ConfigManager configManager)
                {
                        this.ConfigManager = configManager;
                }


                public int DepositoPredeterminado
                {
                        get
                        {
                                return ConfigManager.ReadGlobalSetting<int>("Sistema.Stock.DepositoPredet", 1);
                        }
                }

                // Si usa situaciones de stock
                public bool StockMultideposito
                {
                        get
                        {
                                return ConfigManager.ReadGlobalSetting<int>("Sistema.Stock.Multideposito", 0) != 0;
                        }
                }

                private static string ps_DefaultCode = null;
                public string CodigoPredeterminado()
                {
                        if (ps_DefaultCode != null)
                                return ps_DefaultCode;

                        // Devuelve el código predeterminado de un artículo
                        int CodPredet = ConfigManager.ReadGlobalSetting<int>("Sistema.Stock.CodigoPredet", 0);

                        switch (CodPredet) {
                                case 0:
                                        // Usar el código autonumérico integrado
                                        ps_DefaultCode = "id_articulo";
                                        break;
                                default:
                                        // Usar un código en particular
                                        ps_DefaultCode = "codigo" + CodPredet.ToString();
                                        break;
                        }
                        return ps_DefaultCode;
                }
        }
}
