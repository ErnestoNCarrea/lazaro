using System;
using System.Collections.Generic;

namespace Lfc.Comprobantes.Facturas
{
        public class Inicio : Lfc.Comprobantes.Inicio
        {
                public Inicio()
                        : base()
                {
                        this.Definicion.ElementoTipo = typeof(Lbl.Comprobantes.Factura);
                        this.HabilitarBorrar = true;
                }

                public Inicio(string comando)
                        : this()
                {
                        try {
                                this.Definicion.ElementoTipo = Lbl.Instanciador.InferirTipo(comando);
                        } catch {
                                this.Definicion.ElementoTipo = typeof(Lbl.Comprobantes.Factura);
                        }
                        
                        this.HabilitarBorrar = true;
                }


                public override Lfx.Types.OperationResult SolicitudEliminacion(Lbl.ListaIds codigos)
                {
                        Lfx.Workspace.Master.RunTime.Execute("INSTANCIAR Lfc.Comprobantes.Facturas.Anular " + codigos[0].ToString());
                        return new Lfx.Types.SuccessOperationResult();
                }
        }
}
