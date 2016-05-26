using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Articulos
{
        public enum Tipos
        {
                Regular = 0,
                Compuesto = 1
        }

        public enum Publicacion
        {
                Nunca = 0,
                Siempre = 1,
                SoloSiHayExistenciasOPedidos = 2
        }

        public enum Seguimientos
        {
                Predeterminado = 0,
                Ninguno = 1,
                NumerosDeSerie = 3,
                TallesYColores = 5
        }
}
