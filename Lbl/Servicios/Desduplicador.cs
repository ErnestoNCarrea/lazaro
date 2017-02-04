using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Lazaro.Orm.Data;

namespace Lbl.Servicios
{
        /// <summary>
        /// Fusiona dos elementos de datos, útil para eliminar duplicados. Cambia todas las referencias de claves foráneas al nuevo elemento.
        /// </summary>
        public class Desduplicador
        {
                public Lfx.Data.IConnection DataBase;
                public string TablaOriginal, CampoIdOriginal;
                public int IdOriginal, IdDuplicado;

                public Desduplicador(Lfx.Data.IConnection dataBase, string tablaOriginal, string campoIdOriginal, int idOriginal, int idDuplicado)
                {
                        this.DataBase = dataBase;
                        this.TablaOriginal = tablaOriginal;
                        this.CampoIdOriginal = campoIdOriginal;
                        this.IdOriginal = idOriginal;
                        this.IdDuplicado = idDuplicado;
                }

                public void Desduplicar()
                {
                        IDbTransaction Trans = null;

                        if(this.DataBase.InTransaction == false)
                                Trans = this.DataBase.BeginTransaction(IsolationLevel.Serializable);

                        // Le doy tratamiento especial a algunas situaciones
                        switch (TablaOriginal) {
                                case "personas":
                                        // Quito la imagen del elemento duplicado... para que no choque con la original
                                        qGen.Delete QuitarImagen = new qGen.Delete("personas_imagenes");
                                        QuitarImagen.WhereClause = new qGen.Where("id_persona", this.IdDuplicado);
                                        this.DataBase.Execute(QuitarImagen);
                                        break;
                        }

                        // Busco una lista de relaciones entre tablas
                        var Rels = this.ListaRelaciones();
                        foreach (Lazaro.Orm.Data.Relation Rel in Rels) {
                                // Cambio todas las referencias que apuntan al registro duplicado hacia el registro original
                                qGen.Update Upd = new qGen.Update(Rel.ReferenceTable);
                                Upd.Fields.AddWithValue(Rel.ReferenceColumn, IdOriginal);
                                Upd.WhereClause = new qGen.Where(Rel.ReferenceColumn, IdDuplicado);
                                this.DataBase.Execute(Upd);
                        }

                        // Ahora que no queda nada apuntando al registro duplicado, lo elimino
                        qGen.Delete Del = new qGen.Delete(this.TablaOriginal);
                        Del.WhereClause = new qGen.Where(this.CampoIdOriginal, this.IdDuplicado);
                        this.DataBase.Execute(Del);

                        // Le doy tratamiento especial a algunas situaciones
                        switch (TablaOriginal) {
                                case "personas":
                                        // En personas, recalculo la cuenta corriente, ya que la nueva cuenta corriente es la fusión de las dos anteriores
                                        Lbl.Personas.Persona PersonaOriginal = new Lbl.Personas.Persona(this.DataBase, IdOriginal);
                                        PersonaOriginal.CuentaCorriente.Recalcular();
                                        PersonaOriginal.AgregarComentario("Desduplicador: Se fusionaron los datos del elemento " + IdDuplicado);
                                        break;
                                        // En artículos, debería recalcular el historial de movimientos y el stock actual, pedidos, etc.
                        }

                        if (Trans != null)
                                Trans.Commit();
                }

                public IList<Relation> ListaRelaciones()
                {
                        var Res = new List<Relation>();
                        foreach (Lfx.Data.ConstraintDefinition Cons in Lfx.Workspace.Master.Structure.Constraints.Values) {
                                if (Cons.ReferenceTable == TablaOriginal && Cons.ReferenceColumn == CampoIdOriginal) {
                                        var Rel = new Relation(CampoIdOriginal, Cons.TableName, Cons.Column, null);
                                        Res.Add(Rel);
                                }
                        }

                        foreach (Lfx.Data.TableStructure Tab in Lfx.Workspace.Master.Structure.Tables.Values) {
                                if (Tab.Name != TablaOriginal) {
                                        foreach (Lfx.Data.ColumnDefinition Col in Tab.Columns.Values) {
                                                if (Col.Name == CampoIdOriginal) {
                                                        bool Found = false;
                                                        foreach (Lazaro.Orm.Data.Relation Rel in Res) {
                                                                if (Rel.ReferenceTable == Tab.Name && Rel.ReferenceColumn == Col.Name) {
                                                                        Found = true;
                                                                        break;
                                                                }
                                                        }
                                                        if (Found == false)
                                                                System.Console.WriteLine("El cammpo " + Tab.Name + "." + Col.Name + " puede ser una referencia no declarada como clave foránea.");
                                                }
                                        }
                                }
                        }

                        return Res;
                }
        }
}
