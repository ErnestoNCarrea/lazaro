using System;
using System.Collections.Generic;

namespace Lfc.Personas.Proveedores
{
        public class Inicio : Lfc.Personas.Inicio
        {
                public Inicio()
                        : base()
                {
                        this.Definicion.ElementoTipo = typeof(Lbl.Personas.Proveedor);
                        this.Tipo = 2;
                }

                public Inicio(string comand)
                        : base(comand)
                {
                        this.Definicion.ElementoTipo = typeof(Lbl.Personas.Proveedor);
                        this.Tipo = 2;
                }
        }
}
