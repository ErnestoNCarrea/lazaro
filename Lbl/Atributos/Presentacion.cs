using System;
using System.Collections.Generic;

namespace Lbl.Atributos
{
        public enum PanelExtendido
        {
                Nunca,
                Automatico,
                Siempre
        }

        [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
        public class Presentacion : System.Attribute
        {
                public bool MensajeAlCrear { get; set; }
                public PanelExtendido PanelExtendido { get; set; }

                public Presentacion()
                {
                        this.PanelExtendido = Atributos.PanelExtendido.Automatico;
                }

                public Presentacion(bool mensajeAlCrear, PanelExtendido panelExtendido)
                {
                        this.MensajeAlCrear = mensajeAlCrear;
                        this.PanelExtendido = panelExtendido;
                }
        }
}
