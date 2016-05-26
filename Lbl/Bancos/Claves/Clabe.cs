namespace Lbl.Bancos.Claves
{
        /// <summary>
        /// Clave Bancaria Estandarizada (México)
        /// http://es.wikipedia.org/wiki/CLABE
        /// </summary>
        public class Clabe: IdentificadorUnico
        {
                public override string Nombre
                {
                        get
                        {
                                return "CLABE";
                        }
                }
        }
}
