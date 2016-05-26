using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Sys.Permisos
{
        /// <summary>
        /// Describe un tipo de acceso que puede tener una persona.
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Objeto de Permiso")]
        [Lbl.Atributos.Datos(TablaDatos = "sys_permisos_objetos", CampoId = "id_objeto")]
        [Lbl.Atributos.Presentacion()]
        public class Objeto : ElementoDeDatos
        {
                //Heredar constructor
		public Objeto(Lfx.Data.Connection dataBase)
                        : base(dataBase) { }

		public Objeto(Lfx.Data.Connection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Objeto(Lfx.Data.Connection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                public string Tipo
                {
                        get
                        {
                                return this.GetFieldValue<string>("tipo");
                        }
                        set
                        {
                                this.SetFieldValue("tipo", value);
                        }
                }


                public string NombreExtra1
                {
                        get
                        {
                                return this.GetFieldValue<string>("extra1_nombre");
                        }
                        set
                        {
                                this.SetFieldValue("extra1_nombre", value);
                        }
                }

                public string NombreExtra2
                {
                        get
                        {
                                return this.GetFieldValue<string>("extra2_nombre");
                        }
                        set
                        {
                                this.SetFieldValue("extra2_nombre", value);
                        }
                }

                public string NombreExtra3
                {
                        get
                        {
                                return this.GetFieldValue<string>("extra3_nombre");
                        }
                        set
                        {
                                this.SetFieldValue("extra3_nombre", value);
                        }
                }

                public string NombreExtraA
                {
                        get
                        {
                                return this.GetFieldValue<string>("extraa_nombre");
                        }
                        set
                        {
                                this.SetFieldValue("extraa_nombre", value);
                        }
                }

                public string NombreExtraB
                {
                        get
                        {
                                return this.GetFieldValue<string>("extrab_nombre");
                        }
                        set
                        {
                                this.SetFieldValue("extrab_nombre", value);
                        }
                }

                public string NombreExtraC
                {
                        get
                        {
                                return this.GetFieldValue<string>("extrac_nombre");
                        }
                        set
                        {
                                this.SetFieldValue("extrac_nombre", value);
                        }
                }
        }
}
