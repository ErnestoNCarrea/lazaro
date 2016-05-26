using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Entidades
{

        /// <summary>
        /// Representa un País.
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "País")]
        [Lbl.Atributos.Datos(TablaDatos = "paises", CampoId = "id_pais")]
        [Lbl.Atributos.Presentacion()]
        public class Pais : ElementoDeDatos
        {
                private ClaveUnica m_ClavePersonasFisicas = null, m_ClavePersonasJuridicas = null, m_ClaveBancaria = null;
                private Moneda m_Moneda = null;

                //Heredar constructor
                public Pais(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

                public Pais(Lfx.Data.Connection dataBase, int itemId)
                        : base(dataBase, itemId) { }

                public Pais(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                public string CodigoIso
                {
                        get
                        {
                                return this.GetFieldValue<string>("iso");
                        }
                        set
                        {
                                this.Registro["iso"] = value;
                        }
                }

                

                /// <summary>
                /// El tipo de clave utilizada para identificar a las personas (DNI, CI, SSN, etc.)
                /// </summary>
                public ClaveUnica ClavePersonasFisicas
                {
                        get
                        {
                                if (m_ClavePersonasFisicas == null)
                                        m_ClavePersonasFisicas = new ClaveUnica(this.Connection, this.GetFieldValue<int>("clavefis"));
                                return m_ClavePersonasFisicas;
                        }
                }


                /// <summary>
                /// El tipo de clave utilizada para identificar a las personas jurídicas (CUIT, RUT, NIF, etc.)
                /// </summary>
                public ClaveUnica ClavePersonasJuridicas
                {
                        get
                        {
                                if (m_ClavePersonasJuridicas == null && this.GetFieldValue<int>("clavejur") > 0)
                                        m_ClavePersonasJuridicas = new ClaveUnica(this.Connection, this.GetFieldValue<int>("clavejur"));
                                return m_ClavePersonasJuridicas;
                        }
                }


                /// <summary>
                /// El tipo de clave utilizada para identificar las cuentas bancarias (CBU, IBAN, CLABE, etc.)
                /// </summary>
                public ClaveUnica ClaveBancaria
                {
                        get
                        {
                                if (m_ClaveBancaria == null && this.GetFieldValue<int>("claveban") > 0)
                                        m_ClaveBancaria = new ClaveUnica(this.Connection, this.GetFieldValue<int>("claveban"));
                                return m_ClaveBancaria;
                        }
                }


                /// <summary>
                /// La divisa utilizada en el país.
                /// </summary>
                public Moneda Moneda
                {
                        get
                        {
                                if (m_Moneda == null)
                                        m_Moneda = new Moneda(this.Connection, this.GetFieldValue<int>("id_moneda"));
                                return m_Moneda;
                        }
                }


                /// <summary>
                /// La tasa de IVA normal.
                /// </summary>
                public decimal Iva1
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("iva1");
                        }
                        set
                        {
                                this.SetFieldValue("iva1", value);
                        }
                }


                /// <summary>
                /// La tasa de IVA reducida.
                /// </summary>
                public decimal Iva2
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("iva2");
                        }
                        set
                        {
                                this.SetFieldValue("iva2", value);
                        }
                }
        }
}
