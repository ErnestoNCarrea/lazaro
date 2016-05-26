using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Servicios.Importar
{
        /// <summary>
        /// Especifica cómo se "mapea" una tabla externa a una tabla de Lázaro.
        /// </summary>
        public class MapaDeTabla
        {
                public string Nombre { get; set; }
                public string TablaExterna { get; set; }
                public string TablaLazaro { get; set; }
                public string ColumnaIdExterna { get; set; }
                public string ColumnaIdLazaro { get; set; }
                public MapaDeColumnas MapaDeColumnas { get; set; }
                public Type TipoElemento { get; set; }
                public string Where { get; set; }
                public bool ActualizaRegistros { get; set; }
                public int Limite { get; set; }
                public int Saltear { get; set; }
                public bool AutoSaltear { get; set; }

                public MapaDeTabla(string nombre, string tablaExterna, string tablaLazaro)
                {
                        this.MapaDeColumnas = new MapaDeColumnas();
                        this.ColumnaIdLazaro = "import_id";
                        this.Nombre = nombre;
                        this.ActualizaRegistros = true;
                        this.TablaExterna = tablaExterna;
                        this.TablaLazaro = tablaLazaro;
                        this.AutoSaltear = true;
                }

                public MapaDeTabla(string nombre, string tablaExterna, string tablaLazaro, string columnaIdExterna)
                        : this(nombre, tablaExterna, tablaLazaro)
                {
                        this.ColumnaIdExterna = columnaIdExterna;
                }

                public override string ToString()
                {
                        return this.Nombre;
                }
        }
}
