using System;
using System.Collections.Generic;
using System.Text;

namespace Lfc
{
        public class Contador
        {
                public string Etiqueta = "Contador", Prefijo = null, Sufijo = null;
                public Lui.Forms.DataTypes DataType = Lui.Forms.DataTypes.Float;
                public decimal Total = 0, Min = 0, Max = 0;
                public int CantidadValores = 0;

                public Contador(string etiqueta, Lui.Forms.DataTypes dataType)
                {
                        this.Etiqueta = etiqueta;
                        this.DataType = dataType;
                }

                public Contador(string etiqueta, Lui.Forms.DataTypes dataType, string prefijo, string sufijo)
                        : this(etiqueta, dataType)
                {
                        this.Prefijo = prefijo;
                        this.Sufijo = sufijo;
                }

                public void Reset()
                {
                        this.CantidadValores = 0;
                        this.Total = 0;
                        this.Min = 0;
                        this.Max = 0;
                }

                public void AddValue(decimal val)
                {
                        this.CantidadValores++;
                        this.Total += val;
                        if (val < this.Min)
                                this.Min = val;
                        if (val > this.Max)
                                this.Max = val;
                }


                public void SetValue(decimal val)
                {
                        this.CantidadValores = 1;
                        this.Total = val;
                        if (val < this.Min)
                                this.Min = val;
                        if (val > this.Max)
                                this.Max = val;
                }


                public override string ToString()
                {
                        return this.Etiqueta + "(" + this.CantidadValores.ToString() + "): " + this.Total.ToString(); 
                }
        }
}
