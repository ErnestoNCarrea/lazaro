using System;
using System.Collections.Generic;

namespace Lbl.Servicios.Importar
{
        /// <summary>
        /// Contiene una lista de tablas a mapear al importar.
        /// </summary>
        public class ColeccionMapaDeTablas : List<MapaDeTabla>
        {
                public void AddWithValue(string nombre, string tablaExterna, string tablaLazaro)
                {
                        this.Add(new MapaDeTabla(nombre, tablaExterna, tablaLazaro));
                }

                public void AddWithValue(string nombre, string tablaExterna, string tablaLazaro, string columnaId)
                {
                        this.Add(new MapaDeTabla(nombre, tablaExterna, tablaLazaro, columnaId));
                }

                public MapaDeTabla this[string tablaExterna]
                {
                        get
                        {
                                foreach (MapaDeTabla Map in this) {
                                        if (Map.TablaExterna == tablaExterna)
                                                return Map;
                                }
                                return null;
                        }
                }
        }
}
