using System;
using System.Collections.Generic;

namespace Lfc.Bancos.Cheques
{
        public class InicioRecibidos : Inicio
        {
                public InicioRecibidos()
                        : base()
                {
                        this.Definicion.ElementoTipo = typeof(Lbl.Bancos.ChequeRecibido);
                        DepositarPagar.Text = "Depositar";
                        BotonCrear.Text = "Efectivizar";

                        Lbl.ColeccionCodigoDetalle NuevosEstados = new Lbl.ColeccionCodigoDetalle() { 
                                {0, "A Cobrar"},
                                {5, "Depositado"},
                                {10, "Cobrado"},
                                {11, "Entregado"},
                                {90, "Anulado"}
                        };

                        this.EstadosCheques.AddRange(NuevosEstados);
                }
        }
}
