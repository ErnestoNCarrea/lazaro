using System;

namespace Afip.ControladorFiscal
{
        /// <summary>
        /// Los códigos de estado de la aplicación de servidor fiscal (Lázaro gestión).
        /// </summary>
	public enum EstadoServidorFiscal
	{
		Esperando = 0,
		Imprimiendo = 1,
		Apagando = 3,
		Reiniciando = 4,
		Error = 5
	}
        
}
