using System;
using System.Collections.Generic;

namespace Lfc.Comprobantes.Remitos
{
        public class Inicio : Lfc.Comprobantes.Inicio
        {
                public Inicio()
                        : base()
                {
                        this.Definicion.ElementoTipo = typeof(Lbl.Comprobantes.Remito);
                }

                public Inicio(string comand)
                        : base(comand)
                {
                        this.Definicion.ElementoTipo = typeof(Lbl.Comprobantes.Remito);
                }
        }
}
