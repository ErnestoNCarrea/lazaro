using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Sys
{
        public partial class Config
        {
                public class Empresa : Configuracion.SeccionConfiguracion
                {
                        private static Lbl.Impuestos.Alicuota m_AlicuotaPredeterminada = null;
                        private static ColeccionGenerica<Lbl.Comprobantes.PuntoDeVenta> m_PuntosDeVenta = null;

                        public static Lbl.Entidades.Sucursal SucursalActual = null;

                        public static int SituacionTributaria
                        {
                                get
                                {
                                        return Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Empresa.Situacion", 2);
                                }
                                set
                                {
                                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Empresa.Situacion", value);
                                }
                        }


                        public static Lbl.Impuestos.Alicuota AlicuotaPredeterminada
                        {
                                get
                                {
                                        if (m_AlicuotaPredeterminada == null) {
                                                if (SituacionTributaria == 4 || SituacionTributaria == 5)
                                                        // Monotributistas y exentos usan alícuota del 0%
                                                        m_AlicuotaPredeterminada = new Impuestos.Alicuota(Lfx.Workspace.Master.MasterConnection, 4);
                                                else
                                                        // El resto usan IVA tasa nomral
                                                        m_AlicuotaPredeterminada = new Impuestos.Alicuota(Lfx.Workspace.Master.MasterConnection, 1);
                                        }

                                        return m_AlicuotaPredeterminada;
                                }
                        }


                        public static string Nombre
                        {
                                get
                                {
                                        return Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Empresa.Nombre", "");
                                }
                                set
                                {
                                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Empresa.Nombre", value.Trim());
                                }
                        }


                        public static int Id
                        {
                                get
                                {
                                        return Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<int>("Sistema.Empresa.Id", 1);
                                }
                                set
                                {
                                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Empresa.Id", value);
                                }
                        }


                        public static string RazonSocial
                        {
                                get
                                {
                                        string Predet;
                                        if (string.Compare(Nombre, "Empresa sin nombre") == 0)
                                                Predet = "Compañía sin nombre";
                                        else
                                                Predet = Nombre;

                                        return Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Empresa.RazonSocial", Predet);
                                }
                                set
                                {
                                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Empresa.RazonSocial", value.Trim());
                                }
                        }

                        public static IIdentificadorUnico ClaveTributaria
                        {
                                get
                                {
                                        string Res = Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Empresa.CUIT", "");
                                        if (Res == "" || Res == "00-00000000-0")
                                                return null;
                                        else
                                                return new Personas.Claves.Cuit(Res);
                                }
                                set
                                {
                                        if (value == null)
                                                Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Empresa.CUIT", "", 0);
                                        else
                                                Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Empresa.CUIT", value.ToString(), 0);
                                }
                        }

                        public static string Email
                        {
                                get
                                {
                                        return Lfx.Workspace.Master.CurrentConfig.ReadGlobalSetting<string>("Sistema.Empresa.Email", "");
                                }
                                set
                                {
                                        Lfx.Workspace.Master.CurrentConfig.WriteGlobalSetting("Sistema.Empresa.Email", value);
                                }
                        }


                        public static ColeccionGenerica<Lbl.Comprobantes.PuntoDeVenta> PuntosDeVenta
                        {
                                get
                                {
                                        if (m_PuntosDeVenta == null) {
                                                System.Data.DataTable TablaPvs = Lfx.Workspace.Master.MasterConnection.Select("SELECT * FROM pvs");
                                                m_PuntosDeVenta = new Lbl.ColeccionGenerica<Lbl.Comprobantes.PuntoDeVenta>(Lfx.Workspace.Master.MasterConnection, TablaPvs);
                                        }
                                        return m_PuntosDeVenta;
                                }
                        }
                }
        }
}