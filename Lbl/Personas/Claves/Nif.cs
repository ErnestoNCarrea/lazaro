namespace Lbl.Personas.Claves
{
        /// <summary>
        /// Número de Identificación Fiscal (España)
        /// </summary>
        public class Nif : IdentificadorUnico
        {
                public Nif(string valor)
                        : base(valor) { }

                public override string Nombre
                {
                        get
                        {
                                return "NIF";
                        }
                }
        }
}
