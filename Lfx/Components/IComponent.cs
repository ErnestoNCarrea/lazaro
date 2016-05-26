using System;
using System.Collections.Generic;

namespace Lfx.Components
{
        public interface IComponent
        {
                string Nombre { get; set; }
                string EspacioNombres { get; set; }
                string CifFileName { get; set; }
                bool Disabled { get; set; }
                string UrlActualizaciones { get; set; }

                string Estructura { get; set; }
                string Cif { get; set; }
                FunctionInfoCollection Funciones { get; set; }
                RegisteredTypeCollection TiposRegistrados { get; set; }
                IList<MenuEntry> MenuEntries { get; set; }
                System.Reflection.Assembly Assembly { get; set; }

                Lfx.Types.OperationResult Load();
        }
}
