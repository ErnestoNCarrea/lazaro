using System;
using System.Collections.Generic;

namespace Lazaro.Base.Util.Impresion.Comprobantes.Fiscal
{
        public class Respuesta
        {
                public Lbl.Impresion.ModelosFiscales ModeloImpresora;
                public ErroresFiscales Error;
                public string Lugar;
                public bool HacerCierreZ;
                public string Mensaje;
                public CodigosComandosFiscales CodigoComando;
                public int Secuencia;
                public string ProtocoloBinario;

                public EstadoImpresora EstadoImpresora = new EstadoImpresora();

                public class EstadosFiscales
                {
                        public long CodigoEstado;

                        public bool Bit(int bitNumber)
                        {
                                return (CodigoEstado & (long)Math.Pow(2, bitNumber)) != 0;
                        }
                        public bool DocumentoFiscalAbierto
                        {
                                get
                                {
                                        return this.Bit(12);
                                }
                        }
                        //Este bit se encuentra en 1 siempre que un documento (fiscal, no fiscal o no fiscal homologado) se encuentra abierto.(Hasar)
                        public bool DocumentoAbierto 
                        {
                                get
                                {
                                        return this.Bit(13);
                                }
                        }
                        public bool HacerCierreZ
                        {
                                get
                                {
                                        return this.Bit(15);
                                }
                        }
                }
                public EstadosFiscales EstadoFiscal = new EstadosFiscales();

                public List<string> Campos;

                public Respuesta()
                        : this(ErroresFiscales.Ok)
                {
                }

                public Respuesta(ErroresFiscales codigoError)
                {
                        this.Error = codigoError;
                        this.Campos = null;
                        this.CodigoComando = CodigosComandosFiscales.Ninguno;
                        this.EstadoFiscal.CodigoEstado = 0;
                        this.EstadoImpresora.CodigoEstado = 0;
                        this.HacerCierreZ = false;
                        this.Lugar = "";
                        this.Mensaje = "";
                        this.Secuencia = 0;
                }

                public int NumeroComprobante
                {
                        get
                        {
                                if (Campos.Count >= 3)
                                        return System.Convert.ToInt32(Campos[2]);
                                else
                                        return 0;
                        }
                }

                public override string ToString()
                {
                        string Res = "<Respuesta" + System.Environment.NewLine;
                        Res += "  comando=" + this.CodigoComando.ToString() + System.Environment.NewLine;
                        Res += "  secuencia=" + this.Secuencia.ToString() + System.Environment.NewLine;
                        for (int i = 0; i < Campos.Count; i++) {
                                Res += "  campo_" + i.ToString() + "=" + this.Campos[i].ToString() + System.Environment.NewLine;
                        }
                        Res += "  estado_fiscal=" + this.ExplicarEstadoFiscal() + System.Environment.NewLine;
                        Res += "  estado_impresora=" + this.ExplicarEstadoImpresora() + System.Environment.NewLine;
                        Res += "/>" + System.Environment.NewLine;
                        return Res;
                }

                public string ExplicarEstadoImpresora()
                {
                        string Estado = "0x" + System.Convert.ToString(EstadoImpresora.CodigoEstado, 16).PadLeft(4, '0') + ":";

                        if (Bit(EstadoImpresora.CodigoEstado, 0))
                                Estado += "Bit 0;";

                        if (Bit(EstadoImpresora.CodigoEstado, 1))
                                Estado += "Bit 1;";

                        if (Bit(EstadoImpresora.CodigoEstado, 2))
                                Estado += "Bit 2: Falla en la impresora;";

                        if (Bit(EstadoImpresora.CodigoEstado, 3))
                                Estado += "Bit 3: Fuera de línea;";

                        if (Bit(EstadoImpresora.CodigoEstado, 4))
                                Estado += "Bit 4;";

                        if (Bit(EstadoImpresora.CodigoEstado, 5))
                                Estado += "Bit 5;";

                        if (Bit(EstadoImpresora.CodigoEstado, 6))
                                Estado += "Bit 6: Búfer lleno;";

                        if (Bit(EstadoImpresora.CodigoEstado, 7))
                                Estado += "Bit 7: Búfer vacío;";

                        if (Bit(EstadoImpresora.CodigoEstado, 8))
                                Estado += "Bit 8: Entrada frontal de papel preparada;";

                        if (Bit(EstadoImpresora.CodigoEstado, 9))
                                Estado += "Bit 9: Hoja suelta frontal separada;";

                        if (Bit(EstadoImpresora.CodigoEstado, 10))
                                Estado += "Bit 10;";

                        if (Bit(EstadoImpresora.CodigoEstado, 11))
                                Estado += "Bit 11;";

                        if (Bit(EstadoImpresora.CodigoEstado, 12))
                                Estado += "Bit 12;";

                        if (Bit(EstadoImpresora.CodigoEstado, 13))
                                Estado += "Bit 13;";

                        switch (ModeloImpresora) {
                                case Lbl.Impresion.ModelosFiscales.EpsonTiquedora:
                                case Lbl.Impresion.ModelosFiscales.EpsonGenerico:
                                case Lbl.Impresion.ModelosFiscales.Emulacion:
                                        if (Bit(EstadoImpresora.CodigoEstado, 14))
                                                Estado += "Bit 14: Sin papel;";
                                        break;
                                case Lbl.Impresion.ModelosFiscales.HasarTiquedora:
                                case Lbl.Impresion.ModelosFiscales.HasarGenerico:
                                        if (Bit(EstadoImpresora.CodigoEstado, 14))
                                                Estado += "Bit 14: Cajón de dinero cerrado o ausente;";
                                        break;
                        }

                        if (Bit(EstadoImpresora.CodigoEstado, 15))
                                Estado += "Bit 15: Bandera de error;";

                        return Estado;
                }

                public string ExplicarEstadoFiscal()
                {
                        string Estado = "0x" + System.Convert.ToString(EstadoFiscal.CodigoEstado, 16).PadLeft(4, '0') + ":";
                        if (Bit(EstadoFiscal.CodigoEstado, 0))
                                Estado += "Bit 0: Error de memoria fiscal;";

                        if (Bit(EstadoFiscal.CodigoEstado, 1))
                                Estado += "Bit 1: Error de memoria de trabajo;";

                        if (Bit(EstadoFiscal.CodigoEstado, 2))
                                Estado += "Bit 2: Batería baja;";

                        if (Bit(EstadoFiscal.CodigoEstado, 3))
                                Estado += "Bit 3: Comando no reconocido;";

                        if (Bit(EstadoFiscal.CodigoEstado, 4))
                                Estado += "Bit 4: Campo de datos no válido;";

                        if (Bit(EstadoFiscal.CodigoEstado, 5))
                                Estado += "Bit 5: Comando no válido en este estado;";

                        if (Bit(EstadoFiscal.CodigoEstado, 6) & Bit(EstadoFiscal.CodigoEstado, 11))
                                Estado += "Bits 6 y 11: Es necesario hacer un transporte de hoja;";
                        else if (Bit(EstadoFiscal.CodigoEstado, 6))
                                Estado += "Bit 6: Desbordamiento;";

                        if (Bit(EstadoFiscal.CodigoEstado, 7))
                                Estado += "Bit 7: Memoria fiscal llena;";

                        if (Bit(EstadoFiscal.CodigoEstado, 8))
                                Estado += "Bit 8: Memoria fiscal casi llena;";

                        if (Bit(EstadoFiscal.CodigoEstado, 9) & Bit(EstadoFiscal.CodigoEstado, 10))
                                Estado += "Bits 9 y 10: Controlador fiscalizado;";
                        else if (Bit(EstadoFiscal.CodigoEstado, 9) & Bit(EstadoFiscal.CodigoEstado, 10) == false)
                                Estado += "Bit 9: Impresor fiscal certificado;";
                        else if (Bit(EstadoFiscal.CodigoEstado, 9) == false & Bit(EstadoFiscal.CodigoEstado, 10))
                                Estado += "Bit 10: Impresora desfiscalizada por software;";

                        if (Bit(EstadoFiscal.CodigoEstado, 11))
                                Estado += "Bit 11: Es necesario un cierre de jornada;";

                        if (Bit(EstadoFiscal.CodigoEstado, 12))
                                Estado += "Bit 12: Documento fiscal abierto;";

                        if (Bit(EstadoFiscal.CodigoEstado, 13))
                                Estado += "Bit 13: Documento fiscal abierto por rollo de papel;";

                        if (Bit(EstadoFiscal.CodigoEstado, 14))
                                Estado += "Bit 14: Factura o impresión en hoja suelta inicializada;";

                        if (Bit(EstadoFiscal.CodigoEstado, 15))
                                Estado += "Bit 15;";

                        return Estado;
                }

                private static bool Bit(long numero, int fiscalBit)
                {
                        long ValorBit = System.Convert.ToInt64(Math.Pow(2, fiscalBit));
                        return (numero & ValorBit) == ValorBit;
                }

        }
}
