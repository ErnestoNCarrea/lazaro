using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Entidades
{
        /// <summary>
        /// Representa una moneda (divisa).
        /// </summary>
        [Lbl.Atributos.Nomenclatura(NombreSingular = "Moneda", Grupo = "Cuentas")]
        [Lbl.Atributos.Datos(TablaDatos = "monedas", CampoId = "id_moneda")]
        [Lbl.Atributos.Presentacion()]
        public class Moneda : ElementoDeDatos
        {
                //Heredar constructor
                public Moneda(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

                public Moneda(Lfx.Data.IConnection dataBase, int itemId)
                        : base(dataBase, itemId) { }

                public Moneda(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }


                public string Simbolo
                {
                        get
                        {
                                return this.GetFieldValue<string>("signo");
                        }
                        set
                        {
                                this.Registro["signo"] = value;
                        }
                }

                public string NomenclaturaIso
                {
                        get
                        {
                                return this.GetFieldValue<string>("iso");
                        }
                        set
                        {
                                this.Registro["iso"] = value;
                        }
                }

                public decimal Cotizacion
                {
                        get
                        {
                                return this.GetFieldValue<decimal>("cotizacion");
                        }
                        set
                        {
                                this.Registro["cotizacion"] = value;
                        }
                }


                public int Decimales
                {
                        get
                        {
                                return this.GetFieldValue<int>("decimales");
                        }
                        set
                        {
                                this.Registro["decimales"] = value;
                        }
                }
        }
}
