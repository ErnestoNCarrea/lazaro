using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl
{
        /// <summary>
        /// Una colección Generica para ElementosDeDatos.
        /// </summary>
        public class ColeccionGenerica<T> : List<T>, IEnumerable<T> where T : ElementoDeDatos
        {
                public bool HayAgregados = false, HayQuitados = false;

                public Lfx.Data.IConnection DataBase;
                // public List<T> List = new List<T>();

                public ColeccionGenerica()
                {
                }

                public ColeccionGenerica(Lfx.Data.IConnection dataBase)
                        : this()
                {
                        this.DataBase = dataBase;
                }

                public ColeccionGenerica(Lfx.Data.IConnection dataBase, System.Data.DataTable tabla)
                        : this(dataBase)
                {
                        this.Clear();
                        this.AddRange(tabla);
                }


                public ColeccionGenerica(Lfx.Data.IConnection dataBase, Lfx.Data.Table tabla)
                        : this(dataBase)
                {
                        this.Clear();
                        this.AddRange(tabla);
                }


                public void AddRange(System.Data.DataTable tabla)
                {
                        if (tabla != null) {
                                foreach (System.Data.DataRow Rw in tabla.Rows) {
                                        Lfx.Data.Row Lrw = (Lfx.Data.Row)Rw;
                                        this.AddFromRow(Lrw);
                                }
                        }
                        this.HayCambios = false;
                }


                public void AddRange(Lfx.Data.Table tabla)
                {
                        if (tabla != null) {
                                tabla.PreLoad();
                                foreach (Lfx.Data.Row Rw in tabla.FastRows.Values) {
                                        Lfx.Data.Row Lrw = Rw;
                                        this.AddFromRow(Lrw);
                                }
                        }
                        this.HayCambios = false;
                }

                new public void AddRange(IEnumerable<T> collection)
                {
                        foreach (T elem in collection) {
                                elem.Connection = this.DataBase;
                        }
                        base.AddRange(collection);
                        this.HayAgregados = true;
                }

                public void DesdeTable(Lfx.Data.Table tabla)
                {
                        this.Clear();
                        tabla.FastRows.LoadAll();
                        foreach (Lfx.Data.Row Lrw in tabla.FastRows.Values) {
                                this.AddFromRow(Lrw);
                        }
                        this.HayCambios = false;
                }

                public ColeccionGenerica(Lfx.Data.Table tabla)
                        : this(tabla.Connection)
                {
                        this.DesdeTable(tabla);
                }

                private void AddFromRow(Lfx.Data.Row row)
                {
                        T Elem = Instanciador.Instanciar<T>(this.DataBase, row);
                        this.Add(Elem);
                        this.HayAgregados = true;
                }

                /// <summary>
                /// Busca un elemento por su Id.
                /// </summary>
                public bool Contains(int id)
                {
                        foreach (T El in this) {
                                if (El != null && El.Id == id)
                                        return true;
                        }
                        return false;
                }

                /// <summary>
                /// Obtiene un Elemento por su Id.
                /// </summary>
                public T GetById(int id)
                {
                        foreach (T El in this) {
                                if (El != null && El.Id == id)
                                        return El;
                        }
                        return null;
                }

                public int[] GetAllIds()
                {
                        int[] Res = new int[this.Count];
                        int i = 0;
                        foreach (T El in this) {
                                Lbl.IElementoDeDatos El2 = El as Lbl.IElementoDeDatos;
                                if (El2 != null)
                                        Res[i++] = El2.Id;
                        }
                        return Res;
                }

                /// <summary>
                /// Agrega un elemento a la colección.
                /// </summary>
                new public void Add(T elemento)
                {
                        elemento.Connection = this.DataBase;
                        base.Add(elemento);
                        this.HayAgregados = true;
                }

                /// <summary>
                /// Elimina un elemento por su Id.
                /// </summary>
                public void RemoveById(int id)
                {
                        for (int i = 0; i < this.Count; i++) {
                                Lbl.IElementoDeDatos El2 = this[i] as Lbl.IElementoDeDatos;
                                if (El2 != null && El2.Id == id) {
                                        base.RemoveAt(i);
                                        this.HayQuitados = true;
                                        break;
                                }
                        }
                }

                public bool HayCambios
                {
                        get
                        {
                                return this.HayAgregados || this.HayQuitados;
                        }
                        set
                        {
                                this.HayQuitados = value;
                                this.HayAgregados = value;
                        }
                }

                /// <summary>
                /// Elimina un elemento de la lista.
                /// </summary>
                /// <param name="elemento">El elemento a eliminar.</param>
                new public void Remove(T elemento)
                {
                        base.Remove(elemento);
                        this.HayQuitados = true;
                }

                /// <summary>
                /// Devuelve una nueva colección, conteniendo los mismos elementos.
                /// </summary>
                public ColeccionGenerica<T> Clone()
                {
                        ColeccionGenerica<T> Res = new ColeccionGenerica<T>(this.DataBase);
                        foreach (T El in this) {
                                Res.Add(El);
                        }
                        return Res;
                }

                /// <summary>
                /// Devuelve una colección de elementos nuevos, en comparación con una colección original.
                /// </summary>
                /// <param name="original">La colección original.</param>
                /// <returns>La colección de los elementos presentes en esta colección, pero no en la original.</returns>
                public ColeccionGenerica<T> Agregados(ColeccionGenerica<T> original)
                {
                        var Res = new ColeccionGenerica<T>();
                        foreach (T El in this) {
                                var El2 = El as Lbl.IElementoDeDatos;
                                if(original == null || original.Contains(El2.Id) == false)
                                        Res.Add(El);
                        }
                        return Res;
                }

                /// <summary>
                /// Devuelve una colección de elementos faltantes, en comparación con una colección original.
                /// </summary>
                /// <param name="original">La colección original.</param>
                /// <returns>La colección de los elementos no presentes en esta colección, pero si en la original.</returns>
                public ColeccionGenerica<T> Quitados(ColeccionGenerica<T> original)
                {
                        var Res = new ColeccionGenerica<T>();
                        if (original != null) {
                                foreach (T Elem in original) {
                                        var El2 = Elem as Lbl.IElementoDeDatos;
                                        if (this.Contains(El2.Id) == false)
                                                Res.Add(Elem);
                                }
                        }
                        return Res;
                }

                public override string ToString()
                {
                        return this.ToString(", ");
                }

                public string ToString(string separator)
                {
                        System.Text.StringBuilder Res = new StringBuilder();

                        foreach (ElementoDeDatos Elem in this) {
                                if (Res.Length == 0)
                                        Res.Append(Elem.ToString());
                                else
                                        Res.Append(separator + Elem.ToString());
                        }

                        return Res.ToString();
                }
        }
}
