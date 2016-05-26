using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Lbl.Atributos
{
        [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
        public class Nomenclatura : System.Attribute
        {
                public string NombreSingular { get; set; }
                public string Grupo { get; set; }

                /// <summary>
                /// Obtiene o establece un valor que indica si al mostrar el nombre del elemento debe prefijarse con el tipo.
                /// Por ejemplo "Artículo Manzana" (prefijado) vs. "Manzana" (no prefijado), o "Proveedor Juan Perez" vs. "Juan Perez".
                /// </summary>
                public bool PrefijarNombreConTipo { get; set; }

                public Nomenclatura()
                {
                }

                public Nomenclatura(string nombreSingular, string grupo)
                        : this(nombreSingular, grupo, false)
                {
                }

                public Nomenclatura(string nombreSingular, string grupo, bool prefijarNombreConTipo)
                {
                        this.NombreSingular = nombreSingular;
                        this.Grupo = Grupo;
                        this.PrefijarNombreConTipo = prefijarNombreConTipo;
                }

                public string NombrePlural
                {
                        get
                        {
                                string Res = "";
                                string[] Palabras = this.NombreSingular.Split(new char[] { ' ', '-' });
                                foreach (string Palabra in Palabras) {
                                        if (Palabra == "de" || Palabra == "con" || Palabra == "y" || Palabra == "o")
                                                Res += Palabra + " ";
                                        else if (Palabra == "del")
                                                Res += "de los ";
                                        else if (Palabra.EndsWith("s"))
                                                Res += Palabra + " ";
                                        else if ("aeiouáéíóúü".IndexOf(Palabra.Substring(Palabra.Length - 1, 1).ToLowerInvariant()) >= 0)
                                                Res += Palabra + "s ";
                                        else
                                                Res += Palabra + "es ";
                                }
                                return Res.Trim();
                        }
                }
        }
}
