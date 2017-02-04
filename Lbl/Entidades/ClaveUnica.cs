using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Entidades
{
        public enum TipoClaveUnica
        {
                PersonasFisicas = 1,
                PersonasJuridicas = 2,
                PersonasFisicasYJuridicas = 3,
                CuentasBancarias = 4
        }

        /// <summary>
        /// Representa una Clave Única (por ejemplo un DNI, SSN, CBU, IBAN, etc.).
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Clave Única")]
        [Lbl.Atributos.Datos(TablaDatos = "tipo_doc", CampoId = "id_tipo_doc")]
        [Lbl.Atributos.Presentacion()]
        public class ClaveUnica : ElementoDeDatos
        {
                //Heredar constructor
                public ClaveUnica(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public ClaveUnica(Lfx.Data.IConnection dataBase, int itemId)
                        : base(dataBase, itemId) { }

                public ClaveUnica(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                public string Descripcion
                {
                        get
                        {
                                return this.GetFieldValue<string>("descripcion");
                        }
                        set
                        {
                                this.Registro["descripcion"] = value;
                        }
                }


                public TipoClaveUnica Tipo
                {
                        get
                        {
                                return (TipoClaveUnica)(this.GetFieldValue<int>("tipo"));
                        }
                        set
                        {
                                this.Registro["tipo"] = (int)(value);
                        }
                }
        }
}

