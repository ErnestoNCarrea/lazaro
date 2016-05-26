namespace Lfc.Comprobantes.Recibos
{
        public partial class InicioCobro : Inicio
        {
                public InicioCobro()
                        : base()
                {
                        this.Definicion.ElementoTipo = typeof(Lbl.Comprobantes.ReciboDeCobro);
                }
        }
}