namespace Lfc.Comprobantes.Recibos
{
        public partial class InicioPago : Inicio
        {
                public InicioPago()
                        : base()
                {
                        this.Definicion.ElementoTipo = typeof(Lbl.Comprobantes.ReciboDePago);
                }
        }
}
