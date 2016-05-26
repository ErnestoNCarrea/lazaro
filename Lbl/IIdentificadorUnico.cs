namespace Lbl
{
        public interface IIdentificadorUnico
        {
                string Valor { get; set; }
                string Nombre { get; }

                bool EsValido();
        }
}
