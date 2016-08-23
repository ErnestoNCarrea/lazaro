using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Afip.ControladorFiscal.Protocolo
{
        /// <summary>
        /// Algunos caracteres de control para uso del protocolo binario.
        /// </summary>
        public static class CaracteresDeControl
        {
                public const char PROTO_STX = (char)0x02;
                public const char PROTO_FS = (char)0x1C;
                public const char PROTO_ETX = (char)0x03;
                public const char PROTO_DC2 = (char)0x12;
                public const char PROTO_DC4 = (char)0x14;
                public const char PROTO_ACK = (char)0x06;
                public const char PROTO_NAK = (char)0x15;
        }
}
