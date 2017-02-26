using System;
using System.Collections.Generic;

namespace Lfx.Components
{
        /// <summary>
        /// Contiene la información de un componente que puede cargarse en memoria.
        /// </summary>
        public interface IComponentInfo
        {
                string Nombre { get; set; }
                string EspacioNombres { get; set; }
                string CifFileName { get; set; }
                bool Disabled { get; set; }
                string UrlActualizaciones { get; set; }

                string Estructura { get; set; }
                string Cif { get; set; }
                IComponent ComponentInstance { get; set; }

                //FunctionInfoCollection Funciones { get; set; }
                //RegisteredTypeCollection TiposRegistrados { get; set; }
                IList<MenuEntry> MenuEntries { get; set; }
                System.Reflection.Assembly Assembly { get; set; }

                Lfx.Types.OperationResult Load();
        }
}
