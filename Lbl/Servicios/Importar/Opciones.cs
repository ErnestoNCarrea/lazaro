using System;
using System.Collections.Generic;

namespace Lbl.Servicios.Importar
{
        public class Opciones
        {
                public bool ImportarClientes { get; set; }
                public bool ImportarArticulos { get; set; }
                public bool ImportarStock { get; set; }
                public bool ImportarFacturas { get; set; }
                public bool ImportarCtasCtes { get; set; }
                public bool ActualizarRegistros { get; set; }

                public Opciones()
                {
                        this.ImportarClientes = true;
                        this.ImportarArticulos = true;
                        this.ImportarStock = true;
                        this.ImportarFacturas = true;
                        this.ImportarCtasCtes = true;
                }
        }
}
