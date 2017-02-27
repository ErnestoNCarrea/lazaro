using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl
{
        /// <summary>
        /// Describe una etiqueta que se puede asociar a un ElementoDeDatos, por ejemplo "Destacado", "Nuevo", etc.
        /// Se pueden asociar cero o más etiquetas a un elemento mediante la propiedad Etiquetas y el método GuardarEtiquetas().
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Etiqueta")]
        [Lbl.Atributos.Datos(TablaDatos = "sys_labels", CampoId = "id_label")]
        [Lbl.Atributos.Presentacion()]
        public class Etiqueta : ElementoDeDatos
        {
                private static ColeccionGenerica<Etiqueta> m_Todas;

                //Heredar constructor
		public Etiqueta(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public Etiqueta(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

                public Etiqueta(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                /// <summary>
                /// Obtiene o establece el nombre del elemento.
                /// </summary>
                public string Nombre
                {
                        get
                        {
                                return this.GetFieldValue<string>(CampoNombre);
                        }
                        set
                        {
                                this.Registro[CampoNombre] = value;
                        }
                }


                public static implicit operator Etiqueta(Lfx.Data.Row row)
                {
                        Etiqueta Res = new Etiqueta(((Lfx.Data.Table)(row.Table)).Connection);
                        Res.FromRow(row);
                        return Res;
                }

                public string TablaReferencia
                {
                        get
                        {
                                return this.GetFieldValue<string>("tablas");
                        }
                }

                public static ColeccionGenerica<Etiqueta> Todas
                {
                        get
                        {
                                if (m_Todas == null) {
                                        System.Data.DataTable EtiquetasElem = Lfx.Workspace.Master.MasterConnection.Select("SELECT id_label FROM sys_labels");
                                        m_Todas = new ColeccionGenerica<Etiqueta>(Lfx.Workspace.Master.MasterConnection, EtiquetasElem);
                                }

                                return m_Todas;
                        }
                }

                public static ColeccionGenerica<Etiqueta> ObtenerPorTabla(string tablaDeDatos)
                {
                        ColeccionGenerica<Etiqueta> Res = new ColeccionGenerica<Etiqueta>();
                        foreach (Etiqueta Et in Lbl.Etiqueta.Todas) {
                                if (Et.TablaDatos == tablaDeDatos)
                                        Res.Add(Et);
                        }
                        return Res;
                }
        }
}
