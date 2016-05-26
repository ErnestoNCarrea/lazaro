using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Sys.Permisos
{
        [Flags]
        public enum Operaciones
        {
                // Operaciones donde no se cambian los datos
                Ninguno = 0,
                Listar = 1,
                Ver = 2,
                Imprimir = 4,

                // Operaciones donde se cambian los datos en situaciones más bien cotidianas
                Crear = 8,
                Editar = 16,
                EditarAvanzado = 32,
                Mover = 64,

                // Operaciones donde se hacen cambios más importantes
                Eliminar = 128,
                Administrar = 256,
                Extra0 = 512,

                // Campos extra para uso de las implementaciones
                Extra1 = 1024,
                Extra2 = 2048,
                Extra3 = 4096,

                // Campos extra para uso de las implementaciones
                ExtraA = 8192,
                ExtraB = 16384,
                ExtraC = 32768,

                // Acceso total (incluye todas las anteriores)
                Total = 65536
        }
}
