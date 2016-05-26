namespace Lbl.Bancos.Claves
{
        /// <summary>
        /// International Bank Account Number (Europa, otros)
        /// http://en.wikipedia.org/wiki/International_Bank_Account_Number
        /// </summary>
        public class Iban : IdentificadorUnico
        {
                public override string Nombre
                {
                        get
                        {
                                return "IBAN";
                        }
                }
        }
}
