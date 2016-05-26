namespace Lbl
{
        public class IdentificadorUnico : IIdentificadorUnico
        {
                public string Valor { get; set; }

                public IdentificadorUnico()
                {
                }

                public IdentificadorUnico(string valor)
                {
                        this.Valor = valor;
                }

                public virtual string Nombre
                {
                        get
                        {
                                return "Identificador Único de Personas";
                        }
                }


                public override string ToString()
                {
                        return this.Valor;
                }


                public virtual bool EsValido()
                {
                        // Overridear en las clases derivadas
                        return true;
                }
        }
}
