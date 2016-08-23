using System;
using System.Collections.Generic;
using System.Text;

namespace Afip.ControladorFiscal
{
        public delegate void NotificacionEventHandler(object sender, ImpresoraEventArgs e);

        //Sistema de eventos
        public class ImpresoraEventArgs : System.EventArgs
        {
                public enum EventTypes
                {
                        Inicializada,
                        InicioImpresion,
                        FinImpresion,
                        Estado,
                        Error
                }

                public EventTypes EventType = EventTypes.Estado;
                public EstadoServidorFiscal Estado;
                public string MensajeEstado;
                public ErroresFiscales ErrorFiscal;

                public ImpresoraEventArgs() { }
                public ImpresoraEventArgs(EventTypes eventType)
                {
                        EventType = eventType;
                }
                public ImpresoraEventArgs(string mensajeEstado)
                {
                        this.EventType = EventTypes.Estado;
                        MensajeEstado = mensajeEstado;
                }
                public ImpresoraEventArgs(ErroresFiscales errorFiscal)
                {
                        this.EventType = EventTypes.Error;
                        ErrorFiscal = errorFiscal;
                }
        }
}
