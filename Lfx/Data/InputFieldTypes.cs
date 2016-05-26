using System;
using System.Collections.Generic;

namespace Lfx.Data
{
        public enum InputFieldTypes
        {
                /// <summary>
                /// Número entero que indica un identificador de registro autonumérico.
                /// </summary>
                Serial,
                /// <summary>
                /// Número entero que indica un identificador de registro relacionado con otra tabla.
                /// </summary>
                Relation,
                /// <summary>
                /// Numero entero de 32 bits.
                /// </summary>
                Integer,
                /// <summary>
                /// Numero de doble precisión.
                /// </summary>
                Numeric,
                /// <summary>
                /// Numero que indica un valor monetario.
                /// </summary>
                Currency,
                /// <summary>
                /// Texto de largo variable de hasta 200 caracteres.
                /// </summary>
                Text,
                /// <summary>
                /// Número entero dentro de una serie
                /// </summary>
                Set,
                /// <summary>
                /// Texto de largo variable de largo extendido.
                /// </summary>
                Memo,
                /// <summary>
                /// Año y mes.
                /// </summary>
                YearMonth,
                /// <summary>
                /// Fecha.
                /// </summary>
                Date,
                /// <summary>
                /// Fecha y hora.
                /// </summary>
                DateTime,
                /// <summary>
                /// Imagen (normalmente JPEG).
                /// </summary>
                Image,
                /// <summary>
                /// Datos binarios.
                /// </summary>
                Binary,
                /// <summary>
                /// Valor booleano que indica si/no (normalmente se traduce a un entero pequeño 1/0).
                /// </summary>
                Bool,
                /// <summary>
                /// Número entero comprendido dentro un conjunto determinado, cada uno asociado con una etiqueta.
                /// </summary>
                NumericSet,
                /// <summary>
                /// Valor alfanumérico comprendido dentro un conjunto determinado, cada uno asociado con una etiqueta.
                /// </summary>
                AlphanumericSet
        }
}
