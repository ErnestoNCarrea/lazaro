using System;
using System.Collections.Generic;
using System.Text;

namespace Lazaro.Impresion.Comprobantes.Fiscal
{
        public class Comando
        {
                public CodigosComandosFiscales CodigoComando;
                public int Secuencia;
                public string[] Campos;
                private System.Text.Encoding DefaultEncoding = System.Text.Encoding.GetEncoding(1252);

                public Comando(CodigosComandosFiscales codigoComando, params string[] campos)
                {
                        CodigoComando = codigoComando;
                        Campos = campos;
                }

                public string ProtocoloBinario()
                {
                        System.Text.StringBuilder Comando = new System.Text.StringBuilder();
                        Comando.Append(CaracteresDeControl.PROTO_STX);      // STX Start of Frame

                        Comando.Append((char)Secuencia); // SN Sequence Number


                        byte[] Cmd = new byte[1] { (byte)CodigoComando };
                        Comando.Append(DefaultEncoding.GetChars(Cmd)); // Comando

                        if (Campos != null && Campos.Length > 0) {
                                // Params
                                foreach (string Param in Campos) {
                                        Comando.Append(CaracteresDeControl.PROTO_FS); // FS Field Separator
                                        Comando.Append(Param);
                                }
                        }

                        Comando.Append(CaracteresDeControl.PROTO_ETX);	// ETX End of Frame

                        //Calculo el BCC
                        long BCC = 0;
                        byte[] ComandoBytes = DefaultEncoding.GetBytes(Comando.ToString());
                        for (int n = 0; n < ComandoBytes.Length; n++) {
                                BCC += ComandoBytes[n];
                        }
                        Comando.Append(System.Convert.ToString(BCC, 16).ToUpper().PadLeft(4, '0'));

                        return Comando.ToString();
                }

                public override string ToString()
                {
                        string Res = "<Enviar" + System.Environment.NewLine;
                        Res += "  comando=" + this.CodigoComando.ToString() + System.Environment.NewLine;
                        Res += "  secuencia=" + this.Secuencia.ToString() + System.Environment.NewLine;
                        for (int i = 0; i < Campos.Length; i++) {
                                Res += "  campo_" + i.ToString() + "=" + this.Campos[i] + System.Environment.NewLine;
                        }
                        Res += "/>" + System.Environment.NewLine;
                        return Res;
                }
        }
}
