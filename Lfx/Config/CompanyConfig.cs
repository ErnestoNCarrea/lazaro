using System;
using System.Collections.Generic;
using System.Text;

namespace Lfx.Config
{
        public class CompanyConfig
        {
                private ConfigManager ConfigManager;
                private Lfx.Data.Row m_Sucursal;

                public CompanyConfig(ConfigManager configManager)
                {
                        this.ConfigManager = configManager;
                }

                private Lfx.Data.Row Sucursal
                {
                        get
                        {
                                if (m_Sucursal == null)
                                        m_Sucursal = Lfx.Workspace.Master.Tables["sucursales"].FastRows[this.SucursalActual];
                                return m_Sucursal;
                        }
                }

                public int SucursalActual
                {
                        get
                        {
                                return ConfigManager.ReadLocalSettingInt("Company", "Branch", 1);
                        }
                        set
                        {
                                ConfigManager.WriteLocalSetting("Company", "Branch", value);
                        }
                }

                public string Telefono
                {
                        get
                        {
                                return this.Sucursal["telefono"].ToString();
                        }
                }

                public string Domicilio
                {
                        get
                        {
                                return this.Sucursal["direccion"].ToString();
                        }
                }

                public string NombreLocalidad
                {
                        get
                        {
                                return ConfigManager.DataBase.FieldString("SELECT nombre FROM ciudades WHERE id_ciudad=(SELECT id_ciudad FROM sucursales WHERE id_sucursal=" + this.SucursalActual.ToString() + ")");
                        }
                }

                public int IdLocalidad
                {
                        get
                        {
                                int City = ConfigManager.DataBase.FieldInt("SELECT id_ciudad FROM sucursales WHERE id_sucursal=" + ConfigManager.Empresa.SucursalActual.ToString());
                                if (City > 0)
                                        return City;
                                else
                                        return 1;
                        }
                }

                public int SituacionOrigenPredeterminada
                {
                        get
                        {
                                int SituacionOrigen = ConfigManager.DataBase.FieldInt("SELECT situacionorigen FROM sucursales WHERE id_sucursal=" + ConfigManager.Empresa.SucursalActual.ToString());
                                if (SituacionOrigen > 0)
                                        return SituacionOrigen;
                                else
                                        return 1;
                        }
                }

                public int CajaDiaria
                {
                        get
                        {
                                int IdCajaDiaria = ConfigManager.DataBase.FieldInt("SELECT id_caja_diaria FROM sucursales WHERE id_sucursal=" + ConfigManager.Empresa.SucursalActual.ToString());
                                if (IdCajaDiaria > 0)
                                        return IdCajaDiaria;
                                else
                                        return 999;
                        }
                }

                public int CajaCheques
                {
                        get
                        {
                                int IdCajaCheques = ConfigManager.DataBase.FieldInt("SELECT id_caja_cheques FROM sucursales WHERE id_sucursal=" + ConfigManager.Empresa.SucursalActual.ToString());
                                if (IdCajaCheques > 0)
                                        return IdCajaCheques;
                                else
                                        return this.CajaDiaria;
                        }
                }
        }
}
