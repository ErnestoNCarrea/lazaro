namespace Lbl.Bancos.Claves
{
        /// <summary>
        /// Código Cuenta Cliente (España)
        /// Está siendo sustituído por el IBAN.
        /// http://es.wikipedia.org/wiki/C%C3%B3digo_cuenta_cliente
        /// </summary>
        public class Ccc : IdentificadorUnico
        {
                public override string Nombre
                {
                        get
                        {
                                return "CCC";
                        }
                }
        }
}
