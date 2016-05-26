using System;
using System.Collections.Generic;

namespace Lbl.Atributos
{
        [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
        public class Datos : System.Attribute
        {
                public string TablaDatos { get; set; }
                public string CampoId { get; set; }
                public string CampoNombre { get; set; }
                public string CampoImagen { get; set; }
                public string TablaImagenes { get; set; }
                public bool EstadosEstandar { get; set; }

                public Datos()
                {
                        this.CampoNombre = "nombre";
                        this.CampoImagen = "imagen";
                }

                public Datos(string nombreSingular, string tablaDatos, string campoId, string campoNombre, string campoImagen, string tablaImagenes, bool estadosEstandar)
                {
                        this.TablaDatos = tablaDatos;
                        this.CampoId = campoId;
                        this.CampoNombre = campoNombre;
                        this.CampoImagen = CampoImagen;
                        this.TablaImagenes = tablaImagenes;
                        this.EstadosEstandar = estadosEstandar;
                }
        }
}
