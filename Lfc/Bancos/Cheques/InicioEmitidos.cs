using System;
using System.Collections.Generic;

namespace Lfc.Bancos.Cheques
{
        public class InicioEmitidos : Inicio
        {
                public InicioEmitidos()
                        : base()
                {
                        this.Definicion.ElementoTipo = typeof(Lbl.Bancos.ChequeEmitido);
                        DepositarPagar.Text = "Pagar";
                        BotonCrear.Text = "Emitir";

                        Lbl.ColeccionCodigoDetalle NuevosEstados = new Lbl.ColeccionCodigoDetalle() { 
                                {0, "A Pagar"},
                                {5, "Depositado"},
                                {10, "Pagado"},
                                {11, "Entregado"},
                                {90, "Anulado"}
                        };
                        
                        this.EstadosCheques.AddRange(NuevosEstados);
                }
        }
}
