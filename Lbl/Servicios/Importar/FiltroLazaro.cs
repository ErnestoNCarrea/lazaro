using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Servicios.Importar
{
        public class FiltroLazaro : Filtro
        {
                public FiltroLazaro(Lfx.Data.Connection dataBase, Opciones opciones)
                        : base(dataBase, opciones)
                {
                        this.Nombre = "Filtro de importación de Lázaro";
                }
        }
}
