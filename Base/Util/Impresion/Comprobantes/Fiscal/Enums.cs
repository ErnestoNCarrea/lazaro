using System;

namespace Lazaro.Base.Util.Impresion.Comprobantes.Fiscal
{
	/// <summary>
	/// Impresión mediante controlador fiscal.
	/// </summary>
	/// 	

	static class CaracteresDeControl
	{
		public const char PROTO_STX = (char)0x02;
                public const char PROTO_FS = (char)0x1C;
                public const char PROTO_ETX = (char)0x03;
                public const char PROTO_DC2 = (char)0x12;
                public const char PROTO_DC4 = (char)0x14;
                public const char PROTO_ACK = (char)0x06;
                public const char PROTO_NAK = (char)0x15;
	}

	public enum EstadoServidorFiscal
	{
		Esperando = 0,
		Imprimiendo = 1,
		Apagando = 3,
		Reiniciando = 4,
		Error = 5
	}

	public enum ErroresFiscales
	{
		Ok = 0,
		Error = 1,
		ErrorImpresora = 2,
		ErrorFiscal = 3,
		TimeOut = 10,
		NAK = 11,
		ErrorBCC = 12,
		ErrorComunicacion,
	}

	public enum CodigosComandosFiscales
	{
		Ninguno = 0,
		Escape = 0X1B,

		/* Comandos EPSON */
		EpsonNada = 0,
		EpsonSolicitudEstado = 0X2A,
		EpsonCierreJornada = 0X39,

		EpsonReporteMemoriaPorFecha = 0X3A,
		EpsonReporteMemoriaPorCierre = 0X3B,
		EpsonReporteTransporte = 0X5C,

		EpsonDocumentoNoFiscalPonerPreferencias = 0X5A,
		EpsonDocumentoNoFiscalLeerPreferencias = 0X5B,
		EpsonDocumentoNoFiscalAbrir = 0X48,
		EpsonDocumentoNoFiscalImprimir = 0X49,
		EpsonDocumentoNoFiscalCerrar = 0X4A,
		EpsonAvanzarHoja = 0X53,
		EpsonExpulsarHoja = 0X4B,

		EpsonPonerFechaYHora = 0X58,
		EpsonLeerFechaYHora = 0X59,

		EpsonPonerDatosFijos = 0X5D,
		EpsonLeerDatosFijos = 0X5E,
		EpsonPonerZonasDeImpresion = 0X5A,
		EpsonPonerZonasDeImpresionOffset = 0X5C,
		EpsonLeerZonasDeImpresion = 0X5B,

		EpsonBorrarZonasDeImpresion = 0X5C,
		EpsonBorrarPreferencias = 0X5C,

                EpsonTiqueDocumentoFiscalAbrir = 0X40,
                EpsonTiqueDocumentoFiscalTexto = 0X41,
                EpsonTiqueDocumentoFiscalItem = 0X42,
                EpsonTiqueDocumentoFiscalSubTotal = 0X43,
                EpsonTiqueDocumentoFiscalPagoDescuentoRecargo = 0X44,
                EpsonTiqueFiscalCerrar = 0X45,

                EpsonDocumentoFiscalAbrir = 0X60,
		EpsonDocumentoFiscalItem = 0X62,
		EpsonDocumentoFiscalSubtotal = 0X63,
		EpsonDocumentoFiscalPagosYDescuentos = 0X64,
		EpsonDocumentoFiscalCerrar = 0X65,

		/* Comandos HASAR */
		HasarSolicitudEstado = 0X2A,
		HasarCierreJornada = 0X39,

		HasarDocumentoFiscalAbrir = 0X40,
                HasarDocumentoNoFiscalAbrir = 0X48,
                HasarDocumentoNoFiscalHomologadoAbrir = 0X80,
                HasarDocumentoNoFiscalHomologadoCerrar = 0X81,
		HasarDocumentoSetDatosCliente = 0X62,
                HasarDocumentoFiscalTexto = 0X41,
                HasarDocumentoFiscalItem = 0X42,
                HasarDocumentoEstablecerEncabezadoCola = 0X5D,
		HasarDocumentoFiscalDescuentoGeneral = 0X54,
		HasarDocumentoFiscalDevolucionesYRecargos = 0X6D,
		HasarDocumentoFiscalPago = 0X44,
		HasarDocumentoFiscalCerrar = 0X45,
                HasarDocumentoNoFiscalCerrar = 0X4D,
		HasarDocumentoFiscalCancelar = 0X98,
                HasarDocumentoFiscalCargarComprobanteOriginal = 0X93,
                HasarDocumentoFiscalNombreFantasia = 0X5F,
                HasarDocumentoImprimirTextoDobleAncho = 0XF4,

	}
}
