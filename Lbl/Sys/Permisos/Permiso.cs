using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Sys.Permisos
{
        /// <summary>
        /// Describe una instancia de un permiso en particular.
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Permiso", Grupo = "Permisos")]
        [Lbl.Atributos.Datos(TablaDatos = "sys_permisos", CampoId = "id_permiso")]
        [Lbl.Atributos.Presentacion()]
        public class Permiso : ElementoDeDatos
        {
                public ListaIds Item = null;
                public Lbl.Personas.Usuario Usuario = null;
                public Objeto Objeto = null;

                //Heredar constructor
		public Permiso(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

		public Permiso(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Permiso(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

                public Permiso(Lbl.Personas.Usuario usuario, Objeto tipo, Operaciones ops, ListaIds item)
                        : this(usuario.Connection)
                {
                        this.Usuario = usuario;
                        this.Objeto = tipo;
                        this.Operaciones = ops;
                        this.Item = item;
                }


                public override void OnLoad()
                {
                        if (this.GetFieldValue<int>("id_objeto") > 0)
                                this.Objeto = new Permisos.Objeto(this.Connection, this.GetFieldValue<int>("id_objeto"));
                        else
                                this.Objeto = null;

                        if (this.GetFieldValue<string>("items") != null)
                                this.Item = new ListaIds(this.GetFieldValue<string>("items"));
                        else
                                this.Item = null;

                        base.OnLoad();
                }

                public Operaciones Operaciones
                {
                        get
                        {
                                return (Operaciones)(this.GetFieldValue<int>("ops"));
                        }
                        set
                        {
                                this.SetFieldValue("ops", (int)value);
                        }
                }

                public override string ToString()
                {
                        return this.Objeto.Nombre + ": " + this.Operaciones.ToString();
                }
        }
}
