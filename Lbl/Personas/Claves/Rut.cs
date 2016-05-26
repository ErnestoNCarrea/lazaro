
namespace Lbl.Personas.Claves
{
        /// <summary>
        /// Rol Único Tributario (Chile)
        /// </summary>
        public class Rut : IdentificadorUnico
        {
                public Rut(string valor)
                        : base(valor) { }

                public override string Nombre
                {
                        get
                        {
                                return "RUT";
                        }
                }

        }
}
