using System;
using System.Collections.Generic;

namespace Lcc.Edicion
{
        public class Campo
        {
                public Lui.Forms.EditableControl ControlEntrada { get; set; }
                public Lui.Forms.Label Etiqueta { get; set; }

                public Campo(Lui.Forms.EditableControl control, Lui.Forms.Label etiqueta)
                {
                        this.ControlEntrada = control;
                        this.Etiqueta = etiqueta;
                }
        }
}
