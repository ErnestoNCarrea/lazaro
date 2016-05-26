using System;
using System.Collections.Generic;

namespace Lfc.Personas.Usuarios
{
        public class Inicio : Lfc.Personas.Inicio
        {
                public Inicio()
                        : base()
                {
                        this.Definicion.ElementoTipo = typeof(Lbl.Personas.Usuario);
                        this.Tipo = 4;
                }

                public Inicio(string comand)
                        : base(comand)
                {
                        this.Definicion.ElementoTipo = typeof(Lbl.Personas.Usuario);
                        this.Tipo = 4;
                }


                public override Lbl.IElementoDeDatos Crear()
                {
                        Lbl.Personas.Persona Item = new Lbl.Personas.Persona(this.Connection);
                        Item.Crear();
                        Item.Tipo = 4;

                        return Item;
                }
        }
}
