
namespace Lbl.Personas.Claves
{
        /// <summary>
        /// Registro Único de Contribuyente (Uruguay)
        /// </summary>
        public class Ruc : IdentificadorUnico
        {
                public Ruc(string valor)
                        : base(valor) { }

                public override string Nombre
                {
                        get
                        {
                                return "RUC";
                        }
                }

        }
}
