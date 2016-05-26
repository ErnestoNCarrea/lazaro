using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Sys.Configuracion
{
        public class Global : SeccionConfiguracion
        {
                public UsuarioConectado UsuarioConectado;
                public Impresion Impresion;
                public Comprobantes Comprobantes;

                public Global()
                {
                        this.Impresion = new Impresion();
                        this.UsuarioConectado = new UsuarioConectado(null);
                        this.Comprobantes = new Comprobantes();
                }
        }
}
