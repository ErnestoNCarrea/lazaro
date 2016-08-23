using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afip.ControladorFiscal.Protocolo
{
        /// <summary>
        /// Los códigos de los comandos para el protocolo binario.
        /// </summary>
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
